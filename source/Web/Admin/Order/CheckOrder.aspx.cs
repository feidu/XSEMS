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

public partial class Admin_Order_CheckOrder : System.Web.UI.Page
{
    protected int id = 0;
    Order order = null;
    User user = null;
    protected List<OrderDetail> result = null;
    private static readonly int REASON_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
            user = UserOperation.GetUserByUsername(cookie.Username);

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
        //lblReceiveType.Text = order.ReceiveType;
        //lblReceiveUser.Text = UserOperation.GetUserById(order.ReceiveUserId).RealName;
        //lblCalculateType.Text = CalculateTypeOperation.GetCalculateTypeById(order.CalculateType).Name;
        //lblReceiveDate.Text = order.ReceiveDate.ToShortDateString();
        //lblType.Text = EnumConvertor.OrderTypeConvertToString((byte)order.Type);
        //lblUserName.Text = UserOperation.GetUserById(order.UserId).RealName;
        lblAuditUser.Text = UserOperation.GetUserById(order.AuditUserId).RealName;
        lblAuditTime.Text = order.AuditTime.ToString();
    }

    protected void btnCheckThrough_Click(object sender, EventArgs e)
    {
        order.Status = OrderStatus.FINISHED;
        order.Reason = "";
        Client client = order.Client;
        order.CheckUserId = user.Id;
        order.CheckTime = DateTime.Now;
        OrderOperation.UpdateOrderStatus(order);
        OrderOperation.UpdateOrderCheckInfo(order);
        OrderOperation.UpdateOrderReason(order);

        string encode = StringHelper.GetEncodeNumber("YF");
        foreach (OrderDetail od in result)
        {
            ShouldPay sp = new ShouldPay();
            sp.OrderEncode = order.Encode;
            sp.OrderDetail = od;
            sp.CreateTime = DateTime.Now;
            sp.Encode = encode;
            sp.UserId = user.Id;
            sp.CompanyId = user.CompanyId;
            Carrier carrier = new Carrier();
            carrier.Id = CarrierOperation.GetCarrierByEncode(od.CarrierEncode).Id;
            sp.Carrier = carrier;
            sp.Type = "营业应付";
            ShouldPayOperation.CreateShouldPay(sp);
        }
        string msg = "";

        Company company = CompanyOperation.GetCompanyById(order.CompanyId);
        EmailHelper.SendMailForConsign(company, order.Client, order, out msg);
        Response.Write("<script language='javascript' type='text/javascript'>alert('" + msg + "');location.href='CheckOrderList.aspx';</script>");
        
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
        order.CheckUserId = user.Id;
        order.CheckTime = DateTime.Now;
        order.Status = OrderStatus.WAIT_AUDIT;
        Client client = order.Client;
        client.Balance = client.Balance + order.Costs;
        ClientOperation.UpdateClientBalance(client);
        OrderOperation.UpdateOrderStatus(order);
        OrderOperation.UpdateOrderCheckInfo(order);
        OrderOperation.UpdateOrderReason(order);

        ShouldReceive sr = ShouldReceiveOperation.GetShouldReceiveByOrderId(id);
        if (sr != null)
        {
            ShouldReceiveOperation.DeleteReceivedDeductedBySrEncode(sr.Encode);
        }
        ShouldReceiveOperation.DeleteShouldReceiveByOrderId(id);

        Response.Write("<script language='javascript' type='text/javascript'>alert('操作成功！');location.href='AuditOrderList.aspx';</script>");
    }
}
