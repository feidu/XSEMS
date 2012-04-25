using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.BAL;

public partial class Track : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["TRACKNUMS"] != null)
        {
            string trackNums = HttpContext.Current.Session["TRACKNUMS"].ToString();
            trackNums = trackNums.Trim('\'').Trim('"').Replace("\r", "','");
            List<PostStatus> result = PostStatusOperation.GetPostStatusByBarcodes(trackNums);
            if (result.Count > 0)
            {
                rpLogisticInfo.DataSource = result;
                rpLogisticInfo.DataBind();
            }
            else
            {
                trMsg.Visible = true;
                lblMsg.Text = "很抱歉，没有查到相关物流信息……";
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}