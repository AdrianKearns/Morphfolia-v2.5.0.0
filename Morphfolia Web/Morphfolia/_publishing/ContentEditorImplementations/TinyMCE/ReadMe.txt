Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details. 

The TinyMCE implementation hasn't been done yet, 
the files in this folder are a place holder only.

When complete, the following steps will apply:

To use TinyMCE as the active editor, replace the original/active copy of the 
"edit_content.aspx(.cs)" and "AddBlogPost.aspx(.cs)" files (located in 
the "Morphfolia/_publishing" folder) with the ones in the 
"Morphfolia/_publishing/ContentEditorImplementions/TinyMCE" folder.

Alternatively, open the edit_content and AddBlogPost .aspx files 
(in source view) and modify the UserControl registration to point to the 
appropriate Src; for example: 

To use ABKEditor: 
<%@ Register TagPrefix="uc1" TagName="EditContent" Src="~/Morphfolia/_publishing/ContentEditorImplementations/ABKEditor/EditContent.ascx" %>

To use WMD: 
<%@ Register TagPrefix="uc1" TagName="EditContent" Src="~/Morphfolia/_publishing/ContentEditorImplementations/WMD/EditContent.ascx" %>
