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

public partial class Admin_News_NewsView : System.Web.UI.Page
{
    News news = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            news = NewsOperation.GetNewsById(id);
        }
        FormDataBind();    
    }

    private void FormDataBind()
    {
        lblTitle.Text = news.Title;
        lblCreateTime.Text = news.CreateTime.ToString();
        lblContent.Text = news.Content;
    }

}
