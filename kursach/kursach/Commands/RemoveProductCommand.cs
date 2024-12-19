using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Services;


namespace kursach.Commands
{
    public class RemoveProductCommand : ICommand
    {
        private readonly IShopService _shop;

        public RemoveProductCommand(IShopService shop)
        {
            _shop = shop;
        }

        public void Execute()
        {
            Console.Write("Enter product name to remove: ");
            string name = Console.ReadLine();

            _shop.RemoveProduct(name);
            Console.WriteLine($"Product {name} removed successfully.");
        }

        public void ShowDescription()
        {
            Console.WriteLine("Remove Product");
        }
    }
}

