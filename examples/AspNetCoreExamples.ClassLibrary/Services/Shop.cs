using System;

namespace AspNetCoreExamples.ClassLibrary.Services
{
    public class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public string BuyProduct(string productName)
        {
            if (!_warehouse.HasProduct(productName))
            {
                return "Product not found";
            }

            var product = _warehouse.DispatchProduct(productName);

            // TODO pay, ...


            return $"Successfully purchased one {product}";
        }
    }
}
