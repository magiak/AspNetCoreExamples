using AspNetCoreExamples.ClassLibrary.Services;
using AspNetCoreExamples.ConsoleAppWithoutHost.Examples;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;

namespace AspNetCoreExamples.ConsoleAppWithoutHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddUserSecrets("0ebb5397-00de-4e6b-8edf-644c830d9613"); // comment out to use appsettings.Production.json

            // mock setting environment variable   or use set ASPNETCORE_ENVIRONMENT = Production dotnet run and
            // Commands: 
            // set ASPNETCORE_ENVIRONMENT=Production
            // dotnet run
            // echo %ASPNETCORE_ENVIRONMENT%
            configurationBuilder.AddInMemoryCollection(new[] { KeyValuePair.Create("ASPNETCORE_ENVIRONMENT", "Production") }); // mock setting environment variable

            IConfiguration configuration = configurationBuilder.Build();
            var environment = configuration["ASPNETCORE_ENVIRONMENT"];
            configurationBuilder
                .AddJsonFile($"appsettings.{environment}.json", false, false);

            configuration = configurationBuilder.Build();

            // var config = new AppSettings();
            // configuration.Bind(AppSettings);

            var services = new ServiceCollection()
                .AddTransient<ExampleApp>()
                .AddTransient<Shop>()
                .AddSingleton<Warehouse>() // AddTransient
                .AddSingleton(configuration);

            services.AddSingleton(configuration);

            var serviceProvider = services
                .BuildServiceProvider();

            var exampleApp = serviceProvider.GetService<ExampleApp>();
            exampleApp.Run();

            var exampleApp2 = serviceProvider.GetService<ExampleApp>();
            exampleApp2.Run();
        }
    }
}
