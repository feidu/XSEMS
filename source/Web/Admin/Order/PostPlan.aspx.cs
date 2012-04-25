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
using System.Collections.Generic;

public partial class Admin_Order_PostPlan : System.Web.UI.Page
{
    PostPlan pp = null;
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            pp = PostPlanOperation.GetPostPlanById(id);
        }
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        List<Depot> result = DepotOperation.GetDepotByCompanyId(pp.CompanyId);
        if (!IsPostBack)
        {
            ddlDepot.DataSource = result;
            ddlDepot.DataTextField = "Name";
            ddlDepot.DataValueField = "Id";
            ddlDepot.DataBind();
            FormDataBind();
        }         
    }

    private void FormDataBind()
    {
        txtPackageCount.Text = pp.PackageCount.ToString();
        txtWeight.Text = pp.Weight.ToString();
        ddlCarrier.SelectedValue = pp.Carrier.Id.ToString();
        ddlDepot.SelectedValue = pp.Depot.Id.ToString();
        lblUsername.Text = pp.User.RealName;
        lblCreateTime.Text = pp.CreateTime.ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string strPackageCount = Request.Form[txtPackageCount.ID].Trim();
        string strWeight = Request.Form[txtWeight.ID].Trim();

        int packageCount = 0;
        if (string.IsNullOrEmpty(strPackageCount) || !int.TryParse(strPackageCount, out packageCount))
        {
            lblMsg.Text = "发件包裹数量不能为空，且只能为数字！";
            return;
        }

        decimal weight = 0;
        if (string.IsNullOrEmpty(strWeight) || !decimal.TryParse(strWeight, out weight))
        {
            lblMsg.Text = "总重量不能为空，且只能为数字！";
            return;
        }
        Carrier carrier = CarrierOperation.GetCarrierById(int.Parse(ddlCarrier.SelectedItem.Value));
        pp.Carrier = carrier;
        Depot depot = DepotOperation.GetDepotById(int.Parse(ddlDepot.SelectedItem.Value));
        pp.Depot = depot;
        pp.PackageCount = packageCount;
        pp.User = user;
        pp.Weight = weight;
        PostPlanOperation.UpdatePostPlan(pp);
        lblMsg.Text = "修改成功！";
        FormDataBind();
    }
}
