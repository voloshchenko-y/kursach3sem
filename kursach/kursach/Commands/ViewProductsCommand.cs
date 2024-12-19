using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Services;


namespace kursach.Commands
{
    public class ViewProductsCommand : ICommand
    {
        private readonly IShopService _shop;

        public ViewProductsCommand(IShopService shop)
        {
            _shop = shop;
        }

        public void Execute()
        {
            _shop.DisplayProducts();
        }

        public void ShowDescription()
        {
            Console.WriteLine("View products");
        }
    }
}

