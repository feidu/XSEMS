<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_DataQuery_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<link href="../Css/DivPopup.css" rel="stylesheet" type="text/css" />
<script src="../Js/Common.js" type="text/javascript" language="javascript"></script>
<script language="javascript" type="text/javascript">
function openCountryWindow()
{
    window.open("../../Config/CountryList.aspx","国家列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
}    
</script>
</head>
<body>
<form id="form1" runat="server">   
  <input type="hidden" id="hdCountry" runat="server" />
  <input type="hidden" id="txtToCountry" runat="server" />
  <input type="Hidden" id="txtCarrier" runat="server" />
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">数据查询 > 收费查询</td>
    </tr>
    <tr>
        <td class="info"><table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td width="230">寄达国家：<input id="txtCountry" type="text" style="width:160px;color:#555555;" runat="server" readonly="readonly"/></td><td valign="middle"><input type="image" src="../Images/btn_bg1.gif" onclick="openCountryWindow()" /></td>
                      <td>&nbsp;&nbsp;物品类型：<wl:GoodsTypeDropDownList ID="ddlGoodsType" name="ddlGoodsType" runat="server"></wl:GoodsTypeDropDownList>&nbsp;&nbsp;&nbsp;</td>
                      <td>物品重量：<input id="txtWeight" name="txtWeight" type="text" style="width:68px" runat="server" />千克&nbsp;&nbsp;&nbsp;</td>                      
                      <td>件数：<input id="txtCount" name="txtCount" type="text" style="width:68px" runat="server"  value="1"/>件&nbsp;&nbsp;&nbsp;</td>
                      <td><asp:Button ID="btnSearch" runat="server" CssClass="button" Text="查 询" OnClientClick="return checkFreightForm()" OnClick="btnSearch_Click" /></td></tr></table></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr>
      <td><table class="grid">
              <tr>
                <th align="center" class="header">承运商编号</th>
                <th align="center" class="header">承运商名称</th>           
                <th align="center" class="header">地区</th>   
                <th align="center" class="header">首重价</th>        
                <th align="center" class="header">续重价</th>
                <th align="center" class="header">每KG价</th>
                <th align="center" class="header">处理费</th>
                <th align="center" class="header">挂号费</th>
                <th align="center" class="header">燃油附加费</th>
                <th align="center" class="header">类型</th>
                <th align="center" class="header">金额</th>
              </tr>
              <%if (result != null)
                {
                    foreach (Backend.Models.CarrierCharge cc in result)
                    {
                    %> 
              
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';" >
                    <td align="center"><%=cc.Carrier.Encode%></td>
                    <td align="center"><%=cc.Carrier.Name%></td>          
                    <td align="center"><%=cc.CarrierArea.Name%></td>
                    <td align="center"><%=cc.ChargeStandard.ClientBasePrice%></td> 
                    <td align="center"><%=cc.ChargeStandard.ClientContinuePrice%></td> 
                    <td align="center"><%=cc.ChargeStandard.ClientKgPrice%></td> 
                    <td align="center"><%=cc.ChargeStandard.ClientDisposalCost%></td> 
                    <td align="center"><%=cc.ChargeStandard.ClientRegisterCost%></td> 
                    <td align="center"><%=cc.ClientPostCost*cc.Carrier.FuelSgRate%></td> 
                    <td align="center"><%=Backend.Utilities.EnumConvertor.GoodsTypeConvertToString(cc.ChargeStandard.GoodsType)%></td> 
                    <td align="center"><%=cc.ClientTotalCost%></td>                                         
                  </tr> 
              <%  }
              } %>       
              <tr id="trMsg" runat="server" visible="false"><td colspan="11" align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label></td></tr>
            </table>		
		</td>
    </tr>
  </table>
</form>
</body>
</html>

