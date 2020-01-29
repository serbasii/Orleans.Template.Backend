using RabbitMQ.Client;
using System.Threading.Tasks;

namespace QueuePopper.Interfaces
{
    public interface IDao
    {
        Task<BasicGetResult> GetMessage();
    }
}