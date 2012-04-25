using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class PostPlan
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
        private Carrier _carrier;
        public Carrier Carrier
        {
            get { return _carrier; }
            set { _carrier = value; }
        }

        private int _packageCount;
        public int PackageCount
        {
            get { return _packageCount; }
            set { _packageCount = value; }
        }

        private decimal _weight;
        public decimal Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private Depot _depot;
        public Depot Depot
        {
            get { return _depot; }
            set { _depot = value; }
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
    }
}
