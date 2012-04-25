using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class CostType
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private bool _isManageCosts;
        public bool IsManageCosts
        {
            get { return _isManageCosts; }
            set { _isManageCosts = value; }
        }

        private bool _isSalorCosts;
        public bool IsSalorCosts
        {
            get { return _isSalorCosts; }
            set { _isSalorCosts = value; }
        }

    }
}
