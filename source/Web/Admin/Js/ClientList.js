// JScript 文件
var oInputField; //考虑到很多函数中都要使用  
var oPopDiv;    //因此采用全局变量的形式  
var oColorsUl;  
var xmlHttp;  
function createXMLHttpRequest() {  
    if (window.ActiveXObject)  
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");  
    else if (window.XMLHttpRequest)  
        xmlHttp = new XMLHttpRequest();  
} 
  
function initVars() {  
    //初始化变量      
    oInputField = document.getElementById("txtClientName");  
    oPopDiv = document.getElementById("popup");  
    oColorsUl = document.getElementById("colors_ul");  
    sCompId=document.getElementById("txtCompanyId");
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
            clearColors(); //同时清除提示框  
        }  
    }          
}  
function findColors() {  
    initVars();     //初始化变量  
    if (oInputField.value.length > 0) {  
        createXMLHttpRequest();     //将用户输入发送给服务器  
        var sUrl = "/Config/ClientBackend.aspx?sColor=" +escape(oInputField.value) + "&sCompId=" + sCompId.value + "&timestamp=" + new Date().getTime();  
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
    var oInputField = document.getElementById("txtClientName");
    if(oInputField.value=="请输入客户姓名拼音的首字母")
    {
        oInputField.value="";
    }
}   
function repalyText()
{
    var oInputField = document.getElementById("txtClientName");
    if(oInputField.value=="")
    {
        oInputField.value="请输入客户姓名拼音的首字母";
    }
}

