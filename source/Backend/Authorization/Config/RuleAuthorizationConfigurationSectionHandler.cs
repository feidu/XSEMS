using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace Backend.Authorization.Config
{
    public class RuleAuthorizationConfigurationSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            RuleAuthorizationConfigurationSetion acs = new RuleAuthorizationConfigurationSetion();
            acs.CookieName = section.Attributes["cookieName"].Value;
            acs.SignInUrl = section.Attributes["signInUrl"].Value;
            acs.AccessDeniedUrl = section.Attributes["accessDeniedUrl"].Value;
            acs.Modules = new List<RuleAuthorizationModule>();
            
            // read modules
            foreach (XmlNode xnModule in section.ChildNodes)
            {
                if (xnModule.Name != "module")
                {
                    continue;
                }
                RuleAuthorizationModule ram = new RuleAuthorizationModule();
                ram.Id = int.Parse(xnModule.Attributes["id"].Value);
                ram.Name = xnModule.Attributes["name"].Value;
                ram.Pages = new List<string>();
                // read pages
                foreach (XmlNode xnPage in xnModule.ChildNodes)
                {
                    ram.Pages.Add(xnPage.InnerText.ToLower());
                }
                acs.Modules.Add(ram);
            }
            return acs;
        }
    }
}
