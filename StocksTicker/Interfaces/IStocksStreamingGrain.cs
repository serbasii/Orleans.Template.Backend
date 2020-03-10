using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IStocksStreamingGrain : Orleans.IGrainWithStringKey
    {
        Task<string> GetPrice();
    }
}