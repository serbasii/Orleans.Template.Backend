using SimpleLoggingInterfaces.Interfaces;
using System.Threading.Tasks;

namespace SimpleLoggingService.Interfaces
{
    public interface IErrorDao : Orleans.IGrainWithGuidKey
    {
    }
}