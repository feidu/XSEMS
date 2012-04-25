using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class UserSales
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        private decimal _money;
        public decimal Money
        {
            get { return _money; }
            set { _money = value; }
        }

        private decimal _profit;
        public decimal Profit
        {
            get { return _profit; }
            set { _profit = value; }
        }
    }
}
