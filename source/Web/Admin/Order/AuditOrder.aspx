<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditOrder.aspx.cs" Inherits="Admin_Order_AuditOrder" %>

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
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 收件审核</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
    <tr>
        <td class="info"><asp:Button ID="btnAuditThrough" runat="server" Text="审核通过" CssClass="button" OnClick="btnAuditThrough_Click"/>&nbsp;&nbsp;<asp:Button ID="btnReturn" runat="server" Text="退回修改" CssClass="button" OnClientClick="return checkReason('请填写退回原因！')" OnClick="btnReturn_Click" />&nbsp;&nbsp;<asp:Button ID="btnDetain" runat="server" Text="审核扣货" CssClass="button" OnClientClick="return checkReason('请填写扣货原因！')" OnClick="btnDetain_Click" />&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='AuditOrderList.aspx';" /></td>
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
            <td width="10%" class="label" >收件日期:</td>
            <td width="24%" class="content"><asp:Label ID="lblReceiveDate" runat="server" Text=""></asp:Label></td>
            <td width="10%" class="label" >下单类型:</td>
            <td width="23%" class="content"><asp:Label ID="lblType" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >客户姓名:</td>
            <td class="content"><asp:Label ID="lblClientName" runat="server" Text=""></asp:Label></td>
            <td class="label" >收货方式:</td>
            <td class="content"><asp:Label ID="lblReceiveType" runat="server" Text=""></asp:Label></td>
            <td class="label" >结算方式:</td>
            <td class="content"><asp:Label ID="lblCalculateType" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >业 务 员:</td>
            <td class="content"><asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
            <td class="label" >收 件 人:</td>
            <td class="content"><asp:Label ID="lblReceiveUser" runat="server" Text=""></asp:Label></td>
            <td class="label" >制 单 人:</td>
            <td class="content"><asp:Label ID="lblCreateUser" runat="server" Text=""></asp:Label></td>                
          </tr>
          <tr>
            <td class="label" >应收总计:</td>
            <td class="content" colspan="3"><asp:Label ID="lblCosts" runat="server" Text="" ForeColor="blue"></asp:Label> 元</td>
            <td class="label" >制单时间:</td>
            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>                
          </tr>
          <tr>
            <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content" colspan="5"><asp:Label ID="lblRemark" runat="server" Text=""></asp:Label></td>          
          </tr>          
          <tr id="trCheckReason" runat="server" visible="false">
            <td class="label" style="color:Red; height:24px;">检验退回原因:</td>
            <td class="content" colspan="5"><asp:Label ID="lblCheckReason" runat="server" Text=""></asp:Label></td>          
          </tr>
          <tr>
            <td class="label" >退回扣货原因:</td>
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
            <td align="left" class="headers">承运商</td>
            <td align="left" class="headers">邮件数量</td>           
            <td align="left" class="headers">计费重量</td>
            <td align="left" class="headers">每千克价</td>   
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
                <td align="left"><%=od.CarrierEncode%></td>
                <td align="left"><%=od.Count%></td>
                <td align="left"><%=od.Weight%></td>
                <td align="left"><%=od.KgPrice%></td>
                <td align="left"><%=od.PostCosts%></td>
                <td align="left"><%=od.RegisterCosts%></td>
                <td align="left"><%=od.RemoteCosts%></td>
                <td align="left"><%=od.DisposalCosts%></td>
                <td align="left"><%=od.FetchCosts%></td>
                <td align="left"><%=od.MaterialCosts%></td>
                <td align="left"><%=od.OtherCosts%></td>
                <td align="left"><%=od.TotalCosts%></td>
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
