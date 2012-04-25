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

public partial class Admin_DataQuery_Insurance : System.Web.UI.Page
{
    Insurance insurance = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            insurance = InsuranceOperation.GetInsuranceById(id);
        }
        FormDataBind();
    }

    private void FormDataBind()
    {
        txtBarCode.Value = OrderDetailOperation.GetOrderDetailById(insurance.OrderDetailId).BarCode;
        txtInsureWorth.Value = insurance.InsureWorth.ToString();
        txtInsureCosts.Value = insurance.InsureCosts.ToString();
    }
}
