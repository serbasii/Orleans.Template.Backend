using System;
using System.Threading.Tasks;

namespace Orleans.Example
{
    public class PersonGrain : Grain, IPersonGrain
    {
        public async Task SayHelloAsync()
        {
            string primaryKey = this.GetPrimaryKeyString();
            Console.WriteLine($"{primaryKey} said hello!");
            await Task.CompletedTask;
        }
    }
}
