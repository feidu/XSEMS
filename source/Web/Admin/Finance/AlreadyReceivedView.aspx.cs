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

public partial class Admin_Finance_AlreadyReceivedView : System.Web.UI.Page
{
    Recharge recharge = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            recharge = RechargeOperation.GetRechargeById(id);
        }
        FormDataBind();
    }

    private void FormDataBind()
    {
        lblAccount.Text = recharge.Account;
        if (recharge.Paid > 0)
        {
            trUsdConversion.Visible = true;
            trReceivedMoney.Visible = false;
            lblClientPaid.Text = recharge.Paid.ToString();
            lblExchangeRate.Text = recharge.ExchangeRate.ToString();
            lblActualReceived.Text = recharge.Money.ToString();
        }
        else
        {
            trUsdConversion.Visible = false;
            trReceivedMoney.Visible = true;
            lblReceivedMoney.Text = recharge.Money.ToString();
        }
        lblEncode.Text = recharge.Encode;
        lblReceivedTime.Text = recharge.ReceiveTime.ToString();
        lblClientName.Text = recharge.ClientName;
        lblCurrencyType.Text = EnumConvertor.CurrencyTypeConvertToString((byte)recharge.CurrencyType);
        lblInvoice.Text = recharge.Invoice;
        lblPaymentMethod.Text = recharge.PaymentMethodName;
        lblPaymentType.Text = EnumConvertor.PaymentTypeConvertToString((byte)recharge.PaymentType);
        lblRemark.Text = recharge.Remark;
        lblUsername.Text = recharge.UserName;
        lblCreateTime.Text = recharge.CreateTime.ToString();
    }
}
