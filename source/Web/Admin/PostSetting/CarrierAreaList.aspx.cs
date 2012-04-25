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

public partial class Admin_PostSetting_CarrierAreaList : System.Web.UI.Page
{
    protected int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!int.TryParse(Request.QueryString["id"], out id))
        {
            return;
        }
        lblCarrier.Text = CarrierOperation.GetCarrierById(id).Name;
        RpCarrierAreaDataBind();
    }

    private void RpCarrierAreaDataBind()
    {
        rpCarrierArea.DataSource = CarrierAreaOperation.GetCarrierAreaByCarrierId(id);
        rpCarrierArea.DataBind();
    }
}
