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
using Backend.Authorization;
using Backend.Models;
using Backend.Utilities;
using Backend.Models.Pagination;
using Backend.BAL;
using System.Collections.Generic;

public partial class Admin_DataQuery_OrderList : System.Web.UI.Page
{
    DateTime minTime = new DateTime(1999, 1, 1);
    User user = null;
    int orderDetailId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        if (int.TryParse(Request.QueryString["id"], out orderDetailId))
        {
            CancelOrderDetails();
        }
        
        if (!IsPostBack)
        {
            //RpOrderDataBind("", -1, "", "", "", minTime, minTime, 0);
            DdlCarrierDataBind();
            
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
            
            string carrierEncode = Request.QueryString["cr"];
            string encode = Request.QueryString["e"];
            string ydEncode = Request.QueryString["y"];
            string barCode = Request.QueryString["b"];
            int clientId = 0;
            string clientName = Request.QueryString["cn"];
            if (!string.IsNullOrEmpty(clientName))
            {
                Client client = ClientOperation.GetClientByRealName(clientName);
                if (client != null)
                {
                    clientId = client.Id;
                }
            }
            else
            {
                clientId = -1;
            }
            byte status = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["s"]))
            {
                status = byte.Parse(Request.QueryString["s"]);
            }
            if (string.IsNullOrEmpty(carrierEncode))
            {
                carrierEncode = "";
            }
            if (string.IsNullOrEmpty(encode))
            {
                encode = "";
            }
            if (string.IsNullOrEmpty(ydEncode))
            {
                ydEncode = "";
            }
            if (string.IsNullOrEmpty(barCode))
            {
                barCode = "";
            }
            if (string.IsNullOrEmpty(clientName))
            {
                clientName = "";
            }

            RpOrderDataBind(carrierEncode, clientId, encode, ydEncode, barCode, startDate, endDate, status);
            txtStartDate.Value = sDate;
            txtEndDate.Value = eDate;
            ddlCarrier.SelectedValue = carrierEncode;
            txtYdEncode.Value = ydEncode;
            txtBarCode.Value = barCode;
            txtClientName.Value = clientName;
            txtEncode.Value = encode;
            ddlStatus.SelectedValue = status.ToString();
        }
    }

    private void RpOrderDataBind(string carrierEncode, int clientId, string encode, string ydEncode, string barCode, DateTime startDate, DateTime endDate,byte status)
    {
        PaginationQueryResult<SearchOrder> result = OrderOperation.GetSearchOrderByParameters(PaginationHelper.GetCurrentPaginationQueryCondition(Request), carrierEncode, clientId, encode, ydEncode, barCode, startDate, endDate, status);
        rpOrder.DataSource = result.Results;
        rpOrder.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    private void DdlCarrierDataBind()
    {
        List<Carrier> result = CarrierOperation.GetCarrier();
        ddlCarrier.DataSource = result;
        ddlCarrier.DataTextField = "Encode";
        ddlCarrier.DataValueField = "Encode";
        ddlCarrier.DataBind();

        ddlCarrier.Items.Add(new ListItem("", ""));
        ddlCarrier.SelectedValue = "";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
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

        string carrierEncode = ddlCarrier.SelectedItem.Text;
        string encode = Request.Form[txtEncode.ID].Trim();
        string ydEncode = Request.Form[txtYdEncode.ID].Trim();
        string barCode = Request.Form[txtBarCode.ID].Trim();

        int clientId = 0;
        string clientName = Request.Form[txtClientName.ID].Trim();
        if (!string.IsNullOrEmpty(clientName))
        {
            Client client = ClientOperation.GetClientByRealName(clientName);
            if (client != null)
            {
                clientId = client.Id;
            }
        }
        else
        {
            clientId = -1;
        }        
        Response.Redirect("OrderList.aspx?sd="+sDate+"&ed="+eDate+"&cr="+carrierEncode+"&e="+encode+"&y="+ydEncode+"&b="+barCode+"&cn="+clientName+"&s="+ddlStatus.SelectedValue);
    }

    private void CancelOrderDetails()
    {
        OrderDetail od = OrderDetailOperation.GetOrderDetailById(orderDetailId);
        Order order = OrderOperation.GetOrderById(od.OrderId);
        
        od.CancelTime = DateTime.Now;
        od.CancelUser = user.Id;
        OrderDetailOperation.UpdateOrderDetailCancelInfo(od);
        OrderDetailOperation.DeleteOrderDetailById(orderDetailId);
        List<OrderDetail> result = OrderDetailOperation.GetOrderDetailByOrderId(od.OrderId);
        if (result.Count <= 0)
        {           
            OrderOperation.DeleteOrderById(od.OrderId);
        }
        if (order.Status == OrderStatus.FINISHED)
        {
            ShouldPayOperation.DeleteShouldPayByOrderDetailId(orderDetailId);
        }
        if (order.Status == OrderStatus.WAIT_CHECK || order.Status == OrderStatus.FINISHED)
        {            
            Client client = order.Client;
            client.Balance = client.Balance + od.TotalCosts;
            ClientOperation.UpdateClientBalance(client);

            ShouldReceive sr = ShouldReceiveOperation.GetShouldReceiveByOrderId(od.OrderId);// 应付款
            ShouldReceive srd = ShouldReceiveOperation.GetShouldReceivedByOrderId(od.OrderId);// 已付款
            if (sr != null)
            {
                sr.Money = sr.Money - od.TotalCosts;
                ShouldReceiveOperation.UpdateShouldReceive(sr);
                if (sr.Money <= 0)
                {
                    ShouldReceiveOperation.DeleteShouldReceiveById(sr.Id);
                    if (sr.Money < 0)
                    {
                        srd.Money = srd.Money + sr.Money;
                        ShouldReceiveOperation.UpdateShouldReceive(srd);
                        if (srd.Money <= 0)
                        {
                            ShouldReceiveOperation.DeleteShouldReceiveById(srd.Id);
                        }
                        ReceivedDeducted rd = ShouldReceiveOperation.GetReceivedDeductedBySrEncode(sr.Encode);
                        if (rd != null)
                        {
                            rd.Money = rd.Money + sr.Money;
                            ShouldReceiveOperation.UpdateReceivedDeducted(rd);
                            if (rd.Money <= 0)
                            {
                                ShouldReceiveOperation.DeleteReceivedDeductedById(rd.Id);
                            }
                        }
                    }
                }
            }
            else
            {
                srd.Money = srd.Money - od.TotalCosts;
                ShouldReceiveOperation.UpdateShouldReceive(srd);
                if (srd.Money <= 0)
                {
                    ShouldReceiveOperation.DeleteShouldReceiveById(srd.Id);
                }
                ReceivedDeducted rd = ShouldReceiveOperation.GetReceivedDeductedBySrEncode(srd.Encode);
                if (rd != null)
                {
                    rd.Money = rd.Money - od.TotalCosts;
                    ShouldReceiveOperation.UpdateReceivedDeducted(rd);
                    if (rd.Money <= 0)
                    {
                        ShouldReceiveOperation.DeleteReceivedDeductedById(rd.Id);
                    }
                }
            }
        }
        
        Response.Write("<script language='javascript' type='text/javascript'>alert('操作成功！');location.href='OrderList.aspx';</script>");
    }
}
