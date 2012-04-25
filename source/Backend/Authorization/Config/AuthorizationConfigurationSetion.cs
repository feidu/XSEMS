using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Authorization.Config
{
    public class AuthorizationConfigurationSetion
    {
        private string _SignInUrl;

        public string SignInUrl
        {
            get { return _SignInUrl; }
            set { _SignInUrl = value; }
        }

        private string _SessionName;

        public string SessionName
        {
            get { return _SessionName; }
            set { _SessionName = value; }
        }
    }
}
