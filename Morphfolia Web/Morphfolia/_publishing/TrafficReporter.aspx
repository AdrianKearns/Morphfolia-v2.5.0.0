<%@ Page AutoEventWireup="true" CodeFile="TrafficReporter.aspx.cs" Inherits="_publishing_TrafficReporter"
    Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" Title="Traffic Reporter" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>
<%@ Register Assembly="Morphfolia.PublishingSystem" Namespace="Morphfolia.PublishingSystem.WebControls" TagPrefix="cc2" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">  
    




    
        <asp:Table ID="Table1" runat="server" CellPadding="5" CellSpacing="0">
        <asp:TableRow ID="TableRow1" runat="server">
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
            <asp:TableCell ID="TableCell3" runat="server" CssClass="CntrlGroupBorderLeft">&nbsp;</asp:TableCell>
        
            <asp:TableCell ID="TableCell4" runat="server"><asp:Calendar ID="Calendar1" OnSelectionChanged="Calendar1_OnSelectionChanged" runat="server"></asp:Calendar></asp:TableCell>
            <asp:TableCell ID="TableCell5" runat="server" VerticalAlign="Bottom">
                <asp:Button ID="btnViewThisDate" runat="server" onclick="btnViewThisDate_Click" Text="< This Date" />
                <br />
                <br />
                <asp:Button ID="btnViewThisDateRange" runat="server" onclick="btnViewThisDateRange_Click" Text="< Date Range >" />
            </asp:TableCell>
            <asp:TableCell ID="TableCell6" runat="server"><asp:Calendar ID="Calendar2" OnSelectionChanged="Calendar2_OnSelectionChanged" runat="server"></asp:Calendar></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    
<p><b>Query this URL</b> <cc2:UrlTextBox ID="txtUrl" runat="server" Width="460px" Height="16px"></cc2:UrlTextBox><br />
<span class="inlineHelpText">Click 'View', 'This Date' or 'Date Range' to get the relevant traffic report.&nbsp; Start typing a page URL (root relative - without the leading http//etc...) to show the URL prompter.</span></p>

    
    <asp:Panel ID="pnlTrafficInAndOut" runat="server" CssClass="FunctionalArea">
    
    <p style="text-align: center;"><b><asp:Label ID="lblTargetTimeRange" runat="server" Text=""></asp:Label></b></p>

    <table align="center" cellpadding="5" cellspacing="0" border="0">
     
     <tr><td colspan="2">
        
        <asp:PlaceHolder ID="phdrMisc" runat="server"></asp:PlaceHolder>        
        
         
     </td></tr>
     
    <tr>
    <td width="50%" valign="top"><cc2:HttpTrafficFlow ID="htfToResults" runat="server"></cc2:HttpTrafficFlow></td>
    <td class="CntrlGroupBorderLeft">&nbsp;</td>
    <td width="50%" valign="top">
    
        <asp:Panel ID="pnlAlternativeUrl" runat="server" Visible="False">
        <p>Includinging this alternative referrer URL:<br />
        <asp:TextBox ID="txtAlternativeUrl" 
            runat="server" Width="400px" ReadOnly="True"></asp:TextBox></p>
    </asp:Panel>
    
    <cc2:HttpTrafficFlow ID="htfFromResults" runat="server"></cc2:HttpTrafficFlow></td>
    </tr>
    
    </table>
    </asp:Panel> 
    
</asp:Content>        