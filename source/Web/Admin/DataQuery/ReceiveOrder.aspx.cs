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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Backend.Authorization;

public partial class Admin_DataQuery_ReceiveOrder : System.Web.UI.Page
{
    protected int id = 0;
    protected Order order = null;
    User user = null;
    protected List<OrderDetail> result = null;
    protected int orderDetailCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            order = OrderOperation.GetOrderById(id);
            result = OrderDetailOperation.GetOrderDetailByOrderId(id);
            orderDetailCount = result.Count;
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
    }

    private void FormDataBind()
    {
        txtRemark.Text = order.Remark;
        txtCosts.Value = order.Costs.ToString();
        lblClientName.Text = order.Client.RealName;
        lblEncode.Text = order.Encode;
        lblCreateTime.Text = order.CreateTime.ToString();
        if (order.ReceiveDate > DateTime.MinValue)
        {
            txtReceivedDate.Value = order.ReceiveDate.ToShortDateString();
        }
        if (order.Reason != null && order.Reason.Trim().Length > 0)
        {
            trReturnReason.Visible = true;
            lblReason.Text = order.Reason;
        }
    }    
}
