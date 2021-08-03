<%@ Control Language="c#" Inherits="Morphfolia.Web.UserControls.EditContent" CodeFile="EditContent.ascx.cs" %>

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
    <td vAlign=top id='tdContentId'><asp:literal id=litContentID 
       runat="server"></asp:literal></td></tr>
  <tr>
    <td vAlign=top>Note</td>
    <td vAlign=top><asp:textbox id=txtNote runat="server" Width="462px" Columns="50" Rows="5" TextMode="MultiLine"></asp:textbox></td></tr>
    
    
  <tr>
    <td vAlign=top>&nbsp;</td>
    <td vAlign=top>
    <asp:Button id=btnSave1 runat="server" Text="Save" onclick="btnSave_Click" 
            ToolTip="Saves the currently displayed content and allows you to keep working on it."></asp:Button> 
    <asp:Button id=btnSaveNExit1 runat="server" Text="Save And Exit" 
            EnableViewState="False" onclick="btnSaveNExit_Click" 
            ToolTip="Saves the currently displayed page details, and returns you to the main admin screen."></asp:Button>
    <asp:Button ID="btnSaveAsNew1" runat="server" OnClick="btnSaveAsNew_Click" 
            Text="Save As New" 
            ToolTip="Save the currently displayed values as a new content item, leaving the previously saved content item as-is." /> 
            
        <input id="btnIndexContent" type="button" value="Index Content" onclick="indexContent();" runat=server />
            
            &nbsp; &nbsp; &nbsp; &nbsp; 
    <asp:Button ID="btnDelete1" runat="server" Text="Delete" OnClick="btnDelete_Click" 
            ToolTip="Click here to permanently delete this content item.  Make sure you confirm the delete." />
        &nbsp;<asp:CheckBox ID="chkbxConfirmDelete1" runat="server" 
            ToolTip="This box must be ticked, otherwise the delete will not occur." />
            
            
            
            <div id='indexProgressWindowContainer' style='display: none; padding: 0px; border: solid 1px #000000; width: 543px; height: 200px;'><iframe id='indexProgressWindow' style='width: 100%; height: 100%;' frameborder='0'></iframe></div>
            
            
        </td></tr>



  <tr>
    <td vAlign=top>Content</td>
    <td vAlign=top>(Mode) <asp:DropDownList ID="ddlContentEntryFilter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlContentEntryFilter_SelectedIndexChanged">
            <asp:ListItem Value="HtmlEditor">Normal</asp:ListItem>
        </asp:DropDownList></td></tr>
    
  <tr>
    <td vAlign=top style="HEIGHT: 134px">&nbsp;</td>
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
    <asp:CheckBox id=chkbxIsLive runat="server" Text="Is Live"></asp:CheckBox> &nbsp; 
    <asp:CheckBox id=chkbxIncludeInSiteMap runat="server" Text="Include In Site Map" Visible="False"></asp:CheckBox></td></tr>

  <tr>
    <td vAlign=top></td>
    <td vAlign=top>
    <asp:Button id=btnSave2 runat="server" Text="Save" onclick="btnSave_Click" 
            ToolTip="Saves the currently displayed content and allows you to keep working on it."></asp:Button> 
    <asp:Button id=btnSaveNExit2 runat="server" Text="Save And Exit" 
            EnableViewState="False" onclick="btnSaveNExit_Click" 
            ToolTip="Saves the currently displayed page details, and returns you to the main admin screen."></asp:Button>
    <asp:Button ID="btnSaveAsNew2" runat="server" OnClick="btnSaveAsNew_Click" 
            Text="Save As New" 
            ToolTip="Save the currently displayed values as a new content item, leaving the previously saved content item as-is." /> &nbsp; &nbsp; &nbsp; &nbsp; 
    <asp:Button ID="btnDelete2" runat="server" Text="Delete" OnClick="btnDelete_Click" 
            ToolTip="Click here to permanently delete this content item.  Make sure you confirm the delete." />
        &nbsp;<asp:CheckBox ID="chkbxConfirmDelete2" runat="server" 
            ToolTip="This box must be ticked, otherwise the delete will not occur." />
        <!--
    <asp:CheckBox id=chkbxCreateOwnPage runat="server" Text="Create a new page specifically for this content?" ToolTip=""></asp:CheckBox> -->
    </td></tr>
    
    </table>
<asp:Label ID="lblPagesThatUseThisItem" runat="server"></asp:Label>
