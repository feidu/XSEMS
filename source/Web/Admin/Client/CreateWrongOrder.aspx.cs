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
using Backend.Authorization;

public partial class Admin_Client_CreateWrongOrder : System.Web.UI.Page
{
    User user = null;
    private static readonly int ORDER_ENCODE_LENGTH = 50;
    private static readonly int WRONG_ORDER_REASON_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string orderEncode = Request.Form[txtOrderEncode.ID].Trim();
        string reason = Request.Form[txtReason.ID].Trim();

        if (string.IsNullOrEmpty(orderEncode) || Validator.IsMatchLessThanChineseCharacter(orderEncode, ORDER_ENCODE_LENGTH))
        {
            lblMsg.Text = "定单号不能为空，且长度不能超过"+ORDER_ENCODE_LENGTH+"个字符！";
            return;
        }
        Order order = OrderOperation.GetOrderByEncode(orderEncode);
        if (!string.IsNullOrEmpty(orderEncode) && order == null)
        {
            lblMsg.Text = "此订单号不存在！";
            return;
        }
        if (string.IsNullOrEmpty(reason) || Validator.IsMatchLessThanChineseCharacter(reason, WRONG_ORDER_REASON_LENGTH))
        {
            lblMsg.Text = "问题内容不能为空，且长度不能超过"+WRONG_ORDER_REASON_LENGTH+"个字符！";
            return;
        }

        WrongOrder wo = new WrongOrder();
        wo.CompanyId = user.CompanyId;
        wo.CompanyName = CompanyOperation.GetCompanyById(user.CompanyId).Name;
        wo.CreateTime = DateTime.Now;
        wo.LastUpdateCreateTime = DateTime.Now;
        wo.CreateUserId = user.Id;
        wo.Encode = StringHelper.GetEncodeNumber("WT");
        wo.Reason = reason;
        wo.Status = WrongOrderStatus.SEARCHED;
        wo.Type = slWrongType.Value;        
        wo.Order = order;        
        
        WrongOrderOperation.CreateWrongOrder(wo);
        wo=WrongOrderOperation.GetWrongOrderByEncode(wo.Encode);
        Response.Write("<script language='javascript' type='text/javascript'>alert('添加成功！');location.href='WrongOrder.aspx?id="+wo.Id+"';</script>");
    }
}
