using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class FetchArrange
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        private int _companyId;
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
       
        private OrderType _type;
        public OrderType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _clientName;
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private DateTime _fetchTime;
        public DateTime FetchTime
        {
            get { return _fetchTime; }
            set { _fetchTime = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
