<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewLogs.aspx.cs" Inherits="_publishing_ViewLogs" Title="System Logs" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->


<%@ Register Assembly="Morphfolia.WebControls" Namespace="Morphfolia.WebControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="MainContentPlaceholder">
                
<cc1:SystemLogSearcher ID="LogListQueryTool1" runat="server" /><br />
<cc1:SystemLogViewer id=LogListViewer1 runat="server"></cc1:SystemLogViewer>        
    
 </asp:Content>       