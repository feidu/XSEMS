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
using Backend.Utilities;
using Backend.BAL;
using Backend.Models;

public partial class AboutUs : System.Web.UI.Page
{
    protected string aboutFeidu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        News news = NewsOperation.GetNewsById(9);
        if (news != null)
        {
            aboutFeidu = news.Content;
        }
    }
}
