// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Specialized;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Morphfolia.Common.Info;

namespace Morphfolia.WebControls.Charting
{
    public class Legend : WebControl, INamingContainer
    {
        private Table tblLegend;        
        private TableRow tr;
        private TableCell td;
        private Image imgLegendTile;


        private string colourRange = Constants.ColourRanges.Default;
        public string ColourRange
        {
            get { return colourRange; }
            set { colourRange = value; }
        }

        private StringCollection words = new StringCollection();
        public StringCollection Words
        {
            get { return words; }
            set { words = value; }
        }


        protected override void CreateChildControls()
        {
            tblLegend = new Table();
            Controls.Add(tblLegend);
            tblLegend.ID = "tblLegend";
            tblLegend.CellPadding = 5;
            tblLegend.CellSpacing = 0;
            //tblHttpSessionList.CssClass = "FunctionalArea";
            //tblHttpSessionList.Attributes.Add("border", "1");
            //tblLegend.Width = Unit.Percentage(100);

            //th = new TableHeaderRow();
            //tblHttpSessionList.Controls.Add(th);

            //thc = new TableHeaderCell();
            //th.Cells.Add(thc);
            //thc.Text = "Session Id";

            //thc = new TableHeaderCell();
            //th.Cells.Add(thc);
            //thc.Text = "Requests";
            //thc.ToolTip = "Number of requests in specified time-frame.";
        }




        private void Populate()
        {
            if (Words.Count == 0)
            {
                tr = new TableRow();
                tblLegend.Controls.Add(tr);
                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = "No data.";
            }
            else
            {
                for (int i = 0; i < Words.Count; i++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblLegend.Controls.Add(tr);
                    //tr.ID = string.Format("tr{0}", i.ToString());

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    //td.Text = Sessions[i].TotalPageRequests.ToString();
                    //td.ToolTip = "Total Page Requests made by this session.";
                    //td.HorizontalAlign = HorizontalAlign.Right;
                    td.Width = Unit.Pixel(20);

                    imgLegendTile = new Image();
                    Controls.Add(imgLegendTile);
                    td.Controls.Add(imgLegendTile);
                    imgLegendTile.ImageUrl = ChartingUtilities.MakeUrlToPieChartLegendTileProvider(16, i, ColourRange);

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = Words[i];
                    //td.ToolTip = "The time of the sessions most recent Url request.";
                    //td.HorizontalAlign = HorizontalAlign.Right;
                }
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                Populate();

                tblLegend.RenderControl(writer);
            }
        }


    }
}
