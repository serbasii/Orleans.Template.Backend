using Interfaces.Services;
using Intrinio.SDK.Api;
using Intrinio.SDK.Client;
using Intrinio.SDK.Model;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Core;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grains.Services
{
    public class StocksProxyGrainService : GrainService, IStocksProxyGrainService
    {
        private RealtimeStockPrice result = null;
        public IGrainFactory GrainFactory { get; }

        public StocksProxyGrainService(IServiceProvider serviceProvider, 
                                        IGrainIdentity id, 
                                        Silo silo, 
                                        ILoggerFactory loggerFactory,
                                        IGrainFactory grainFactory ) :  base(id, silo, loggerFactory)
        {
            GrainFactory = grainFactory;
        }

        public async Task<string> GetPriceQuoteAsync(string ticker)
        {
            Configuration.Default.AddApiKey("api_key", "OmIyMzk1OGMzNTBjOTRjYjU2NjM2MWM5MzM0Yzc4YmJk");

            var securityApi = new SecurityApi();

            try
            {
                result = await securityApi.GetSecurityRealtimePriceAsync(ticker, null);
                Console.WriteLine(result.ToJson());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling SecurityApi.GetSecurityRealtimePrice: " + e.Message);
            }

            return result.LastPrice.ToString();
        }
    }
}
