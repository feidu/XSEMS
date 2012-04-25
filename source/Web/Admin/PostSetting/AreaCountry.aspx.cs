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
using System.Collections.Generic;

public partial class Admin_PostSetting_AreaCountry : System.Web.UI.Page
{
    int id = 0;
    CarrierArea ca = null;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!int.TryParse(Request.QueryString["id"], out id))
        {
            return;
        }
        ca = CarrierAreaOperation.GetCarrierAreaById(id);
        lblCarrier.Text = ca.Carrier.Name;
        lblCarrierArea.Text = ca.Name;
        if (!IsPostBack)
        {
            RpCountryDataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {        
        AreaCountryOperation.DeleteAreaCountryByCarrierAreaId(id);        
        
        CarrierArea ca = CarrierAreaOperation.GetCarrierAreaById(id);
        for (int i = 0; i < rpCountry.Items.Count; i++)
        {
            RepeaterItem ri = rpCountry.Items[i];
            CheckBox chkId = (CheckBox)ri.FindControl("chkId");
            Label lblId = (Label)ri.FindControl("lblId");
            if (chkId.Checked)
            {   
                AreaCountry ac = new AreaCountry();
                Country country = CountryOperation.GetCountryById(int.Parse(lblId.Text));
                ac.Country = country;
                ac.CarrierArea = ca;
                AreaCountryOperation.CreateAreaCountry(ac);
            }
        }
        Response.Write("<script language='javascript'>alert('修改成功！');location.href='CarrierAreaList.aspx?id=" + ca.Carrier.Id + "';</script>");
    }

    private void RpCountryDataBind()
    {
        rpCountry.ItemDataBound += new RepeaterItemEventHandler(rpCountry_ItemDataBound);
        rpCountry.DataSource = CountryOperation.GetCountryForArea();
        rpCountry.DataBind();
    }

    private void rpCountry_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Country country = (Country)e.Item.DataItem;

        CheckBox chkId = (CheckBox)e.Item.FindControl("chkId");
        Label lblId = (Label)e.Item.FindControl("lblId");
        List<AreaCountry> result = AreaCountryOperation.GetAreaCountryByCarrierAreaId(id);
        foreach (AreaCountry ac in result)
        {
            if(ac.Country!=null && ac.Country.Id == country.Id)
            {
                chkId.Checked = true;
            }
        }
        lblId.Text = country.Id.ToString();
    }
}
