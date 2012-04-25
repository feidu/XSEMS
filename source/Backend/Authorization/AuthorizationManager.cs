using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Configuration;
using Backend.Authorization.Config;

namespace Backend.Authorization
{
    public class AuthorizationManager
    {
        private static readonly AuthorizationConfigurationSetion acs
            = (AuthorizationConfigurationSetion)ConfigurationManager.GetSection("web.authorization");

        private const string RETURN_URL = "ReturnUrl";

        private static readonly string SIGN_IN_PAGE_URL = acs.SignInUrl + "?" + RETURN_URL + "=";

        public static void Authorize( ISessionable obj)
        {
            HttpContext.Current.Session[acs.SessionName] = obj;
        }

        public static void UnAuthorize()
        {
            HttpContext.Current.Session[acs.SessionName] = null;
        }

        public static bool IsAuthorized(HttpContext ctx)
        {
            if (ctx.Session == null) return false;
            if (ctx.Session[acs.SessionName] == null) return false;
            if (ctx.Session[acs.SessionName] is ISessionable) return true;
            return false;
        }

        public static ISessionable GetCurrentSessionObject(HttpContext ctx,bool isRedirect)
        {
            if (IsAuthorized(ctx))
            {
                return (ISessionable)ctx.Session[acs.SessionName];
            }
            else
            {
                if(isRedirect)
                    RedirectToSignInPage(ctx);
                return null;
            }
        }


        public static void RedirectToSignInPage(HttpContext ctx)
        {
            ctx.Response.Redirect(SIGN_IN_PAGE_URL + HttpUtility.UrlEncode(ctx.Request.RawUrl));
        }


        public static string GetPreviousUrl(HttpContext ctx)
        {
            return HttpUtility.UrlDecode(ctx.Request.QueryString[RETURN_URL]);
        }
         
    }
}
