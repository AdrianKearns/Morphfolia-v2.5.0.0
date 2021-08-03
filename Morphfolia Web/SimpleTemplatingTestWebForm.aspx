<%@ Page Language="C#" MasterPageFile="~/SimpleTemplatingTestMasterPage.master" AutoEventWireup="true" CodeFile="SimpleTemplatingTestWebForm.aspx.cs" Inherits="SimpleTemplatingTestWebForm" Title="Untitled Page" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


    
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%    
    Morphfolia.PublishingSystem.WebFormHelper webFormHelper = new Morphfolia.PublishingSystem.WebFormHelper();
    lblProperties.Text = webFormHelper.Page.Description;
%>        
    <p><asp:Label ID="lblProperties" runat="server"></asp:Label></p>
        
    <p style="border: dashed 2px red">CustomProperties Count: <%= webFormHelper.CustomProperties.Count.ToString() %></p>
    
</asp:Content>

