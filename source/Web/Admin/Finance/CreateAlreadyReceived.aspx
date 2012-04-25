<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAlreadyReceived.aspx.cs" Inherits="Admin_Finance_CreateAlreadyReceived" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/ClientList.js"></script>
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
<style type="text/css" >  
    <! --   

    #popup  
    {  
        /* 提示框div块的样式 */  
        color:#000000;  
        font-size: 12px;  
        font-family: Arial, Helvetica, sans-serif;
	    background-color:#FFFFFF;
         
    }  
    #popup.show  
    {  
        /* 显示提示框的边框 */  
        border: 1px solid #004a7e;  
    }  
    #popup.hide  
    {  
        /* 隐藏提示框的边框 */  
        border: none;  
    }
    
    /* 提示框的样式风格 */  
    ul  
    {  
        list-style: none;  
        margin: 0px;  
        padding: 0px;  
    }  
    li
    {
    background-color:#FFFFFF;
    }
    li.mouseOver  
    {  
        background-color: #004a7e;  
        color: #FFFFFF;  
    }  
    li.mouseOut  
    {  
        background-color: #FFFFFF;  
        color: #000000;  
    }  
    -- >  
</style> 
<script language="javascript" type="text/javascript">  
   
    //乘法函数，用来得到精确的乘法结果 
    //说明：javascript的乘法结果会有误差，在两个浮点数相乘的时候会比较明显。这个函数返回较为精确的乘法结果。 
    //调用：accMul(arg1,arg2) 
    //返回值：arg1乘以arg2的精确结果 
    function accMul(arg1,arg2) 
    { 
    var m=0,s1=arg1.toString(),s2=arg2.toString(); 
    try{m+=s1.split(".")[1].length}catch(e){} 
    try{m+=s2.split(".")[1].length}catch(e){} 
    return Number(s1.replace(".",""))*Number(s2.replace(".",""))/Math.pow(10,m) 
    }     

    
    function calculateActualMoney()
    {
        var clientPaid = document.getElementById("txtClientPaid");
        var exchangeRate = document.getElementById("txtExchangeRate");
        var actualReceived = document.getElementById("txtActualReceived");
        
        var actualMoney = clientPaid.value * exchangeRate.value;
        if(isNaN(actualMoney))
        {
            alert("客户付款金额和当前汇率只能为数字！");
            clientPaid.value="";
            exchangeRate.value=1;
            actualReceived.value="";
        }
        else
        {
            actualReceived.value= accMul(clientPaid.value, exchangeRate.value);
        }
    }
    function openClientWindow()
    {
        window.open("../../Config/ClientList.aspx?id="+document.getElementById('hdCompanyId').value+"","客户列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
    }  
</script>
</head>
<body>
<form id="form1" runat="server">     
  <wl:FinanceNav ID="financeNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">财务管理 > 客户付款 > 添加客户付款记录</td>
    </tr>
    <tr>
        <td class="info"></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center" style="height:21px">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">  
              <tr>
                <td width="9%" class="label" >收款类型:</td>
                <td width="91%" class="content"><wl:PaymentTypeDropDownList ID="ddlPaymentType" runat="server"></wl:PaymentTypeDropDownList></td>
              </tr>
              <tr>
                <td class="label" >收款时间:</td>
                <td class="content"><input type="text" onclick="WdatePicker({maxDate:'%y-%M-%d'})" runat="server" id="txtReceivedTime" name="txtDate" size="29" readonly="readonly" /></td>
              </tr>
              <tr>
                <td class="label" >流水号:</td>
                <td class="content"><asp:TextBox ID="txtInvoice" runat="server" Width="180"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="label" >客户姓名:</td>   
                <td class="content"><table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                    <td align="left" width="20%"><input id="txtClientName" type="text" style="width:97%;color:#555555;" runat="server" readonly="readonly"/></td>
                    <td align="left" width="80%"><input type="image" src="../Images/btn_bg1.gif" onclick="openClientWindow()" />
                    <input id="hdCompanyId" name="hdCompanyId" type="hidden" value="<%=companyId %>" /></td></tr></table>
                </td>
              </tr>                   
              <tr>
                <td class="label" >付款方式:</td>
                <td class="content"><wl:PaymentMethodDropDownList ID="ddlPaymentMethod" runat="server"></wl:PaymentMethodDropDownList></td>
              </tr>
              <tr>
                <td class="label" >收款账号:</td>
                <td class="content"><asp:TextBox ID="txtAccount" runat="server" Width="180"></asp:TextBox></td>
              </tr>                            
              <tr>
                <td class="label" >币&nbsp;&nbsp;&nbsp;&nbsp;种:</td>
                <td class="content"><wl:CurrencyTypeDropDownList ID="ddlCurrencyType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCurrencyType_SelectedIndexChanged"></wl:CurrencyTypeDropDownList></td>
              </tr>   
              <tr id="trUsdConversion" runat="server" visible="false">
                    <td colspan="2" align="left" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                              <td class="label" width="9%"> 客户付款: </td>
                              <td align="left" class="content" width="91%"><asp:TextBox ID="txtClientPaid" runat="server" Width="180" onkeyup="calculateActualMoney()"></asp:TextBox>
                              </td>
                            </tr>
                            <tr>
                              <td class="label" > 当前汇率: </td>
                              <td align="left" class="content"><asp:TextBox ID="txtExchangeRate" runat="server" Width="180" Text="1" onkeyup="calculateActualMoney()"></asp:TextBox>
                              </td>
                            </tr> 
                            <tr>
                              <td class="label"> 实际收款: </td>
                              <td align="left" class="content"><input type="text" runat="server" name="txtActualReceived" id="txtActualReceived" size="29" readonly="readonly" />元                                          
                                 </td>
                            </tr> 
                        </table>
                    </td>
                </tr>
                <tr  id="trReceivedMoney" runat="server">
                <td class="label" >收款金额:</td>
                <td class="content"><asp:TextBox ID="txtReceivedMoney" runat="server" Width="180"></asp:TextBox>元</td>
              </tr>  
              <tr>
                <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
                <td class="content"><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="580" Columns="2"></asp:TextBox></td>
              </tr> 
                <tr><td colspan="2" align="center"><asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="提 交" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='AlreadyReceived.aspx'"/></td></tr>
            </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
