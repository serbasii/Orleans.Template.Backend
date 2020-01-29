using System;
using System.Collections.Generic;
using System.Text;
using Logger.Application;
using Logger.Queue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Log
{
    public class Logger : ILogger
    {
        private IApplication _application;

        private Logger()
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder().Build();

            IServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.AddSingleton<IApplication, Application>().BuildServiceProvider();
        }
    }
}