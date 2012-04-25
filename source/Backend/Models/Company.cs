using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models.Admin;

namespace Backend.Models
{
    public class Company
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private AreaCode _areaCode;
        public AreaCode AreaCode
        {
            get { return _areaCode; }
            set { _areaCode = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _contactPerson;
        public string ContactPerson
        {
            get { return _contactPerson; }
            set { _contactPerson = value; }
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

        private string _contactEmail="joe@eadu.com";
        public string ContactEmail
        {
            get { return _contactEmail; }
            set { _contactEmail = value; }
        }

        private string _emailPassword;
        public string EmailPassword
        {
            get { return _emailPassword; }
            set { _emailPassword = value; }
        }
        private string _smtp;
        public string Smtp
        {
            get { return _smtp; }
            set { _smtp = value; }
        }

        private decimal _commission;
        public decimal Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }

        private List<ModuleAuthorization> _ModuleAuthorizations;
        public List<ModuleAuthorization> ModuleAuthorizations
        {
            get { return _ModuleAuthorizations; }
            set { _ModuleAuthorizations = value; }
        }

        private string _qq;
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }

        private string _msn;
        public string MSN
        {
            get { return _msn; }
            set { _msn = value; }
        }
    }
}
