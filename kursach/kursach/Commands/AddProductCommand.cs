using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Services;

namespace kursach.Commands
{
    public class AddProductCommand : ICommand
    {
        private readonly IShopService _shop;

        public AddProductCommand(IShopService shop)
        {
            _shop = shop;
        }

        public void Execute()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            _shop.AddProduct(name, price, quantity);
            Console.WriteLine($"Product {name} added successfully.");
        }

        public void ShowDescription()
        {
            Console.WriteLine("Add Product");
        }
    }
}

