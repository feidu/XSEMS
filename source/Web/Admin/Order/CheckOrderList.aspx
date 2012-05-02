<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOrderList.aspx.cs" Inherits="Admin_Order_CheckOrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td class="img"><img src="../Images/icon_applist.gif" width="32" height="32" alt="" /></td>
      <td class="title2"><a href="../Order/CheckOrderList.aspx">收件检验</a></td>
    </tr>
    <tr>
      <td colspan="2" class="line"></td>
    </tr>
  </table>  
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">收件检验</td>
    </tr>
    <tr>
        <td class="info">日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate"/>&nbsp;&nbsp;&nbsp;&nbsp;单号：<input id="txtEncode" runat="server" size="15" class="textBox" />  <asp:Button
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
                <th align="left" class="header">收件单号</th>     
                <th align="left" class="header">制单时间</th>     
                <th align="left" class="header">客户名称</th>
                <th align="left" class="header">订单费用</th>  
                <th align="left" class="header">审核人员</th>  
                <th align="left" class="header">审核时间</th>     
                <th align="center" class="header">操作</th>
              </tr>
              <asp:Repeater ID="rpOrder" runat="server">
                <ItemTemplate>
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                    <td align="left"><%# Eval("Encode") %></td>             
                    <td align="left"><%# Eval("CreateTime")%></td>     
                    <td align="left"><%# Eval("Client.RealName")%></td>
                    <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("Costs").ToString())%></td>  
                    <td align="left"><%# Backend.BAL.UserOperation.GetUserById(Convert.ToInt32(Eval("audit_user_id"))).RealName%></td>  
                    <td align="left"><%# Eval("Audit_Time")%></td>  
                    <td align="center"><a href="CheckOrder.aspx?id=<%# Eval("Id") %>">检验</a></td>                                               
                  </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                  <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                    <td align="left"><%# Eval("Encode") %></td>           
                    <td align="left"><%# Eval("CreateTime")%></td>         
                    <td align="left"><%# Eval("Client.RealName")%></td>
                    <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("Costs").ToString())%></td> 
                    <td align="left"><%# Backend.BAL.UserOperation.GetUserById(Convert.ToInt32(Eval("audit_user_id"))).RealName%></td>  
                    <td align="left"><%# Eval("Audit_Time")%></td> 
                    <td align="center"><a href="CheckOrder.aspx?id=<%# Eval("Id") %>">检验</a></td>     
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
