using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class ComplaintReply
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _complaintId;
        public int ComplaintId
        {
            get { return _complaintId; }
            set { _complaintId = value; }
        }

        private int _replierId;
        public int ReplierId
        {
            get { return _replierId; }
            set { _replierId = value; }
        }

        private string _replierName;
        public string ReplierName
        {
            get { return _replierName; }
            set { _replierName = value; }
        }

        private DateTime _replyTime;
        public DateTime ReplyTime
        {
            get { return _replyTime; }
            set { _replyTime = value; }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
