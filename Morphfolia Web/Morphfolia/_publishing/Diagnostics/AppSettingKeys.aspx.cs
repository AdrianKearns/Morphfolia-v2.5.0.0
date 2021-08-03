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

public partial class Morphfolia__publishing_Diagnostics_AppSettingKeys : System.Web.UI.Page
{
    private System.Text.StringBuilder sb = new System.Text.StringBuilder();
    private AppSettingKeyExtractor appSettingKeyExtractor;
    private Table tblExtractedData;
    private TableCell td;
    private TableRow tr;

    protected void Page_Load(object sender, EventArgs e)
    {
        Header.Title = "AppSetting Keys";

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


        appSettingKeyExtractor = new AppSettingKeyExtractor();
        appSettingKeyExtractor.MiscInformationFound += new AppSettingKeyExtractor.OnMiscInformationFound(appSettingKeyExtractor_MiscInformationFound);
        appSettingKeyExtractor.AssemblyMatched += new AppSettingKeyExtractor.OnAssemblyMatched(appSettingKeyExtractor_AssemblyMatched);
        appSettingKeyExtractor.AppSettingKeyDefinitionClassFound += new AppSettingKeyExtractor.OnAppSettingKeyDefinitionClassFound(appSettingKeyExtractor_AppSettingKeyDefinitionClassFound);
        appSettingKeyExtractor.AppSettingKeyDefinitionFound += new AppSettingKeyExtractor.OnAppSettingKeyDefinitionFound(appSettingKeyExtractor_AppSettingKeyDefinitionFound);
    }



    void appSettingKeyExtractor_AssemblyMatched(string assemblyName)
    {
        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = assemblyName;
        td.ColumnSpan = 4;
        td.CssClass = "assembly";
    }

    void appSettingKeyExtractor_AppSettingKeyDefinitionClassFound(string nameSpace, string className, string description)
    {
        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = string.Format("{0}.<span class='type'>{1}</span>", nameSpace, className);
        td.ColumnSpan = 4;
        td.CssClass = "package";


        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = description;
        td.ColumnSpan = 4;
        td.CssClass = "";


        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = "AppSetting Key";
        td.ColumnSpan = 1;        

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = "Constant";

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = "Description";

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = "Typical Usage";  
    }


    void appSettingKeyExtractor_AppSettingKeyDefinitionFound(string fieldName, string key, string description, string usage)
    {
        tr = new TableRow();
        tblExtractedData.Rows.Add(tr);

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = key;
        td.ColumnSpan = 1;
        td.CssClass = "item";

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = fieldName;

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = description;

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = usage;  
    }



    void appSettingKeyExtractor_MiscInformationFound(string key, string val)
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
        td.ColumnSpan = 3;
        td.CssClass = "";
    }

    protected override void OnPreRender(EventArgs e)
    {
        lblTemp.Text = sb.ToString();

        base.OnPreRender(e);
    }

    protected void btnShowMorphOnly_Click(object sender, EventArgs e)
    {
        appSettingKeyExtractor.ScanAssemblies("Morph");
    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        appSettingKeyExtractor.ScanAssemblies();
    }
}
