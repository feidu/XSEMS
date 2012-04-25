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
using Backend.Authorization;
using Backend.Utilities;

public partial class Admin_CompanySetting_QuoteDetail : System.Web.UI.Page
{
    protected int id = 0;
    protected QuoteDetail qd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!int.TryParse(Request.QueryString["id"], out id))
        {
            Response.Write("<script language='javascript'>alert('参数错误！');location.href='Quote.aspx?id=" + id + "';</script>");
        }
        qd = QuoteOperation.GetQuoteDetailById(id);
        if (!IsPostBack)
        {
            FormDataBind();
            txtDiscount.Value = StringHelper.CurtNumber(qd.Discount.ToString());
            txtPreferentialGram.Value = StringHelper.CurtNumber(qd.PreferentialGram.ToString());
            txtSetRegisterCosts.Value = StringHelper.CurtNumber(qd.RegisterCosts.ToString());
            chkIsRegisterAbate.Checked = qd.IsRegisterAbate;
        }
    }

    protected void ddlCarrierList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlsDataBind();
    }

    private void DdlsDataBind()
    {
        int cId = int.Parse(ddlCarrier.SelectedItem.Value);
        ddlCarrierArea.DataSource = CarrierAreaOperation.GetCarrierAreaByCarrierId(cId);
        ddlCarrierArea.DataTextField = "Name";
        ddlCarrierArea.DataValueField = "Id";
        ddlCarrierArea.DataBind();
    }

    private void FormDataBind()
    {
        ddlCarrier.SelectedValue = qd.Carrier.Id.ToString();
        int cId = int.Parse(ddlCarrier.SelectedItem.Value);
        ddlCarrierArea.DataSource = CarrierAreaOperation.GetCarrierAreaByCarrierId(cId);
        ddlCarrierArea.DataTextField = "Name";
        ddlCarrierArea.DataValueField = "Id";
        ddlCarrierArea.DataBind();
        ddlCarrierArea.SelectedValue = qd.CarrierArea.Id.ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        string strDiscount = Request.Form[txtDiscount.ID].Trim();
        string strPreferentialGram = Request.Form[txtPreferentialGram.ID].Trim();
        string strRegisterCosts = Request.Form[txtSetRegisterCosts.ID].Trim();
        decimal discount = 1;
        decimal preferentialGram = 0;
        decimal registerCosts = 0;
        if (string.IsNullOrEmpty(strDiscount) || !decimal.TryParse(strDiscount, out discount))
        {
            lblMsg.Text = "折扣不能为空，且只能为数字！";
            return;
        }
        if (discount <= 0 || discount > 2)
        {
            lblMsg.Text = "折扣率数字只能在0和2之间！";
            return;
        }
        if (string.IsNullOrEmpty(strPreferentialGram) || !decimal.TryParse(strPreferentialGram, out preferentialGram))
        {
            lblMsg.Text = "让利克数不能为空，且只能为不小于0的数字！";
            return;
        }
        if (preferentialGram < 0)
        {
            lblMsg.Text = "让利克数只能为不小于0的数字！";
            return;
        }
        if (!string.IsNullOrEmpty(strRegisterCosts) && !decimal.TryParse(strRegisterCosts, out registerCosts))
        {
            lblMsg.Text = "挂号费只能为数字!";
            return;
        }
        Carrier carrier = CarrierOperation.GetCarrierById(int.Parse(ddlCarrier.SelectedItem.Value));
        qd.Carrier = carrier;
        CarrierArea ca = CarrierAreaOperation.GetCarrierAreaById(int.Parse(ddlCarrierArea.SelectedItem.Value));
        qd.CarrierArea = ca;
        qd.UserId = user.Id;
        qd.Discount = discount;
        qd.PreferentialGram = preferentialGram;
        qd.IsRegisterAbate = chkIsRegisterAbate.Checked;
        qd.RegisterCosts = registerCosts;
        QuoteOperation.UpdateQutoeDetail(qd);
        Response.Write("<script language='javascript'>alert('修改成功！');location.href='Quote.aspx?id=" + qd.QuoteId + "';</script>");
    }
}
