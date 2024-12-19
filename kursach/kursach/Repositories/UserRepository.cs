using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;

namespace kursach.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<IUser> _users = new List<IUser>();

        public IUser GetUser(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u is User regularUser && regularUser.Password == password);
        }


        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _users;
        }
    }

}
