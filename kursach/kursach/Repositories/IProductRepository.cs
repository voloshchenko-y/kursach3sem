using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;


namespace kursach.Repositories
{
    public interface IProductRepository
    {
        List<IProduct> GetAllProducts();
        void AddProduct(IProduct product);
        void RemoveProduct(string productName);
        IProduct GetProductByName(string productName);
    }

}
