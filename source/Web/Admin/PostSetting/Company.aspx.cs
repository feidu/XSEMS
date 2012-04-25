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

public partial class Admin_PostSetting_Company : System.Web.UI.Page
{
    private static readonly int CONST_NAME_LENGTH = 50;
    private static readonly int CONST_EMAIL_LENGTH = 50;
    private static readonly int CONST_EMAIL_PASSWORD_LENGTH = 50;
    private static readonly int CONST_EMAIL_SMTP_LENGTH = 50;
    private static readonly int CONST_CONTACT_PERSON_LENGTH = 20;
    private static readonly int CONST_PHONE_LENGTH = 20;
    private static readonly int CONST_ADDRESS_LENGTH = 200;
    private static readonly int NORMAL_LENGTH = 50;

    Company company = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            company = CompanyOperation.GetCompanyById(id);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string name = Request.Form[txtName.ID].Trim();
        string contactPerson = Request.Form[txtContactPerson.ID].Trim();
        string phone = Request.Form[txtPhone.ID].Trim();
        string email = Request.Form[txtEmail.ID].Trim();
        string password = Request.Form[txtPassword.ID].Trim();
        string smtp = Request.Form[txtSmtp.ID].Trim();
        string address = Request.Form[txtAddress.ID].Trim();
        decimal commission = 0;
        string qq = Request.Form[txtQQ.ID].Trim();
        string msn = Request.Form[txtMSN.ID].Trim();

        byte area = byte.Parse(Request.Form["ddlAreaCode"]);

        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, CONST_NAME_LENGTH))
        {
            lblMsg.Text = "公司名称不能为空，并且长度不能超过 " + CONST_NAME_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(contactPerson) || Validator.IsMatchLessThanChineseCharacter(contactPerson, CONST_CONTACT_PERSON_LENGTH))
        {
            lblMsg.Text = "联系人不能为空，并且长度不能超过 " + CONST_CONTACT_PERSON_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(phone) || Validator.IsMatchLessThanChineseCharacter(phone, CONST_PHONE_LENGTH))
        {
            lblMsg.Text = "联系电话不能为空，并且长度不能超过 " + CONST_PHONE_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(email) || Validator.IsMatchLessThanChineseCharacter(email, CONST_EMAIL_LENGTH))
        {
            lblMsg.Text = "电子邮箱不能为空，并且长度不能超过 " + CONST_EMAIL_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(smtp) || Validator.IsMatchLessThanChineseCharacter(smtp, CONST_EMAIL_SMTP_LENGTH))
        {
            lblMsg.Text = "SMTP不能为空，并且长度不能超过 " + CONST_EMAIL_SMTP_LENGTH + " 个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(password) && Validator.IsMatchLessThanChineseCharacter(password, CONST_EMAIL_PASSWORD_LENGTH))
        {
            lblMsg.Text = "密码长度不能超过" + CONST_EMAIL_PASSWORD_LENGTH + "个字符！";
            return;
        }
        if (decimal.TryParse(Request.Form[txtCommission.ID].Trim(), out commission))
        {
            if (commission < 0 || commission > 1)
            {
                lblMsg.Text = "提成数字只能在0 - 1 之间！";
                return;
            }
        }
        else
        {
            lblMsg.Text = "提成数字只能在0 - 1 之间！";
            return;
        }

        if (!string.IsNullOrEmpty(qq) && Validator.IsMatchLessThanChineseCharacter(qq, NORMAL_LENGTH))
        {
            lblMsg.Text = "QQ长度不能超过 " + NORMAL_LENGTH + " 个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(msn) && Validator.IsMatchLessThanChineseCharacter(msn, NORMAL_LENGTH))
        {
            lblMsg.Text = "MSN长度不能超过 " + NORMAL_LENGTH + " 个字符！";
            return;
        }
        if (string.IsNullOrEmpty(address) || Validator.IsMatchLessThanChineseCharacter(address, CONST_ADDRESS_LENGTH))
        {
            lblMsg.Text = "公司地址不能为空，并且长度不能超过 " + CONST_ADDRESS_LENGTH + " 个字符！";
            return;
        }
        
        company.Name = name;
        company.Phone = phone;
        company.ContactPerson = contactPerson;
        company.Email = email;
        if (!string.IsNullOrEmpty(password) && password.Length > 0)
        {
            company.EmailPassword = password;
        }
        company.Smtp = smtp;
        company.Address = address;
        company.Commission = commission;
        company.QQ = qq;
        company.MSN = msn;        
        company.AreaCode = EnumConvertor.ConvertToAreaCode(area);

        CompanyOperation.UpdateCompany(company);

        lblMsg.Text = "修改成功！";
    }

    private void FormDataBind()
    {
        txtName.Text = company.Name;
        txtAddress.Text = company.Address;
        txtCommission.Text = StringHelper.CurtNumber(company.Commission.ToString());
        txtContactPerson.Text = company.ContactPerson;
        txtEmail.Text = company.Email;
        txtPassword.Text = company.EmailPassword;
        txtSmtp.Text = company.Smtp;
        txtPhone.Text = company.Phone;
        txtQQ.Text = company.QQ;
        txtMSN.Text = company.MSN;
        ddlAreaCode.SelectedItem.Text = EnumConvertor.AreaCodeConvertToString((byte)company.AreaCode);
    }

}
