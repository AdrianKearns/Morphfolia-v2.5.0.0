/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */


// This has not been fully integrated as the File Listing - is still hung over 
// with some references to the thumbnails.

// Hooks the ThumbnailPanels client "ThumbnailImageClicked" event with 
// something else - such as the HTMLEditors "InsertImg" event. 
function FileListingClicked( sIFullmagePath, action )
{
	//alert( sIFullmagePath + ', ' + action );
	//InsertLinkToFile( sIFullmagePath, action );
	FormatActionMapper(action, sIFullmagePath);
}


