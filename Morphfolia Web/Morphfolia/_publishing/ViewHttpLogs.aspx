<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewHttpLogs.aspx.cs" Inherits="Morphfolia__publishing_ViewHttpLogs" Title="Search Http Logs" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<asp:Content ID="Content1" ContentPlaceHolderID="PageHeadPlaceholder" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">
    <table cellpadding=3 cellspacing=0 class="FunctionalArea">
    <tr><th colspan=2>Search Http Logs</th></tr>
        <tr>
            <td>Request Url</td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Columns="55" MaxLength="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Referer Url</td>
            <td>
                <asp:TextBox ID="txtRefererUrl" runat="server" Columns="55" MaxLength="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Misc Info</td>
            <td>
                <asp:TextBox ID="txtMiscInfo" runat="server" Columns="55" MaxLength="500"></asp:TextBox>
            </td>
        </tr>
                <tr>
            <td>Session Id</td>
            <td>
                <asp:TextBox ID="txtSessionId" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>User Host Address</td>
            <td>
                <asp:TextBox ID="txtUserHostAddress" runat="server" Columns="20" MaxLength="50"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>From</td>
            <td>
                <asp:TextBox ID="txtDateFrom" runat="server" Columns="30" MaxLength="30"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>Till</td>
            <td>
                <asp:TextBox ID="txtDateTill" runat="server" Columns="30" MaxLength="30"></asp:TextBox>
                    </td>
        </tr>
        <tr><td>&nbsp;</td><td>
            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                onclick="btnSearch_Click" />
            </td></tr>
        <tr><td>&nbsp;</td><td>
            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
            </td></tr>
    </table>
    
    
    <br />
    
    <asp:Panel ID="pnlResults" runat="server">
    </asp:Panel>
    
</asp:Content>

