<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysCarrierList.aspx.cs" Inherits="Config_SysCarrierList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>承运商选择</title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info"></td>
    </tr>
  </table>
  <table class="tablecontent">
     <tr>
      <td><table class="grid" id="tblCarrier">
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
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';" onclick="setCarrier(this.rowIndex-1);">
                    <td align="center"><%=cc.Carrier.Encode%><input type="hidden" name="hdCarrierEncode" value="<%=cc.Carrier.Encode %>" /></td>
                    <td align="center"><%=cc.Carrier.Name%><input type="hidden" name="hdCarrierName" value="<%=cc.Carrier.Name %>" /></td>          
                    <td align="center"><%=cc.CarrierArea.Name%></td>
                    <td align="center"><%=cc.ChargeStandard.ClientBasePrice%></td> 
                    <td align="center"><%=cc.ChargeStandard.ClientContinuePrice%></td> 
                    <td align="center"><%=cc.ChargeStandard.ClientKgPrice%></td> 
                    <td align="center"><%=cc.ChargeStandard.ClientDisposalCost%><input type="hidden" name="hdClientDisposalCost"            value="<%=cc.ChargeStandard.ClientDisposalCost %>" /></td> 
                    <td align="center"><%=cc.ChargeStandard.ClientRegisterCost%><input type="hidden" name="hdClientRegisterCost"            value="<%=cc.ChargeStandard.ClientRegisterCost %>" /></td> 
                    <td align="center"><%=cc.ClientPostCost*cc.Carrier.FuelSgRate%><input type="hidden" name="hdClientFuelCost"         value="<%=cc.ClientPostCost*cc.Carrier.FuelSgRate %>" /></td> 
                    <td align="center"><%=Backend.Utilities.EnumConvertor.GoodsTypeConvertToString(cc.ChargeStandard.GoodsType)%></td> 
                    <td align="center"><%=cc.ClientTotalCost%><input type="hidden" name="hdClientPostCost" value="<%=cc.ClientPostCost %>" /></td>                                         
                  </tr> 
              <%  }
              }%>       
              <tr id="trMsg" runat="server" visible="false"><td colspan="10" align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label></td></tr>
            </table>	
<script language="javascript" type="text/javascript">
function setCarrier(index)
{           
    var hdCarrierName = document.getElementsByName("hdCarrierName");
    var hdCarrierEncode = document.getElementsByName("hdCarrierEncode");
    
    var hdClientDisposalCost = document.getElementsByName("hdClientDisposalCost");
    var hdClientRegisterCost = document.getElementsByName("hdClientRegisterCost");
    var hdClientPostCost = document.getElementsByName("hdClientPostCost");
    var hdClientFuelCost = document.getElementsByName("hdClientFuelCost");
    
    var disposalCost = parseFloat(hdClientDisposalCost[index].value);
    var registerCost = parseFloat(hdClientRegisterCost[index].value);
    var clientPostCost = parseFloat(hdClientPostCost[index].value);
    var fuelCost = parseFloat(hdClientFuelCost[index].value);
        
    opener.document.getElementById("txtCarrier").value = hdCarrierName[index].value;
    opener.document.getElementById("hdCarrierEncode").value = hdCarrierEncode[index].value;
    
    
    opener.document.getElementById("txtPostCosts").value = clientPostCost;    
    opener.document.getElementById("txtRegisterCosts").value = registerCost;
    opener.document.getElementById("txtDisposalCosts").value = disposalCost; 
    opener.document.getElementById("txtFuelCosts").value = fuelCost;   
            
    opener.getTotalCosts(2);
    self.close();
}
</script>	
		</td>
    </tr>
  </table>
</form>
</body>
</html>