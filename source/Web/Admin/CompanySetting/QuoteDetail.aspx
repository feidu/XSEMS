<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuoteDetail.aspx.cs" Inherits="Admin_CompanySetting_QuoteDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="formCharge" runat="server"> 
  <wl:CompanySettingNav ID="companySettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">公司设置 > 公司设定 >  报价管理 > 报价明细</td>
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
            <td width="9%" class="label" >承运商:</td>
            <td width="31%" class="content"><wl:CarrierDropDownList ID="ddlCarrier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCarrierList_SelectedIndexChanged"></wl:CarrierDropDownList></td>
            <td width="9%" class="label" >分区选择:</td>
            <td width="21%" class="content"><asp:DropDownList ID="ddlCarrierArea" runat="server"></asp:DropDownList></td>
            <td width="10%" class="label">挂号费打折:</td>
            <td width="20%" class="content"><asp:CheckBox ID="chkIsRegisterAbate" runat="server" Checked="true" /></td>
          </tr>         
          <tr>
            <td class="label">折扣率:</td>
            <td class="content"><input type="text" id="txtDiscount" runat="server" value="1" size="7" />(0 - 2之间的数字)</td>
            <td class="label">让利克数:</td>
            <td class="content"><input type="text" id="txtPreferentialGram" runat="server" value="0" size="7" /> 克</td>
            <td class="label">挂号费:</td>
            <td class="content"><input type="text" id="txtSetRegisterCosts" runat="server" value="0" size="7" /> 元</td>
          </tr>
          <tr><td colspan="6" align="left">&nbsp;<span style="color:Red; font-weight:bold;">说明：</span>挂号费如果输入不等于0的值，则挂号费直接按此值计算，不受[挂号费打折]是否勾选和任何[折扣率]约束。</td></tr>
          <tr><td colspan="6" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='/Admin/Order/Quote.aspx?id=<%=qd.QuoteId %>'"/></td></tr>
         </table>
		</td>
    </tr>
  </table>
</form>
</body>
</html>
