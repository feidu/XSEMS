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

public partial class Admin_Order_DetainOrder : System.Web.UI.Page
{
    protected int id = 0;
    Order order = null;
    protected List<OrderDetail> result = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
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
        lblReason.Text = order.Reason;
    }

    protected void btnAuditThrough_Click(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);

        order.Status = OrderStatus.WAIT_CHECK;
        order.AuditTime = DateTime.Now;
        order.AuditUserId = user.Id;
        order.Reason = "";
        Client client = order.Client;
        client.Balance = client.Balance - order.Costs;
        ClientOperation.UpdateClientBalance(client);
        OrderOperation.UpdateOrderStatus(order);
        OrderOperation.UpdateOrderAuditInfo(order);
        OrderOperation.UpdateOrderReason(order);
        Response.Write("<script language='javascript' type='text/javascript'>alert('操作成功！');location.href='CheckOrderList.aspx';</script>");
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        order.Status = OrderStatus.WAIT_AUDIT;
        OrderOperation.UpdateOrderStatus(order);
        order.Reason = "";
        OrderOperation.UpdateOrderReason(order);
        Response.Write("<script language='javascript' type='text/javascript'>alert('操作成功！');location.href='AuditOrderList.aspx';</script>");
    }
}
