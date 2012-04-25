using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class ShouldPay
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _orderEncode;
        public string OrderEncode
        {
            get { return _orderEncode; }
            set { _orderEncode = value; }
        }
        
        private OrderDetail _orderDetail;
        public OrderDetail OrderDetail
        {
            get { return _orderDetail; }
            set { _orderDetail = value; }
        }

        private Carrier _carrier;
        public Carrier Carrier
        {
            get { return _carrier; }
            set { _carrier = value; } 
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _companyId;
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }

        private string _encode;
        public string Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
    }
}
