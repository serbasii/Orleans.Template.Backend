using Orleans.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Services
{
    public interface IStocksProxyServiceClient : IGrainServiceClient<IStocksProxyGrainService>, IStocksProxyGrainService
    {
    }
}