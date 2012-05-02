<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Client_Order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<center>
<form id="form1" runat="server">
  <div>
    <div id="wrapper">
      <div id="wrapper2">
        <!--头部-->
        <wl:HeaderClient ID="hc" runat="server" />  
        <!--内容-->
        <div id="content">
          <div id="main_client">
            <div class="left_bar_client">
              <!--中间左边导航部分-->
              <wl:Left ID="left" runat="server" />
            </div>
            <div class="right_bar_client">
              <table class="tablecontent">
                <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="订单详情"></wl:ClientTop></td></tr> 
                <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>                   
                <tr>
                  <td>
      	             <table class="grid">
                      <tr>
                        <td width="12%" class="label" >收件单号:</td>
                        <td width="38%" class="content" colspan="2"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
                        <td width="13%" class="label">制单时间:</td>
                        <td width="37%" class="content" colspan="2"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>  
                      </tr>
                      <tr>
                        <td class="label" >应收总计:</td>
                        <td class="content" colspan="5"><input type="text" id="txtCosts" name="txtCosts" style="color:Blue;" runat="server" readonly="readonly" value="0" />元</td>                                      
                      </tr>
                      <tr>
                        <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
                        <td class="content" colspan="5"><asp:Label ID="lblRemark" runat="server" Text=""></asp:Label></td>          
                      </tr>
                      <tr id="trReturnReason" runat="server" visible="false">
                        <td class="label" style="color:Red; height:24px;"><asp:Label ID="lblReasonTitle" runat="server"></asp:Label>:</td>
                        <td class="content" colspan="5"><asp:Label ID="lblReason" runat="server" Text=""></asp:Label></td>          
                      </tr>                      
                      </table>
                       </td></tr>
                     </table>	     
	              </td>
                </tr>                
                <tr>
                  <td>
      	             <table class="grid">
      	              <tr><td class="label" style="font-weight:bold;" colspan="8"> 订单明细</td></tr>
                      <tr>
                        <td align="center" class="headers">序号</td>
                        <td align="left" class="headers">国家</td>
                        <td align="left" class="headers">承运商编号</td>
                        <td align="left" class="headers">承运商名称</td>
                        <td align="left" class="headers">追踪码</td>
                        <td align="left" class="headers">数量</td>           
                        <td align="left" class="headers">计费重量(KG)</td>                      
                        <td align="left" class="headers">应收费用</td>      
                      </tr>
                      <%
                          if (result != null)
                          {
                              int i = 1;
                              foreach (Backend.Models.OrderDetail od in result)
                              {
                                  
                           %>
                          <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                            <td align="center"><%=i%></td>
                            <td align="left"><%=od.ToCountry%></td>
                            <td align="left"><%=od.CarrierEncode%></td>
                            <td align="left"><%= od.CarrierEncode==null?"": Backend.BAL.CarrierOperation.GetCarrierByEncode(od.CarrierEncode).Name%></td>
                            <td align="left"><%=od.BarCode%></td>
                            <td align="left"><%=od.Count%></td>
                            <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.Weight.ToString())%></td>                            
                            <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(od.TotalCosts.ToString())%></td>
                          </tr>
                          <% i++;
                         }
                     }%>   
                     </table>	         
	              </td>
                </tr>
              </table>
            </div>
          </div>
        </div>
        <!--尾部-->
        <wl:Footer ID="footer" runat="server" />
      </div>
    </div>
  </div>
</form>
</center>
</body>
</html>
