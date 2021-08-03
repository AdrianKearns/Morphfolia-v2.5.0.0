<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
        
</head>
<body onload="if (top.frames.length!=0) top.location=self.document.location;">

<asp:PlaceHolder ID="PageHeader" runat="server" EnableViewState="False"></asp:PlaceHolder>
    
    
    <form id="form1" runat="server">
        
    <asp:Table ID="tblPageLayout" runat="server" HorizontalAlign=Center CellPadding="5"
        CellSpacing="0" EnableViewState="False" Width=70%>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" VerticalAlign=top Width="300px">
            
            
        <asp:Login ID="LoginControl" runat="server"></asp:Login>
       
            
            </asp:TableCell>
            <asp:TableCell ID="tdAdditionalContent" runat="server" VerticalAlign=top>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
       
    </form>
       
    
    <asp:PlaceHolder ID="PageFooter" runat="server" EnableViewState="False"></asp:PlaceHolder>

</body>
</html>
