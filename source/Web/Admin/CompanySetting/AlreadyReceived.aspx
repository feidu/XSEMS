<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlreadyReceived.aspx.cs" Inherits="Admin_CompanySetting_AlreadyReceived" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:CompanySettingNav ID="companySettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">公司设置 > 公司设定 > 客户付款</td>
    </tr>
    <tr>
        <td class="info">日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate"/> <asp:Button
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
                <th align="left" class="header">收款单号</th>
                <th align="left" class="header">类型</th>           
                <th align="left" class="header">收款日期</th>
                <th align="left" class="header">流水号</th>   
                <th align="left" class="header">客户姓名</th>      
                <th align="left" class="header">付款方式</th>        
                <th align="left" class="header">收款金额</th>
                <th align="left" class="header">制单人</th>                
                <th align="center" class="header">操作</th>
              </tr>
              <asp:Repeater ID="rpAlreadyReceived" runat="server">
                <ItemTemplate>
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                    <td align="left"><%# Eval("Encode")%></td>
                    <td align="left"><%# Backend.Utilities.EnumConvertor.PaymentTypeConvertToString(Convert.ToByte(Eval("PaymentType")))%></td>          
                    <td align="left"><%# Convert.ToDateTime(Eval("ReceiveTime")).ToShortDateString()%></td>
                    <td align="left"><%# Eval("Invoice")%></td>       
                    <td align="left"><%# Eval("ClientName")%></td>               
                    <td align="left"><%# Eval("PaymentMethodName")%></td>
                    <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("Money").ToString())%> 元</td>
                    <td align="left"><%# Eval("UserName")%></td>                    
                    <td align="center"><a onclick="return confirm('您确认要删除此充值信息？')" href="AlreadyReceived.aspx?id=<%# Eval("Id") %>">删除</a></td>   
                  </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                  <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                    <td align="left"><%# Eval("Encode")%></td>
                    <td align="left"><%# Backend.Utilities.EnumConvertor.PaymentTypeConvertToString(Convert.ToByte(Eval("PaymentType")))%></td>          
                    <td align="left"><%# Convert.ToDateTime(Eval("ReceiveTime")).ToShortDateString()%></td>
                    <td align="left"><%# Eval("Invoice")%></td>       
                    <td align="left"><%# Eval("ClientName")%></td>               
                    <td align="left"><%# Eval("PaymentMethodName")%></td>
                    <td align="left"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("Money").ToString())%> 元</td>
                    <td align="left"><%# Eval("UserName")%></td>                    
                    <td align="center"><a onclick="return confirm('您确认要删除此充值信息？')" href="AlreadyReceived.aspx?id=<%# Eval("Id") %>">删除</a></td>             
                  </tr>
                </AlternatingItemTemplate>
              </asp:Repeater>   
              <tr style="display:none;">              
              <td align="right" colspan="10">
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
