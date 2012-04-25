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

public partial class Admin_DataQuery_ReceiveOrderDetail : System.Web.UI.Page
{
    OrderDetail od = null;
    protected Order order = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            od = OrderDetailOperation.GetOrderDetailById(id);
            order = OrderOperation.GetOrderById(od.OrderId);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }

    private void FormDataBind()
    {
        lblEncode.Text = order.Encode;
        hdClientId.Value = order.Client.Id.ToString();
        hdCountry.Value = od.ToCountry;
        hdCountryBak.Value = od.ToCountry;
        hdCarrierEncode.Value = od.CarrierEncode;
        txtCountry.Value = od.ToCountry;
        txtAddressChangeCosts.Value = od.AddressChangeCosts.ToString();
        txtBarCode.Value = od.BarCode;
        if (od.CarrierEncode != null)
        {
            txtCarrier.Value = CarrierOperation.GetCarrierByEncode(od.CarrierEncode).Name;
        }
        if (od.PostCosts <= 0)
        {
            txtCount.Value = od.ClientCount.ToString();
            txtWeight.Value = od.ClientWeight.ToString();
        }
        else
        {
            txtCount.Value = od.Count.ToString();
            txtWeight.Value = od.Weight.ToString();
        }
        txtDamageMoney.Value = od.DamageMoney.ToString();
        txtDisposalCosts.Value = od.DisposalCosts.ToString();
        txtFetchCosts.Value = od.FetchCosts.ToString();
        txtInsureCosts.Value = od.InsureCosts.ToString();
        txtKgPrice.Value = od.KgPrice.ToString();
        txtMaterialCosts.Value = od.MaterialCosts.ToString();
        txtOtherCosts.Value = od.OtherCosts.ToString();
        txtOtherCostsNote.Value = od.OtherCostsNote;
        txtPostCosts.Value = od.PostCosts.ToString();
        txtRegisterCosts.Value = od.RegisterCosts.ToString();
        txtRemark.Text = od.Remark;
        txtRemoteCosts.Value = od.RemoteCosts.ToString();
        txtReturnCosts.Value = od.ReturnCosts.ToString();
        txtReturnMoney.Value = od.ReturnMoney.ToString();
        txtToAddress.Value = od.ToAddress;
        txtToCity.Value = od.ToCity;
        txtToCountry.Value = od.ToCountry;
        txtToEmail.Value = od.ToEmail;
        txtToPhone.Value = od.ToPhone;
        txtToPostcode.Value = od.ToPostcode;
        txtTotalCosts.Value = od.TotalCosts.ToString();
        txtToUsername.Value = od.ToUsername;
        slGoodsType.Value = od.Type.ToString();
    }
}
