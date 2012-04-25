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

public partial class Admin_Order_CreatePostPlan : System.Web.UI.Page
{
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        List<Depot> result = DepotOperation.GetDepotByCompanyId(user.CompanyId);
        if (result == null)
        {
            lblMsg.Text = "请先添加仓库信息！";
            return;
        }
        if (!IsPostBack)
        {
            ddlDepot.DataSource = result;
            ddlDepot.DataTextField = "Name";
            ddlDepot.DataValueField = "Id";
            ddlDepot.DataBind();
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
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
        PostPlan pp = new PostPlan();
        pp.CreateTime = DateTime.Now;
        pp.CompanyId = user.CompanyId;
        Carrier carrier = CarrierOperation.GetCarrierById(int.Parse(ddlCarrier.SelectedItem.Value));
        pp.Carrier = carrier;
        Depot depot = DepotOperation.GetDepotById(int.Parse(ddlDepot.SelectedItem.Value));
        pp.Depot = depot;
        pp.PackageCount = packageCount;
        pp.User = user;
        pp.Weight = weight;
        PostPlanOperation.CreatePostPlan(pp);
        Response.Write("<script language='javascript' type='text/javascript'>alert('添加成功！');location.href='PostPlanList.aspx';</script>");
    }
}
