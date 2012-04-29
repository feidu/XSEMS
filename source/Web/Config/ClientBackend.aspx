<%@ Page Language="C#" %>

<%@ Import Namespace="System.Data" %>  
<%@ Import Namespace="System.Data.SqlClient" %>  
<%@ Import Namespace="Backend.Models" %> 
<%@ Import Namespace="Backend.BAL" %> 
<%@ Import Namespace="Backend.Utilities" %> 
<%@ Import Namespace="System.Collections.Generic" %>
<%  
    Response.CacheControl = "no-cache";  
    Response.AddHeader("Pragma","no-cache");  
    string sInput = Server.UrlDecode(Request["sColor"]);
    string sCompId = Server.UrlDecode(Request["sCompId"]);
    int compId = int.Parse(sCompId);
    if(sInput.Length == 0)  
    return;  
    string sResult = "";
    
    List<Client> result = ClientOperation.GetClientList();
    DataTable dt = new DataTable();

    dt.Columns.Add("uname", typeof(string));
    dt.Columns.Add("upinyin", typeof(string));
    for (int i = 0; i < result.Count; i++)
    {
        DataRow dr = dt.NewRow();
        dr["uname"] = result[i].RealName;
        dr["upinyin"] = StringHelper.GetChineseSpell(result[i].RealName);
        dt.Rows.Add(dr);
    }

    DataView dv = dt.DefaultView;
    dv.RowFilter = "upinyin like '%" + sInput + "%'";

    foreach (DataRowView drv in dv)
    {
        sResult += drv["uname"].ToString() + ",";
    }
   
    if(sResult.Length>0)             //如果有匹配项   
        sResult = sResult.Substring(0,sResult.Length-1);    //去掉最后的“,”号   
    Response.Write(sResult);  
%>  