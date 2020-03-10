using Interfaces;
using Interfaces.Services;
using Intrinio.SDK.Api;
using Intrinio.SDK.Client;
using Intrinio.SDK.Model;
using Orleans;
using Orleans.Runtime;
using System;
using System.Threading.Tasks;

namespace Grains
{
    public class StocksStreamingGrain : Grain, IStocksStreamingGrain
    {
        private string price = null;

        private RealtimeStockPrice result = null;
        private readonly IStocksProxyServiceClient _stocksProxyServiceClient;

        public StocksStreamingGrain(IGrainActivationContext grainActivationContext,
                                    IStocksProxyServiceClient stocksProxyServiceClient)
        {
            _stocksProxyServiceClient = stocksProxyServiceClient;
        }

        public async override Task OnActivateAsync()
        {
            var ticker = this.GetPrimaryKeyString();

            await UpdatePrice(ticker);

            RegisterTimer(UpdatePrice,
                ticker,
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(10));

            await base.OnActivateAsync();
        }

        private async Task UpdatePrice(object stock)
        {
            price = await GetPriceQuote(stock as string);
            Console.WriteLine(price);
        }

        public Task<string> GetPrice()
        {
            return Task.FromResult(result.LastPrice.ToString());
        }

        public async Task<string> GetPriceQuote(string ticker)
        {
            return await _stocksProxyServiceClient.GetPriceQuoteAsync(ticker);
        }
    }
}