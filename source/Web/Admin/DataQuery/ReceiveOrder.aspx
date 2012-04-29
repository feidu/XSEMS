<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveOrder.aspx.cs" Inherits="Admin_DataQuery_ReceiveOrder" %>

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
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">数据查询 > 收件查询 > 收件详情</td>
    </tr>
    <tr>
        <td class="seperator"><input type="hidden" id="hdOrderDetailCount" value="<%=orderDetailCount %>"/><input type="hidden" id="hdOrderCosts" value="<%=order.Costs %>"/></td>
    </tr>
    <tr>
        <td class="info"><input type="button" class="button" value="返 回" onclick="javascript:location.href='ReceiveOrderList.aspx';" /></td>
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
            <td width="10%" class="label" >收件日期:</td>
            <td width="40%" class="content"><input type="text" onclick="WdatePicker()" class="Wdate" runat="server" id="txtReceivedDate" name="txtDate" readonly="readonly" /></td>            
          </tr>
          <tr>
            <td class="label" >客户姓名:</td>
            <td class="content"><asp:Label ID="lblClientName" runat="server" Text=""></asp:Label></td>
            <td class="label" >应收总计:</td>
            <td class="content" colspan="3"><input type="text" id="txtCosts" name="txtCosts" style="color:Blue;" runat="server" readonly="readonly" value="0" />元</td>
          </tr>         
          <tr>
            
            <td class="label" >制单时间:</td>
            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>               
            <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content"><asp:TextBox TextMode="multiLine" Rows="2" Width="100%" runat="server" ID="txtRemark"></asp:TextBox></td>          
          </tr>
          <tr id="trReturnReason" runat="server" visible="false">
            <td class="label" style="color:Red; height:24px;">审核退回原因:</td>
            <td class="content" colspan="5"><asp:Label ID="lblReason" runat="server" Text=""></asp:Label></td>          
          </tr>
         </table>	         
	  </td>
    </tr>    
    <tr>
      <td>
      	 <table class="grid">
          <tr>
            <td align="center" class="headers">序号</td>
            <td align="left" class="headers">国家</td>
            <td align="left" class="headers">承运商</td>
            <td align="left" class="headers">追踪号</td>
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
                <td align="center"><%=i%></td>
                <td align="left"><%=od.ToCountry%></td>
                <td align="left"><%=od.CarrierEncode%></td>    
                <td align="left"><%=od.BarCode%></td>  
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
                <td align="center"><a href="ReceiveOrderDetail.aspx?id=<%=od.Id %>">查看</a></td>
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

