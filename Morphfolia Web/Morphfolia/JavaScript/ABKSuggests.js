/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

// Declare 'private' variables:
// JavaScript/ABKSuggests.js
var xhttp;
var objDoc;
var txtSearchCriteria, btnSearch;
var previewScreen;


function InitABKSuggests()
{
	// alert('InitABKSuggests');
	txtSearchCriteria = document.getElementById(txtSearchCriteriaId);
	btnSearch = document.getElementById(btnSearchId);
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



function DoAdriansSendRequest()
{		
    InitABKSuggests();
    //alert( txtSearchCriteria );
    
    
	if (window.XMLHttpRequest) 
	{ 
	    // Mozilla, Safari,...
		xhttp = new XMLHttpRequest();
		if (xhttp.overrideMimeType) 
		{
			xhttp.overrideMimeType('text/xml');
		}
	}
	else if (window.ActiveXObject) 
	{ 
		// IE
		try
		{
			xhttp = new ActiveXObject("Msxml2.XMLHTTP");
		}
		catch(e) 
		{
			try
			{
				xhttp = new ActiveXObject("Microsoft.XMLHTTP");
			}
			catch (e)
			{
			}
		}
	}
	
	
	xhttp.onreadystatechange = HandlerOnReadyStateChange;
   
    //alert( txtSearchCriteria );
    //alert( txtSearchCriteria.value );

	// prepare the call, http method=GET, false=asynchronous call
	// xhttp.open("GET", "http://localhost/Morphfolia.Web/asyncHandlers/SearchResultPreview.ashx?searchCriteria=" + txtSearchCriteria.value, false);
	xhttp.open("GET", "SearchResultPreview.ashx?searchCriteria=" + txtSearchCriteria.value, true);
	//xhttp.open("GET", sHttpContextCurrentRequestApplicationPath + "/SearchResultPreview.ashx?searchCriteria=t", true);

	
	// alert( sHttpContextCurrentRequestApplicationPath + "/SearchResultPreview.ashx?searchCriteria=t" );
	if( !callInProgress(xhttp) ) 
	{
		xhttp.send( null );
	}	 
}


function HandlerOnReadyStateChange()
{
	// alert('HandlerOnReadyStateChange');
	if (xhttp.readyState == 4)
	{
		previewScreen = document.getElementById('divSuggestResults');


		var xmldoc = xhttp.responseXML;
		var nodes = xmldoc.getElementsByTagName('MyWord');
		//alert(nodes.firstChild.data);


		//responseXML contains an XMLDOM object
		var s = "";
		//var nodes = xhttp.responseXML.selectNodes("//MyWord");
		
		if(nodes.length > 0)
		{
			previewScreen.style.visibility = 'visible';
			s = s + '<table width=100% cellpadding=1 cellspacing=0>\n';
			for (var i = 0; i < nodes.length; i++)
			{
				// IE:
				//s = s + '<tr onclick=\"setSearchCriteria(\'' + nodes[i].text + '\');\" class=\'\' onmouseover=\"this.className=\'activeSearchPreview\';" onmouseout=\"this.className=\'\';\"><td>' + nodes[i].text + '</td> ';

				// Mozilla (+ IE?): 
				s = s + '<tr onclick=\"setSearchCriteria(\'' + nodes[i].firstChild.data + '\');\" class=\'\' onmouseover=\"this.className=\'activeSearchPreview\';" onmouseout=\"this.className=\'\';\"><td width=100%>' + nodes[i].firstChild.data + '</td> ';				
				s = s + '<td align=right><nobr>' + nodes[i].getAttribute('TotalOccurances') + ' &nbsp; occurances in &nbsp; </nobr></td>\n';
				s = s + '<td align=right><nobr>' + nodes[i].getAttribute('DistinctPageCount') + ' &nbsp; pages</nobr></td></tr>\n';
			}
			s = s + '</table>\n';

			previewScreen.innerHTML = s;
		}
		else
		{
			previewScreen.style.visibility = 'hidden';
		}
	}
}


function checkSearchCriteria( txtInput_SearchCriteria )
{	
	InitABKSuggests();

	if(txtInput_SearchCriteria.value.length > 1)
	{	
		// window.status = txtInput_SearchCriteria.style.outerLeft;
	
		DoAdriansSendRequest();
	}
	else
	{
		previewScreen = document.getElementById('divSuggestResults');
		previewScreen.innerHTML = '';
		previewScreen.style.visibility = 'hidden';
	}

	// Abandoned for now.
	// Attempt to arrow down into the list of matches if the search input textbox has the focus:
	// alert( window.event.keyCode );  // 40 = arrow down
}


function setSearchCriteria( searchCriteria )
{
	// alert(searchCriteria);
	txtSearchCriteria.value = searchCriteria;
	btnSearch.click();
}