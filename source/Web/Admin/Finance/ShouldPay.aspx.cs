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
using Backend.Models.Pagination;
using Backend.Utilities;
using Backend.Authorization;
using System.Collections.Generic;
using System.Text;

public partial class Admin_Finance_ShouldPay : System.Web.UI.Page
{
    User user = null;
    List<ShouldPay> confirmPaidResult = null;
    private static readonly int REMARK_LENGTH = 500;
    private static readonly int INVOICE_LENGTH = 50;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);

        RpShouldPayDataBind();
        if (!IsPostBack)
        {
            ddlCarrier.Items.Add(new ListItem("", ""));
            ddlCarrier.SelectedValue = "";

            txtPaidTime.Value = DateTime.Now.ToShortDateString();
        }
    }

    private void RpShouldPayDataBind()
    {
        PaginationQueryResult<ShouldPay> result = ShouldPayOperation.GetShouldPayByCompanyId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId);
        rpShouldPay.DataSource = result.Results;
        rpShouldPay.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        divShouldPay.Visible = true;
        divContent.Visible = false;
        divConfirmPaid.Visible = false;

        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();
        
        DateTime startDate = new DateTime(1999, 1, 1);
        DateTime endDate = new DateTime(1999, 1, 1);
        if (!DateTime.TryParse(sDate, out startDate))
        {
            startDate = new DateTime(1999, 1, 1);
        }
        if (DateTime.TryParse(eDate, out endDate))
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
        }
        else
        {
            endDate = new DateTime(1999, 1, 1);
        }
        int carrierId = 0;
        if (ddlCarrier.SelectedItem.Value != "")
        {
            carrierId = int.Parse(ddlCarrier.SelectedItem.Value);
        }
        PaginationQueryResult<ShouldPay> result = ShouldPayOperation.GetShouldPayByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId, startDate, endDate, carrierId);
        rpShouldPay.DataSource = result.Results;
        rpShouldPay.DataBind();

        pagi.TotalCount = result.TotalCount;

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        ShouldPayOperation.DeleteShouldPayByIds(ids);
        lblMsg.Text = "删除成功！";

        RpShouldPayDataBind();
    }
    protected void btnPayForCarrier_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();
        if (string.IsNullOrEmpty(sDate) || string.IsNullOrEmpty(eDate))
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('请指定具体的时间段！');</script>");
            return;
        }
        DateTime startDate = new DateTime(1999, 1, 1);
        DateTime endDate = new DateTime(1999, 1, 1);
        if (!DateTime.TryParse(sDate, out startDate) || !DateTime.TryParse(eDate, out endDate))
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('请输入正确的时间格式，如：2008-8-8！');</script>");
            return; 
        }
        endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

        if (ddlCarrier.SelectedItem.Value == "")
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('请指定承运商！');</script>");
            return;
        }

        divShouldPay.Visible = false;
        divContent.Visible = true;
        divConfirmPaid.Visible = true;

        int carrierId = int.Parse(ddlCarrier.SelectedItem.Value);
        string carrierName = CarrierOperation.GetCarrierById(carrierId).Name;

        confirmPaidResult = ShouldPayOperation.GetShouldPayByParameters(user.CompanyId, startDate, endDate, carrierId);

        string titleContent = "起止日期：" + sDate + " — " + eDate + "&nbsp;&nbsp;&nbsp;承运商：" + carrierName + "";

        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='1' width='100%' cellspacing='0' cellpadding='0'>");
        sb.Append("<tr style='font-weight:bold;'><td align='left' colspan='7'>&nbsp;" + titleContent + "</td></tr>");
        sb.Append("<tr style='font-weight:bold;'><td align='left'>&nbsp;订单号码</td><td align='left'>&nbsp;跟踪条码</td><td align='left'>&nbsp;承运商</td><td align='left'>&nbsp;国家</td><td align='right'>&nbsp;重量</td><td align='right'>&nbsp;数量</td><td align='right'>&nbsp;应付金额</td></tr>");

        decimal totalMoney = 0;
        foreach (ShouldPay sp in confirmPaidResult)
        {
            sb.Append("<tr>");
            sb.Append("<td align='left'>&nbsp;" + sp.OrderEncode + "</td>");
            sb.Append("<td align='left'>&nbsp;" + sp.OrderDetail.BarCode + "</td>");
            sb.Append("<td align='left'>&nbsp;" + sp.Carrier.Name + "</td>");
            sb.Append("<td align='left'>&nbsp;" + sp.OrderDetail.ToCountry + "</td>");
            sb.Append("<td align='right'>&nbsp;" + sp.OrderDetail.Weight.ToString() + "</td>");
            sb.Append("<td align='right'>&nbsp;" + sp.OrderDetail.Count.ToString() + "</td>");
            sb.Append("<td align='right'>&nbsp;" + sp.OrderDetail.SelfTotalCosts.ToString() + "</td>");
            sb.Append("</tr>");
            totalMoney += sp.OrderDetail.SelfTotalCosts;
        }

        sb.Append("<tr style='font-weight:bold;'><td align='left'>&nbsp;合计：</td><td align='left' colspan='5'>&nbsp;</td><td align='right'>&nbsp;" + totalMoney.ToString() + "</td></tr>");
        sb.Append("</table>");

        divContent.InnerHtml = sb.ToString();
    }

    protected void btnConfirmPaid_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();
        if (string.IsNullOrEmpty(sDate) || string.IsNullOrEmpty(eDate))
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('请指定具体的时间段！');</script>");
            return;
        }
        DateTime startDate = new DateTime(1999, 1, 1);
        DateTime endDate = new DateTime(1999, 1, 1);
        if (!DateTime.TryParse(sDate, out startDate) || !DateTime.TryParse(eDate, out endDate))
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('请输入正确的时间格式，如：2008-8-8！');</script>");
            return;
        }
        endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

        if (ddlCarrier.SelectedItem.Value == "")
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('请指定承运商！');</script>");
            return;
        }
                
        int carrierId = int.Parse(ddlCarrier.SelectedItem.Value);

        confirmPaidResult = ShouldPayOperation.GetShouldPayByParameters(user.CompanyId, startDate, endDate, carrierId);


        string strPaidTime = Request.Form[txtPaidTime.ID];
        string invoice = Request.Form[txtInvoice.ID].Trim();
        string remark = Request.Form[txtRemark.ID].Trim();
        DateTime paidTime = new DateTime(1999, 1, 1);
        if (string.IsNullOrEmpty(strPaidTime) || !DateTime.TryParse(strPaidTime, out paidTime))
        {
            lblMsg.Text = "付款日期不能为空，且只能为时间格式！";
            return;
        }
        if (string.IsNullOrEmpty(invoice) || Validator.IsMatchLessThanChineseCharacter(invoice, INVOICE_LENGTH))
        {
            lblMsg.Text = "流水号不能为空，且长度不能超过" + INVOICE_LENGTH + "个字符！";
            return;
        }
        if (!string.IsNullOrEmpty(remark) && Validator.IsMatchLessThanChineseCharacter(remark, REMARK_LENGTH))
        {
            lblMsg.Text = "备注长度不能超过" + REMARK_LENGTH + "个字符！";
            return;
        }

        decimal totalMoney = 0;
        Carrier carrier = null;
        foreach (ShouldPay sp in confirmPaidResult)
        {
            ShouldPayOperation.UpdateShouldPayIsPaid(sp.Id);
            carrier = sp.Carrier;
            totalMoney += sp.OrderDetail.SelfTotalCosts;
        }
                
        AlreadyPaid ap = new AlreadyPaid();
        ap.User = user;
        ap.Remark = remark;
        ap.PaymentMethod = PaymentMethodOperation.GetPaymentMethodById(int.Parse(ddlPaymentMethod.SelectedItem.Value));
        ap.PaidTime = paidTime;
        ap.Money = totalMoney;
        ap.Invoice = invoice;
        ap.Encode = StringHelper.GetEncodeNumber("FK");
        ap.CreateTime = DateTime.Now;
        ap.CompanyId = user.CompanyId;
        ap.Carrier = carrier;
        ap.Account = "";
        ap.StartTime = startDate;
        ap.EndTime = endDate;
        AlreadyPaidOperation.CreateAlreadyPaid(ap);    

        Response.Write("<script language='javascript' type='text/javascript'>alert('操作成功！');location.href='AlreadyPaid.aspx';</script>");
    }
}
