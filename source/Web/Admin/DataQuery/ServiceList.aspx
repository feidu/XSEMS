<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiceList.aspx.cs" Inherits="Admin_DataQuery_ServiceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">数据查询 > 服务查询</td>
    </tr>
    <tr>
        <td class="info">日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly"/> <asp:Button
        ID="btnSearch" runat="server" Text="查 询" CssClass="button" OnClick="btnSearch_Click"/></td>
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
            <th align="center" class="header">编号</th>  
            <th align="center" class="header">客户姓名</th>
            <th align="center" class="header">制单人</th>
            <th align="center" class="header">制单时间</th>
            <th align="center" class="header">最后处理日期</th>
            <th align="center" class="header">操作</th>
          </tr>
          <asp:Repeater ID="rpWrongOrder" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Encode") %></td>
                <td align="left"><%# Eval("Order.Client.RealName")%></td>
                <td align="left"><%# Backend.BAL.UserOperation.GetUserById(int.Parse(Eval("CreateUserId").ToString())).RealName %></td>
                <td align="left"><%# Eval("CreateTime") %></td>
                <td align="left"><%# Eval("CreateTime") %></td>
                <td align="center"><a href="Service.aspx?id=<%# Eval("Id") %>">查看</a></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Encode") %></td>
                <td align="left"><%# Eval("Order.Client.RealName")%></td>
                <td align="left"><%# Backend.BAL.UserOperation.GetUserById(int.Parse(Eval("CreateUserId").ToString())).RealName %></td>
                <td align="left"><%# Eval("CreateTime") %></td>
                <td align="left"><%# Eval("CreateTime") %></td>
                <td align="center"><a href="Service.aspx?id=<%# Eval("Id") %>">查看</a></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>      
        </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>  
</form>
</body>
</html>
