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

public partial class Admin_Order_Quote : System.Web.UI.Page
{
    protected int id = 0;
    Quote quote = null;
    User user = null;
    protected string companyId = "0";
    protected List<QuoteDetail> result = null;
    protected int quoteDetailCount = 0;
    private static readonly int CLIENT_NAME_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            quote = QuoteOperation.GetQuoteById(id);
            companyId = quote.CompanyId.ToString();
            result = QuoteOperation.GetQuoteDetailByQuoteId(id);
            quoteDetailCount = result.Count;
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);        
    }

    private void FormDataBind()
    {
        txtRemark.Text = quote.Remark;
        lblEncode.Text = quote.Encode;
        lblCompanyName.Text = quote.CompanyName;
        txtClientName.Value = quote.Client.RealName;
        txtQuoteTime.Value = quote.QuoteTime.ToShortDateString();
        lblCreateUser.Text = quote.User.RealName;
        lblCreateTime.Text = quote.CreateTime.ToString();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        QuoteOperation.DeleteQuoteById(id);
        Response.Write("<script language='javascript' type='text/javascript'>alert('删除成功！');location.href='QuoteList.aspx';</script>");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DateTime quoteTime = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(Request.Form[txtQuoteTime.ID].Trim()) || !DateTime.TryParse(Request.Form[txtQuoteTime.ID].Trim(), out quoteTime))
        {
            lblMsg.Text = "报价日期不能为空，且只能为时间格式！";
            return;
        }

        string clientName = Request.Form[txtClientName.ID].Trim();
        if (string.IsNullOrEmpty(clientName) || clientName == "请输入客户姓名拼音的首字母" || Validator.IsMatchLessThanChineseCharacter(clientName, CLIENT_NAME_LENGTH))
        {
            lblMsg.Text = "客户姓名不能为空，且长度不能超过" + CLIENT_NAME_LENGTH + "个字符！";
            return;
        }
        Client client = ClientOperation.GetClientByRealName(clientName);
        if (client == null)
        {
            lblMsg.Text = "客户不存在！";
            return;
        }
        string remark = Request.Form[txtRemark.ID].Trim();
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }
        quote.Client = client;
        quote.Remark = remark;
        quote.QuoteTime = quoteTime;
        
        QuoteOperation.UpdateQuote(quote);
        lblMsg.Text = "修改成功！";
        FormDataBind();
    }
  
    protected void btnDeleteDetail_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            FormDataBind();
            return;
        }
        QuoteOperation.DeleteQuoteDetailByIds(ids);

        Response.Write("<script language='javascript'>location.href='Quote.aspx?id=" + id + "';</script>");
    }
   
}
