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
using System.Collections.Generic;

public partial class Admin_Order_CreateOrderQuick : System.Web.UI.Page
{
    private static readonly int NORMAL_LENGTH = 50;

    protected string companyId = "0";
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        companyId = user.CompanyId.ToString();

        if (!IsPostBack)
        {
            DdlCarrierDataBind();
            txtCreateDate.Value = DateTime.Now.ToShortDateString();
        }
    }

    private void DdlCarrierDataBind()
    {
        List<Carrier> result = CarrierOperation.GetCarrier();
        ddlCarrier.DataSource = result;
        ddlCarrier.DataTextField = "Name";
        ddlCarrier.DataValueField = "Encode";
        ddlCarrier.DataBind();
        ddlCarrier.SelectedValue = "CNAM";
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string clientName = Request.Form[txtClientName.ID].Trim();
        string countryName = Request.Form[txtToCountry.ID].Trim();
        string barCode = Request.Form[txtBarCode.ID].Trim();
        string remark = Request.Form[txtRemark.ID].Trim();

        if (string.IsNullOrEmpty(clientName) || Validator.IsMatchLessThanChineseCharacter(clientName, NORMAL_LENGTH))
        {
            lblMsg.Text = "客户姓名不能为空，且长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        Client client = ClientOperation.GetClientByRealName(clientName);
        if (client == null)
        {
            lblMsg.Text = "客户不存在！";
            return;
        }

        DateTime createDate = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(Request.Form[txtCreateDate.ID].Trim()) || !DateTime.TryParse(Request.Form[txtCreateDate.ID].Trim(), out createDate))
        {
            lblMsg.Text = "发货日期不能为空，且只能为时间格式！";
            return;
        }

        decimal weight = 0;
        if (string.IsNullOrEmpty(Request.Form[txtWeight.ID].Trim()) || !decimal.TryParse(Request.Form[txtWeight.ID].Trim(), out weight))
        {
            lblMsg.Text = "计费重量不能为空，且只能为数字！";
            return;
        }
        if (weight <= 0)
        {
            lblMsg.Text = "计费重量只能为大于0的数字！";
            return;
        }
        weight = weight / 1000;
        if (string.IsNullOrEmpty(countryName) || Validator.IsMatchLessThanChineseCharacter(countryName, NORMAL_LENGTH))
        {
            lblMsg.Text = "国家不能为空，且长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        Country country = CountryOperation.GetCountryByEnglishName(countryName);
        if (country == null)
        {
            lblMsg.Text = "国家名称不存在！";
            return;
        }

        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, NORMAL_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }

        if (string.IsNullOrEmpty(barCode) || Validator.IsMatchLessThanChineseCharacter(barCode, NORMAL_LENGTH))
        {
            lblMsg.Text = "挂号条码不能为空，且长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }

        if (!string.IsNullOrEmpty(barCode) && OrderDetailOperation.GetOrderDetaiByBarCode(barCode))
        {
            lblMsg.Text = "此挂号条码已存在！";
            return;
        }

        Carrier carrier = CarrierOperation.GetCarrierByEncode(ddlCarrier.SelectedItem.Value);
        CarrierCharge clientCarrierCharge = ChargeStandardOperation.GetClientCarrierChargeByParameter(country.Id, weight, 1, 1, carrier.Id, client.Id);
        CarrierCharge selfCarrierCharge = ChargeStandardOperation.GetSelfCarrierChargeByParameter(country.Id, weight, 1, 1, carrier.Id, client.Id);
        if (clientCarrierCharge == null || selfCarrierCharge ==null)
        {
            lblMsg.Text = "承运商不抵达此国家或重量超过承运商限定范围！";
            return;
        }

        Order order = null;
        order = OrderOperation.GetTodayClientOrderByParameters(client.Id, createDate);
        if (order == null)
        {
            order = new Order();
            string encode = StringHelper.GetEncodeNumber("SJ");
            order.Client = client;
            order.CompanyId = user.CompanyId;
            order.CompanyName = CompanyOperation.GetCompanyById(client.CompanyId).Name;
            order.Encode = encode;
            if (client.UserId != 0)
            {
                order.UserId = client.UserId;
            }
            else
            {
                order.UserId = user.Id;
            }
            order.CreateUser = user;
            order.ReceiveUserId = user.Id;
            order.Status = OrderStatus.WAIT_SUBMIT;
            order.Type = OrderType.COMPANY_ORDER;
            order.CalculateType = 1;
            order.ReceiveType = "上门收件";
            order.CreateTime = new DateTime(createDate.Year, createDate.Month, createDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            order.Costs = 0;
            order.ReceiveDate = new DateTime(createDate.Year, createDate.Month, createDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            order.Remark = "";
            order.ToPostcode = "";
            order.ToAddress = "";
            order.ToCity = "";
            order.ToCountry = "";
            order.ToEmail = "";
            order.ToPhone = "";
            order.ToUsername = "";
            order.IsQuickOrder = true;

            OrderOperation.CreateOrder(order);
            order = OrderOperation.GetOrderByEncode(encode);
        }

        

        OrderDetail od = new OrderDetail();
        od.AddressChangeCosts = 0;
        od.BarCode = barCode;
        od.CarrierEncode = ddlCarrier.SelectedItem.Value;
        od.Count = 1;
        od.CreateTime = DateTime.Now;
        od.DamageMoney = 0;
        od.DisposalCosts = clientCarrierCharge.ChargeStandard.ClientDisposalCost;
        od.FetchCosts = 0;
        od.InsureCosts = 0;
        od.KgPrice = 0;
        od.MaterialCosts = 0;
        od.OrderId = order.Id;
        od.OtherCosts = 0;
        od.OtherCostsNote = "";
        od.PostCosts = clientCarrierCharge.ClientPostCost;
        od.RegisterCosts = clientCarrierCharge.ChargeStandard.ClientRegisterCost;
        od.RemoteCosts = 0;
        od.ReturnCosts = 0;
        od.ReturnMoney = 0;
        od.ToCountry = countryName;
        od.TotalCosts = clientCarrierCharge.ClientTotalCost;
        od.Encode = StringHelper.GetEncodeNumber("YD"); ;
        od.Type = 1;
        od.UserId = user.Id;
        od.Weight = weight;
        od.Remark = remark;
        od.ToAddress = "";
        od.ToCity = "";
        od.ToEmail = "";
        od.ToPhone = "";
        od.ToPostcode = "";
        od.ToUsername = "";
        od.FuelCosts = od.PostCosts * carrier.FuelSgRate;
        od.SelfPostCosts = selfCarrierCharge.SelfPostCost;
        od.SelfTotalCosts = selfCarrierCharge.SelfTotalCost;

        OrderDetailOperation.CreateOrderDetail(od);
        order.Costs += clientCarrierCharge.ClientTotalCost;
        order.SelfCosts += selfCarrierCharge.SelfTotalCost;
        OrderOperation.UpdateOrder(order);
        lblMsg.Text = "添加成功！";

        txtBarCode.Text = "";
        txtRemark.Text = "";
        txtWeight.Text = "";
    }
}

