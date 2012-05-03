<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveOrderDetail.aspx.cs"
    Inherits="Admin_Order_ReceiveOrderDetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script src="../Js/Common.js" type="text/javascript" language="javascript"></script>
<script src="../Js/ChargeStandard.js" type="text/javascript" language="javascript"></script>
<script src="../Js/util.js" type="text/javascript" language="javascript"></script>
<script src="../Js/jquery-1.2.6.js" type="text/javascript" language="javascript"></script>
<script language="javascript" type="text/javascript">  

function checkFreightForm()
{
    var country = document.getElementById("txtCountry");
    var weight = document.getElementById("txtWeight");
    var count = document.getElementById("txtCount");
    if(country.value.length<=0 || country.value=="请输入国家英文名称")
    {
	    alert("请输入寄达国家！");
	    country.focus();
	    return false;
    }

    if(weight.value.length<=0)
    {
	    alert("请输入重量！");
	    weight.focus();
	    return false;
    }
    else if(isNaN(weight.value))
    {
        alert("重量只能为数字！");
        weight.focus();
        return false;
    }
    else if(parseFloat(weight.value)<0)
    {
        alert("重量不能小于或等于0！");
        weight.focus();
        return false;
    }
    if(count.value.length<=0)
    {
	    alert("请输入数量！");
	    count.focus();
	    return false;
    }
    else if(isNaN(count.value))
    {
        alert("数量只能为数字！");
        count.focus();
        return false;
    }
    else if(parseInt(count.value)<=0 || parseInt(count.value)!=count.value)
    {
        alert("数量只能为大于0的整数！");
        count.focus();
        return false;
    }
    return true;
}

function checkFreightForms()
{   
    var country = document.getElementById("txtCountry");
    var weight = document.getElementById("txtWeight");
    var count = document.getElementById("txtCount"); 
    var carrier=document.getElementById("txtCarrier");
    if(country.value.length<=0 || country.value=="请输入国家英文名称")
    {
	    alert("请输入寄达国家！");
	    country.focus();
	    return false;
    }

    if(weight.value.length<=0)
    {
	    alert("请输入重量！");
	    weight.focus();
	    return false;
    }
    else if(isNaN(weight.value))
    {
        alert("重量只能为数字！");
        weight.focus();
        return false;
    }
    else if(parseFloat(weight.value)<0)
    {
        alert("重量不能小于或等于0！");
        weight.focus();
        return false;
    }
    if(count.value.length<=0)
    {
	    alert("请输入数量！");
	    count.focus();
	    return false;
    }
    else if(isNaN(count.value))
    {
        alert("数量只能为数字！");
        count.focus();
        return false;
    }
    else if(parseInt(count.value)<=0 || parseInt(count.value)!=count.value)
    {
        alert("数量只能为大于0的整数！");
        count.focus();
        return false;
    }
    if(carrier.value.length<=0)
    {
        alert("请选择承运商！");
        return false;
    }
    return true;
}

function checkData(obj)
{
    if(obj.value.length<=0 || isNaN(obj.value))
    {
        obj.value=0;
        getTotalCosts();
    }
}
function checkSpecialData(obj)
{
    var strValue = obj.value.substring(1,obj.value.length);
    if(isNaN(strValue))
    {
        obj.value="-0";
    }
}


function setSubtract(obj, type)
{
    if(obj.value.indexOf('-')==-1)
	    obj.value = "-" + obj.value;

    var index = obj.value.indexOf('-');
    if(index>0) {
	    obj.value = obj.value.substring(index,obj.value.length);
    }
    var p_index = obj.value.indexOf('.');
    if(p_index==1) {
	    obj.value=obj.value.replace(".","");
    }
    getTotalCosts(type);
}

function setAddition(obj, type)
{
    var reg = /^0\d\.?\d*$/;
    if(reg.test(obj.value)) {
	    obj.value = obj.value.substring(1,obj.value.length);
    }
    getTotalCosts(type);
}

function getTotalCosts(type) 
{
    var totalCosts = 0;
    var disposalCosts = $("#txtDisposalCosts").val();
    var registerCosts = $("#txtRegisterCosts").val();
    var fuelCosts = $("#txtFuelCosts").val();
    var postCosts = $("#txtPostCosts").val();
    
    if(type == 1)
    {
        totalCosts = disposalCosts*1 + registerCosts*1 + postCosts*1;
    }
    else if(type == 2)
    {
        var count = $("#txtCount").val();
        var remoteCosts = $("#txtRemoteCosts").val();//偏远附加费
        var fetchCosts = $("#txtFetchCosts").val();
        var materialCosts = $("#txtMaterialCosts").val();
        var otherCosts = $("#txtOtherCosts").val();
        var insureCosts = $("#txtInsureCosts").val();
        var addressChangeCosts = $("#txtAddressChangeCosts").val();
        var returnCosts = $("#txtReturnCosts").val();
        
        var damageMoney = $("#txtDamageMoney").val()=="-"?0:$("#txtDamageMoney").val();//损失与赔偿
        var returnMoney = $("#txtReturnMoney").val()=="-"?0:$("#txtReturnMoney").val();//返利
        
        totalCosts = disposalCosts*1 + registerCosts*1 + fuelCosts*1  + postCosts*1 + remoteCosts*1 + fetchCosts*1 + materialCosts*1 + otherCosts*1 + insureCosts*1 + addressChangeCosts*1 + returnCosts*1 + damageMoney*1 + returnMoney*1;
    }
    totalCosts=Math.round(parseFloat(totalCosts)*1000);
    totalCosts=totalCosts/1000;
    $("#txtTotalCosts").val(totalCosts);    	    
}

function openCountryWindow()
{
    window.open("../../Config/CountryList.aspx","国家列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");    
}     
function openCarrierWindow()
{
    if(checkFreightForm())
    {
        window.open("../../Config/SysCarrierList.aspx?country="+document.getElementById('hdCountry').value+"&weight="+document.getElementById('txtWeight').value+"&type="+document.getElementById('slGoodsType').value+"&count="+document.getElementById('txtCount').value+"&clientId="+document.getElementById('hdClientId').value+"","费用查询","toolbar=no,top=20,left=20,width=950,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
    }
}     

document.onkeypress = function() {
    if(event.keyCode==13)
    {
        document.getElementById("txtBarCode").focus();
        return false;
    }
}  
</script>
</head>
<body>
<form id="formCharge" runat="server">
  <input type='hidden' id="hdClientId" runat="server" />
  <input type="hidden" id="hdCountry" runat="server" />
  <input type="hidden" id="hdCountryBak" runat="server" />
  <input type="hidden" id="hdCarrierEncode" runat="server" />  
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td class="info2"> 业务管理 > 收件审核 > 编辑收件明细</td>
    </tr>
    <tr>
      <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr>
      <td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td>
    </tr>
    <tr>
      <td><table class="grid">
          <tr>
            <td width="9%" class="label"> 抵达国家:</td>
            <td width="25%" class="content"><table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                  <td align="left" width="85%"><input id="txtCountry" type="text" style="width: 100%; color: #555555;" runat="server" readonly="readonly" />
                    </td>
                  <td align="right" width="15%"><input type="image" src="../Images/btn_bg1.gif" onclick="openCountryWindow()" /></td>
                </tr>
              </table></td>
            <td width="12%" class="label"> 物品类别:</td>
            <td width="21%" class="content"><select id="slGoodsType" runat="server" onchange="checkCarrier(2,2)">
                <option value="1">包裹</option>
                <option value="2">文件</option>
              </select>
            </td>
            <td width="10%" class="label"> 计费重量:</td>
            <td width="23%" class="content"><input id="txtWeight" type="text" style="width: 60px" runat="server" value="0" onkeyup="checkCarrier(3,2)"
                                    onclick="this.select();" />
              千克</td>
          </tr>
          <tr>
            <td class="label"> 件&nbsp;&nbsp;&nbsp;&nbsp;数:</td>
            <td class="content"><input id="txtCount" name="txtCount" type="text" style="width: 60px" runat="server"
                                    value="1" onkeyup="checkCarrier(4,2)" onclick="this.select();" />
              件</td>
            <td class="label"> 承 运 商:</td>
            <td class="content"><input id="txtCarrier" type="text" style="width: 200px" runat="server" readonly="readonly" /></td>
            <td class="content" valign="middle" colspan="2" align="left"><input type="image" src="../Images/btn_bg1.gif" onclick="openCarrierWindow()" /></td>
          </tr>
          <tr>
            <td class="label"> 运费合计:</td>
            <td class="content"><input id="txtPostCosts" type="text" style="width: 60px; color: #993333;" runat="server"
                                    readonly="readonly" value="0" />
              元</td>
            <td class="label"> 挂 号 费:</td>
            <td class="content"><input id="txtRegisterCosts" type="text" style="width: 60px; color: #993333;" runat="server"
                                    readonly="readonly" value="0" />
              元</td>
            <td class="label"> 处 理 费:</td>
            <td class="content"><input id="txtDisposalCosts" type="text" style="width: 60px; color: #993333;" runat="server"
                                    readonly="readonly" value="0" />
              元</td>  
          </tr>
          <tr>
            <td class="label"> 燃油附加费:</td>
            <td class="content"><input id="txtFuelCosts" type="text" style="width: 60px; color: #993333;" runat="server"
                                    readonly="readonly" value="0" />
              元</td>  
            <td class="label"> 偏远地区附加费:</td>
            <td class="content"><input id="txtRemoteCosts" type="text" style="width: 60px" runat="server" value="0"
                                    onchange="checkData(this);" onblur="setAddition(this, 2)" onkeypress="return checkPrice(event,this.value)"
                                    onkeyup="setAddition(this, 2)" onclick="this.select()" />
              元</td>
            <td class="label"> 取 件 费:</td>
            <td class="content"><input id="txtFetchCosts" type="text" style="width: 60px" runat="server" value="0"
                                    onchange="checkData(this);" onblur="setAddition(this, 2)" onkeypress="return checkPrice(event,this.value)"
                                    onkeyup="setAddition(this, 2)" onclick="this.select()" />
              元</td>
          </tr>
          <tr>
            <td class="label"> 材 料 费:</td>
            <td class="content"><input id="txtMaterialCosts" type="text" style="width: 60px" runat="server" value="0"
                                    onchange="checkData(this);" onblur="setAddition(this, 2)" onkeypress="return checkPrice(event,this.value)"
                                    onkeyup="setAddition(this, 2)" onclick="this.select()" />
              元</td>
            <td class="label"> 其它费用:</td>
            <td class="content" colspan="3"><input id="txtOtherCosts" type="text" style="width: 60px" runat="server" value="0"
                                    onkeypress="return checkPrice(event,this.value);" onblur="setAddition(this, 2)" onchange="checkData(this);"
                                    onkeyup="setAddition(this, 2)" onclick="this.select()" />
              元&nbsp;&nbsp;费用说明:
              <input id="txtOtherCostsNote" type="text" style="width: 66%;" runat="server" /></td>
          </tr>
          <tr>
            <td class="label"> 保 价 费:</td>
            <td class="content"><input id="txtInsureCosts" type="text" style="width: 60px" runat="server" value="0"
                                    readonly="readonly" onclick="this.select()" />
              元</td>
            <td class="label"> 地址更改费:</td>
            <td class="content"><input id="txtAddressChangeCosts" type="text" style="width: 60px" runat="server"
                                    value="0" onchange="checkData(this);" onkeypress="return checkPrice(event,this.value)"
                                    onkeyup="setAddition(this, 2)" onblur="setAddition(this, 2)" onclick="this.select()" />
              元</td>
            <td class="label"> 退 件 费:</td>
            <td class="content"><input id="txtReturnCosts" type="text" style="width: 60px" runat="server" value="0"
                                    onchange="checkData(this);" onblur="setAddition(this, 2)" onkeypress="return checkPrice(event,this.value)"
                                    onkeyup="setAddition(this, 2)" onclick="this.select()" />
              元</td>
          </tr>
          <tr>
            <td class="label"> 损失与赔偿:</td>
            <td class="content"><input id="txtDamageMoney" type="text" style="width: 60px" runat="server" value="-"
                                    onkeypress="return checkPrice(event,this.value)" onkeyup="setSubtract(this, 2);checkSpecialData(this);"
                                    onclick="this.select()" />
              元</td>
            <td class="label"> 返&nbsp;&nbsp;&nbsp;&nbsp;利:</td>
            <td class="content"><input id="txtReturnMoney" type="text" style="width: 60px" runat="server" value="-"
                                    onkeypress="return checkPrice(event,this.value)" onkeyup="setSubtract(this, 2);checkSpecialData(this);"
                                    onclick="this.select()" />
              元</td>
            <td class="label"> 应收费用:</td>
            <td class="content"><input id="txtTotalCosts" type="text" style="width: 60px; color: Blue;" runat="server"
                                    readonly="readonly" value="0" />
              元</td>
          </tr>          
          <tr>
            <td colspan="6" height="18"></td>
          </tr>
          <tr>
            <td class="label"> 包裹单号:</td>
            <td class="content"><input id="txtBarCode" type="text" style="width: 180px" runat="server" /></td>
            <td class="label">备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content"><asp:TextBox ID="txtRemark" Width="180" runat="server"></asp:TextBox></td>
            <td class="label"> 亿度条码:</td>
            <td class="content" colspan="3"><asp:Label ID="lblYDEncode" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td class="label"> 收件人姓名:</td>
            <td class="content"><input id="txtToUsername" type="text" style="width: 180px" runat="server" /></td>
            <td class="label"> 收件人电话:</td>
            <td class="content"><input id="txtToPhone" type="text" style="width: 180px" runat="server" /></td>
            <td class="label"> 收件人邮箱:</td>
            <td class="content"><input id="txtToEmail" type="text" style="width: 180px" runat="server" /></td>
          </tr>
          <tr>
            <td class="label"> 收件人城市:</td>
            <td class="content"><input id="txtToCity" type="text" style="width: 180px" runat="server" /></td>
            <td class="label"> 收件人国家:</td>
            <td class="content"><input id="txtToCountry" type="text" style="width: 180px" runat="server" readonly="readonly" /></td>
            <td class="label"> 收件人邮编:</td>
            <td class="content"><input id="txtToPostcode" type="text" style="width: 180px" runat="server" /></td>
          </tr>          
          <tr>
            <td class="label"> 收件人详址:</td>
            <td class="content" colspan="5"><input id="txtToAddress" type="text" style="width: 98%" runat="server" /></td>
          </tr>
          <tr>
            <td colspan="6" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClientClick="return checkFreightForm()"
                                    OnClick="btnUpdate_Click" />
              &nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnDelete" runat="server"
                                        CssClass="button" Text="删 除" OnClientClick="return confirm('您确认要删除？');" OnClick="btnDelete_Click" />
              &nbsp;&nbsp;&nbsp;
              <input
                                            type="button" class="button" value="返 回" onclick="javascript:location.href='AuditOrder.aspx?id=<%=order.Id %>'" /></td>
          </tr>
        </table></td>
    </tr>
  </table>
</form>
</body>
</html>
