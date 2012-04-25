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
using Backend.Utilities;

public partial class Controls_Seo : System.Web.UI.UserControl
{
    private string _Title;

    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
    protected string title = "";
    protected string keyword = "";
    protected string description = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Setting setting = CacheHelper.GetSetting();
        if (setting == null)
        {
            title = description = keyword = "飞度物流";
        }
        else
        {
            title = setting.Title;
            keyword = setting.Keyword;
            description = setting.Description;
        }
        if (!string.IsNullOrEmpty(Title))
            title = Title + " - " + title;
    }
}
