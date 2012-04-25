using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Liability
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

        private Order _order;
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        private int _companyId;
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private string _barCode;
        public string BarCode
        {
            get { return _barCode; }
            set { _barCode = value; }
        }

        private string _currencyType;
        public string CurrencyType
        {
            get { return _currencyType; }
            set { _currencyType = value; }
        }

        private string _createUser;
        public string CreateUser
        {
            get { return _createUser; }
            set { _createUser = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private LiabilityEventType _eventType;
        public LiabilityEventType EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        private bool _correctStatus;
        public bool CorrectStatus
        {
            get { return _correctStatus; }
            set { _correctStatus = value; }
        }

        private LiabilityStatus _status;
        public LiabilityStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _fillUser;
        public string FillUser
        {
            get { return _fillUser; }
            set { _fillUser = value; }
        }

        private DateTime _fillTime;
        public DateTime FillTime
        {
            get { return _fillTime; }
            set { _fillTime = value; }
        }

        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private decimal _totalMoney;
        public decimal TotalMoney
        {
            get { return _totalMoney; }
            set { _totalMoney = value; }
        }

        private string _zrDepartment;
        public string ZrDepartment
        {
            get { return _zrDepartment; }
            set { _zrDepartment = value; }
        }

        private decimal _zrDtMoney;
        public decimal ZrDtMoney
        {
            get { return _zrDtMoney; }
            set { _zrDtMoney = value; }
        }

        private string _zrUser;
        public string ZrUser
        {
            get { return _zrUser; }
            set { _zrUser = value; }
        }

        private decimal _zrUrMoney;
        public decimal ZrUrMoney
        {
            get { return _zrUrMoney; }
            set { _zrUrMoney = value; }
        }

        private string _clientName;
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }

        private decimal _clientPtEadu;
        public decimal ClientPtEadu
        {
            get { return _clientPtEadu; }
            set { _clientPtEadu = value; }
        }

        private decimal _eaduPtClient;
        public decimal EaduPtClient
        {
            get { return _eaduPtClient; }
            set { _eaduPtClient = value; }
        }

        private string _carrierName;
        public string CarrierName
        {
            get { return _carrierName; }
            set { _carrierName = value; }
        }

        private decimal _carrierPtEadu;
        public decimal CarrierPtEadu
        {
            get { return _carrierPtEadu; }
            set { _carrierPtEadu = value; }
        }

        private decimal _eaduPtCarrier;
        public decimal EaduPtCarrier
        {
            get { return _eaduPtCarrier; }
            set { _eaduPtCarrier = value; }
        }

        private string _jlDepartment;
        public string JlDepartment
        {
            get { return _jlDepartment; }
            set { _jlDepartment = value; }
        }

        private decimal _jlDtMoney;
        public decimal JlDtMoney
        {
            get { return _jlDtMoney; }
            set { _jlDtMoney = value; }
        }

        private string _jlUser;
        public string JlUser
        {
            get { return _jlUser; }
            set { _jlUser = value; }
        }

        private decimal _jlUrMoney;
        public decimal JlUrMoney
        {
            get { return _jlUrMoney; }
            set { _jlUrMoney = value; }
        }

        private string _liabilityUser;
        public string LiabilityUser
        {
            get { return _liabilityUser; }
            set { _liabilityUser = value; }
        }

        private string _correctUser;
        public string CorrectUser
        {
            get { return _correctUser; }
            set { _correctUser = value; }
        }

        private string _financeUser;
        public string FinanceUser
        {
            get { return _financeUser; }
            set { _financeUser = value; }
        }

        private string _cashierUser;
        public string CashierUser
        {
            get { return _cashierUser; }
            set { _cashierUser = value; }
        }
    }
}
