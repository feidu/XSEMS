using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Depot
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

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Department _department;
        public Department Department
        {
            get { return _department; }
            set { _department = value; }
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

        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }        
    }
}
