<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateOrderQuick.aspx.cs" Inherits="Admin_Order_CreateOrderQuick" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/ClientList.js"></script>
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>

<script language="javascript" type="text/javascript">
function openClientWindow()
    {
        window.open("../../Config/ClientList.aspx?id="+document.getElementById('hdCompanyId').value+"","客户列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
    }  
    function openCountryWindow()
    {
        window.open("../../Config/CountryList.aspx","国家列表","toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");
    }     
    
    function chkForm()
    {
        var barCode = document.getElementById("txtBarCode");
        if(barCode.value.length<=0)
        {
            barCode.focus();
            return false;
        }   
    }    
</script>
</head>
<body>
<form id="form1" runat="server">   
  <asp:Panel ID="plForm" runat="server" DefaultButton="btnCreate">
  <wl:OrderNav ID="orderNav" runat="server" />
  <input type="hidden" id="hdCountry" runat="server" value="UnitedStates" />
  <input type="hidden" id="txtToCountry" runat="server"  value="UnitedStates"/>
  <input type="hidden" id="txtCarrier" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 收件计划 > 快捷开单</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
     <tr>
      <td><table class="grid">
                <tr>
                  <td colspan="2" align="center" style="height: 21px">
                      <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td>
                </tr>     
                <tr>
                  <td width="10%" class="label"> 客户姓名: </td>
                  <td width="90%" class="content"><table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                    <td align="left" width="24%"><input id="txtClientName" type="text" style="width:97%;color:#555555;" runat="server" readonly="readonly" /></td>
                    <td align="left" width="76%"><asp:ImageButton ImageUrl="../Images/btn_bg1.gif" runat="server" ID="btnOpenClientWindow" OnClientClick="openClientWindow()" UseSubmitBehavior="false" />
                    <input id="hdCompanyId" name="hdCompanyId" type="hidden" value="<%=companyId %>" /></td></tr></table>
                  </td>
                </tr>    
                <tr>
                <td class="label" >发货日期:</td>
                <td class="content"><input type="text" onclick="WdatePicker()" class="Wdate" style=" width:179px;" runat="server" id="txtCreateDate" readonly="readonly" /></td>
                </tr>
                <tr>
                 <td class="label" >承 运 商:</td>
                 <td class="content"><asp:DropDownList ID="ddlCarrier" runat="server"></asp:DropDownList></td>
                </tr> 
                <tr>
                 <td class="label">包裹重量:</td>
                 <td class="content"><asp:TextBox ID="txtWeight" runat="server" Width="180"></asp:TextBox> 克</td>
                </tr>
                <tr>
                 <td class="label">国&nbsp;&nbsp;&nbsp;&nbsp;家:</td>
                 <td class="content"><table border="0" cellpadding="0" cellspacing="0" width="35%"><tr><td align="left" width="85%"><input id="txtCountry" type="text" style="width:100%;color:#555555;" runat="server" readonly="readonly" value="UnitedStates -- 美国"/></td><td align="right" width="15%"><asp:ImageButton ImageUrl="../Images/btn_bg1.gif" runat="server" ID="btnOpenCountryWindow" OnClientClick="openCountryWindow()" /></td></tr></table></td>
                </tr>                
                <tr>
                 <td class="label">备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
                 <td class="content"><asp:TextBox ID="txtRemark" runat="server" Width="180"></asp:TextBox></td>
                </tr>
                 <tr>
                 <td class="label">挂号条码:</td>
                 <td class="content"><asp:TextBox ID="txtBarCode" runat="server" Width="180"></asp:TextBox></td>
                </tr>                                         
                <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="提 交" OnClientClick="return chkForm()" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='Default.aspx'"/></td></tr>
            </table>		
		</td>
    </tr>
  </table>
  </asp:Panel>
</form>
</body>
</html>