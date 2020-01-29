using System;
using System.Threading.Tasks;

namespace SimpleLoggingService.Interfaces
{
    public interface IConvertMessage : Orleans.IGrainWithGuidKey
    {
        Task<bool> ConvertMessage(byte[] message);
    }
}