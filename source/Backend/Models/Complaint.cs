using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Complaint
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

        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        private string _clientName;
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private bool _isReply;
        public bool IsReply
        {
            get { return _isReply; }
            set { _isReply = value; }
        }
    }
}
