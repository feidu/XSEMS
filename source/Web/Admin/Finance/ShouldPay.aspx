<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShouldPay.aspx.cs" Inherits="Admin_Finance_ShouldPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:FinanceNav ID="financeNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">财务管理 > 应付账款</td>
    </tr>
    <tr>
        <td class="info">日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate"/> &nbsp;&nbsp;&nbsp;承运商：<wl:CarrierDropDownList ID="ddlCarrier" runat="server"></wl:CarrierDropDownList>&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查 询" CssClass="button" OnClick="btnSearch_Click"/>&nbsp;&nbsp;<asp:Button ID="btnPayForCarrier" runat="server" Text="确认付款" CssClass="button" OnClick="btnPayForCarrier_Click" /></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td>
      <div id="divShouldPay" runat="server">
      <table class="grid">
              <tr>
                <th align="center" class="header">应付类型</th>
                <th align="center" class="header">应付款号</th>           
                <th align="center" class="header">应付日期</th>
                <th align="center" class="header">订单号码</th>   
                <th align="center" class="header">跟踪条码</th>     
                <th align="center" class="header">承运商</th>   
                <th align="center" class="header">国家</th>    
                <th align="center" class="header">重量</th>    
                <th align="center" class="header">数量</th>         
                <th align="center" class="header">应付金额</th>
                <th align="center" class="header">操作</th>
                <th align="center" class="header">选择</th>
              </tr>
              <asp:Repeater ID="rpShouldPay" runat="server">
                <ItemTemplate>
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                    <td align="center"><%# Eval("Type")%></td>
                    <td align="center"><%# Eval("Encode")%></td>          
                    <td align="left"><%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString() %></td>
                    <td align="center"><%# Eval("OrderEncode")%></td>   
                    <td align="center"><%# Eval("OrderDetail.BarCode")%></td>     
                    <td align="center"><%# Eval("Carrier.Name")%></td>
                    <td align="center"><%# Eval("OrderDetail.ToCountry")%></td>
                    <td align="center"><%# Eval("OrderDetail.Weight")%></td>
                    <td align="center"><%# Eval("OrderDetail.Count")%></td>
                    <td align="center"><%# Eval("OrderDetail.SelfTotalCosts")%></td>                    
                    <td align="center"><a href="ShouldPayView.aspx?id=<%# Eval("Id") %>">查看</a></td>                                               
                    <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
                  </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                  <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                    <td align="center"><%# Eval("Type")%></td>
                    <td align="center"><%# Eval("Encode")%></td>          
                    <td align="left"><%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString() %></td>
                    <td align="center"><%# Eval("OrderEncode")%></td>      
                    <td align="center"><%# Eval("OrderDetail.BarCode")%></td>     
                    <td align="center"><%# Eval("Carrier.Name")%></td>
                    <td align="center"><%# Eval("OrderDetail.ToCountry")%></td>
                    <td align="center"><%# Eval("OrderDetail.Weight")%></td>
                    <td align="center"><%# Eval("OrderDetail.Count")%></td>
                    <td align="center"><%# Eval("OrderDetail.SelfTotalCosts")%></td>                    
                    <td align="center"><a href="ShouldPayView.aspx?id=<%# Eval("Id") %>">查看</a></td>                                               
                    <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
                  </tr>
                </AlternatingItemTemplate>
              </asp:Repeater> 
              <tr style="display:none;">              
              <td align="right" colspan="12">
                    <asp:Button ID="btnDelete" runat="server"  CssClass="button"  Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>                      
            </table>	
            </div>
            <div id="divContent" runat="server" visible="false"></div>	
            <div id="divConfirmPaid" runat="server" visible="false" style="text-align:center">
            <table class="grid">
                  <tr>
                    <td class="label" width="9%" align="left">付款日期:</td>
                    <td class="content" width="91%" align="left"><input type="text" onclick="WdatePicker()" runat="server" id="txtPaidTime" name="txtDate" size="28" readonly="readonly" /></td>
                  </tr>  
                  <tr>
                    <td class="label" align="left">流 水 号:</td>
                    <td class="content" align="left"><asp:TextBox ID="txtInvoice" runat="server" Width="175"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td class="label" align="left">付款方式:</td>   
                    <td class="content" align="left"><wl:PaymentMethodDropDownList ID="ddlPaymentMethod" runat="server"></wl:PaymentMethodDropDownList></td>
                  </tr>   
                  <tr>
                    <td class="label" align="left">备&nbsp;&nbsp;&nbsp;&nbsp;注:</td>
                    <td class="content" align="left"><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="580" Columns="2"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td colspan="2" align="center"><asp:Button ID="btnConfirmPaid" Text="确认已付" runat="server" CssClass="button" OnClick="btnConfirmPaid_Click" /></td>
                  </tr>
            </table>                
            </div>
		</td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>  
</form>
</body>
</html>
