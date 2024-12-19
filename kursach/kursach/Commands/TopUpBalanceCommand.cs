using kursach.Models;
using kursach.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace kursach.Commands;

public class TopUpBalanceCommand : ICommand
{
    private readonly IShopService _shop;
    private readonly IUser _user;

    public TopUpBalanceCommand(IShopService shop, IUser user)
    {
        _shop = shop;
        _user = user;
    }

    public void Execute()
    {
        Console.Write("Enter amount of money: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            _shop.AddBalance(_user, amount);
        }
        else
        {
            Console.WriteLine("Error. Incorrect amount.");
        }
    }

    public void ShowDescription()
    {
        Console.WriteLine("Top up balance");
    }
}

