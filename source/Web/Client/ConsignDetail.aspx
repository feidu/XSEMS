<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsignDetail.aspx.cs" Inherits="Client_ConsignDetail" %>

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
              <table class="tablecontent">
                 <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="编辑发货明细"></wl:ClientTop></td></tr> 
                 <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                 <tr>
                  <td><table class="grid">     
                            <tr>
                              <td class="label"> 物品名称: </td>
                              <td class="content"><asp:TextBox ID="txtGoodsTitle" runat="Server" Width="280"></asp:TextBox>
                              </td>
                              <td class="label" > 重&nbsp;&nbsp;&nbsp;&nbsp;量: </td>
                              <td class="content" ><asp:TextBox ID="txtWeight" runat="Server" Width="80"></asp:TextBox> 千克
                              </td>
                            </tr>  
                     
                            <tr>
                              <td class="label" width="13%"> 数&nbsp;&nbsp;&nbsp;&nbsp;量: </td>
                              <td class="content" width="47%"><asp:TextBox ID="txtCount" runat="Server" Width="80"></asp:TextBox>
                              </td>
                              <td class="label" width="13%"> 申报价值: </td>
                              <td class="content" width="27%"><asp:TextBox ID="txtWorth" runat="Server" Width="80"></asp:TextBox> 元
                              </td>
                            </tr>                                    
                            <tr>
                                <td class="label" >中文申报名称:</td>
                                <td class="content" colspan="3"><asp:TextBox ID="txtDeclareCnName"  runat="server" Width="100%"></asp:TextBox></td>
                            </tr>                                
                            <tr style="display:none;">
                              <td class="label"> 英文申报名称: </td>
                              <td class="content" colspan="3"><asp:TextBox ID="txtDeclareEnName"  runat="server" Width="100%"></asp:TextBox>                                               
                              </td>
                            </tr> 
                            <tr>
                                <td class="label" >HS 编 码:</td>
                                <td class="content" colspan="3"><asp:TextBox ID="txtHsEncode"  runat="server" Width="100%"></asp:TextBox></td>
                            </tr>                          
                            <tr><td colspan="4" align="center"><asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="修 改" OnClick="btnUpdate_Click"/>&nbsp;&nbsp;&nbsp;<input type="button" class="button" value="返 回" onclick="javascript:location.href='Consign.aspx?id=<%=order.Id %>'"/></td></tr>
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
