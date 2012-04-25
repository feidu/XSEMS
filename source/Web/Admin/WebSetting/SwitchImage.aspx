<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwitchImage.aspx.cs" Inherits="Admin_WebSetting_SwitchImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
   <wl:WebSettingNav ID="webSettingNav" Title="网站信息设置" runat="server" />
  <table class="tablecontent">
    <tr><td align="center"><asp:Label ForeColor="red" ID="lblMsg" runat="server"></asp:Label></td></tr>
    <tr><td align="center">图片最佳大小：(宽)978px * (高)289px</td></tr>
    <tr>
      <td><table class="grid">
            <tr><th width="7%" align="center" class="header"></th>
            <th align="center" class="header" style="display:none;"></th>
            <th width="45%" align="center" class="header">图片路径</th>
            <th width="32%" align="center" class="header">链接地址</th>
            <th width="10%" align="center" class="header">描述</th>
            <th width="6%" align="center" class="header">排序号</th>
          </tr>
    <asp:Repeater ID="rep" runat="server">
      <ItemTemplate>
          <tr>
            <td height="30" align="center" valign="middle" class="label">图片<%# DataBinder.Eval(Container, "DataItem.RowId") %> : </td>
            <td height="30" align="center" valign="middle" class="label" style="display:none;"><asp:HiddenField ID="hdId" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Id") %>' /></td>
            <td height="30" align="left" valign="middle" class="content"><asp:FileUpload ID="fuImage" CssClass="button" runat="server" Width="360px" />&nbsp;&nbsp;<%# DataBinder.Eval(Container, "DataItem.Id").ToString() != "" ? "<a href='" + Backend.Utilities.FilePath.FilePathGenerator.GeneratePhotoHttpUrl(Eval("Path").ToString()) + "' target='_blank' border='0'>查看</a>" : ""%></td>
            <td align="left" valign="middle" class="content"><span style="font-size:12px; font-weight:bold;">http://</span><asp:TextBox ID="txtUrl" runat="server" Width="220px" Text='<%# DataBinder.Eval(Container, "DataItem.Url") %>'></asp:TextBox></td>
            <td align="left" valign="middle" class="content"><asp:TextBox ID="txtTitle" runat="server" Width="110px" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>'></asp:TextBox></td>
            <td align="left" valign="middle" class="content"><asp:TextBox ID="txtSortNum" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SortNum") %>'></asp:TextBox></td>
          </tr>
      </ItemTemplate>
    </asp:Repeater>
          <tr>
            <td height="30" align="left" valign="middle" colspan="2"><asp:LinkButton ID="lbAdd" runat="server" Font-Size="12px" Font-Underline="false" OnClick="lbAdd_Click">加一行</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton ID="lbSubtract" runat="server" Font-Underline="false" Font-Size="12px" OnClick="lbSubtract_Click">删一行</asp:LinkButton></td>
            <td align="right" valign="middle" colspan="3">< - 排序号大的排在前面 - > <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click" Text="提交/修改" /></td>
          </tr>
        </table></td>
    </tr>
  </table>
</form>
</body>
</html>
