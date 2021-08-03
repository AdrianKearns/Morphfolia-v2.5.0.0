<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Page CodeFile="edit_page.aspx.cs" Title="Add / Edit Page" Inherits="Morphfolia.Web._publishing.edit_page" Language="c#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" %>
<%@ Register assembly="Morphfolia.PublishingSystem" namespace="Morphfolia.PublishingSystem.WebControls" tagprefix="cc1" %>



<asp:Content ID="Content2" ContentPlaceHolderID=PageHeadPlaceholder runat=server>

    <script language=javascript src='../JavaScript/UrlTypeAheadHelper.js'></script>
    <script language=javascript src='../JavaScript/PreviewContentItem.js'></script>
    <script language=javascript src='../JavaScript/AssignContentToPage.js'></script>

    <style type='text/css'>
	    .bordvis { BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid }
	    TABLE.ActiveContentNode { BORDER-TOP: #000000 1px solid; MARGIN: 5px; BORDER-LEFT: #000000 1px solid; BACKGROUND-COLOR: #ddffc1; }
	    TABLE.ActiveContentNode TD { BORDER-RIGHT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid }
	    TR.ActiveContentNodeToolbar { BACKGROUND-COLOR: #cdecb4 }
    </style>



</asp:Content>


<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">
    <cc1:EditPage ID="EditPage1" runat="server" />
</asp:Content>            