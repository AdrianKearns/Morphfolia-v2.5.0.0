<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddBlogPost.aspx.cs" Inherits="Morphfolia__publishing_AddBlogPost" Title="Add Blog Post" ValidateRequest="false" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register src="~/Morphfolia/_publishing/ContentEditorImplementations/TinyMCE/AddBlogPost.ascx" tagname="AddBlogPost" tagprefix="uc1" %>


<asp:Content ContentPlaceHolderID=PageHeadPlaceholder runat=server>

    <script language=javascript src='../JavaScript/UrlTypeAheadHelper.js'></script>
    <script language=javascript src='../JavaScript/PreviewContentItem.js'></script>
    <!-- script language=javascript src='../JavaScript/EditPage.js'></script -->

    <style type='text/css'>
	    .bordvis { BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid }
	    TABLE.ActiveContentNode { BORDER-TOP: #000000 1px solid; MARGIN: 5px; BORDER-LEFT: #000000 1px solid; BACKGROUND-COLOR: #ddffc1; }
	    TABLE.ActiveContentNode TD { BORDER-RIGHT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid }
	    TR.ActiveContentNodeToolbar { BACKGROUND-COLOR: #cdecb4 }
    </style>


    <script>
    // EditPage.js
    // for use with the EditPage UserControl.

    var sTextToDrop = 'TextToDrop';
    var sEffectAllowed = "copy";
    //var sEffectAllowed = "move";

    var activeContentNodeID;


    function handleDragStart()
    {
	    var oData = window.event.dataTransfer;
	    oData.effectAllowed = sEffectAllowed;
    }

    function handleDragStart2( stuffToDrop )
    {
	    var oData = window.event.dataTransfer;
	    oData.effectAllowed = sEffectAllowed;	
	    sTextToDrop = stuffToDrop;
    }

    function handleDrop()
    {
	    var oTarg = window.event.srcElement;
	    var oData = window.event.dataTransfer;
	    cancelDefaultAction();	

	    try
	    {
		    oTarg.appendChild( CreateActiveContentNode( activeContentNodeID ) );
		    // deactivate the Content Node as an available Content Node so it can't be added twice.
    		
		    UpdateContentContainerDropBox( oTarg );
	    }
	    catch (exc) 
	    {
		    // 'Unexpected call to method or property access.'
		    alert( exc.description );
	    }
    }


    function UpdateContentContainerDropBox( contentContainerDropBox )
    {
	    //alert( 'UpdateContentContainerDropBox: ' + contentContainerDropBox.id );
    	
	    var txtID = contentContainerDropBox.id.replace('ConcreteDropBox', 'txtPropertyValue');
	    var txt = document.getElementById( txtID );
    	
	    var s = '';
	    for( var i = 0; i < contentContainerDropBox.children.length; i++ )
	    {
		    s = s + contentContainerDropBox.children[i].id.replace('tbl_', ' ');
		    //s = s.replace('tbl_', ' ');
	    }
	    txt.value = s;
	    //alert(s);
    }



    function handleDrop2()
    {
	    var oTarg = window.event.srcElement;
	    var oData = window.event.dataTransfer;
	    cancelDefaultAction();	
    }

    function handleDragEnter()
    {
	    var oData = window.event.dataTransfer;
	    cancelDefaultAction();
	    oData.dropEffect = sEffectAllowed;
    }

    function cancelDefaultAction()
    {
	    var oEvent = window.event;
	    oEvent.returnValue = false;
    }


    function RemoveActiveContentNodeFromCanvas( imgId )
    {
	    var obj;
	    var strID = new String(imgId);
	    var id = strID.substr( strID.indexOf('_')+1 );
    		
	    var tblContentNode = document.getElementById( 'tbl_' + id );
	    if(tblContentNode)
	    {		
		    obj = tblContentNode.parentElement;

		    tblContentNode.removeNode(true);
		    // Reinstate the removed ContentNode in the list of available Content Nodes.
    		
		    //alert( 'anIdThatRepresentsAContentItem' + id );
		    var img = document.getElementById('anIdThatRepresentsAContentItem' + id);
		    img.src = '../g/icon_dragHandle.jpg';
    		
		    UpdateContentContainerDropBox( obj );
	    }
    	
    }




    // direction: 'up' or 'down' 
    function MoveActiveContentNodeUpOrDown( imgId, direction )
    {
	    var strID = new String(imgId);
	    var id = 'tbl_' + strID.substr( strID.indexOf('_')+1 );
	    var tblDestinationContentNode;
	    var tblCallingContentNode = document.getElementById(id);
	    var aryChildren = tblCallingContentNode.parentElement.children;


	    var ci = 0;
	    var di = 0;
	    var s = id + ' >';

	    for(var i = 0; i < aryChildren.length; i++)
	    {
		    s = s + '| ' + aryChildren[i].id;
		    if(id==aryChildren[i].id)
		    {
			    //alert(id);
			    ci = i;
			    //tblCallingContentNode = aryChildren[i];
    			
			    if(direction == 'up')
			    {
				    di = i-1;
				    //tblDestinationContentNode = aryChildren[i-1];
			    }
			    else
			    {
				    di = i+1;
				    //tblDestinationContentNode = aryChildren[i+1];			
			    }
			    //break;
    			
			    tblDestinationContentNode = aryChildren[di];
		    }
	    }
    			
	    //alert(s);
    			
	    if((tblCallingContentNode)&&(tblDestinationContentNode))
	    {
		    tblCallingContentNode.swapNode( tblDestinationContentNode );
		    // reset move arrow icons as appropriate to nodes position.		
	    }else{	
		    //alert(ci + ' / ' + di);
	    }
    	
    	
	    UpdateContentContainerDropBox( tblCallingContentNode.parentElement );
    }


    function CreateActiveContentNode( contentNodeID )
    {
	    var oContentItem = GetAvailableContentItemByID( contentNodeID );

	    var oTable = document.createElement("TABLE");
	    oTable.className = 'ActiveContentNode';
	    oTable.cellPadding = 5;
	    oTable.cellSpacing = 0;
	    oTable.id = 'tbl_' + contentNodeID;

	    var oTHead = document.createElement("THEAD");
	    var oTBody = document.createElement("TBODY");
	    var oTFoot = document.createElement("TFOOT");

	    oTable.appendChild(oTHead);
	    oTable.appendChild(oTBody);
	    oTable.appendChild(oTFoot);
    	
	    //------------------------------------------------
	    // Toolbar
	    //------------------------------------------------		
	    var oRow = oTBody.insertRow(0);
	    oRow.className = 'ActiveContentNodeToolbar';

	    //------------------------------------------------
	    // ID
	    //------------------------------------------------	
	    var oCellID = oRow.insertCell(0);
	    oCellID.align = "right";
	    oCellID.width = '30';
	    oCellID.innerHTML = '<b>' + contentNodeID + '</b>';

	    //------------------------------------------------
	    // PREVIEW
	    //------------------------------------------------	
	    var oCellPreview = oRow.insertCell(1);
	    oCellPreview.align = "center";
	    //oCellPreview.innerHTML = "<a href='' target='_Blank'>Preview</a>";
	    oCellPreview.innerHTML = '<a href=\'\' onclick=\"PreviewContentItem(' + contentNodeID + '); return false;\">Preview</a>';
    	
	    //------------------------------------------------
	    // MOVE UP
	    //------------------------------------------------
	    var oCellMoveUp = oRow.insertCell(2);
	    oCellMoveUp.align = "center";
	    oCellMoveUp.innerHTML = '<img id="img_' + contentNodeID + '" src=\'../g/icon_moveUp.jpg\' title=\'Click to re-order the content within the content drop box.\' style=\'cursor: hand;\' onClick="MoveActiveContentNodeUpOrDown( this.id, \'up\' );">';
	    //oCellMoveDown.innerHTML = "&nbsp;";

	    //------------------------------------------------
	    // MOVE DOWN
	    //------------------------------------------------
	    var oCellMoveDown = oRow.insertCell(3);
	    oCellMoveDown.align = "center";
	    oCellMoveDown.innerHTML = '<img id="img_' + contentNodeID + '" src=\'../g/icon_moveDown.jpg\' title=\'Click to re-order the content within the content drop box.\' style=\'cursor: hand;\' onClick="MoveActiveContentNodeUpOrDown( this.id, \'down\' );">';
	    //oCellMoveDown.innerHTML = "&nbsp;";

	    //------------------------------------------------
	    // Remove
	    //------------------------------------------------
	    var oCellRemove = oRow.insertCell(4);
	    oCellRemove.align = "center";	
	    oCellRemove.innerHTML = '<img id="img_' + contentNodeID + '" src=\'../g/icon_Remove.jpg\' title=\'Click to remove from the content drop box.\' style=\'cursor: hand;\' onClick="RemoveActiveContentNodeFromCanvas( this.id );">';
    	
	    //------------------------------------------------
	    // Empty
	    //------------------------------------------------
	    var oCell = oRow.insertCell(5);
	    oCell.align = "center";
	    oCell.innerHTML = "<a href='edit_content.aspx?c=" + contentNodeID + "' target='_blank'>Edit</a>";
	    oCell.width = '100%';
    	
	    //------------------------------------------------
	    // Content abbrev:
	    //------------------------------------------------
	    var oRow = oTBody.insertRow(1);
	    var oCell = oRow.insertCell(0);
	    oCell.innerHTML = oContentItem.Note;
	    oCell.colSpan = 6;

	    return oTable;
    }

    function ContentItem( id, note )
    {
	    this.ID = id;
	    this.Note = note; 
    } 


    var aryAvailableContentItems = new Array;
    // litContentItemJavaScriptDeclarations


    function GetAvailableContentItemByID( id )
    {
	    for(i = 0; i < aryAvailableContentItems.length; i++)
	    {
		    if( aryAvailableContentItems[i].ID == id )
		    {
			    return aryAvailableContentItems[i];
			    break;
		    }
	    }
    }


    function loadActiveContentItemsToContentCanvas( oConcreteContentContainerID, sContentItemIDs )
    {
	    var oConcreteContentContainer = document.getElementById( oConcreteContentContainerID );
	    var aryContentItemIDs = sContentItemIDs.split(" ")
	    var img;


	    if( !oConcreteContentContainer )
	    {
		    alert('Could not get concrete content container, id = ' + oConcreteContentContainerID);
	    }
	    else
	    {
		    for(var i = 0; i < aryContentItemIDs.length; i++)
		    {
			    if( aryContentItemIDs[i] != "" )
			    {
				    oConcreteContentContainer.appendChild( CreateActiveContentNode( aryContentItemIDs[i] ) );
    		
				    img = document.getElementById('anIdThatRepresentsAContentItem' + aryContentItemIDs[i]);
				    handleContentAssignmentImgClick( img, aryContentItemIDs[i] );
			    }
		    }
	    }
    }


    function CreateAvailableContentNode( oContentItem )
    {
	    var oTable = document.createElement("TABLE");
	    oTable.className = 'ActiveContentNode';
	    oTable.cellPadding = 5;
	    oTable.cellSpacing = 0;
	    oTable.id = 'atbl_' + oContentItem.ID;
    	
	    var oTHead = document.createElement("THEAD");
	    var oTBody = document.createElement("TBODY");
	    var oTFoot = document.createElement("TFOOT");

	    oTable.appendChild(oTHead);
	    oTable.appendChild(oTBody);
	    oTable.appendChild(oTFoot);
    	
	    //------------------------------------------------
	    // Toolbar
	    //------------------------------------------------		
	    var oRow = oTBody.insertRow(0);
	    //oRow.className = 'ActiveContentNodeToolbar';

	    //------------------------------------------------
	    // ID
	    //------------------------------------------------	
	    var oCellPreview = oRow.insertCell(0);
	    //oCellPreview.align = "center";
	    oCellPreview.innerHTML = oContentItem.ID;
    	
	    //------------------------------------------------
	    // Note
	    //------------------------------------------------
	    var oCell = oRow.insertCell(1);
	    if( oContentItem.Note != '' )
	    {
		    oCell.innerHTML = oContentItem.Note;
	    }else{
		    oCell.innerHTML = '&nbsp;';
	    }
	    oCell.width = '100%';

	    //------------------------------------------------
	    // Drag
	    //------------------------------------------------
	    var oCellMoveDown = oRow.insertCell(2);
	    oCellMoveDown.align = "center";
	    oCellMoveDown.innerHTML = '<img id="anIdThatRepresentsAContentItem' + oContentItem.ID + '" src="../g/icon_dragHandle.jpg" style="cursor: hand;" ondragstart="handleDragStart2( this.id ); handleContentAssignmentImgClick(this, ' + oContentItem.ID + '); activeContentNodeID=' + oContentItem.ID + ';">';


	    //ondragstart="handleDragStart2( this.id ); 
	    //handleContentAssignmentImgClick(this, ' + oContentItem.ID + '); 
	    //activeContentNodeID=' + oContentItem.ID + ';"
        //oTable.ondragstart = "alert('d');";

	    return oTable;
    }

    function handleContentAssignmentImgClick( img, oContentItemId )
    {
	    if((img)&&(oContentItemId))
	    {
		    if( img.src.indexOf('g/icon_dragHandle.jpg') > 1 )
		    {
			    // Append content item: 
			    img.src = '../g/tickbox_empty.gif';
    			
    			
			    // <div id="EditPage1_oTarget3_ConcreteDropBox" 
			    //oTarg.appendChild( CreateActiveContentNode( activeContentNodeID ) );

		    }else{
    		
			    // Remove content item: 
			    if( img.src.indexOf('g/icon_Remove.jpg') > 1 )
			    {
				    RemoveActiveContentNodeFromCanvas( oContentItemId );
			    }
		    }
	    //}else{
		    //alert('handleContentAssignmentImgClick Error.');
	    }
    }

    function GetListOfActiveContentItems()
    {	
	    var s = '';
	    var aryChildren;
	    var drpbxName;
	    var contentDropBoxes = document.body.getElementsByTagName("DIV");
	    for(var i = 0; i < contentDropBoxes.length; i++)
	    {
		    if( contentDropBoxes[i].id.indexOf("ConcreteDropBox") > 1 )
		    {
			    //...
			    // <span id="EditPage1_oTarget3_ContainerName">TextR2C2</span><div id="EditPage1_oTarget3_ConcreteDropBox" on
			    drpbxName = contentDropBoxes[i].parentElement.children[0].innerText;
			    //	var aryChildren = tblCallingContentNode.parentElement.children;

			    s = s + ' @' + drpbxName + ' ';
    		
			    aryChildren = contentDropBoxes[i].children;
			    for(var c = 0; c < aryChildren.length; c++)
			    {
				    var sID = new String(aryChildren[c].id);
				    s = s + ' ' + sID.substr( sID.indexOf('_')+1 );
			    }		
		    }
	    }


        // the id is wrong !!!!!
	    //var txtContentItems = document.getElementById('_ctl0_ContentPlaceHolder1_EditPage1_txtContentItems');
    	
	    //	<input name="ctl00$ContentPlaceHolder1$EditPage1$txtContentItems" type="text" id="ctl00_ContentPlaceHolder1_EditPage1_txtContentItems" id="txtContentItems" style="visibility:hidden;position:absolute;" />

    	
	    var txtContentItems = document.getElementById('ctl00_ContentPlaceHolder1_EditPage1_txtContentItems');
	    txtContentItems.value = s;
    }



    /*
    function loadAvailableContentItems()
    {
	    for(i = 0; i < aryAvailableContentItems.length; i++)
	    {
		    divAvailableContentItems.appendChild( CreateAvailableContentNode( aryAvailableContentItems[i] ) );
	    }
    }
    */

    function loadAvailableContentItems()
    {
        //window.status = window.status + 'b ';
        //alert(aryAvailableContentItems.length);
        //alert(aryAvailableContentItems[0].Note);
        
        //var txtContentFilter = document.getElementById(EditPageID + '_txtContentFilter');
        var txtContentFilter = document.getElementById('<asp:Literal ID="litID" runat="server"></asp:Literal>');
        if(txtContentFilter)
        {        
            //alert('457');
        
            //window.status = '';
            //divAvailableContentItems.deleteContents();
            var divAvailableContentItems = document.getElementById('divAvailableContentItems');
            divAvailableContentItems.innerHTML = '';
            for(var i = 0; i < aryAvailableContentItems.length; i++)
            {
                // indexOf is case-sensitive.
                if(aryAvailableContentItems[i].Note.toUpperCase().indexOf(txtContentFilter.value.toUpperCase()) > -1)
                {
                    //alert(aryAvailableContentItems[i].Note);
                    //window.status = window.status + aryAvailableContentItems[i].ID + ' ';
        		    divAvailableContentItems.appendChild( CreateAvailableContentNode( aryAvailableContentItems[i] ) );
                }         
            }
        }
        else
        {
            //alert('476');
        
            for(i = 0; i < aryAvailableContentItems.length; i++)
            {
	            divAvailableContentItems.appendChild( CreateAvailableContentNode( aryAvailableContentItems[i] ) );
            }
        }
    }


    function btnIndex_onclick()
    {
        var id = '<asp:Literal ID="litPageIDForIndexing" runat="server"></asp:Literal>';
        
        var indexProgressWindowContainer = document.getElementById('indexProgressWindowContainer');
        indexProgressWindowContainer.style.display = 'block';
        var indexProgressWindow = document.getElementById('indexProgressWindow');
        indexProgressWindow.src = "resetsearchindex.aspx?IndexAction=Indexpage&id=" + id;
    }

    </script>


</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">
    <uc1:AddBlogPost ID="AddBlogPost1" runat="server" />
</asp:Content>

