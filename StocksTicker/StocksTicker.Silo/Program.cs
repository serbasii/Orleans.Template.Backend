using Grains;
using Grains.Services;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using System;
using System.Threading.Tasks;

namespace StocksTicker.Silo
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return RunSilo().Result;
        }

        private static async Task<int> RunSilo()
        {
            try
            {
                var host = await StartSilo();

                Console.WriteLine("Press enter to terminate silo...");
                Console.ReadLine();

                await host.StopAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }

        private static async Task<ISiloHost> StartSilo()
        {
            var silo = new SiloHostBuilder()
            .UseLocalhostClustering()
            .AddGrainService<StocksProxyGrainService>()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IStocksProxyServiceClient, StocksProxyServiceClient>();
            })
            // Clustering information
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "StocksTickerApp";
            })
            // Endpoints
            .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000) //127.0.0.1:30000
            // Application parts: just reference one of the grain implementations that we use
            .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(StocksStreamingGrain).Assembly).WithReferences())
            // Now create the silo!
            .Build();

            await silo.StartAsync();
            return silo;
        }
    }
}