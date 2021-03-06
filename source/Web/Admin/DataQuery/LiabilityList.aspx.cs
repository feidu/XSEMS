﻿using System;
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

public partial class Admin_DataQuery_LiabilityList : System.Web.UI.Page
{
    User user = null;
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        RpLiabilityOrderDataBind();
    }

    private void RpLiabilityOrderDataBind()
    {
        PaginationQueryResult<Liability> result = LiabilityOperation.GetFinishedLiabilityByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), 0, minTime, minTime);
        rpRpLiabilityOrder.DataSource = result.Results;
        rpRpLiabilityOrder.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
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
            PaginationQueryResult<Liability> result = LiabilityOperation.GetFinishedLiabilityByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), 0, startDate, endDate);
            rpRpLiabilityOrder.DataSource = result.Results;
            rpRpLiabilityOrder.DataBind();

            pagi.TotalCount = result.TotalCount;
        }
    }
}
