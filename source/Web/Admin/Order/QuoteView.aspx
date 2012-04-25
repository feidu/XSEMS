<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuoteView.aspx.cs" Inherits="Admin_Order_QuoteView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 报价管理 > 报价详情</td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
    <tr>
        <td class="info"><input type="button" class="button" value="返 回" onclick="javascript:location.href='QuoteList.aspx';" /></td>
    </tr>    
  </table>
  <table class="tablecontent">
    <tr><td align="center" style="height: 21px">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td>
      	 <table class="grid">
          <tr>
            <td width="10%" class="label" >报价单号:</td>
            <td width="23%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
            <td width="10%" class="label" >报价日期:</td>
            <td width="24%" class="content"><asp:Label ID="lblQuoteTime" runat="server" Text=""></asp:Label></td>
            <td width="10%" class="label" >所属公司:</td>
            <td width="23%" class="content"><asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >客户姓名:</td>
            <td class="content"><asp:Label ID="lblClientName" runat="server"></asp:Label></td>            
            <td class="label" >制 单 人:</td>
            <td class="content"><asp:Label ID="lblCreateUser" runat="server" Text=""></asp:Label></td>     
            <td class="label" >制单时间:</td>
            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>              
          </tr>
          <tr>
            <td class="label" >审 核 人:</td>
            <td class="content"><asp:Label ID="lblAuditUser" runat="server"></asp:Label></td>            
            <td class="label" >审核时间:</td>
            <td class="content" colspan="3"><asp:Label ID="lblAuditTime" runat="server" Text=""></asp:Label></td>     
          </tr>
          <tr>
            <td class="label" >备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
            <td class="content" colspan="5"><asp:TextBox TextMode="multiLine" Rows="2" Width="100%" runat="server" ID="txtRemark"></asp:TextBox></td>          
          </tr>         
         </table>	         
	  </td>
    </tr>
    <tr><td style="height:8px;"></td></tr>
    <tr>
      <td>
      	 <table class="grid">
          <tr style="font-weight:bold;">
            <td align="center" class="headers">序号</td>
            <td align="left" class="headers">承运商编号</td>
            <td align="left" class="headers">承运商名称</td>
            <td align="left" class="headers">区域</td>           
            <td align="left" class="headers">折扣</td>         
            <td align="left" class="headers">让利克数</td>     
            <td align="left" class="headers">挂号费打折</td>
            <td align="left" class="headers">挂号费</td>  
          </tr>
          <%
              if (result != null)
              {
                  int i = 1;
                  foreach (Backend.Models.QuoteDetail qd in result)
                  {
                      
               %>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%=i%></td>
                <td align="left"><%=qd.Carrier.Encode%></td>
                <td align="left"><%=qd.Carrier.Name%></td>
                <td align="left"><%=qd.CarrierArea.Name%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(qd.Discount.ToString())%></td>
                <td align="left"><%=qd.PreferentialGram.ToString()%></td>         
                <td align="left"><%=Convert.ToBoolean(qd.IsRegisterAbate) ? "是" : "否"%></td>
                <td align="left"><%=Backend.Utilities.StringHelper.CurtNumber(qd.RegisterCosts.ToString())%></td>       
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
