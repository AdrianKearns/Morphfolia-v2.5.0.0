<%@ Page AutoEventWireup="true" CodeFile="PageTrafficDashboard.aspx.cs" Inherits="_publishing_PageTrafficDashboard"
    Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" Title="Traffic Dashboard" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">  
    
    
    <p>Select a URL from the drop-down or enter a URL into the text field below.<br />
    <asp:DropDownList ID="ddlUrls" runat="server" Height="16px" Width="735px">
        </asp:DropDownList><br />
        <asp:TextBox ID="txtUrl" runat="server" Width="620px"></asp:TextBox> &nbsp; 
        <asp:Button ID="btnShowDataForSelectedUrl" runat="server" Text="Show Traffic" 
            onclick="btnShowDataForSelectedUrl_Click" />
        
        </p>
    
    <h3><asp:Literal ID="litHeading" runat="server"></asp:Literal></h3>


    <h3>Daily Trend</h3>
    <table cellpadding="0" cellspacing="0">
    <tr>
    <td valign="top"><asp:Panel ID="pnlWeeklyTrendChart" runat="server"></asp:Panel></td>
    <td>&nbsp;</td>
    <td valign="top"><asp:Panel ID="pnlWeeklyTrendLegend" runat="server"></asp:Panel></td></tr></table>
    <asp:Panel ID="pnlWeeklyTrendData" runat="server">
    </asp:Panel>

    <h3>Weekly Hits</h3>
    <table cellpadding="0" cellspacing="0">
    <tr>
    <td valign="top"><asp:Panel ID="pnlAllTimeGreatestHitsChart" runat="server"></asp:Panel></td>
    <td>&nbsp;</td>
    <td valign="top"><asp:Panel ID="pnlAllTimeGreatestHitsLegend" runat="server"></asp:Panel></td></tr></table>
    <asp:Panel ID="pnlAllTimeGreatestHitsData" runat="server">
    </asp:Panel>


    
    
</asp:Content>        