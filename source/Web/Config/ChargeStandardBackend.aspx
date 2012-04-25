<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>  
<%@ Import Namespace="System.Data.SqlClient" %>  
<%@ Import Namespace="Backend.Models" %> 
<%@ Import Namespace="Backend.BAL" %> 
<%@ Import Namespace="Backend.Utilities" %> 
<%@ Import Namespace="System.Collections.Generic" %>

<%
    Response.CacheControl = "no-cache";
    Response.AddHeader("Pragma", "no-cache");
    string sEncode = Server.UrlDecode(Request["carrier"]);
    string sCountry = Server.UrlDecode(Request["country"]);
    string sType = Server.UrlDecode(Request["type"]);
    string sWeight = Server.UrlDecode(Request["weight"]);
    string sCount = Server.UrlDecode(Request["count"]);
    string sClientId=Server.UrlDecode(Request["clientId"]);

    if (sEncode.Length == 0 || sCountry.Length == 0 || sType.Length == 0 || sWeight.Length == 0 || sCount.Length == 0)
        return;
    
    Country country = CountryOperation.GetCountryByEnglishName(sCountry);
    Carrier carrier = CarrierOperation.GetCarrierByEncode(sEncode);
    byte type = byte.Parse(sType);
    decimal weight = decimal.Parse(sWeight);
    int count = int.Parse(sCount);
    int clientId = int.Parse(sClientId);
        
    string result = "";

    CarrierCharge cc = ChargeStandardOperation.GetClientCarrierChargeByParameter(country.Id, weight, type, count, carrier.Id, clientId);
    if (cc != null)
    {
        result = cc.ChargeStandard.ClientKgPrice.ToString() + "," + cc.ChargeStandard.ClientDisposalCost.ToString() + "," + cc.ChargeStandard.ClientRegisterCost.ToString() + "," + cc.ClientPostCost.ToString() + "," + sCountry; 
    }
    Response.Write(result);
    
 %>
