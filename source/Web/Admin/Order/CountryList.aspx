<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="Admin_Order_CountryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>抵达国家选择</title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 收件计划 > 添加收件明细 > 抵达国家选择</td>
    </tr>
    <tr>
        <td class="info"></td>
    </tr>
  </table>
  <table class="tablecontent">
     <tr>
      <td><table class="grid" id="tblCountry">
              <tr>
                <th align="center" class="header">国家名称</th>                
              </tr>
              <%if (result != null)
                {
                    foreach (Backend.Models.Country country in result)
                    {
                    %>               
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';" onclick="setCountry(this.rowIndex-1);">
                    <td align="left"><%=country.EnglishName%> -- <%=country.ChineseName%><input type="hidden" name="hdCountryName" value="<%=country.EnglishName%> -- <%=country.ChineseName%>" /><input type="hidden" name="hdCountryEnName" value="<%=country.EnglishName %>" /></td>                    
                  </tr> 
              <%  }
              }%>                     
            </table>	
            <script language="javascript" type="text/javascript">
            function setCountry(index)
            {           
                var hdCountryName = document.getElementsByName("hdCountryName");        
                var hdCountryEnName= document.getElementsByName("hdCountryEnName")
                opener.document.getElementById("txtCountry").value = hdCountryName[index].value;    
                opener.document.getElementById("hdCountry").value = hdCountryEnName[index].value;
                opener.document.getElementById("txtToCountry").value = hdCountryEnName[index].value;
                if(opener.document.getElementById("txtCarrier").value !="")
                {
                    opener.searchCarriers(1, 2);
                }
                self.close();
            }
            </script>	
		</td>
    </tr>
  </table>
</form>
</body>
</html>

