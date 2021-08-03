<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Page CodeFile="page_management.aspx.cs" Title="Page Management"
    Inherits="Morphfolia.Web._publishing.page_management" Language="c#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="PageList" Src="../UserControls/PageList.ascx" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">

                <uc1:PageList id=PageList1 runat="server"></uc1:PageList>
                <asp:Literal id=Literal1 runat="server"></asp:Literal>
</asp:Content>