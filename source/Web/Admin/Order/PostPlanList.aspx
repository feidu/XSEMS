<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostPlanList.aspx.cs" Inherits="Admin_Order_PostPlanList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:OrderNav ID="orderNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">业务管理 > 发件计划</td>
    </tr>
    <tr>
        <td class="info"><a href="CreatePostPlan.aspx">添加发件计划</a>&nbsp;&nbsp;&nbsp;&nbsp;日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate"/> <asp:Button
        ID="btnSearch" runat="server" Text="查 询" CssClass="button" OnClick="btnSearch_Click"/></td>
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
                <th align="center" class="header">承运商</th>                
                <th align="center" class="header">发货包裹数量</th>
                <th align="center" class="header">总重量</th>     
                <th align="center" class="header">装袋仓库</th>     
                <th align="center" class="header">制单人</th>
                <th align="center" class="header">制单时间</th>      
                <th align="center" class="header">操作</th>
              </tr>
              <asp:Repeater ID="rpPostPlan" runat="server">
                <ItemTemplate>
                  <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                    <td align="center"><%# Eval("Carrier.Name") %></td>                    
                    <td align="center"><%# Eval("PackageCount")%></td>     
                    <td align="center"><%# Eval("Weight")%></td>     
                    <td align="center"><%# Eval("Depot.Name")%></td>
                    <td align="center"><%# Eval("User.RealName")%></td>
                    <td align="center"><%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString()%></td> 
                    <td align="center"><a href="PostPlan.aspx?id=<%# Eval("Id") %>">查看</a></td>                                             
                  </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                  <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                    <td align="center"><%# Eval("Carrier.Name") %></td>                    
                    <td align="center"><%# Eval("PackageCount")%></td>     
                    <td align="center"><%# Eval("Weight")%></td>     
                    <td align="center"><%# Eval("Depot.Name")%></td>
                    <td align="center"><%# Eval("User.RealName")%></td>
                    <td align="center"><%# Convert.ToDateTime(Eval("CreateTime")).ToShortDateString()%></td> 
                    <td align="center"><a href="PostPlan.aspx?id=<%# Eval("Id") %>">查看</a></td>     
                  </tr>
                </AlternatingItemTemplate>
              </asp:Repeater>        
              <tr><td align="right" colspan="7"><asp:Button ID="btnDelete" Text="删除选择项" runat="server" CssClass="button" OnClick="btnDelete_Click"/></td></tr>              
            </table>		
		</td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>  
</form>
</body>
</html>
