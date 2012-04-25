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

public partial class Admin_DataQuery_Liability : System.Web.UI.Page
{
    private Liability ly = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            ly = LiabilityOperation.GetLiabilityById(id);
        }
        hdLiabilityId.Value = id.ToString();
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }
    private void FormDataBind()
    {
        txtBarCode.Text = ly.BarCode;
        txtCarrier.Text = ly.CarrierName;
        txtCarrierPtEadu.Text = StringHelper.CurtNumber(ly.CarrierPtEadu.ToString());
        txtCashierUser.Text = ly.CashierUser;
        txtClientName.Text = ly.ClientName;
        txtClientPtEadu.Text = StringHelper.CurtNumber(ly.ClientPtEadu.ToString());
        txtCorrectUser.Text = ly.CorrectUser;
        lblCreateUser.Text = ly.CreateUser;
        txtDetail.Text = ly.Detail;
        txtEaduPtCarrier.Text = StringHelper.CurtNumber(ly.EaduPtCarrier.ToString());
        txtEaduPtClient.Text = StringHelper.CurtNumber(ly.EaduPtClient.ToString());
        lblEncode.Text = ly.Encode;
        txtFillTime.Value = ly.FillTime.ToShortDateString();
        txtFillUser.Text = ly.FillUser;
        txtFinanceUser.Text = ly.FinanceUser;
        txtLiabilityUser.Text = ly.LiabilityUser;
        txtOrderEncode.Text = ly.Order.Encode;
        lblOrderUser.Text = UserOperation.GetUserById(ly.Order.UserId).RealName;
        lblReceiveDate.Text = ly.Order.ReceiveDate.ToShortDateString();
        txtResult.Text = ly.Result;
        txtTotalMoney.Text = StringHelper.CurtNumber(ly.TotalMoney.ToString());
        if (ly.ZrDepartment != null)
        {
            txtZrDepartment.Text = ly.ZrDepartment.ToString();
        }
        txtZrDtMoney.Text = StringHelper.CurtNumber(ly.ZrDtMoney.ToString());
        txtZrUrMoney.Text = StringHelper.CurtNumber(ly.ZrUrMoney.ToString());
        txtZrUser.Text = ly.ZrUser;
        ddlCorrectStatus.SelectedValue = ly.CorrectStatus ? "1" : "0";
        ddlCurrencyType.SelectedValue = ly.CurrencyType;
        ddlEventType.SelectedValue = Convert.ToByte(ly.EventType).ToString();
    }
}
