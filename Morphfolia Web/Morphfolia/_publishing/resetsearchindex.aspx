<%@ Page language="c#" Inherits="Morphfolia.Web._publishing.ResetSearchIndex" CodeFile="ResetSearchIndex.aspx.cs" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


	
    <!--  ------------------------------------------------------------
    IMPORTANT!
    
    Ignore errors in VS IDE.
    The page header is added during runtime.
    -------------------------------------------------------------  -->
	
    <form id="Form1" method="post" runat="server">    
    
    <h4>Reset Search Indexes</h4>
    
    <p>
        <asp:label runat="server" text="" id="lblIntendedAction"></asp:label><br />    
        <asp:checkbox runat="server" Text="Remove unwanted words during reset." ID="chkbxRemoveUnWantedWords" Checked="True"></asp:checkbox><br />
        <asp:Button id=btnStartIndexing runat="server" Text="Reset Search Index" onclick="btnStartIndexing_Click"></asp:Button>
    </p>
    
    <asp:Literal id=Literal1 runat="server" EnableViewState="False"></asp:Literal>
    
    </form>