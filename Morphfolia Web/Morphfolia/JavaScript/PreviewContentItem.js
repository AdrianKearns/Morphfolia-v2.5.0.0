/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

// Declare 'private' variables:
var xhttp;
var objDoc;
var contentItemPreviewPanel;
var tblContentItemPreviewContainer;


function PreviewContentItem( contentItemId )
{		

	//alert( sHttpContextCurrentRequestApplicationPath );

	// Initilize 'private' variables:
	contentItemPreviewPanel = document.getElementById('contentItemPreviewPanel');

	
	xhttp = new ActiveXObject("Msxml2.XMLHTTP"); 

	//hook the event handler
	xhttp.onreadystatechange = PreviewContentItemHandlerOnReadyStateChange;

	//prepare the call, http method=GET, false=asynchronous call
	xhttp.open("GET", "ContentItemPreview.ashx?cid=" + contentItemId, false);

	//finally send the call
	xhttp.send();          
}


// Haven't put any error handling in here yet.
function PreviewContentItemHandlerOnReadyStateChange()
{
	if (xhttp.readyState == 4)
	{
		contentItemPreviewPanel = document.getElementById('contentItemPreviewPanel');
		contentItemPreviewPanel.innerHTML = xhttp.responseText;
		ShowContentItemPreviewContainer();
	}
}

function ShowContentItemPreviewContainer()
{
	tblContentItemPreviewContainer = document.getElementById('tblContentItemPreviewContainer');
	tblContentItemPreviewContainer.style.zIndex = 2000;
	tblContentItemPreviewContainer.style.visibility = 'visible';
}


function HideContentItemPreviewContainer()
{
	tblContentItemPreviewContainer = document.getElementById('tblContentItemPreviewContainer');
	tblContentItemPreviewContainer.style.zIndex = -2000;
	tblContentItemPreviewContainer.style.visibility = 'hidden';
}

