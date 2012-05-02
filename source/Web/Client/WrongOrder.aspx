<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WrongOrder.aspx.cs" Inherits="Client_WrongOrder" %>

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
                <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="问题订单详情"></wl:ClientTop></td></tr>                 
                <tr>
                  <td><table class="grid">
                          <tr>
                            <td width="10%" class="label" >问题单号:</td>
                            <td width="40%" class="content"><asp:Label ID="lblEncode" runat="server" Text=""></asp:Label></td>
                            <td width="10%" class="label" >收件单号:</td>
                            <td width="40%" class="content"><asp:TextBox ID="txtOrderEncode" runat="server"></asp:TextBox></td>                           
                          </tr>
                          <tr>
                            <td class="label" >制单时间:</td>
                            <td class="content"><asp:Label ID="lblCreateTime" runat="server" Text=""></asp:Label></td>    
                            <td class="label" >问题类别:</td>
                            <td class="content"><select id="slWrongType" runat="server">
                                              <option value="未收到">未收到 </option>                             
                                              <option value="损坏">损坏 </option>
                                              <option value="差错">差错</option>
                                              <option value="海关因素">海关因素 </option>                              
                                          </select></td>      
                          </tr>         
                          <tr>
                            <td class="label" >问题内容:</td>
                            <td class="content" colspan="3"><asp:TextBox ID="txtReason" TextMode="multiLine" Rows="2" Width="100%" runat="server"></asp:TextBox></td>          
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
                              </tr>
                              <% i++;
                             }
                         }%>   
                         </table>
                    </td>
                </tr>               
              </table>              
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