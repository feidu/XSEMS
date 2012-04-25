<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComplaintList.aspx.cs" Inherits="Client_ComplaintList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<wl:Seo ID="seo" runat="server" Title=""/>
<link href="../Css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/Admin/JS/Calendar/WdatePicker.js"></script>
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
              
              <!--中间右边内容部分--> 
              <table class="tablecontent">
                <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="投诉列表"></wl:ClientTop></td></tr>  
                <tr><td align="left" valign="bottom" style="padding-left:5px;">回复状态：<asp:DropDownList ID="ddlReplyStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReplyStatus_SelectedIndexChanged"><asp:ListItem Text="全部" Value="0"></asp:ListItem><asp:ListItem Text="已回复" Value="True" Selected="true"></asp:ListItem><asp:ListItem Text="未回复" Value="False"></asp:ListItem></asp:DropDownList>&nbsp; &nbsp; &nbsp; 日期范围：<input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="startDate"/> 至 <input class="Wdate" type="text" onclick="WdatePicker()" runat="server" id="endDate"/> <input type="button" id="btnSerach" runat="server" value="查 询" class="button" onserverclick="btnSerach_ServerClick"/></td></tr>
                <tr>
                  <td><table class="grid">
                      <tr>
                        <th align="center" class="header_client">编号</th>
                        <th align="center" class="header_client">标题</th>
                        <th align="center" class="header_client">部分投诉内容</th>
                        <th align="center" class="header_client">提交时间</th>
                        <th align="center" class="header_client">查看</th>
                      </tr>
                      <asp:Repeater ID="rpComplaint" runat="server">
                        <ItemTemplate>
                          <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                            <td align="center"><%# Eval("Id") %></td>
                            <td align="left"><%# StringHelper.CnCutString(Eval("Title").ToString(), 66) %></td>
                            <td align="left"><%# StringHelper.CnCutString(Eval("Content").ToString(), 66)+"……" %></td>
                            <td align="center"><%# Eval("CreateTime")%></td>
                            <td align="center"><a href="ComplaintView.aspx?id=<%# Eval("Id") %>">查看</a></td>
                          </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                          <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                            <td align="center"><%# Eval("Id") %></td>
                            <td align="left"><%# StringHelper.CnCutString(Eval("Title").ToString(), 66) %></td>
                            <td align="left"><%# StringHelper.CnCutString(Eval("Content").ToString(), 66) + "……"%></td>
                            <td align="center"><%# Eval("CreateTime")%></td>
                            <td align="center"><a href="ComplaintView.aspx?id=<%# Eval("Id") %>">查看</a></td>
                          </tr>
                        </AlternatingItemTemplate>
                      </asp:Repeater>                      
                    </table>		
		            </td>
                </tr>
              </table>
              <wl:Pagination ID="pagi" runat="server"/>               
            </div>
          </div>
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
