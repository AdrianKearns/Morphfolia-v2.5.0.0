
<%@ Page AutoEventWireup="true" CodeFile="unwantedWords_management.aspx.cs" Inherits="_publishing_unwantedWords_management"
    Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" Title="Unwanted Word Management" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>

 
        
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">
   
        
        <table>
        <tr>
        <td valign=top style="width: 190px">Unwanted Word List</td>
        <td><asp:TextBox ID="txtUnwantedWords" runat="server" Height="260px" TextMode="MultiLine" Width="499px"></asp:TextBox></td>
        </tr>
        <tr>
        <td style="width: 190px">Remove Unwanted Words<br />From The Content Indexes</td>
        <td valign="top"><asp:Button ID="btnInitiateRemoval" runat="server" OnClick="btnSaveAndRemove_Click" Text="Save + Remove" /></td>
        </tr>
        </table>
        
</asp:Content>    