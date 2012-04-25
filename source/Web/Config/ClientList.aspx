<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientList.aspx.cs" Inherits="Config_ClientList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>客户选择</title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="seperator"></td>
    </tr>
    <tr>
        <td class="info">&nbsp;<asp:TextBox ID="txtSearchKey" runat="server" Width="280"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查 询" OnClick="btnSearch_Click" /></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
     <tr>
      <td><table class="grid" id="tblCountry">
              <tr>
                <th align="center" class="header">客户名称</th>                
              </tr>
              <%if (result != null)
                {
                    foreach (Backend.Models.Client client in result)
                    {
                    %>               
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';" onclick="setClient(this.rowIndex-1);">
                    <td align="left"><%=client.RealName%><input type="hidden" id="hdClientRealName" name="hdClientRealName"  value="<%=client.RealName %>" /></td>                    
                  </tr> 
              <%  }
              }%>                     
            </table>	
            <script language="javascript" type="text/javascript">
            function setClient(index)
            {           
                var hdClientRealName = document.getElementsByName("hdClientRealName");      
                opener.document.getElementById("txtClientName").value = hdClientRealName[index].value;      
                self.close();
            }
            </script>	
		</td>
    </tr>
  </table>
</form>
</body>
</html>