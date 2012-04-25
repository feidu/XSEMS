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


public partial class Site : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rpSites.DataSource = CompanyOperation.GetCompany();
        rpSites.DataBind();
    }
}
