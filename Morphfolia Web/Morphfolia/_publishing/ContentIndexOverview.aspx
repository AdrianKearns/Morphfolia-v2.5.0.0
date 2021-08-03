<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ContentIndexOverview.aspx.cs" Inherits="Morphfolia__publishing_ContentIndexOverview" Title="Untitled Page" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register assembly="Morphfolia.WebControls" namespace="Morphfolia.WebControls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">
    <cc1:ContentIndexSummary ID="ContentIndexSummary1" runat="server" Letter="D" />
</asp:Content>

