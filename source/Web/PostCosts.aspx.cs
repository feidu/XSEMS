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

public partial class PostCosts : System.Web.UI.Page
{
    protected List<CarrierCharge> result = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strCountry = Request.Form["ddlCountries"];
            string strGoodsType = Request.Form["radioType"];
            string strWeight = Request.Form["txtWeight"].Trim();
            string strCount = Request.Form["txtCount"].Trim();

            hdCountry.Value = strCountry;
            txtCountry.Value = strCountry;
            txtWeight.Value = strWeight;
            txtCount.Value = strCount;
            ddlGoodsType.SelectedValue = strGoodsType;
            int count = 0;
            decimal weight = 0;
            byte type = 0;
            if (!string.IsNullOrEmpty(strCountry) && int.TryParse(strCount, out count) && decimal.TryParse(strWeight, out weight) && byte.TryParse(strGoodsType, out type))
            {
                Country country = CountryOperation.GetCountryByEnglishName(strCountry);
                if (country != null)
                {
                    result = ChargeStandardOperation.GetCarrierCharge(country.Id, weight, type, count, 0);
                    lblMsg.Text = "";
                }
                else
                {
                    trMsg.Visible = true;
                    lblMsg.Text = "输入的国家不存在！";
                }
            }
            else if (!int.TryParse(strCount, out count))
            {
                trMsg.Visible = true;
                lblMsg.Text = "数量只能为大于0的整数！";
            }
            else if (!decimal.TryParse(strWeight, out weight))
            {
                trMsg.Visible = true;
                lblMsg.Text = "重量只能为大于0的数字！";
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strLongCountry = Request.Form["txtCountry"].Trim();
        string strCountry = Request.Form["hdCountry"].Trim();
        string strGoodsType = Request.Form["ddlGoodsType"];
        string strWeight = Request.Form["txtWeight"].Trim();
        string strCount = Request.Form["txtCount"].Trim();

        hdCountry.Value = strCountry;
        txtCountry.Value = strLongCountry;
        txtWeight.Value = strWeight;
        txtCount.Value = strCount;
        ddlGoodsType.SelectedValue = strGoodsType;
        int count = 0;
        decimal weight = 0;
        byte type = 0;
        if (!string.IsNullOrEmpty(strCountry) && int.TryParse(strCount, out count) && decimal.TryParse(strWeight, out weight) && byte.TryParse(strGoodsType, out type))
        {
            Country country = CountryOperation.GetCountryByEnglishName(strCountry);
            if (country != null)
            {
                result = ChargeStandardOperation.GetCarrierCharge(country.Id, weight, type, count, 0);
                lblMsg.Text = "";
            }
            else
            {
                trMsg.Visible = true;
                lblMsg.Text = "输入的国家不存在！";
            }
        }
        else if (!int.TryParse(strCount, out count))
        {
            trMsg.Visible = true;
            lblMsg.Text = "数量只能为大于0的整数！";
        }
        else if (!decimal.TryParse(strWeight, out weight))
        {
            trMsg.Visible = true;
            lblMsg.Text = "重量只能为大于0的数字！";
        }
    }  
}
