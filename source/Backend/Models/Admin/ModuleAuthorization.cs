using System;
using System.Collections.Generic;
using System.Text;
using Backend.Authorization;

namespace Backend.Models.Admin
{
    public class ModuleAuthorization : IRuleModule
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private bool _Accessible;

        public bool Accessible
        {
            get { return _Accessible; }
            set { _Accessible = value; }
        }

        private bool _Writable;

        public bool Writable
        {
            get { return _Writable; }
            set { _Writable = value; }
        }

        private int _ModuleId;

        public int ModuleId
        {
            get { return _ModuleId; }
            set { _ModuleId = value; }
        }
    }
}
