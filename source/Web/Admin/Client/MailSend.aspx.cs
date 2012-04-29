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
using Backend.Utilities;
using System.Collections.Generic;
using Backend.Authorization;

public partial class Admin_Client_MailSend : System.Web.UI.Page
{
    private static readonly int CONST_TITLE_LENGTH = 100;
    private static readonly int CONST_CONTENT_LENGTH = 2000;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string title = Request.Form[txtTitle.ID].Trim();
        string content = Request.Form[txtContent.ID].Trim();

        if (string.IsNullOrEmpty(title) || Validator.IsMatchLessThanChineseCharacter(title, CONST_TITLE_LENGTH))
        {
            lblMsg.Text = "邮件标题不能为空，并且长度不能超过 " + CONST_TITLE_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(content) || Validator.IsMatchLessThanChineseCharacter(content, CONST_CONTENT_LENGTH))
        {
            lblMsg.Text = "邮件内容不能为空，并且长度不能超过 " + CONST_CONTENT_LENGTH + " 个字符！";
            return;
        }

        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);

        Company company = CompanyOperation.GetCompanyById(user.CompanyId);
        
        List<Client> result = ClientOperation.GetClientList();
        

        List<Client> sendFailed = EmailHelper.SendMailForAnnounce(company, result, title, content);
        if (sendFailed.Count > 0)
        {
            lblMsg.Text = "已发送，其中";
            foreach (Client client in sendFailed)
            {
                lblMsg.Text += client.RealName + "，";
            }
            lblMsg.Text += "邮件发送失败！";
        }
        else
        {
            lblMsg.Text = "全部发送成功！";
        }

    }
}
