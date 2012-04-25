<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Country.aspx.cs" Inherits="Admin_PostSetting_Country" %>

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
        <td class="info2">物流设置 > 国家设定 > 国家详情</td>
    </tr>
    <tr>
        <td class="info"><a href="CreateCountry.aspx">添加国家</a> | <a href="CountryList.aspx">国家列表</a></td>
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
                      <td class="label" width="14%"> 英 文 名: </td>
                      <td class="content" width="86%"><asp:TextBox ID="txtEnglishName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>            
                    <tr>
                      <td class="label"> 中 文 名: </td>
                      <td class="content"><asp:TextBox ID="txtChineseName" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>                    
                    <tr>
                      <td class="label"> 国家代码: </td>
                      <td class="content"><asp:TextBox ID="txtCode" runat="server" Width="180"></asp:TextBox>
                      </td>
                    </tr>
                    <tr>
                      <td class="label"> 所 属 洲: </td>
                      <td class="content"><select id="slContinent" name="slContinent" runat="server">
                                            <option value="1">亚洲</option>
                                            <option value="2">欧洲</option>
                                            <option value="3">非洲</option>
                                            <option value="4">北美洲</option>
                                            <option value="5">南美洲</option>
                                            <option value="6">大洋洲</option>
                                            <option value="7">南极洲</option>
                                            </select>
                      </td>
                    </tr>            
                    <tr>
                      <td class="label">排在前面</td>
                      <td class="content"><asp:CheckBox ID="chkIsFront" runat="server" Checked="false" /></td>
                    </tr>       
                    <tr><td colspan="2" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click" />&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='CountryList.aspx';" /></td></tr>
                </table>		
        </td>
    </tr>
  </table>
</form>
</body>
</html>
