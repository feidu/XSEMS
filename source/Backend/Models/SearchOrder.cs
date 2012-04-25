using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class SearchOrder:Order
    {
        private int _orderDetailId;
        public int OrderDetailId
        {
            get { return _orderDetailId; }
            set { _orderDetailId = value; }
        }

        private string _carrierEncode;
        public string CarrierEncode
        {
            get { return _carrierEncode; }
            set { _carrierEncode = value; }
        }

        private string _barCode;
        public string BarCode
        {
            get { return _barCode; }
            set { _barCode = value; }
        }

        private decimal _totalWeight;
        public decimal TotalWeight
        {
            get { return _totalWeight; }
            set { _totalWeight = value; }
        }

        private int _totalCount;
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }

        private decimal _totalCost;
        public decimal TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }
    }


    public class SearchOrderDetail : OrderDetail
    {
        private string _orderEncode;
        public string OrderEncode
        {
            get { return _orderEncode; }
            set { _orderEncode = value; }
        }

        private DateTime _orderReceiveDate;
        public DateTime OrderReceiveDate
        {
            get { return _orderReceiveDate; }
            set { _orderReceiveDate = value; }
        }

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        private decimal _totalFetchCosts;
        public decimal TotalFetchCosts
        {
            get { return _totalFetchCosts; }
            set { _totalFetchCosts = value; }
        }

        private decimal _totalDisposalCosts;
        public decimal TotalDisposalCosts
        {
            get { return _totalDisposalCosts; }
            set { _totalDisposalCosts = value; }
        }

        private decimal _totalMaterialCosts;
        public decimal TotalMaterialCosts
        {
            get { return _totalMaterialCosts; }
            set { _totalMaterialCosts = value; }
        }

        private decimal _totalOtherCosts;
        public decimal TotalOtherCosts
        {
            get { return _totalOtherCosts; }
            set { _totalOtherCosts = value; }
        }

        private bool _isArrive;
        public bool IsArrive
        {
            get { return _isArrive; }
            set { _isArrive = value; }
        }

        private string _postStatus;
        public string PostStatus
        {
            get { return _postStatus; }
            set { _postStatus = value; }
        }

        private DateTime _lastDisposalTime;
        public DateTime LastDisposalTime
        {
            get { return _lastDisposalTime; }
            set { _lastDisposalTime = value; }
        }

        private bool _isTracking;
        public bool IsTracking
        {
            get { return _isTracking; }
            set { _isTracking = value; }
        }

        private DateTime _trackingTime;
        public DateTime TrackingTime
        {
            get { return _trackingTime; }
            set { _trackingTime = value; }
        }

    }
}
