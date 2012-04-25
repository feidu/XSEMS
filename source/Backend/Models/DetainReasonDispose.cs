using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class DetainReasonDispose
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _detainReasonId;
        public int DetainReasonId
        {
            get { return _detainReasonId; }
            set { _detainReasonId = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
}
