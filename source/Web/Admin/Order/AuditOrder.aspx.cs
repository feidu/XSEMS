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
using Backend.Authorization;
using System.Text;

public partial class Admin_Order_AuditOrder : System.Web.UI.Page
{
    protected int id = 0;
    Order order = null;
    User user = null;
    Company company = null;
    protected List<OrderDetail> result = null;
    private static readonly int REASON_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
            user = UserOperation.GetUserByUsername(cookie.Username);
            company = CompanyOperation.GetCompanyById(user.CompanyId);
            order = OrderOperation.GetOrderById(id);
            result = OrderDetailOperation.GetOrderDetailByOrderId(id);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }

    private void FormDataBind()
    {
        lblRemark.Text = order.Remark;
        lblCosts.Text = order.Costs.ToString();
        lblClientName.Text = order.Client.RealName;
        //lblCreateUser.Text = order.CreateUser.RealName;
        lblEncode.Text = order.Encode;
        lblCreateTime.Text = order.CreateTime.ToString();
        lblReceiveType.Text = order.ReceiveType;
        //lblReceiveUser.Text = UserOperation.GetUserById(order.ReceiveUserId).RealName;
        lblCalculateType.Text = CalculateTypeOperation.GetCalculateTypeById(order.CalculateType).Name;
        lblReceiveDate.Text = order.ReceiveDate.ToShortDateString();
        lblType.Text = EnumConvertor.OrderTypeConvertToString((byte)order.Type);
        lblUserName.Text = UserOperation.GetUserById(order.UserId).RealName;

        if(order.Reason!=null && order.Reason.Length>0)
        {
            if (order.CheckUserId != 0 && order.CheckTime != DateTime.MinValue)
            {
                trCheckReason.Visible = true;
                lblCheckReason.Text = order.Reason;
            }
        }        
    }

    protected void btnAuditThrough_Click(object sender, EventArgs e)
    {
        btnAuditThrough.Attributes.Add("onclick", "this.disabled=true;");
        Client client = order.Client;
        decimal oldClientBalance = client.Balance;
        decimal clientMoney = client.Balance + client.Credit;
        if (clientMoney < order.Costs)
        {
            lblMsg.Text = "该客户余额不足，不能审核通过！";
            return;
        }
        
        order.Status = OrderStatus.WAIT_CHECK;
        order.AuditTime = DateTime.Now;
        order.AuditUserId = user.Id;
        order.Reason = "";
                
        client.Balance = client.Balance - order.Costs;
        ClientOperation.UpdateClientBalance(client);
        OrderOperation.UpdateOrderStatus(order);
        OrderOperation.UpdateOrderAuditInfo(order);
        OrderOperation.UpdateOrderReason(order);

        if (client.Balance >= 0)
        {
            ShouldReceive sr = new ShouldReceive();
            sr.Remark = "";
            sr.Money = order.Costs;
            sr.ReceiveTime = DateTime.Now;
            sr.Type = "订单已收";
            sr.UserId = user.Id;
            sr.ClientId = order.Client.Id;
            sr.CompanyId = user.CompanyId;
            sr.CreateTime = DateTime.Now;
            sr.ReceiveTime = order.ReceiveDate;
            sr.Order = order;
            sr.Status = true;
            sr.Encode = StringHelper.GetEncodeNumber("SK");
            ShouldReceiveOperation.CreateOrderShouldReceive(sr);
        }
        else
        {
            ShouldReceive sr = new ShouldReceive();
            sr.Remark = "";
            if (oldClientBalance <= 0)
            {
                sr.Money = order.Costs;
            }
            else
            {
                sr.Money = order.Costs - oldClientBalance;

                ShouldReceive sred = new ShouldReceive();
                sred.Remark = "";
                sred.Money = oldClientBalance;
                sred.ReceiveTime = DateTime.Now;
                sred.Type = "订单已收";
                sred.UserId = user.Id;
                sred.ClientId = order.Client.Id;
                sred.CompanyId = user.CompanyId;
                sred.CreateTime = DateTime.Now;
                sred.ReceiveTime = order.ReceiveDate;
                sred.Order = order;
                sred.Status = true;
                sred.Encode = StringHelper.GetEncodeNumber("SK");
                ShouldReceiveOperation.CreateOrderShouldReceive(sred);
            }
            sr.ReceiveTime = DateTime.Now;
            sr.Type = "订单应收";
            sr.UserId = user.Id;
            sr.ClientId = order.Client.Id;
            sr.CompanyId = user.CompanyId;
            sr.CreateTime = DateTime.Now;
            sr.ReceiveTime = order.ReceiveDate;
            sr.Order = order;
            sr.Status = false;
            sr.Encode = StringHelper.GetEncodeNumber("YS");
            ShouldReceiveOperation.CreateOrderShouldReceive(sr);
        }

        decimal arrearageMoney = 0;
        
        string msg = "操作成功！";
        if (client.Balance < 0)
        {
            if (oldClientBalance <= 0)
            {
                arrearageMoney = order.Costs;
            }
            else
            {
                arrearageMoney = order.Costs - oldClientBalance;
            }
            EmailHelper.SendMailForArrearage(company, client, arrearageMoney, out msg);
        }

        Response.Write("<script language='javascript' type='text/javascript'>alert('" + msg + "');location.href='AuditOrderList.aspx';</script>");
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        string reason = Request.Form[txtReason.ID].Trim();
        if (string.IsNullOrEmpty(reason) || Validator.IsMatchLessThanChineseCharacter(reason, REASON_LENGTH))
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('退回原因不能为空，且长度不能超过500个字符！');</script>");
            return;
        }
        order.Reason = reason;
        order.AuditTime = DateTime.Now;
        order.AuditUserId = user.Id;

        order.Status = OrderStatus.WAIT_SUBMIT;
        OrderOperation.UpdateOrderStatus(order);
        OrderOperation.UpdateOrderReason(order);
               
        Response.Write("<script language='javascript' type='text/javascript'>alert('操作成功！');location.href='Default.aspx';</script>");
    }

    protected void btnDetain_Click(object sender, EventArgs e)
    {
        string reason = Request.Form[txtReason.ID].Trim();
        if (string.IsNullOrEmpty(reason) || Validator.IsMatchLessThanChineseCharacter(reason, REASON_LENGTH))
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('扣货原因不能为空，且长度不能超过500个字符！');</script>");
            return;
        }
                
        order.Status = OrderStatus.DETAINED;

        order.Reason = reason;
        order.AuditTime = DateTime.Now;
        order.AuditUserId = user.Id;

        OrderOperation.UpdateOrderStatus(order);
        OrderOperation.UpdateOrderAuditInfo(order);
        OrderOperation.UpdateOrderReason(order);
                
        Response.Write("<script language='javascript' type='text/javascript'>alert('操作成功！');location.href='DetainOrderList.aspx';</script>");
    }
}
