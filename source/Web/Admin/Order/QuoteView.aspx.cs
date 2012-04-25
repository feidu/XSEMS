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

public partial class Admin_Order_QuoteView : System.Web.UI.Page
{
    protected int id = 0;
    Quote quote = null;
    protected List<QuoteDetail> result = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            quote = QuoteOperation.GetQuoteById(id);
            result = QuoteOperation.GetQuoteDetailByQuoteId(id);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }

    private void FormDataBind()
    {
        txtRemark.Text = quote.Remark;
        lblEncode.Text = quote.Encode;
        lblCompanyName.Text = quote.CompanyName;
        lblClientName.Text = quote.Client.RealName;
        lblQuoteTime.Text = quote.QuoteTime.ToShortDateString();
        lblCreateUser.Text = quote.User.RealName;
        lblCreateTime.Text = quote.CreateTime.ToString();
        lblAuditUser.Text = UserOperation.GetUserById(quote.AuditUserId).RealName;
        lblAuditTime.Text = quote.AuditTime.ToShortDateString();
    }
}

