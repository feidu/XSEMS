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
using Backend.Authorization;

public partial class Admin_Finance_ShouldPayView : System.Web.UI.Page
{
    ShouldPay sp = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            sp = ShouldPayOperation.GetShouldPayById(id);
        }
        FormDataBind();
    }

    private void FormDataBind()
    {
        lblEncode.Text = sp.Encode;
        lblCarrier.Text = sp.Carrier.Name;
        lblType.Text = sp.Type;
        lblPayTime.Text = sp.CreateTime.ToShortDateString();
        txtMoney.Text = sp.OrderDetail.SelfTotalCosts.ToString();
        lblUsername.Text = UserOperation.GetUserById(sp.UserId).RealName;
        lblCreateTime.Text = sp.CreateTime.ToString();
        lblOrderEncode.Text = sp.OrderEncode;
        lblBarCode.Text = sp.OrderDetail.BarCode;
        lblToCountry.Text = sp.OrderDetail.ToCountry;
        lblWeight.Text = sp.OrderDetail.Weight.ToString();
        lblCount.Text = sp.OrderDetail.Count.ToString();
    }
    
}
