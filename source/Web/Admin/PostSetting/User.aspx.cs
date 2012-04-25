﻿using System;
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

public partial class Admin_PostSetting_User : System.Web.UI.Page
{
    private static readonly int CONST_EMAIL_LENGTH = 50;
    private static readonly int CONST_REAL_NAME_LENGTH = 20;
    private static readonly int CONST_IDCARD_LENGTH = 22;
    private static readonly int CONST_PHONE_LENGTH = 20;
    private static readonly int CONST_MOBILE_LENGTH = 20;
    private static readonly int CONST_ADDRESS_LENGTH = 200;
    private readonly DateTime CONST_MIN_DATE = new DateTime(1999, 1, 1);
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            user = UserOperation.GetUserById(id);
        }
        if (!IsPostBack)
        {
            DdlDepartmendDataBind();
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
        string sex = Request.Form["rdoSex"];
        string nation = Request.Form["slNation"];
        string maritalStatus = Request.Form["slMaritalStatus"];
        string education = Request.Form["slEducation"];
        string strBirthday = Request.Form[txtBirthday.ID].Trim();
        string strJoinDate = Request.Form[txtJoinDate.ID].Trim();
        string strContractDate = Request.Form[txtContractDate.ID].Trim();
        decimal commission = 0;
        int departmentId = 0;
        if (ddlDepartment.Items.Count > 0)
        {
            departmentId = int.Parse(ddlDepartment.SelectedItem.Value);
        }
        int companyId = int.Parse(ddlCompany.SelectedItem.Value);
        byte positionId = byte.Parse(ddlPosition.SelectedItem.Value);

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
        if (decimal.TryParse(Request.Form[txtCommission.ID], out commission))
        {
            if (commission < 0 || commission > 1)
            {
                lblMsg.Text = "提成数字只能在0--1之间！";
                return;
            }
        }
        else
        {
            lblMsg.Text = "提成数字只能在0--1之间！";
            return;
        }

        user.Address = address;
        user.Email = email;
        user.IdCard = idCard;
        user.Mobile = mobile;
        user.Phone = phone;
        user.RealName = realName;
        user.Education = education;
        user.MaritalStatus = maritalStatus;
        user.Nation = nation;
        user.Sex = sex == "1" ? true : false;
        user.Birthday = birthday;
        user.JoinDate = joinDate;
        user.ContractDate = contractDate;
        user.Commission = commission;
        user.DepartmentId = departmentId;
        user.PositionId = positionId;
        user.CompanyId = companyId;
        user.CreateDate = DateTime.Now;

        UserOperation.UpdateUser(user);
        lblMsg.Text = "修改成功！";
    }

    private void FormDataBind()
    {
        lblUsername.Text = user.Username;
        txtAddress.Text = user.Address;
        txtBirthday.Value = user.Birthday.ToShortDateString();
        txtCommission.Text = StringHelper.CurtNumber(user.Commission.ToString());
        txtContractDate.Value = user.ContractDate.ToShortDateString();
        txtEmail.Text = user.Email;
        txtIdCard.Text = user.IdCard;
        txtJoinDate.Value = user.JoinDate.ToShortDateString();
        txtMobile.Text = user.Mobile;
        txtPhone.Text = user.Phone;
        txtRealName.Text = user.RealName;
        rdoSex1.Checked = user.Sex == true ? true : false;
        rdoSex2.Checked = user.Sex == false ? true : false;
        ddlDepartment.SelectedValue = user.DepartmentId.ToString();
        ddlPosition.SelectedValue = user.PositionId.ToString();
        slEducation.Value = user.Education;
        slMaritalStatus.Value = user.MaritalStatus;
        slNation.Value = user.Nation;
        ddlCompany.SelectedValue = user.CompanyId.ToString();
    }

    private void DdlDepartmendDataBind()
    {
        ddlDepartment.DataSource = DepartmentOperation.GetDepartmentByCompanyId(user.CompanyId);
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataValueField = "Id";
        ddlDepartment.DataBind();
    }

    protected void ddlCompany_SelectIndexChanged(object sender, EventArgs e)
    {
        ddlDepartment.DataSource = DepartmentOperation.GetDepartmentByCompanyId(int.Parse(ddlCompany.SelectedItem.Value));
        ddlDepartment.DataTextField = "Name";
        ddlDepartment.DataValueField = "Id";
        ddlDepartment.DataBind();
    }
}
