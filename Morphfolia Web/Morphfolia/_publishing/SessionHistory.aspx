<%@ Page AutoEventWireup="true" CodeFile="SessionHistory.aspx.cs" Inherits="SessionHistory"
    Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" Title="Session History" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>


<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">

    <asp:Table ID="Table1" runat="server" CellPadding="5" CellSpacing="0">
        <asp:TableRow runat="server">
            <asp:TableCell ID="TableCell1" runat="server" VerticalAlign="Bottom">
                View sessions active<br />
                within the last:<br />

                <asp:DropDownList ID="ddlHours" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="1">Hour</asp:ListItem>
                    <asp:ListItem Value="8">8 Hours</asp:ListItem>
                    <asp:ListItem Value="12">12 Hours</asp:ListItem>
                    <asp:ListItem Value="24" Selected="True">24 Hours</asp:ListItem>
                    <asp:ListItem Value="48">48 Hours</asp:ListItem>
                    <asp:ListItem Value="168">Week</asp:ListItem>
                    <asp:ListItem Value="672">4 Weeks</asp:ListItem>
                </asp:DropDownList> 
        
                <asp:Button ID="btnViewPredefinedTimeRange" runat="server" Text="View" onclick="btnViewPredefinedTimeRange_Click" />
                
        </asp:TableCell>
        
            <asp:TableCell ID="TableCell2" runat="server">&nbsp;</asp:TableCell>
            <asp:TableCell runat="server" CssClass="CntrlGroupBorderLeft">&nbsp;</asp:TableCell>
        
            <asp:TableCell runat="server"><asp:Calendar ID="Calendar1" OnSelectionChanged="Calendar1_OnSelectionChanged" runat="server"></asp:Calendar></asp:TableCell>
            <asp:TableCell runat="server" VerticalAlign="Bottom">
                <asp:Button ID="btnViewThisDate" runat="server" onclick="btnViewThisDate_Click" Text="< This Date" />
                <br />
                <br />
                <asp:Button ID="btnViewThisDateRange" runat="server" onclick="btnViewThisDateRange_Click" Text="< Date Range >" />
            </asp:TableCell>
            <asp:TableCell runat="server"><asp:Calendar ID="Calendar2" OnSelectionChanged="Calendar2_OnSelectionChanged" runat="server"></asp:Calendar></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        
    
 
        
    
    
    <p><b><asp:Label ID="lblTargetTimeRange" runat="server" Text=""></asp:Label></b></p>



    <asp:PlaceHolder ID="plchdrSessionList" runat="server"></asp:PlaceHolder>


    <br />

<!--
    <div class='FunctionalArea' style="overflow-y: scroll; height: 200px; padding: 0px; width: 700px;">
    </div>
    -->

    <asp:PlaceHolder ID="plchdrSessionHistory" runat="server"></asp:PlaceHolder>
    
</asp:Content>    