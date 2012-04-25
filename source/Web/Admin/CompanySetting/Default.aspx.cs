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
using Backend.Authorization;
using Backend.BAL;
using Backend.Utilities;

public partial class Admin_CompanySetting_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);

        Company company = CompanyOperation.GetCompanyById(user.CompanyId);
        txtAddress.Text = company.Address;
        txtCommission.Text = StringHelper.CurtNumber(company.Commission.ToString());
        txtContactPerson.Text = company.ContactPerson;
        txtEmail.Text = company.Email;
        txtName.Text = company.Name;
        txtPhone.Text = company.Phone;
        txtSmtp.Text = company.Smtp;
        txtQQ.Text = company.QQ;
        txtMSN.Text = company.MSN;
        ddlAreaCode.SelectedItem.Text = EnumConvertor.AreaCodeConvertToString((byte)company.AreaCode);
    }
}
