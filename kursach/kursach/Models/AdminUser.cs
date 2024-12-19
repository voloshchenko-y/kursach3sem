using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Repositories;
using kursach.Services;

namespace kursach.Models
{
    public class AdminUser : IUser
    {
        public string Username { get; set; }
        public decimal Balance
        {
            get => 0;
            set { }
        }

        public AdminUser(string username)
        {
            Username = username;
        }
    }


}
