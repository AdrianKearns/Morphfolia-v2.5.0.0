/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

// AssignContentToPage.js


var sTextToDrop = 'TextToDrop';
var sEffectAllowed = "copy";
var idOfContentAssigner = 'notset';
var idOfAvailableContentfilterInputTextBox = 'notset';
var xhttp;
var objDoc;
var contentItemNodes;
var currentlySavedBindings;

function handleDragStart()
{
    //alert('handleDragStart');
	var oData = window.event.dataTransfer;
	oData.effectAllowed = sEffectAllowed;
}

function handleDragStart2(e, stuffToDrop)
{
	sTextToDrop = stuffToDrop;

    //alert(stuffToDrop);
    
    if (!e) var e = window.event;        
        
	var oData = e.dataTransfer;
	
	if(oData){
	    if(oData.effectAllowed){
	        oData.effectAllowed = sEffectAllowed;	
	    }
	}		
}

function handleDrop(e)
{
    var oTarg;
    if (!e) var e = window.event;
    if (e.target) oTarg = e.target;
    else if (e.srcElement) oTarg = e.srcElement;
    if (oTarg.nodeType == 3) // defeat Safari bug
        oTarg = oTarg.parentNode;
        
	//var oData = window.event.dataTransfer;
		
	cancelDefaultAction(e);	

    if(oTarg.tagName == 'DIV')
    {               
        var newElement = CreateActiveContentNode( GetAvailableContentItemByID( sTextToDrop.replace('anIdThatRepresentsAContentItem', '') ) );    
        sTextToDrop = 'TextToDrop';
        if(newElement)
        {
	        oTarg.appendChild( newElement );		
	        UpdateContentContainerDropBox( oTarg );
	    }
	}
//	else
//	{
//	    alert('Please drop the item onto the coloured background, not other items.');
//	}
}

function handleDrop2()
{
    var oTarg;
    if (!e) var e = window.event;
    if (e.target) oTarg = e.target;
    else if (e.srcElement) oTarg = e.srcElement;
    if (oTarg.nodeType == 3) // defeat Safari bug
        oTarg = oTarg.parentNode;
        
	var oData = e.dataTransfer;
	cancelDefaultAction(e);	
}

function handleDragEnter()
{
	var oData = window.event.dataTransfer;
	cancelDefaultAction();
	oData.dropEffect = sEffectAllowed;
}

function cancelDefaultAction(e)
{
    if (!e) var e = window.event;
	if(e.returnValue)
	{
	    e.returnValue = false;
	}
}




function callInProgress(xmlhttp)
{
    switch ( xmlhttp.readyState )
    {
        case 1, 2, 3:
            return true;
			break;

        // Case 4 and 0
        default:
            return false;
			break;
    }
}





/*
Credit - Cross-Browser AJAX XmlHttpRequest, many thanks to WoLpH - http://stackoverflow.com/users/54017/wolph
http://stackoverflow.com/questions/2557247/easiest-way-to-retrieve-cross-browser-xmlhttprequest
*/

var XMLHttpFactories = [
    function () {return new XMLHttpRequest()},
    function () {return new ActiveXObject("Msxml2.XMLHTTP")},
    function () {return new ActiveXObject("Msxml3.XMLHTTP")},
    function () {return new ActiveXObject("Microsoft.XMLHTTP")}
];

function createXMLHTTPObject() {
    var xmlhttp = false;
    for (var i=0;i<XMLHttpFactories.length;i++) {
        try {
            xmlhttp = XMLHttpFactories[i]();
        }
        catch (e) {
            continue;
        }
        break;
    }
    return xmlhttp;
}













function GetContentItems_ByNotesFilter(notesFilter)
{
    //alert('GetContentItems_ByNotesFilter: [' + notesFilter + ']');
	
	xhttp = createXMLHTTPObject();
	//xhttp.setRequestHeader('User-Agent','XMLHTTP/1.0');
	xhttp.onreadystatechange = GetContentItems_ByNotesFilter_HandlerOnReadyStateChange;
   	xhttp.open("GET", "_publishing/ContentList.ashx?nf=%" + notesFilter + "%", true);
	
	if( !callInProgress(xhttp) ) 
	{
		xhttp.send( null );
	}	 
}



function GetContentItems_ByNotesFilter_HandlerOnReadyStateChange()
{
	if (xhttp.readyState == 4)
	{
		var xmldoc = xhttp.responseXML;		
		previewScreen = document.getElementById('divAvailableContentItems');
		contentItemNodes = xmldoc.getElementsByTagName('ContentListItem');
        previewScreen.innerHTML = '';
		
		if(contentItemNodes.length > 0)
		{
			for (var i = 0; i < contentItemNodes.length; i++)
			{
                previewScreen.appendChild( CreateAvailableContentNode(contentItemNodes[i]) );
			}
		}
		else
		{
			previewScreen.innerHTML = '';
		}
	}
}



function GetContentItems_ById(id)
{
    var url = "_publishing/ContentList.ashx?contentIds=" + id;

    //alert(url);
	
	xhttp = createXMLHTTPObject();
	//xhttp.setRequestHeader('User-Agent','XMLHTTP/1.0');
	//xhttp.onreadystatechange = GetContentItems_ById_HandlerOnReadyStateChange;
   	xhttp.open("GET", url, false);
	
	if( !callInProgress(xhttp) ) 
	{
		xhttp.send( null );
	}	 
	
	return xhttp.responseXML;
}







function PopulateDropBoxesFromHedwig()
{    
	var txtHedwigInstance = document.getElementById( idOfContentAssigner + '_txtHedwig' );	
    //alert(txtHedwigInstance.value);
    
    var aryLines = txtHedwigInstance.value.split('\n');       
    //alert(aryLines.length);
        
    var currentLine;
    var targetDropBox;
    var s = '';
    for(var l = 0; l < aryLines.length; l++)
    {
        currentLine = aryLines[l].split(' '); 
        //alert(currentLine[0]);
        
        targetDropBox = getDropBoxByTitle(currentLine[1]);
        if(targetDropBox)
        {        
            //alert('locked: ' + targetDropBox.title);
            //s = s + '\n CDBx-' + targetDropBox.id + ' ';
            
            var currentChild;
            var length = targetDropBox.childNodes.length;
            for(var c = 0; c < length; c++)
            {
                currentChild = targetDropBox.childNodes[0];
                if(currentChild)
                {
                    targetDropBox.removeChild( currentChild );
                }
            }            
            
            for(var a = 2; a < currentLine.length; a++)
            {
                if(currentLine[a] != '')
                {
                    s = s + ' [' + currentLine[a] + ']';
                    //alert(currentLine[a]);
                                        
                                        
                    // http://localhost/Morphfolia.Web/ContentList.ashx?contentIds=24
                    // http://localhost/Morphfolia.Web/ContentList.ashx?contentIds=1   
                    
                    //GetContentItems_ById(currentLine[a]);                                     
                                        
                    //var newElement = CreateActiveContentNode( GetAvailableContentItemByID( currentLine[a] ) );    
                    
                    var xmldoc = GetContentItems_ById( currentLine[a] );
                    
                    var nodes = xmldoc.getElementsByTagName('ContentListItem');
                    
                    //alert(currentLine[a] + ' --- ' + nodes.length);
                    
                    var newElement = CreateActiveContentNode( nodes[0] );    
                    if(newElement)
                    {
	                    targetDropBox.appendChild( newElement );		
	                }
                }
            }
            
            UpdateContentContainerDropBox( targetDropBox );
        }
    }
    
    // ctl00_MainContentPlaceholder_EditPage1_assignContentToPage_txtContentFilter       
    GetContentItems_ByNotesFilter(document.getElementById(idOfAvailableContentfilterInputTextBox).value);
    
    //alert(s);
    
    // Example contents of Hedwig: 
    // @ TextC1 43 44
    // @ TextC3 43

    // Example ContentDropBox mark-up: 
    // <div id="ctl00_MainContentPlaceholder_EditPage1_assignContentToPage_oTarget0_ConcreteDropBox" 
    // title="TextC1" class="ContentDropBox" 
}


var allDivs = undefined;
function getDropBoxByTitle(dropBoxTitle)
{
    if(allDivs == undefined)
    {
        allDivs = document.getElementsByTagName("DIV");
    }
        
    for(var d = 0; d < allDivs.length; d++)
    {
        if(allDivs[d].title == dropBoxTitle)
        {
            return allDivs[d];
        }
    }
}



function UpdateContentContainerDropBox(contentContainerDropBox)
{
    //alert('UpdateContentContainerDropBox: ' + contentContainerDropBox.id);

    var obj;
	var s = '';
	var debugS = '';
		
    //debugS = debugS + contentContainerDropBox.childNodes.length + '\n';

	for( var i = 0; i < contentContainerDropBox.childNodes.length; i++ )
	{
	    obj = contentContainerDropBox.childNodes[i];	
	    //debugS = debugS + obj.tagName + '\n';
		if(obj.childNodes)
		{
		    //debugS = debugS + ' . ' + obj.childNodes.length + '\n';
			for( var i2 = 0; i2 < obj.childNodes.length; i2++ )
            {
                //debugS = debugS + ' - ' + i2 + ', ' + obj.childNodes[i2].tagName + '\n';
                if(obj.childNodes[i2].tagName == 'TABLE')
                {
                    s = s + obj.childNodes[i2].title.replace('Item ', ' ');
                }
            }
		}				
	}
	//alert(debugS);

	var spnContainerNameID = contentContainerDropBox.id.replace('ConcreteDropBox', 'ContainerName');
    //debugS = debugS + ' . ' + spnContainerNameID + '\n';

	var spnContainerName = document.getElementById(spnContainerNameID);
    //debugS = debugS + ' . ' + spnContainerName.innerHTML + '\n';
	
	var txtPropertyValueId = contentContainerDropBox.id.replace('ConcreteDropBox', 'txtPropertyValue');
    //debugS = debugS + ' . ' + txtPropertyValueId + '\n';
	
	var txtPropertyValue = document.getElementById( txtPropertyValueId );
    //debugS = debugS + ' . ' + txtPropertyValue + '\n';
	
    //alert(debugS);

    txtPropertyValue.value = '@ ' + spnContainerName.innerHTML + ' ' + s;
    
    //alert(txtPropertyValue.value);
    //alert('UpdateContentContainerDropBox \n ' + s);
	
	
	// Gather all bindings: 
	s = '';	
	
	
	var txtbxs = document.getElementsByTagName('input');
	
	
	for(var i = 0; i < txtbxs.length; i++)
	{
        if(txtbxs[i].id.indexOf('assignContentToPage') > 1)
	    {	
	        if(txtbxs[i].id.indexOf('_txtPropertyValue') > 1)
	        {
	            s = s + txtbxs[i].value + '\n';
	            //s = s + txtbxs[i].name + ' = ' + txtbxs[i].value + '\n';
	        }
	    }
	}
	
	
	// Put all bindings into hedwig for posting to server.
	var txtHedwigInstance = document.getElementById( idOfContentAssigner + '_txtHedwig' );	
	txtHedwigInstance.value = s;	
}






function GetAvailableContentItemByID( id )
{
    var s = 'GetAvailableContentItemByID ' + id + ' ';
	if(contentItemNodes.length > 0)
	{
		for (var i = 0; i < contentItemNodes.length; i++)
		{
            if(id == contentItemNodes[i].getAttribute('ContentID'))
            {
                return contentItemNodes[i];
                break;
            }
            else
            {
                s = s + '\n not ' + contentItemNodes[i].getAttribute('ContentID');
            }
		}
		//alert(s);
	}
	else
	{
		alert('GetAvailableContentItemByID() - contentItemNodes is empty.');
	}
}


function GetSavedBindings()
{
    //============================================================================
    // get list of saved content bindings (if any)
    //============================================================================
    var rawBindings = document.getElementById(idOfContentAssigner + '_txtHedwig').value;
    //alert(rawBindings);
    var listOfContentNeeded = '';
    var currentLines = rawBindings.split('@');
    var currentBindings;
    
    var temp, myId;
    var items;
    for(var l = 0; l < currentLines.length; l++)
    {
        temp = currentLines[l];
        items = temp.split(' ');
        for(var i = 0; i < items.length; i++)
        {
            if(items[i] != '')
            {
                myId = parseInt(items[i]);
                if(isNaN(myId))
                {
                    listOfContentNeeded = listOfContentNeeded + '@' + items[i]
                }else{
                    listOfContentNeeded = listOfContentNeeded + ' ' + myId;
                }
            }
        }
    }
       
    if(listOfContentNeeded.length > 1)
    {
        listOfContentNeeded = listOfContentNeeded.substring(1, listOfContentNeeded.length);
        return listOfContentNeeded;
    }
    else
    {
        return '';
    }
}



function indexPage(pageId)
{
    var indexProgressWindowContainer = document.getElementById('indexProgressWindowContainer');
    indexProgressWindowContainer.style.display = 'block';
    var indexProgressWindow = document.getElementById('indexProgressWindow');
    indexProgressWindow.src = "resetsearchindex.aspx?IndexAction=indexpage&id=" + pageId;
}





function CreateAvailableContentNode( node )
{
    var ContentID = node.getAttribute('ContentID');
    var ContentTypeMachineValue = node.getAttribute('ContentTypeMachineValue');
    var ContentTypeHumanReadableValue = node.getAttribute('ContentTypeHumanReadableValue');
    var Note = node.getAttribute('Note');
    var PageUsageCount = node.getAttribute('PageUsageCount');
    var IsLive = node.getAttribute('IsLive');
    var IsSearchable = node.getAttribute('IsSearchable');
    var LastModified = node.getAttribute('LastModified');
    var LastModifiedBy = node.getAttribute('LastModifiedBy');

	var oTable = document.createElement("TABLE");
	oTable.className = 'ActiveContentNode';
	oTable.cellPadding = 3;
	oTable.cellSpacing = 0;
	oTable.id = 'atbl_' + ContentID;
	//oTable.style.width = '100%';
	
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

	var oCell = oRow.insertCell(0);
	oCell.innerHTML = ContentID;
    oCell.align = "right";
    oCell.width = '30px';
    oCell.title = 'Content Id (' + ContentTypeHumanReadableValue + ')';
	    
	oCell = oRow.insertCell(1);
	oCell.innerHTML = PageUsageCount;
	oCell.title = 'Page Usage';
    oCell.align = "center";
    oCell.width = '30px';

	oCell = oRow.insertCell(2);
	oCell.innerHTML = IsLive;
	oCell.width = '16px';
	if(IsLive == 'True')
	{
	    oCell.title = 'Is live';
	    oCell.innerHTML = '<img src="../g/tickbox_ticked.gif" style="background-color: #ffffff;">';
    }else{	    
	    oCell.title = 'Is not live';
	    oCell.innerHTML = '<img src="../g/tickbox_empty.gif" style="background-color: #ffffff;">';
	}

	oCell = oRow.insertCell(3);
	oCell.innerHTML = IsSearchable;
	oCell.width = '16px';
	if(IsSearchable == 'True')
	{
	    oCell.title = 'Is searchable';
	    oCell.innerHTML = '<img src="../g/tickbox_ticked.gif" style="background-color: #ffffff;">';
    }else{	    
	    oCell.title = 'Is not searchable';
	    oCell.innerHTML = '<img src="../g/tickbox_empty.gif" style="background-color: #ffffff;">';
	}
	
    oCell = oRow.insertCell(4);
	//oCell.align = "center";
	//oCell.innerHTML = '<img id="anIdThatRepresentsAContentItem' + ContentID + '" src="../g/icon_dragHandle.jpg" style="cursor: hand;" ondragstart="handleDragStart2( this.id ); handleContentAssignmentImgClick(this, ' + ContentID + '); activeContentNodeID=' + ContentID + ';">';
	oCell.innerHTML = '<img id="anIdThatRepresentsAContentItem' + ContentID + '" src="../g/icon_dragHandle.jpg" style="cursor: hand;" onDrag="handleDragStart2( event, this.id ); handleContentAssignmentImgClick(this, ' + ContentID + '); activeContentNodeID=' + ContentID + ';" onClick="handleDragStart2( event, this.id ); handleContentAssignmentImgClick(this, ' + ContentID + '); activeContentNodeID=' + ContentID + ';">';
    oCell.width = '75%';



    oRow = oTBody.insertRow(1);
	oCell = oRow.insertCell(0);
	oCell.colSpan = 5;
	oCell.width = '100%';
	if( Note != '' )
	{
		oCell.innerHTML = Note;
	}else{
		oCell.innerHTML = '&nbsp;';
	}


	//ondragstart="handleDragStart2( this.id ); 
	//handleContentAssignmentImgClick(this, ' + oContentItem.ID + '); 
	//activeContentNodeID=' + oContentItem.ID + ';"
    //oTable.ondragstart = "alert('d');";


	oRow = oTBody.insertRow(2);
	oCell = oRow.insertCell(0);
	oCell.colSpan = 5;
	oCell.innerHTML = LastModified + ' by ' + LastModifiedBy;

	return oTable;
}


// This method expects to be passed an existing "Available" content node - not XML (?).
function CreateActiveContentNode( node )
{
    if(!node)
    {
        //alert('node is not defined.');
        return undefined;
    }
    else
    {      
        var ContentID = node.getAttribute('ContentID');        
        var ContentTypeMachineValue = node.getAttribute('ContentTypeMachineValue');
        var ContentTypeHumanReadableValue = node.getAttribute('ContentTypeHumanReadableValue');
        var Note = node.getAttribute('Note');
        var PageUsageCount = node.getAttribute('PageUsageCount');
        var IsLive = node.getAttribute('IsLive');
        var IsSearchable = node.getAttribute('IsSearchable');
        var LastModified = node.getAttribute('LastModified');
        var LastModifiedBy = node.getAttribute('LastModifiedBy');
        
        
        var oSpan = document.createElement("SPAN");
        
	    var oTable = document.createElement("TABLE");
	    oSpan.appendChild(oTable);
	    oTable.className = 'ActiveContentNode';
	    oTable.cellPadding = 3;
	    oTable.cellSpacing = 0;
	    oTable.title = 'Item ' + ContentID;

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
	    oCellID.innerHTML = ContentID;

	    //------------------------------------------------
	    // PREVIEW
	    //------------------------------------------------	
	    //var oCellPreview = oRow.insertCell(1);
	    //oCellPreview.align = "center";
	    //oCellPreview.innerHTML = '<a href=\'\' onclick=\"PreviewContentItem(' + ContentID + '); return false;\">Preview</a>';
        	    	
        	
        oCell = oRow.insertCell(1);
	    oCell.innerHTML = IsLive;
	    if(IsLive == 'True')
	    {
	        oCell.title = 'Is live';
	        oCell.innerHTML = '<img src="../g/tickbox_ticked.gif" style="background-color: #ffffff;">';
        }else{	    
	        oCell.title = 'Is not live';
	        oCell.innerHTML = '<img src="../g/tickbox_empty.gif" style="background-color: #ffffff;">';
	    }

	    oCell = oRow.insertCell(2);
	    oCell.innerHTML = IsSearchable;
        oCell.title = 'Is Searchable';
	    if(IsSearchable == 'True')
	    {
	        oCell.title = 'Is searchable';
	        oCell.innerHTML = '<img src="../g/tickbox_ticked.gif" style="background-color: #ffffff;">';
        }else{	    
	        oCell.title = 'Is not searchable';
	        oCell.innerHTML = '<img src="../g/tickbox_empty.gif" style="background-color: #ffffff;">';
	    }
    	
    	
    	
	    //------------------------------------------------
	    // MOVE UP
	    //------------------------------------------------
	    var oCellMoveUp = oRow.insertCell(3);
	    oCellMoveUp.align = "center";

	    var imgMoveUp = document.createElement("IMG");
        oCellMoveUp.appendChild(imgMoveUp);
        imgMoveUp.name = 'img_' + ContentID
        imgMoveUp.title = 'Click to re-order the content within the content drop box.';
        imgMoveUp.src = '../g/icon_moveUp.jpg';
        imgMoveUp.style.cursor = 'hand';

        if(imgMoveUp.addEventListener){ // Mozilla, Netscape, Firefox
	        imgMoveUp.addEventListener('click', MoveActiveContentNodeUp, false);
        } else { // IE
	       imgMoveUp.attachEvent("onclick", MoveActiveContentNodeUp)
        }

        
	    //------------------------------------------------
	    // MOVE DOWN
	    //------------------------------------------------
	    var oCellMoveDown = oRow.insertCell(4);
	    oCellMoveDown.align = "center";
	    oCellMoveDown.width = '22';

	    var imgMoveDown = document.createElement("IMG");
        oCellMoveDown.appendChild(imgMoveDown);
        imgMoveDown.name = 'img_' + ContentID
        imgMoveDown.title = 'Click to re-order the content within the content drop box.';
        imgMoveDown.src = '../g/icon_moveDown.jpg';
        imgMoveDown.style.cursor = 'hand';

        if(imgMoveDown.addEventListener){ // Mozilla, Netscape, Firefox
	        imgMoveDown.addEventListener('click', MoveActiveContentNodeDown, false);
        } else { // IE
	       imgMoveDown.attachEvent("onclick", MoveActiveContentNodeDown)
        }
        
	    //------------------------------------------------
	    // Remove
	    //------------------------------------------------
	    var oCellRemove = oRow.insertCell(5);
	    oCellRemove.align = "center";	
	    oCellRemove.width = '22';
	    oCellRemove.innerHTML = '<img id="img_' + ContentID + '" src=\'../g/icon_Remove.jpg\' title=\'Click to remove from the content drop box.\' style=\'cursor: hand;\' onClick="RemoveActiveContentNodeFromCanvas( this );">';
    	
	    //------------------------------------------------
	    // Empty
	    //------------------------------------------------
	    var oCell = oRow.insertCell(6);
	    oCell.innerHTML = "<a href='edit_content.aspx?c=" + ContentID + "' target='_blank'>Edit</a>";
	    oCell.width = '100%';
    	
	    //------------------------------------------------
	    // Content abbrev:
	    //------------------------------------------------
	    var oRow = oTBody.insertRow(1);
	    var oCell = oRow.insertCell(0);
	    oCell.innerHTML = Note;
	    oCell.colSpan = 7;

	    return oSpan;
	}
}



function RemoveActiveContentNodeFromCanvas( img )
{
    //alert('RemoveActiveContentNodeFromCanvas id=[' + img.id + '] name=[' + img.name + ']');

	var obj, strID;
	if(img.id)
	{
	    strID = new String(img.id);
	}
	else
	{
	    strID = new String(img.name);
	}
	//var strID = new String(img.id);
	var id = strID.substr( strID.indexOf('_')+1 );
		
    //alert('RemoveActiveContentNodeFromCanvas id=' + id);
		
		
		
    //var helloPolly = img.parentElement.parentElement.parentElement.parentElement;
    //alert('' + helloPolly.id + ' / ' + helloPolly.tagName);
		
	//var tblContentNode = document.getElementById( 'tbl_' + id );
	var tblContentNode = img.parentElement.parentElement.parentElement.parentElement;
	if(tblContentNode)
	{		
		var theSpan = tblContentNode.parentElement;
		var theDiv = theSpan.parentElement;		
        theDiv.removeChild(theSpan);

		var dragHandleImg = document.getElementById('anIdThatRepresentsAContentItem' + id);
		if(dragHandleImg)
		{
		    dragHandleImg.src = '../g/icon_dragHandle.jpg';
		}
		
		UpdateContentContainerDropBox( theDiv );
	}
	
}


function MoveActiveContentNodeUp(e)
{
    var targ;
    if (!e) var e = window.event;
    if (e.target) targ = e.target;
    else if (e.srcElement) targ = e.srcElement;
    if (targ.nodeType == 3) // defeat Safari bug
        targ = targ.parentNode;
    
    MoveActiveContentNodeUpOrDown(targ, 'up');
}

function MoveActiveContentNodeDown(e)
{
    var targ;
    if (!e) var e = window.event;
    if (e.target) targ = e.target;
    else if (e.srcElement) targ = e.srcElement;
    if (targ.nodeType == 3) // defeat Safari bug
        targ = targ.parentNode;
        
    MoveActiveContentNodeUpOrDown(targ, 'down');
}

// direction: 'up' or 'down' 
function MoveActiveContentNodeUpOrDown( img, direction )
{
    //alert('MoveActiveContentNodeUpOrDown');

	var strID = new String(img.name);
	var id = 'Item ' + strID.substr( strID.indexOf('_')+1 );
	var spanDestinationContentNode;	

    var obj = img;
	for(var x = 0; x < 5; x++)
	{
	    if(obj.parentNode)
	    {	    
	        obj = obj.parentNode;
	    }
	}
	
	//var tblCallingContentNode = obj;
	var spanCallingContentNode = img.parentElement.parentElement.parentElement.parentElement.parentElement;
	//alert(tblCallingContentNode.tagName);
	//alert(tblCallingContentNode.parentElement.tagName);
	//alert(tblCallingContentNode.parentElement.parentElement.tagName);
	
    var divContentDropBox = spanCallingContentNode.parentNode;
	//alert(parentElement.tagName);

    //ReportChildren(parentElement);


	var aryChildren = divContentDropBox.childNodes;
	var ci = 0;
	var di = 0;
	
	//alert(aryChildren.length);
	//ReportChildren(divContentDropBox);
	
    var tempChild;
	for(var i = 0; i < aryChildren.length; i++)
	{	
        if(aryChildren[i] == spanCallingContentNode)
	    {
	        //alert('got caller: ' + i);
	        ci = i;
	    }	
	}		
			

	if(direction == 'up')
	{
	    if((ci-1) >= 0)
	    {
	        var x = divContentDropBox.insertBefore(spanCallingContentNode, aryChildren[ci-1]);
	    }
	}else{
	    if((ci+1) < aryChildren.length)
	    {
            var x = divContentDropBox.insertBefore(aryChildren[ci+1], spanCallingContentNode);
        }
	}
			
			
	UpdateContentContainerDropBox( spanCallingContentNode.parentNode );
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
	}
}



//<ContentListItem ContentID="51" 
//  ContentTypeMachineValue="BPST" ContentTypeHumanReadableValue="Blog Post" 
//  Note="A New boring test post" PageUsageCount="0" IsLive="True" 
//  IsSearchable="True" LastModified="10/02/2009 1:01:47 p.m." LastModifiedBy="AdrianK" /> 

function ReportChildren(obj)
{
    var sDebug1 = ' ';
    
    if(obj.childNodes)
    {        
        sDebug1 = sDebug1 + 'yes childNodes: ' + obj.childNodes.length + '\n';

        for(var i = 0; i < obj.childNodes.length; i++)
        {
            sDebug1 = sDebug1 + '[' + obj.childNodes[i].tagName + ']\n';
            //sDebug1 = sDebug1 + ReportChildrenINNER(obj.childNodes[i], 1);
        }
    }
    else
    {
        sDebug1 = sDebug1 + 'No childNodes';
    }
    
    alert(sDebug1);
}


function ReportChildrenINNER(obj, c)
{
    var sDebug2 = 'ReportChildrenINNER ';

    if(obj.childNodes)
    {
        for(var i = 0; i < obj.childNodes.length; i++)
        {
            sDebug2 = sDebug2 + ' . ' + c + ' . ' + obj.childNodes[i].tagName + '\n';
            sDebug2 = sDebug2 + ' . ' + c + ' . ' + ReportChildrenINNER(obj.childNodes[i], c++);
        }
        return sDebug2;
    }
    else
    {
        return ' . . No childNodes';
    }
}


// Call this everytime we load: 
//UpdateAllContentContainerDropBoxes();
