<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Track.aspx.cs" Inherits="Track" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <wl:Seo ID="seo" runat="server" Title="" />
    <link href="Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <div>
            <div id="wrapper">
                <div id="wrapper2">
                    <!--头部-->
                    <wl:Header ID="hc" runat="server" />
                    <!--内容-->
                    <div class="margin_t" id="main" style="padding-bottom: 15px;">
                        <table class="tablecontent">
                            <tr>
                                <td>
                                    <table class="grid" id="tblCarrier">
                                        <tr>
                                            <th align="center" class="header_client">
                                                邮件号码
                                            </th>
                                            <th align="center" class="header_client">
                                                状态
                                            </th>
                                            <th align="center" class="header_client">
                                                位置
                                            </th>
                                            <th align="center" class="header_client">
                                                邮件寄达国
                                            </th>
                                            <th align="center" class="header_client">
                                                处理日期
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="rpLogisticInfo" runat="server">
                                            <ItemTemplate>
                                            <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                                                <td align="left">
                                                    <%# Eval("BarCode")%>
                                                </td>
                                                <td align="left">
                                                    <%# Eval("Status")%>
                                                </td>
                                                <td align="left">
                                                    <%# Eval("Location")%>
                                                </td>
                                                <td align="left">
                                                    <%# Eval("ToCountry")%>
                                                </td>
                                                <td align="left">
                                                    <%#  Convert.ToDateTime(Eval("DisposalTime")).ToShortDateString()%>
                                                </td>
                                            </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr id="trMsg" runat="server" visible="false">
                                            <td colspan="5" align="center">
                                                <asp:Label ID="lblMsg" runat="server" ForeColor="Maroon"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
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
