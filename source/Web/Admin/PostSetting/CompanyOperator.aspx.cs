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
using Backend.Authorization.Config;
using Backend.Models;
using Backend.Models.Admin;
using System.Collections.Generic;

public partial class Admin_PostSetting_CompanyOperator : System.Web.UI.Page
{
    private int id = 0;
    Company company = null;
    protected string siteName = "";
    List<RuleAuthorizationModule> rams = RuleAuthorizationManager.GetRuleAuthorizationConfigurationSetion().Modules;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            company = CompanyOperation.GetCompanyById(id);
        }
        siteName = company.Name;
        if (!IsPostBack)
        {
            RpModuleDataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        List<ModuleAuthorization> mas = new List<ModuleAuthorization>();
        for (int i = 0; i < rpModule.Items.Count; i++)
        {
            RepeaterItem ri = rpModule.Items[i];
            RuleAuthorizationModule ram = rams[i];
            CheckBox chkAccess = (CheckBox)ri.FindControl("chkAccess");
            ModuleAuthorization ma = new ModuleAuthorization();
            ma.ModuleId = ram.Id;
            ma.Accessible = chkAccess.Checked;
            ma.Writable = true;
            mas.Add(ma);
        }
        CompanyOperation.UpdateCompanyAuthorization(id, mas);

        lblMsg.Text = "修改成功！";
    }

    private void RpModuleDataBind()
    {
        rpModule.ItemDataBound += new RepeaterItemEventHandler(rpModule_ItemDataBound);
        rpModule.DataSource = rams;
        rpModule.DataBind();
    }

    private void rpModule_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RuleAuthorizationModule ram = (RuleAuthorizationModule)e.Item.DataItem;
        CheckBox chkAccess = (CheckBox)e.Item.FindControl("chkAccess");
        foreach (ModuleAuthorization ma in company.ModuleAuthorizations)
        {
            if (ma.ModuleId == ram.Id)
            {
                chkAccess.Checked = ma.Accessible;
            }
        }
    }
}
