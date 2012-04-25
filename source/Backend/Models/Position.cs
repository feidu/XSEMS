using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models.Admin;

namespace Backend.Models
{
    public class Position
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
        
        private List<ModuleAuthorization> _ModuleAuthorizations;

        public List<ModuleAuthorization> ModuleAuthorizations
        {
            get { return _ModuleAuthorizations; }
            set { _ModuleAuthorizations = value; }
        }
    }
}
