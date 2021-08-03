/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

// ResetSearchIndexHelper.js

var oInterval = "";

function StartResetSearchIndexHelperInterval()
{
	oInterval = window.setInterval("ScrollToBottom()", 300);
}


function CancelResetSearchIndexHelperInterval()
{
    if( oInterval )
    {
        window.clearInterval(oInterval);
    }
    
    ScrollToBottom();
}


function ScrollToBottom()
{
    //alert( window.document.body.children.length );
    
    //window.document.body.children[ window.document.body.children.length-1 ].scrollIntoView(true);
}




StartResetSearchIndexHelperInterval();
