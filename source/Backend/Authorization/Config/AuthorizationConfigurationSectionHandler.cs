using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Backend.Authorization.Config
{
    public class AuthorizationConfigurationSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            AuthorizationConfigurationSetion acs = new AuthorizationConfigurationSetion();
            acs.SessionName = section.Attributes["sessionName"].Value;
            acs.SignInUrl = section.Attributes["signInUrl"].Value;
            return acs;
        }
    }
}
