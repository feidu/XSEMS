<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CostTypeList.aspx.cs" Inherits="Admin_PostSetting_CostTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">   
  <wl:PostSettingNav ID="postSettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 费用类型</td>
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
            <th align="center" class="header">费用名称</th>
            <th align="center" class="header">是否计入管理成本</th>
            <th align="center" class="header">是否计入业务员成本</th>
            <th align="center" class="header">选择</th>
          </tr>
          <asp:Repeater ID="rpCostType" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left"><asp:TextBox ID="txtName" runat="server" Width="200"></asp:TextBox></td>
                <td align="center"><asp:CheckBox ID="chkManageCosts" runat="server" /></td>
                <td align="center"><asp:CheckBox ID="chkSalorCosts" runat="server" /></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="center"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left"><asp:TextBox ID="txtName" runat="server" Width="200"></asp:TextBox></td>
                <td align="center"><asp:CheckBox ID="chkManageCosts" runat="server" /></td>
                <td align="center"><asp:CheckBox ID="chkSalorCosts" runat="server" /></td>
                <td align="center"><input id="chkId" name="chkId" type="checkbox" value="<%# Eval("Id")%>" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="5">
                    <asp:Button ID="lbtnCreate" runat="server" CssClass="button" Text="添 加" OnClick="lbtnCreate_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="button" Text="删除选择项" OnClientClick="return confirm('您确认要删除吗？')" OnClick="btnDelete_Click" /></td>
              </tr>
        </table>	
        <table class="grid" id="tbCostTypeCreate" runat="server">    
                <tr>
                    <td colspan="2" style="height:30px;"></td>
                </tr>
                <tr>
                    <td width="150" align="left" valign="middle" class="header" colspan="2">添加付款方式: </td>
                </tr>
                <tr>
                  <td class="label" width="14%"> 费用类型名称: </td>
                  <td class="content" width="86%"><asp:TextBox ID="txtName" runat="server" Width="180"></asp:TextBox>
                  </td>
                </tr>            
                <tr>
                  <td class="label"> 是否计入管理成本: </td>
                  <td class="content"><asp:CheckBox ID="chkManageCosts" runat="server" />
                  </td>
                </tr>                    
                <tr>
                  <td class="label"> 是否计入业务员成本: </td>
                  <td class="content"><asp:CheckBox ID="chkSalorCosts" runat="server" />
                  </td>
                </tr>                        
                <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="添 加" OnClick="btnCreate_Click" /></td></tr>
            </table>			
        </td>
    </tr>
  </table>
</form>
</body>
</html>