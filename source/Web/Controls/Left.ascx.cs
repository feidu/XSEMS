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

public partial class Controls_Left : System.Web.UI.UserControl
{
    protected string username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientSession clientSession = (ClientSession)AuthorizationManager.GetCurrentSessionObject(Context, false);
        if (clientSession == null)
        {
            Response.Write("<script language='javascript'>alert('请登录！');location.href='/'</script>");
        }
        else
        {
            username = clientSession.RealName;
        }
    }
}