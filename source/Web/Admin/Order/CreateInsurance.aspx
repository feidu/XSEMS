<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateInsurance.aspx.cs" Inherits="Admin_Order_CreateInsurance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
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
    
    function GetInsureCosts()
    {
        var insureCosts = 0;
        var txtInsureWorth = document.getElementById("txtInsureWorth");
        if(isNaN(txtInsureWorth.value))
        {
            alert("投保价值只能为数字！");
            txtInsureWorth.value = 0;
            return;
        }
        insureCosts = accMul(txtInsureWorth.value, 0.01);        
        var txtInsureCosts = document.getElementById("txtInsureCosts");
        if(insureCosts < 10)
        {
            insureCosts = 10;
        }
        txtInsureCosts.value = insureCosts;
    }
</script>
</head>
<body>
<form id="formCharge" runat="server">   
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 收件计划 > 添加保价明细</td>
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
            <td class="label" width="9%" >跟踪号码:</td>
            <td class="content" width="25%" ><input id="txtBarCode" type="text" style="width:150px;" runat="server" readonly="readonly"/></td>
            <td class="label" width="9%" >投保价值:</td>
            <td class="content" width="24%" ><input id="txtInsureWorth" type="text" style="width:90px;" runat="server" onkeyup="GetInsureCosts()" /> 元</td>
            <td class="label" width="9%" >保 价 费:</td>
            <td class="content" width="24%" ><input id="txtInsureCosts" type="text" style="width:90px; color:Blue;" runat="server" readonly="readonly"/> 元</td>                
          </tr>          
          <tr><td colspan="6" align="left" style="color:Red;">&nbsp;说明：保价费最低为10元。</td></tr>
          <tr><td colspan="6" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="提 交" OnClick="btnCreate_Click"/><span id="spanDelete" runat="server">&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删 除" OnClick="btnDelete_Click"/></span>&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='/Admin/Order/ReceiveOrder.aspx?id=<%=id %>'"/></td></tr>
         </table>
		</td>
    </tr>
  </table>
</form>
</body>
</html>
