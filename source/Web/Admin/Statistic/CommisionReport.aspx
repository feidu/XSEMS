<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommisionReport.aspx.cs" Inherits="Admin_Statistic_CommisionReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:StatisticNav ID="statisticNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">统计分析 > 提成报表</td>
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
                </td>
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
                <td class="label" >业 务 员:</td>
                <td class="content"><asp:DropDownList ID="ddlCompanyUsers" runat="server"></asp:DropDownList></td>
              </tr> 
              <tr>
                <td class="label" >报表类型:</td>
                <td class="content"><asp:DropDownList ID="ddlReportType" runat="server">
                <asp:ListItem Text="PDF" Value="1"></asp:ListItem>
                <asp:ListItem Text="Excel" Value="0" Selected="true"></asp:ListItem></asp:DropDownList></td>
              </tr> 
                <tr><td colspan="2" align="center"><asp:Button ID="btnCompanyStatistic" runat="server" CssClass="button" Text="按 公 司" OnClick="btnCompanyStatistic_Click"/>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUserStatistic" runat="server" CssClass="button" Text="按业务员" OnClick="btnUserStatistic_Click"/></td></tr>
            </table>		
		</td>
    </tr>
  </table>
</form>
</body>
</html>