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
using System.Collections.Generic;

public partial class Admin_CompanySetting_Depot : System.Web.UI.Page
{
    private static readonly int NAME_LENGTH = 50;
    private static readonly int PHONE_LENGTH = 50;
    private static readonly int FAX_LENGTH = 50;
    private static readonly int CONTACT_PERSON_LENGTH = 50;
    private static readonly int ADDRESS_LENGTH = 200;
    Depot depot = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            depot = DepotOperation.GetDepotById(id);
        }
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        List<Department> result = DepartmentOperation.GetDepartmentByCompanyId(user.CompanyId);
        if (result == null)
        {
            lblMsg.Text = "请先添加部门！";
            return;
        }
        if (!IsPostBack)
        {
            ddlDepartment.DataSource = result;
            ddlDepartment.DataTextField = "Name";
            ddlDepartment.DataValueField = "Id";
            ddlDepartment.DataBind();
            FormDataBind();
        }
        
    }

    private void FormDataBind()
    {
        txtAddress.Text = depot.Address;
        txtContactPerson.Text = depot.ContactPerson;
        txtFax.Text = depot.Fax;
        txtName.Text = depot.Name;
        txtPhone.Text = depot.Phone;
        slStatus.Value = depot.Status == true ? "1" : "0";
        ddlDepartment.SelectedValue = depot.Department.Id.ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string name = Request.Form[txtName.ID].Trim();
        string contactPerson = Request.Form[txtContactPerson.ID].Trim();
        string phone = Request.Form[txtPhone.ID].Trim();
        string fax = Request.Form[txtFax.ID].Trim();
        string address = Request.Form[txtAddress.ID].Trim();

        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, NAME_LENGTH))
        {
            lblMsg.Text = "仓库名称不能为空，并且长度不能超过 " + NAME_LENGTH + " 个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(contactPerson) && Validator.IsMatchLessThanChineseCharacter(contactPerson, CONTACT_PERSON_LENGTH))
        {
            lblMsg.Text = "联系人长度不能超过 " + CONTACT_PERSON_LENGTH + " 个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(phone) && Validator.IsMatchLessThanChineseCharacter(phone, PHONE_LENGTH))
        {
            lblMsg.Text = "联系电话长度不能超过 " + PHONE_LENGTH + " 个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(fax) && Validator.IsMatchLessThanChineseCharacter(fax, FAX_LENGTH))
        {
            lblMsg.Text = "传真长度不能超过 " + FAX_LENGTH + " 个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(address) && Validator.IsMatchLessThanChineseCharacter(address, ADDRESS_LENGTH))
        {
            lblMsg.Text = "联系地址长度不能超过 " + ADDRESS_LENGTH + " 个字符！";
            return;
        }

        depot.Name = name;
        depot.ContactPerson = contactPerson;
        depot.Phone = phone;
        depot.Fax = fax;
        depot.Address = address;
        depot.Status = slStatus.Value == "1" ? true : false;
        Department depart = DepartmentOperation.GetDepartmentById(int.Parse(ddlDepartment.SelectedItem.Value));
        depot.Department = depart;

        DepotOperation.UpdateDepot(depot);
        lblMsg.Text = "修改成功！";
        FormDataBind();
    }
}
