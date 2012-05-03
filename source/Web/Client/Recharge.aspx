<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recharge.aspx.cs" Inherits="Client_Recharge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<center>
<form id="form1" runat="server">
  <div>
    <div id="wrapper">
      <div id="wrapper2">
        <!--头部-->
        <wl:HeaderClient ID="hc" runat="server" />  
        <!--内容-->
        <div id="content">
          <div id="main_client">
            <div class="left_bar_client">
              <!--中间左边导航部分-->
              <wl:Left ID="left" runat="server" />
            </div>
            <div class="right_bar_client">
              
              <!--中间右边内容部分--> 
              <table class="tablecontent">
                <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="充值明细"></wl:ClientTop></td></tr>  
                <tr><td align="left" valign="bottom" style="padding-left:5px;">日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly"/> <input type="button" id="btnSerach" runat="server" value="查 询" class="button" onserverclick="btnSerach_ServerClick"/></td></tr>                   
                <tr>
                  <td><table class="grid">
                          <tr>
                            <th align="center" class="header_client">单号</th>
                            <th align="center" class="header_client">类型</th>           
                            <th align="center" class="header_client">收款日期</th>
                            <th align="center" class="header_client">流水号</th>   
                            <th align="center" class="header_client">付款方式</th>        
                            <th align="center" class="header_client">收款金额</th>
                            <th align="center" class="header_client">经手人</th>  
                          </tr>
                          <asp:Repeater ID="rpWrongOrder" runat="server">
                            <ItemTemplate>
                              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                                <td align="center"><%# Eval("Encode")%></td>
                                <td align="center"><%# Backend.Utilities.EnumConvertor.PaymentTypeConvertToString(Convert.ToByte(Eval("PaymentType")))%></td>          
                                <td align="left"><%# Convert.ToDateTime(Eval("ReceiveTime")).ToShortDateString()%></td>
                                <td align="center"><%# Eval("Invoice")%></td>                 
                                <td align="center"><%# Eval("PaymentMethodName")%></td>
                                <td align="center"><%# Eval("Money")%> 元</td>
                                <td align="center"><%# Eval("UserName")%></td>                                            
                              </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                                <td align="center"><%# Eval("Encode")%></td>
                                <td align="center"><%# Backend.Utilities.EnumConvertor.PaymentTypeConvertToString(Convert.ToByte(Eval("PaymentType")))%></td>          
                                <td align="left"><%# Convert.ToDateTime(Eval("ReceiveTime")).ToShortDateString()%></td>
                                <td align="center"><%# Eval("Invoice")%></td>                    
                                <td align="center"><%# Eval("PaymentMethodName")%></td>
                                <td align="center"><%# Eval("Money")%> 元</td>
                                <td align="center"><%# Eval("UserName")%></td>    
                              </tr>
                            </AlternatingItemTemplate>
                          </asp:Repeater>                                                
                        </table>		
		            </td>
                </tr>                
              </table>              
              <wl:Pagination ID="pagi" runat="server"/>
            </div>
          </div>
        </div>
        <!--尾部-->
        <wl:Footer ID="footer" runat="server" />
      </div>
    </div>
  </div>
</form>
</center>
</body>
</html>
