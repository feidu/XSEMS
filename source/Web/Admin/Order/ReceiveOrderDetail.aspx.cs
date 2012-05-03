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

public partial class Admin_Order_ReceiveOrderDetail : System.Web.UI.Page
{
    OrderDetail od = null;
    protected Order order = null;
    private static readonly int NOTE_ADDRESS_LENGTH = 200;
    private static readonly int CONTACT_WAY_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string countryName = Request.Form[hdCountry.ID].Trim();
        Country country = CountryOperation.GetCountryByEnglishName(countryName);
        if (country == null)
        {
            lblMsg.Text = "国家名称不存在！";
            return;
        }
        decimal weight = 0;
        if (string.IsNullOrEmpty(Request.Form[txtWeight.ID].Trim()) || !decimal.TryParse(Request.Form[txtWeight.ID].Trim(), out weight))
        {
            lblMsg.Text = "计费重量不能为空，且只能为数字！";
            return;
        }

        int count = 0;
        if (string.IsNullOrEmpty(Request.Form[txtCount.ID].Trim()) || !int.TryParse(Request.Form[txtCount.ID].Trim(), out count))
        {
            lblMsg.Text = "件数不能为空，且只能为大于等于1的整数！";
            return;
        }
        string carrierEncode = Request.Form[hdCarrierEncode.ID].Trim();
        if (string.IsNullOrEmpty(carrierEncode))
        {
            lblMsg.Text = "承运商名称不能为空！";
            return;
        }
        Carrier carrier = CarrierOperation.GetCarrierByEncode(carrierEncode);
        if (carrier == null)
        {
            lblMsg.Text = "承运商名称不存在！";
            return;
        }       
        decimal clientPostCosts = 0;
        if (string.IsNullOrEmpty(Request.Form[txtPostCosts.ID].Trim()) || !decimal.TryParse(Request.Form[txtPostCosts.ID].Trim(), out clientPostCosts))
        {
            lblMsg.Text = "运费合计不能为空，且只能为大于0的数字！";
            return;
        }
        if (clientPostCosts <= 0)
        {
            lblMsg.Text = "运费合计不能为空，且只能为大于0的数字！";
            return;
        }
        decimal clientRegisterCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtRegisterCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtRegisterCosts.ID].Trim(), out clientRegisterCosts))
        {
            lblMsg.Text = "挂号费只能为数字！";
            return;
        }
        decimal clientDisposalCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtDisposalCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtDisposalCosts.ID].Trim(), out clientDisposalCosts))
        {
            lblMsg.Text = "处理费只能为数字！";
            return;
        }
        decimal clientFuelCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtFuelCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtFuelCosts.ID].Trim(), out clientFuelCosts))
        {
            lblMsg.Text = "燃油附加费只能为数字！";
            return;
        }
        decimal clientRemoteCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtRemoteCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtRemoteCosts.ID].Trim(), out clientRemoteCosts))
        {
            lblMsg.Text = "偏远地区附加费只能为数字！";
            return;
        }
        decimal clientFetchCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtFetchCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtFetchCosts.ID].Trim(), out clientFetchCosts))
        {
            lblMsg.Text = "取件费只能为数字！";
            return;
        }
        decimal materialCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtMaterialCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtMaterialCosts.ID].Trim(), out materialCosts))
        {
            lblMsg.Text = "材料费只能为数字！";
            return;
        }
        decimal clientOtherCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtOtherCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtOtherCosts.ID].Trim(), out clientOtherCosts))
        {
            lblMsg.Text = "其它费用只能为数字！";
            return;
        }

        string clientOtherCostsNote = Request.Form[txtOtherCostsNote.ID].Trim();
        if (clientOtherCosts > 0)
        {
            if (string.IsNullOrEmpty(clientOtherCostsNote) || Validator.IsMatchLessThanChineseCharacter(clientOtherCostsNote, NOTE_ADDRESS_LENGTH))
            {
                lblMsg.Text = "其他费用说明不能为空，且不能超过" + NOTE_ADDRESS_LENGTH + "个字符！";
                return;
            }
        }
        decimal clientAddressChangeCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtAddressChangeCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtAddressChangeCosts.ID].Trim(), out clientAddressChangeCosts))
        {
            lblMsg.Text = "地址更改费只能为数字！";
            return;
        }
        decimal clientReturnCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtReturnCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtReturnCosts.ID].Trim(), out clientReturnCosts))
        {
            lblMsg.Text = "退件费只能为数字！";
            return;
        }
        decimal damageMoney = 0;
        if (Request.Form[txtDamageMoney.ID].Trim() != "-" && !decimal.TryParse(Request.Form[txtDamageMoney.ID].Trim(), out damageMoney))
        {
            lblMsg.Text = "损失与赔偿费用只能为数字！";
            return;
        }
        decimal returnMoney = 0;
        if (Request.Form[txtReturnMoney.ID].Trim() != "-" && !decimal.TryParse(Request.Form[txtReturnMoney.ID].Trim(), out returnMoney))
        {
            lblMsg.Text = "返利只能为数字！";
            return;
        }
        decimal clientTotalCosts = 0;
        if (!string.IsNullOrEmpty(Request.Form[txtTotalCosts.ID].Trim()) && !decimal.TryParse(Request.Form[txtTotalCosts.ID].Trim(), out clientTotalCosts))
        {
            lblMsg.Text = "应收费用不能为空，且只能为大于0的数字！";
            return;
        }
        if (clientTotalCosts <= 0)
        {
            lblMsg.Text = "应收费用不能为空，且只能为大于0的数字！";
            return;
        }
        string remark = Request.Form[txtRemark.ID].Trim();
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }

        string toUsername = Request.Form[txtToUsername.ID].Trim();
        if (!string.IsNullOrEmpty(toUsername) && Validator.IsMatchLessThanChineseCharacter(toUsername, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人姓名不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toPhone = Request.Form[txtToPhone.ID].Trim();
        if (!string.IsNullOrEmpty(toPhone) && Validator.IsMatchLessThanChineseCharacter(toPhone, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人电话不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toEmail = Request.Form[txtToEmail.ID].Trim();
        if (!string.IsNullOrEmpty(toEmail) && Validator.IsMatchLessThanChineseCharacter(toEmail, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人邮箱不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toCity = Request.Form[txtToCity.ID].Trim();
        if (!string.IsNullOrEmpty(toCity) && Validator.IsMatchLessThanChineseCharacter(toCity, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人城市不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toCountry = Request.Form[txtToCountry.ID].Trim();
        if (!string.IsNullOrEmpty(toCountry) && Validator.IsMatchLessThanChineseCharacter(toCountry, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人国家不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string toPostcode = Request.Form[txtToPostcode.ID].Trim();
        if (!string.IsNullOrEmpty(toPostcode) && Validator.IsMatchLessThanChineseCharacter(toPostcode, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "收件人邮编不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }
        string barCode = Request.Form[txtBarCode.ID].Trim();
        if (!string.IsNullOrEmpty(barCode) && Validator.IsMatchLessThanChineseCharacter(barCode, CONTACT_WAY_LENGTH))
        {
            lblMsg.Text = "跟踪条码不能超过" + CONTACT_WAY_LENGTH + "个字符！";
            return;
        }

        if (!string.IsNullOrEmpty(barCode) && barCode!=od.BarCode && OrderDetailOperation.GetOrderDetaiByBarCode(barCode))
        {
            lblMsg.Text = "此跟踪条码已存在！";
            return;
        }
        string toAddress = Request.Form[txtToAddress.ID].Trim();
        if (!string.IsNullOrEmpty(toAddress) && Validator.IsMatchLessThanChineseCharacter(toAddress, NOTE_ADDRESS_LENGTH))
        {
            lblMsg.Text = "收件人详址不能超过" + NOTE_ADDRESS_LENGTH + "个字符！";
            return;
        }

        decimal oldTotalCosts = od.TotalCosts;        
        od.AddressChangeCosts = clientAddressChangeCosts;
        od.BarCode = barCode;
        od.CarrierEncode = carrierEncode;
        od.Count = count;
        od.DamageMoney = damageMoney;
        od.DisposalCosts = clientDisposalCosts;
        od.FetchCosts = clientFetchCosts;
        od.InsureCosts = 0;
        od.KgPrice = 0;
        od.MaterialCosts = 0;
        od.OtherCosts = clientOtherCosts;
        od.OtherCostsNote = clientOtherCostsNote;
        od.PostCosts = clientPostCosts;
        od.RegisterCosts = clientRegisterCosts;
        od.RemoteCosts = clientRemoteCosts;
        od.ReturnCosts = clientReturnCosts;
        od.FuelCosts = clientFuelCosts;
        od.ReturnMoney = returnMoney;
        od.ToCountry = countryName;
        od.TotalCosts = clientTotalCosts;
        od.Type = byte.Parse(slGoodsType.Value);
        od.Weight = weight;
        od.Remark = remark;
        od.ToAddress = toAddress;
        od.ToCity = toCity;
        od.ToEmail = toEmail;
        od.ToPhone = toPhone;
        od.ToPostcode = toPostcode;
        od.ToUsername = toUsername;

        decimal oldSelfTotalCosts = od.SelfTotalCosts;
        CarrierCharge cc = ChargeStandardOperation.GetSelfCarrierChargeByParameter(country.Id, weight, byte.Parse(slGoodsType.Value), count, carrier.Id, order.Client.Id);
        
        od.SelfPostCosts = cc.SelfPostCost;
        od.SelfTotalCosts = cc.SelfTotalCost;

        OrderDetailOperation.UpdateOrderDetail(od);
        order.Costs = order.Costs - oldTotalCosts + clientTotalCosts;
        order.SelfCosts = order.SelfCosts - oldSelfTotalCosts + od.SelfTotalCosts;
        OrderOperation.UpdateOrder(order);
        Response.Write("<script language='javascript'>alert('修改成功！');location.href='AuditOrder.aspx?id=" + order.Id + "';</script>");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        OrderDetailOperation.DeleteOrderDetailById(od.Id);
        Response.Write("<script language='javascript' type='text/javascript'>location.href='AuditOrder.aspx?id=" + order.Id + "';</script>");
    }

    private void FormDataBind()
    {
        lblYDEncode.Text = od.Encode;
        hdClientId.Value = order.Client.Id.ToString();
        hdCountry.Value = od.ToCountry;
        hdCountryBak.Value = od.ToCountry;
        hdCarrierEncode.Value = od.CarrierEncode;
        txtCountry.Value = od.ToCountry;
        txtAddressChangeCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.AddressChangeCosts.ToString());
        txtBarCode.Value = od.BarCode;
        if (od.CarrierEncode != null)
        {
            txtCarrier.Value = CarrierOperation.GetCarrierByEncode(od.CarrierEncode).Name;
        }
        if (od.PostCosts <= 0)
        {
            txtCount.Value = od.ClientCount.ToString();
            txtWeight.Value = Backend.Utilities.StringHelper.CurtNumber(od.ClientWeight.ToString());
        }
        else
        {
            txtCount.Value = od.Count.ToString();
            txtWeight.Value = Backend.Utilities.StringHelper.CurtNumber(od.Weight.ToString());
        }
        txtFuelCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.FuelCosts.ToString());
        txtDamageMoney.Value = Backend.Utilities.StringHelper.CurtNumber(od.DamageMoney.ToString());
        txtDisposalCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.DisposalCosts.ToString());
        txtFetchCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.FetchCosts.ToString());
        txtInsureCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.InsureCosts.ToString());
        //txtKgPrice.Value = od.KgPrice.ToString();
        txtMaterialCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.MaterialCosts.ToString());
        txtOtherCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.OtherCosts.ToString());
        txtOtherCostsNote.Value = od.OtherCostsNote;
        txtPostCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.PostCosts.ToString());
        txtRegisterCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.RegisterCosts.ToString());
        txtRemark.Text = od.Remark;
        txtRemoteCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.RemoteCosts.ToString());
        txtReturnCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.ReturnCosts.ToString());
        txtReturnMoney.Value = Backend.Utilities.StringHelper.CurtNumber(od.ReturnMoney.ToString());
        txtToAddress.Value = od.ToAddress;
        txtToCity.Value = od.ToCity;
        txtToCountry.Value = od.ToCountry;
        txtToEmail.Value = od.ToEmail;
        txtToPhone.Value = od.ToPhone;
        txtToPostcode.Value = od.ToPostcode;
        txtTotalCosts.Value = Backend.Utilities.StringHelper.CurtNumber(od.TotalCosts.ToString());
        txtToUsername.Value = od.ToUsername;       
        slGoodsType.Value = od.Type.ToString();
    }
}
