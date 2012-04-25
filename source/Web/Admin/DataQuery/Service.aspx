<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Service.aspx.cs" Inherits="Admin_DataQuery_Service" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link href="../Css/Style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/Js/SelectCity.js"></script>
</head>
<body>
<form id="form1" runat="server">   
  <wl:DataQueryNav ID="dataQueryNav" runat="server" />
  <table cellpadding="0" cellspacing="0" class="nav">
    <tr>
        <td class="info2">数据查询 > 服务查询 > 服务详情</td>
    </tr>
    <tr>
        <td class="info"></td>
    </tr>
    <tr>
        <td class="seperator"></td>
    </tr>
  </table>
  <table class="tablecontent">
    <tr><td align="center">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>    
    <tr>
        <td class="info"><input type="button" class="button" value="返 回" onclick="javascript:location.href='ServiceList.aspx';" /></td>
    </tr>
    <tr>
      <td><table class="grid">
          <tr>
            <td width="10%" class="label" >服务单号:</td>
            <td width="23%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
            <td width="10%" class="label" >收件单号:</td>
            <td width="24%" class="content"><asp:TextBox ID="txtOrderEncode" runat="server"></asp:TextBox></td>
            <td width="10%" class="label" >收件日期:</td>
            <td width="23%" class="content"><asp:Label ID="lblReceiveDate" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
            <td class="label" >服务类别:</td>
            <td class="content"><select id="slWrongType" runat="server">
                              <option value="未收到">未收到 </option>                             
                              <option value="损坏">损坏 </option>
                              <option value="差错">差错</option>
                              <option value="海关因素">海关因素 </option>                              
                          </select></td>
            <td class="label" >制 单 人:</td>
            <td class="content"><asp:Label ID="lblCreateUser" runat="server" Text=""></asp:Label></td>           
            <td class="label" >制单时间:</td>
            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>        
          </tr>         
          <tr>
            <td class="label" >服务内容:</td>
            <td class="content" colspan="5"><asp:TextBox ID="txtReason" TextMode="multiLine" Rows="2" Width="100%" runat="server"></asp:TextBox></td>          
          </tr>        
         </table>		
        </td>
    </tr>    
    <tr>
      <td>
      	 <table class="grid">
          <tr>
            <td align="center" class="headers">序号</td>
            <td align="left" class="headers">处理方式及过程</td>
            <td align="left" class="headers">处理结果</td>           
            <td align="left" class="headers">处理人</td>
            <td align="left" class="headers">处理时间</td>    
            <td align="center" class="headers">操作</td>
          </tr>
          <%
              if (result != null)
              {
                  int i = 1;
                  foreach (Backend.Models.WrongOrderDetail wod in result)
                  {
                      
               %>
              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                <td align="center"><%=i%></td>
                <td align="left"><%=wod.Detail%></td>
                <td align="left"><%=wod.Result%></td>
                <td align="left"><%= Backend.BAL.UserOperation.GetUserById(wod.CreateUserId).RealName%></td>
                <td align="left"><%=wod.CreateTime%></td>
                <td align="center"><a href="WrongOrderDetail.aspx?id=<%=wod.Id %>">查看</a></td>
              </tr>
              <% i++;
             }
         }%>   
         </table>	         
	  </td>
    </tr>
  </table>
</form>
</body>
</html>
