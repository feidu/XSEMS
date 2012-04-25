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

public partial class Admin_Order_CreateOrderDetail : System.Web.UI.Page
{
    protected int id = 0;
    Order order = null;
    private static readonly int NOTE_ADDRESS_LENGTH = 200;
    private static readonly int CONTACT_WAY_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            order = OrderOperation.GetOrderById(id);
            hdClientId.Value = order.Client.Id.ToString();
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
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

        if (!string.IsNullOrEmpty(barCode) && OrderDetailOperation.GetOrderDetaiByBarCode(barCode))
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


        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        string encode = StringHelper.GetEncodeNumber("YD");
        
        OrderDetail od = new OrderDetail();
        od.AddressChangeCosts = clientAddressChangeCosts;
        od.BarCode = barCode;
        od.CarrierEncode = carrierEncode;
        od.Count = count;
        od.CreateTime = DateTime.Now;
        od.DamageMoney = damageMoney;
        od.DisposalCosts = clientDisposalCosts;        
        od.FetchCosts = clientFetchCosts;
        od.InsureCosts = 0;
        od.KgPrice = 0;
        od.MaterialCosts = 0;
        od.OrderId = order.Id;
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
        od.Encode = encode;
        od.Type = byte.Parse(slGoodsType.Value);
        od.UserId = user.Id;
        od.Weight = weight;
        od.Remark = remark;
        od.ToAddress = toAddress;
        od.ToCity = toCity;
        od.ToEmail = toEmail;
        od.ToPhone = toPhone;
        od.ToPostcode = toPostcode;
        od.ToUsername = toUsername;

        CarrierCharge cc = ChargeStandardOperation.GetSelfCarrierChargeByParameter(country.Id, weight, byte.Parse(slGoodsType.Value), count, carrier.Id, order.Client.Id);
        od.SelfPostCosts = cc.SelfPostCost;
        od.SelfTotalCosts = cc.SelfTotalCost;
        
        OrderDetailOperation.CreateOrderDetail(od);
        order.Costs += clientTotalCosts;
        order.SelfCosts += od.SelfTotalCosts;
        OrderOperation.UpdateOrder(order);
        Response.Write("<script language='javascript'>alert('添加成功！');location.href='ReceiveOrder.aspx?id=" + id + "';</script>");
    }
}
