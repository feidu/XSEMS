using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models.Admin;

namespace Backend.Models
{

    public class UserBase
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _realName;

        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        private string _idCard;

        public string IdCard
        {
            get { return _idCard; }
            set { _idCard = value; }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _companyId;

        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private DateTime _createDate;

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
    }

    public class User : UserBase
    {

        private int _departmentId;

        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }

        private byte _positionId;

        public byte PositionId
        {
            get { return _positionId; }
            set { _positionId = value; }
        }
        
        private bool _sex;

        public bool Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private string _nation;

        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        private DateTime _birthday;

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private DateTime _joinDate;

        public DateTime JoinDate
        {
            get { return _joinDate; }
            set { _joinDate = value; }
        }

        private DateTime _contractDate;

        public DateTime ContractDate
        {
            get { return _contractDate; }
            set { _contractDate = value; }
        }

        private string _education;

        public string Education
        {
            get { return _education; }
            set { _education = value; }
        }

        private decimal _commission;

        public decimal Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }

        private string _maritalStatus;

        public string MaritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }

        private List<ModuleAuthorization> _ModuleAuthorizations;

        public List<ModuleAuthorization> ModuleAuthorizations
        {
            get { return _ModuleAuthorizations; }
            set { _ModuleAuthorizations = value; }
        }
    }
}
