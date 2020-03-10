using Grains;
using Interfaces;
using Orleans;
using Orleans.Configuration;
using Orleans.Runtime;
using Polly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StocksStreamSubscriptionClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.Sleep(20000);
            var client = InitClient().Result;

            var grain = client.GetGrain<IStocksStreamingGrain>("AAPL");

            var price = grain.GetPrice().GetAwaiter().GetResult();

            Console.WriteLine($"Price: {price}");
        }

        private static async Task<IClusterClient> InitClient()
        {
            //return Policy<IClusterClient>
            //    .Handle<SiloUnavailableException>()
            //    .Or<OrleansMessageRejectionException>()
            //    .WaitAndRetry(

            //    new[] {
            //        TimeSpan.FromSeconds(2),
            //        TimeSpan.FromSeconds(4)
            //    })
            //    .Execute(() =>
            //    {
            var client = new ClientBuilder()
            .UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "StocksTickerApp";
            })

            .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(IStocksStreamingGrain).Assembly))
            .Build();

            await client.Connect();

            Console.WriteLine($"client successfully connected to silo");

            return client;
            //});
        }
    }
}