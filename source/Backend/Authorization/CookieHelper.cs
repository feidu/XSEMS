using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Backend.Models;

namespace Backend.Authorization
{
    public class CookieHelper
    {
        public const string COOKIE_ADMIN_ID = "WL.Admin.Id";
        public const string COOKIE_ADMIN_PSW = "WL.Admin.Password";
        public const string COOKIE_ADMIN_NAME = "WL.Admin.Name";

        public static void AddAdmin(int adminId, string adminName, string password, int saveDays)
        {
            HttpCookie cookieId = new HttpCookie(COOKIE_ADMIN_ID, adminId.ToString());
            HttpCookie cookiePsw = new HttpCookie(COOKIE_ADMIN_PSW, HttpUtility.UrlEncode(Backend.Utilities.EncryptionHelper.EncryptString(password)));
            HttpCookie cookieUn = new HttpCookie(COOKIE_ADMIN_NAME, HttpUtility.UrlEncode(adminName));
            if (saveDays > 0)
            {
                DateTime expiredDate = DateTime.Now.AddDays(saveDays);
                cookieId.Expires = expiredDate;
                cookiePsw.Expires = expiredDate;
                cookieUn.Expires = expiredDate;
            }
            HttpContext.Current.Response.Cookies.Add(cookieId);
            HttpContext.Current.Response.Cookies.Add(cookiePsw);
            HttpContext.Current.Response.Cookies.Add(cookieUn);
        }

        public static AdminCookie GetAdmin()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[COOKIE_ADMIN_PSW];
            string psw = cookie == null ? string.Empty : HttpUtility.UrlDecode(cookie.Value);
            cookie = HttpContext.Current.Request.Cookies[COOKIE_ADMIN_NAME];
            string username = cookie == null ? string.Empty : HttpUtility.UrlDecode(cookie.Value);
            cookie = HttpContext.Current.Request.Cookies[COOKIE_ADMIN_ID];
            string sId =  cookie == null ? string.Empty : cookie.Value;
            int id = 0;
            AdminCookie ac = null;
            if (sId != null && int.TryParse(sId, out id))
            {
                ac = new AdminCookie();
                ac.Id = id;
                ac.Username = username;
                ac.Password = psw;
            }
            return ac;
        }

        public static string GetAdminPsw()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[COOKIE_ADMIN_PSW];
            return cookie == null ? string.Empty : HttpUtility.UrlDecode(cookie.Value);
        }

        public static string GetAdminName()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[COOKIE_ADMIN_NAME];
            return cookie == null ? string.Empty : HttpUtility.UrlDecode(cookie.Value);
        }

        public static string GetAdminId()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[COOKIE_ADMIN_ID];
            return cookie == null ? string.Empty : cookie.Value;
        }

        public static void ClearAdmin()
        {
            HttpCookie cookieId = new HttpCookie(COOKIE_ADMIN_ID, string.Empty);
            HttpCookie cookiePsw = new HttpCookie(COOKIE_ADMIN_PSW, string.Empty);
            HttpCookie cookieUn = new HttpCookie(COOKIE_ADMIN_NAME, string.Empty);
            cookieId.Expires = new DateTime(1999, 1, 1);
            cookiePsw.Expires = new DateTime(1999, 1, 1);
            cookieUn.Expires = new DateTime(1999, 1, 1);
            HttpContext.Current.Response.Cookies.Add(cookieId);
            HttpContext.Current.Response.Cookies.Add(cookiePsw);
            HttpContext.Current.Response.Cookies.Add(cookieUn);
        }

    }
}