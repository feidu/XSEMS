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

public partial class Admin_CompanySetting_CreateDepartment : System.Web.UI.Page
{
    private const int CONST_DEPARTMENT_NAME_LENGHT = 50;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string name = Request.Form[txtDeptName.ID].Trim();
        if (string.IsNullOrEmpty(name) || Validator.IsMatchLessThanChineseCharacter(name, CONST_DEPARTMENT_NAME_LENGHT))
        {
            lblMsg.Text = "部门名称不能为空，并且不能超过个" + CONST_DEPARTMENT_NAME_LENGHT + "字符！";
            return;
        }
        Department dept = new Department();
        dept.Name = name;
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        dept.CompanyId = user.CompanyId;

        if (DepartmentOperation.CreateDepartment(dept))
        {
            lblMsg.Text = "添加成功！";
        }
        else
        {
            lblMsg.Text = "部门名称已经存在！";
        }
    }
}
