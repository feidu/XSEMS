// JScript 文件
var country;
var goodsType;
var weight;
var count;
var carrier;
var xmlHttp;  

function checkCarrier(index, type)
    {
        if(document.getElementById("txtCarrier").value!="")
        {
            searchCarriers(index, type);
        }
    }

function initVariables() {  
    //初始化变量  
    var hdCountry = document.getElementById("hdCountry");
    var slGoodsType = document.getElementById("slGoodsType");
    var txtWeight = document.getElementById("txtWeight");
    var txtCount = document.getElementById("txtCount");
    var hdCarrierEncode = document.getElementById("hdCarrierEncode");
    var hdClientId = document.getElementById("hdClientId");
    
    carrier = hdCarrierEncode.value;
    country = hdCountry.value;    
    goodsType = slGoodsType.value;
    weight = txtWeight.value;
    count = txtCount.value;    
    clientId = hdClientId.value;
}  

function searchCarriers(index, type) {  
    if(checkFreightForm() && parseFloat(document.getElementById("txtWeight").value)>0)
    {
        initVariables();     //初始化变量  
        createXMLHttpRequest();     //将用户输入发送给服务器  
        var sUrl = "/Config/ChargeStandardBackend.aspx?carrier=" + carrier + "&country=" + country + "&type=" + goodsType +"&weight=" + weight + "&count=" + count + "&clientId=" + clientId;  
        xmlHttp.open("GET", sUrl, true);  
        xmlHttp.onreadystatechange = function() {  
            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {  
                var result = xmlHttp.responseText;              
                setCosts(result, index, type); //处理服务器结果  
            }  
        }  
        xmlHttp.send(null);  
    }    
}

function setCosts(result, index, type) 
{    
    var oldCountry = $("#hdCountryBak").val();
    if(result!="")
    {        
        var arrayResult = new Array();
        arrayResult = result.split(",");
                
        var kgPrice = arrayResult[0];
        var disposalCost = arrayResult[1];
        var registerCost = arrayResult[2];
        var postCost = arrayResult[3];    
        var country = arrayResult[4];
        oldCountry = arrayResult[4]
          
        $("#txtKgPrice").val(kgPrice);       
        $("#txtDisposalCosts").val(disposalCost);       
        $("#txtRegisterCosts").val(registerCost);       
        $("#txtPostCosts").val(postCost);       
        $("#hdCountryBak").val(oldCountry);
        
        getTotalCosts(type);        
    }        	    
    else
    {   
        $("#txtKgPrice").val(0);       
        $("#txtDisposalCosts").val(0);       
        $("#txtRegisterCosts").val(0);       
        $("#txtPostCosts").val(0); 
         getTotalCosts(type); 
        if(index == 1)
        {
            alert("该承运商不抵达此国家！");
        }
        else if(index == 2)
        {
            alert("该承运商不支持此物品类别！");
        }
        else if(index == 3)
        {
            alert("重量超过此承运商限定范围！");
        }
        else if(index == 4)
        {
            alert("数量超过此承运商限定范围！");
        }
    }   
}
