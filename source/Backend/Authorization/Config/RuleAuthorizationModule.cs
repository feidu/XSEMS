using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Authorization.Config
{
    public class RuleAuthorizationModule
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
	

        private List<string> _Pages;

        public List<string> Pages
        {
            get { return _Pages; }
            set { _Pages = value; }
        }
	
    }
}
