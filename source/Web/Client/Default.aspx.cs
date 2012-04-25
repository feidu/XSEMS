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

public partial class Client_Default : System.Web.UI.Page
{
    ClientSession clientSession = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        if (!IsPostBack)
        {
            ddlOrderStatus.SelectedValue = "1";
            RpOrderDataBind(OrderStatus.WAIT_SUBMIT);
        }
    }

    private void RpOrderDataBind(OrderStatus status)
    {
        PaginationQueryResult<Order> result = OrderOperation.GetOrderByClientIdAndStatus(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientSession.Id, status);
        rpOrder.DataSource = result.Results;
        rpOrder.DataBind();

        pagi.TotalCount = result.TotalCount;
    }    

    protected void btnSerach_ServerClick(object sender, EventArgs e)
    {
        string sDate = Request.Form[txtStartDate.ID].Trim();
        string eDate = Request.Form[txtEndDate.ID].Trim();
        string encode = Request.Form[txtEncode.ID].Trim();
        if (!string.IsNullOrEmpty(encode))
        {
            if (ddlOrderStatus.SelectedItem.Value != "0")
            {
                OrderStatus status = EnumConvertor.ConvertToOrderStatus(byte.Parse(ddlOrderStatus.SelectedItem.Value));
                Order order = OrderOperation.GetOrderByClientIdEncodeAndStatus(clientSession.Id, encode, status);
                List<Order> result = new List<Order>();
                if (order != null)
                {
                    result.Add(order);
                }
                rpOrder.DataSource = result;
                rpOrder.DataBind();
            }
            else
            {
                Order order = OrderOperation.GetOrderByClientIdAndEncode(clientSession.Id, encode);
                List<Order> result = new List<Order>();
                if (order != null)
                {
                    result.Add(order);
                }
                rpOrder.DataSource = result;
                rpOrder.DataBind();
            }
        }
        else if (string.IsNullOrEmpty(sDate) && string.IsNullOrEmpty(eDate))
        {
            return;
        }
        else
        {
            DateTime startDate = new DateTime(1999, 1, 1);
            DateTime endDate = new DateTime(1999, 1, 1);
            if(!DateTime.TryParse(sDate, out startDate))
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

            if (ddlOrderStatus.SelectedItem.Value != "0")
            {
                OrderStatus status = EnumConvertor.ConvertToOrderStatus(byte.Parse(ddlOrderStatus.SelectedItem.Value));
                PaginationQueryResult<Order> result = OrderOperation.GetOrderByClientIdStatusAndDate(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientSession.Id, status, startDate, endDate);
                rpOrder.DataSource = result.Results;
                rpOrder.DataBind();

                pagi.TotalCount = result.TotalCount;
            }
            else
            {
                PaginationQueryResult<Order> result = OrderOperation.GetOrderByClientIdAndDate(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientSession.Id, startDate, endDate);
                rpOrder.DataSource = result.Results;
                rpOrder.DataBind();

                pagi.TotalCount = result.TotalCount;
            }
        }       
    }
    protected void ddlOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOrderStatus.SelectedItem.Value != "0")
        {
            OrderStatus status = EnumConvertor.ConvertToOrderStatus(byte.Parse(ddlOrderStatus.SelectedItem.Value));
            RpOrderDataBind(status);
        }
        else
        {
            PaginationQueryResult<Order> result = OrderOperation.GetOrderByClientId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), clientSession.Id);
            rpOrder.DataSource = result.Results;
            rpOrder.DataBind();

            pagi.TotalCount = result.TotalCount;
        }
    }
}

