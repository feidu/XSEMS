using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

public partial class Client_PostStatus : System.Web.UI.Page
{
    private string barCode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        barCode = Request.QueryString["barCode"];
        if (!string.IsNullOrEmpty(barCode))
        {
            rpPostStatus.DataSource = PostStatusOperation.GetPostStatusByBarcode(barCode);
            rpPostStatus.DataBind();
        }
    }
}