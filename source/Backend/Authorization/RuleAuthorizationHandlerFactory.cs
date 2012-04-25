using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace Backend.Authorization
{
    public class RuleAuthorizationHandlerFactory : PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            Page handler = (Page)base.GetHandler(context, requestType, virtualPath, path);
            handler.PreInit += new EventHandler(OnHandlerPreInit);
            return handler;
        }

        private void OnHandlerPreInit(object sender, EventArgs e)
        {
            Page handler = (Page)sender;
            HttpContext ctx = HttpContext.Current;
            RuleAuthorizationStatus status = RuleAuthorizationManager.IsAuthorized(ctx, handler.IsPostBack);
            switch (status)
            {
                case RuleAuthorizationStatus.NOT_SIGN_IN:
                    RuleAuthorizationManager.RedirectToSignInPage(ctx);
                    break;
                case RuleAuthorizationStatus.ACCESS_DENIED:
                    RuleAuthorizationManager.RedirectToAccessDeniedPage(ctx);
                    break;
            }
        }
    }
}
