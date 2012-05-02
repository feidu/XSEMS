<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderCostList.aspx.cs" Inherits="Client_OrderCostList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
<link rel="stylesheet" type="text/css" href="../css/lightview.css">
<script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/prototype/1.6.1/prototype.js'></script>
<script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/scriptaculous/1.8.2/scriptaculous.js?load=effects'></script>
<script type='text/javascript' src="../Js/lightview.js"></script>
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
              
              <!--中间右边内容部分--> 
              <table class="tablecontent">
                <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="消费明细"></wl:ClientTop></td></tr>  
                <tr><td align="left" valign="bottom" style="padding-left:5px;">日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate" readonly="readonly"/> 包裹单号：<input id="txtBarCode" runat="server" size="15" class="textBox" /> 备注：<input id="txtRemark" runat="server" size="15" class="textBox" />&nbsp;&nbsp;<input type="button" id="btnSerach" runat="server" value="查 询" class="button" onserverclick="btnSerach_ServerClick"/>&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" CssClass="button" Text="导出" OnClick="btnExport_Click" /></td></tr>                   
                <tr>
                  <td><table class="grid">
                          <tr>
                            <th align="center" class="header_client">收件单号</th>
                            <th align="center" class="header_client">包裹单号</th>
                            <th align="center" class="header_client">备注</th> 
                            <th align="center" class="header_client">收件人</th>           
                            <th align="center" class="header_client">数量</th>
                            <th align="center" class="header_client">重量</th>                              
                            <th align="center" class="header_client">国家</th>
                            <th align="center" class="header_client">费用</th>
                            <th align="center" class="header_client">录入时间</th>
                            <th align="center" class="header_client">最后处理时间</th>
                            <th align="center" class="header_client">状态</th>
                          </tr>
                          <asp:Repeater ID="rpOrder" runat="server">
                            <ItemTemplate>
                              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                                <td align="center"><%# Eval("OrderEncode")%></td>
                                <td align="center"><%# Convert.ToBoolean(Eval("IsTracking")) ? "<a href='PostStatus.aspx?barcode=" + Eval("BarCode") + "' class='lightview' title=' :: :: topclose: true, autosize: true'>" + Eval("BarCode") + "</a>" : "" + Eval("BarCode") + ""%></td>    
                                <td align="center"><%# Eval("Remark")%></td>  
                                <td align="center"><%# Eval("ToUsername")%></td>      
                                <td align="center"><%# Eval("Count")%></td>                                     
                                <td align="center"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("Weight").ToString())%></td>                                     
                                <td align="center"><%# Eval("ToCountry")%></td>                                     
                                <td align="center"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("TotalCosts").ToString())%></td>     
                                <td align="center"><%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString()%></td>     
                                <td align="center"><%# Convert.ToDateTime(Eval("LastDisposalTime")) > DateTime.MinValue ? "" + Convert.ToDateTime(Eval("LastDisposalTime")).ToShortDateString() + "" : ""%></td>          
                                <td align="left"><%# Eval("PostStatus")%></td>                                          
                              </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                                <td align="center"><%# Eval("OrderEncode")%></td>
                                <td align="center"><%# Convert.ToBoolean(Eval("IsTracking")) ? "<a href='PostStatus.aspx?barcode=" + Eval("BarCode") + "' class='lightview' title=' :: :: topclose: true, autosize: true'>" + Eval("BarCode") + "</a>" : "" + Eval("BarCode") + ""%></td>    
                                <td align="center"><%# Eval("Remark")%></td>    
                                <td align="center"><%# Eval("ToUsername")%></td>    
                                <td align="center"><%# Eval("Count")%></td>                                     
                                <td align="center"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("Weight").ToString())%></td>                                     
                                <td align="center"><%# Eval("ToCountry")%></td>                                     
                                <td align="center"><%# Backend.Utilities.StringHelper.CurtNumber(Eval("TotalCosts").ToString())%></td>       
                                <td align="center"><%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString()%></td>   
                                <td align="center"><%# Convert.ToDateTime(Eval("LastDisposalTime")) > DateTime.MinValue ? "" + Convert.ToDateTime(Eval("LastDisposalTime")).ToShortDateString() + "" : ""%></td>       
                                <td align="left"><%# Eval("PostStatus")%></td>   
                              </tr>
                            </AlternatingItemTemplate>
                          </asp:Repeater>                                                
                        </table>		
		            </td>
                </tr>                
              </table>              
              <wl:Pagination ID="pagi" runat="server"/>
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
