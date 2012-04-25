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

public partial class Client_ComplaintView : System.Web.UI.Page
{
    Complaint comp = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        seo.Title = "我的投诉";
        int id = 0;
        if(int.TryParse(Request.QueryString["id"],out id))
        {
            comp = ComplaintOperation.GetComplaintById(id);
        }
        lblTitle.Text = comp.Title;
        lblCreateTime.Text = comp.CreateTime.ToString();
        lblContent.Text = comp.Content;

        divComplaintReplyDataBind();
    }
   
    private void divComplaintReplyDataBind()
    {
        ComplaintReply cr = ComplaintOperation.GetComplaintReplyByComplaintId(comp.Id);
        if (cr != null)
        {
            divReplyContent.Visible = true;
            lblReplyUser.Text = cr.ReplierName;
            lblReplyTime.Text = cr.ReplyTime.ToString();
            lblReplyContent.Text = cr.Content;
        }
        else
        {
            divReplyContent.Visible = false;
        }

    }
}
