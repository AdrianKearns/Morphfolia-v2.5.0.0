/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

if(document.execCommand)
{
    //document.execCommand("LiveResize", false, true);
}    


var userSelection, selectedText, rangeObject;

function BuildRange()
{
	// Need to dynamically get editor div - here it is hard coded:
	//abkEditor_divWysiwygCanvas.setActive();

    // Attribution: many thanks to Quirks Mode
    // http://www.quirksmode.org/dom/range_intro.html
    //var userSelection;
    if (window.getSelection) {
        // selection object
	    userSelection = window.getSelection();
	    newRangeObject = getRangeObject(userSelection);
	    //alert('16 ' + newRangeObject);
    }
    else if (document.selection) { // should come last; Opera!
        // a TextRange object
	    userSelection = document.selection;
	    newRangeObject = document.selection.createRange();
	    //alert('21 ' + newRangeObject);
    }

    return newRangeObject;
}


// Used by IE only?
function BuildTextSelection()
{   
	// Need to dynamically get editor div - here it is hard coded:
	abkEditor_divWysiwygCanvas.setActive();

	oTextRange = document.selection.createRange();
	if(oTextRange)
	{	
		oTextRange.select();	
	}
	
	//alert(oTextRange.text);
	//alert(oTextRange.htmlText);
}



function getRangeObject(selectionObject)
{
    if (selectionObject.getRangeAt)
    {
	    return selectionObject.getRangeAt(0);
	}
    
    if(document.createRange)
    { // Safari!
        var range = document.createRange();
        range.setStart(selectionObject.anchorNode,selectionObject.anchorOffset);
        range.setEnd(selectionObject.focusNode,selectionObject.focusOffset);
        return range;
    }   
}


//--------------------------------------------------------------
// execCommand(), FormatActionMapper() & PerformAction_IE()
//--------------------------------------------------------------
//
// FormatActionMapper() routes calls to the correct code.
// 
// PerformAction_IE() is my method for executing IE targetted code.
// PerformAction_NotIE() is for everything else.
// 
// execCommand() is a Microsoft/IE method which Executes a command on 
// the current document, current selection, or the given range. 
// 
// For consistency I have kept the variable names the same, but dropped 
// bUserInterface, it's IE only, so if you want to use it you'll need to 
// call PerformAction_IE directly. 
//
// execCommand...
// http://msdn.microsoft.com/en-us/library/ms536419(VS.85).aspx
// Syntax:                  bSuccess = object.execCommand(sCommand [, bUserInterface] [, vValue])
//
//sCommand Required.        String that specifies the command to execute. This command can be 
// any of the command identifiers that can be executed in script. 
//bUserInterface Optional.  Boolean that specifies one of the following values. 
//      false Default. Do not display a user interface. Must be combined with vValue , if the command requires a value. 
//      true Display a user interface if the command supports one. 
//
//vValue Optional.          Variant that specifies the string, number, or other value to assign. 
// Possible values depend on the command. 

function FormatActionMapper(action)
{
    FormatActionMapper(action, "");
}

function FormatActionMapper(sCommand, vValue)
{
    //alert('FormatActionMapper, sCommand: [' + sCommand + ']\nvValue: [' + vValue +']');

    var isIe = false;
    
    var newrange = BuildRange();
    if(newrange.execCommand)
    {
        isIe = true;
    }
    
    if(isIe == true)
    {
        PerformAction_IE(sCommand, undefined, vValue);
    }
    else
    {
        PerformAction_NotIE(sCommand, vValue);
    }
}    

function FormatActionMapper(sCommand, vValue, bUserInterface)
{
    //alert('FormatActionMapper, sCommand: [' + sCommand + ']\nvValue: [' + vValue +']\nbUserInterface: [' + bUserInterface + ']');

    var isIe = false;
    
    var newrange = BuildRange();
    if(newrange.execCommand)
    {
        isIe = true;
    }
    
    if(isIe == true)
    {
        PerformAction_IE(sCommand, vValue, bUserInterface);
    }
    else
    {
        PerformAction_NotIE(sCommand, vValue);
    }
}  


function PerformAction_IE(sCommand, vValue, bUserInterface)
{	
    //alert('PerformAction_IE, sCommand: [' + sCommand + ']\nvValue: [' + vValue +']\nbUserInterface: [' + bUserInterface + ']');

	if(!bUserInterface)
	{
		bUserInterface = false;
	}
	
	if(!vValue)
	{
		vValue = "";
	}

	BuildTextSelection();
	
    //alert(oTextRange.text);    
	//alert(oTextRange.htmlText);
		
	switch( sCommand )
	{
//		case "Bold":
//			FormatBlockElement('b');
//			break;
			
		case "InsertHorizontalRule":
			oTextRange.pasteHTML("<hr>");
			break;
		
		case "insertOriginalImage":
		    oTextRange.pasteHTML("<img src='" + vValue + "'>")
			break;
		
		case "insertThumbnailAsLinkToOriginalImage":
			// s = path to thumbnail image.
			// original = path to original image.
			//alert(vValue);
			var original = vValue.replace('/Thumbnails/', '/Images/');
			//alert(original);
			oTextRange.pasteHTML("<a href='" + original + "' target='_blank'><img src='" + vValue + "' border='0'></a>")
			break;
		
		case "insertLinkToFile":
			// s = path to thumbnail image.
			// original = path to original image.
			//alert(vValue);
			var fileName = vValue.substr( vValue.lastIndexOf('/')+1 );
			//alert(original);
			oTextRange.pasteHTML("<a href='" + vValue + "' target='_blank'>" + fileName + "</a>")
			break;
			
		default:
		    var newrange = BuildRange();
			newrange.execCommand(sCommand, bUserInterface, vValue);
			break;		
	}
	
	//alert(oTextRange.text);
	//alert(oTextRange.htmlText);
}



function PerformAction_NotIE(sCommand, vValue)
{
    //alert('PerformAction_NotIE, sCommand: [' + sCommand + ']\nvValue: [' + vValue + ']');

	if(!vValue)
	{
		vValue = "";
	}
	
    switch(sCommand)
    {
        case 'Bold':
        FormatBlockElement('font-weight: 700;');   
        break;  
        
        case 'Italic':
        FormatBlockElement('font-style: italic;');   
        break;  

        case 'Underline':
        FormatBlockElement('text-decoration: underline;');   
        break;  

        case 'Indent':
        FormatBlockElement('padding-left: 20px;');   
        break; 
        
        case 'Outdent':
        FormatBlockElement('padding-left: -20px;');   
        break; 
        
        //Underline Italic Indent Outdent JustifyLeft JustifyCenter JustifyRight InsertOrderedList InsertUnorderedList
        
        case 'insertOriginalImage':
        InsertImg(sCommand, vValue);
        break;
        
        case 'insertThumbnailAsLinkToOriginalImage':
        InsertImg(sCommand, vValue);
        break;
        
        case 'insertLinkToFile':
        //InsertLinkToFile();
        InsertLinkToFile('insertLinkToFile', vValue);
        break;        
        
        case 'CreateLink':
        //InsertLinkToFile();
        InsertLinkToFile('CreateLink', vValue);
        break;     
        
        default:
        alert('the action \'' + sCommand + '\' is not handled.');
        break;
    }                 
}









function InsertLinkToFile( action, sOriginalFileSrc )
{
    //alert('InsertLinkToFile\naction=' + action + '\nsOriginalFileSrc=' + sOriginalFileSrc);
    
    var newrange = BuildRange();
    //var sModifiedImageSrc = '';

    var newrange = BuildRange();

    var linkToFile, preTextObj, newTxtObjA, newTxtObjB, endTxtObj;
    var startParentObj, endParentObj;
    var seltext, oldText, preText, newTextA, newTextB, endText;
    var startElement = newrange.startContainer;
    var endElement = newrange.endContainer;
        
    seltext = userSelection;
    newTxtObjA = document.createTextNode(seltext);
    
    //alert(startElement);
    //alert(endElement);
    //alert(startElement.nodeValue);
    //alert(endElement.nodeValue);
    //alert(newrange.collapsed);
    //alert(newrange.startOffset);
    //alert(newrange.endOffset);
    
    var s = '';
    s += '\nsOriginalFileSrc:' + sOriginalFileSrc;
    //s += '\nssModifiedImageSrc:' + sModifiedImageSrc;
    s += '\naction:' + action;
    s += '\ncollapsed:' + newrange.collapsed;
    s += '\nstartOffset:' + newrange.startOffset;
    s += '\nendOffset:' + newrange.endOffset;
    //alert(s);
    
    
    preText = "";    
    if(startElement != null)
    {
        if(startElement.nodeValue != null)
        {
            preText = startElement.nodeValue;
            preText = preText.slice(0, newrange.startOffset);
        }
    }
    preTextObj = document.createTextNode(preText);
    //alert('389, preText: ' + preText);
    
    
    
    endText = "";
    if(startElement != null)
    {
        if(startElement.nodeValue != null)
        {
            endText = startElement.nodeValue;
            endText = endText.slice(newrange.endOffset, endElement.nodeValue.length);
        }
    }
    endTxtObj = document.createTextNode(endText);

    linkToFile = document.createElement("a");
    linkToFile.href = sOriginalFileSrc;
    
    
    if(action == 'insertLinkToFile')
    {
        var temp = sOriginalFileSrc;
        temp = temp.substr(sOriginalFileSrc.lastIndexOf("/") + 1);
        var fileName = document.createTextNode(temp);
        linkToFile.appendChild(fileName);
    }
    else
    {
        linkToFile.appendChild(newTxtObjA);
    }


    if(startElement)
    {
        startElement.nodeValue = '';
        startElement.parentNode.insertBefore(preTextObj, startElement);
        
        if( action == 'insertThumbnailAsLinkToOriginalImage' )
	    {
            startElement.parentNode.insertBefore(linkToFile, startElement);
        }
        else
        {
            startElement.parentNode.insertBefore(linkToFile, startElement);
        }
        
        startElement.parentNode.insertBefore(endTxtObj, startElement);
        startElement.normalize();  // don't know if this is really useful or not.
    }
                
    return false;
}












function FormatBlockElement(style)
{
    //alert('FormatBlockElement: ' + style);

    var newrange = BuildRange();
        
    if(newrange.insertNode)
    {
        var bold, preTextObj, newTxtObjA, newTxtObjB, endTxtObj;
        var startParentObj, endParentObj;
        var seltext, oldText, preText, newTextA, newTextB, endText;
        var startElement = newrange.startContainer;
        var endElement = newrange.endContainer;
        
        if(startElement==endElement)
        {
            seltext = userSelection;
            newTxtObjA = document.createTextNode(seltext);
                
            preText = startElement.nodeValue;
            preText = preText.slice(0, newrange.startOffset);
            preTextObj = document.createTextNode(preText);
            
            endText = startElement.nodeValue;
            endText = endText.slice(newrange.endOffset, endElement.nodeValue.length);
            endTxtObj = document.createTextNode(endText);
            
            bold = document.createElement("span");
            bold.setAttribute("style", style);
            bold.appendChild(newTxtObjA);

            //alert(preText + '/' + newTextA + '/' + endText);
            
            startElement.nodeValue = '';
            startElement.parentNode.insertBefore(preTextObj, startElement);
            startElement.parentNode.insertBefore(bold, startElement);
            startElement.parentNode.insertBefore(endTxtObj, startElement);
            startElement.normalize();  // don't know if this is really useful or not.
        }
        else
        {           
            alert(startElement + ', ' + endElement);
                
            preText = startElement.nodeValue;
            preText = preText.slice(0, newrange.startOffset);
            preTextObj = document.createTextNode(preText);
                                                                       
            if(endElement.nodeValue)
            {
                endText = endElement.nodeValue;
                endText = endText.slice(newrange.endOffset, endElement.nodeValue.length);
                endTxtObj = document.createTextNode(endText);
                newTextB = endElement.nodeValue.slice(0, newrange.endOffset);
            }
            else
            {
                newTextB = '';
            }

            //alert(preText + ',' + endText);

            newTextA = startElement.nodeValue.slice(newrange.startOffset, startElement.nodeValue.length);
            //newTextB = endElement.nodeValue.slice(0, newrange.endOffset);

            //alert(newTextA + ',' + newTextB);

            bold = document.createElement("span");
            bold.setAttribute("style", style);
            newTxtObjA = document.createTextNode(newTextA);
            bold.appendChild(newTxtObjA);
            
            startElement.nodeValue = '';
            startElement.parentNode.insertBefore(preTextObj, startElement);
            startElement.parentNode.insertBefore(bold, startElement);
            startElement.normalize();  // don't know if this is really useful or not.

            
            bold = document.createElement("span");
            bold.setAttribute("style", style);
            newTxtObjB = document.createTextNode(newTextB);
            bold.appendChild(newTxtObjB);
                        
            //endElement.nodeValue = '';
            //endElement.parentNode.insertBefore(bold, endElement);
            //endElement.parentNode.insertBefore(endTxtObj, endElement);

            endElement.normalize();  // don't know if this is really useful or not.        
        }  
    }   
}


function PopulateHtmlView()
{
	abkEditor_txtHtmlView.value = abkEditor_divWysiwygCanvas.innerHTML;
	abkEditor_txtTextView.value = abkEditor_divWysiwygCanvas.innerText;
}

function PopulateWysiwygCanvas()
{
	 abkEditor_divWysiwygCanvas.innerHTML = abkEditor_txtHtmlView.value;
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



function InsertInlineElement(imgSrc)
{
    alert('InsertInlineElement');
}


function InsertImg( action, sOriginalImageSrc )
{
    //alert('InsertImg\naction=' + action + '\nsOriginalImageSrc=' + sOriginalImageSrc);
    
    var newrange = BuildRange();
    var sModifiedImageSrc = '';

	if( action == 'insertThumbnailAsLinkToOriginalImage' )
	{
	    sModifiedImageSrc = sOriginalImageSrc.replace('/Thumbnails/', '/Images/');
	}

    var newrange = BuildRange();

    var imgElement, linkToFullPicture, preTextObj, newTxtObjA, newTxtObjB, endTxtObj;
    var startParentObj, endParentObj;
    var seltext, oldText, preText, newTextA, newTextB, endText;
    var startElement = newrange.startContainer;
    var endElement = newrange.endContainer;
        
    seltext = userSelection;
    newTxtObjA = document.createTextNode(seltext);
    
    //alert(startElement);
    //alert(endElement);
    //alert(startElement.nodeValue);
    //alert(endElement.nodeValue);
    //alert(newrange.collapsed);
    //alert(newrange.startOffset);
    //alert(newrange.endOffset);
    
    var s = '';
    s += '\nsOriginalImageSrc:' + sOriginalImageSrc;
    s += '\nssModifiedImageSrc:' + sModifiedImageSrc;
    s += '\naction:' + action;
    s += '\ncollapsed:' + newrange.collapsed;
    s += '\nstartOffset:' + newrange.startOffset;
    s += '\nendOffset:' + newrange.endOffset;
    //alert(s);
    
    
    preText = "";    
    if(startElement != null)
    {
        if(startElement.nodeValue != null)
        {
            preText = startElement.nodeValue;
            preText = preText.slice(0, newrange.startOffset);
        }
    }
    preTextObj = document.createTextNode(preText);
    //alert('389, preText: ' + preText);
    
    
    
    endText = "";
    if(startElement != null)
    {
        if(startElement.nodeValue != null)
        {
            endText = startElement.nodeValue;
            endText = endText.slice(newrange.endOffset, endElement.nodeValue.length);
        }
    }
    endTxtObj = document.createTextNode(endText);
    //alert('401, endText: ' + endText);



    imgElement = document.createElement("img");

	if( action == 'insertThumbnailAsLinkToOriginalImage' )
	{
	    //alert('insertThumbnailAsLinkToOriginalImage');	
        imgElement.src = sOriginalImageSrc;	
      
        linkToFullPicture = document.createElement("a");
        linkToFullPicture.href = sModifiedImageSrc;
        linkToFullPicture.appendChild(imgElement);        
  	}
	else
	{
	    //insertThumbnailAsLinkToOriginalImage
	    //prompt(action, action);	
        imgElement.src = sOriginalImageSrc;	
	}


    if(startElement)
    {
        startElement.nodeValue = '';
        startElement.parentNode.insertBefore(preTextObj, startElement);
        
        if( action == 'insertThumbnailAsLinkToOriginalImage' )
	    {
            startElement.parentNode.insertBefore(linkToFullPicture, startElement);
        }
        else
        {
            startElement.parentNode.insertBefore(imgElement, startElement);
        }
        
        startElement.parentNode.insertBefore(endTxtObj, startElement);
        startElement.normalize();  // don't know if this is really useful or not.
    }
//    else
//    {
//        alert('startElement is null ?');
//    }
    
    //alert('440');
    
    
    if(newrange.collapsed == undefined)
    {
    //sOriginalImageSrc
    //sModifiedImageSrc
        // IE (sigh)
        newrange.pasteHTML("<img src='" + sOriginalImageSrc + "'>");        
    }
    
    
    //alert('finishing now...');
                
    return false;
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