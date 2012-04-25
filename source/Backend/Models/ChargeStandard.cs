using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class ChargeStandard
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _carrierId;
        public int CarrierId
        {
            get { return _carrierId; }
            set { _carrierId = value; }
        }

        private int _carrierAreaId;
        public int CarrierAreaId
        {
            get { return _carrierAreaId; }
            set { _carrierAreaId = value; }
        }

        private string _encode;
        public string Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }

        private byte _goodsType;
        public byte GoodsType
        {
            get { return _goodsType; }
            set { _goodsType = value; }
        }

        private decimal _startWeight;
        public decimal StartWeight
        {
            get { return _startWeight; }
            set { _startWeight = value; }
        }

        private decimal _endWeight;
        public decimal EndWeight
        {
            get { return _endWeight; }
            set { _endWeight = value; }
        }

        private decimal _baseWeight;
        public decimal BaseWeight
        {
            get { return _baseWeight; }
            set { _baseWeight = value; }
        }

        private decimal _increaseWeight;
        public decimal IncreaseWeight
        {
            get { return _increaseWeight; }
            set { _increaseWeight = value; }
        }

        private decimal _normalBasePrice;
        public decimal NormalBasePrice
        {
            get { return _normalBasePrice; }
            set { _normalBasePrice = value; }
        }

        private decimal _normalContinuePrice;
        public decimal NormalContinuePrice
        {
            get { return _normalContinuePrice; }
            set { _normalContinuePrice = value; }
        }

        private decimal _normalKgPrice;
        public decimal NormalKgPrice
        {
            get { return _normalKgPrice; }
            set { _normalKgPrice = value; }
        }

        private decimal _normalDisposalCost;
        public decimal NormalDisposalCost
        {
            get { return _normalDisposalCost; }
            set { _normalDisposalCost = value; }
        }

        private decimal _normalRegisterCost;
        public decimal NormalRegisterCost
        {
            get { return _normalRegisterCost; }
            set { _normalRegisterCost = value; }
        }

        private decimal _clientBasePrice;
        public decimal ClientBasePrice
        {
            get { return _clientBasePrice; }
            set { _clientBasePrice = value; }
        }

        private decimal _clientContinuePrice;
        public decimal ClientContinuePrice
        {
            get { return _clientContinuePrice; }
            set { _clientContinuePrice = value; }
        }

        private decimal _clientKgPrice;
        public decimal ClientKgPrice
        {
            get { return _clientKgPrice; }
            set { _clientKgPrice = value; }
        }

        private decimal _clientDisposalCost;
        public decimal ClientDisposalCost
        {
            get { return _clientDisposalCost; }
            set { _clientDisposalCost = value; }
        }

        private decimal _clientRegisterCost;
        public decimal ClientRegisterCost
        {
            get { return _clientRegisterCost; }
            set { _clientRegisterCost = value; }
        }

        private decimal _selfBasePrice;
        public decimal SelfBasePrice
        {
            get { return _selfBasePrice; }
            set { _selfBasePrice = value; }
        }

        private decimal _selfContinuePrice;
        public decimal SelfContinuePrice
        {
            get { return _selfContinuePrice; }
            set { _selfContinuePrice = value; }
        }

        private decimal _selfKgPrice;
        public decimal SelfKgPrice
        {
            get { return _selfKgPrice; }
            set { _selfKgPrice = value; }
        }

        private decimal _selfDisposalCost;
        public decimal SelfDisposalCost
        {
            get { return _selfDisposalCost; }
            set { _selfDisposalCost = value; }
        }

        private decimal _selfRegisterCost;
        public decimal SelfRegisterCost
        {
            get { return _selfRegisterCost; }
            set { _selfRegisterCost = value; }
        }

        private decimal _preferentialGram;
        public decimal PreferentialGram
        {
            get { return _preferentialGram; }
            set { _preferentialGram = value; }
        }
    }
}
