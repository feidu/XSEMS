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

public partial class Admin_Finance_AlreadyPaidView : System.Web.UI.Page
{
    AlreadyPaid ap = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            ap = AlreadyPaidOperation.GetAlreadyPaidById(id);
        }
        FormDataBind();
    }

    private void FormDataBind()
    {
        lblEncode.Text = ap.Encode;
        lblPaidTime.Text = ap.PaidTime.ToShortDateString();
        lblPaymentMethod.Text = ap.PaymentMethod.Name;
        lblInvoice.Text = ap.Invoice;
        lblMoney.Text = ap.Money.ToString();
        lblRemark.Text = ap.Remark;
        lblUsername.Text = ap.User.RealName;
        lblCarrier.Text = ap.Carrier.Name;
        lblCreateTime.Text = ap.CreateTime.ToString();
    }
}