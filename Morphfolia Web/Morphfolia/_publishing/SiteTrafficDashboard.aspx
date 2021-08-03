<%@ Page AutoEventWireup="true" CodeFile="SiteTrafficDashboard.aspx.cs" Inherits="_publishing_SiteTrafficDashboard"
    Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" Title="Traffic Dashboard" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">  
    
    <h3>Right Now</h3>
    <asp:Panel ID="pnlRightNow" runat="server"></asp:Panel>

    <h3>Weekly Trend</h3>
    <asp:Panel ID="pnlWeeklyTrend" runat="server"></asp:Panel>

    <h3>Greatest Hits</h3>
    <asp:Panel ID="pnlAllTimeGreatestHits" runat="server"></asp:Panel>


    
    
</asp:Content>        