<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Area.aspx.cs" Inherits="Admin_PostSetting_Area" %>

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
        <td class="info2">物流设置 > 承运商设定 > 分区详情</td>
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
                      <td class="label" > 承 运 商: </td>
                      <td class="content"><asp:Label ID="lblCarrierName" runat="server"></asp:Label>
                      </td>
                    </tr>     
                    <tr>
                      <td class="label"> 分区名称: </td>
                      <td class="content"><asp:TextBox ID="txtName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>             
                    <tr><td colspan="2" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" /> &nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:javascript:history.go(-1);" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
