using System.Threading.Tasks;

namespace Orleans.Example
{
    public interface IPersonGrain : IGrainWithStringKey
    {
        Task SayHelloAsync();
    }
}
