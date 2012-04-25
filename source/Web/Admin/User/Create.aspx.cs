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
using Backend.Models.Admin;
using Backend.BAL;
using Backend.Utilities;
using Backend.Authorization;
using System.Collections.Generic;

public partial class Admin_User_Create : System.Web.UI.Page
{
    private const int CONST_USERNAEM_LENGTH = 20;
    private const int CONST_PASSWORD_LENGTH = 20;
    private const int CONST_EMAIL_LENGTH = 50;
    private const int CONST_REAL_NAME_LENGTH = 20;
    private const int CONST_IDCARD_LENGTH = 22;
    private const int CONST_PHONE_LENGTH = 20;
    private const int CONST_MOBILE_LENGTH = 20;
    private const int CONST_ADDRESS_LENGTH = 200;
    private readonly DateTime CONST_MIN_DATE = new DateTime(1999, 1, 1);
    User adminUser = null;
    Company adminCompany = null;
    List<Department> result = new List<Department>();
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        adminUser = UserOperation.GetUserByUsername(cookie.Username);
        adminCompany = CompanyOperation.GetCompanyById(adminUser.CompanyId);
        result = DepartmentOperation.GetDepartmentByCompanyId(adminUser.CompanyId);
        if (!IsPostBack)
        {
            DdlsDataBind();
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
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
        string sex = Request.Form["rdoSex"];
        string nation = Request.Form["slNation"];
        string maritalStatus = Request.Form["slMaritalStatus"];
        string education = Request.Form["slEducation"];
        string strBirthday = Request.Form[txtBirthday.ID].Trim();
        string strJoinDate = Request.Form[txtJoinDate.ID].Trim();
        string strContractDate = Request.Form[txtContractDate.ID].Trim();

        int departmentId = 0;
        byte positionId = 0;
        positionId = byte.Parse(ddlPosition.SelectedItem.Value);
        if (result.Count > 0)
        {
            departmentId = int.Parse(ddlDepartment.SelectedItem.Value);
        }
        else
        {
            lblMsg.Text = "请先添加部门！";
            return;
        }

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
        DateTime birthday = CONST_MIN_DATE;
        if (string.IsNullOrEmpty(strBirthday) || !DateTime.TryParse(strBirthday, out birthday))
        {
            lblMsg.Text = "出生日期不能为空，且只能为时间格式如：2008-08-08 ！";
            return;
        }
        DateTime joinDate = CONST_MIN_DATE;
        if (string.IsNullOrEmpty(strJoinDate) || !DateTime.TryParse(strJoinDate, out joinDate))
        {
            lblMsg.Text = "入职日期不能为空，且只能为时间格式如：2008-08-08 ！";
            return;
        }
        DateTime contractDate = CONST_MIN_DATE;
        if (string.IsNullOrEmpty(strContractDate) || !DateTime.TryParse(strContractDate, out contractDate))
        {
            lblMsg.Text = "合同有效期不能为空，且只能为时间格式如：2008-08-08 ！";
            return;
        }
        
        User user = new User();
        user.Username = username;
        user.Address = address;
        user.CompanyId = adminUser.CompanyId;
        user.Email = email;
        user.IdCard = idCard;
        user.Mobile = mobile;
        user.Password = password;
        user.Phone = phone;
        user.RealName = realName;
        user.Education = education;
        user.MaritalStatus = maritalStatus;
        user.Nation = nation;
        user.Sex = sex=="1"?true:false;
        user.Birthday = birthday;
        user.JoinDate = joinDate;
        user.ContractDate = contractDate;
        user.Commission = 0;
        user.DepartmentId = departmentId;
        user.PositionId = positionId;
        user.CreateDate = DateTime.Now;

        OperatorStaus staus= UserOperation.CreateUser(user);
        switch(staus)
        {
            case OperatorStaus.OPERATOR_USERNAME_EXISTED:
                lblMsg.Text = "此用户名已经存在！";
                break;
            case OperatorStaus.SUCCESS:
                lblMsg.Text = "添加成功！";
                User currentUser = UserOperation.GetUserByUsername(user.Username);
                Position pt = PositionOperation.GetPositionById(currentUser.PositionId);
                UserOperation.UpdateOperatorAuthorization(currentUser.Id, pt.ModuleAuthorizations);
                break;
        }
    }

    private void DdlsDataBind()
    {
        if (result.Count > 0)
        {
            ddlDepartment.DataSource = result;
            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataValueField = "Id";
            ddlDepartment.DataBind();
        }
        else
        {
            lblMsg.Text = "请先添加部门和职位！";
            return;
        }
    }
}
