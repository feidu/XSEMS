using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;
using Backend.Authorization;
using Backend.Utilities;

public partial class Client_CreateAddress : System.Web.UI.Page
{
    ClientSession clientSession ;
    protected void Page_Load(object sender, EventArgs e)
    {
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string address = Request.Form[txtAddress.ID].Trim();
        string email = Request.Form[txtEmail.ID].Trim();
        string senderName = Request.Form[txtSenderName.ID].Trim();
        string fax = Request.Form[textFax.ID].Trim();
        string phone = Request.Form[txtPhone.ID].Trim();
        string postcode = Request.Form[txtPostCode.ID].Trim();
        string province = Request.Form["slProvince"].Trim();
        string remark = Request.Form[txtRemark.ID].Trim();

        if (province == "0")
        {
            lblMsg.Text = "请选择所在地区！";
            return;
        }

        if (string.IsNullOrEmpty(senderName) || Validator.IsMatchLessThanChineseCharacter(senderName, 50))
        {
            lblMsg.Text = "发件人姓名不能为空，且不能超过" + 50 + "个字符！";
            return;
        }

        if (!string.IsNullOrEmpty(phone) && Validator.IsMatchLessThanChineseCharacter(phone, 20))
        {
            lblMsg.Text = "联系电话不能超过" + 20 + "个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(email) && Validator.IsMatchLessThanChineseCharacter(email, 40))
        {
            lblMsg.Text = "电子邮件不能超过" + 40 + "个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(fax) && Validator.IsMatchLessThanChineseCharacter(fax, 20))
        {
            lblMsg.Text = "传真不能超过" + 20 + "个字符！";
            return;
        }
        
        if (string.IsNullOrEmpty(address) || Validator.IsMatchLessThanChineseCharacter(address, 200))
        {
            lblMsg.Text = "地址不能为空，且不能超过" + 200 + "个字符！";
            return;
        }

        ClientAddress ca = new ClientAddress();
        ca.Address = address;
        ca.ClientId = clientSession.Id;
        ca.Email = email;
        ca.Fax = fax;
        ca.Phone = phone;
        ca.Postcode = postcode;
        ca.Province = province;
        ca.Remark = remark;
        ca.SenderName = senderName;

        ClientAddressOpreation.CreateClientAddress(ca);
        lblMsg.Text = "添加成功！";
    }
}