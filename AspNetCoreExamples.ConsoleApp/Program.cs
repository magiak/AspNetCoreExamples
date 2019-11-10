using System.Threading.Tasks;
using AspNetCoreExamples.ClassLibrary.Services;
using AspNetCoreExamples.ConsoleApp.Examples;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreExamples.ConsoleApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args)
                .RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddTransient<Shop>()
                        .AddSingleton<Warehouse>(); // AddTransient

                    services.AddHostedService<ExampleAppWorker>();
                })
                .ConfigureLogging(config =>
                {
                    // clear out default configuration
                    // config.ClearProviders(); or configure logging in appsettings.json 
                });
    }
}
