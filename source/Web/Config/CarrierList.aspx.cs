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


public partial class Config_CarrierList : System.Web.UI.Page
{
    protected string countryName = "";
    protected int count = 0;
    protected decimal weight = 0;
    private byte type = 0;
    protected int clientId = 0;
    protected List<CarrierCharge> result = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["country"]) && int.TryParse(Request.QueryString["count"], out count) && decimal.TryParse(Request.QueryString["weight"], out weight) && byte.TryParse(Request.QueryString["type"], out type) && int.TryParse(Request.QueryString["clientId"], out clientId))
        {
            countryName = Request.QueryString["country"].Trim();
            Country country = CountryOperation.GetCountryByEnglishName(countryName);
            if (country != null)
            {
                result = ChargeStandardOperation.GetCarrierCharge(country.Id, weight, type, count, clientId);
                lblMsg.Text = "";
            }
            else
            {
                trMsg.Visible = true;
                lblMsg.Text = "输入的国家不存在！";
            }
        }
        else
        {
            trMsg.Visible = true;
            lblMsg.Text = "数量只能为大于0的整数！";
        }
    }
}
