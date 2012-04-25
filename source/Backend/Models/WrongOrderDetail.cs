using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class WrongOrderDetail
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _wrongOrderId;
        public int WrongOrderId
        {
            get { return _wrongOrderId; }
            set { _wrongOrderId = value; }
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

    }
}
