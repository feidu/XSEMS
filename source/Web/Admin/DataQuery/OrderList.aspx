<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="Admin_DataQuery_OrderList" %>

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
        <td class="info2">数据查询 > 跟踪单号查询</td>
    </tr>
    <tr>
        <td class="info">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr><td align="left">日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly"/></td><td align="left">承 运 商：<asp:DropDownList ID="ddlCarrier" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;收件单号：<input id="txtEncode" runat="server" size="15" class="textBox" />&nbsp;&nbsp;&nbsp;&nbsp;亿度条码：<input id="txtYdEncode" runat="server" size="15" class="textBox" /></td><td align="left"></td></tr>
                <tr><td colspan="3" style="height:5px;"></td></tr>
                <tr><td align="left">跟踪条码：<input id="txtBarCode" runat="server" size="16" class="textBox" /></td><td align="left">客户姓名：<input id="txtClientName" runat="server" size="15" class="textBox" />&nbsp;&nbsp;&nbsp;&nbsp;状态：<asp:DropDownList ID="ddlStatus" runat="server"><asp:ListItem Text="全部" Value="0"></asp:ListItem><asp:ListItem Text="待提交" Value="1"></asp:ListItem><asp:ListItem Text="待审核" Value="2"></asp:ListItem><asp:ListItem Text="已扣货" Value="3"></asp:ListItem><asp:ListItem Text="待检验" Value="4"></asp:ListItem><asp:ListItem Text="已完成" Value="5"></asp:ListItem></asp:DropDownList></td><td align="left"><asp:Button ID="btnSearch" runat="server" Text="查 询" CssClass="button" OnClick="btnSearch_Click"/></td></tr>
            </table>
        </td>
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
                <th align="center" class="header">制单日期</th>
                <th align="center" class="header">收件单号</th>           
                <th align="center" class="header">客户姓名</th>
                <th align="center" class="header">承运商</th>   
                <th align="center" class="header">国家</th>        
                <th align="center" class="header">收件人</th>
                <th align="center" class="header">跟踪条码</th>
                <th align="center" class="header">状态</th>
                <th align="center" class="header">操作</th>
              </tr>
              <asp:Repeater ID="rpOrder" runat="server">
                <ItemTemplate>
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                    <td align="center"><%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString()%></td>
                    <td align="center"><a href="Order.aspx?id=<%# Eval("ID")%>"><%# Eval("Encode")%></a></td>          
                    <td align="center"><%# Eval("Client.RealName")%></td>
                    <td align="center"><%# Eval("CarrierEncode")%></td>       
                    <td align="center"><%# Eval("ToCountry")%></td>               
                    <td align="center"><%# Eval("ToUsername")%></td>
                    <td align="center"><%# Eval("BarCode")%></td>     
                    <td align="center"><%# Backend.Utilities.EnumConvertor.OrderStatusConvertToString(Convert.ToByte(Eval("Status")))%></td> 
                    <td align="center"><a href="OrderDetail.aspx?id=<%# Eval("OrderDetailId") %>">查看</a>&nbsp;<a onclick="return confirm('确认取消此订单？')" href="OrderList.aspx?id=<%# Eval("OrderDetailId") %>">取消订单</a></td>                                              
                  </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                  <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                    <td align="center"><%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString()%></td>
                    <td align="center"><a href="Order.aspx?id=<%# Eval("ID")%>"><%# Eval("Encode")%></a></td>          
                    <td align="center"><%# Eval("Client.RealName")%></td>
                    <td align="center"><%# Eval("CarrierEncode")%></td>       
                    <td align="center"><%# Eval("ToCountry")%></td>               
                    <td align="center"><%# Eval("ToUsername")%></td>
                    <td align="center"><%# Eval("BarCode")%></td>           
                    <td align="center"><%# Backend.Utilities.EnumConvertor.OrderStatusConvertToString(Convert.ToByte(Eval("Status")))%></td>   
                    <td align="center"><a href="OrderDetail.aspx?id=<%# Eval("OrderDetailId") %>">查看</a>&nbsp;<a onclick="return confirm('确认取消此订单？')" href="OrderList.aspx?id=<%# Eval("OrderDetailId") %>">取消订单</a></td>    
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