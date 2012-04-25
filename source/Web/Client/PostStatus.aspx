<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostStatus.aspx.cs" Inherits="Client_PostStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="tablecontent" width="350">                                                   
                <tr>
                  <td><table class="grid">
                          <tr>
                            <th align="left" class="header_client">包裹单号</th>
                            <th align="left" class="header_client">状态</th> 
                            <th align="left" class="header_client">所在地</th>           
                            <th align="left" class="header_client">发往国家</th>
                            <th align="left" class="header_client">最后处理时间</th>
                          </tr>
                          <asp:Repeater ID="rpPostStatus" runat="server">
                            <ItemTemplate>
                              <tr class="label" onmouseover="this.className = 'hover';" onmouseout="this.className = 'label';">
                                <td align="left"><%# Eval("BarCode")%></td>
                                <td align="left"><%# Eval("Status")%></td>    
                                <td align="left"><%# Eval("Location")%></td>  
                                <td align="left"><%# Eval("ToCountry")%></td>      
                                <td align="left"><%#  Convert.ToDateTime(Eval("DisposalTime")).ToShortDateString()%></td>                                                         
                              </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                              <tr class="content" onmouseover="this.className = 'hover';" onmouseout="this.className = 'content';">
                               <td align="left"><%# Eval("BarCode")%></td>
                                <td align="left"><%# Eval("Status")%></td>    
                                <td align="left"><%# Eval("Location")%></td>  
                                <td align="left"><%# Eval("ToCountry")%></td>      
                                <td align="left"><%#  Convert.ToDateTime(Eval("DisposalTime")).ToShortDateString()%></td>                 
                              </tr>
                            </AlternatingItemTemplate>
                          </asp:Repeater>                                                
                        </table>		
		            </td>
                </tr>                
              </table>
    </div>
    </form>
</body>
</html>
