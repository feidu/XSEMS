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

public partial class News_Content : System.Web.UI.Page
{
    protected string newsTitle = "";
    protected string newsContent = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if(!int.TryParse(Request.QueryString["id"], out id))
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
