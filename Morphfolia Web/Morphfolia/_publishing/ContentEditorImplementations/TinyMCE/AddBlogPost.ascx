<%@ Control Language="c#" Inherits="Morphfolia.Web.UserControls.EditContent" CodeFile="AddBlogPost.ascx.cs" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Register TagPrefix="cc2" Namespace="Morphfolia.WebControls" Assembly="Morphfolia.WebControls" %>




<table cellSpacing=5 cellPadding=3 border=0 width="90%">
  <tr>
    <td vAlign=top>ID</td>
    <td vAlign=top><asp:literal id=litContentID 
       runat="server"></asp:literal></td></tr>
  <tr>
    <td vAlign=top>Title</td>
    <td vAlign=top><asp:textbox id=txtNote runat="server" Width="462px" Columns="60" 
            Rows="1" MaxLength="500"></asp:textbox></td></tr>    
  <tr>
    <td vAlign=top>Blog to post to</td>
    <td vAlign=top>
        <asp:DropDownList ID="ddlBlog" runat="server" AutoPostBack="True" EnableViewState="true" 
            onselectedindexchanged="ddlBlog_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="lblBlogListMsg" runat="server" Text="Label"></asp:Label>
    </td></tr>
    
      <tr>
    <td vAlign=top>Tags</td>
    <td vAlign=top>
        <asp:CheckBoxList ID="lstTagsTaxonomyInput" runat="server">
        </asp:CheckBoxList>
        <asp:TextBox ID="txtTagsFolksonomyInput" runat="server" Rows="5" 
            TextMode="MultiLine" Width="300px" Wrap="False"></asp:TextBox>
            </td></tr>
    
  <tr>
    <td vAlign=top>&nbsp;</td>
    <td vAlign=top>
    <asp:Button id=btnSave1 runat="server" Text="Save" onclick="btnSave_Click" 
            ToolTip="Saves the currently displayed content and allows you to keep working on it."></asp:Button> 
    <asp:Button id=btnSaveNExit1 runat="server" Text="Save And Exit" 
            EnableViewState="False" onclick="btnSaveNExit_Click" 
            ToolTip="Saves the currently displayed page details, and returns you to the main admin screen."></asp:Button>
        &nbsp; &nbsp; &nbsp; &nbsp; 
        &nbsp;</td></tr>



  <tr>
    <td vAlign=top style="HEIGHT: 134px">Content</td>
    <td vAlign=top style="HEIGHT: 134px">
        <cc2:HTMLEditor ID="HTMLEditor1" runat="server" EnableTheming="False" />
        &nbsp;&nbsp;
        <asp:Panel ID="pnlFormTemplateContainer" runat="server" Width="100%">
        </asp:Panel>
    </td></tr>
  <tr>
    <td vAlign=top></td>
    <td vAlign=top>
    <asp:CheckBox id=chkbxIsSearchable runat="server" Text="Is Searchable"></asp:CheckBox> &nbsp; 
    <asp:CheckBox id=chkbxIsLive runat="server" Text="Is Live"></asp:CheckBox><br />
        &nbsp; &nbsp; Be aware that once post are marked as live they will be cached by some RSS 
        readers.</td></tr>

  <tr>
    <td vAlign=top></td>
    <td vAlign=top>
    <asp:Button id=btnSave2 runat="server" Text="Save" onclick="btnSave_Click" 
            ToolTip="Saves the currently displayed content and allows you to keep working on it."></asp:Button> 
    <asp:Button id=btnSaveNExit2 runat="server" Text="Save And Exit" 
            EnableViewState="False" onclick="btnSaveNExit_Click" 
            ToolTip="Saves the currently displayed page details, and returns you to the main admin screen."></asp:Button>
        &nbsp; &nbsp; &nbsp; &nbsp; 
        &nbsp;<!--
    <asp:CheckBox id=chkbxCreateOwnPage runat="server" Text="Create a new page specifically for this content?" ToolTip=""></asp:CheckBox> --></td></tr>
    
    </table>

