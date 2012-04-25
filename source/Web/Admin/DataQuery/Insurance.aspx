<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Insurance.aspx.cs" Inherits="Admin_DataQuery_Insurance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table class="tablecontent">
    <tr>
      <td><table class="grid">          
          <tr>
            <td class="label" width="9%" >跟踪号码:</td>
            <td class="content" width="25%" ><input id="txtBarCode" type="text" style="width:150px;" runat="server" readonly="readonly"/></td>
            <td class="label" width="9%" >投保价值:</td>
            <td class="content" width="24%" ><input id="txtInsureWorth" type="text" style="width:90px;" runat="server" readonly="readonly"/> 元</td>
            <td class="label" width="9%" >保 价 费:</td>
            <td class="content" width="24%" ><input id="txtInsureCosts" type="text" style="width:90px; color:Blue;" runat="server" readonly="readonly"/> 元</td>                
          </tr>          
          <tr><td colspan="6" align="left" style="color:Red;">&nbsp;说明：保价费最低为10元。</td></tr>          
         </table>
        </td>
    </tr>
  </table>
</form>
</body>
</html>
