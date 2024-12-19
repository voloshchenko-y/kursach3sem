using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.Models;
using kursach.Services;

namespace kursach.Commands
{
    public class ViewPurchaseHistoryCommand : ICommand
    {
        private readonly IShopService _shopService;
        private readonly IUser _user;

        public ViewPurchaseHistoryCommand(IShopService shopService, IUser user)
        {
            _shopService = shopService;
            _user = user;
        }

        public void Execute()
        {
            Console.WriteLine(_shopService.ViewPurchaseHistory(_user));
        }

        public void ShowDescription()
        {
            Console.WriteLine("View purchase history");
        }
    }
}

