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

public partial class Controls_ClientTop : System.Web.UI.UserControl
{
    private string _title;
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    protected decimal balance = 0;
    protected decimal todayCosts = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientSession clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        if (clientSession == null)
        {
            Response.Write("<script language='javascript'>alert('请登录！');location.href='/'</script>");
        }
        else
        {
            Client client = ClientOperation.GetClientById(clientSession.Id);
            balance = client.Balance;
            todayCosts = OrderOperation.GetClientTodayOrderCostsByParameters(clientSession.Id);
        }
    }
}
