/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.   */

// EditContent.js

function indexContent()
{
    var tdContentId = document.getElementById('tdContentId');

    var indexProgressWindowContainer = document.getElementById('indexProgressWindowContainer');
    indexProgressWindowContainer.style.display = 'block';
    var indexProgressWindow = document.getElementById('indexProgressWindow');
    
    // we are basically praying  this will be the id.  naughty.
    indexProgressWindow.src = "resetsearchindex.aspx?IndexAction=indexcontent&id=" + tdContentId.innerText;
}