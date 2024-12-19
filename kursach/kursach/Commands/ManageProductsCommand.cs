using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;
using kursach.Services;
using System;

namespace kursach.Commands
{
    public class ManageProductsCommand : ICommand
    {
        private readonly AdminUser _admin;
        private readonly IShopService _shop;

        public ManageProductsCommand(AdminUser admin, IShopService shop)
        {
            _admin = admin;
            _shop = shop;
        }

        public void Execute()
        {
            while(true)
            {
                Console.WriteLine("\n1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Exit");

                Console.Write("Choose option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ICommand addProduct = new AddProductCommand(_shop);
                        addProduct.Execute();
                        break;

                    case "2":
                        ICommand removeProduct = new RemoveProductCommand(_shop);
                        removeProduct.Execute();
                        break;

                    case "3":
                        ICommand viewProducts = new ViewProductsCommand(_shop);
                        viewProducts.Execute();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
    }

        public void ShowDescription()
        {
            Console.WriteLine("Administrator - Manage products");
        }
    }
}

