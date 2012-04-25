using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Carrier
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
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

        private string _returnAddress;
        public string ReturnAddress
        {
            get { return _returnAddress; }
            set { _returnAddress = value; }
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

        private string _quoteType;
        public string QuoteType
        {
            get { return _quoteType; }
            set { _quoteType = value; }
        }

        private bool _isInvoice;
        public bool IsInvoice
        {
            get { return _isInvoice; }
            set { _isInvoice = value; }
        }
        
        private bool _isLimitWeight;
        public bool IsLimitWeight
        {
            get { return _isLimitWeight; }
            set { _isLimitWeight = value; }
        }

        private decimal _minWeight;
        public decimal MinWeight
        {
            get { return _minWeight; }
            set { _minWeight = value; }
        }

        private decimal _maxWeight;
        public decimal MaxWeight
        {
            get { return _maxWeight; }
            set { _maxWeight = value; }
        }

        private bool _isOpenApi;
        public bool IsOpenApi
        {
            get { return _isOpenApi; }
            set { _isOpenApi = value; }
        }

        private decimal _clientDiscount;
        public decimal ClientDiscount
        {
            get { return _clientDiscount; }
            set { _clientDiscount = value; }
        }

        private decimal _agencyDiscount;
        public decimal AgencyDiscount
        {
            get { return _agencyDiscount; }
            set { _agencyDiscount = value; }
        }

        private decimal _fuelSgRate;
        /// <summary>
        /// 燃油附加率（Fuel surcharge rate）
        /// </summary>
        public decimal FuelSgRate
        {
            get { return _fuelSgRate; }
            set { _fuelSgRate = value; }
        }

        private decimal _otherCosts = 8;
        public decimal OtherCosts
        {
            get { return _otherCosts; }
            set { _otherCosts = value; }
        }

        private bool _isFollow;
        public bool IsFollow
        {
            get { return _isFollow; }
            set { _isFollow = value; }
        }

        private bool _isUseable;
        public bool IsUseable
        {
            get { return _isUseable; }
            set { _isUseable = value; }
        }

        private bool _isClientShow;
        public bool IsClientShow
        {
            get { return _isClientShow; }
            set { _isClientShow = value; }
        }

        private string _transportTime;
        public string TransportTime
        {
            get { return _transportTime; }
            set { _transportTime = value; }
        }

        private bool _isChargeByWV;
        /// <summary>
        /// 是否按重量体积计费
        /// </summary>
        public bool IsChargeByWV
        {
            get { return _isChargeByWV; }
            set { _isChargeByWV = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

    }
}
