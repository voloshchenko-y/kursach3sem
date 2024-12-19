using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;


namespace kursach.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<IProduct> _products = new List<IProduct>
    {
        new Product("Laptop", 1000m, 5),
        new Product("Phone", 500m, 10),
        new Product("Headphones", 100m, 20)
    };

        public List<IProduct> GetAllProducts()
        {
            return _products;
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(string productName)
        {
            var product = _products.FirstOrDefault(p => p.Name == productName);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public IProduct GetProductByName(string productName)
        {
            return _products.FirstOrDefault(p => p.Name == productName);
        }
    }

}
