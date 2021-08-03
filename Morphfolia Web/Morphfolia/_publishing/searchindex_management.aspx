<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Page CodeFile="searchIndex_management.aspx.cs" Title="Search Index Management"
    Inherits="Morphfolia.Web._publishing.searchIndex_management" Language="c#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" %>


<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">

    <iframe src="ResetSearchIndex.aspx?IndexAction=indexsite" width="100%" height="550" frameborder=0 style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"></iframe>   
                
</asp:Content>