using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class DailyCost
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

        private int _orderUserId;
        public int OrderUserId
        {
            get { return _orderUserId; }
            set { _orderUserId = value; }
        }

        private string _orderUserName;
        public string OrderUserName
        {
            get { return _orderUserName; }
            set { _orderUserName = value; }
        }

        private int _auditUserId;
        public int AuditUserId
        {
            get { return _auditUserId; }
            set { _auditUserId = value; }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _departmentName;
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        private int _costTypeId;
        public int CostTypeId
        {
            get { return _costTypeId; }
            set { _costTypeId = value; }
        }

        private string _costType;
        public string CostType
        {
            get { return _costType; }
            set { _costType = value; }
        }

        private int _companyId;
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        
        private string _encode;
        public string Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }

        private decimal _money;
        public decimal Money
        {
            get { return _money; }
            set { _money = value; }
        }

        private DateTime _orderTime;
        /// <summary>
        /// 产生日期
        /// </summary>
        public DateTime OrderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        private DailyCostStatus _status;
        public DailyCostStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private DateTime _auditTime;
        public DateTime AuditTime
        {
            get { return _auditTime; }
            set { _auditTime = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

    }
}
