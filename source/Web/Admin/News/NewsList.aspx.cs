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
using Backend.BAL;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.Utilities;

public partial class Admin_News_NewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RpNewsDataBind();        
    }
    
    private void RpNewsDataBind()
    {
        PaginationQueryResult<News> result = NewsOperation.GetNews(PaginationHelper.GetCurrentPaginationQueryCondition(Request));
        rpNews.DataSource = result.Results;
        rpNews.DataBind();

        pagi.TotalCount = result.TotalCount;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["cbxId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        NewsOperation.DeleteNewsByIds(ids);
        lblMsg.Text = "删除成功！";

        RpNewsDataBind();
    }
}
