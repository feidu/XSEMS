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

public partial class Admin_Order_CreateReceiveOrder : System.Web.UI.Page
{
    private static readonly int CLIENT_NAME_LENGTH = 50;
    private static readonly int REMARK_LENGTH = 500;

    protected string companyId = "0";
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        companyId = user.CompanyId.ToString();
        txtCreateDate.Value = DateTime.Now.ToShortDateString();
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string clientName = Request.Form[txtClientName.ID].Trim();
        string remark = Request.Form[txtRemark.ID].Trim();

        if (string.IsNullOrEmpty(clientName) || clientName == "请输入客户姓名拼音的首字母" || Validator.IsMatchLessThanChineseCharacter(clientName, CLIENT_NAME_LENGTH))
        {
            lblMsg.Text = "客户姓名不能为空，且长度不能超过" + CLIENT_NAME_LENGTH + "个字符！";
            return;
        }
        Client client = ClientOperation.GetClientByRealNameAndCompanyId(clientName, user.CompanyId);
        if (client == null)
        {
            lblMsg.Text = "客户不存在！";
            return;
        }

        DateTime createDate = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(Request.Form[txtCreateDate.ID].Trim()) || !DateTime.TryParse(Request.Form[txtCreateDate.ID].Trim(), out createDate))
        {
            lblMsg.Text = "发货日期不能为空，且只能为时间格式！";
            return;
        }
        
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }
           
        string encode = StringHelper.GetEncodeNumber("SJ");

        Order order = new Order();
        order.Client = client;
        order.CompanyId = user.CompanyId;
        order.CompanyName = CompanyOperation.GetCompanyById(client.CompanyId).Name;
        order.Encode = encode;
        if (client.UserId != 0)
        {
            order.UserId = client.UserId;
        }
        else
        {
            order.UserId = user.Id;
        }
        order.CreateUser = user;
        order.ReceiveUserId = user.Id;
        order.Status = OrderStatus.WAIT_SUBMIT;
        order.Type = OrderType.COMPANY_ORDER;
        order.CalculateType = int.Parse(ddlCalculateType.SelectedItem.Value);
        order.ReceiveType = ddlReceiveType.SelectedItem.Value;
        order.CreateTime = new DateTime(createDate.Year, createDate.Month, createDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
        order.Costs = 0;
        order.ReceiveDate = new DateTime(createDate.Year, createDate.Month, createDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
        order.Remark = remark;
        order.ToPostcode = "";
        order.ToAddress = "";
        order.ToCity = "";
        order.ToCountry = "";
        order.ToEmail = "";
        order.ToPhone = "";
        order.ToUsername = "";

        OrderOperation.CreateOrder(order);
        order = OrderOperation.GetOrderByEncode(encode);
        Response.Write("<script language='javascript'>alert('添加成功！');location.href='ReceiveOrder.aspx?id="+order.Id+"';</script>");
    }
}
