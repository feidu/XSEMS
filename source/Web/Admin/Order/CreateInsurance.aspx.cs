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
using Backend.Authorization;

public partial class Admin_Order_CreateInsurance : System.Web.UI.Page
{
    protected int id = 0;
    OrderDetail od = null;
    Insurance insurance = null;
    User user = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int oId = 0;
        if (int.TryParse(Request.QueryString["id"], out oId))
        {
            od = OrderDetailOperation.GetOrderDetailById(oId);
            insurance = InsuranceOperation.GetInsuranceByOrderDetailId(od.Id);
            id = od.OrderId;
        }
        AdminCookie cookie = (AdminCookie)RuleAuthorizationManager.GetCurrentSessionObject(Context, true);
        user = UserOperation.GetUserByUsername(cookie.Username);
        if (!IsPostBack)
        {
            FormDataBind();
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string strInsureWorth = Request.Form[txtInsureWorth.ID].Trim();
        string strInsureCosts = Request.Form[txtInsureCosts.ID].Trim();

        decimal insureWorth = 0;
        if (string.IsNullOrEmpty(strInsureWorth) || !decimal.TryParse(strInsureWorth, out insureWorth))
        {
            lblMsg.Text = "投保价值不能为空，且只能为大于0的数字！";
            return;
        }
        decimal insureCosts = 0;
        if (string.IsNullOrEmpty(strInsureCosts) || !decimal.TryParse(strInsureCosts, out insureCosts))
        {
            lblMsg.Text = "报价费不能为空，且只能为大于0的数字！";
            return;
        }

        if (insureCosts < 10)
        {
            insureCosts = 10;
        }

        if (insurance != null)
        {
            insurance.InsureWorth = insureWorth;
            insurance.InsureCosts = insureCosts;
            insurance.OrderDetailId = od.Id;
            insurance.OrderId = id;
            InsuranceOperation.UpdateInsurance(insurance);
        }
        else
        {
            insurance = new Insurance();
            insurance.InsureWorth = insureWorth;
            insurance.InsureCosts = insureCosts;
            insurance.OrderDetailId = od.Id;
            insurance.OrderId = id;
            insurance.CreateTime = DateTime.Now;
            insurance.CreateUserId = user.Id;
            insurance.CarrierName = CarrierOperation.GetCarrierByEncode(od.CarrierEncode).Name;
            insurance.ClientName = OrderOperation.GetOrderById(od.OrderId).Client.RealName;
            InsuranceOperation.CreateInsurance(insurance);
        }

        Order order = OrderOperation.GetOrderById(od.OrderId);
        order.Costs = order.Costs - od.TotalCosts;

        
        od.TotalCosts = od.TotalCosts - od.InsureCosts + insureCosts;
        od.InsureCosts = insureCosts;
        OrderDetailOperation.UpdateOrderDetail(od);


        order.Costs = order.Costs + od.TotalCosts;
        OrderOperation.UpdateOrder(order);

        Response.Write("<script language='javascript' type='text/javascript'>alert('提交成功！');location.href='ReceiveOrder.aspx?id="+od.OrderId+"';</script>");

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        InsuranceOperation.DeleteInsuranceById(insurance.Id);

        Order order = OrderOperation.GetOrderById(od.OrderId);
        order.Costs = order.Costs - od.TotalCosts;


        od.TotalCosts = od.TotalCosts -insurance.InsureCosts;
        od.InsureCosts = 0;
        OrderDetailOperation.UpdateOrderDetail(od);


        order.Costs = order.Costs + od.TotalCosts;
        OrderOperation.UpdateOrder(order);

        Response.Write("<script language='javascript' type='text/javascript'>alert('删除成功！');location.href='ReceiveOrder.aspx?id=" + od.OrderId + "';</script>");
    }

    private void FormDataBind()
    {
        txtBarCode.Value = od.BarCode;
        if (insurance != null)
        {
            spanDelete.Visible = true;
            txtInsureWorth.Value = insurance.InsureWorth.ToString();
            txtInsureCosts.Value = insurance.InsureCosts.ToString();
        }
        else
        {
            spanDelete.Visible = false;
        }
    }
}
