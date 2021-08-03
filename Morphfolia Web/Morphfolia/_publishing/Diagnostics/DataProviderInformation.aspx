<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DataProviderInformation.aspx.cs" Inherits="Morphfolia__publishing_Diagnostics_DataProviderInformation" Title="Data Info" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">

<h3>Data Info</h3>

<p>Provides information about the under-lying data provider, supplied by the data provider itself.</p>

<p><b>Usage Summary</b></p>
    <pre><asp:Literal ID="litUsageSummary" runat="server" EnableViewState="False"></asp:Literal></pre>
</asp:Content>

