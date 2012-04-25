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

public partial class Admin_Controls_PersonalNavigation : System.Web.UI.UserControl
{
    private string _Title;

    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = Title;
    }
}