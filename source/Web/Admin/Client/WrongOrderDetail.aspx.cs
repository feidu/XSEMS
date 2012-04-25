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
using Backend.Utilities;

public partial class Admin_Client_WrongOrderDetail : System.Web.UI.Page
{
    protected int id = 0;
    protected WrongOrderDetail wod = null;
    private static readonly int DETAIL_LENGTH = 500;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!int.TryParse(Request.QueryString["id"], out id))
        {
            Response.Write("<script language='javascript'>alert('参数错误！');history.go(-1);</script>");
        }
        wod = WrongOrderOperation.GetWrongOrderDetailById(id);
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }
        
    private void FormDataBind()
    {
        txtDetail.Text = wod.Detail;
        ddlStatus.SelectedValue = wod.Result;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string detail = Request.Form[txtDetail.ID].Trim();

        if (string.IsNullOrEmpty(detail) || Validator.IsMatchLessThanChineseCharacter(detail, DETAIL_LENGTH))
        {
            lblMsg.Text = "处理方式及过程不能为空，且长度不能超过" + DETAIL_LENGTH + "个字符！";
            return;
        }

        wod.Detail = detail;
        wod.Result = ddlStatus.SelectedItem.Text;
        WrongOrderOperation.UpdateWrongOrderDetail(wod);

        string msg = "操作成功！";
        if (chkIsMail.Checked)
        {
            WrongOrder wo = WrongOrderOperation.GetWrongOrderById(wod.WrongOrderId);
            Order order = OrderOperation.GetOrderById(wo.Order.Id);
            Company company = CompanyOperation.GetCompanyById(order.CompanyId);
            EmailHelper.SendMailForService(company, order.Client, wod, out msg);
        }

        Response.Write("<script language='javascript'>alert('"+msg+"');location.href='WrongOrder.aspx?id=" + wod.WrongOrderId + "';</script>");
    }
}