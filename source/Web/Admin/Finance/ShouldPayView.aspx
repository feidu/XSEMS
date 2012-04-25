<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShouldPayView.aspx.cs" Inherits="Admin_Finance_ShouldPayView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:FinanceNav ID="financeNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">财务管理 > 应付账款 > 应付详情</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">  
              <tr>
                <td width="9%" class="label" >应付款号:</td>
                <td width="41%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
              </tr> 
              <tr>
                <td class="label" >应付类型:</td>
                <td class="content"><asp:Label ID="lblType" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >应付日期:</td>
                <td class="content"><asp:Label ID="lblPayTime" runat="server" Text=""></asp:Label></td>
              </tr>                
              <tr>
                <td class="label" >应付金额:</td>
                <td class="content"><asp:TextBox ID="txtMoney" runat="server" Width="80"></asp:TextBox> 元</td>
              </tr> 
              <tr>
                <td class="label" >订 单 号:</td>
                <td class="content"><asp:Label ID="lblOrderEncode" runat="server" Text=""></asp:Label></td>
              </tr> 
              <tr>
                <td class="label" >跟踪条码:</td>
                <td class="content"><asp:Label ID="lblBarCode" runat="server" Text=""></asp:Label></td>
              </tr> 
              <tr>
                <td class="label" >国&nbsp;&nbsp;&nbsp;家:</td>
                <td class="content"><asp:Label ID="lblToCountry" runat="server" Text=""></asp:Label></td>
              </tr> 
              <tr>
                <td class="label" >重&nbsp;&nbsp;&nbsp;量:</td>
                <td class="content"><asp:Label ID="lblWeight" runat="server" Text=""></asp:Label></td>
              </tr> 
              <tr>
                <td class="label" >数&nbsp;&nbsp;&nbsp;量:</td>
                <td class="content"><asp:Label ID="lblCount" runat="server" Text=""></asp:Label></td>
              </tr>              
              <tr>
                <td class="label" >承 运 商:</td>
                <td class="content"><asp:Label ID="lblCarrier" runat="server" Text=""></asp:Label></td>
              </tr>      
              <tr>
                <td class="label" >制 单 人:</td>
                <td class="content"><asp:Label ID="lblUsername" runat="server" Text=""></asp:Label></td>
              </tr>  
              <tr>
                <td class="label" >制单时间:</td>
                <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>
              </tr>     
              <tr><td align="center" colspan="2"><input type="button" class="button" value="返 回" onclick="javascript:history.go(-1);" /></td></tr> 
            </table>
        </td>
    </tr>
  </table>
</form>
</body>
</html>

