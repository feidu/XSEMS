using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class ReceivedDeducted
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _companyId;
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        private string _srEncode;
        public string SrEncode
        {
            get { return _srEncode; }
            set { _srEncode = value; }
        }

        private string _arEncode;
        public string ArEncode
        {
            get { return _arEncode; }
            set { _arEncode = value; }
        }

        private string _arAccount;
        public string ArAccount
        {
            get { return _arAccount; }
            set { _arAccount = value; }
        }

        private int _arUserId;
        public int ArUserId
        {
            get { return _arUserId; }
            set { _arUserId = value; }
        }

        private decimal _money;
        public decimal Money
        {
            get { return _money; }
            set { _money = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        
    }
}
