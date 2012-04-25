using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class DetainReason
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

        private string _orderEncode;
        public string OrderEncode
        {
            get { return _orderEncode; }
            set { _orderEncode = value; }
        }
        
        private string reason;
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
    }
}
