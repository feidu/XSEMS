using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class QuoteDetail
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _quoteId;
        public int QuoteId
        {
            get { return _quoteId; }
            set { _quoteId = value; }
        }

        private Carrier _carrier;
        public Carrier Carrier
        {
            get { return _carrier; }
            set { _carrier = value; }
        }

        private CarrierArea _carrierArea;
        public CarrierArea CarrierArea
        {
            get { return _carrierArea; }
            set { _carrierArea = value; }
        }

        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        private decimal _discount;
        public decimal Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        private decimal _preferentialGram;
        public decimal PreferentialGram
        {
            get { return _preferentialGram; }
            set { _preferentialGram = value; }
        }

        private bool _isRegisterAbate;
        public bool IsRegisterAbate
        {
            get { return _isRegisterAbate; }
            set { _isRegisterAbate = value; }
        }

        private decimal _registerCosts;
        public decimal RegisterCosts
        {
            get { return _registerCosts; }
            set { _registerCosts = value; }
        }

        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
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
    }
}
