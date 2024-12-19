using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;

namespace kursach.Services
{
    public interface IShopService
    {
        IUser Register(string username, string password, bool isAdmin = false);
        IUser Login(string username, string password);
        string AddBalance(IUser user, decimal amount);
        string PurchaseProduct(IUser user, string productName);
        string DisplayProducts();
        string ViewPurchaseHistory(IUser user);
        string AddProduct(string name, decimal price, int quantity);
        string RemoveProduct(string name);

    }
}
