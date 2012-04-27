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
using System.Collections.Generic;

public partial class Config_ClientList : System.Web.UI.Page
{
    protected List<Client> result = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        result = ClientOperation.GetClientList();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchKey = Request.Form[txtSearchKey.ID].Trim();
        if (string.IsNullOrEmpty(searchKey) || searchKey.Length > 50)
        {
            return;
        }
        result = ClientOperation.GetClientByParameters(searchKey);
    }
}
