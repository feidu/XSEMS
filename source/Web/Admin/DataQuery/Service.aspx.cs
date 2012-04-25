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
using Backend.Authorization;
using System.Collections.Generic;
using Backend.Utilities;

public partial class Admin_DataQuery_Service : System.Web.UI.Page
{
    protected int id = 0;
    protected WrongOrder wo = null;
    User user = null;
    protected List<WrongOrderDetail> result = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            wo = WrongOrderOperation.GetWrongOrderById(id);
            result = WrongOrderOperation.GetWrongOrderDetailByWrongOrderId(id);
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
        lblCreateTime.Text = wo.CreateTime.ToString();
        lblCreateUser.Text = UserOperation.GetUserById(wo.CreateUserId).RealName;
        lblEncode.Text = wo.Encode;
        txtReason.Text = wo.Reason;
        slWrongType.Value = wo.Type;
        if (wo.Order != null)
        {
            txtOrderEncode.Text = wo.Order.Encode;
            lblReceiveDate.Text = wo.Order.ReceiveDate.ToString();
        }
    }

}
