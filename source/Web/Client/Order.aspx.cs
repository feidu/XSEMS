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

public partial class Client_Order : System.Web.UI.Page
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
        txtCosts.Value =Backend.Utilities.StringHelper.CurtNumber(order.Costs.ToString());       
        lblEncode.Text = order.Encode;
        lblCreateTime.Text = order.CreateTime.ToString();

        if (order.Reason != null && order.Reason.Trim().Length > 0)
        {
            trReturnReason.Visible = true;
            lblReason.Text = order.Reason;
            if (order.Status == OrderStatus.WAIT_AUDIT)
            {
                lblReasonTitle.Text = "检验退回原因";
            }
            else if (order.Status == OrderStatus.WAIT_AUDIT)
            {
                lblReasonTitle.Text = "审核退回原因";
            }
            else if (order.Status == OrderStatus.DETAINED)
            {
                lblReasonTitle.Text = "扣货原因";
            }
        }
    }

    protected void btnPrintTag_Click(object sender, EventArgs e)
    {

    }
     
    protected void btnInsure_Click(object sender, EventArgs e)
    {
        FormDataBind();
    }
}
