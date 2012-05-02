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

public partial class Client_CreateConsign : System.Web.UI.Page
{
    protected int id = 0;
    private static readonly int NOTE_ADDRESS_LENGTH = 200;
    private static readonly int CONTACT_WAY_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;
    Client client = null;
    Company company = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        seo.Title = "我要发货";
        ClientSession clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        if (clientSession != null)
        {
            client = ClientOperation.GetClientById(clientSession.Id);
            company = CompanyOperation.GetCompanyById(client.CompanyId);
        }

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string countryName = Request.Form[hdCountry.ID].Trim();
        if (string.IsNullOrEmpty(countryName))
        {
            lblMsg.Text = "收件人国家不能为空！";
            return;
        }
        if (CountryOperation.GetCountryByEnglishName(countryName) == null)
        {
            lblMsg.Text = "国家名称不存在！";
            return;
        }        
        string toUsername = Request.Form[txtToUsername.ID].Trim();
        if (string.IsNullOrEmpty(toUsername) || Validator.IsMatchLessThanChineseCharacter(toUsername, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人姓名不能为空，且不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toPhone = Request.Form[txtToPhone.ID].Trim();
        if (!string.IsNullOrEmpty(toPhone) && Validator.IsMatchLessThanChineseCharacter(toPhone, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人电话不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toEmail = Request.Form[txtToEmail.ID].Trim();
        if (!string.IsNullOrEmpty(toEmail) && Validator.IsMatchLessThanChineseCharacter(toEmail, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人邮箱不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toCity = Request.Form[txtToCity.ID].Trim();
        if (!string.IsNullOrEmpty(toCity) && Validator.IsMatchLessThanChineseCharacter(toCity, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人城市不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }

        string toPostcode = Request.Form[txtToPostcode.ID].Trim();
        if (!string.IsNullOrEmpty(toPostcode) && Validator.IsMatchLessThanChineseCharacter(toPostcode, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人邮编不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toAddress = Request.Form[txtToAddress.ID].Trim();
        if (!string.IsNullOrEmpty(toAddress) && Validator.IsMatchLessThanChineseCharacter(toAddress, NOTE_ADDRESS_LENGTH))
        {
            lblMsg.Text = "收件人详址不能超过" + NOTE_ADDRESS_LENGTH + "个字符！";
            return;
        }
        string remark = Request.Form[txtRemark.ID].Trim();
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }

        string encode = StringHelper.GetEncodeNumber("SJ");
        Order order = new Order();
        order.Client = client;
        order.CompanyId = client.CompanyId;
        order.CompanyName = company.Name;
        order.Encode = encode;
        order.Status = OrderStatus.WAIT_AUDIT;
        order.Type = OrderType.CLIENT_ORDER;
        order.CreateTime = DateTime.Now;
        order.Costs = 0;
        order.Remark = remark;

        order.ToAddress = toAddress;
        order.ToCity = toCity;
        order.ToCountry = countryName;
        order.ToEmail = toEmail;
        order.ToPhone = toPhone;
        order.ToPostcode = toPostcode;
        order.ToUsername = toUsername;

        OrderOperation.CreateClientOrder(order);
        order = OrderOperation.GetOrderByEncode(encode);
        Response.Write("<script language='javascript'>alert('添加成功！');location.href='Consign.aspx?id=" + order.Id + "';</script>");
    }

}
