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

public partial class Admin_Client_CreateLiabilityOrder : System.Web.UI.Page
{
    User user = null;
    private static readonly int ORDER_ENCODE_LENGTH = 50;
    private static readonly int FILL_USER_LENGTH = 10;
    private static readonly int DETAIL_LENGTH = 2000;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string orderEncode = Request.Form[txtOrderEncode.ID].Trim();
        string fillUser = Request.Form[txtFillUser.ID].Trim();
        string strFillTime = Request.Form[txtFillTime.ID].Trim();
        string detail = Request.Form[txtDetail.ID].Trim();
        if (string.IsNullOrEmpty(orderEncode) || Validator.IsMatchLessThanChineseCharacter(orderEncode, ORDER_ENCODE_LENGTH))
        {
            lblMsg.Text = "订单号不能为空，且长度不能超过" + ORDER_ENCODE_LENGTH + "个字符！";
            return;
        }
        Order order = OrderOperation.GetOrderByEncode(orderEncode);
        if (order == null)
        {
            lblMsg.Text = "此订单号不存在！";
            return;
        }
        string encode = StringHelper.GetNextEncodeNumber(8, "00000000");

        if (string.IsNullOrEmpty(fillUser) || Validator.IsMatchLessThanChineseCharacter(fillUser, FILL_USER_LENGTH))
        {
            lblMsg.Text = "填表人不能为空，且长度不能超过"+FILL_USER_LENGTH+"个字符！";
        }

        DateTime fillTime = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(strFillTime) || !DateTime.TryParse(strFillTime, out fillTime))
        {
            lblMsg.Text = "填表时间不能为空，且只能为时间格式！";
            return;
        }
        if (string.IsNullOrEmpty(detail) || Validator.IsMatchLessThanChineseCharacter(detail, DETAIL_LENGTH))
        {
            lblMsg.Text = "事情经过不能为空，且长度不能超过" + DETAIL_LENGTH + "个字符！";
            return;
        }
        Liability ly = new Liability();
        ly.Encode = encode;
        ly.Order = order;
        ly.FillUser = fillUser;
        ly.FillTime = fillTime;
        ly.EventType = EnumConvertor.ConvertToLiabilityEventType(byte.Parse(ddlEventType.SelectedItem.Value));
        ly.Detail = Request.Form[txtDetail.ID].Trim();
        ly.Result = "";
        ly.CompanyId = order.CompanyId;
        ly.Status = LiabilityStatus.WAIT_AUDIT;
        ly.ClientName = order.Client.RealName;
        ly.CreateUser = user.RealName;
        ly.CreateTime = DateTime.Now;
        ly.CurrencyType = "人民币";
        LiabilityOperation.CreateLiability(ly);

        ly = LiabilityOperation.GetLiabilityByEncode(encode);
        Response.Write("<script language='javascript' type='text/javascript'>alert('添加成功！');location.href='LiabilityOrder.aspx?id=" + ly.Id + "';</script>");
    }
}
