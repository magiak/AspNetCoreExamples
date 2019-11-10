using System;
using AspNetCoreExamples.ClassLibrary.Services;

namespace AspNetCoreExamples.ConsoleAppWithoutHost.Examples
{
    public class ExampleApp
    {
        private readonly Shop _shop;

        public ExampleApp(Shop shop)
        {
            _shop = shop;
        }

        public void Run()
        {
            // TODO while and Console.Read
            var result = _shop.BuyProduct("Television");

            Console.WriteLine(result);
        }
    }
}
