<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderUpload.aspx.cs" Inherits="Client_OrderUpload" %>

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
                 <tr><td align="left" class="top_content"><wl:ClientTop runat="server" id="clientTop" Title="订单批量上传"></wl:ClientTop></td></tr> 
                 <tr><td align="center"><asp:Label ID="lblMsg" runat="server" Text="" ForeColor="red"></asp:Label></td></tr>
                 <tr>
                  <td><table class="grid">     
                            <tr style="display:none;">
                              <td class="label" width="13%"> 发件人姓名: </td>
                              <td class="content" width="87%"><asp:DropDownList ID="ddlClientAddress" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<a href="CreateAddress.aspx">添加发件人地址信息</a>
                              </td>
                            </tr>  
                            <tr>
                              <td class="label"> 选择文件:</td>
                              <td class="content"><asp:FileUpload ID="fuDataFile" runat="server" />
                              </td>
                            </tr> 
                            <tr>
                              <td class="label"> 样例文件下载: </td>
                              <td class="content"><a href="../Config/paypal.csv" target="_blank">PayPal格式范本</a>&nbsp;&nbsp;<a href="../Config/ebay.csv" target="_blank">Ebay格式范本</a>
                              </td>
                            </tr>         
                            <tr><td colspan="2" align="center"><asp:Button ID="btnUpload" runat="server" 
                                    CssClass="button" Text="上 传" onclick="btnUpload_Click"/></td></tr>
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
