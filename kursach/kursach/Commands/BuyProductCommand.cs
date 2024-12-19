using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;
using kursach.Services;

namespace kursach.Commands
{
    public class BuyProductCommand : ICommand
    {
        private readonly IShopService _shop;
        private readonly IUser _user;

        public BuyProductCommand(IShopService shop, IUser user)
        {
            _shop = shop;
            _user = user;
        }

        public void Execute()
        {
            Console.Write("Enter name of product to buy: ");
            string productName = Console.ReadLine();
            _shop.PurchaseProduct(_user, productName);
        }

        public void ShowDescription()
        {
            Console.WriteLine("Buy product");
        }
    }
}

