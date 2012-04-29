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

public partial class Admin_Order_QuoteList : System.Web.UI.Page
{
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);

        RpQuoteDataBind();
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
        RpQuoteDataBind();
    }

    private void RpQuoteDataBind()
    {
        PaginationQueryResult<Quote> result = QuoteOperation.GetQuote(PaginationHelper.GetCurrentPaginationQueryCondition(Request));
        rpQuote.DataSource = result.Results;
        rpQuote.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
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
        PaginationQueryResult<Quote> result = QuoteOperation.GetQuoteByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), startDate, endDate, "0","");
        rpQuote.DataSource = result.Results;
        rpQuote.DataBind();

        pagi.TotalCount = result.TotalCount;

    }
}
