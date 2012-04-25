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
using Backend.Models;
using Backend.Authorization;

public partial class Admin_CompanySetting_DepotList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RpDepotDataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        DepotOperation.DeleteDepotByIds(ids);
        RpDepotDataBind();
    }

    private void RpDepotDataBind()
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        rpDepot.DataSource = DepotOperation.GetDepotByCompanyId(user.CompanyId);
        rpDepot.DataBind();
    }
}
