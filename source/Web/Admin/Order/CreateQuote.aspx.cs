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

public partial class Admin_Order_CreateQuote : System.Web.UI.Page
{
    protected string companyId = "0";
    User user = null;
    private static readonly int CLIENT_NAME_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        companyId = user.CompanyId.ToString();
        txtQuoteTime.Value = DateTime.Now.ToShortDateString();
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string clientName = Request.Form[txtClientName.ID].Trim();
        string remark = Request.Form[txtRemark.ID].Trim();

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
        DateTime quoteTime = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(Request.Form[txtQuoteTime.ID].Trim()) || !DateTime.TryParse(Request.Form[txtQuoteTime.ID].Trim(), out quoteTime))
        {
            lblMsg.Text = "报价日期不能为空，且只能为时间格式！";
            return;
        }
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }

        string encode = StringHelper.GetEncodeNumber("BJ");
        Quote quote = new Quote();
        quote.Encode = encode;
        quote.QuoteTime = quoteTime;
        quote.Client = client;
        quote.CreateTime = DateTime.Now;
        quote.User = user;
        quote.CompanyId = user.CompanyId;
        quote.CompanyName = CompanyOperation.GetCompanyById(user.CompanyId).Name;
        quote.Remark = remark;

        QuoteOperation.CreateQuote(quote);
        quote = QuoteOperation.GetQuoteByEncode(encode);
        Response.Write("<script language='javascript'>alert('添加成功！');location.href='Quote.aspx?id=" + quote.Id + "';</script>");
    }
}
