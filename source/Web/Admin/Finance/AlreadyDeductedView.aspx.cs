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

public partial class Admin_Finance_AlreadyDeductedView : System.Web.UI.Page
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
        lblMoney.Text = StringHelper.CurtNumber(sr.Money.ToString());
        lblClientName.Text = sr.ClientName;
        //lblRemark.Text = sr.Remark;
        lblOrderEncode.Text = sr.Order.Encode;
        lblOrderReceiveDate.Text = sr.Order.ReceiveDate.ToShortDateString();
        lblUsername.Text = UserOperation.GetUserById(sr.UserId).RealName;
        lblCreateTime.Text = sr.CreateTime.ToString();
    }
}
