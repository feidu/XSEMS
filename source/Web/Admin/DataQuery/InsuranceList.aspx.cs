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

public partial class Admin_DataQuery_InsuranceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RpInsuranceDataBind();
    }

    private void RpInsuranceDataBind()
    {
        PaginationQueryResult<Insurance> result = InsuranceOperation.GetInsurance(PaginationHelper.GetCurrentPaginationQueryCondition(Request));
        rpInsurance.DataSource = result.Results;
        rpInsurance.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();
        decimal insureWorth = decimal.Parse(ddlInsureWorth.SelectedItem.Value);
        string searchKey = Request.Form[txtSearchKey.ID].Trim();

        DateTime startDate = new DateTime(1999, 1, 1);
        DateTime endDate = new DateTime(1999, 1, 1);

        if (!string.IsNullOrEmpty(sDate) && !string.IsNullOrEmpty(eDate))        
        {
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
        }

        PaginationQueryResult<Insurance> result = InsuranceOperation.GetInsuranceByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), startDate, endDate, insureWorth, searchKey);
        rpInsurance.DataSource = result.Results;
        rpInsurance.DataBind();

        pagi.TotalCount = result.TotalCount;
    }
}
