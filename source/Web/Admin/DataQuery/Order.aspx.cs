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

public partial class Admin_DataQuery_Order : System.Web.UI.Page
{
    protected int id = 0;
    Order order = null;
    User user = null;
    Company company = null;
    protected List<OrderDetail> result = null;   
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
        lblCreateUser.Text = order.CreateUser.RealName;
        lblEncode.Text = order.Encode;
        lblCreateTime.Text = order.CreateTime.ToString();
        lblReceiveType.Text = order.ReceiveType;
        lblReceiveUser.Text = UserOperation.GetUserById(order.ReceiveUserId).RealName;
        lblCalculateType.Text = CalculateTypeOperation.GetCalculateTypeById(order.CalculateType).Name;
        lblReceiveDate.Text = order.ReceiveDate.ToShortDateString();
        lblType.Text = EnumConvertor.OrderTypeConvertToString((byte)order.Type);
        lblUserName.Text = UserOperation.GetUserById(order.UserId).RealName;

        if (order.Reason != null && order.Reason.Length > 0)
        {
            if (order.CheckUserId != 0 && order.CheckTime != DateTime.MinValue)
            {
                trCheckReason.Visible = true;
                lblCheckReason.Text = order.Reason;
            }
        }
    }
}
