using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class ClientRecharge
    {
        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        private List<Recharge> _rechargeList;
        public List<Recharge> RechargeList
        {
            get { return _rechargeList; }
            set { _rechargeList = value; }
        }
    }
}
