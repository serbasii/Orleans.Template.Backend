using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Runtime;
using Polly;
using SimpleLoggingService.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class Program
    {
        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            try
            {
                using (var client = ConnectClient())
                {
                    await DoClientWork(client);
                    Console.ReadKey();
                }

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException while trying to run client: {e.Message}");
                Console.WriteLine("Make sure the silo the client is trying to connect to is running.");
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
                return 1;
            }
        }

        private static IClusterClient ConnectClient()
        {

            return Policy<IClusterClient>
                .Handle<SiloUnavailableException>()
                .Or<OrleansMessageRejectionException>()
                .WaitAndRetry(
                new[] {
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(4)
                })
                .Execute(() =>
                {

                    IClusterClient client;
                    client = new ClientBuilder()
                        .UseLocalhostClustering()
                        .Configure<ClusterOptions>(options =>
                        {
                            options.ClusterId = "dev";
                            options.ServiceId = "OrleansBasics";
                        })
                        .ConfigureLogging(logging => logging.AddConsole())
                        .Build();

                    client.Connect().GetAwaiter().GetResult();
                    Console.WriteLine("Client successfully connected to silo host \n");
                    return client;
                });
        }

        private static async Task DoClientWork(IClusterClient client)
        {
            // example of calling grains from the initialized client
            var friend = client.GetGrain<IConvertMessage>(Guid.NewGuid());
            var response = await friend.ConvertMessage(Encoding.UTF8.GetBytes("Test"));
            Console.WriteLine("\n\n{0}\n\n", response);
        }
    }
}