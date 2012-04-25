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
using Backend.BAL;
using Backend.Authorization;
using Backend.Utilities;

public partial class Admin_PostSetting_ChangePwd : System.Web.UI.Page
{
    protected User user = null;
    private static readonly int CONST_PASSWORD_LENGTH = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            user = UserOperation.GetUserById(id);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);

        string newPwd = Request.Form[txtNewPwd.ID];
        string reNewPwd = Request.Form[txtReNewPwd.ID];

        if (string.IsNullOrEmpty(newPwd) || Validator.IsMatchLessThanChineseCharacter(newPwd, CONST_PASSWORD_LENGTH))
        {
            lblMsg.Text = "新密码不能为空，且不能超过" + CONST_PASSWORD_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(reNewPwd) || Validator.IsMatchLessThanChineseCharacter(reNewPwd, CONST_PASSWORD_LENGTH))
        {
            lblMsg.Text = "确认新密码不能为空，且不能超过" + CONST_PASSWORD_LENGTH + "个字符！";
            return;
        }
        if (newPwd != reNewPwd)
        {
            lblMsg.Text = "两次输入密码不一致！";
            return;
        }

        UserOperation.UpdateUserPassword(user, newPwd);

        if (cookie.Id == user.Id)
        {
            cookie.Password = newPwd;
            RuleAuthorizationManager.Authorize(HttpContext.Current, cookie);
        }
        lblMsg.Text = "修改成功！";
    }
}
