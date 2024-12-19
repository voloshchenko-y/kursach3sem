using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;
using kursach.Repositories;
using kursach.Services;

namespace kursach.Commands
{
    public interface ICommand
    {
        void Execute();
        void ShowDescription();
    }
}

