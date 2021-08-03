<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="error" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ooops, Error</title>
</head>
<body>

    <asp:PlaceHolder ID="PageHeader" runat="server"></asp:PlaceHolder>

    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblErrorHeading" runat="server" CssClass='PageTitle'></asp:Label>
        <asp:Label ID="lblErrorMessage" runat="server" CssClass=''></asp:Label>
    
    </div>
    </form>
    
    <asp:PlaceHolder ID="PageFooter" runat="server"></asp:PlaceHolder>
    
</body>
</html>
