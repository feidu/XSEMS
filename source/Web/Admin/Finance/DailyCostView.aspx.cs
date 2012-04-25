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

public partial class Admin_Finance_DailyCostView : System.Web.UI.Page
{
    DailyCost dc = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            dc = DailyCostOperation.GetDailyCostById(id);
        }
        FormDataBind();
    }

    private void FormDataBind()
    {
        lblEncode.Text = dc.Encode;
        lblCreateTime.Text = dc.CreateTime.ToString();
        lblCostType.Text = CostTypeOperation.GetCostTypeById(dc.CostTypeId).Name;
        lblMoney.Text = dc.Money.ToString();
        lblOrderTime.Text = dc.OrderTime.ToShortDateString();
        lblOrderUser.Text = dc.OrderUserName;
        lblOrderUserDepartment.Text = DepartmentOperation.GetDepartmentById(UserOperation.GetUserById(dc.OrderUserId).DepartmentId).Name;
        lblRemark.Text = dc.Remark;
        lblUsername.Text = dc.Username;      
    }
}
