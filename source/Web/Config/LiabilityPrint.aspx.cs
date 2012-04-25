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

public partial class Config_LiabilityPrint : System.Web.UI.Page
{
    private Liability ly = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            ly = LiabilityOperation.GetLiabilityById(id);
        }
        FormDataBind();
    }
    private void FormDataBind()
    {
        lblBarCode.Text = ly.BarCode;
        lblCarrier.Text = ly.CarrierName;
        lblCarrierPtEadu.Text = StringHelper.CurtNumber(ly.CarrierPtEadu.ToString());
        lblCashierUser.Text = ly.CashierUser;
        lblClientName.Text = ly.ClientName;
        lblClientPtEadu.Text = StringHelper.CurtNumber(ly.ClientPtEadu.ToString());
        lblCorrectUser.Text = ly.CorrectUser;
        lblCreateUser.Text = ly.CreateUser;
        lblDetail.Text = ly.Detail;
        lblEaduPtCarrier.Text = StringHelper.CurtNumber(ly.EaduPtCarrier.ToString());
        lblEaduPtClient.Text = StringHelper.CurtNumber(ly.EaduPtClient.ToString());
        lblEncode.Text = ly.Encode;
        lblFillTime.Text = ly.FillTime.ToShortDateString();
        lblFillUser.Text = ly.FillUser;
        lblFinanceUser.Text = ly.FinanceUser;
        lblLiabilityUser.Text = ly.LiabilityUser;
        lblOrderEncode.Text = ly.Order.Encode;
        lblOrderUser.Text = UserOperation.GetUserById(ly.Order.UserId).RealName;
        lblReceiveDate.Text = ly.Order.ReceiveDate.ToShortDateString();
        lblResult.Text = ly.Result;
        lblTotalMoney.Text = StringHelper.CurtNumber(ly.TotalMoney.ToString());
        if (ly.ZrDepartment != null)
        {
            lblZrDepartment.Text = ly.ZrDepartment.ToString();
        }
        lblZrDtMoney.Text = StringHelper.CurtNumber(ly.ZrDtMoney.ToString());
        lblZrUrMoney.Text = StringHelper.CurtNumber(ly.ZrUrMoney.ToString());
        lblZrUser.Text = ly.ZrUser;
        lblCorrectStatus.Text = ly.CorrectStatus ? "已更正" : "未更正";
        lblCurrencyType.Text = ly.CurrencyType;
        lblEventType.Text = EnumConvertor.LiabilityStatusConvertToString((byte)ly.EventType);
    }
}
