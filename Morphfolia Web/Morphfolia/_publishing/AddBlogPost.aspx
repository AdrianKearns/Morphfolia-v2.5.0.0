<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddBlogPost.aspx.cs" Inherits="Morphfolia__publishing_AddBlogPost" Title="Add Blog Post" ValidateRequest="false" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register src="~/Morphfolia/_publishing/ContentEditorImplementations/ABKEditor/AddBlogPost.ascx" tagname="AddBlogPost" tagprefix="uc1" %>


<asp:Content ContentPlaceHolderID="PageHeadPlaceholder" runat="server">

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">
    <uc1:AddBlogPost ID="AddBlogPost1" runat="server" />
</asp:Content>