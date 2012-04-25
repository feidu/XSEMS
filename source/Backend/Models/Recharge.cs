using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Recharge
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

        private int _companyId;
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private string _clientName;
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
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

        private string _account;
        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }

        private DateTime _receiveTime;
        public DateTime ReceiveTime
        {
            get { return _receiveTime; }
            set { _receiveTime = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private PaymentType _paymentType;
        public PaymentType PaymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private int _paymentMethodId;
        public int PaymentMethodId
        {
            get { return _paymentMethodId; }
            set { _paymentMethodId = value; }
        }

        private string _paymentMethodName;
        public string PaymentMethodName
        {
            get { return _paymentMethodName; }
            set { _paymentMethodName = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private decimal _paid;
        public decimal Paid
        {
            get { return _paid; }
            set { _paid = value; }
        }

        private decimal _exchangeRate;
        public decimal ExchangeRate
        {
            get { return _exchangeRate; }
            set { _exchangeRate = value; }
        }

        private CurrencyType _currencyType;
        public CurrencyType CurrencyType
        {
            get { return _currencyType; }
            set { _currencyType = value; }
        }

        private string _invoice;
        public string Invoice
        {
            get { return _invoice; }
            set { _invoice = value; }
        }
    }
}
