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



// Hooks the ThumbnailPanels client "ThumbnailImageClicked" event with 
// something else - such as the HTMLEditors "InsertImg" event. 
function ThumbnailImageClicked( sIFullmagePath, action )
{
	//alert( sIFullmagePath );
	InsertImg( sIFullmagePath, action );
}


