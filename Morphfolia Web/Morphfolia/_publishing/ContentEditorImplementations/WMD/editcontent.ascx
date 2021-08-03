<%@ Control Language="c#" Inherits="Morphfolia.Web.UserControls.EditContent" CodeFile="EditContent.ascx.cs" %>

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
   

<table cellspacing="5" cellpadding="3" border="0" width="90%">
  <tr>
    <td valign="top">ID</td>
    <td valign="top" id='tdContentId'><asp:literal id="litContentID"
       runat="server"></asp:literal></td></tr>
       
  <tr>
    <td valign="top">Note</td>
    <td valign="top"><asp:textbox id=txtNote runat="server" Width="462px" Columns="50" Rows="5" TextMode="MultiLine" CssClass="wmd-ignore"></asp:textbox></td></tr>
        
  <tr>
    <td valign="top">&nbsp;</td>
    <td valign="top">
    <asp:Button id="btnSave1" runat="server" Text="Save" onclick="btnSave_Click" 
            ToolTip="Saves the currently displayed content and allows you to keep working on it."></asp:Button> 
    <asp:Button id="btnSaveNExit1" runat="server" Text="Save And Exit" 
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
    <td valign="top">Content</td>
    <td valign="top">(Mode) <asp:DropDownList ID="ddlContentEntryFilter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlContentEntryFilter_SelectedIndexChanged">
            <asp:ListItem Value="HtmlEditor">Normal</asp:ListItem>
        </asp:DropDownList></td></tr>
    
  <tr>
    <td valign="top" style="HEIGHT: 134px">&nbsp;</td>
    <td valign="top" style="HEIGHT: 134px">
    
    
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
        
        
        
&nbsp;&nbsp;&nbsp;
        <asp:Panel ID="pnlFormTemplateContainer" runat="server" Width="100%">
        </asp:Panel>
    </td></tr>
  <tr>
    <td valign="top"></td>
    <td valign="top">
    <asp:CheckBox id=chkbxIsSearchable runat="server" Text="Is Searchable"></asp:CheckBox> &nbsp; 
    <asp:CheckBox id=chkbxIsLive runat="server" Text="Is Live"></asp:CheckBox> &nbsp; 
    <asp:CheckBox id=chkbxIncludeInSiteMap runat="server" Text="Include In Site Map" Visible="False"></asp:CheckBox></td></tr>

  <tr>
    <td valign="top"></td>
    <td valign="top">
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
