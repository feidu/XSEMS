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

public partial class Admin_PostSetting_AreaCountryList : System.Web.UI.Page
{
    CarrierArea ca = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            ca = CarrierAreaOperation.GetCarrierAreaById(id);
            lblCarrier.Text = ca.Carrier.Name;
            lblCarrierArea.Text = ca.Name;
  
            rpAreaCountry.DataSource = AreaCountryOperation.GetAreaCountryByCarrierAreaId(id);
            rpAreaCountry.DataBind();
        }
    }
}
