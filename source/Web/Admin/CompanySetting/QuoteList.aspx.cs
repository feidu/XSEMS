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
using Backend.Models.Pagination;
using Backend.Authorization;

public partial class Admin_CompanySetting_QuoteList : System.Web.UI.Page
{
    User user = null;
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        
        if (!IsPostBack)
        {
            RpQuoteDataBind();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (ids == null)
        {
            lblMsg.Text = "请选择！";
            return;
        }
        QuoteOperation.DeleteQuoteByIds(ids);

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();
        string status = ddlQuoteStatus.SelectedItem.Value;
        string keyword = Request.Form[txtKeyword.ID].Trim();
        Response.Redirect("QuoteList.aspx?s=" + sDate + "&e=" + eDate + "&t=" + status + "&k=" + keyword + "");
    }

    private void RpQuoteDataBind()
    {
        string sDate = Request.QueryString["s"];
        string eDate = Request.QueryString["e"];
        string strStatus = Request.QueryString["t"];
        string keyword=Request.QueryString["k"];

        if (string.IsNullOrEmpty(strStatus))
        {
            strStatus = "0";
        }

        txtStartDate.Value = sDate;
        txtEndDate.Value = eDate;
        txtKeyword.Value = keyword;
        ddlQuoteStatus.SelectedValue = strStatus;

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
        PaginationQueryResult<Quote> result = QuoteOperation.GetQuoteByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId, startDate, endDate, strStatus, keyword);
        rpQuote.DataSource = result.Results;
        rpQuote.DataBind();

        pagi.TotalCount = result.TotalCount;
    }
    
}
