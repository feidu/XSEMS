<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Admin_PostSetting_UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../JS/Calendar/WdatePicker.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:PostSettingNav ID="postSettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 公司设定 > 员工列表</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateCompany.aspx">添加公司</a> | <a href="Default.aspx">公司列表</a> | <a href="UserList.aspx">员工列表</a></td>
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
            <th align="center" class="header">用户名</th>
            <th align="center" class="header">真实姓名</th>
            <th align="center" class="header">所属公司</th>
            <th align="center" class="header">性别</th>
            <th align="center" class="header">学历</th>
            <th align="center" class="header">手机</th>
            <th align="center" class="header">邮箱</th>
            <th align="center" class="header">入职时间</th>
            <th align="center" class="header">合同有效期</th>
            <%--<th align="center" class="header">提成</th>--%>
            <th align="center" class="header">操作</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpUser" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left"><%# Eval("Username") %></td>
                <td align="left"><%# Eval("RealName") %></td>
                <td align="left"><%# Backend.BAL.CompanyOperation.GetCompanyById(Convert.ToInt32(Eval("CompanyId"))).Name%></td>
                <td align="left"><%# Convert.ToBoolean(Eval("Sex")) ? "男" : "女"%></td>
                <td align="left"><%# Eval("Education") %></td>
                <td align="left"><%# Eval("Mobile") %></td>
                <td align="left"><%# Eval("Email") %></td>
                <td align="left"><%# Convert.IsDBNull(Eval("JoinDate")) ? "" : Convert.ToDateTime(Eval("JoinDate")).ToShortDateString()%></td>
                <td align="left"><%# Convert.IsDBNull(Eval("ContractDate")) ? "" : Convert.ToDateTime(Eval("ContractDate")).ToShortDateString()%></td>
                <%--<td align="center"><asp:TextBox ID="txtCommission" runat="server" Width="35"></asp:TextBox></td>--%>
                <td align="center"><a href="User.aspx?id=<%# Eval("Id") %>">编辑</a>&nbsp;|&nbsp;<a href="ChangePwd.aspx?id=<%# Eval("Id") %>">修改密码</a>&nbsp;|&nbsp;<a href="UserOpreator.aspx?id=<%# Eval("Id") %>">修改权限</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left"><%# Eval("Username") %></td>
                <td align="left"><%# Eval("RealName") %></td>
                <td align="left"><%# Backend.BAL.CompanyOperation.GetCompanyById(Convert.ToInt32(Eval("CompanyId"))).Name%></td>
                <td align="left"><%# Convert.ToBoolean(Eval("Sex")) ? "男" : "女"%></td>
                <td align="left"><%# Eval("Education") %></td>
                <td align="left"><%# Eval("Mobile") %></td>
                <td align="left"><%# Eval("Email") %></td>
                <td align="left"><%# Convert.IsDBNull(Eval("JoinDate")) ? "" : Convert.ToDateTime(Eval("JoinDate")).ToShortDateString()%></td>
                <td align="left"><%# Convert.IsDBNull(Eval("ContractDate")) ? "" : Convert.ToDateTime(Eval("ContractDate")).ToShortDateString()%></td>
                <%--<td align="center"><asp:TextBox ID="txtCommission" runat="server" Width="35"></asp:TextBox></td>--%>
                <td align="center"><a href="User.aspx?id=<%# Eval("Id") %>">编辑</a>&nbsp;|&nbsp;<a href="ChangePwd.aspx?id=<%# Eval("Id") %>">修改密码</a>&nbsp;|&nbsp;<a href="UserOpreator.aspx?id=<%# Eval("Id") %>">修改权限</a></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="13">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/> 
</form>
</body>
</html>