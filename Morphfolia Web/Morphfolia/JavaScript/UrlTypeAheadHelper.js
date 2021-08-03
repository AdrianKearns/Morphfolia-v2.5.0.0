/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

var xhttp;
var objDoc;
var URLInputField, btnSearch;
var previewScreen;

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


function GetExistingURLInfo()
{		    
	if (window.XMLHttpRequest) 
	{ // Mozilla, Safari,...
		xhttp = new XMLHttpRequest();
		if (xhttp.overrideMimeType) 
		{
			xhttp.overrideMimeType('text/xml');
		}
	} else if (window.ActiveXObject) 
	{ 
		// IE
		try {
			xhttp = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e) 
		{
			try {
				xhttp = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e)
			{
			}
		}
	}
	
	
	// hook the event handler
	xhttp.onreadystatechange = HandlerOnReadyStateChange;

	//alert( sUrlInputId );

	// prepare the call, http method=GET, false=asynchronous call
	// xhttp.open("GET", "http://localhost/Morphfolia.Web/asyncHandlers/SearchResultPreview.ashx?searchCriteria=" + txtSearchCriteria.value, false);
	xhttp.open("GET", "UrlTypeAheadHelper.ashx?urlHint=" + URLInputField.value, true);
	//xhttp.open("GET", sHttpContextCurrentRequestApplicationPath + "/SearchResultPreview.ashx?searchCriteria=t", true);

	
	// alert( sHttpContextCurrentRequestApplicationPath + "/SearchResultPreview.ashx?searchCriteria=t" );
	if( !callInProgress(xhttp) ) 
	{
		xhttp.send( null );
	}
}


function HandlerOnReadyStateChange()
{
	if (xhttp.readyState == 4)
	{
		//previewScreen = document.getElementById('divExistingURLs');
		var xmldoc = xhttp.responseXML;
		var nodes = xmldoc.getElementsByTagName('urlSegment');
		var s = "";

		if(nodes.length > 0)
		{
			if((nodes.length == 1)&&(nodes[0].firstChild.data=='None Found'))
			{
				previewScreen.style.visibility = 'hidden';
			}
			else
			{
				previewScreen.style.visibility = 'visible';
				s = s + '<table width=100% cellpadding=1 cellspacing=0>\n';
				for (var i = 0; i < nodes.length; i++)
				{
					// IE:
					//s = s + '<tr onclick=\"SetURL(\'' + nodes[i].text + '\');\" class=\'\' onmouseover=\"this.className=\'activeSearchPreview\';" onmouseout=\"this.className=\'\';\"><td>' + nodes[i].text + '</td> ';

					// Mozilla (+ IE?): 
					s = s + '<tr onclick=\"SetURL(\'' + nodes[i].firstChild.data + '\');\" class=\'\' onmouseover=\"this.className=\'activeSearchPreview\';" onmouseout=\"this.className=\'\';\" title=\'Click to use this URL.\'><td>' + nodes[i].firstChild.data + '</td></tr>';
								
					//s = s + '<td align=right>' + nodes[i].getAttribute('Count') + '</td></tr>\n';
				}
				s = s + '</table>\n';
				s = s + '<p><a href="" onclick="ClosePreviewScreen(); return false;">Close</a></p>';

				previewScreen.innerHTML = s;			
			}
		}
		else
		{
			previewScreen.style.visibility = 'hidden';
		}
	}
}


function CheckURLCriteria( urlInputField, idOfdivExistingURLs )
{	
    URLInputField = urlInputField;
    previewScreen = document.getElementById(idOfdivExistingURLs);

    
	if(URLInputField.value.length > 0)
	{	
		GetExistingURLInfo();
	}else{
		ClosePreviewScreen();
	}
}

function ClosePreviewScreen()
{
	//previewScreen = document.getElementById('divExistingURLs');
	previewScreen.innerHTML = '';
	previewScreen.style.visibility = 'hidden';
}

function SetURL( url )
{
	URLInputField.value = url;
	ClosePreviewScreen();
}