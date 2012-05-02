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
using System.Collections.Generic;

public partial class Controls_Announcement : System.Web.UI.UserControl
{
    protected string announcement = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        List<News> result = NewsOperation.GetNewsByCategoryId(3);
        foreach (News news in result)
        {
            announcement += "<a href='Announcement.aspx?id=" + news.Id + "' targit='_blank'>" + news.Title + "</a>&nbsp;";
        }
    }
}
