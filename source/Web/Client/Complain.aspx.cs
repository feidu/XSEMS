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
using Backend.Authorization;

public partial class Client_Complain : System.Web.UI.Page
{
    ClientSession clientSession = null;
    private static readonly int TITLE_LENGTH = 50;
    protected void Page_Load(object sender, EventArgs e)
    {
        seo.Title = "我要投诉";

        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string title = Request.Form[txtTitle.ID].Trim();
        if (string.IsNullOrEmpty(title) || Validator.IsMatchLessThanChineseCharacter(title, TITLE_LENGTH))
        {
            lblMsg.Text = "标题不能为空， 且长度不能超过"+ TITLE_LENGTH +"个字符！";
            return;
        }
        string content = Request.Form[txtContent.ID].Trim();
        if(string.IsNullOrEmpty(content))
        {
            lblMsg.Text = "投诉内容不能为空！";
            return;
        }

        Complaint comp = new Complaint();
        comp.Title = title;
        comp.ClientId = clientSession.Id;
        comp.ClientName = clientSession.RealName;
        comp.Content = content;
        comp.CreateTime = DateTime.Now;
        Client client = ClientOperation.GetClientById(clientSession.Id);
        comp.CompanyId = client.CompanyId;

        ComplaintOperation.CreateComplaint(comp);
        lblMsg.Text = "提交成功！";
    }
}
