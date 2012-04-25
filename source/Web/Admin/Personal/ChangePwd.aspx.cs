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

public partial class Admin_Personal_ChangePwd : System.Web.UI.Page
{
    private static readonly int CONST_PASSWORD_LENGTH = 20;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AdminCookie us = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        string currentPwd = Request.Form[txtCurrentPwd.ID];
        string newPwd = Request.Form[txtNewPwd.ID];
        string reNewPwd = Request.Form[txtReNewPwd.ID];

        if (string.IsNullOrEmpty(currentPwd) || Validator.IsMatchLessThanChineseCharacter(currentPwd, CONST_PASSWORD_LENGTH))
        {
            lblMsg.Text = "原密码不能为空，且不能超过" + CONST_PASSWORD_LENGTH + "个字符！";
            return;
        }
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

        if (us.Password != EncryptionHelper.EncryptString(currentPwd))
        {
            lblMsg.Text = "原密码不正确!";
            return;
        }

        UserOperation.UpdateUserPassword(us, newPwd);
        us.Password = reNewPwd;
        RuleAuthorizationManager.Authorize(HttpContext.Current, us);
        lblMsg.Text = "修改成功！";
    }
}
