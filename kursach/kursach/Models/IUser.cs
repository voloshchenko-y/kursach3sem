using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Repositories;
using kursach.Services;

namespace kursach.Models

{
    public interface IUser
    {
        string Username { get; }
        decimal Balance { get; set; }
    }

}
