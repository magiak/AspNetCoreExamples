using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreExamples.ClassLibrary.Services;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreExamples.ConsoleApp.Examples
{
    public class ExampleAppWorker : IHostedService
    {
        private readonly Shop _shop;
        public ExampleAppWorker(Shop shop)
        {
            _shop = shop;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var result = _shop.BuyProduct("Television");
            Console.WriteLine(result);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
