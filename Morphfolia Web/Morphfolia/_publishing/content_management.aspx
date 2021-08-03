<%@ Page language="c#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" Inherits="Morphfolia.Web._publishing.content_management" CodeFile="content_management.aspx.cs" Title="Content Management" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">

<asp:PlaceHolder ID="ContentListContainer" runat="server"></asp:PlaceHolder>

</asp:Content>
