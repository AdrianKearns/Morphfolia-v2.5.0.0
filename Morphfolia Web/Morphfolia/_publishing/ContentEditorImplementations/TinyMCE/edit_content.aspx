<%@ Page CodeFile="edit_content.aspx.cs"
    Inherits="Morphfolia.Web._publishing.edit_content" Language="c#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master"
    ValidateRequest="false" Title="Add / Edit Content" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="EditContent" Src="~/Morphfolia/_publishing/ContentEditorImplementations/TinyMCE/EditContent.ascx" %>



<asp:Content ContentPlaceHolderID=PageHeadPlaceholder runat=server>

    <script language=javascript src='../JavaScript/EditContent.js'></script>

</asp:Content>



<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">

            
            <uc1:editcontent id=EditContent1 runat="server"></uc1:EditContent>
            
       
</asp:Content>