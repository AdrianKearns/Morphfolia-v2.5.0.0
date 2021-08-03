// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Morphfolia.Common.Utilities;



public partial class Morphfolia__publishing_EventIds : System.Web.UI.Page
{
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    EventIdExtractor eventIdExtractor;
    private Table tblExtractedData;
    private TableCell td;
    private TableRow tr;


    protected void Page_Load(object sender, EventArgs e)
    {
        Header.Title = "Event Ids";

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("{0}{0}{0}<style type='text/css'>", Environment.NewLine);
        sb.AppendFormat("{0}.ExtractedData {1} border: solid 1px #000000; {2}", Environment.NewLine, "{", "}");
        sb.AppendFormat("{0}.assembly {1} background-color: #dfefff; {2}", Environment.NewLine, "{", "}");
        sb.AppendFormat("{0}.package {1} background-color: #d6e6f6; {2}", Environment.NewLine, "{", "}");
        sb.AppendFormat("{0}.type {1} font-weight: 700; {2}", Environment.NewLine, "{", "}");
        sb.AppendFormat("{0}.item {1} font-weight: 700; {2}", Environment.NewLine, "{", "}");
        sb.AppendFormat("{0}</style>{0}{0}{0}", Environment.NewLine);


        Literal style = new Literal();
        style.Text = sb.ToString();

        HtmlHead f = (HtmlHead)Page.Header;
        f.Controls.Add(style);


        tblExtractedData = new Table();
        pnlExtractedData.Controls.Add(tblExtractedData);
        tblExtractedData.CellPadding = 3;
        tblExtractedData.CellSpacing = 0;
        tblExtractedData.CssClass = "ExtractedData";

        pnlExtractedData.EnableViewState = false;
        tblExtractedData.EnableViewState = false;

        eventIdExtractor = new EventIdExtractor();
        eventIdExtractor.MiscInformationFound += new EventIdExtractor.OnMiscInformationFound(eventIdExtractor_MiscInformationFound);
        eventIdExtractor.AssemblyMatched += new EventIdExtractor.OnAssemblyMatched(eventIdExtractor_AssemblyMatched);
        eventIdExtractor.EventIdDefinitionClassFound += new EventIdExtractor.OnEventIdDefinitionClassFound(eventIdExtractor_EventIdDefinitionClassFound);
        eventIdExtractor.EventIdDefinitionFound += new EventIdExtractor.OnEventIdDefinitionFound(eventIdExtractor_EventIdDefinitionFound);
    }


    void eventIdExtractor_AssemblyMatched(string assemblyName)
    {
        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = assemblyName;
        td.ColumnSpan = 3;
        td.CssClass = "assembly";
    }

    void eventIdExtractor_EventIdDefinitionClassFound(string nameSpace, string className, string eventIdRange, string description)
    {
        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = string.Format("{0}.<span class='type'>{1}</span>", nameSpace, className);
        td.ColumnSpan = 3;
        td.CssClass = "package";


        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = description;
        td.ColumnSpan = 3;
        td.CssClass = "";


        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = "Event Id";
        td.ColumnSpan = 1;

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = "Constant";

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = "Description";
    }

    void eventIdExtractor_EventIdDefinitionFound(string fieldName, int eventId, string description)
    {
        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = eventId.ToString();
        td.ColumnSpan = 1;
        td.HorizontalAlign = HorizontalAlign.Right;
        td.CssClass = "item";

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = fieldName;

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = description;
    }

    void eventIdExtractor_MiscInformationFound(string key, string val)
    {
        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = key;
        td.ColumnSpan = 1;
        td.CssClass = "";

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = val;
        td.ColumnSpan = 2;
        td.CssClass = "";
    } 

    protected override void OnPreRender(EventArgs e)
    {
        lblTemp.Text = sb.ToString();

        base.OnPreRender(e);
    }

    protected void btnShowMorphOnly_Click(object sender, EventArgs e)
    {
        eventIdExtractor.ScanAssemblies("Morph");
    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        eventIdExtractor.ScanAssemblies();
    }
}
