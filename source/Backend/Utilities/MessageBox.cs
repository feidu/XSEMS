using System;
using System.Collections.Generic;
using System.Web;

namespace Backend.Utilities
{
    public class MessageBox
    {
        public static void ShowAlert(string message)
        {
            if (message == null)
                message = "";
            //ljj 
            //2005-12-9
            //message=message.Replace("  ","@");
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + message + "');</script>");
        }
        public static void ShowAlert(string message, string url)
        {
            if (message == null)
                message = "";
            //message = message.Replace("  ", "@");
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + message + "');location='" + url + "';</script>");
        }
        public static void ShowConfirmAlert(string message, string confirmurl, string cancelurl)
        {
            if (message == null)
                message = "";
            //message = message.Replace("  ", "@");
            System.Web.HttpContext.Current.Response.Write("<script Language=Javascript>if( confirm('" + message + "') ) {document.location.href='" + confirmurl + "'; } else { document.location.href='" + cancelurl + "' }</script>");
        }
        public static void ShowConfirmAlert(string message, string confirmurl)
        {
            if (message == null)
                message = "";
            //message = message.Replace("  ", "@");
            System.Web.HttpContext.Current.Response.Write("<script Language=Javascript>if( confirm('" + message + "') ) {document.location.href='" + confirmurl + "'; } else { window.history.back(); }</script>");
        }
        public static void Redirect(string url)
        {// 
            //
            if (url == null || url.Length < 1)
                ShowAlert("重定向地址不能为空");
            else
                System.Web.HttpContext.Current.Response.Write("<script>location='" + url + "';</script>");
        }
        public static void SSOLoginRedirect(string url)
        {
            Redirect(url);
            //   if(url==null||url.Length<1)
            //    ShowAlert("重定向地址不能为空");
            //   else
            //    System.Web.HttpContext.Current.Response.Write("<script>if(window.parent!=window) window.parent.location=window.location; location='"+url+"';</script>");

        }
        public static void ShowAlert(string message, string url, bool IsRedirect)
        {

            if (message == null)
                message = "";
            if (IsRedirect)
                ShowAlert(message, url);
            else
                ShowAlert(message);
        }
    }

}