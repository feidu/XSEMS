<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditOrderList.aspx.cs" Inherits="Admin_Order_AuditOrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 收件审核</td>
    </tr>
    <tr>
        <td class="info">类型：<asp:DropDownList ID="ddlConsinType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConsinType_SelectedIndexChanged">
                <asp:ListItem Text="全部" Value="1"></asp:ListItem>
                <asp:ListItem Text="可发货" Value="2" Selected="True"></asp:ListItem>
                <asp:ListItem Text="不可发货" Value="3"></asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly"/>&nbsp;&nbsp;&nbsp;&nbsp;单号：<input id="txtEncode" runat="server" size="15" class="textBox" /> <asp:Button ID="btnSearch" runat="server" Text="查 询" CssClass="button" OnClick="btnSearch_Click"/>
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
                <th align="left" class="header">收件单号</th>           
                <th align="left" class="header">制单时间</th>     
                <th align="left" class="header">客户名称</th> 
                <th align="left" class="header">订单费用</th>     
                <th align="left" class="header">可发货量</th>     
                <th align="center" class="header">操作</th>
                <th align="center" class="header">选择</th>
              </tr>
              <asp:Repeater ID="rpOrder" runat="server">
                <ItemTemplate>
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                    <td align="left"><%# Eval("Encode") %></td>          
                    <td align="left"><%# Eval("CreateTime")%></td>     
                    <td align="left"><%# Eval("Client.RealName")%></td>
                    <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("Costs").ToString())%></td>
                    <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber((Convert.ToDecimal(Eval("Client.Balance"))+Convert.ToDecimal(Eval("Client.Credit"))).ToString())%></td>
                    <td align="center"><a href="AuditOrder.aspx?id=<%# Eval("Id") %>">审核</a></td>     
                    <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>                                           
                  </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                  <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                    <td align="left"><%# Eval("Encode") %></td>           
                    <td align="left"><%# Eval("CreateTime")%></td>        
                    <td align="left"><%# Eval("Client.RealName")%></td>
                    <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("Costs").ToString())%></td>
                    <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber((Convert.ToDecimal(Eval("Client.Balance"))+Convert.ToDecimal(Eval("Client.Credit"))).ToString())%></td>
                    <td align="center"><a href="AuditOrder.aspx?id=<%# Eval("Id") %>">审核</a></td>     
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
