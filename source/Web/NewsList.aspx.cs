using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Models;
using Backend.Models.Pagination;
using Backend.BAL;
using Backend.Utilities;

public partial class NewsList : System.Web.UI.Page
{protected void Page_Load(object sender, EventArgs e)
    {
        int catId = 0;
        if(!int.TryParse(Request.QueryString["cat"],out catId))
        {
            Response.Write("<script language='javascript'>alert('参数错误！');history.go(-1);</script>");
            return;
        }
        switch (catId)
        {
            case 1:
                hc.CurrentNav = 2;
                break;
            case 3:
                hc.CurrentNav = 3;
                break;
            case 4:
                hc.CurrentNav = 4;
                break;
            case 5:
                hc.CurrentNav = 6;
                break;
        }

        NewsCategory cat = NewsOperation.GetNewsCategoryById(catId);
        if (cat != null)
        {
            seo.Title = cat.Name;

            PaginationQueryResult<News> result = NewsOperation.GetNewsByCategoryId(PaginationHelper.GetCurrentPaginationQueryCondition(Request), catId);

            rpNews.DataSource = result.Results;
            rpNews.DataBind();
            pagi.TotalCount = result.TotalCount;
        }
    }
}