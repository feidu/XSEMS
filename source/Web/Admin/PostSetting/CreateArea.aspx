<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateArea.aspx.cs" Inherits="Admin_PostSetting_CreateArea" %>

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
        <td class="info2">物流设置 > 分区设定 > 添加分区</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateArea.aspx">添加分区</a> | <a href="AreaList.aspx">分区列表</a></td>
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
                    <tr id="trLblCarrier" runat="server" visible="false">
                      <td class="label" width="14%"> 承 运 商: </td>
                      <td class="content" width="86%"><asp:Label ID="lblCarrier" runat="server" Text=""></asp:Label>
                      </td>
                    </tr>       
                    <tr id="trDdlCarrier" runat="server" visible="false">
                      <td class="label" > 承 运 商: </td>
                      <td class="content"><wl:CarrierDropDownList ID="ddlCarrier" runat="server"></wl:CarrierDropDownList>
                      </td>
                    </tr>     
                    <tr>
                      <td class="label"> 分区名称: </td>
                      <td class="content"><asp:TextBox ID="txtName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>             
                    <tr><td colspan="2" align="center"><asp:Button ID="btnCreate" runat="server" CssClass="button" Text="添 加" OnClick="btnCreate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='CarrierList.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
