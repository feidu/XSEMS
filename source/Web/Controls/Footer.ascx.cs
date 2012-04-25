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

public partial class Controls_Footer : System.Web.UI.UserControl
{
    protected string address = "";
    protected string phoneNumber = "";
    protected string faxNumber = "";
    protected string record = "";
    protected string copyright = "";
    protected string postalcode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Setting setting = CacheHelper.GetSetting();

        phoneNumber = setting.Phone;
        faxNumber = setting.Fax;
        record = setting.Record;
        copyright = setting.Copyright;
        address = setting.Address;
        postalcode = setting.Postalcode;
    }
}
