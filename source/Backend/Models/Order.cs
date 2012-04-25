using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Order
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; }
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
      
        private OrderStatus _status;
        public OrderStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private OrderType _type;
        public OrderType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _encode;
        public string Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private DateTime _receiveDate;
        public DateTime ReceiveDate
        {
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }

        private string _receiveType;
        public string ReceiveType
        {
            get { return _receiveType; }
            set { _receiveType = value; }
        }

        private decimal _costs;
        public decimal Costs
        {
            get { return _costs; }
            set { _costs = value; }
        }

        private decimal _selfCosts;
        public decimal SelfCosts
        {
            get { return _selfCosts; }
            set { _selfCosts = value; }
        }
           
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _receiveUserId;
        public int ReceiveUserId
        {
            get { return _receiveUserId; }
            set { _receiveUserId = value; }
        }

        private User _createUser;
        public User CreateUser
        {
            get { return _createUser; }
            set { _createUser = value; }
        }

        private bool _isDelete;
        public bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private int _calculateType;
        public int CalculateType
        {
            get { return _calculateType; }
            set { _calculateType = value; }
        }

        private bool _isMailSend;
        public bool IsMailSend
        {
            get { return _isMailSend; }
            set { _isMailSend = value; }
        }

        private int _auditUserId;
        public int AuditUserId
        {
            get { return _auditUserId; }
            set { _auditUserId = value; }
        }

        private DateTime _auditTime;
        public DateTime AuditTime
        {
            get { return _auditTime; }
            set { _auditTime = value; }
        }

        private int _checkUserId;
        public int CheckUserId
        {
            get { return _checkUserId; }
            set { _checkUserId = value; }
        }

        private DateTime _checkTime;
        public DateTime CheckTime
        {
            get { return _checkTime; }
            set { _checkTime = value; }
        }

        private string _reason;
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        private string _toUsername;
        public string ToUsername
        {
            get { return _toUsername; }
            set { _toUsername = value; }
        }

        private string _toPhone;
        public string ToPhone
        {
            get { return _toPhone; }
            set { _toPhone = value; }
        }

        private string _toEmail;
        public string ToEmail
        {
            get { return _toEmail; }
            set { _toEmail = value; }
        }

        private string _toCity;
        public string ToCity
        {
            get { return _toCity; }
            set { _toCity = value; }
        }

        private string _toCountry;
        public string ToCountry
        {
            get { return _toCountry; }
            set { _toCountry = value; }
        }

        private string _toAddress;
        public string ToAddress
        {
            get { return _toAddress; }
            set { _toAddress = value; }
        }

        private string _toPostcode;
        public string ToPostcode
        {
            get { return _toPostcode; }
            set { _toPostcode = value; }
        }

        private bool _isQuickOrder;
        public bool IsQuickOrder
        {
            get { return _isQuickOrder; }
            set { _isQuickOrder = value; }
        }
    }
}
