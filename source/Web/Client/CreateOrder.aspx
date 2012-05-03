<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateOrder.aspx.cs" Inherits="Client_CreateOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <wl:Seo ID="seo" runat="server" Title="" />
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/Js/util.js" type="text/javascript" language="javascript"></script>
    <script src="/Admin/Js/jquery-1.2.6.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript" src="../Admin/JS/Calendar/WdatePicker.js"></script>
    <script language="javascript" type="text/ecmascript">
        function openCountryWindow() {
            window.open("../Config/CountryList.aspx", "国家列表", "toolbar=no,top=20,left=150,width=600,height=550,menubar=no,scrollbars=yes,resizable=yes,status=yes", "");
        }

        function chkForm() {
            var barCode = document.getElementById("txtBarCode");
            if (barCode.value.length <= 0) {
                barCode.focus();
                return false;
            }
        }    
    </script>
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
                                <table class="tablecontent">
                                    <tr>
                                        <td align="left" class="top_content">
                                            <wl:ClientTop runat="server" ID="clientTop" Title="新建发货标签"></wl:ClientTop>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="grid">
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="red"></asp:Label>
                                                    </td>
                                                </tr>                                                
                                                <tr>
                                                    <td class="label">
                                                        发货日期:
                                                    </td>
                                                    <td class="content">
                                                        <input type="text" onclick="WdatePicker()" class="Wdate" style="width: 179px;" runat="server"
                                                            id="txtCreateDate" readonly="readonly" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label">
                                                        承 运 商:
                                                    </td>
                                                    <td class="content">
                                                        <asp:DropDownList ID="ddlCarrier" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label">
                                                        包裹重量:
                                                    </td>
                                                    <td class="content">
                                                        <asp:TextBox ID="txtWeight" runat="server" Width="180"></asp:TextBox>
                                                        克
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label">
                                                        国&nbsp;&nbsp;&nbsp;&nbsp;家:
                                                    </td>
                                                    <td class="content">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="35%">
                                                            <tr>
                                                                <td align="left" width="85%">
                                                                    <input id="txtCountry" type="text" style="width: 100%; color: #555555;" runat="server"
                                                                        readonly="readonly" value="UnitedStates -- 美国" />
                                                                </td>
                                                                <td align="right" width="15%">
                                                                    <asp:ImageButton ImageUrl="../Admin/Images/btn_bg1.gif" runat="server" ID="btnOpenCountryWindow"
                                                                        OnClientClick="openCountryWindow()" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label">
                                                        备&nbsp;&nbsp;&nbsp;&nbsp;注:
                                                    </td>
                                                    <td class="content">
                                                        <asp:TextBox ID="txtRemark" runat="server" Width="180"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label">
                                                        挂号条码:
                                                    </td>
                                                    <td class="content">
                                                        <asp:TextBox ID="txtBarCode" runat="server" Width="180"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnCreate" runat="server" CssClass="button" Text="提 交" OnClientClick="return chkForm()"
                                                            OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button"
                                                                value="返 回" onclick="javascript:location.href='Default.aspx'" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <input type="hidden" id="hdCountry" runat="server" value="UnitedStates" />
                    <input type="hidden" id="txtToCountry" runat="server" value="UnitedStates" />
                    <input type="hidden" id="txtCarrier" runat="server" />
                    <!--尾部-->
                    <wl:Footer ID="footer" runat="server" />
                </div>
            </div>
        </div>
        </form>
    </center>
</body>
</html>
