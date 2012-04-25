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

public partial class Admin_Finance_AlreadyPaid : System.Web.UI.Page
{
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context,true);
        user = UserOperation.GetUserByUsername(cookie.Username);

        RpAlreadyPaidDataBind();
    }

    private void RpAlreadyPaidDataBind()
    {
        PaginationQueryResult<AlreadyPaid> result = AlreadyPaidOperation.GetAlreadyPaidByCompanyId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId);
        rpAlreadyPaid.DataSource = result.Results;
        rpAlreadyPaid.DataBind();

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
            PaginationQueryResult<AlreadyPaid> result = AlreadyPaidOperation.GetAlreadyPaidByCompanyIdAndDate(PaginationHelper.GetCurrentPaginationQueryCondition(Request), user.CompanyId, startDate, endDate);
            rpAlreadyPaid.DataSource = result.Results;
            rpAlreadyPaid.DataBind();

            pagi.TotalCount = result.TotalCount;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        AlreadyPaidOperation.DeleteAlreadyPaidByIds(ids);
        lblMsg.Text = "删除成功！";

        RpAlreadyPaidDataBind();
    }
}
