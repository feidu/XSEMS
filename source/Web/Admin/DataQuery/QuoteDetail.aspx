<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuoteDetail.aspx.cs" Inherits="Admin_DataQuery_QuoteDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="formCharge" runat="server"> 
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">数据查询 > 报价查询 > 报价明细</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
     <tr><td align="center" style="height: 21px">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
     <tr>
      <td><table class="grid">
          <tr>
            <td width="10%" class="label" >承运商:</td>
            <td width="40%" class="content"><wl:CarrierDropDownList ID="ddlCarrier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCarrierList_SelectedIndexChanged"></wl:CarrierDropDownList></td>
            <td width="10%" class="label" >分区选择:</td>
            <td width="40%" class="content"><asp:DropDownList ID="ddlCarrierArea" runat="server"></asp:DropDownList></td>
          </tr>         
          <tr>
            <td class="label">折扣率</td>
            <td class="content" colspan="3"><input type="text" id="txtDiscount" runat="server" value="1" size="15" /></td>
          </tr>
          <tr><td colspan="4" align="center"><input type="button" class="button" value="返 回" onclick="javascript:location.href='/Admin/DataQuery/Quote.aspx?id=<%=qd.QuoteId %>'"/></td></tr>
         </table>
		</td>
    </tr>
  </table>
</form>
</body>
</html>
