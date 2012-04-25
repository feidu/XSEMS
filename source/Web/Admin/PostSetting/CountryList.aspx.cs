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
using Backend.Models.Pagination;
using Backend.Utilities;

public partial class Admin_PostSetting_CountryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RpCountryDataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string ids = Request.Form["chkId"];
        if (string.IsNullOrEmpty(ids))
        {
            lblMsg.Text = "请选择！";
            return;
        }
        CountryOperation.DeleteCountryByIds(ids);
        RpCountryDataBind();
    }

    private void RpCountryDataBind()
    {
        PaginationQueryResult<Country> result = CountryOperation.GetCountry(PaginationHelper.GetCurrentPaginationQueryCondition(Request));
        rpCountry.DataSource = result.Results;
        rpCountry.DataBind();

        pagi.TotalCount = result.TotalCount;
    }
}
