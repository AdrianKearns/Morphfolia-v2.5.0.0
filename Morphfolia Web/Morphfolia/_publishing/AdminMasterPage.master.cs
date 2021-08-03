// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;

public partial class _publishing_AdminMasterPage : System.Web.UI.MasterPage
{
    private TableRow tr;
    private TableCell td;
    private HyperLink hyp;
    private Image img;

    protected void Page_Load(object sender, EventArgs e)
    {
        tblAdminMenu.EnableViewState = false;

        imgLogo.ImageUrl = string.Format("{0}/morphfolia/_publishing/ThisIsMorphfolia.gif", Morphfolia.WebControls.Utilities.WebUtilities.VirtualApplicationRoot());

        CreateNAppendChildControls_MainNode("Admin Home", "../_publishing/default.aspx", 3);
        CreateNAppendChildControls_SubNode("Add New Page", "../_publishing/edit_page.aspx");
        CreateNAppendChildControls_SubNode("Page Property Manager", "../_publishing/SiteWidePropertyManager.aspx");

        CreateNAppendChildControls_SpacerRow();

        CreateNAppendChildControls_MainNode("Manage Content", "../_publishing/content_management.aspx?ct=OpenMarkUp", 6);
        CreateNAppendChildControls_SubNode("Add New Content", "../_publishing/edit_content.aspx");
        CreateNAppendChildControls_SubNode("Add Blog Post", "../_publishing/AddBlogPost.aspx");
        CreateNAppendChildControls_SubNode("Manage Blog Posts", "../_publishing/content_management.aspx?ct=BlogPost");
        CreateNAppendChildControls_SubNode("Files", "../_publishing/FileManager.aspx");
        CreateNAppendChildControls_SubNode("Images", "../_publishing/ImageManager.aspx");

        CreateNAppendChildControls_SpacerRow();

        CreateNAppendChildControls_MainNode("User Manager", "../_publishing/user_management.aspx", 3);
        CreateNAppendChildControls_SubNode("Add New User", "../_publishing/createnewuser.aspx");
        CreateNAppendChildControls_SubNode("User Role Manager", "../_publishing/userrole_manager.aspx");

        CreateNAppendChildControls_SpacerRow();

        CreateNAppendChildControls_MainNode("Index Management", "../_publishing/ContentIndexOverview.aspx", 4);
        CreateNAppendChildControls_SubNode("View Indexes", "../_publishing/contentIndexes.aspx");
        CreateNAppendChildControls_SubNode("Reset Indexes", "../_publishing/searchIndex_management.aspx");
        CreateNAppendChildControls_SubNode("Manage Unwanted Words", "../_publishing/unwantedWords_management.aspx");

        CreateNAppendChildControls_SpacerRow();

        CreateNAppendChildControls_MainNode("Traffic Reporter", "../_publishing/TrafficReporter.aspx", 5);
        CreateNAppendChildControls_SubNode("Session History", "../_publishing/SessionHistory.aspx");
        CreateNAppendChildControls_SubNode("Site Dashboard", "../_publishing/SiteTrafficDashboard.aspx");
        CreateNAppendChildControls_SubNode("Page Dashboard", "../_publishing/PageTrafficDashboard.aspx");
        CreateNAppendChildControls_SubNode("Http Logs", "../_publishing/ViewHttpLogs.aspx");

        CreateNAppendChildControls_SpacerRow();

        CreateNAppendChildControls_MainNode("Diagnostics", "../_publishing/Diagnostics/systemhealth.aspx", 7);
        CreateNAppendChildControls_SubNode("System Logs", "../_publishing/Diagnostics/viewlogs.aspx");
        CreateNAppendChildControls_SubNode("Audit Logs", "../_publishing/Diagnostics/ViewAuditLogs.aspx");
        CreateNAppendChildControls_SubNode("Event Ids", "../_publishing/Diagnostics/EventIds.aspx");
        CreateNAppendChildControls_SubNode("AppSettings", "../_publishing/Diagnostics/AppSettingKeys.aspx");
        CreateNAppendChildControls_SubNode("HttpHandlers", "../_publishing/Diagnostics/HttpHandlerDirectory.aspx");
        CreateNAppendChildControls_SubNode("Data Info", "../_publishing/Diagnostics/DataProviderInformation.aspx");

        CreateNAppendChildControls_SpacerRow();
    }


    private void CreateNAppendChildControls_SpacerRow()
    {
        CreateNAppendChildControls_SpacerRow("&nbsp;");
    }

    private void CreateNAppendChildControls_SpacerRow(string content)
    {
        tr = new TableRow();
        Controls.Add(tr);
        tblAdminMenu.Rows.Add(tr);

        td = new TableCell();
        Controls.Add(td);
        tr.Cells.Add(td);
        td.ColumnSpan = 3;
        td.Text = content;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rows">The number of rows: the main-node plus the intended number of sub-nodes.</param>
    /// <param name="linkText"></param>
    /// <param name="linkUrl"></param>
    private void CreateNAppendChildControls_MainNode(string mainNodeLinkText, string mainNodeLinkUrl, int rows)
    {
        // <tr><td valign=top rowspan=2><img src="../g/spacer.gif" class="iconMainNode" width="16" height="16" /></td><td colspan=2><a href='../_publishing/default.aspx'><STRONG>Admin Home</STRONG></a></td></tr>
        // <tr><td><img src="../g/spacer.gif" class="iconSubNode" width="12" height="12" /></td><td><a href='../_publishing/edit_page.aspx'>Add New Page</a></td></tr>

        tr = new TableRow();
        Controls.Add(tr);
        tblAdminMenu.Rows.Add(tr);

        td = new TableCell();
        Controls.Add(td);
        tr.Cells.Add(td);
        td.RowSpan = rows;
        td.VerticalAlign = VerticalAlign.Top;

        img = new Image();
        Controls.Add(img);
        td.Controls.Add(img);
        img.ImageUrl = "../g/spacer.gif";
        img.CssClass = "iconMainNode";
        img.Width = Unit.Pixel(16);
        img.Height = Unit.Pixel(16);

        td = new TableCell();
        Controls.Add(td);
        tr.Cells.Add(td);
        td.ColumnSpan = 2;
        td.VerticalAlign = VerticalAlign.Top;

        hyp = new HyperLink();
        Controls.Add(hyp);
        td.Controls.Add(hyp);
        hyp.Text = mainNodeLinkText;
        hyp.NavigateUrl = mainNodeLinkUrl;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rows">The number of row: the main-node plus the intended number of sub-nodes.</param>
    /// <param name="linkText"></param>
    /// <param name="linkUrl"></param>
    private void CreateNAppendChildControls_SubNode(string subNodeLinkText, string subNodeLinkUrl)
    {
        // <tr><td valign=top rowspan=2><img src="../g/spacer.gif" class="iconMainNode" width="16" height="16" /></td><td colspan=2><a href='../_publishing/default.aspx'><STRONG>Admin Home</STRONG></a></td></tr>
        // <tr><td><img src="../g/spacer.gif" class="iconSubNode" width="12" height="12" /></td><td><a href='../_publishing/edit_page.aspx'>Add New Page</a></td></tr>

        tr = new TableRow();
        Controls.Add(tr);
        tblAdminMenu.Rows.Add(tr);

        td = new TableCell();
        Controls.Add(td);
        tr.Cells.Add(td);
        td.VerticalAlign = VerticalAlign.Top;

        img = new Image();
        Controls.Add(img);
        td.Controls.Add(img);
        img.ImageUrl = "../g/spacer.gif";
        img.CssClass = "iconSubNode";
        img.Width = Unit.Pixel(12);
        img.Height = Unit.Pixel(12);

        td = new TableCell();
        Controls.Add(td);
        tr.Cells.Add(td);
        td.VerticalAlign = VerticalAlign.Top;
        td.Width = Unit.Pixel(250);

        hyp = new HyperLink();
        Controls.Add(hyp);
        td.Controls.Add(hyp);
        hyp.Text = subNodeLinkText;
        hyp.NavigateUrl = subNodeLinkUrl;
    }


}
