using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;
using Backend.Utilities;
using Backend.Authorization;

public partial class Client_CreateClientOrder : System.Web.UI.Page
{    
    private static readonly int NOTE_ADDRESS_LENGTH = 200;
    private static readonly int CONTACT_WAY_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;
    ClientSession clientSession;
    protected void Page_Load(object sender, EventArgs e)
    {
        seo.Title = "我要发货";
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);

        if (!IsPostBack)
        {
            //List<ClientAddress> result = ClientAddressOpreation.GetClientAddressByClientId(clientSession.Id);
            //ddlClientAddress.DataSource = result;
            //ddlClientAddress.DataTextField = "SenderName";
            //ddlClientAddress.DataValueField = "Id";
            //ddlClientAddress.DataBind();
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        //int clientAddressId = 0;
        //if (ddlClientAddress.SelectedItem==null || !int.TryParse(ddlClientAddress.SelectedItem.Value, out clientAddressId))
        //{
        //    lblMsg.Text = "请添加并选择发件人！";
        //    return;
        //}

        string countryName = Request.Form[txtCountry.ID].Trim();
        if (string.IsNullOrEmpty(countryName) || Validator.IsMatchLessThanChineseCharacter(countryName, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人国家不能为空，且不能超过" + CONTACT_WAY_LENGTH + "个字符！";
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
        if (string.IsNullOrEmpty(toAddress) || Validator.IsMatchLessThanChineseCharacter(toAddress, NOTE_ADDRESS_LENGTH))
        {
            lblMsg.Text = "收件人详址不能为空，且长度不能超过" + NOTE_ADDRESS_LENGTH + "个字符！";
            return;
        }
        string remark = Request.Form[txtRemark.ID].Trim();
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }

        ClientOrder co = new ClientOrder();
        co.Address = toAddress;
        co.ClientAddressId = 0;
        //co.ClientAddressId = int.Parse(ddlClientAddress.SelectedItem.Value);
        co.ClientId = clientSession.Id;
        co.CreateTime = DateTime.Now;
        co.Email = toEmail;
        co.Phone = toPhone;
        co.Postcode = toPostcode;
        co.RealName = toUsername;
        co.Remark = remark;
        co.Country = countryName;
        co.City = toCity;
        co.Encode = StringHelper.GetEncodeNumber("YD");
        ClientOrderOperation.CreateClientOrder(co);


        lblMsg.Text = "添加成功！";

        txtCountry.Value = "";
        txtRemark.Text = "";
        txtToAddress.Value = "";
        txtToCity.Value = "";
        txtToEmail.Value = "";
        txtToPhone.Value = "";
        txtToPostcode.Value = "";
        txtToUsername.Value = "";
        
    }

}
