using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class WrongOrder
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        private string _encode;
        public string Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }

        private string _barCode;
        public string BarCode
        {
            get { return _barCode; }
            set { _barCode = value; }
        }

        private Order _order;
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        private string _reason;
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        private int _createUserId;
        public int CreateUserId
        {
            get { return _createUserId; }
            set { _createUserId = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private DateTime _lastUpdateTime;
        public DateTime LastUpdateCreateTime
        {
            get { return _lastUpdateTime; }
            set { _lastUpdateTime = value; }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private WrongOrderStatus _status;
        public WrongOrderStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
