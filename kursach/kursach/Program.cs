using kursach;
using System;
using System.Collections.Generic;
using System.Linq;
using kursach.Models;
using kursach.Repositories;
using kursach.Services;
using kursach.Commands;

class Program
{
    static void Main(string[] args)
    {
        IUserRepository userRepository = new UserRepository();
        IProductRepository productRepository = new ProductRepository();
        IShopService shopService = new ShopService(userRepository, productRepository);
        IUser currentUser = null;

        while (true)
        {
            Console.WriteLine("\n1. User Registration");
            Console.WriteLine("2. Admin Registration");
            Console.WriteLine("3. Login");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter username: ");
                    string regUsername = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string regPassword = Console.ReadLine();
                    currentUser = shopService.Register(regUsername, regPassword);
                    break;

                case "2":
                    Console.Write("Enter administrator username: ");
                    string adminUsername = Console.ReadLine();
                    currentUser = shopService.Register(adminUsername, null, isAdmin: true);
                    break;

                case "3":
                    Console.Write("Enter username: ");
                    string loginUsername = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string loginPassword = Console.ReadLine();
                    currentUser = shopService.Login(loginUsername, loginPassword);
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Error. Incorrect choice.");
                    continue;
            }

            while (currentUser != null)
            {
                if (currentUser is AdminUser)
                {
                    Console.WriteLine("\n1. Add product");
                    Console.WriteLine("2. Remove product");
                    Console.WriteLine("3. View products");
                    Console.WriteLine("4. Log out");
                    Console.Write("Choose option: ");
                    string adminOption = Console.ReadLine();

                    switch (adminOption)
                    {
                        case "1":
                            Console.Write("Enter product name: ");
                            string productName = Console.ReadLine();
                            Console.Write("Enter product price: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal price))
                            {
                                Console.Write("Enter product quantity: ");
                                if (int.TryParse(Console.ReadLine(), out int quantity))
                                {
                                    Console.WriteLine(shopService.AddProduct(productName, price, quantity));
                                }
                                else
                                {
                                    Console.WriteLine("Invalid quantity.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid price.");
                            }
                            break;

                        case "2":
                            Console.Write("Enter product name to remove: ");
                            string removeProductName = Console.ReadLine();
                            Console.WriteLine(shopService.RemoveProduct(removeProductName));
                            break;

                        case "3":
                            Console.WriteLine(shopService.DisplayProducts());
                            break;

                        case "4":
                            currentUser = null;
                            break;

                        default:
                            Console.WriteLine("Error. Incorrect choice.");
                            break;
                    }
                }
                else if (currentUser is User)
                {
                    Console.WriteLine("\n1. Top up balance");
                    Console.WriteLine("2. View products");
                    Console.WriteLine("3. Buy product");
                    Console.WriteLine("4. View purchase history");
                    Console.WriteLine("5. Log out");
                    Console.Write("Choose option: ");
                    string userOption = Console.ReadLine();

                    switch (userOption)
                    {
                        case "1":
                            Console.Write("Enter amount to top up: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                            {
                                Console.WriteLine(shopService.AddBalance(currentUser, amount));
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount.");
                            }
                            break;

                        case "2":
                            Console.WriteLine(shopService.DisplayProducts());
                            break;

                        case "3":
                            Console.Write("Enter product name: ");
                            string productName = Console.ReadLine();
                            Console.WriteLine(shopService.PurchaseProduct(currentUser, productName));
                            break;

                        case "4":
                            Console.WriteLine(shopService.ViewPurchaseHistory(currentUser));
                            break;

                        case "5":
                            currentUser = null;
                            break;

                        default:
                            Console.WriteLine("Error. Incorrect choice.");
                            break;
                    }
                }
            }
        }
    }
}
