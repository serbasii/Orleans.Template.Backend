using Orleans.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IStocksProxyGrainService : IGrainService
    {
        Task<string> GetPriceQuoteAsync(string ticker);
    }
}