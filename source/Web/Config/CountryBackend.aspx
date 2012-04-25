<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>  
<%@ Import Namespace="System.Data.SqlClient" %>  
<%@ Import Namespace="Backend.Models" %> 
<%@ Import Namespace="Backend.BAL" %> 
<%@ Import Namespace="System.Collections.Generic" %>

<%  
    Response.CacheControl = "no-cache";  
    Response.AddHeader("Pragma","no-cache");  
    string sInput = Server.UrlDecode(Request["sColor"]);  
    if(sInput.Length == 0)  
    return;  
    string sResult = "";

    List<Country> result = CountryOperation.GetCountry();

    DataTable dtCountry = new DataTable();
    dtCountry.Columns.Add("english_name", typeof(string));
    foreach (Country country in result)
    {
        DataRow drCountry = dtCountry.NewRow();
        drCountry["english_name"] = country.EnglishName;
        dtCountry.Rows.Add(drCountry);
    }

    DataView dv = dtCountry.DefaultView;
    dv.RowFilter = "english_name like '" + sInput + "%'";

    foreach (DataRowView drv in dv)
    {
        sResult += drv["english_name"].ToString() + ",";
    }
   
    if(sResult.Length>0)             //如果有匹配项   
        sResult = sResult.Substring(0,sResult.Length-1);    //去掉最后的“,”号   
    Response.Write(sResult);  
%>  
