using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

public partial class NewsView : System.Web.UI.Page
{
    protected string newsTitle = "";
    protected string newsContent = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (!int.TryParse(Request.QueryString["id"], out id))
        {
            Response.Write("<script language='javascript'>alert('参数错误！');</script>");
            return;
        }

        News news = NewsOperation.GetNewsById(id);

        seo.Title = news.Title;

        newsTitle = news.Title;
        newsContent = news.Content;
    }
}
