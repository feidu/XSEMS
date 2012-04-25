<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Order_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 收件计划</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateReceiveOrder.aspx">添加收件计划</a>&nbsp;&nbsp;&nbsp;<a href="CreateOrderQuick.aspx">快捷开单</a>&nbsp;&nbsp;&nbsp;日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly"/>&nbsp;&nbsp;&nbsp;&nbsp;单号：<input id="txtEncode" runat="server" size="15" class="textBox" /> <asp:Button
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
                <th align="center" class="header">收件单号</th>
                <th align="center" class="header">收件公司</th>           
                <th align="center" class="header">收件日期</th>
                <th align="center" class="header">客户姓名</th>   
                <th align="center" class="header">下单类型</th>        
                <th align="center" class="header">制单人</th>
                <th align="center" class="header">制单时间</th>
                <th align="center" class="header">操作</th>
                <th align="center" class="header">选择</th>
              </tr>
              <asp:Repeater ID="rpOrder" runat="server">
                <ItemTemplate>
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                    <td align="center"><%# Eval("Encode")%></td>
                    <td align="center"><%# Eval("CompanyName")%></td>          
                    <td align="center"><%# Convert.ToDateTime(Eval("ReceiveDate")) > DateTime.MinValue ? Convert.ToDateTime(Eval("ReceiveDate")).ToShortDateString() : "————"%></td>
                    <td align="center"><%# Eval("Client.RealName")%></td>       
                    <td align="center"><%# Backend.Utilities.EnumConvertor.OrderTypeConvertToString(Convert.ToByte(Eval("Type")))%></td>               
                    <td align="center"><%# Convert.ToString(Eval("CreateUser.RealName")).Length <= 0 ? "———" : Eval("CreateUser.RealName")%></td>
                    <td align="center"><%# Eval("CreateTime")%></td>                    
                    <td align="center"><a href="ReceiveOrder.aspx?id=<%# Eval("Id") %>">编辑</a></td>       
                    <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>                                        
                  </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                  <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                    <td align="center"><%# Eval("Encode")%></td>
                    <td align="center"><%# Eval("CompanyName")%></td>          
                    <td align="center"><%# Convert.ToDateTime(Eval("ReceiveDate")) > DateTime.MinValue ? Convert.ToDateTime(Eval("ReceiveDate")).ToShortDateString() : "————"%></td>
                    <td align="center"><%# Eval("Client.RealName")%></td>       
                    <td align="center"><%# Backend.Utilities.EnumConvertor.OrderTypeConvertToString(Convert.ToByte(Eval("Type")))%></td>               
                    <td align="center"><%# Convert.ToString(Eval("CreateUser.RealName")).Length<= 0 ? "———" : Eval("CreateUser.RealName")%></td>
                    <td align="center"><%# Eval("CreateTime")%></td>                    
                    <td align="center"><a href="ReceiveOrder.aspx?id=<%# Eval("Id") %>">编辑</a></td>  
                    <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>    
                  </tr>
                </AlternatingItemTemplate>
              </asp:Repeater>  
              <tr>              
              <td align="right" colspan="9">
                    <asp:Button ID="btnDelete" runat="server"  CssClass="button"  Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>                    
            </table>		
		</td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>  
</form>
</body>
</html>
