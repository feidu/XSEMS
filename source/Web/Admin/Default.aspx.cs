using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Backend.Models;
using Backend.Authorization;
using Backend.Models.Admin;
using Backend.BAL;
using Backend.Utilities;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //if (!VerifyCodeHelper.IsValid(Context, vc.ID))
        //{
        //    Response.Write("<script>alert('验证码不正确！');</script>");
        //    return;
        //}
        AdminCookie cookie = new AdminCookie();
        cookie.Username = Request.Form[tbUsername.ID];
        cookie.Password = Request.Form[tbPassword.ID];

        OperatorStaus status = UserOperation.UserLogin(cookie);
        switch (status)
        {
            case OperatorStaus.SUCCESS:
                string url = RuleAuthorizationManager.GetPreviousUrl(Context);
                RuleAuthorizationManager.Authorize(Context, cookie);
                if (StringHelper.IsEmpty(url))
                {
                    Response.Redirect("/Admin/Main");
                }
                else
                {
                    Response.Redirect(url);
                }
                break;
            case OperatorStaus.OPERATOR_USERNAME_INCORROECT:
                Response.Write("<script>alert('用户名错误！');</script>");
                break;
            case OperatorStaus.OPERATOR_PASSWORD_INCORROECT:
                Response.Write("<script>alert('密码错误！');</script>");
                break;
        }

    }
}
