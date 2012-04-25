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

public partial class Admin_PostSetting_CarrierList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RpCarrierDataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        CarrierOperation.DeleteCarrierByIds(ids);
        RpCarrierDataBind();
    }

    private void RpCarrierDataBind()
    {
        rpCarrier.DataSource = CarrierOperation.GetCarrier();
        rpCarrier.DataBind();
    }
}
