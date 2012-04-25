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
using System.Collections.Generic;

public partial class Admin_Client_LiabilityOrder : System.Web.UI.Page
{
    private Liability ly = null;
    private static readonly int NORMAL_LENGTH = 50;
    private static readonly int FILL_USER_LENGTH = 10;
    private static readonly int DETAIL_LENGTH = 2000;
    private static readonly int RESULT_LENGTH = 1000;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if(int.TryParse(Request.QueryString["id"], out id))
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
        txtJlDepartment.Text = ly.JlDepartment;
        txtJlDtMoney.Text = StringHelper.CurtNumber(ly.JlDtMoney.ToString());
        txtJlUser.Text = ly.JlUser;
        txtJlUrMoney.Text= StringHelper.CurtNumber(ly.JlUrMoney.ToString());        
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
        ddlCorrectStatus.SelectedValue = ly.CorrectStatus ? "True" : "False";
        ddlCurrencyType.SelectedValue = ly.CurrencyType;
        ddlEventType.SelectedValue =Convert.ToByte(ly.EventType).ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string orderEncode = Request.Form[txtOrderEncode.ID].Trim();
        if (orderEncode != ly.Order.Encode)
        {
            if (string.IsNullOrEmpty(orderEncode) || Validator.IsMatchLessThanChineseCharacter(orderEncode, NORMAL_LENGTH))
            {
                lblMsg.Text = "订单号不能为空，且长度不能超过" + NORMAL_LENGTH + "个字符！";
                return;
            }
            Order order = OrderOperation.GetOrderByEncode(orderEncode);
            if (order == null)
            {
                lblMsg.Text = "此订单号不存在！";
                return;
            }
            ly.Order = order;
            ly.ClientName = order.Client.RealName;
        }
        string barCode = Request.Form[txtBarCode.ID].Trim();
        if (!string.IsNullOrEmpty(barCode))
        {
            if (Validator.IsMatchLessThanChineseCharacter(barCode, NORMAL_LENGTH))
            {
                lblMsg.Text = "跟踪号码长度不能超过"+NORMAL_LENGTH+"个字符！";
                return;
            }
            bool isExist = false;
            string carrierName="";
            List<OrderDetail> result = OrderDetailOperation.GetOrderDetailByOrderId(ly.Order.Id);
            foreach (OrderDetail od in result)
            {                
                if (barCode == od.BarCode)
                {
                    isExist = true;
                    carrierName=CarrierOperation.GetCarrierByEncode(od.CarrierEncode).Name;
                }
            }
            if (isExist)
            {
                ly.BarCode = barCode;
                ly.CarrierName = carrierName;
            }
            else
            {
                lblMsg.Text = "此跟踪单号不存在！";
                return;
            }
        }
        ly.BarCode = barCode;

        ly.EventType = EnumConvertor.ConvertToLiabilityEventType(byte.Parse(ddlEventType.SelectedItem.Value));
        ly.CorrectStatus = bool.Parse(ddlCorrectStatus.SelectedItem.Value);
        ly.CurrencyType = ddlCurrencyType.SelectedItem.Value;

        string fillUser = Request.Form[txtFillUser.ID].Trim();
        if (string.IsNullOrEmpty(fillUser) || Validator.IsMatchLessThanChineseCharacter(fillUser, FILL_USER_LENGTH))
        {
            lblMsg.Text = "填表人不能为空，且长度不能超过" + FILL_USER_LENGTH + "个字符！";
        }
        ly.FillUser = fillUser;

        string strFillTime = Request.Form[txtFillTime.ID].Trim();
        DateTime fillTime = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(strFillTime) || !DateTime.TryParse(strFillTime, out fillTime))
        {
            lblMsg.Text = "填表时间不能为空，且只能为时间格式！";
            return;
        }
        ly.FillTime = fillTime;

        string detail = Request.Form[txtDetail.ID].Trim();
        if (string.IsNullOrEmpty(detail) || Validator.IsMatchLessThanChineseCharacter(detail, DETAIL_LENGTH))
        {
            lblMsg.Text = "事情经过不能为空，且长度不能超过" + DETAIL_LENGTH + "个字符！";
            return;
        }
        ly.Detail = detail;

        string disposalResult = Request.Form[txtResult.ID].Trim();
        if (!string.IsNullOrEmpty(disposalResult) && Validator.IsMatchLessThanChineseCharacter(disposalResult, RESULT_LENGTH))
        {
            lblMsg.Text = "处理结果长度不能超过" + RESULT_LENGTH + "个字符！";
            return;
        }
        ly.Result = disposalResult;

        string strTotalMoney = Request.Form[txtTotalMoney.ID].Trim();
        decimal totalMoney = 0;
        if (!string.IsNullOrEmpty(strTotalMoney) && !decimal.TryParse(strTotalMoney, out totalMoney))
        {
            lblMsg.Text = "责任总金额只能为不小于0的数字！";
            return;
        }
        if (totalMoney < 0)
        {
            lblMsg.Text = "责任总金额只能为不小于0的数字！";
            return;
        }
        ly.TotalMoney = totalMoney;

        string zrDepartment = Request.Form[txtZrDepartment.ID].Trim();
        if (!string.IsNullOrEmpty(zrDepartment) && Validator.IsMatchLessThanChineseCharacter(zrDepartment, NORMAL_LENGTH))
        {
            lblMsg.Text = "责任部门名称长度不能超过"+NORMAL_LENGTH+"个字符！";
            return;
        }
        ly.ZrDepartment = zrDepartment;

        string strZrDtMoney = Request.Form[txtZrDtMoney.ID].Trim();
        decimal zrDtMoney = 0;
        if (!string.IsNullOrEmpty(strZrDtMoney) && !decimal.TryParse(strZrDtMoney, out zrDtMoney))
        {
            lblMsg.Text = "责任部门承担金额只能为不小于0的数字！";
            return;
        }
        if (zrDtMoney < 0)
        {
            lblMsg.Text = "责任部门承担金额只能为不小于0的数字！";
            return;
        }
        ly.ZrDtMoney = zrDtMoney;

        string zrUser = Request.Form[txtZrUser.ID].Trim();
        if (!string.IsNullOrEmpty(zrUser) && Validator.IsMatchLessThanChineseCharacter(zrUser, NORMAL_LENGTH))
        {
            lblMsg.Text = "责任人姓名长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        ly.ZrUser = zrUser;

        string strZrUrMoney = Request.Form[txtZrUrMoney.ID].Trim();
        decimal zrUrMoney = 0;
        if (!string.IsNullOrEmpty(strZrUrMoney) && !decimal.TryParse(strZrUrMoney, out zrUrMoney))
        {
            lblMsg.Text = "责任人承担金额只能为不小于0的数字！";
            return;
        }
        if (zrUrMoney < 0)
        {
            lblMsg.Text = "责任人承担金额只能为不小于0的数字！";
            return;
        }
        ly.ZrUrMoney = zrUrMoney;

        string strClientPtEadu = Request.Form[txtClientPtEadu.ID].Trim();
        decimal clientPtEadu = 0;
        if (!string.IsNullOrEmpty(strClientPtEadu) && !decimal.TryParse(strClientPtEadu, out clientPtEadu))
        {
            lblMsg.Text = "客户付给亿度金额只能为不小于0的数字！";
            return;
        }
        if (clientPtEadu < 0)
        {
            lblMsg.Text = "客户付给亿度金额只能为不小于0的数字！";
            return;
        }
        ly.ClientPtEadu = clientPtEadu;

        string strEaduPtClient = Request.Form[txtEaduPtClient.ID].Trim();
        decimal eaduPtClient = 0;
        if (!string.IsNullOrEmpty(strEaduPtClient) && !decimal.TryParse(strEaduPtClient, out eaduPtClient))
        {
            lblMsg.Text = "亿度付给客户金额只能为不小于0的数字！";
            return;
        }
        if (eaduPtClient < 0)
        {
            lblMsg.Text = "亿度付给客户金额只能为不小于0的数字！";
            return;
        }
        ly.EaduPtClient = eaduPtClient;

        string newCarrierName = Request.Form[txtCarrier.ID].Trim();
        if (!string.IsNullOrEmpty(newCarrierName) && Validator.IsMatchLessThanChineseCharacter(newCarrierName, NORMAL_LENGTH))
        {
            lblMsg.Text = "承运商名称长度不能超过"+NORMAL_LENGTH+"个字符！";
            return;
        }
        if (string.IsNullOrEmpty(ly.CarrierName))
        {
            ly.CarrierName = newCarrierName;
        }

        string strCarrierPtEadu = Request.Form[txtCarrierPtEadu.ID].Trim();
        decimal carrierPtEadu = 0;
        if (!string.IsNullOrEmpty(strCarrierPtEadu) && !decimal.TryParse(strCarrierPtEadu, out zrUrMoney))
        {
            lblMsg.Text = "承运商付给亿度金额只能为不小于0的数字！";
            return;
        }
        if (carrierPtEadu < 0)
        {
            lblMsg.Text = "承运商付给亿度金额只能为不小于0的数字！";
            return;
        }
        ly.CarrierPtEadu = carrierPtEadu;

        string strEaduPtCarrier = Request.Form[txtEaduPtCarrier.ID].Trim();
        decimal eaduPtCarrier = 0;
        if (!string.IsNullOrEmpty(strEaduPtCarrier) && !decimal.TryParse(strEaduPtCarrier, out eaduPtCarrier))
        {
            lblMsg.Text = "亿度付给承运商金额只能为不小于0的数字！";
            return;
        }
        if (eaduPtCarrier < 0)
        {
            lblMsg.Text = "亿度付给承运商金额只能为不小于0的数字！";
            return;
        }
        ly.EaduPtCarrier = eaduPtCarrier;

        string jlDepartment = Request.Form[txtJlDepartment.ID].Trim();
        if (!string.IsNullOrEmpty(jlDepartment) && Validator.IsMatchLessThanChineseCharacter(jlDepartment, NORMAL_LENGTH))
        {
            lblMsg.Text = "奖励部门名称长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        ly.JlDepartment = jlDepartment;

        string strJlDtMoney = Request.Form[txtJlDtMoney.ID].Trim();
        decimal jlDtMoney = 0;
        if (!string.IsNullOrEmpty(strJlDtMoney) && !decimal.TryParse(strJlDtMoney, out jlDtMoney))
        {
            lblMsg.Text = "奖励部门金额只能为不小于0的数字！";
            return;
        }
        if (jlDtMoney < 0)
        {
            lblMsg.Text = "奖励部门金额只能为不小于0的数字！";
            return;
        }
        ly.JlDtMoney = jlDtMoney;

        string jlUser = Request.Form[txtJlUser.ID].Trim();
        if (!string.IsNullOrEmpty(jlUser) && Validator.IsMatchLessThanChineseCharacter(jlUser, NORMAL_LENGTH))
        {
            lblMsg.Text = "奖励人姓名长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        ly.JlUser = jlUser;

        string strJlUrMoney = Request.Form[txtJlUrMoney.ID].Trim();
        decimal jlUrMoney = 0;
        if (!string.IsNullOrEmpty(strJlUrMoney) && !decimal.TryParse(strJlUrMoney, out jlUrMoney))
        {
            lblMsg.Text = "奖励人金额只能为不小于0的数字！";
            return;
        }
        if (jlUrMoney < 0)
        {
            lblMsg.Text = "奖励人金额只能为不小于0的数字！";
            return;
        }
        ly.JlUrMoney = jlUrMoney;

        string liabilityUser = Request.Form[txtLiabilityUser.ID].Trim();
        if (!string.IsNullOrEmpty(liabilityUser) && Validator.IsMatchLessThanChineseCharacter(liabilityUser, NORMAL_LENGTH))
        {
            lblMsg.Text = "责任人姓名长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        ly.LiabilityUser = liabilityUser;

        string correctUser = Request.Form[txtCorrectUser.ID].Trim();
        if (!string.IsNullOrEmpty(correctUser) && Validator.IsMatchLessThanChineseCharacter(correctUser, NORMAL_LENGTH))
        {
            lblMsg.Text = "更正人员姓名长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        ly.CorrectUser = correctUser;

        string financeUser = Request.Form[txtFinanceUser.ID].Trim();
        if (!string.IsNullOrEmpty(financeUser) && Validator.IsMatchLessThanChineseCharacter(financeUser, NORMAL_LENGTH))
        {
            lblMsg.Text = "财务人员姓名长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        ly.FinanceUser = financeUser;

        string cashierUser = Request.Form[txtCashierUser.ID].Trim();
        if (!string.IsNullOrEmpty(cashierUser) && Validator.IsMatchLessThanChineseCharacter(cashierUser, NORMAL_LENGTH))
        {
            lblMsg.Text = "出纳人员姓名长度不能超过" + NORMAL_LENGTH + "个字符！";
            return;
        }
        ly.CashierUser = cashierUser;

        LiabilityOperation.UpdateLiability(ly);
        lblMsg.Text = "修改成功！";                
    }
}
