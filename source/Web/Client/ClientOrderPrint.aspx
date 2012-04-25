<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientOrderPrint.aspx.cs" Inherits="Client_ClientOrderPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
div{	
	font-family:Arial;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0">
        <asp:Repeater ID="rpPrint" runat="server">
            <ItemTemplate>

            <tr>
            <td align="left" valign="top">
                <div style="position:relative;height:8.4cm;width:9.4cm;border:2px solid black;left:0.1cm;overflow:hidden;">
	            <div style="position:absolute;height:1.8cm;width:8.1cm;border:none;border-bottom:2px solid black;top:0cm;left:0cm;overflow:hidden;">
	            <div style="font-size:7px">
            <table style="border-collapse:collapse;width:7.8cm;height:1.4cm;border:0px;margin:auto;margin-top:3px;font-weight:bold" align="center"  >
				            <tr >
				            <td style="border:2px solid #000; border-collapse:collapse;width:5.5cm"   align="center" rowspan="2">
                           <span style="font-size:10px;margin-top:5px;height:1.2cm ">
                           If UNDELIVERED PLEASE<br />
                           RETURN TO P.O. BOX<br />
                           No. 68600 Kowloon East<br />
                           Post Office
                            </span>
                            </td>
				            <td width="5px" style="border:0px;font-weight:bold"></td>
                            <td style="text-align:center; font-size:10px;line-height:10px;border:2px solid #000; border-collapse:collapse;height:0.6cm;font-weight:bold; width:2.8cm;">POSTAGE PAID HONG KONG PORT PAYE</td>
				            <td style="width:1.2cm; font-size:10px; line-height:10px;border:2px solid #000;font-weight:bold" align="center">PERMIT<br 

/>No.<br />5435</td>
				             </tr>
				             <tr>
				             <td></td>
				             <td style="font-size:10px;height:0.5cm">AIR MAIL</td>
				             </tr>
			            </table>	 
            </div>	</div>
	            <div style="position:absolute;height:1.5cm;width:8.2cm;border:none;border-top:2px solid black;border-bottom:2px solid black;top:1.8cm;left:0cm;">
		            <div style="line-height:14px;font-size:14px; padding-top:3px; padding-left:5px; font-weight:bold;">From:</div>
		            <div style="line-height:12px;font-size:12px; padding-top:3px; padding-left:5px;"><%# Eval("PostAddress") %></div>
	            </div>
	            <div style="position:absolute;height:3.6cm;width:8.1cm;border:none;top:3.3cm;left:0cm;font-weight:bold;font-size:14px;overflow:hidden; padding-top:5px; padding-left:5px;">
		            To: <%# Eval("RealName") %><br/>
		            <%# Eval("Address") %>,<br/>  <%# Eval("Postcode")%><%# Convert.ToString(Eval("Postcode")).Length > 1 ? ",<br/>" : ""%>
		            <%# Eval("City") %><%# Convert.ToString(Eval("City")).Length > 1 ? ", " : ""%> <%# Eval("Country") %><br /><br />
                    <%# Convert.ToString(Eval("Phone")).Length > 1 ? "Tel: " : ""%><%# Eval("Phone") %>	
                    
                    </div>
                 <div style="position:absolute;height:1.5cm;width:8.2cm;border:none;border-top:2px solid black;top:6.9cm;left:0cm;">
			            <div style="position:absolute;height:1.3cm;width:8cm;left:0.1cm;text-align:center;">
			            <img src="http://sys.gamesalor.com.cn/BarCode.ashx?BarcodeType=CODE128A&Data=<%# Eval("Encode") %>&CopyrightText=&BarWidth=1&Height=50" alt="<%# Eval("Encode") %>"/>
			
		            </div>
	              </div>	            
	
	            <div style="position:absolute;height:8.4cm;width:1.3cm;border:none;border-left:2px solid black;top:0cm;left:8.2cm;font-size:13px;overflow:hidden;border-bottom:2px solid black">
		            </div>
            </div>
            </td>                                             
            </tr>     
	    <tr><td style="height:0.2cm"></td></tr>  
        </ItemTemplate>     
        </asp:Repeater>  
                         
    </table>
    </div>
    </form>
</body>
</html>
