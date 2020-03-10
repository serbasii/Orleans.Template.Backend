using Interfaces.Services;
using Orleans.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grains.Services
{
    public class StocksProxyServiceClient : GrainServiceClient<IStocksProxyGrainService>, IStocksProxyServiceClient
    {
        public StocksProxyServiceClient(IServiceProvider serviceProvider) 
               : base(serviceProvider)
        {

        }

        public Task<string> GetPriceQuoteAsync(string ticker) => GrainService.GetPriceQuoteAsync(ticker);

    }
}
