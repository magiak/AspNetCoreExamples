using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreExamples.ClassLibrary.Services
{
    public class Warehouse
    {
        public Warehouse(IConfiguration configuration)
        {
            var productsSection = configuration.GetSection("Warehouse:Products").GetChildren();
            _products = productsSection.Select(p => p.Value).ToList();
        }

        private List<string> _products { get; set; }

        public bool HasProduct(string productName)
        {
            return _products.Any(x => x == productName);
        } 

        public string DispatchProduct(string productName)
        {
            if (!HasProduct(productName))
            {
                throw new Exception("Product not found in warehouse. Call method HasProduct before DispatchProduct.");
            }

            var product = _products.FirstOrDefault(x => x == productName);
            _products.Remove(product);

            return product;
        }
    }
}
