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
    public class CommandManager
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ShowCommands()
        {
            for (int i = 0; i < _commands.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _commands[i].ShowDescription();
            }
            Console.WriteLine("0. Log out");
        }

        public void ExecuteCommand(int choice)
        {
            if (choice >= 1 && choice <= _commands.Count)
            {
                _commands[choice - 1].Execute();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}

