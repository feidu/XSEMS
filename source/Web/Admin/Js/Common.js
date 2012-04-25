var oInputField; //���ǵ��ܶຯ���ж�Ҫʹ��  
var oPopDiv;    //��˲���ȫ�ֱ�������ʽ  
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
    //��ʼ������  
    oInputField = document.getElementById("txtCountry");  
    oPopDiv = document.getElementById("popup");  
    oColorsUl = document.getElementById("colors_ul");  
    hdCountry = document.getElementById("hdCountry");
}  
function clearColors() {  
    //�����ʾ����  
    for (var i = oColorsUl.childNodes.length - 1; i >= 0; i--)  
        oColorsUl.removeChild(oColorsUl.childNodes[i]);  
    oPopDiv.className = "hide";  
}  
function hideColors() {  
    oPopDiv.className = "hide";  
}
function setColors(the_colors) {  
    //��ʾ��ʾ�򣬴���Ĳ�����Ϊƥ������Ľ����ɵ�����  
    clearColors(); //ÿ����һ����ĸ�������ԭ�ȵ���ʾ���ټ���  
    oPopDiv.className = "show";  
    var oLi;  
    for (var i = 0; i < the_colors.length; i++) {  
        //��ƥ�����ʾ�����һ��ʾ���û�  
        oLi = document.createElement("li");  
        oColorsUl.appendChild(oLi);  
        oLi.appendChild(document.createTextNode(the_colors[i]));  

        oLi.onmouseover = function() {  
            this.className = "mouseOver"; //��꾭��ʱ����  
        }  
        oLi.onmouseout = function() {  
            this.className = "mouseOut"; //�뿪ʱ�ָ�ԭ��  
        }  
        oLi.onclick = function() {  
            //�û����ĳ��ƥ����ʱ�����������Ϊ�����ֵ  
            oInputField.value = this.firstChild.nodeValue;  
            hdCountry.value = this.firstChild.nodeValue;
            clearColors(); //ͬʱ�����ʾ��  
        }  
    }          
}  
function findColors() {  
    initVars();     //��ʼ������  
    if (oInputField.value.length > 0) {  
        createXMLHttpRequest();     //���û����뷢�͸�������  
        var sUrl = "/Config/CountryBackend.aspx?sColor=" +escape(oInputField.value) + "&timestamp=" + new Date().getTime();  
        xmlHttp.open("GET", sUrl, true);  
        xmlHttp.onreadystatechange = function() {  
            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {  
                var aResult = new Array();  
                if (xmlHttp.responseText.length) {  
                    aResult = xmlHttp.responseText.split(",");  
                    setColors(aResult); //��ʾ���������  
                }  
                else  
                    clearColors();  
            }  
        }  
        xmlHttp.send(null);  
    }  
    else  
        clearColors(); //������ʱ�����ʾ�������û���del����  
}  

function clearText()
{
    var oInputField = document.getElementById("txtCountry");
    if(oInputField.value=="���������Ӣ������")
    {
        oInputField.value="";
    }
}

function repalyText()
{
    var oInputField = document.getElementById("txtCountry");
    if(oInputField.value=="")
    {
        oInputField.value="���������Ӣ������";
    }
}


function checkFreightForm()
{
    var country = document.getElementById("txtCountry");
    var weight = document.getElementById("txtWeight");
    var count = document.getElementById("txtCount");
    if(country.value.length<=0 || country.value=="���������Ӣ������")
    {
	    alert("������Ĵ���ң�");
	    country.focus();
	    return false;
    }

    if(weight.value.length<=0)
    {
	    alert("������������");
	    weight.focus();
	    return false;
    }
    else if(isNaN(weight.value))
    {
        alert("����ֻ��Ϊ���֣�");
        weight.focus();
        return false;
    }
    else if(parseFloat(weight.value)<=0)
    {
        alert("��������С�ڻ����0��");
        weight.focus();
        weight.value="";
        return false;
    }
    if(count.value.length<=0)
    {
	    alert("������������");
	    count.focus();
	    return false;
    }
    else if(isNaN(count.value))
    {
        alert("����ֻ��Ϊ���֣�");
        count.focus();
        return false;
    }
    else if(parseInt(count.value)<=0 || parseInt(count.value)!=count.value)
    {
        alert("����ֻ��Ϊ����0��������");
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
    if(country.value.length<=0 || country.value=="���������Ӣ������")
    {
	    alert("������Ĵ���ң�");
	    country.focus();
	    return false;
    }

    if(weight.value.length<=0)
    {
	    alert("������������");
	    weight.focus();
	    return false;
    }
    else if(isNaN(weight.value))
    {
        alert("����ֻ��Ϊ���֣�");
        weight.focus();
        return false;
    }
    else if(parseFloat(weight.value)<=0)
    {
        alert("��������С�ڻ����0��");
        weight.focus();
        return false;
    }
    if(count.value.length<=0)
    {
	    alert("������������");
	    count.focus();
	    return false;
    }
    else if(isNaN(count.value))
    {
        alert("����ֻ��Ϊ���֣�");
        count.focus();
        return false;
    }
    else if(parseInt(count.value)<=0 || parseInt(count.value)!=count.value)
    {
        alert("����ֻ��Ϊ����0��������");
        count.focus();
        return false;
    }
    if(carrier.value.length<=0)
    {
        alert("��ѡ������̣�");
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
        var remoteCosts = $("#txtRemoteCosts").val();//ƫԶ���ӷ�
        var fetchCosts = $("#txtFetchCosts").val();
        var materialCosts = $("#txtMaterialCosts").val();
        var otherCosts = $("#txtOtherCosts").val();
        var insureCosts = $("#txtInsureCosts").val();
        var addressChangeCosts = $("#txtAddressChangeCosts").val();
        var returnCosts = $("#txtReturnCosts").val();
        
        var damageMoney = $("#txtDamageMoney").val()=="-"?0:$("#txtDamageMoney").val();//��ʧ���⳥
        var returnMoney = $("#txtReturnMoney").val()=="-"?0:$("#txtReturnMoney").val();//����
        alert(count);
        totalCosts = disposalCosts*count + registerCosts*count + postCosts*1 + remoteCosts*1 + fetchCosts*1 + materialCosts*1 + otherCosts*1 + insureCosts*1 + addressChangeCosts*1 + returnCosts*1 + damageMoney*1 + returnMoney*1;
    }
    totalCosts=Math.round(parseFloat(totalCosts)*100);
    totalCosts=totalCosts/100;
    $("#txtTotalCosts").val(totalCosts);    	    
}