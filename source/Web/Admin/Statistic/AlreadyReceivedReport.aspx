<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlreadyReceivedReport.aspx.cs" Inherits="Admin_Statistic_AlreadyReceivedReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
    function openClientWindow()
    {
        window.open("../../Config/ClientList.aspx?id="+document.getElementById('hdCompanyId').value+"","客户列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
    }  
</script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:StatisticNav ID="statisticNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">统计分析 > 收款报表</td>
    </tr>
    <tr>
        <td class="info"></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">  
              <tr>
                <td class="label" >所属公司:</td>   
                <td class="content"><asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"></asp:DropDownList>
                <input id="hdCompanyId" name="hdCompanyId" type="hidden" value="<%=companyId %>" /></td>
              </tr>
              <tr>
                <td class="label" width="9%">开始日期:</td>
                <td class="content" width="91%"><input type="text" class="Wdate" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly" /></td>
              </tr>              
              <tr>
                <td class="label" >结束日期:</td>
                <td class="content"><input type="text" class="Wdate" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly" /></td>
              </tr>                              
              <tr>
                <td class="label" >客户姓名:</td>
                <td class="content"><table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                <td align="left" width="14%"><input id="txtClientName" type="text" style="width:98%;color:#555555;" runat="server" readonly="readonly"/></td>
                <td align="left" width="86%"><input type="image" src="../Images/btn_bg1.gif" onclick="openClientWindow()" /></td></tr></table></td>
              </tr>  
              <tr>
                <td class="label" >业 务 员:</td>
                <td class="content"><asp:DropDownList ID="ddlCompanyUsers" runat="server"></asp:DropDownList></td>
              </tr> 
              <tr>
                <td class="label" >收 款 人:</td>
                <td class="content"><asp:DropDownList ID="ddlReceiveUsers" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="label" >付款方式:</td>
                <td class="content">
                <% foreach (Backend.Models.PaymentMethod pm in result)
                   {
                %>
                        <input type="checkbox" id="chkPaymentMethod" name="chkPaymentMethod" value="<%=pm.Id %>" /><%=pm.Name %>&nbsp;&nbsp;        
                 <%
                   } 
                 %>
                </td>
              </tr>
              <tr>
                <td class="label" >报表类型:</td>
                <td class="content"><asp:DropDownList ID="ddlReportType" runat="server">
                <asp:ListItem Text="PDF" Value="1"></asp:ListItem>
                <asp:ListItem Text="Excel" Value="0" Selected="true"></asp:ListItem>
                </asp:DropDownList></td>
              </tr> 
              <tr><td colspan="2" align="center"><asp:Button ID="btnArStatistic" CssClass="button" runat="server" Text="收款汇总" OnClick="btnArStatistic_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnArDetailStatistic" CssClass="button" runat="server" Text="收款明细" OnClick="btnArDetailStatistic_Click" /></td></tr>
            </table>		
		</td>
    </tr>
  </table>
</form>
</body>
</html>