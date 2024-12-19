using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;


namespace kursach.Repositories
{
    public interface IUserRepository
    {
        IUser GetUser(string username, string password);
        void AddUser(IUser user);
        IEnumerable<IUser> GetAllUsers();
    }

}
