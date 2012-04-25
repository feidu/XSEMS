<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LiabilityOrder.aspx.cs" Inherits="Admin_Client_LiabilityOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function openPrintWindow()
{
    window.open("../../Config/LiabilityPrint.aspx?id="+document.getElementById('hdLiabilityId').value+"","责任认定打印","toolbar=no,top=20,left=62,width=900,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes","");    
}  
</script>
</head>
<body>
<form id="form1" runat="server">   
  <input type="hidden" id="hdLiabilityId" runat="server" />
  <wl:ClientNav ID="clientNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">客户服务 > 责任认定 > 责任认定祥情</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateLiabilityOrder.aspx">新增记录</a> | <a href="LiabilityList.aspx">责任认定列表</a></td>
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
            <td width="10%" class="label" >认定书编号:</td>
            <td width="23%" class="content"><asp:Label ID="lblEncode" runat="server"></asp:Label></td>
            <td width="10%" class="label" >收件单号:</td>
            <td width="24%" class="content"><asp:TextBox ID="txtOrderEncode" Width="180" runat="server"></asp:TextBox></td>
            <td width="10%" class="label" >收件日期:</td>
            <td width="23%" class="content"><asp:Label ID="lblReceiveDate" runat="server"></asp:Label></td>
          </tr>          
          <tr>            
            <td class="label" >跟踪单号:</td>
            <td class="content"><asp:TextBox ID="txtBarCode" Width="180" runat="server"></asp:TextBox></td>           
            <td class="label" >跟进业务员:</td>
            <td class="content"><asp:Label ID="lblOrderUser" runat="server"></asp:Label></td>        
            <td class="label" >制 单 人:</td>
            <td class="content"><asp:Label ID="lblCreateUser" runat="server"></asp:Label></td>
          </tr>        
          <tr>            
            <td class="label" >事件类型:</td>
            <td class="content"><wl:LiabilityEventTypeDropDownList ID="ddlEventType" runat="server"></wl:LiabilityEventTypeDropDownList></td>           
            <td class="label" >更正状态:</td>
            <td class="content"><asp:DropDownList ID="ddlCorrectStatus" runat="server">
                <asp:ListItem Text="未更正" Value="False"></asp:ListItem>
                <asp:ListItem Text="已更正" Value="True"></asp:ListItem>
            </asp:DropDownList></td>        
            <td class="label" >货&nbsp;&nbsp;&nbsp;&nbsp;币:</td>
            <td class="content"><asp:DropDownList ID="ddlCurrencyType" runat="server">
                <asp:ListItem Text="人民币" Value="人民币"></asp:ListItem>
                <asp:ListItem Text="港元" Value="港元"></asp:ListItem>
                <asp:ListItem Text="美元" Value="美元"></asp:ListItem>
                <asp:ListItem Text="欧元" Value="欧元"></asp:ListItem>
            </asp:DropDownList></td>
          </tr>        
          <tr>            
            <td class="label" >填 表 人:</td>
            <td class="content"><asp:TextBox ID="txtFillUser" Width="180" runat="server"></asp:TextBox></td>           
            <td class="label" >填表日期:</td>
            <td class="content" colspan="3"><input type="text" onclick="WdatePicker()" class="Wdate" runat="server" id="txtFillTime" name="txtFillTime" size="29" readonly="readonly" /></td>        
          </tr>    
          <tr>
            <td class="label" >事情经过:</td>
            <td class="content" colspan="5"><asp:TextBox ID="txtDetail" TextMode="multiLine" Rows="4" Width="100%" runat="server"></asp:TextBox></td>          
          </tr>    
          <tr>
            <td class="label" >处理结果:</td>
            <td class="content" colspan="5"><asp:TextBox ID="txtResult" TextMode="multiLine" Rows="3" Width="100%" runat="server"></asp:TextBox></td>          
          </tr>                
         </table>		
        </td>
    </tr>    
    <tr>
        <td><table class="grid">
          <tr>
            <td class="label">责任总金额:</td>
            <td colspan="7" class="content"><asp:TextBox ID="txtTotalMoney" runat="server" Width="80"></asp:TextBox></td>
          </tr>
          <tr>
            <td width="10%" class="label">责任部门:</td>
            <td width="22%" class="content"><asp:TextBox ID="txtZrDepartment" Width="190" runat="server"></asp:TextBox></td>
            <td width="12%" class="label" >承担金额:</td>
            <td width="12%" class="content"><asp:TextBox ID="txtZrDtMoney" Width="80" runat="server"></asp:TextBox></td>
            <td width="12%" class="label" >责 任 人:</td>
            <td width="12%" class="content"><asp:TextBox ID="txtZrUser" Width="80" runat="server"></asp:TextBox></td>
            <td width="8%" class="label" >承担金额:</td>
            <td width="12%" class="content"><asp:TextBox ID="txtZrUrMoney" Width="80" runat="server"></asp:TextBox></td>
          </tr>          
          <tr>            
            <td class="label">客户姓名:</td>
            <td class="content"><asp:TextBox ID="txtClientName" Width="80" runat="server"></asp:TextBox></td>           
            <td class="label" >客户付给亿度:</td>
            <td class="content"><asp:TextBox ID="txtClientPtEadu" Width="80" runat="server"></asp:TextBox></td>        
            <td class="label" >亿度付给客户:</td>
            <td class="content" colspan="3"><asp:TextBox ID="txtEaduPtClient" Width="80" runat="server"></asp:TextBox></td>
          </tr>      
          <tr>            
            <td class="label">承 运 商:</td>
            <td class="content"><asp:TextBox ID="txtCarrier" Width="190" runat="server"></asp:TextBox></td>           
            <td class="label" >承运商付给亿度:</td>
            <td class="content"><asp:TextBox ID="txtCarrierPtEadu" Width="80" runat="server"></asp:TextBox></td>        
            <td class="label" >亿度付给承运商:</td>
            <td class="content" colspan="3"><asp:TextBox ID="txtEaduPtCarrier" Width="80" runat="server"></asp:TextBox></td>
          </tr>      
          <tr>
            <td class="label">奖励部门:</td>
            <td class="content"><asp:TextBox ID="txtJlDepartment" Width="190" runat="server"></asp:TextBox></td>
            <td class="label" >奖励金额:</td>
            <td class="content"><asp:TextBox ID="txtJlDtMoney" Width="80" runat="server"></asp:TextBox></td>
            <td class="label" >奖 励 人:</td>
            <td class="content"><asp:TextBox ID="txtJlUser" Width="80" runat="server"></asp:TextBox></td>
            <td class="label" >奖励金额:</td>
            <td class="content"><asp:TextBox ID="txtJlUrMoney" Width="80" runat="server"></asp:TextBox></td>
          </tr>     
          <tr>
            <td class="label">负 责 人:</td>
            <td class="content"><asp:TextBox ID="txtLiabilityUser" Width="80" runat="server"></asp:TextBox></td>
            <td class="label" >更&nbsp;&nbsp;&nbsp;&nbsp;正:</td>
            <td class="content"><asp:TextBox ID="txtCorrectUser" Width="80" runat="server"></asp:TextBox></td>
            <td class="label" >财&nbsp;&nbsp;&nbsp;&nbsp;务:</td>
            <td class="content"><asp:TextBox ID="txtFinanceUser" Width="80" runat="server"></asp:TextBox></td>
            <td class="label" >出&nbsp;&nbsp;&nbsp;&nbsp;纳:</td>
            <td class="content"><asp:TextBox ID="txtCashierUser" Width="80" runat="server"></asp:TextBox></td>
          </tr>         
         </table>
        </td>
    </tr>
    <tr><td align="center"><asp:Button ID="btnUpdate" CssClass="button" Text="修 改" runat="server" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='LiabilityList.aspx';" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="打印预览" onclick="openPrintWindow()" /></td></tr>
  </table>  
</form>
</body>
</html>