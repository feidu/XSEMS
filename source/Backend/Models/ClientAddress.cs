using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class ClientAddress
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        private string _province;
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        private string _senderName;
        public string SenderName
        {
            get { return _senderName; }
            set { _senderName = value; }
        }

        private string _contactPerson;
        public string ContactPerson
        {
            get { return _contactPerson; }
            set { _contactPerson = value; }
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

        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
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
    }
}
