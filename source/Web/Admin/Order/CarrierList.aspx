<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarrierList.aspx.cs" Inherits="Admin_Order_CarrierList" %>

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
        <td class="info2">业务管理 > 收件计划 > 添加收件明细 > 承运商选择</td>
    </tr>
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
                <th align="center" class="header">类型</th>
                <th align="center" class="header">金额<input type="hidden" id="hdWeight" name="weight" value="<%=weight %>" /><input type="hidden" id="hdCount" name="count" value="<%=count %>" /><input type="hidden" id="hdCountry" name="count" value="<%=countryName %>" /></th>
              </tr>
              <%if (result != null)
                {
                    foreach (Backend.Models.CarrierCharge cc in result)
                    {
                    %>               
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';" onclick="setCarrier(this.rowIndex-1);">
                    <td align="center"><%=cc.Carrier.Encode%><input type="hidden" name="hdEncode" value="<%=cc.Carrier.Encode %>" /></td>
                    <td align="center"><%=cc.Carrier.Name%><input type="hidden" name="hdCarrierName" value="<%=cc.Carrier.Name %>" /><input type="hidden" name="hdCarrierEncode" value="<%=cc.Carrier.Encode %>" /></td>          
                    <td align="center"><%=cc.CarrierArea.Name%><input type="hidden" name="hdIncreaseWeight" value="<%=cc.ChargeStandard.IncreaseWeight %>" /></td>
                    <td align="center"><%=cc.ChargeStandard.NormalBasePrice%><input type="hidden" name="hdClientBasePrice" value="<%=cc.ChargeStandard.NormalBasePrice %>" /><input type="hidden" name="hdSelfBasePrice" value="<%=cc.ChargeStandard.SelfBasePrice %>" /></td> 
                    <td align="center"><%=cc.ChargeStandard.NormalContinuePrice%><input type="hidden" name="hdClientContinuePrice" value="<%=cc.ChargeStandard.NormalContinuePrice %>" /><input type="hidden" name="hdSelfContinuePrice" value="<%=cc.ChargeStandard.SelfContinuePrice %>" /></td> 
                    <td align="center"><%=cc.ChargeStandard.NormalKgPrice%><input type="hidden" name="hdClientKgPrice" value="<%=cc.ChargeStandard.NormalKgPrice %>" /><input type="hidden" name="hdSelfKgPrice" value="<%=cc.ChargeStandard.SelfKgPrice %>" /></td> 
                    <td align="center"><%=cc.ChargeStandard.NormalDisposalCost%><input type="hidden" name="hdClientDisposalCost" value="<%=cc.ChargeStandard.NormalDisposalCost %>" /><input type="hidden" name="hdSelfDisposalCost" value="<%=cc.ChargeStandard.SelfDisposalCost %>" /></td> 
                    <td align="center"><%=cc.ChargeStandard.NormalRegisterCost%><input type="hidden" name="hdClientRegisterCost" value="<%=cc.ChargeStandard.NormalRegisterCost %>" /><input type="hidden" name="hdSelfRegisterCost" value="<%=cc.ChargeStandard.SelfRegisterCost %>" /></td> 
                    <td align="center"><%=Backend.Utilities.EnumConvertor.GoodsTypeConvertToString(cc.ChargeStandard.GoodsType)%></td> 
                    <td align="center"><%=cc.ClientTotalCost%><input type="hidden" name="hdClientPostCost" value="<%=cc.ClientPostCost %>" /><input type="hidden" name="hdSelfPostCost" value="<%=cc.ClientPostCost %>" /><input type="hidden" name="hdClientTotalCost" value="<%=cc.ClientTotalCost %>" /><input type="hidden" name="hdSelfTotalCost" value="<%=cc.ClientTotalCost %>" /></td>                                         
                  </tr> 
              <%  }
              }%>       
              <tr id="trMsg" runat="server" visible="false"><td colspan="10" align="center"><asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label></td></tr>
            </table>	
<script language="javascript" type="text/javascript">
function setCarrier(index)
{   
    var totalPrice = 0;
    var weight = document.getElementById("hdWeight").value;
    var count = document.getElementById("hdCount").value;
    var country = document.getElementById("hdCountry").value;
        
    var hdCarrierName = document.getElementsByName("hdCarrierName");
    var hdCarrierEncode = document.getElementsByName("hdCarrierEncode");
    var hdIncreaseWeight = document.getElementsByName("hdIncreaseWeight");
    var hdClientPostCost = document.getElementsByName("hdClientPostCost");
    var hdClientTotalCost = document.getElementsByName("hdClientTotalCost");
    
    var hdClientBasePrice = document.getElementsByName("hdClientBasePrice");
    var hdClientContinuePrice = document.getElementsByName("hdClientContinuePrice");
    var hdClientKgPrice = document.getElementsByName("hdClientKgPrice");
    var hdClientDisposalCost = document.getElementsByName("hdClientDisposalCost");
    var hdClientRegisterCost = document.getElementsByName("hdClientRegisterCost");
    
    var hdSelfBasePrice = document.getElementsByName("hdSelfBasePrice");
    var hdSelfContinuePrice = document.getElementsByName("hdSelfContinuePrice");
    var hdSelfKgPrice = document.getElementsByName("hdSelfKgPrice");
    var hdSelfDisposalCost = document.getElementsByName("hdSelfDisposalCost");
    var hdSelfRegisterCost = document.getElementsByName("hdSelfRegisterCost");
    
    var disposalCost = parseFloat(hdClientDisposalCost[index].value);
    var registerCost = parseFloat(hdClientRegisterCost[index].value);
    var clientPostCost = parseFloat(hdClientPostCost[index].value);
    var clientTotalCost = parseFloat(hdClientTotalCost[index].value);
        
    opener.document.getElementById("txtCarrier").value = hdCarrierName[index].value;
    
    opener.document.getElementById("txtPostCosts").value = clientPostCost;
    opener.document.getElementById("txtTotalCosts").value = clientTotalCost;
    opener.document.getElementById("hdTotalCosts").value = clientTotalCost;
    opener.document.getElementById("txtKgPrice").value = hdClientKgPrice[index].value;
    opener.document.getElementById("txtRegisterCosts").value = hdClientRegisterCost[index].value;
    opener.document.getElementById("txtDisposalCosts").value = hdClientDisposalCost[index].value;
    
    opener.document.getElementById("txtToCountry").value = country;
    
    opener.document.getElementById("hdCarrierEncode").value = hdCarrierEncode[index].value;
    opener.document.getElementById("hdIncreaseWeight").value = hdIncreaseWeight[index].value;
    
    opener.document.getElementById("hdClientBasePrice").value = hdClientBasePrice[index].value;
    opener.document.getElementById("hdClientContinuePrice").value = hdClientContinuePrice[index].value;
    opener.document.getElementById("hdClientKgPrice").value = hdClientKgPrice[index].value;
    opener.document.getElementById("hdClientDisposalCost").value = hdClientDisposalCost[index].value;
    opener.document.getElementById("hdClientRegisterCost").value = hdClientRegisterCost[index].value;
    opener.document.getElementById("hdSelfBasePrice").value = hdSelfBasePrice[index].value;
    opener.document.getElementById("hdSelfContinuePrice").value = hdSelfContinuePrice[index].value;
    opener.document.getElementById("hdSelfKgPrice").value = hdSelfKgPrice[index].value;
    opener.document.getElementById("hdSelfDisposalCost").value = hdSelfDisposalCost[index].value;
    opener.document.getElementById("hdSelfRegisterCost").value = hdSelfRegisterCost[index].value;
    
    self.close();
}
</script>	
		</td>
    </tr>
  </table>
</form>
</body>
</html>
