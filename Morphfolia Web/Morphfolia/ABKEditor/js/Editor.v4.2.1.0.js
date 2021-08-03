/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

/* Copyright (C) 2009 Adrian Kearns / Morphological Software Solutions Limited; www.morphological.geek.nz
You can redistribute this software and/or modify it under the terms of the Microsoft Reciprocal License 
(Ms-RL).  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */



document.execCommand("LiveResize", false, true);


function PopulateHtmlView()
{
	abkEditor_txtHtmlView.value = abkEditor_divWysiwygCanvas.innerHTML;
	abkEditor_txtTextView.value = abkEditor_divWysiwygCanvas.innerText;
}

function PopulateWysiwygCanvas()
{
	 abkEditor_divWysiwygCanvas.innerHTML = abkEditor_txtHtmlView.value;
}


function StringReplacementFunction_23(str)
{
	return str.replace(/^\s{1,}/ig, "").replace(/\s{1,}$/ig, "");
}


var abkEditorWysiwygViewID = '';
var abkEditorHtmlViewTabID = '';
//var abkEditorTextViewID = '';


var abkEditor_trHtmlViewToolbar;
var abkEditor_trHtmlView;
var abkEditor_trWysiwygToolbar;
var abkEditor_trWysiwygView;

var abkEditor_txtHtmlView;
var abkEditor_txtTextView;
var abkEditor_divWysiwygCanvas;


function InitializeABKHtmlEditor( sObjectId )
{
	//alert('InitializeABKHtmlEditor: ' + sObjectId);
	
	//						                   EditContent1_abkEditor_ContentEditorControl_trWysiwygToolbar
	abkEditor_trHtmlViewToolbar = document.getElementById( 'abkEditor_' + sObjectId + '_trHtmlViewToolbar' );
	abkEditor_trHtmlView = document.getElementById( 'abkEditor_' + sObjectId + '_trHtmlView' );
	abkEditor_trWysiwygToolbar = document.getElementById( 'abkEditor_' + sObjectId + '_trWysiwygToolbar' );
	abkEditor_trWysiwygView = document.getElementById( 'abkEditor_' + sObjectId + '_trWysiwygView' );
	
	abkEditor_txtHtmlView = document.getElementById( 'abkEditor_' + sObjectId + '_HtmlData' );
	abkEditor_txtTextView = document.getElementById( 'abkEditor_' + sObjectId + '_TextData' );
	abkEditor_divWysiwygCanvas = document.getElementById( 'abkEditor_' + sObjectId + '_divWysiwygCanvas' );
	
	SwitchToView('wysiwyg');
}



function SwitchToView( view )
{
	//alert( view );

	if( view == 'html' )
	{
		abkEditor_trHtmlViewToolbar.style.display = 'inline';
		abkEditor_trHtmlView.style.display = 'inline';
		PopulateHtmlView();
		abkEditor_trWysiwygToolbar.style.display = 'none';
		abkEditor_trWysiwygView.style.display = 'none';
	}else{
		abkEditor_trWysiwygToolbar.style.display = 'inline';
		abkEditor_trWysiwygView.style.display = 'inline';
		PopulateWysiwygCanvas();
		abkEditor_trHtmlViewToolbar.style.display = 'none';
		abkEditor_trHtmlView.style.display = 'none';
	}
}



function BuildTextSelection()
{
	// Need to dynamically get editor div - here it is hard coded:
	abkEditor_divWysiwygCanvas.setActive();

	oTextRange = document.selection.createRange();
	if(oTextRange)
	{
		//oTextRange.select();
		//oTextRange.moveEnd("character", 1);
		//oTextRange.moveStart("character", 1);
		//oTextRange.collapse(false);	
	
		oTextRange.select();	
	}
	
	//alert(oTextRange.text);
	//alert(oTextRange.htmlText);
}


function PerformAction(sExecCommand, b, s)
{	
    //alert('PerformAction');

	if(!b)
	{
		b = false;
	}
	
	if(!s)
	{
		s = "";
	}


	BuildTextSelection();
	
	
	switch( sExecCommand )
	{
		case "InsertHorizontalRule":
			InsertHR();
			break;
		
		case "InsertImg":
		    oTextRange.pasteHTML("<img src='" + s + "'>")
			break;
		
		case "thumbnailAsLinkToOriginalImage":
			// s = path to thumbnail image.
			// original = path to original image.
			//alert(s);
			var original = s.replace('/Thumbnails/', '/Images/');
			//alert(original);
			oTextRange.pasteHTML("<a href='" + original + "' target='_blank'><img src='" + s + "' border='0'></a>")
			break;
		
		case "insertLinkToFile":
			// s = path to thumbnail image.
			// original = path to original image.
			//alert(s);
			var fileName = s.substr( s.lastIndexOf('/')+1 );
			//alert(original);
			oTextRange.pasteHTML("<a href='" + s + "' target='_blank'>" + fileName + "</a>")
			break;
			
		default:
			oTextRange.execCommand(sExecCommand, b, s);
			break;
		
	}
	
	//alert(oTextRange.text);
	//alert(oTextRange.htmlText);
}


function InsertHR()
{
	oTextRange.pasteHTML("<hr>");
}

function InsertImg( sFullImgSrc, action )
{
	if( action == 'thumbnailAsLinkToOriginalImage' )
	{
		PerformAction(action, false, sFullImgSrc);		
	}
	else
	{
		PerformAction('InsertImg', false, sFullImgSrc);
	}


	//PerformAction('InsertImg', false, sFullImgSrc);
    //oTextRange.pasteHTML("<img src='" + sFullImgSrc + "'>")
}


function InsertLinkToFile( sFullFileSrc, action )
{
	if( action == 'insertLinkToFile' )
	{
		PerformAction(action, false, sFullFileSrc);		
	}
	else
	{
		PerformAction('CreateLink', false, sFullFileSrc);
	}


	//PerformAction('InsertImg', false, sFullImgSrc);
    //oTextRange.pasteHTML("<img src='" + sFullImgSrc + "'>")
}

function handleOnBlur( oDiv )
{
	PopulateHtmlView();

	/*
	if( abkHtmlEditor_EditableArea )
	{
		//alert( oDiv.innerHTML );
		if(objHiddenHTMLData)
		{
			objHiddenHTMLData.value = abkHtmlEditor_EditableArea.innerHTML;		
		}
	}
	*/
}
  


