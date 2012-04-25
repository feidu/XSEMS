using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Quote
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _encode;
        public string Encode
        {
            get { return _encode; }
            set { _encode = value; }
        }

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; }
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

        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime _quoteTime;
        public DateTime QuoteTime
        {
            get { return _quoteTime; }
            set { _quoteTime = value; }
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private int _auditUserId;
        public int AuditUserId
        {
            get { return _auditUserId; }
            set { _auditUserId = value; }
        }

        private DateTime _auditTime;
        public DateTime AuditTime
        {
            get { return _auditTime; }
            set { _auditTime = value; }
        }

        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
