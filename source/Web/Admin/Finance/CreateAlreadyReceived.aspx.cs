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
using Backend.Utilities;
using Backend.Models;
using Backend.BAL;
using Backend.Authorization;
using System.Collections.Generic;

public partial class Admin_Finance_CreateAlreadyReceived : System.Web.UI.Page
{
    private static readonly int CLIENT_NAME_LENGTH = 50;
    private static readonly int INVOICE_NUMBER_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;
    private static readonly int ACCOUNT_LENGTH = 50;
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        if (!IsPostBack)
        {
            if (ReceivableAccountOperation.GetReceivableAccount().Count > 0)
            {
                ddlReceiveAccount.DataSource = ReceivableAccountOperation.GetReceivableAccount();
                ddlReceiveAccount.DataTextField = "AccountNumber";
                ddlReceiveAccount.DataValueField = "Id";
                ddlReceiveAccount.DataBind();
            }
            else
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('请先添加收款账号！');history.go(-1);</script>");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string clientName = Request.Form[txtClientName.ID].Trim();
        string invoice = Request.Form[txtInvoice.ID].Trim();
        string remark = Request.Form[txtRemark.ID].Trim();
        string strReceivedTime = Request.Form[txtReceivedTime.ID].Trim();
        DateTime receivedTime = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(strReceivedTime) || !DateTime.TryParse(strReceivedTime, out receivedTime))
        {
            lblMsg.Text = "收款时间不能为空，且只能为时间格式！";
            return;
        }
        if (string.IsNullOrEmpty(invoice) || Validator.IsMatchLessThanChineseCharacter(invoice, INVOICE_NUMBER_LENGTH))
        {
            lblMsg.Text = "发票号码不能为空，且长度不能超过" + INVOICE_NUMBER_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(clientName) || clientName == "请输入客户姓名拼音的首字母" || Validator.IsMatchLessThanChineseCharacter(clientName, CLIENT_NAME_LENGTH))
        {
            lblMsg.Text = "客户姓名不能为空，且长度不能超过" + CLIENT_NAME_LENGTH + "个字符！";
            return;
        }
        Client client = ClientOperation.GetClientByRealName(clientName);
        if (client == null)
        {
            lblMsg.Text = "客户不存在！";
            return;
        }
        
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }

        decimal paid = 0;
        decimal exchangeRate = 1;
        decimal money = 0;
        if (ddlCurrencyType.SelectedItem.Value == "2")
        {
            if (!decimal.TryParse(Request.Form[txtClientPaid.ID].Trim(), out paid))
            {
                lblMsg.Text = "客户付款金额只能为数字！";
                return;
            }
            if (!decimal.TryParse(Request.Form[txtExchangeRate.ID].Trim(), out exchangeRate))
            {
                lblMsg.Text = "当前汇率只能为数字！";
                return;
            }
            string strActualReceived = Request.Form["txtActualReceived"];
            if (!decimal.TryParse(strActualReceived, out money))
            {
                return;
            }
        }
        else
        {
            if (!decimal.TryParse(Request.Form[txtReceivedMoney.ID], out money))
            {
                lblMsg.Text = "收款金额只能为数字！";
                return;
            }
        }
        if (money <= 0)
        {
            lblMsg.Text = "付款金额必须大于0！";
            return;
        }

        Recharge recharge = new Recharge();
        recharge.Account = ddlReceiveAccount.SelectedItem.Text;
        recharge.ClientId = client.Id;    
        recharge.CreateTime = DateTime.Now;
        recharge.UserId = user.Id;
        recharge.CurrencyType = EnumConvertor.ConvertToCurrencyType(byte.Parse(ddlCurrencyType.SelectedItem.Value));
        recharge.Encode = StringHelper.GetEncodeNumber("SK");
        recharge.Invoice = invoice;
        recharge.ExchangeRate = exchangeRate;
        recharge.Money = money;
        recharge.Paid = paid;
        recharge.ReceiveTime = receivedTime;
        recharge.Remark = remark;

        RechargeOperation.CreateRecharge(recharge);
        decimal balance = client.Balance + money;
        client.Balance = balance;
        ClientOperation.UpdateClientBalance(client);

        List<ShouldReceive> result = ShouldReceiveOperation.GetShouldReceiveByClientId(client.Id);
        if (result.Count > 0)
        {
            foreach (ShouldReceive sr in result)
            {
                if (sr.Money <= money)
                {
                    sr.Status = true;
                    sr.Type = "订单已收";
                    sr.ReceiveTime = DateTime.Now;
                    ShouldReceiveOperation.UpdateShouldReceive(sr);
                    ReceivedDeducted rd = new ReceivedDeducted();
                    rd.Money = sr.Money;
                    rd.Client = client;
                    rd.ArEncode = recharge.Encode;
                    rd.ArAccount = recharge.Account;
                    rd.ArUserId = recharge.UserId;
                    rd.SrEncode = sr.Encode;
                    rd.CreateTime = DateTime.Now;
                    rd.CompanyId = client.CompanyId;
                    ShouldReceiveOperation.CreateReceivedDeducted(rd);
                    money = money - sr.Money;
                }
                else if (money > 0)
                {
                    sr.Money = sr.Money - money;
                    ShouldReceiveOperation.UpdateShouldReceive(sr);
                    ReceivedDeducted rd = new ReceivedDeducted();
                    rd.Money = money;
                    rd.Client = client;
                    rd.ArEncode = recharge.Encode;
                    rd.ArAccount = recharge.Account;
                    rd.ArUserId = recharge.UserId;
                    rd.SrEncode = sr.Encode;
                    rd.CreateTime = DateTime.Now;
                    rd.CompanyId = client.CompanyId;
                    ShouldReceiveOperation.CreateReceivedDeducted(rd);

                    sr.Money = money;
                    sr.Status = true;
                    sr.Type = "订单已收";
                    sr.ReceiveTime = DateTime.Now;
                    ShouldReceiveOperation.CreateOrderShouldReceive(sr);
                    money = 0;
                    MailSend(client, recharge.Money);
                }
            }
        }
        MailSend(client, recharge.Money);
    }

    private void MailSend(Client client, decimal money)
    {
        string msg = "";
        EmailHelper.SendMailForReceiveMoney(client, money, out msg);
        Response.Write("<script language='javascript' type='text/javascript'>alert('" + msg + "');location.href='AlreadyReceived.aspx';</script>");

    }

    protected void ddlCurrencyType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCurrencyType.SelectedItem.Value == "2")
        {
            trUsdConversion.Visible = true;
            trReceivedMoney.Visible = false;
        }
        else
        {
            trUsdConversion.Visible = false;
            trReceivedMoney.Visible = true;
        }
    }
}
