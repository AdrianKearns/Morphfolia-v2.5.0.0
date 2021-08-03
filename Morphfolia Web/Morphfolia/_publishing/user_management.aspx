<%@ Page CodeFile="user_management.aspx.cs" Title="User Management"
    Inherits="Morphfolia.Web._publishing.User_Management" Language="c#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>


<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">


        <table border='0' cellpadding='0' cellspacing='0'>
            <tr>
                <td class='adminWorkArea' valign="top">
                
                <asp:Panel ID="pnlUserList" runat="server" CssClass="FunctionalArea_Light" 
                        EnableViewState="False">
                </asp:Panel>
                
                <br>
                           
                <asp:Panel ID="pnlManageUser" runat="server" CssClass="FunctionalArea_Light" 
                        EnableViewState="False" Width="100%">
                </asp:Panel>
                           

    
        </td></tr></table>


</asp:Content>