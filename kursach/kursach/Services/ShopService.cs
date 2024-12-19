using kursach.Models;
using kursach.Repositories;
using System.Text;

namespace kursach.Services
{
    public class ShopService : IShopService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public ShopService(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public IUser Register(string username, string password, bool isAdmin = false)
        {
            if (isAdmin)
            {
                Console.Write("Enter admin-panel password: ");
                string adminPassword = Console.ReadLine();

                if (adminPassword == "1234")
                {
                    var adminUser = new AdminUser(username);
                    _userRepository.AddUser(adminUser);
                    Console.WriteLine("Administrator registration successful!");
                    return adminUser;
                }
                else
                {
                    Console.WriteLine("Incorrect admin-panel password. Registration failed.");
                    return null;
                }
            }
            else
            {
                var user = new User(username, password);
                _userRepository.AddUser(user);
                Console.WriteLine("User registration successful!");
                return user;
            }
        }


        public IUser Login(string username, string password)
        {
            return _userRepository.GetUser(username, password);
        }

        public string AddBalance(IUser user, decimal amount)
        {
            user.Balance += amount;
            return $"Balance topped up. Current balance: ${user.Balance}";
        }

        public string PurchaseProduct(IUser user, string productName)
        {
            var sb = new StringBuilder();

            if (user is User regularUser)
            {
                var product = _productRepository.GetProductByName(productName);
                if (product != null && product.Quantity > 0 && product.Price <= regularUser.Balance)
                {
                    product.Quantity--;
                    regularUser.Balance -= product.Price;
                    regularUser.PurchaseHistory.Add(productName);
                    sb.AppendLine($"Product {productName} has been purchased successfully!");
                }
                else
                {
                    sb.AppendLine("Couldn't buy product. Maybe not enough money or product isn't currently available.");
                }
            }
            else
            {
                sb.AppendLine("Only regular users can buy products.");
            }

            return sb.ToString();
        }


        public string DisplayProducts()
        {
            var sb = new StringBuilder();
            sb.AppendLine("\nAvailable Products:");

            foreach (var product in _productRepository.GetAllProducts())
            {
                sb.AppendLine($"{product.Name} - ${product.Price} - Quantity: {product.Quantity}");
            }

            return sb.ToString();
        }

        public string ViewPurchaseHistory(IUser user)
        {
            var sb = new StringBuilder();
            sb.AppendLine("\nPurchase History:");

            if (user is User regularUser && regularUser.PurchaseHistory.Count > 0)
            {
                foreach (var item in regularUser.PurchaseHistory)
                {
                    sb.AppendLine(item);
                }
            }
            else
            {
                sb.AppendLine("No purchase history available.");
            }

            return sb.ToString();
        }
        public string AddProduct(string name, decimal price, int quantity)
        {
            var product = new Product(name, price, quantity);
            _productRepository.AddProduct(product);
            return $"Product {name} added successfully.";
        }

        public string RemoveProduct(string name)
        {
            _productRepository.RemoveProduct(name);
            return $"Product {name} removed successfully.";
        }
    }
}
