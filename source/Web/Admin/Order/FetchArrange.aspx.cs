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

public partial class Admin_Order_FetchArrange : System.Web.UI.Page
{
    FetchArrange fa = null;
    private static readonly int PHONE_LENGTH = 50;
    private static readonly int ADDRESS_LENGTH = 200;
    private static readonly int REMARK_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if(int.TryParse(Request.QueryString["id"], out id))
        {            
            fa = FetchArrangeOperation.GetFetchArrangeById(id);
        }
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }

    private void FormDataBind()
    {
        lblClientName.Text = fa.ClientName;
        lblCreateTime.Text = fa.CreateTime.ToString();
        txtFetchAddress.Text = fa.Address;
        txtPhone.Text = fa.Phone;
        txtFetchTime.Value = fa.FetchTime.ToShortDateString();
        slHour.Value = fa.FetchTime.Hour.ToString();
        slMinute.Value = fa.FetchTime.Minute.ToString();
        txtRemark.Text = fa.Remark;
        if (fa.Type == OrderType.CLIENT_ORDER)
        {
            lblType.ForeColor = System.Drawing.Color.Blue;
        }
        lblType.Text = EnumConvertor.OrderTypeConvertToString((byte)fa.Type);
        if (UserOperation.GetUserById(fa.UserId) != null)
        {
            lblCreateUser.Text = UserOperation.GetUserById(fa.UserId).RealName;
        }
        else
        {
            lblCreateUser.Text = "— — —";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        FetchArrangeOperation.DeleteFetchArrangeById(fa.Id);
        Response.Write("<script language='javascript' type='text/javascript'>alert('删除成功！');location.href='FetchArrangeList.aspx';</script>");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
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

        fa.Address = address;
        fa.FetchTime = new DateTime(fetchDate.Year, fetchDate.Month, fetchDate.Day, int.Parse(strHour), int.Parse(strMinute), 0);
        fa.Phone = phone;
        fa.Remark = remark;

        FetchArrangeOperation.UpdateFetchArrange(fa);
        lblMsg.Text = "修改成功！";
        FormDataBind();
    }
}
