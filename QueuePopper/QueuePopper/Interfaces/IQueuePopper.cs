using RabbitMQ.Client;
using System.Threading.Tasks;

namespace QueuePopper.Interfaces
{
    public interface IQueuePopper
    {
        Task<object> GetMessage();
    }
}