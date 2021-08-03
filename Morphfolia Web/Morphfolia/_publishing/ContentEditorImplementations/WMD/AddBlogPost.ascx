<%@ Control Language="c#" Inherits="Morphfolia.Web.UserControls.EditContent" CodeFile="AddBlogPost.ascx.cs" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Register TagPrefix="cc2" Namespace="Morphfolia.WebControls" Assembly="Morphfolia.WebControls" %>


<script type="text/javascript">

function PopulateTextContent()
{
    //alert('PopulateTextContent');
    var textContentViewCrtl = document.getElementById('<asp:Literal runat="server" ID="txtTextContentID"></asp:Literal>');
    var divWmdPreviewCrtl = document.getElementById('divWmdPreview');
    
    if(divWmdPreviewCrtl.textContent)
    {
        textContentViewCrtl.value = divWmdPreviewCrtl.textContent;
    }
    else
    {
        textContentViewCrtl.value = divWmdPreviewCrtl.innerText;
    }
}

</script>


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
            TextMode="MultiLine" Width="300px" Wrap="False" CssClass="wmd-ignore"></asp:TextBox>
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
    
    
    
    
    
        <p>
        <asp:TextBox ID="txtEditor_MarkDown" runat="server" TextMode="MultiLine" 
                Columns="100" Rows="8" Width="100%"></asp:TextBox>
        </p>
        
        <p style="display: none;">HTML Output<br />
        <asp:TextBox ID="txtEditor_HTML" CssClass="wmd-output" TextMode="MultiLine" 
                Columns="100" Rows="8" runat="server" Width="100%"></asp:TextBox>
        </p>
        
        <p>Preview<br />
        <div class='bordvis' style="padding: 5px;"><div class="wmd-preview" id="divWmdPreview"></div></div>
        <asp:TextBox ID="txtTextContent" runat="server" Height="96px" Width="100%"></asp:TextBox>
        </p>
        
        
    
    

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



    <script type="text/javascript">
		// to set WMD's options programatically, define a "wmd_options" object with whatever settings
		// you want to override.  Here are the defaults:
        wmd_options = {
			// format sent to the server.  Use "Markdown" to return the markdown source.
			output: "Markdown",

			// line wrapping length for lists, blockquotes, etc.
			lineLength: 40,

			// toolbar buttons.  Undo and redo get appended automatically.
			//buttons: "bold italic | link blockquote code image | ol ul heading hr",

			// option to automatically add WMD to the first textarea found.  See apiExample.html for usage.
			autostart: true
		};
	</script>
<script type="text/javascript" src="../wmd/wmd.js"></script>
