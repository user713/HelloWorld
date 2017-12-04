using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Set up the IoC container.
            IServiceProvider serviceProvider = BuildContainer();

            // Main logic: Get a message repo, get the message, and output it somewhere.
            IMessageRepository messageRepo = serviceProvider.GetService<IMessageRepository>();
            IOutput output = serviceProvider.GetService<IOutput>();
            var message = messageRepo.GetMessage();
            output.Write(message);
        }

        /// <summary>
        /// Builds the program dependencies.  Configure future source message repos or output targets here.
        /// </summary>
        /// <returns></returns>
        private static IServiceProvider BuildContainer()
        {
            var serviceCollection = new ServiceCollection();

            // Use this for local testing.
            //serviceCollection.AddSingleton<IMessageRepository, LocalMessageRepository>();

            serviceCollection.AddSingleton<IMessageRepository, WebApiMessageRepository>();
            serviceCollection.AddSingleton<IWebApiSettings, ConfigWebApiSettings>();
            serviceCollection.AddSingleton<IConfigurationRoot>(provider =>
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var config = builder.Build();
                return config;
            });

            serviceCollection.AddSingleton<IOutput, ConsoleOutput>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}