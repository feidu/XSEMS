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

public partial class Admin_Client_WrongOrder : System.Web.UI.Page
{
    protected int id = 0;
    protected WrongOrder wo = null;
    User user = null;
    protected List<WrongOrderDetail> result = null;
    private static readonly int ORDER_ENCODE_LENGTH = 50;
    private static readonly int WRONG_ORDER_REASON_LENGTH = 500;
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        WrongOrderOperation.DeleteWrongOrderById(id);
        Response.Write("<script language='javascript' type='text/javascript'>alert('删除成功！');location.href='Default.aspx';</script>");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string orderEncode = Request.Form[txtOrderEncode.ID].Trim();
        string reason = Request.Form[txtReason.ID].Trim();

        if (!string.IsNullOrEmpty(orderEncode) && Validator.IsMatchLessThanChineseCharacter(orderEncode, ORDER_ENCODE_LENGTH))
        {
            lblMsg.Text = "定单号长度不能超过" + ORDER_ENCODE_LENGTH + "个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(orderEncode) && OrderOperation.GetOrderByEncode(orderEncode) == null)
        {
            lblMsg.Text = "此订单号不存在！";
            return;
        }
        if (string.IsNullOrEmpty(reason) || Validator.IsMatchLessThanChineseCharacter(reason, WRONG_ORDER_REASON_LENGTH))
        {
            lblMsg.Text = "服务内容不能为空，且长度不能超过" + WRONG_ORDER_REASON_LENGTH + "个字符！";
            return;
        }
        wo.Reason = reason;        
        wo.Type = slWrongType.Value;
        if (orderEncode.Length >= 1)
        {
            Order order = OrderOperation.GetOrderByEncode(orderEncode);
            wo.Order = order;
        }
        else
        {
            wo.Order = null;
        }
        WrongOrderOperation.UpdateWrongOrder(wo);
        lblMsg.Text = "修改成功！";
        FormDataBind();
    }

    protected void btnDeleteDetail_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            FormDataBind();
            return;
        }
        WrongOrderOperation.DeleteWrongOrderDetailByIds(ids);

        Response.Write("<script language='javascript'>location.href='WrongOrder.aspx?id=" + id + "';</script>");
    }

}
