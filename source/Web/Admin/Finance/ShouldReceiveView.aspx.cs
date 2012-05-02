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

public partial class Admin_Finance_ShouldReceiveView : System.Web.UI.Page
{
    ShouldReceive sr = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            sr = ShouldReceiveOperation.GetShouldReceiveById(id);
        }
        FormDataBind();
    }

    private void FormDataBind()
    {
        lblEncode.Text = sr.Encode;
        lblType.Text = sr.Type;
        lblReceivedTime.Text = sr.ReceiveTime.ToShortDateString();
        txtMoney.Text = StringHelper.CurtNumber(sr.Money.ToString());
        lblClientName.Text = sr.ClientName;
        //lblRemark.Text = sr.Remark;
        lblOrderEncode.Text = sr.Order.Encode;
        lblOrderReceiveDate.Text = sr.Order.ReceiveDate.ToShortDateString();
        lblUsername.Text = UserOperation.GetUserById(sr.UserId).RealName;
        lblCreateTime.Text = sr.CreateTime.ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string strSr = Request.Form[txtMoney.ID].Trim();
        decimal money = 0;
        if (string.IsNullOrEmpty(strSr) || !decimal.TryParse(strSr, out money) || money<=0)
        {
            lblMsg.Text = "应收金额不能为空，且只能为大于0数字！";
            return;
        }

        sr.Money = money;
        ShouldReceiveOperation.UpdateShouldReceive(sr);
        Response.Write("<script language='javascript'>alert('修改成功！');location.href='Default.aspx';</script>");
    }
}
