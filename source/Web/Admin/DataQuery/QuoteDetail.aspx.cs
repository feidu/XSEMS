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

public partial class Admin_DataQuery_QuoteDetail : System.Web.UI.Page
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
}
