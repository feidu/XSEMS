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
using Backend.Models.Pagination;
using Backend.BAL;
using Backend.Models;
using Backend.Authorization;
using Backend.Utilities;
using System.Collections.Generic;

public partial class Client_Recharge : System.Web.UI.Page
{
    ClientSession clientSession = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        if (!IsPostBack)
        {
            RpOrderDataBind();
        }
    }

    private void RpOrderDataBind()
    {
        PaginationQueryResult<Recharge> result = RechargeOperation.GetRechargeByClientId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientSession.Id);
        rpWrongOrder.DataSource = result.Results;
        rpWrongOrder.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnSerach_ServerClick(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();

        if (string.IsNullOrEmpty(sDate) && string.IsNullOrEmpty(eDate))
        {
            return;
        }
        else
        {
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

            PaginationQueryResult<Recharge> result = RechargeOperation.GetRechargeByClientIdAndDate(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientSession.Id, startDate, endDate);
            rpWrongOrder.DataSource = result.Results;
            rpWrongOrder.DataBind();

            pagi.TotalCount = result.TotalCount;

        }
    }
}
