<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargeStandard.aspx.cs" Inherits="Admin_PostSetting_ChargeStandard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">

function setTextBoxValue(strName)
{
    var clientDiscount=document.getElementById("clientDiscount").value;
    var angencyDiscount=document.getElementById("angencyDiscount").value;
    var encode=document.getElementsByName("hiEncode");
    for(var i=0;i<encode.length;i++)
    {
        var psNormal = document.getElementById("rpChargeStandard_ctl0" + i + "_txtNormal" + strName);
        var psClient = document.getElementById("rpChargeStandard_ctl0" + i + "_txtClient" + strName);
        var psSelf = document.getElementById("rpChargeStandard_ctl0" + i + "_txtSelf" + strName);
        
        psClient.value=psNormal.value*clientDiscount;
        psSelf.value=psNormal.value*angencyDiscount;
    }
}

function setNormalTextBoxValue(strName)
{
    var clientDiscount=document.getElementById("clientDiscount").value;
    var angencyDiscount=document.getElementById("angencyDiscount").value;
    var encode=document.getElementsByName("hiEncode");
    for(var i=0;i<encode.length;i++)
    {
        var psNormal = document.getElementById("rpChargeStandard_ctl0" + i + "_txtNormal" + strName);
        var psClient = document.getElementById("rpChargeStandard_ctl0" + i + "_txtClient" + strName);
        var psSelf = document.getElementById("rpChargeStandard_ctl0" + i + "_txtSelf" + strName);
        
        psClient.value=psNormal.value;
        psSelf.value=psNormal.value;
    }
}

function setCreateTextBoxValue(strName)
{
    var clientDiscount=document.getElementById("clientDiscount").value;
    var angencyDiscount=document.getElementById("angencyDiscount").value;
    var psNormal = document.getElementById("txtNormal" + strName);
    var psClient = document.getElementById("txtClient" + strName);
    var psSelf = document.getElementById("txtSelf" + strName);
    
    psClient.value=psNormal.value*clientDiscount;
    psSelf.value=psNormal.value*angencyDiscount;
}

function setNormalCreateTextBoxValue(strName)
{
    var clientDiscount=document.getElementById("clientDiscount").value;
    var angencyDiscount=document.getElementById("angencyDiscount").value;
    var psNormal = document.getElementById("txtNormal" + strName);
    var psClient = document.getElementById("txtClient" + strName);
    var psSelf = document.getElementById("txtSelf" + strName);
    
    psClient.value=psNormal.value;
    psSelf.value=psNormal.value;
}
</script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:PostSettingNav ID="postSettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 承运商设定 > 承运商分区 > 分区收费标准</td>
    </tr>
    <tr>
        <td class="info">承运商：<asp:Label ID="lblCarrier" runat="server" Text="" ForeColor="maroon"></asp:Label>&nbsp;&nbsp;&nbsp;分区名称：<asp:Label ID="lblCarrierArea" runat="server" Text="" ForeColor="maroon"></asp:Label></td>
    </tr>    
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
          <tr>
            <td align="center" class="headers" colspan="5">重量信息(千克)</td>
            <td align="center" class="headers" colspan="5" style="background-color:#EECCE6;">标准报价(元)</td>
            <td align="center" class="headers" colspan="5" style="background-color:#F4FDCC;">卖出价(元)</td>
            <td align="center" class="headers" colspan="5" style="background-color:#DCF3FC;">结算价(元)</td>
            <td align="center" class="headers" colspan="3" ><input type="hidden" id="clientDiscount" value="<%=clientDiscount %>" /><input type="hidden" id="angencyDiscount" value="<%=angencyDiscount %>" /></td>
          </tr>
          <tr class="label">
            <td align="center">序号</td>
            <td align="center">开始</td>
            <td align="center">结束</td>
            <td align="center">首重</td>
            <td align="center">递增</td>
            <td align="center" style="background-color:#EECCE6;">首重价</td>
            <td align="center" style="background-color:#EECCE6;">续重价</td>
            <td align="center" style="background-color:#EECCE6;">每KG价</td>
            <td align="center" style="background-color:#EECCE6;">处理费</td>
            <td align="center" style="background-color:#EECCE6;">挂号费</td>
            <td align="center" style="background-color:#F4FDCC;">首重价</td>
            <td align="center" style="background-color:#F4FDCC;">续重价</td>
            <td align="center" style="background-color:#F4FDCC;">每KG价</td>
            <td align="center" style="background-color:#F4FDCC;">处理费</td>
            <td align="center" style="background-color:#F4FDCC;">挂号费</td>
            <td align="center" style="background-color:#DCF3FC;">首重价</td>
            <td align="center" style="background-color:#DCF3FC;">续重价</td>
            <td align="center" style="background-color:#DCF3FC;">每KG价</td>
            <td align="center" style="background-color:#DCF3FC;">处理费</td>
            <td align="center" style="background-color:#DCF3FC;">挂号费</td>
            <td align="center">让利克数</td>
            <td align="center">类型</td>
            <td align="center">选择</td>
          </tr>
          <asp:Repeater ID="rpChargeStandard" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><asp:Label ID="lblEncode" runat="server"></asp:Label><input type="hidden" id="hiEncode<%# Eval("Encode") %>" name="hiEncode" value="<%# Eval("Encode") %>" /></td>
                <td align="center"><asp:TextBox ID="txtStartWeight" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtEndWeight" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtBaseWeight" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtIncreaseWeight" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtNormalBasePrice" runat="server" Width="34" onKeyUp="setTextBoxValue('BasePrice')"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtNormalContinuePrice" runat="server" Width="34" onKeyUp="setTextBoxValue('ContinuePrice')"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtNormalKgPrice" runat="server" Width="34" onKeyUp="setTextBoxValue('KgPrice')"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtNormalDisposalCost" runat="server" Width="28" onKeyUp="setNormalTextBoxValue('DisposalCost')"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtNormalRegisterCost" runat="server" Width="28" onKeyUp="setTextBoxValue('RegisterCost')"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtClientBasePrice" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtClientContinuePrice" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtClientKgPrice" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtClientDisposalCost" runat="server" Width="28"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtClientRegisterCost" runat="server" Width="28"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtSelfBasePrice" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtSelfContinuePrice" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtSelfKgPrice" runat="server" Width="34"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtSelfDisposalCost" runat="server" Width="28"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtSelfRegisterCost" runat="server" Width="28"></asp:TextBox></td>
                <td align="center"><asp:TextBox ID="txtPreferentialGram" runat="server" Width="24"></asp:TextBox></td>
                <td align="center"><wl:GoodsTypeDropDownList ID="ddlGoodsType" runat="server"></wl:GoodsTypeDropDownList></td>   
                <td align="center"><input type="checkbox" id="chkId" name="chkId" value="<%# Eval("Id") %>" /></td>
              </tr>
            </ItemTemplate>            
          </asp:Repeater>
          <tr>
            <td align="center" colspan="22">
                <asp:Button ID="btnUpdate" CssClass="button" runat="server" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" CssClass="button" runat="server" Text="删除选择项" OnClick="btnDelete_Click" /></td>
          </tr>       
          <tr class="label">
            <td></td>
            <td align="center"><asp:TextBox ID="txtStartWeight" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtEndWeight" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtBaseWeight" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtIncreaseWeight" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtNormalBasePrice" runat="server" Width="34" Text="0" onclick="this.select()" onKeyUp="setCreateTextBoxValue('BasePrice')"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtNormalContinuePrice" runat="server" Width="34" Text="0" onclick="this.select()" onKeyUp="setCreateTextBoxValue('ContinuePrice')"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtNormalKgPrice" runat="server" Width="34" Text="0" onclick="this.select()" onKeyUp="setCreateTextBoxValue('KgPrice')"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtNormalDisposalCost" runat="server" Width="28" Text="0" onclick="this.select()" onKeyUp="setNormalCreateTextBoxValue('DisposalCost')"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtNormalRegisterCost" runat="server" Width="28" Text="0" onclick="this.select()" onKeyUp="setCreateTextBoxValue('RegisterCost')"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtClientBasePrice" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtClientContinuePrice" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtClientKgPrice" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtClientDisposalCost" runat="server" Width="28" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtClientRegisterCost" runat="server" Width="28" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtSelfBasePrice" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtSelfContinuePrice" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtSelfKgPrice" runat="server" Width="34" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtSelfDisposalCost" runat="server" Width="28" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtSelfRegisterCost" runat="server" Width="28" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><asp:TextBox ID="txtPreferentialGram" runat="server" Width="24" Text="0" onclick="this.select()"></asp:TextBox></td>
            <td align="center"><wl:GoodsTypeDropDownList ID="ddlGoodsType" runat="server"></wl:GoodsTypeDropDownList></td>   
            <td></td>
          </tr>            
          <tr>
            <td align="center" colspan="23">
                <asp:Button ID="btnCreate" CssClass="button" runat="server" Text="添 加" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" id="btnBack" onclick="javascript:location.href='CarrierAreaList.aspx?id=<%=carrier.Id %>';" /></td>
          </tr>
        </table>	
        </td>
    </tr>
  </table>
</form>
</body>
</html>

