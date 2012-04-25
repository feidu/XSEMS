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

public partial class Admin_Personal_Default : System.Web.UI.Page
{
    User user = null;
    private static readonly int CONST_EMAIL_LENGTH = 50;
    private static readonly int CONST_PHONE_LENGTH = 20;
    private static readonly int CONST_MOBILE_LENGTH = 20;
    private static readonly int CONST_ADDRESS_LENGTH = 200;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }

    private void FormDataBind()
    {
        lblCompany.Text = CompanyOperation.GetCompanyById(user.CompanyId).Name;
        lblUsername.Text = user.Username;
        txtAddress.Text = user.Address;
        lblBirthday.Text = user.Birthday.ToShortDateString();
        lblCommission.Text = StringHelper.CurtNumber(user.Commission.ToString());
        lblContractDate.Text = user.ContractDate.ToShortDateString();
        if (user.DepartmentId != 0)
        {
            lblDepartment.Text = DepartmentOperation.GetDepartmentById(user.DepartmentId).Name;
        }
        lblEducation.Text = user.Education;
        txtEmail.Text = user.Email;
        lblIdCard.Text = user.IdCard;
        lblJoinDate.Text = user.JoinDate.ToShortDateString();
        lblMaritalStatus.Text = user.MaritalStatus;
        txtMobile.Text = user.Mobile;
        lblNation.Text = user.Nation;
        txtPhone.Text = user.Phone;
        lblPosition.Text = PositionOperation.GetPositionById(user.PositionId).Name;
        lblRealName.Text = user.RealName;
        lblSex.Text = user.Sex == true ? "男" : "女";        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string phone = Request.Form[txtPhone.ID].Trim();
        string mobile = Request.Form[txtMobile.ID].Trim();  
        string email = Request.Form[txtEmail.ID].Trim();     
        string address = Request.Form[txtAddress.ID].Trim();

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

        user.Phone = phone;
        user.Mobile = mobile;
        user.Email = email;
        user.Address = address;

        UserOperation.UpdateUser(user);
        lblMsg.Text = "修改成功！";

        FormDataBind();
    }
}
