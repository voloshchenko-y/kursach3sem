using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach.Models
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public List<string> PurchaseHistory { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Balance = 0;
            PurchaseHistory = new List<string>();
        }
    }

}
