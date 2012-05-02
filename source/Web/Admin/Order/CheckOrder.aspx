<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOrder.aspx.cs" Inherits="Admin_Order_CheckOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
function checkReason(strMsg)
{
    var reason = document.getElementById("txtReason");
    if(reason.value.length<=0)
    {
        alert(strMsg);
        reason.focus();
        return false;        
    }
    return true;
}
</script>
</head>
<body>
<form id="form1" runat="server">   
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
      <td class="img"><img src="../Images/icon_applist.gif" width="32" height="32" alt="" /></td>
      <td class="title2"><a href="/Admin/Order/CheckOrderList.aspx">收件检验</a></td>
    </tr>
    <tr>
      <td colspan="2" class="line"></td>
    </tr>
  </table>  
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">收件检验</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
    <tr>
        <td class="info"><asp:Button ID="btnCheckThrough" runat="server" Text="检验通过" CssClass="button" OnClick="btnCheckThrough_Click" />&nbsp;&nbsp;<asp:Button ID="btnReturn" runat="server" Text="退回审核" CssClass="button" OnClientClick="return checkReason('请填写退回审核原因！')" OnClick="btnReturn_Click" /><div style="display:none;">&nbsp;&nbsp;<asp:Button ID="btnPrintInsurance" runat="server" Text="打印投保单" CssClass="button" /></div>&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='CheckOrderList.aspx';" /></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center" style="height: 21px">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td>
      	 <table class="grid">
          <tr>
            <td width="10%" class="label" >收件单号:</td>
            <td width="23%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
            <td class="label" >制单时间:</td>
            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >客户姓名:</td>
            <td class="content"><asp:Label ID="lblClientName" runat="server" Text=""></asp:Label></td>
            <td class="label" >应收总计:</td>
            <td class="content" colspan="3"><asp:Label ID="lblCosts" runat="server" Text="" ForeColor="blue"></asp:Label> 元</td>
          </tr>
          <tr>
            <td class="label" >审 核 人:</td>
            <td class="content"><asp:Label ID="lblAuditUser" runat="server" Text="" ></asp:Label></td>
            <td class="label" >审核时间:</td>
            <td class="content" colspan="3"><asp:Label ID="lblAuditTime" runat="server" Text=""></asp:Label></td>                
          </tr>
          <tr>
            <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content" colspan="3"><asp:Label ID="lblRemark" runat="server" Text=""></asp:Label></td>          
          </tr>
          <tr>
            <td class="label" >退回原因:</td>
            <td class="content" colspan="5"><asp:TextBox TextMode="multiLine" Rows="2" Width="100%" runat="server" ID="txtReason"></asp:TextBox></td>          
          </tr>
         </table>	         
	  </td>
    </tr>   
    <tr>
      <td>
      	 <table class="grid">
          <tr>
            <td align="center" class="headers">选择</td>
            <td align="center" class="headers">序号</td>
            <td align="left" class="headers">国家</td>
            <td align="left" class="headers">承运商</td>
            <td align="left" class="headers">追踪号</td>
            <td align="left" class="headers">邮件数量</td>           
            <td align="left" class="headers">计费重量</td>  
            <td align="left" class="headers">运费</td>      
            <td align="left" class="headers">挂号费</td>
            <td align="left" class="headers">附加费</td>
            <td align="left" class="headers">处理费</td>
            <td align="left" class="headers">取件费</td>           
            <td align="left" class="headers">材料费</td>
            <td align="left" class="headers">其他费</td>   
            <td align="left" class="headers">应收费用</td>      
            <td align="center" class="headers">操作</td>
          </tr>
          <%
              if (result != null)
              {
                  int i = 1;
                  foreach (Backend.Models.OrderDetail od in result)
                  {
                      
               %>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%=od.Id%>" /></td>
                <td align="center"><%=i%></td>
                <td align="left"><%=od.ToCountry%></td>
                <td align="left"><%=od.CarrierEncode%></td>    
                <td align="left"><%=od.BarCode%></td>
                <td align="left"><%=od.Count%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.Weight.ToString())%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.PostCosts.ToString())%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.RegisterCosts.ToString())%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.RemoteCosts.ToString())%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.DisposalCosts.ToString())%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.FetchCosts.ToString())%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.MaterialCosts.ToString())%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.OtherCosts.ToString())%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.TotalCosts.ToString())%></td>
                <td align="center"><a href="OrderDetailView.aspx?id=<%=od.Id %>">查看</a></td>
              </tr>
              <% i++;
             }
         }%>   
         </table>	         
	  </td>
    </tr>
  </table>
</form>
</body>
</html>

