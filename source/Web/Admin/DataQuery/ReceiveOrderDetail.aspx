<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveOrderDetail.aspx.cs" Inherits="Admin_DataQuery_ReceiveOrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<link href="../Css/DivPopup.css" rel="stylesheet" type="text/css" />
<script src="../Js/ChargeStandard.js" type="text/javascript" language="javascript"></script>
<script src="../Js/util.js" type="text/javascript" language="javascript"></script>
<script src="../Js/jquery-1.2.6.js" type="text/javascript" language="javascript"></script>

<script language="javascript" type="text/javascript">  
var oInputField; //考虑到很多函数中都要使用  
var oPopDiv;    //因此采用全局变量的形式  
var oColorsUl;  
var xmlHttp;  
var hdCountry;
function createXMLHttpRequest() {  
    if (window.ActiveXObject)  
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");  
    else if (window.XMLHttpRequest)  
        xmlHttp = new XMLHttpRequest();  
}  
function initVars() {  
    //初始化变量  
    oInputField = document.getElementById("txtCountry");  
    oPopDiv = document.getElementById("popup");  
    oColorsUl = document.getElementById("colors_ul");  
    hdCountry = document.getElementById("hdCountry");
}  
function clearColors() {  
    //清除提示内容  
    for (var i = oColorsUl.childNodes.length - 1; i >= 0; i--)  
        oColorsUl.removeChild(oColorsUl.childNodes[i]);  
    oPopDiv.className = "hide";  
}  
function hideColors() {  
    oPopDiv.className = "hide";  
}
function setColors(the_colors) {  
    //显示提示框，传入的参数即为匹配出来的结果组成的数组  
    clearColors(); //每输入一个字母就先清除原先的提示，再继续  
    oPopDiv.className = "show";  
    var oLi;  
    for (var i = 0; i < the_colors.length; i++) {  
        //将匹配的提示结果逐一显示给用户  
        oLi = document.createElement("li");  
        oColorsUl.appendChild(oLi);  
        oLi.appendChild(document.createTextNode(the_colors[i]));  

        oLi.onmouseover = function() {  
            this.className = "mouseOver"; //鼠标经过时高亮  
        }  
        oLi.onmouseout = function() {  
            this.className = "mouseOut"; //离开时恢复原样  
        }  
        oLi.onclick = function() {  
            //用户点击某个匹配项时，设置输入框为该项的值  
            oInputField.value = this.firstChild.nodeValue;  
            hdCountry.value = this.firstChild.nodeValue;
            searchCarriers(1, 2);
            clearColors(); //同时清除提示框  
        }  
    }          
}  
function findColors() {  
    initVars();     //初始化变量  
    if (oInputField.value.length > 0) {  
        createXMLHttpRequest();     //将用户输入发送给服务器  
        var sUrl = "/Config/CountryBackend.aspx?sColor=" +escape(oInputField.value) + "&timestamp=" + new Date().getTime();  
        xmlHttp.open("GET", sUrl, true);  
        xmlHttp.onreadystatechange = function() {  
            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {  
                var aResult = new Array();  
                if (xmlHttp.responseText.length) {  
                    aResult = xmlHttp.responseText.split(",");  
                    setColors(aResult); //显示服务器结果  
                }  
                else  
                    clearColors();  
            }  
        }  
        xmlHttp.send(null);  
    }  
    else  
        clearColors(); //无输入时清除提示框（例如用户按del键）  
}  

function clearText()
{
    var oInputField = document.getElementById("txtCountry");
    if(oInputField.value=="请输入国家英文名称")
    {
        oInputField.value="";
    }
}

function repalyText()
{
    var oInputField = document.getElementById("txtCountry");
    if(oInputField.value=="")
    {
        oInputField.value="请输入国家英文名称";
    }
}


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
    else if(parseFloat(weight.value)<=0)
    {
        alert("重量不能小于或等于0！");
        weight.focus();
        weight.value="";
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
    else if(parseFloat(weight.value)<=0)
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
    var postCosts = $("#txtPostCosts").val();
    
    if(type == 1)
    {
        totalCosts = disposalCosts*1 + registerCosts*1 + postCosts*1;
    }
    else if(type == 2)
    {
        var remoteCosts = $("#txtRemoteCosts").val();//偏远附加费
        var fetchCosts = $("#txtFetchCosts").val();
        var materialCosts = $("#txtMaterialCosts").val();
        var otherCosts = $("#txtOtherCosts").val();
        var insureCosts = $("#txtInsureCosts").val();
        var addressChangeCosts = $("#txtAddressChangeCosts").val();
        var returnCosts = $("#txtReturnCosts").val();
        
        var damageMoney = $("#txtDamageMoney").val()=="-"?0:$("#txtDamageMoney").val();//损失与赔偿
        var returnMoney = $("#txtReturnMoney").val()=="-"?0:$("#txtReturnMoney").val();//返利
        
        totalCosts = disposalCosts*1 + registerCosts*1 + postCosts*1 + remoteCosts*1 + fetchCosts*1 + materialCosts*1 + otherCosts*1 + insureCosts*1 + addressChangeCosts*1 + returnCosts*1 + damageMoney*1 + returnMoney*1;
    }
    totalCosts=Math.round(parseFloat(totalCosts)*100);
    totalCosts=totalCosts/100;
    $("#txtTotalCosts").val(totalCosts);    	    
}

function openCountryWindow()
{
    window.open("/Admin/Order/CountryList.aspx","国家列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
}     
function openCarrierWindow()
{
    if(checkFreightForm())
    {
        window.open("/Admin/Order/CarrierList.aspx?country="+document.getElementById('hdCountry').value+"&weight="+document.getElementById('txtWeight').value+"&type="+document.getElementById('slGoodsType').value+"&count="+document.getElementById('txtCount').value+"&clientId="+document.getElementById('hdClientId').value+"","费用查询","toolbar=no,top=20,left=20,width=950,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
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
  <input type="hidden" id="hdIncreaseWeight" runat="server" />
  <input type="hidden" id="hdClientBasePrice" runat="server" />
  <input type="hidden" id="hdClientContinuePrice" runat="server" />
  <input type="hidden" id="hdClientKgPrice" runat="server" />
  <input type="hidden" id="hdClientDisposalCost" runat="server"/>
  <input type="hidden" id="hdClientRegisterCost" runat="server" />
  <input type="hidden" id="hdSelfBasePrice" runat="server" />
  <input type="hidden" id="hdSelfContinuePrice" runat="server" />
  <input type="hidden" id="hdSelfKgPrice" runat="server" />
  <input type="hidden" id="hdSelfDisposalCost" runat="server" />
  <input type="hidden" id="hdSelfRegisterCost" runat="server" />
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">数据查询 > 收件查询 > 收件明细</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
     <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
     <tr>
      <td><table class="grid">
          <tr>
            <td width="9%" class="label" >抵达国家:</td>
            <td width="25%" class="content"><table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td align="left" width="85%"><input id="txtCountry" type="text" style="width:100%;color:#555555;" runat="server" onkeyup="findColors();" value="请输入国家英文名称" onfocus="clearText()" onblur="repalyText()" /><div id="popup" style="width:187px; position:absolute; left:107px; top:94px;" class="hide">  
                            <ul id="colors_ul" style="padding-left:2px; background-color:White; float:left; width:184px;">  
                            </ul>  
                        </div></td><td align="right" width="15%"><input type="image" src="../Images/btn_bg1.gif" onclick="openCountryWindow()" /></td></tr></table>
                      </td>
            <td width="12%" class="label" >物品类别:</td>
            <td width="21%" class="content"><select id="slGoodsType" runat="server" onchange="checkCarrier(2,2)"><option value="1">包裹</option><option value="2">文件</option></select></td>
            <td width="10%" class="label" >计费重量:</td>
            <td width="23%" class="content"><input id="txtWeight" type="text" style="width:60px" runat="server" value="0" onkeyup="checkCarrier(3,2)" onclick="this.select();" /> 千克</td>
          </tr>
          <tr>
            <td class="label">件&nbsp;&nbsp;&nbsp;&nbsp;数:</td>
            <td class="content"><input id="txtCount" name="txtCount" type="text" style="width:60px" runat="server"  value="1" onkeyup="checkCarrier(4,2)" onclick="this.select();"/> 件</td>
            <td class="label">承 运 商:</td>
            <td class="content"><input id="txtCarrier" type="text" style="width:200px" runat="server" readonly="readonly" /></td>
            <td valign="middle" colspan="2" align="left"><input type="image" src="../Images/btn_bg1.gif" onclick="openCarrierWindow()" /></td>
          </tr>
          <tr>
            <td class="label" >每千克价:</td>
            <td class="content"><input id="txtKgPrice" type="text" style="width:60px; color:#993333;" runat="server" readonly="readonly" value="0"/> 元</td>
            <td class="label" >运费合计:</td>
            <td class="content"><input id="txtPostCosts" type="text" style="width:60px; color:#993333;" runat="server" readonly="readonly" value="0" /> 元</td>
            <td class="label" >挂 号 费:</td>
            <td class="content"><input id="txtRegisterCosts" type="text" style="width:60px; color:#993333;" runat="server" readonly="readonly" value="0" /> 元</td>                
          </tr>
          <tr>
            <td class="label">处 理 费:</td>
            <td class="content"><input id="txtDisposalCosts" type="text" style="width:60px; color:#993333;" runat="server" readonly="readonly" value="0" /> 元</td>
            <td class="label">偏远地区附加费:</td>
            <td class="content"><input id="txtRemoteCosts" type="text" style="width:60px" runat="server" value="0" onchange="checkData(this);" onkeypress="return checkPrice(event,this.value)" onkeyup="setAddition(this, 2)" onclick="this.select()"/> 元</td>
            <td class="label">取 件 费:</td>
            <td class="content"><input id="txtFetchCosts" type="text" style="width:60px" runat="server" value="0" onchange="checkData(this);" onkeypress="return checkPrice(event,this.value)" onkeyup="setAddition(this, 2)" onclick="this.select()"/> 元</td>                
          </tr>
          <tr>
            <td class="label">材 料 费:</td>
            <td class="content"><input id="txtMaterialCosts" type="text" style="width:60px" runat="server" value="0" readonly="readonly" /> 元</td>
            <td class="label" >其它费用:</td>
            <td class="content" colspan="3"><input id="txtOtherCosts" type="text" style="width:60px" runat="server" value="0" onkeypress="return checkPrice(event,this.value);" onchange="checkData(this);" onkeyup="setAddition(this, 2)" onclick="this.select()"/> 元&nbsp;&nbsp;费用说明:<input id="txtOtherCostsNote" type="text" style="width:68%;" runat="server"/></td>          
          </tr>
          <tr>
            <td class="label">保 价 费:</td>
            <td class="content"><input id="txtInsureCosts" type="text" style="width:60px" runat="server" value="0" readonly="readonly" onclick="this.select()"/> 元</td>
            <td class="label">地址更改费:</td>
            <td class="content"><input id="txtAddressChangeCosts" type="text" style="width:60px" runat="server" value="0" onchange="checkData(this);" onkeypress="return checkPrice(event,this.value)" onkeyup="setAddition(this, 2)" onclick="this.select()"/> 元</td>
            <td class="label">退 件 费:</td>
            <td class="content"><input id="txtReturnCosts" type="text" style="width:60px" runat="server" value="0" onchange="checkData(this);" onkeypress="return checkPrice(event,this.value)" onkeyup="setAddition(this, 2)" onclick="this.select()" /> 元</td>                
          </tr>
          <tr>
            <td class="label">损失与赔偿:</td>
            <td class="content"><input id="txtDamageMoney" type="text" style="width:60px" runat="server" value="-" onkeypress="return checkPrice(event,this.value)" onkeyup="setSubtract(this, 2);checkSpecialData(this);" onclick="this.select()"/> 元</td>
            <td class="label">返&nbsp;&nbsp;&nbsp;&nbsp;利:</td>
            <td class="content"><input id="txtReturnMoney" type="text" style="width:60px" runat="server" value="-" onkeypress="return checkPrice(event,this.value)" onkeyup="setSubtract(this, 2);checkSpecialData(this);" onclick="this.select()" /> 元</td>
            <td class="label">应收费用:</td>
            <td class="content"><input id="txtTotalCosts" type="text" style="width:60px; color:Blue;" runat="server" readonly="readonly" value="0" /> 元<input type="hidden" id="hdTotalCosts" runat="server" /></td>                
          </tr>
          <tr>
            <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content" colspan="5"><asp:TextBox TextMode="multiLine" Rows="1" Width="100%" runat="server" ID="txtRemark"></asp:TextBox></td>          
          </tr>
          <tr><td colspan="6" height="18"></td></tr>
          <tr>
            <td class="label">收件人姓名:</td>
            <td class="content"><input id="txtToUsername" type="text" style="width:180px" runat="server"/></td>
            <td class="label">收件人电话:</td>
            <td class="content"><input id="txtToPhone" type="text" style="width:180px" runat="server"/></td>
            <td class="label">收件人邮箱:</td>
            <td class="content"><input id="txtToEmail" type="text" style="width:180px" runat="server"/></td>                
          </tr>
          <tr>
            <td class="label">收件人城市:</td>
            <td class="content"><input id="txtToCity" type="text" style="width:180px" runat="server"/></td>
            <td class="label">收件人国家:</td>
            <td class="content"><input id="txtToCountry" type="text" style="width:180px" runat="server" readonly="readonly"/></td>
            <td class="label">收件人邮编:</td>
            <td class="content"><input id="txtToPostcode" type="text" style="width:180px" runat="server"/></td>                
          </tr>
          <tr>
            <td class="label">包裹单号:</td>
            <td class="content"><input id="txtBarCode" type="text" style="width:180px" runat="server"/></td>
            <td class="label">亿度条码:</td>
            <td class="content" colspan="3"><asp:Label ID="lblEncode" runat="server"></asp:Label></td>       
          </tr>
          <tr>
            <td class="label">收件人详址:</td>
            <td class="content" colspan="5"><input id="txtToAddress" type="text" style="width:100%" runat="server"/></td> 
          </tr>
          <tr><td colspan="6" align="center"><input type="button" class="button" value="返 回" onclick="javascript:location.href='/Admin/DataQuery/ReceiveOrder.aspx?id=<%=order.Id %>'"/></td></tr>
         </table>
		</td>
    </tr>
  </table>
</form>
</body>
</html>
