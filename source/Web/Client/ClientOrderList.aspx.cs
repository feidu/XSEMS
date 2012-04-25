using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models.Pagination;
using Backend.BAL;
using Backend.Models;
using Backend.Authorization;
using Backend.Utilities;
using System.Collections.Generic;

public partial class Client_ClientOrderList : System.Web.UI.Page
{
    ClientSession clientSession = null;
    DateTime minTime = new DateTime(1999, 1, 1);
    protected void Page_Load(object sender, EventArgs e)
    {
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        if (!IsPostBack)
        {
            string sDate = Request.QueryString["sd"];
            string eDate = Request.QueryString["ed"];

            DateTime startDate = new DateTime();
            if (string.IsNullOrEmpty(sDate))
            {
                startDate = minTime;
            }
            else
            {
                startDate = DateTime.Parse(sDate);
            }

            DateTime endDate = new DateTime();
            if (string.IsNullOrEmpty(eDate))
            {
                endDate = minTime;
            }
            else
            {
                endDate = DateTime.Parse(eDate);
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
            }

            RpOrderDataBind(clientSession.Id, startDate, endDate);
            txtStartDate.Value = sDate;
            txtEndDate.Value = eDate;
        }
    }

    private void RpOrderDataBind(int clientId, DateTime startDate, DateTime endDate)
    {
        PaginationQueryResult<ClientOrder> result = ClientOrderOperation.GetClientOrderByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientId, startDate, endDate);
        rpOrder.DataSource = result.Results;
        rpOrder.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnSerach_ServerClick(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();

        DateTime startDate = new DateTime();
        if (string.IsNullOrEmpty(sDate))
        {
            startDate = minTime;
        }
        else
        {
            startDate = DateTime.Parse(sDate);
        }

        DateTime endDate = new DateTime();
        if (string.IsNullOrEmpty(eDate))
        {
            endDate = minTime;
        }
        else
        {
            endDate = DateTime.Parse(eDate);
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
        }

        Response.Redirect("ClientOrderList.aspx?sd=" + sDate + "&ed=" + eDate);

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();        

        Response.Redirect("ClientOrderPrint.aspx?sd=" + sDate + "&ed=" + eDate);
        
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = hids.Value;
        if (!string.IsNullOrEmpty(ids))
        {
            ClientOrderOperation.DeleteClientOrderByIds(ids);
        }

        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();

        DateTime startDate = new DateTime();
        if (string.IsNullOrEmpty(sDate))
        {
            startDate = minTime;
        }
        else
        {
            startDate = DateTime.Parse(sDate);
        }

        DateTime endDate = new DateTime();
        if (string.IsNullOrEmpty(eDate))
        {
            endDate = minTime;
        }
        else
        {
            endDate = DateTime.Parse(eDate);
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
        }

        Response.Redirect("ClientOrderList.aspx?sd=" + sDate + "&ed=" + eDate);
    }

    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        ClientOrderOperation.DeleteClientOrderByClientId(clientSession.Id);
        Response.Redirect("ClientOrderList.aspx");
    }
}