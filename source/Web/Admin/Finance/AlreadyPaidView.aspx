<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlreadyPaidView.aspx.cs" Inherits="Admin_Finance_AlreadyPaidView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:FinanceNav ID="financeNav" runat="server" />
  <table class="tablecontent">
    <tr>
      <td><table class="grid">  
              <tr>
                <td width="9%" class="label" >付款单号:</td>
                <td width="91%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >付款日期:</td>
                <td class="content"><asp:Label ID="lblPaidTime" runat="server" Text=""></asp:Label></td>
              </tr>                
              <tr>
                <td class="label" >流水号:</td>
                <td class="content"><asp:Label ID="lblInvoice" runat="server" Text=""></asp:Label></td>
              </tr> 
              <tr>
                <td class="label" >承 运 商:</td>
                <td class="content"><asp:Label ID="lblCarrier" runat="server" Text=""></asp:Label></td>
              </tr> 
              <tr>
                <td class="label" >付款方式:</td>
                <td class="content"><asp:Label ID="lblPaymentMethod" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >付款金额:</td>   
                <td class="content"><asp:Label ID="lblMoney" runat="server" Text=""></asp:Label></td>
              </tr>        
              <tr>
                <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
                <td class="content"><asp:Label ID="lblRemark" runat="server" Text=""></asp:Label></td>
              </tr>  
              <tr>
                <td class="label" >经 手 人:</td>
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
