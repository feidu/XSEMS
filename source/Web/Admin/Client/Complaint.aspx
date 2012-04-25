<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Complaint.aspx.cs" Inherits="Admin_Client_Complaint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
  <wl:ClientNav ID="clientNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">客户服务 > 客户投诉 > 投诉详情</td>
    </tr>    
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr>
      <td><table class="grid">
          <tr>
            <td colspan="2" align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td>
          </tr>
          <tr>
            <td width="10%" class="label" >客户姓名:</td>
            <td width="90%" class="content"><asp:Label ID="lblClientName" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >标&nbsp;&nbsp;&nbsp;&nbsp;题:</td>
            <td class="content"><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >提交时间:</td>
            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >投诉内容:</td>
            <td class="content"><asp:Label ID="lblContent" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td colspan="2" height="20"></td>
          </tr>
          <div id="divReplyContent" runat="server" visible="false">
          <tr>
            <td class="label" colspan="2" align="left" style="font-weight:bold;"><asp:Label ID="lblReplyUser" runat="server" Text=""></asp:Label>&nbsp;&nbsp;<asp:Label runat="server" ID="lblReplyTime"></asp:Label>&nbsp;回复</td>
          </tr>
          <tr>
            <td class="label" >回复内容:</td>
            <td class="content"><asp:Label ID="lblReplyContent" runat="server" Text=""></asp:Label></td>
          </tr>
          </div>
          <div id="divReply" runat="server">
          <tr>
            <td height="35px"  class="label"> 回复内容: </td>
            <td  class="content"><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="850" Height="50"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td colspan="2" align="center" height="35px"><asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="提 交" OnClick="btnSubmit_Click"/>&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='ComplaintList.aspx';" />
            </td>
          </tr>
          </div>
        </table></td>
    </tr>
  </table>
</form>
</body>
</html>
