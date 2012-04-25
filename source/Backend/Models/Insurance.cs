using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Insurance
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _orderId;
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private int _orderDetailId;
        public int OrderDetailId
        {
            get { return _orderDetailId; }
            set { _orderDetailId = value; }
        }

        private decimal _insureWorth;
        public decimal InsureWorth
        {
            get { return _insureWorth; }
            set { _insureWorth = value; }
        }

        private decimal _insureCosts;
        public decimal InsureCosts
        {
            get { return _insureCosts; }
            set { _insureCosts = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private int _createUserId;
        public int CreateUserId
        {
            get { return _createUserId; }
            set { _createUserId = value; }
        }

        private string _orderEncode;
        public string OrderEncode
        {
            get { return _orderEncode; }
            set { _orderEncode = value; }
        }

        private string _orderDetailBarCode;
        public string OrderDetailBarCode
        {
            get { return _orderDetailBarCode; }
            set { _orderDetailBarCode = value; }
        }

        private string _carrierName;
        public string CarrierName
        {
            get { return _carrierName; }
            set { _carrierName = value; }
        }

        private string _clientName;
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
    }
}
