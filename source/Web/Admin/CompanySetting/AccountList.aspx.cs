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

public partial class Admin_CompanySetting_AccountList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RpReceivableAccountDataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        ReceivableAccountOperation.DeleteReceivableAccountByIds(ids);
        RpReceivableAccountDataBind();
    }

    private void RpReceivableAccountDataBind()
    {
        rpReceivableAccount.DataSource = ReceivableAccountOperation.GetReceivableAccount();
        rpReceivableAccount.DataBind();
    }
}
