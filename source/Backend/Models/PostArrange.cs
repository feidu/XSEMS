using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class PostArrange
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

        private int _carrierId;
        public int CarrierId
        {
            get { return _carrierId; }
            set { _carrierId = value; }
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

        private int _depotId;
        public int DepotId
        {
            get { return _depotId; }
            set { _depotId = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private DateTime _createTime;
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
    }
}
