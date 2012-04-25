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
using System.Collections.Generic;

public partial class Admin_CompanySetting_CreateQuoteDetail : System.Web.UI.Page
{
    protected int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!int.TryParse(Request.QueryString["id"], out id))
        {
            Response.Write("<script language='javascript'>alert('参数错误！');location.href='Quote.aspx?id=" + id + "';</script>");
        }

        if (!IsPostBack)
        {
            DdlsDataBind();
        }
    }

    protected void ddlCarrierList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlsDataBind();
    }

    private void DdlsDataBind()
    {
        int cId = int.Parse(ddlCarrier.SelectedItem.Value);
        ddlCarrierArea.Items.Clear();
        List<CarrierArea> result = CarrierAreaOperation.GetCarrierAreaByCarrierId(cId);

        ddlCarrierArea.Items.Add(new ListItem("全部", "0"));
        foreach (CarrierArea ca in result)
        {
            ddlCarrierArea.Items.Add(new ListItem(ca.Name, ca.Id.ToString()));
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
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
        Quote quote = QuoteOperation.GetQuoteById(id);

        if (ddlCarrierArea.SelectedValue != "0")
        {
            QuoteDetail qd = new QuoteDetail();
            qd.QuoteId = id;
            qd.Carrier = carrier;
            CarrierArea ca = CarrierAreaOperation.GetCarrierAreaById(int.Parse(ddlCarrierArea.SelectedItem.Value));
            qd.CarrierArea = ca;
            qd.ClientId = quote.Client.Id;
            qd.Status = false;
            qd.CreateTime = DateTime.Now;
            qd.UserId = user.Id;
            qd.Discount = discount;
            qd.PreferentialGram = preferentialGram;
            qd.IsRegisterAbate = chkIsRegisterAbate.Checked;
            qd.RegisterCosts = registerCosts;
            QuoteOperation.CreateQuoteDetail(qd);
        }
        else
        {
            List<CarrierArea> result = CarrierAreaOperation.GetCarrierAreaByCarrierId(carrier.Id);
            foreach (CarrierArea ca in result)
            {
                QuoteDetail qd = new QuoteDetail();
                qd.QuoteId = id;
                qd.Carrier = carrier;
                qd.CarrierArea = ca;
                qd.ClientId = quote.Client.Id;
                qd.Status = false;
                qd.CreateTime = DateTime.Now;
                qd.UserId = user.Id;
                qd.Discount = discount;
                qd.PreferentialGram = preferentialGram;
                qd.IsRegisterAbate = chkIsRegisterAbate.Checked;
                qd.RegisterCosts = registerCosts;
                QuoteOperation.CreateQuoteDetail(qd);
            }
        }
        Response.Write("<script language='javascript'>alert('添加成功！');location.href='Quote.aspx?id=" + id + "';</script>");
    }
}

