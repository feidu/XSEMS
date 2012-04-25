<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Track.aspx.cs" Inherits="Config_Track" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>物流追踪</title>
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <script src="../Admin/Js/Calendar/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; padding-top:50px;">
    <table width="220" style=" border:1px solid #E2E2E2;">
                <tr><td align="left" valign="bottom" style="padding-left:5px;" height="10px;">
                    </td></tr>     
                <tr><td align="center" style="padding-left:5px; padding-bottom:10px;">选择日期：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="txtStartDate" readonly="readonly"/>
                    </td></tr>                   
                <tr>
                  <td align="center" style="padding-left:5px;"><asp:Button ID="btnExport" runat="server" CssClass="button" Text="导 出" 
                        onclick="btnExport_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnExportDetail" runat="server" CssClass="button" Text="导出明细" 
                        onclick="btnExportDetail_Click" /></td>
                </tr>                
              </table>              
    </div>
    </form>
</body>
</html>
