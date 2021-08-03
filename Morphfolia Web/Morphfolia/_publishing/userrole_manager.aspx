<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="userrole_manager.aspx.cs" Inherits="_publishing_userrole_manager" Title="User Role Manager" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">
   
            <table border='0' cellpadding='0' cellspacing='5'>
            <tr>
                <td class='adminWorkArea' valign="top">
                
                <div class='FunctionalArea_Light' style="overflow-y: scroll; height: 300px; width: 100%;">
                <asp:PlaceHolder ID="plhdrRoleList" runat="server"></asp:PlaceHolder>
                </div>
                
                </td>
                <td class='adminWorkArea' valign="top">
                                               
                    <div class='FunctionalArea_Light' style="overflow-y: scroll; height: 300px; width: 100%;">                
                    <asp:PlaceHolder ID="plhdrManageMembership" runat="server"></asp:PlaceHolder>
                    </div>
    
        </td></tr></table>
        
</asp:Content>

