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

public partial class Admin_Order_CreateFetchArrange : System.Web.UI.Page
{
    private static readonly int CLIENT_NAME_LENGTH = 50;
    private static readonly int PHONE_LENGTH = 50;
    private static readonly int ADDRESS_LENGTH = 200;
    private static readonly int REMARK_LENGTH = 500;

    protected string companyId = "0";
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        companyId = user.CompanyId.ToString();        
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string clientName = Request.Form[txtClientName.ID].Trim();

        if (string.IsNullOrEmpty(clientName) || clientName == "请输入客户姓名拼音的首字母" || Validator.IsMatchLessThanChineseCharacter(clientName, CLIENT_NAME_LENGTH))
        {
            lblMsg.Text = "客户姓名不能为空，且长度不能超过" + CLIENT_NAME_LENGTH + "个字符！";
            return;
        }
        Client client = ClientOperation.GetClientByRealName(clientName);
        if (client == null)
        {
            lblMsg.Text = "客户不存在！";
            return;
        }
        string phone = Request.Form[txtPhone.ID].Trim();
        string address = Request.Form[txtFetchAddress.ID].Trim();
        string strDate = Request.Form[txtFetchTime.ID].Trim();
        string strHour = slHour.Value;
        string strMinute = slMinute.Value;
        string remark = Request.Form[txtRemark.ID].Trim();

        if (string.IsNullOrEmpty(phone) || Validator.IsMatchLessThanChineseCharacter(phone, PHONE_LENGTH))
        {
            lblMsg.Text = "联系电话不能为空，且长度不能超过" + PHONE_LENGTH + "个字符！";
            return;
        }
        if (string.IsNullOrEmpty(address) || Validator.IsMatchLessThanChineseCharacter(address, ADDRESS_LENGTH))
        {
            lblMsg.Text = "取件地址不能为空，且长度不能超过" + ADDRESS_LENGTH + "个字符！";
            return;
        }
        DateTime fetchDate = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(strDate) || !DateTime.TryParse(strDate, out fetchDate))
        {
            lblMsg.Text = "预约时间不能为空，且只能为时间格式！";
            return;
        }
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }

        FetchArrange fa = new FetchArrange();
        fa.Address = address;
        fa.CreateTime = DateTime.Now;
        fa.FetchTime = new DateTime(fetchDate.Year, fetchDate.Month, fetchDate.Day, int.Parse(strHour), int.Parse(strMinute), 0);
        fa.Phone = phone;
        fa.ClientId = client.Id;
        fa.CompanyId = client.CompanyId;
        fa.Remark = remark;
        fa.UserId = user.Id;
        fa.Type = OrderType.COMPANY_ORDER;

        FetchArrangeOperation.CreateFetchArrange(fa);
        Response.Write("<script language='javascript'>alert('添加成功！');location.href='FetchArrangeList.aspx';</script>");
    }
}
