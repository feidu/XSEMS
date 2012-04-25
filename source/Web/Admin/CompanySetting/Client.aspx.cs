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
using Backend.Utilities;

public partial class Admin_CompanySetting_Client : System.Web.UI.Page
{
    private static readonly int CONST_EMAIL_LENGTH = 50;
    private static readonly int CONST_REAL_NAME_LENGTH = 20;
    private static readonly int CONST_IDCARD_LENGTH = 22;
    private static readonly int CONST_PHONE_LENGTH = 20;
    private static readonly int CONST_MOBILE_LENGTH = 20;
    private static readonly int CONST_ADDRESS_LENGTH = 200;
    Client client = null;
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);

        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            client = ClientOperation.GetClientById(id);
        }
        else
        {
            lblMsg.Text = "参数错误！";
            return;
        }

        if (!IsPostBack)
        {
            FormDataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string address = Request.Form[txtAddress.ID].Trim();
        string email = Request.Form[txtEmail.ID].Trim();
        string idCard = Request.Form[txtIdCard.ID].Trim();
        string mobile = Request.Form[txtMobile.ID].Trim();
        string phone = Request.Form[txtPhone.ID].Trim();
        string realName = Request.Form[txtRealName.ID].Trim();
        string province = Request.Form["slProvince"].Trim();
        string city = Request.Form["slCity"];

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

        if (province == "0" || city == "0")
        {
            lblMsg.Text = "请选择所在地区！";
            return;
        }
        if (!string.IsNullOrEmpty(address) && Validator.IsMatchLessThanChineseCharacter(address, CONST_ADDRESS_LENGTH))
        {
            lblMsg.Text = "地址不能超过" + CONST_ADDRESS_LENGTH + "个字符！";
            return;
        }
       
        decimal credit = 0;
        if (!decimal.TryParse(Request.Form[txtCredit.ID], out credit))
        {
            lblMsg.Text = "信用额度只能为数字！";
            return;
        }

        client.Address = address;
        client.Email = email;
        client.IdCard = idCard;
        client.Mobile = mobile;
        client.Phone = phone;
        client.RealName = realName;
        client.IsFetchGoods = chkIsFetchGoods.Checked;
        client.IsMessage = chkIsMessage.Checked;
        client.Province = province;
        client.City = city;
        client.Credit = credit;
        if (ddlCompanyUsers.Items.Count > 0)
        {
            client.UserId = int.Parse(ddlCompanyUsers.SelectedItem.Value);
        }
        else
        {
            client.UserId = 0;
        }
        ClientOperation.UpdateClientInfo(client);
        lblMsg.Text = "修改成功！";
        FormDataBind();
    }
    private void FormDataBind()
    {
        ddlCompanyUsers.DataSource = UserOperation.GetLightUserByCompanyId(user.CompanyId);
        ddlCompanyUsers.DataTextField = "RealName";
        ddlCompanyUsers.DataValueField = "Id";
        ddlCompanyUsers.DataBind();

        txtAddress.Text = client.Address;
        txtEmail.Text = client.Email;
        txtIdCard.Text = client.IdCard;
        txtMobile.Text = client.Mobile;
        txtPhone.Text = client.Phone;
        txtRealName.Text = client.RealName;
        chkIsMessage.Checked = client.IsMessage;
        chkIsFetchGoods.Checked = client.IsFetchGoods;
        slProvince.Value = client.Province;
        slCity.Items.Clear();
        slCity.Items.Add(new ListItem(client.City, client.City));
        txtCredit.Text = StringHelper.CurtNumber(client.Credit.ToString());
        lblBalance.Text = client.Balance.ToString() + " 元";

        if (client.UserId!=0)
        {
            ddlCompanyUsers.SelectedValue = client.UserId.ToString();
        }

    }
}
