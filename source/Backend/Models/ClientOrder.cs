using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class ClientOrder
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _encode;
        public string Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }

        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        private int _clientAddressId;
        public int ClientAddressId
        {
            get { return _clientAddressId; }
            set { _clientAddressId = value; }
        }
        
        private string _realName;
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
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

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _postcode;
        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private string _postAddress;
        public string PostAddress
        {
            get { return _postAddress; }
            set { _postAddress = value; }
        }
    }
}
