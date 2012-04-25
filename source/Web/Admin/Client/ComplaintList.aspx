<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComplaintList.aspx.cs" Inherits="Admin_Client_ComplaintList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:ClientNav ID="clientNav" runat="server"/>
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">客户服务 > 客户投诉</td>
    </tr>
    <tr>
        <td class="info">类型：<asp:DropDownList ID="ddlReplyStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReplyStatus_SelectedIndexChanged">
                <asp:ListItem Text="全部" Value="0"></asp:ListItem>
                <asp:ListItem Text="未回复" Value="False" Selected="True"></asp:ListItem>
                <asp:ListItem Text="已回复" Value="True"></asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtEndDate"/> <asp:Button
        ID="btnSearch" runat="server" Text="查 询" CssClass="button"/></td>
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
            <th align="center" class="header">编号</th>
            <th align="center" class="header">客户姓名</th>
            <th align="center" class="header">标题</th>
            <th align="center" class="header">部分投诉内容</th>
            <th align="center" class="header">提交时间</th>
            <th align="center" class="header">查看</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpComplaint" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="center"><%# Eval("ClientName") %></td>
                <td align="left"><%# StringHelper.CnCutString(Eval("Title").ToString(), 66) %></td>
                <td align="left"><%# StringHelper.CnCutString(Eval("Content").ToString(), 66)+"……" %></td>
                <td align="center"><%# Eval("CreateTime")%></td>
                <td align="center"><a href="Complaint.aspx?id=<%# Eval("Id") %>">查看</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><%# Eval("Id") %></td>
                <td align="center"><%# Eval("ClientName") %></td>
                <td align="left"><%# StringHelper.CnCutString(Eval("Title").ToString(), 66) %></td>
                <td align="left"><%# StringHelper.CnCutString(Eval("Content").ToString(), 66) + "……"%></td>
                <td align="center"><%# Eval("CreateTime")%></td>
                <td align="center"><a href="Complaint.aspx?id=<%# Eval("Id") %>">查看</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="7">
                    <asp:Button ID="btnDelete" runat="server" Text="删除选择项"  CssClass="button" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>  
</form>
</body>
</html>

