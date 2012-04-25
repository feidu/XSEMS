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

public partial class Admin_PostSetting_UserOpreator : System.Web.UI.Page
{
    private int id = 0;
    User user = null;
    protected string username = "";
    List<RuleAuthorizationModule> rams = RuleAuthorizationManager.GetRuleAuthorizationConfigurationSetion().Modules;
    List<RuleAuthorizationModule> compRams = new List<RuleAuthorizationModule>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            user = UserOperation.GetUserById(id);
        }
        username = user.RealName;
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
            Label lblId = (Label)ri.FindControl("lblId");
            ModuleAuthorization ma = new ModuleAuthorization();
            ma.ModuleId = int.Parse(lblId.Text);
            ma.Accessible = chkAccess.Checked;
            ma.Writable = true;
            mas.Add(ma);
        }
        UserOperation.UpdateOperatorAuthorization(id, mas);

        lblMsg.Text = "修改成功！ ";
    }

    private void RpModuleDataBind()
    {
        string[] array = CompanyOperation.GetCompanyRuleAuthorizationModuleIds(user.CompanyId).Split(',');
        foreach (RuleAuthorizationModule ram in rams)
        {
            foreach (string sId in array)
            {
                if (ram.Id.ToString() == sId)
                {
                    compRams.Add(ram);
                }
            }
        }
        rpModule.ItemDataBound += new RepeaterItemEventHandler(rpModule_ItemDataBound);
        rpModule.DataSource = compRams;
        rpModule.DataBind();
    }

    private void rpModule_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RuleAuthorizationModule ram = (RuleAuthorizationModule)e.Item.DataItem;
        CheckBox chkAccess = (CheckBox)e.Item.FindControl("chkAccess");
        Label lblId = (Label)e.Item.FindControl("lblId");
        foreach (ModuleAuthorization ma in user.ModuleAuthorizations)
        {
            if (ma.ModuleId == ram.Id)
            {
                chkAccess.Checked = ma.Accessible;
            }
        }
        lblId.Text = ram.Id.ToString();
    }

}

