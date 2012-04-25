<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlreadyReceivedView.aspx.cs" Inherits="Admin_Finance_AlreadyReceivedView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:FinanceNav ID="financeNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">财务管理 > 客户付款 > 已收账款详情</td>
    </tr>
    <tr>
        <td class="info"></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr>
      <td><table class="grid">  
              <tr>
                <td width="9%" class="label" >收款单号:</td>
                <td width="91%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
              </tr>   
              <tr>
                <td class="label" >收款类型:</td>
                <td class="content"><asp:Label ID="lblPaymentType" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >收款时间:</td>
                <td class="content"><asp:Label ID="lblReceivedTime" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >流水号:</td>
                <td class="content"><asp:Label ID="lblInvoice" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >客户姓名:</td>   
                <td class="content"><asp:Label ID="lblClientName" runat="server" Text=""></asp:Label></td>
              </tr>                   
              <tr>
                <td class="label" >付款方式:</td>
                <td class="content"><asp:Label ID="lblPaymentMethod" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                <td class="label" >收款账号:</td>
                <td class="content"><asp:Label ID="lblAccount" runat="server" Text=""></asp:Label></td>
              </tr>      
              <tr id="trUsdConversion" runat="server" visible="false">
                    <td colspan="2" align="left" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                              <td class="label" >币&nbsp;&nbsp;&nbsp;&nbsp;种:</td>
                              <td class="content"><asp:Label ID="lblCurrencyType" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                              <td class="label" width="9%"> 客户付款: </td>
                              <td align="left" class="content" width="91%"><asp:Label ID="lblClientPaid" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                              <td class="label" > 当前汇率: </td>
                              <td align="left" class="content"><asp:Label ID="lblExchangeRate" runat="server" Text=""></asp:Label></td>
                            </tr> 
                            <tr>
                              <td class="label"> 实际收款: </td>
                              <td align="left" class="content"><asp:Label ID="lblActualReceived" runat="server" Text=""></asp:Label> 元                                          
                                 </td>
                            </tr> 
                        </table>
                    </td>
                </tr>
                <tr  id="trReceivedMoney" runat="server">
                <td class="label" >收款金额:</td>
                <td class="content"><asp:Label ID="lblReceivedMoney" runat="server" Text=""></asp:Label> 元</td>
              </tr>  
              <tr>
                <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
                <td class="content"><asp:Label ID="lblRemark" runat="server" Text=""></asp:Label></td>
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
