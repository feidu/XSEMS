<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_News_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />

</head>
<body>
<form id="form1" runat="server">
   <wl:WebSettingNav ID="webSettingNav" Title="编辑信息" runat="server" />
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid">
          <tr>
            <td width="85" align="left" valign="middle" class="label">标&nbsp;&nbsp;&nbsp;&nbsp;题: </td>
            <td align="left" valign="middle" class="content"><asp:TextBox ID="tbxTitle"  Width="450" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td align="left" valign="middle" class="label">分&nbsp;&nbsp;&nbsp;&nbsp;类:</td>
            <td align="left" valign="middle" class="content">
                <asp:DropDownList ID="ddlNewsCategory" runat="server">
                </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td align="left" valign="middle" class="label">内&nbsp;&nbsp;&nbsp;&nbsp;容:</td>
            <td align="left" valign="middle" class="content"><input type="hidden" name="tbxContent" runat="server" id="tbxContent" class="por-import-srk"  dataType="LimitB" min="1" max="1500" msg=""/>
                            <script type="text/javascript" src="../../Js/HtmlEditor/HtmlEditor.js"></script>
                            <script type="text/javascript" language="javascript">
                                var editor = new KindEditor("editor");     
                                editor.hiddenName = "tbxContent";
                                editor.editorWidth = "100%";
                                editor.editorHeight = "234px";
                                editor.show();
                                function KindSubmit() {
                                 editor.data();
                                }
                               
                            </script> </td>
          </tr>
          <tr>
            <td align="left" valign="middle" class="label">是否首页显示:</td>
            <td align="left" valign="middle" class="content"><asp:CheckBox ID="cbxDisplay" runat="server" /></td>
          </tr>
          <tr>
            <td align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle"><asp:Button ID="btnUpdate" runat="server" CssClass="button" OnClientClick="KindSubmit()"  Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='NewsList.aspx';" /></td>
          </tr>
        </table></td>
    </tr>
  </table>
    </form>
</body>
</html>
