using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Backend.Models;
using Backend.BAL;
using Backend.Utilities;
using Backend.Authorization;
using System.Collections.Generic;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected string address = "";
    protected string phoneNumber = "";
    protected string faxNumber = "";
    protected string msnAccount = "";
    protected string postalcode = "";
    protected string aboutFeidu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Setting setting = CacheHelper.GetSetting();
        phoneNumber = setting.Phone;
        faxNumber = setting.Fax;
        msnAccount = setting.Msn;
        address = setting.Address;
        postalcode = setting.Postalcode;
        News news = NewsOperation.GetNewsById(9);
        if (news != null)
        {
            aboutFeidu = StringHelper.CnCutString(news.Content, 380)+"……";
        }
    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        string username = Request.Form["tbxUsername"].Trim();
        string password = Request.Form["tbxPassword"];

        if (string.IsNullOrEmpty(username))
        {
            Response.Write("<script language='javascript'>alert('请输入用户名！');location.href='/';</script>");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            Response.Write("<script language='javascript'>alert('请输入密码！');location.href='/';</script>");
            return;
        }
        Client client = new Client();
        client.Username = username;
        client.Password = password;
        string msg = "";
        if (ClientOperation.ClientLogin(client, out msg))
        {
            ClientSession cs = new ClientSession();
            Client newClient = ClientOperation.GetClientByUsername(client.Username);
            cs.Id = newClient.Id;
            cs.Username = newClient.Username;
            cs.RealName = newClient.RealName;
            AuthorizationManager.Authorize(cs);
            Response.Redirect("Client/Default.aspx");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('" + msg + "');location.href='/';</script>");
            return;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Server.Transfer("PostCosts.aspx", true);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session["TRACKNUMS"] = null;
        string trackNums = Request.Form["txtTrackNum"];
        if (!string.IsNullOrEmpty(trackNums.Trim()))
        {
            if (trackNums.IndexOf('\r') != -1)
            {
                trackNums = trackNums.Replace("\n", "");
            }
            HttpContext.Current.Session["TRACKNUMS"] = trackNums;
            Response.Write("<script language='javascript'>window.open('Track.aspx');</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('请输入追踪号！');</script>");
        }
    }
}
