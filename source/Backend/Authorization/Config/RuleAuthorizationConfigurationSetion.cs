using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Authorization.Config
{
    public class RuleAuthorizationConfigurationSetion 
    {
        private string _AccessDeniedUrl;

        public string AccessDeniedUrl
        {
            get { return _AccessDeniedUrl; }
            set { _AccessDeniedUrl = value; }
        }
	

        private List<RuleAuthorizationModule> _Modules;

        public List<RuleAuthorizationModule> Modules
        {
            get { return _Modules; }
            set { _Modules = value; }
        }


        private string _SignInUrl;

        public string SignInUrl
        {
            get { return _SignInUrl; }
            set { _SignInUrl = value; }
        }

        private string _CookieName;

        public string CookieName
        {
            get { return _CookieName; }
            set { _CookieName = value; }
        }
    }
}
