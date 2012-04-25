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

public partial class Admin_Client_CreateOrderDetail : System.Web.UI.Page
{
    protected int id = 0;
    private static readonly int DETAIL_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!int.TryParse(Request.QueryString["id"], out id))
        {
            Response.Write("<script language='javascript'>alert('参数错误！');location.href='WrongOrder.aspx?id=" + id + "';</script>");
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        User user = UserOperation.GetUserByUsername(cookie.Username);
        
        string detail=Request.Form[txtDetail.ID].Trim();

        if (string.IsNullOrEmpty(detail) || Validator.IsMatchLessThanChineseCharacter(detail, DETAIL_LENGTH))
        {
            lblMsg.Text = "处理方式及过程不能为空，且长度不能超过"+DETAIL_LENGTH+"个字符！";
            return;
        }

        WrongOrderDetail wod = new WrongOrderDetail();
        wod.WrongOrderId = id;
        wod.Detail = detail;
        wod.CreateTime = DateTime.Now;
        wod.CreateUserId = user.Id;
        wod.Result = ddlStatus.SelectedItem.Text;
        WrongOrderOperation.CreateWrongOrderDetail(wod);

        WrongOrder wo = WrongOrderOperation.GetWrongOrderById(id);
        wo.Status = EnumConvertor.ConvertToWrongOrderStatus(byte.Parse(ddlStatus.SelectedItem.Value));
        wo.LastUpdateCreateTime = DateTime.Now;
        WrongOrderOperation.UpdateWrongOrder(wo);

        string msg = "操作成功！";
        if (chkIsMail.Checked)
        {
            Order order = OrderOperation.GetOrderById(wo.Order.Id);
            Company company = CompanyOperation.GetCompanyById(order.CompanyId);
            EmailHelper.SendMailForService(company, order.Client, wod, out msg);
        }
        Response.Write("<script language='javascript'>alert('"+msg+"');location.href='WrongOrder.aspx?id=" + id + "';</script>");
    }
}
