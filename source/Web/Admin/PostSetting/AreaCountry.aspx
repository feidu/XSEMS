<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AreaCountry.aspx.cs" Inherits="Admin_PostSetting_AreaCountry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
function checkAll()
{
    var tblCountry = document.getElementById("tblCountry");
    var chkAll=document.getElementById("chkAll");
    var count = parseInt(tblCountry.rows.length-2);
    for(var i=0; i< count; i++)
    {
        var chkItem = null;
        if(i<10)
        {
            chkItem = document.getElementById("rpCountry_ctl0"+ i +"_chkId");
        }
        else
        {
            chkItem = document.getElementById("rpCountry_ctl"+ i +"_chkId");
        }
        if(chkAll.checked==true)
        {
            chkItem.checked=true;
        }
        else
        {
            chkItem.checked=false;
        }
    }
}
</script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:PostSettingNav ID="postSettingNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">物流设置 > 分区设定 > 修改分区国家</td>
    </tr>    
    <tr>
        <td class="info">承运商：<asp:Label ID="lblCarrier" runat="server" Text="" ForeColor="maroon"></asp:Label>&nbsp;&nbsp;&nbsp;分区名称：<asp:Label ID="lblCarrierArea" runat="server" ForeColor="maroon"></asp:Label></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
    <tr>
      <td><table class="grid" id="tblCountry">
          <tr>
            <th align="center" class="header">编号</th>
            <th align="center" class="header">英文名</th>
            <th align="center" class="header">中文名</th>
            <th align="center" class="header">所属洲</th>    
            <th align="center" class="header"><input type="checkbox" id="chkAll" onclick="checkAll()" /></th>
          </tr>
          <asp:Repeater ID="rpCountry" runat="server">
            <ItemTemplate>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="left"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left"><%# Eval("EnglishName") %></td>
                <td align="left"><%# Eval("ChineseName") %></td>
                <td align="left"><%# Backend.Utilities.EnumConvertor.ContinentTypeConvertToString(Convert.ToByte(Eval("Continent")))%></td>
                <td align="center"><asp:CheckBox ID="chkId" runat="server" /></td>
              </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                <td align="left"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                <td align="left"><%# Eval("EnglishName") %></td>
                <td align="left"><%# Eval("ChineseName") %></td>
                <td align="left"><%# Backend.Utilities.EnumConvertor.ContinentTypeConvertToString(Convert.ToByte(Eval("Continent")))%></td>
                <td align="center"><asp:CheckBox ID="chkId" runat="server" /></td>
              </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
          <tr>
                <td align="right" colspan="5">
                    <asp:Button ID="btnUpdate" runat="server" Text="修 改" CssClass="button" OnClick="btnUpdate_Click" /> &nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:javascript:history.go(-1);" /></td>
          </tr>
        </table>		
        </td>
    </tr>
  </table>
  <wl:Pagination ID="pagi" runat="server"/>
</form>
</body>
</html>

