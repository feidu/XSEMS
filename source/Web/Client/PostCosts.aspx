<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostCosts.aspx.cs" Inherits="Client_PostCosts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../Admin/Js/Common.js"></script>
<script language="javascript" type="text/javascript">
function openCountryWindow()
{
    window.open("../Config/CountryList.aspx","国家列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
}    
</script>
</head>
<body>
<center>
<form id="form1" runat="server">
  <input type="hidden" id="hdCountry" runat="server" />
  <input type="hidden" id="txtToCountry" runat="server" />
  <input type="Hidden" id="txtCarrier" runat="server" />
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
                <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="费用计算"></wl:ClientTop> </td></tr>  
                <tr><td align="left" valign="bottom" style="padding-left:5px;"><table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td width="230">寄达国家：<input id="txtCountry" type="text" style="width:160px;color:#555555;" runat="server" readonly="readonly"/></td><td valign="middle"><input type="image" src="/Admin/Images/btn_bg1.gif" onclick="openCountryWindow()" /></td>
                          <td>&nbsp;&nbsp;物品类型：<wl:GoodsTypeDropDownList ID="ddlGoodsType" name="ddlGoodsType" runat="server"></wl:GoodsTypeDropDownList>&nbsp;&nbsp;&nbsp;</td>
                          <td>物品重量：<input id="txtWeight" name="txtWeight" type="text" style="width:46px" runat="server" />千克&nbsp;&nbsp;&nbsp;</td>
                          <td>物品数量：<input name="txtCount" id="txtCount" type="text" style="width:46px" runat="server"/>件&nbsp;&nbsp;&nbsp;</td>
                          <td><asp:Button ID="btnSubmit" runat="server" Text="计 算" CssClass="button" OnClientClick="return checkFreightForm()" OnClick="btnSubmit_Click"/></td></tr></table></td></tr>
                 <tr>
                  <td><table class="grid" id="tblCarrier">
                          <tr>
                            <th align="center" class="header_client">承运商编号</th>
                            <th align="center" class="header_client">承运商名称</th>           
                            <th align="center" class="header_client">地区</th>   
                            <th align="center" class="header_client">首重价</th>        
                            <th align="center" class="header_client">续重价</th>
                            <th align="center" class="header_client">每KG价</th>
                            <th align="center" class="header_client">处理费</th>
                            <th align="center" class="header_client">挂号费</th>
                            <th align="center" class="header_client">燃油附加费</th>
                            <th align="center" class="header_client">类型</th>
                            <th align="center" class="header_client">金额</th>
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
                                <td align="center"><%=Backend.Utilities.StringHelper.CurtNumber(cc.ChargeStandard.ClientBasePrice.ToString())%></td> 
                                <td align="center"><%=Backend.Utilities.StringHelper.CurtNumber(cc.ChargeStandard.ClientContinuePrice.ToString())%></td> 
                                <td align="center"><%=Backend.Utilities.StringHelper.CurtNumber(cc.ChargeStandard.ClientKgPrice.ToString())%></td> 
                                <td align="center"><%=Backend.Utilities.StringHelper.CurtNumber(cc.ChargeStandard.ClientDisposalCost.ToString())%></td> 
                                <td align="center"><%=Backend.Utilities.StringHelper.CurtNumber(cc.ChargeStandard.ClientRegisterCost.ToString())%></td> 
                                <td align="center"><%=Backend.Utilities.StringHelper.CurtNumber((cc.ClientPostCost * cc.Carrier.FuelSgRate).ToString())%></td> 
                                <td align="center"><%=Backend.Utilities.EnumConvertor.GoodsTypeConvertToString(cc.ChargeStandard.GoodsType)%></td> 
                                <td align="center"><%=cc.ClientTotalCost%></td>                                         
                              </tr> 
                          <%  }
                          } %>       
                          <tr id="trMsg" runat="server" visible="false"><td colspan="10" align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label></td></tr>
                        </table>	

	                </td>
                </tr>
              </table>              
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
