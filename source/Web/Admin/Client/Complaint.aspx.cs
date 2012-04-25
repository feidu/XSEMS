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

public partial class Admin_Client_Complaint : System.Web.UI.Page
{
    Complaint comp = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            comp = ComplaintOperation.GetComplaintById(id);
        }
        lblClientName.Text = comp.ClientName;
        lblTitle.Text = comp.Title;
        lblContent.Text = comp.Content;
        lblCreateTime.Text = comp.CreateTime.ToString();

        divComplaintReplyDataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        string content = Request.Form[txtContent.ID].Trim();
        if (string.IsNullOrEmpty(content))
        {
            lblMsg.Text = "回复内容不能为空！";
            return;
        }
        ComplaintReply compReply = new ComplaintReply();
        compReply.ComplaintId = comp.Id;
        compReply.ReplierId = user.Id;
        compReply.ReplierName = user.RealName;
        compReply.Content = content;
        compReply.ReplyTime = DateTime.Now;

        ComplaintOperation.CreateComplaintReply(compReply);
        comp.IsReply = true;
        ComplaintOperation.UpdateComplaintIsReply(comp);
        
        divComplaintReplyDataBind();
        lblMsg.Text = "";
    }

    private void divComplaintReplyDataBind()
    {
        ComplaintReply cr = ComplaintOperation.GetComplaintReplyByComplaintId(comp.Id);
        if (cr != null)
        {
            divReplyContent.Visible = true;
            divReply.Visible = false;
            lblReplyUser.Text = cr.ReplierName;
            lblReplyTime.Text = cr.ReplyTime.ToString();
            lblReplyContent.Text = cr.Content;
        }
        else
        {
            divReply.Visible = true;
            divReplyContent.Visible = false;
        }
    }
}
