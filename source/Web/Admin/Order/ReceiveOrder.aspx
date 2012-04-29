<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveOrder.aspx.cs" Inherits="Admin_Order_ReceiveOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function checkDetailCount()
{
    var detailCount = document.getElementById("hdOrderDetailCount");
    var orderCosts = document.getElementById("hdOrderCosts");
    if(parseInt(detailCount.value)<=0)
    {
        alert("此订单还未添加明细！");
        return false;
    }
    if(parseFloat(orderCosts.value)<=0)
    {
        alert("此订单明细还未计算费用！");
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
        <td class="info2">业务管理 > 收件计划</td>
    </tr>
    <tr>
        <td class="seperator"><input type="hidden" id="hdOrderDetailCount" value="<%=orderDetailCount %>"/><input type="hidden" id="hdOrderCosts" value="<%=order.Costs %>"/></td>
    </tr>
    <tr>
        <td class="info"><asp:Button ID="btnSubmit" runat="server" Text="提交审核" CssClass="button" OnClientClick="return checkDetailCount()" OnClick="btnSubmit_Click" />&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" Text="删 除" CssClass="button" OnClientClick="return confirm('您确认要删除？');" OnClick="btnDelete_Click" />&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='Default.aspx';" /></td>
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
            <td width="40%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
            <td class="label" >制单时间:</td>
            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>        
          </tr>
          <tr>
           <td class="label" >客户姓名:</td>
            <td class="content"><asp:Label ID="lblClientName" runat="server" Text=""></asp:Label></td>
            <td class="label" >应收总计:</td>
            <td class="content"><input type="text" id="txtCosts" name="txtCosts" style="color:Blue;" runat="server" readonly="readonly" value="0" />元</td>   
          </tr>
          <tr>            
            <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content" colspan="3"><asp:TextBox TextMode="multiLine" Rows="1" Width="100%" runat="server" ID="txtRemark"></asp:TextBox></td>          
          </tr>
          <tr id="trReturnReason" runat="server" visible="false">
            <td class="label" style="color:Red; height:24px;">审核退回原因:</td>
            <td class="content" colspan="5"><asp:Label ID="lblReason" runat="server" Text=""></asp:Label></td>          
          </tr>
         </table>	         
	  </td>
    </tr>
    <tr><td align="left"><input type="button" class="button" value="添加明细" onclick="javascript:location.href='CreateOrderDetail.aspx?id=<%=id %>';" />&nbsp;&nbsp;<asp:Button ID="btnDeleteDetail" runat="server" Text="删除明细" CssClass="button" OnClick="btnDeleteDetail_Click" /></td></tr>
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
            <td align="left" class="headers">偏远费</td>
            <td align="left" class="headers">处理费</td>
            <td align="left" class="headers">取件费</td>           
            <td align="left" class="headers">材料费</td>
            <td align="left" class="headers">燃油费</td>
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
                <td align="left"><%=od.Weight%></td>
                <td align="left"><%=od.PostCosts%></td>
                <td align="left"><%=od.RegisterCosts%></td>
                <td align="left"><%=od.RemoteCosts%></td>
                <td align="left"><%=od.DisposalCosts%></td>
                <td align="left"><%=od.FetchCosts%></td>
                <td align="left"><%=od.MaterialCosts%></td>
                <td align="left"><%=od.FuelCosts %></td>
                <td align="left"><%=od.OtherCosts%></td>
                <td align="left"><%=od.TotalCosts%></td>
                <td align="center"><a href="ReceiveOrderDetail.aspx?id=<%=od.Id %>">编辑</a> | <a href="CreateInsurance.aspx?id=<%=od.Id %>">保价</a></td>
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
