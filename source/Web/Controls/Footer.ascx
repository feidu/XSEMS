<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="Controls_Footer" %>

  <tr>
    <td height="15">&nbsp;</td>
  </tr>  
  <tr>
    <td height="30" align="center" valign="middle"><hr style="border:1px dashed #cccccc; height:1px"></td>
  </tr>
  <tr>
    <td height="60" align="center" valign="middle"><table width="980" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="25" align="center" valign="middle" style="font-family:宋体; font-size:12px; color: #333;" >地址: <%= address %>  邮编: <%=postalcode %> 电话: <%=phoneNumber %> 传真: <%=faxNumber %></td>
      </tr>
      <tr>
        <td height="20" align="center" valign="middle" style="font-family:Arial; font-size:12px; color: #666;"><%=copyright %></td>
      </tr>
      <tr>
        <td height="20" align="center" valign="middle" style="font-family:宋体; font-size:12px; color: #999;">萧山EMS 版权所有 <a href="http://www.miitbeian.gov.cn" target="_blank"><%=record %></a></td>
      </tr>
    </table></td>
  </tr>