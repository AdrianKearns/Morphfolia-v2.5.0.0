<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AppSettingKeys.aspx.cs" Inherits="Morphfolia__publishing_Diagnostics_AppSettingKeys" Title="Untitled Page" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">
   <asp:Button ID="btnShowMorphOnly" runat="server" 
        onclick="btnShowMorphOnly_Click" Text="Morphfolia AppSetting Keys" 
        ToolTip="Scans Morphological and Morphfolia system assembilies only." />
    <asp:Button ID="btnShowAll" runat="server" onclick="btnShowAll_Click" 
        Text="All AppSetting Keys" 
        
        ToolTip="Scans all assembilies, looking for correctly decorated members." />
    <asp:Label ID="lblTemp" runat="server" EnableViewState="False"></asp:Label>
    <asp:Panel ID="pnlExtractedData" runat="server">
    </asp:Panel>
</asp:Content>

