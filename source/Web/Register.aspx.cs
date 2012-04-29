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

public partial class Register : System.Web.UI.Page
{
    private const int CONST_USERNAEM_LENGTH = 20;
    private const int CONST_PASSWORD_LENGTH = 20;
    private const int CONST_EMAIL_LENGTH = 50;
    private const int CONST_REAL_NAME_LENGTH = 20;
    private const int CONST_IDCARD_LENGTH = 22;
    private const int CONST_PHONE_LENGTH = 20;
    private const int CONST_MOBILE_LENGTH = 20;
    private const int CONST_ADDRESS_LENGTH = 200;

    protected void Page_Load(object sender, EventArgs e)
    {
        seo.Title = "客户注册";
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string username = Request.Form[txtUsername.ID].Trim();
        string address = Request.Form[txtAddress.ID].Trim();
        string email = Request.Form[txtEmail.ID].Trim();
        string idCard = Request.Form[txtIdCard.ID].Trim();
        string mobile = Request.Form[txtMobile.ID].Trim();
        string password = Request.Form[txtPassword.ID];
        string phone = Request.Form[txtPhone.ID].Trim();
        string realName = Request.Form[txtRealName.ID].Trim();
        string rePassword = Request.Form[txtRePassword.ID];       

        bool isMessage = chkIsMessage.Checked;

        if (string.IsNullOrEmpty(username) || Validator.IsMatchLessThanChineseCharacter(username, CONST_USERNAEM_LENGTH))
        {
            lblMsg.Text = "用户名不能为空，且不能超过" + CONST_USERNAEM_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(password) || Validator.IsMatchLessThanChineseCharacter(password, CONST_PASSWORD_LENGTH))
        {
            lblMsg.Text = "密码不能为空，且不能超过" + CONST_PASSWORD_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(rePassword) || Validator.IsMatchLessThanChineseCharacter(rePassword, CONST_PASSWORD_LENGTH))
        {
            lblMsg.Text = "确认密码不能为空，且不能超过" + CONST_PASSWORD_LENGTH + "个字符！";
            return;
        }
        if (password != rePassword)
        {
            lblMsg.Text = "两次输入密码不一致！";
            return;
        }
        if (string.IsNullOrEmpty(realName) || Validator.IsMatchLessThanChineseCharacter(realName, CONST_REAL_NAME_LENGTH))
        {
            lblMsg.Text = "真实姓名不能为空，且不能超过" + CONST_REAL_NAME_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(idCard) || Validator.IsMatchLessThanChineseCharacter(idCard, CONST_IDCARD_LENGTH))
        {
            lblMsg.Text = "身份证号不能为空，且不能超过" + CONST_IDCARD_LENGTH + "个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(phone) && Validator.IsMatchLessThanChineseCharacter(phone, CONST_PHONE_LENGTH))
        {
            lblMsg.Text = "联系电话不能超过" + CONST_PHONE_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(mobile) || Validator.IsMatchLessThanChineseCharacter(mobile, CONST_MOBILE_LENGTH))
        {
            lblMsg.Text = "手机号码不能为空，且不能超过" + CONST_MOBILE_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(email) || Validator.IsMatchLessThanChineseCharacter(email, CONST_EMAIL_LENGTH))
        {
            lblMsg.Text = "电子邮件不能为空，且不能超过" + CONST_EMAIL_LENGTH + "个字符！";
            return;
        }   
        if (string.IsNullOrEmpty(address) || Validator.IsMatchLessThanChineseCharacter(address, CONST_ADDRESS_LENGTH))
        {
            lblMsg.Text = "地址不能为空，且不能超过" + CONST_ADDRESS_LENGTH + "个字符！";
            return;
        }
                
        Client client = new Client();   
        client.Username = username;
        client.Address = address;
        client.Email = email;
        client.IdCard = idCard;
        client.Mobile = mobile;
        client.Password = password;
        client.Phone = phone;
        client.RealName = realName;
        client.IsMessage = isMessage;
        client.Credit = 0;
        client.CreateDate = DateTime.Now;

        if (ClientOperation.CreateClient(client))
        {
            lblMsg.Text = "注册成功！将在3秒后自动跳转到个人信息页面……";
            ClientSession cs = new ClientSession();
            Client newClient=ClientOperation.GetClientByUsername(client.Username);
            cs.Id =newClient.Id;
            cs.Username = newClient.Username;
            cs.RealName = newClient.RealName;
            AuthorizationManager.Authorize(cs);

            Response.AddHeader("refresh", "3;url=/Client/Default.aspx");            
        }
        else
        {
            lblMsg.Text = "此用户名已经存在！";
        }
    }
}
