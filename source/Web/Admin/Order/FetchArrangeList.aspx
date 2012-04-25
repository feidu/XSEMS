<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FetchArrangeList.aspx.cs" Inherits="Admin_Order_FetchArrangeList" %>

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
        <td class="info2">业务管理 > 取件安排</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateFetchArrange.aspx">添加取件安排</a>&nbsp;&nbsp;&nbsp;&nbsp;日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate"/> <asp:Button
        ID="btnSearch" runat="server" Text="查 询" CssClass="button" OnClick="btnSearch_Click"/></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
              <tr>
                <th align="center" class="header">取件时间</th>
                <th align="center" class="header">客户姓名</th>           
                <th align="center" class="header">联系电话</th>
                <th align="center" class="header">取件地址</th>    
                <th align="center" class="header">下单类型</th>      
                <th align="center" class="header">下单时间</th>
                <th align="center" class="header">操作</th>
                <th align="center" class="header">选择</th>
              </tr>
              <asp:Repeater ID="rpFetchArrange" runat="server">
                <ItemTemplate>
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                    <td align="center"><%# Eval("FetchTime")%></td>
                    <td align="center"><%# Eval("ClientName")%></td>          
                    <td align="left"><%# Eval("Phone") %> </td>
                    <td align="center"><%# Eval("Address")%></td>       
                    <td align="center"><%# Backend.Utilities.EnumConvertor.OrderTypeConvertToString(Convert.ToByte(Eval("Type")))%></td>
                    <td align="center"><%# Eval("CreateTime")%></td>                    
                    <td align="center"><a href="FetchArrange.aspx?id=<%# Eval("Id") %>">查看</a></td>      
                    <td align="center"><input type="checkbox" id="chkId" name="chkId" value="<%# Eval("Id")%>" /></td>
                  </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                  <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                    <td align="center"><%# Eval("FetchTime")%></td>
                    <td align="center"><%# Eval("ClientName")%></td>          
                    <td align="left"><%# Eval("Phone") %></td>
                    <td align="center"><%# Eval("Address")%></td>       
                    <td align="center"><%# Backend.Utilities.EnumConvertor.OrderTypeConvertToString(Convert.ToByte(Eval("Type")))%></td>
                    <td align="center"><%# Eval("CreateTime")%></td>                    
                    <td align="center"><a href="FetchArrange.aspx?id=<%# Eval("Id") %>">查看</a></td> 
                    <td align="center"><input type="checkbox" id="chkId" name="chkId" value="<%# Eval("Id")%>" /></td>
                  </tr>
                </AlternatingItemTemplate>
              </asp:Repeater>     
              <tr><td align="right" colspan="8"><asp:Button ID="btnDelete" Text="删除选择项" runat="server" CssClass="button" OnClick="btnDelete_Click"/></td></tr>               
            </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/> 
</form>
</body>
</html>
