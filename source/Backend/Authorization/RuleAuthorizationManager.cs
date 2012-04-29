using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Configuration;
using Backend.Authorization.Config;
using Backend.Models;
using Backend.BAL;

namespace Backend.Authorization
{
    public class RuleAuthorizationManager
    {
        private static readonly RuleAuthorizationConfigurationSetion acs
            = (RuleAuthorizationConfigurationSetion)ConfigurationManager.GetSection("web.ruleAuthorization");

        private const string RETURN_URL = "ReturnUrl";

        private static readonly string SIGN_IN_PAGE_URL = acs.SignInUrl + "?" + RETURN_URL + "=";

        private static readonly string ACCESS_DENIED_URL = acs.AccessDeniedUrl;

        private static readonly int COOKIE_DEFAULE_EXPIRED = 0;

        public static RuleAuthorizationConfigurationSetion GetRuleAuthorizationConfigurationSetion()
        {
            return acs;
        }

        public static void Authorize(HttpContext ctx, IRuleSessionable obj)
        {
            AdminCookie cookie = (AdminCookie)obj;
            CookieHelper.AddAdmin(cookie.Id, cookie.Username, cookie.Password, COOKIE_DEFAULE_EXPIRED);
        }

        public static void UnAuthorize(HttpContext ctx)
        {
            CookieHelper.ClearAdmin();
        }

        public static RuleAuthorizationStatus IsAuthorized(HttpContext ctx, bool isPostback)
        {
            AdminCookie cookie = GetAdminCookie();
            if (cookie == null) return RuleAuthorizationStatus.NOT_SIGN_IN;

            string url = ctx.Request.Path.ToLower().Replace("/web", ""); ;
            //find out matched config url.
            foreach (RuleAuthorizationModule ram in acs.Modules)
            {
                foreach (string u in ram.Pages)
                {
                    if (url == u)
                    {
                        IRuleModule rm = null; // session module configuration
                        if (cookie.RuleModules.TryGetValue(ram.Id, out rm)) // current request url is configured in modules
                        {
                            if (isPostback) // check readonly
                            {
                                return rm.Writable == false ? RuleAuthorizationStatus.ACCESS_DENIED : RuleAuthorizationStatus.SUCCESS;
                            }
                            else
                            {
                                return rm.Accessible == true ? RuleAuthorizationStatus.SUCCESS : RuleAuthorizationStatus.ACCESS_DENIED;
                            }
                        }
                        else // current user session doesn't contains module rules
                        {
                            //TODO will be replaced to RuleAuthorizationStatus.ACCESS_DENIED;
                            return RuleAuthorizationStatus.ACCESS_DENIED;
                        }
                    }
                }
            }
            return RuleAuthorizationStatus.NOT_SIGN_IN;
        }

        private static AdminCookie GetAdminCookie()
        {
            AdminCookie cookie = CookieHelper.GetAdmin();
            if (cookie == null) return null;
            User admin = UserOperation.GetUserById(cookie.Id);
            if (admin != null)
            {
                if (cookie.Username == admin.Username && cookie.Password == admin.Password)
                {
                    AdminCookie.BindRuleModules(cookie, admin.ModuleAuthorizations);
                    cookie.ModuleAuthorizations = admin.ModuleAuthorizations;
                    return cookie;
                }
            }
            return null;
        }

        public static IRuleSessionable GetCurrentSessionObject(HttpContext ctx, bool isPostback)
        {
            RuleAuthorizationStatus status = IsAuthorized(ctx, isPostback);
            switch (status)
            {
                case RuleAuthorizationStatus.NOT_SIGN_IN:
                    RedirectToSignInPage(ctx);
                    return null;
                case RuleAuthorizationStatus.ACCESS_DENIED:
                    RedirectToAccessDeniedPage(ctx);
                    return null;
                case RuleAuthorizationStatus.SUCCESS:
                    AdminCookie cookie = GetAdminCookie();
                    return cookie;
            }
            return null;
        }

        public static void RedirectToAccessDeniedPage(HttpContext ctx)
        {
            ctx.Response.Redirect(ACCESS_DENIED_URL);
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
