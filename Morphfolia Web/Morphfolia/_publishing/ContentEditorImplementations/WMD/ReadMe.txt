Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details. 

The version of WMD used and "supported" in this release is WMD version 1.0.1
At the time of release WMD is being offered "freely", and will be released 
under an MIT licence; as such I have included the WMD files directly in this 
release (also because the entire WMD source is only 31Kb in size).  I'm not 
sure if this will continue, and I'm not intending to take exactly the same 
approach with the likes of TinyMCE (as TinyMCE is just over the size of 
Morphfolia).

http://wmd-editor.com/download
http://code.google.com/p/wmd/

To use WMD as the active editor, replace the original/active copy of the 
"edit_content.aspx(.cs)" and "AddBlogPost.aspx(.cs)" files (located in 
the "Morphfolia/_publishing" folder) with the ones in the 
"Morphfolia/_publishing/ContentEditorImplementions/WMD" folder.

Alternatively, open the edit_content and AddBlogPost .aspx files 
(in source view) and modify the UserControl registration to point to the 
appropriate Src; for example: 

To use ABKEditor: 
<%@ Register TagPrefix="uc1" TagName="EditContent" Src="~/Morphfolia/_publishing/ContentEditorImplementations/ABKEditor/EditContent.ascx" %>

To use WMD: 
<%@ Register TagPrefix="uc1" TagName="EditContent" Src="~/Morphfolia/_publishing/ContentEditorImplementations/WMD/EditContent.ascx" %>
