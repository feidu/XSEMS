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
        alert(count);
        totalCosts = disposalCosts*count + registerCosts*count + postCosts*1 + remoteCosts*1 + fetchCosts*1 + materialCosts*1 + otherCosts*1 + insureCosts*1 + addressChangeCosts*1 + returnCosts*1 + damageMoney*1 + returnMoney*1;
    }
    totalCosts=Math.round(parseFloat(totalCosts)*100);
    totalCosts=totalCosts/100;
    $("#txtTotalCosts").val(totalCosts);    	    
}