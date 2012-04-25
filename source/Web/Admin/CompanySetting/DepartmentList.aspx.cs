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
using Backend.BAL;
using Backend.Authorization;
using Backend.Models;

public partial class Admin_CompanySetting_DepartmentList : System.Web.UI.Page
{
    Department depart = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        RpDepartmentDataBind();
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            depart = DepartmentOperation.GetDepartmentById(id);
            if (!IsPostBack)
            {
                tbDepartmentUpdate.Visible = true;
                txtName.Text = depart.Name;
            }
        }
        else
        {
            tbDepartmentUpdate.Visible = false;
        }
    }

    private void RpDepartmentDataBind()
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        rpDepartment.DataSource = DepartmentOperation.GetDepartmentByCompanyId(user.CompanyId);
        rpDepartment.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        DepartmentOperation.DeleteDepartmentByIds(ids);
        lblMsg.Text = "删除成功！";
        RpDepartmentDataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtName.Text.Trim()))
        {
            lblMsg.Text = "分类名称不能为空！";
            return;
        }
        depart.Name = Request.Form[txtName.ID].Trim();

        DepartmentOperation.UpdateDepartment(depart);
        lblMsg.Text = "修改成功！";

        RpDepartmentDataBind();

        tbDepartmentUpdate.Visible = false;
    }
}
