using System;
using System.Collections.Generic;
using System.Text;
using Backend.BAL;

namespace Backend.Models
{
    public class OrderDetail
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

        private int _orderId;
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        private string _carrierEncode;
        public string CarrierEncode
        {
            get { return _carrierEncode; }
            set { _carrierEncode = value; }
        }

        private decimal _weight;
        public decimal Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private byte _type;
        public byte Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private decimal _kgPrice;
        public decimal KgPrice
        {
            get { return _kgPrice; }
            set { _kgPrice = value; }
        }

        private decimal _postCosts;
        public decimal PostCosts
        {
            get { return _postCosts; }
            set { _postCosts = value; }
        }

        private decimal _selfPostCosts;
        public decimal SelfPostCosts
        {
            get { return _selfPostCosts; }
            set { _selfPostCosts = value; }
        }

        private decimal _registerCosts;
        public decimal RegisterCosts
        {
            get { return _registerCosts; }
            set { _registerCosts = value; }
        }

        private decimal _disposalCosts;
        public decimal DisposalCosts
        {
            get { return _disposalCosts; }
            set { _disposalCosts = value; }
        }

        private decimal _remoteCosts;
        public decimal RemoteCosts
        {
            get { return _remoteCosts; }
            set { _remoteCosts = value; }
        }

        private decimal _fetchCosts;
        public decimal FetchCosts
        {
            get { return _fetchCosts; }
            set { _fetchCosts = value; }
        }

        private decimal _materialCosts;
        public decimal MaterialCosts
        {
            get { return _materialCosts; }
            set { _materialCosts = value; }
        }

        private decimal _otherCosts;
        public decimal OtherCosts
        {
            get { return _otherCosts; }
            set { _otherCosts = value; }
        }

        private string _otherCostsNote;
        public string OtherCostsNote
        {
            get { return _otherCostsNote; }
            set { _otherCostsNote = value; }
        }

        private decimal _insureCosts;
        public decimal InsureCosts
        {
            get { return _insureCosts; }
            set { _insureCosts = value; }
        }

        private decimal _addressChangeCosts;
        public decimal AddressChangeCosts
        {
            get { return _addressChangeCosts; }
            set { _addressChangeCosts = value; }
        }

        private decimal _returnCosts;
        public decimal ReturnCosts
        {
            get { return _returnCosts; }
            set { _returnCosts = value; }
        }

        private decimal _fuelCosts;
        public decimal FuelCosts
        {
            get { return _fuelCosts; }
            set { _fuelCosts = value; }
        }

        private decimal _damageMoney;
        public decimal DamageMoney
        {
            get { return _damageMoney; }
            set { _damageMoney = value; }
        }

        private decimal _returnMoney;
        public decimal ReturnMoney
        {
            get { return _returnMoney; }
            set { _returnMoney = value; }
        }       

        private decimal _totalCosts;
        public decimal TotalCosts
        {
            get { return _totalCosts; }
            set { _totalCosts = value; }
        }

        private decimal _selfTotalCosts;
        public decimal SelfTotalCosts
        {
            get { return _selfTotalCosts; }
            set { _selfTotalCosts = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private string _barCode;
        public string BarCode
        {
            get { return _barCode; }
            set { _barCode = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
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

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private int _clientCount;
        public int ClientCount
        {
            get { return _clientCount; }
            set { _clientCount = value; }
        }

        private decimal _clientWeight;
        public decimal ClientWeight
        {
            get { return _clientWeight; }
            set { _clientWeight = value; }
        }

        private string _declareCnName;
        public string DeclareCnName
        {
            get { return _declareCnName; }
            set { _declareCnName = value; }
        }

        private decimal _declareWorth;
        public decimal DeclareWorth
        {
            get { return _declareWorth; }
            set { _declareWorth = value; }
        }

        private string _hsEncode;
        public string HsEncode
        {
            get { return _hsEncode; }
            set { _hsEncode = value; }
        }

        private int _cancelUser;
        public int CancelUser
        {
            get { return _cancelUser; }
            set { _cancelUser = value; }
        }

        private DateTime _cancelTime;
        public DateTime CancelTime
        {
            get { return _cancelTime; }
            set { _cancelTime = value; }
        }

        private bool _isArrive;
        public bool IsArrive
        {
            get { return _isArrive; }
            set { _isArrive = value; }
        }
      
    }
}
