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

public partial class Admin_Order_CheckOrderView : System.Web.UI.Page
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
        lblCountry.Text = od.ToCountry;
        lblAddressChangeCosts.Text = od.AddressChangeCosts.ToString();
        lblBarCode.Text = od.BarCode;
        if (od.CarrierEncode != null)
        {
            lblCarrier.Text = CarrierOperation.GetCarrierByEncode(od.CarrierEncode).Name;
        }
        if (od.Type >= 1)
        {
            lblGoodsType.Text = EnumConvertor.GoodsTypeConvertToString(od.Type);
        }
        lblEncode.Text = od.Encode;
        lblCount.Text = od.Count.ToString();
        lblCountry.Text = od.ToCountry;
        lblDamageMoney.Text = od.DamageMoney.ToString();
        lblDisposalCosts.Text = od.DisposalCosts.ToString();
        lblFetchCosts.Text = od.FetchCosts.ToString();
        lblInsureCosts.Text = od.InsureCosts.ToString();
        //lblKgPrice.Text = od.KgPrice.ToString();
        lblMaterialCosts.Text = od.MaterialCosts.ToString();
        lblOtherCosts.Text = od.OtherCosts.ToString();
        lblOtherCostsNote.Text = od.OtherCostsNote;
        lblPostCosts.Text = od.PostCosts.ToString();
        lblRegisterCosts.Text = od.RegisterCosts.ToString();
        lblRemark.Text = od.Remark;
        lblRemoteCosts.Text = od.RemoteCosts.ToString();
        lblReturnCosts.Text = od.ReturnCosts.ToString();
        lblReturnMoney.Text = od.ReturnMoney.ToString();
        lblToAddress.Text = od.ToAddress;
        lblToCity.Text = od.ToCity;
        lblToCountry.Text = od.ToCountry;
        lblToEmail.Text = od.ToEmail;
        lblToPhone.Text = od.ToPhone;
        lblToPostcode.Text = od.ToPostcode;
        lblTotalCosts.Text = od.TotalCosts.ToString();
        lblToUsername.Text = od.ToUsername;
        lblWeight.Text = od.Weight.ToString();
    }
}
