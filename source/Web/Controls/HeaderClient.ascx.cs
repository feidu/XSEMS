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
using System.Collections.Generic;
using Backend.BAL;
using Backend.Models;

public partial class Controls_HeaderClient : System.Web.UI.UserControl
{
    protected string announcement = "";

    private int _currentNav;
    public int CurrentNav
    {
        get { return _currentNav; }
        set { _currentNav = value; }
    }
    protected int currentNav = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<News> result = NewsOperation.GetNewsByCategoryId(3);
        foreach (News news in result)
        {
            announcement += "<a href='../NewsView.aspx?id=" + news.Id + "' targit='_blank'>" + news.Title + "</a>&nbsp;";
        }

        currentNav = CurrentNav;
    }
}
