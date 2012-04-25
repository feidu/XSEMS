using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class CompanySales
    {
        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { _company = value; }
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
