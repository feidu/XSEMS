using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class AlreadyPaid
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        private Order _order;
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        private string _invoice;
        public string Invoice
        {
            get { return _invoice; }
            set { _invoice = value; }
        }

        private int _companyId;
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private Carrier _carrier;
        public Carrier Carrier
        {
            get { return _carrier; }
            set { _carrier = value; }
        }

        private PaymentMethod _paymentMethod;
        public PaymentMethod PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }

        private string _account;
        public string Account
        {
            get { return _account; }
            set { _account = value; }
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

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private DateTime _paidTime;
        public DateTime PaidTime
        {
            get { return _paidTime; }
            set { _paidTime = value; }
        }

        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private DateTime _endTime;
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
