<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_WebSetting_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <wl:WebSettingNav ID="webSettingNav" Title="网站信息设置" runat="server" />
    <table class="tablecontent">
        <tr>
            <td>
                <table class="grid">
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ForeColor="red" ID="lblMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            网站标题:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxTitle" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="height: 40px; width: 85px;">
                            关 键 字:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxKeyword" runat="server" Width="600px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            描&nbsp;&nbsp;&nbsp;&nbsp;述:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxDescription" runat="server" Height="50px" TextMode="MultiLine"
                                Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            联系电话:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxPhoneNuber" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            传&nbsp;&nbsp;&nbsp;&nbsp;真:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxFaxNumber" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            邮&nbsp;&nbsp;&nbsp;&nbsp;编:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxPostalcode" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            地&nbsp;&nbsp;&nbsp;&nbsp;址:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxAddress" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            邮&nbsp;&nbsp;&nbsp;&nbsp;箱:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxEmail" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            MSN账 号:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxMSNAccount" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            版权信息:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxCopyright" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" class="label" style="width: 85px">
                            备案信息:
                        </td>
                        <td align="left" valign="middle" class="content">
                            <asp:TextBox ID="tbxRecord" runat="server" Width="600px"></asp:TextBox>
                        </td>
                        <td align="left" class="content" valign="middle">
                        </td>
                    </tr>
                    <!--    
          <tr>
            <td align="left" valign="middle" class="label" style="height: 40px; width: 85px;">公&nbsp;&nbsp;&nbsp;&nbsp;告: </td>
            <td align="left" valign="middle" class="content"><asp:TextBox ID="tbxAnnouncement" runat="server" Width="600px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
              <td align="left" class="content" valign="middle">
              </td>
          </tr>
          -->
                    <tr>
                        <td align="center" valign="middle" colspan="2" width="704px">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClientClick="javascript:return confirm('您确定要修改吗？')"
                                OnClick="btnSubmit_Click" Text="修 改" />
                        </td>
                        <td align="left" valign="middle">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
