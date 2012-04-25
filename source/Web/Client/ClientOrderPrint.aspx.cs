using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;
using Backend.Authorization;

public partial class Client_ClientOrderPrint : System.Web.UI.Page
{
    DateTime minTime = new DateTime(1999, 1, 1);
    ClientSession clientSession = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
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

        List<ClientOrder> result = ClientOrderOperation.GetClientOrderListByParameters(clientSession.Id, startDate, endDate);

        rpPrint.DataSource = result;
        rpPrint.DataBind();
    }
}