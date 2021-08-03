// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Common.Info;

namespace Morphfolia.WebControls
{
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class ContentIndexSummary : WebControl, INamingContainer
    {
        Table tblContentIndexSummary;
        TableRow tr;
        TableCell td;
        TableCell tdHeading;
        Image imgLegendTile;

        TableCell tdCommonWordsPieChart;
        Image imgCommonWordsPieChart;
        TableCell tdCommonWordsBlurb;
        Table tblCommonWords;

        TableCell tdCommonWordsInPerspectivePieChart;
        Image imgCommonWordsInPerspectivePieChart;
        TableCell tdCommonWordsInPerspectiveBlurb;
        Table tblCommonWordsInPerspective;


        private ContentIndexOverview contentIndexOverview;

        private VerticalAlign verticalAlignmentOfTextToPieCharts = VerticalAlign.Top;
        public VerticalAlign VerticalAlignmentOfTextToPieCharts
        {
            get { return verticalAlignmentOfTextToPieCharts; }
            set
            {
                verticalAlignmentOfTextToPieCharts = value;
            }
        }



        private int numberOfPopularWordsToShow = 10;
        public int NumberOfPopularWordsToShow
        {
            get { return numberOfPopularWordsToShow; }
            set{ numberOfPopularWordsToShow = value; }
        }


        protected override void CreateChildControls()
        {
            tblContentIndexSummary = new Table();
            Controls.Add(tblContentIndexSummary);
            tblContentIndexSummary.CellPadding = 5;
            tblContentIndexSummary.CellSpacing = 0;
            //tblContentIndexSummary.Attributes.Add("border", "1");
            //tblContentIndexSummary.CssClass = "FunctionalArea";

            tr = new TableRow();
            Controls.Add(tr);
            tblContentIndexSummary.Rows.Add(tr);

            tdHeading = new TableCell();
            Controls.Add(tdHeading);
            tr.Cells.Add(tdHeading);
            tdHeading.CssClass = "PageTitle";
            tdHeading.ColumnSpan = 2;


            tr = new TableRow();
            Controls.Add(tr);
            tblContentIndexSummary.Rows.Add(tr);

            tdCommonWordsPieChart = new TableCell();
            Controls.Add(tdCommonWordsPieChart);
            tr.Cells.Add(tdCommonWordsPieChart);
            tdCommonWordsPieChart.VerticalAlign = VerticalAlign.Top;
            tdCommonWordsPieChart.HorizontalAlign = HorizontalAlign.Right;

            imgCommonWordsPieChart = new Image();
            Controls.Add(imgCommonWordsPieChart);
            tdCommonWordsPieChart.Controls.Add(imgCommonWordsPieChart);

            tdCommonWordsBlurb = new TableCell();
            Controls.Add(tdCommonWordsBlurb);
            tr.Cells.Add(tdCommonWordsBlurb);
            tdCommonWordsBlurb.VerticalAlign = VerticalAlign.Top;

            tblCommonWords = new Table();
            Controls.Add(tblCommonWords);
            tdCommonWordsBlurb.Controls.Add(tblCommonWords);
            tblCommonWords.CellPadding = 2;
            tblCommonWords.CellSpacing = 0;
            //tblCommonWords.Attributes.Add("border", "1");

            tr = new TableRow();
            Controls.Add(tr);
            tblCommonWords.Rows.Add(tr);
            tr.CssClass = "bold";

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "&nbsp;";

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Word";

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Occurances";



            tr = new TableRow();
            Controls.Add(tr);
            tblContentIndexSummary.Rows.Add(tr);

            tdCommonWordsInPerspectivePieChart = new TableCell();
            Controls.Add(tdCommonWordsInPerspectivePieChart);
            tr.Cells.Add(tdCommonWordsInPerspectivePieChart);
            tdCommonWordsInPerspectivePieChart.VerticalAlign = VerticalAlign.Top;
            tdCommonWordsInPerspectivePieChart.HorizontalAlign = HorizontalAlign.Right;

            imgCommonWordsInPerspectivePieChart = new Image();
            Controls.Add(imgCommonWordsInPerspectivePieChart);
            tdCommonWordsInPerspectivePieChart.Controls.Add(imgCommonWordsInPerspectivePieChart);

            tdCommonWordsInPerspectiveBlurb = new TableCell();
            Controls.Add(tdCommonWordsInPerspectiveBlurb);
            tr.Cells.Add(tdCommonWordsInPerspectiveBlurb);
            tdCommonWordsInPerspectiveBlurb.VerticalAlign = VerticalAlign.Top;

            tblCommonWordsInPerspective = new Table();
            Controls.Add(tblCommonWordsInPerspective);
            tdCommonWordsInPerspectiveBlurb.Controls.Add(tblCommonWordsInPerspective);
            tblCommonWordsInPerspective.CellPadding = 2;
            tblCommonWordsInPerspective.CellSpacing = 0;
            //tblCommonWordsInPerspective.Attributes.Add("border", "1");


            ContentIndexer c = new ContentIndexer();
            contentIndexOverview = c.IndexOverview;
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                tdCommonWordsBlurb.VerticalAlign = VerticalAlignmentOfTextToPieCharts;
                tdCommonWordsInPerspectiveBlurb.VerticalAlign = VerticalAlignmentOfTextToPieCharts;

                if ((NumberOfPopularWordsToShow < 1) | (NumberOfPopularWordsToShow > contentIndexOverview.PopularWords.Count))
                {
                    NumberOfPopularWordsToShow = contentIndexOverview.PopularWords.Count;
                }

                tdHeading.Text = string.Format("The top {0} most common words", NumberOfPopularWordsToShow.ToString());


                int currentTotal = 0;
                int commonWordsSubTotal = 0;
                int entireIndexTotal = 0;
                int[] pwTotals = new int[NumberOfPopularWordsToShow];
                for (int pw = 0; pw < NumberOfPopularWordsToShow; pw++)
                {
                    currentTotal = contentIndexOverview.PopularWords[pw].Total;
                    pwTotals[pw] = currentTotal;
                    commonWordsSubTotal = commonWordsSubTotal + currentTotal;

                    tr = new TableRow();
                    Controls.Add(tr);
                    tblCommonWords.Rows.Add(tr);

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);

                    imgLegendTile = new Image();
                    Controls.Add(imgLegendTile);
                    td.Controls.Add(imgLegendTile);
                    imgLegendTile.ImageUrl = Charting.ChartingUtilities.MakeUrlToPieChartLegendTileProvider(16, pw);


                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = contentIndexOverview.PopularWords[pw].Word;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = currentTotal.ToString();
                    td.HorizontalAlign = HorizontalAlign.Right;
                }
                imgCommonWordsPieChart.ImageUrl = Charting.ChartingUtilities.MakeUrlToPieChartProvider(300, pwTotals);






                for (int ls = 0; ls < contentIndexOverview.LetterSummaries.Count; ls++)
                {
                    entireIndexTotal = entireIndexTotal + contentIndexOverview.LetterSummaries[ls].Total;
                }
                //contentIndexOverview.LetterSummaries

                tr = new TableRow();
                Controls.Add(tr);
                tblCommonWordsInPerspective.Rows.Add(tr);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);

                imgLegendTile = new Image();
                Controls.Add(imgLegendTile);
                td.Controls.Add(imgLegendTile);
                imgLegendTile.ImageUrl = Charting.ChartingUtilities.MakeUrlToPieChartLegendTileProvider(16, 0);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                td.Text = string.Format("{0} Most Common Indexed Words", NumberOfPopularWordsToShow);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                td.Text = commonWordsSubTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;


                tr = new TableRow();
                Controls.Add(tr);
                tblCommonWordsInPerspective.Rows.Add(tr);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);

                imgLegendTile = new Image();
                Controls.Add(imgLegendTile);
                td.Controls.Add(imgLegendTile);
                imgLegendTile.ImageUrl = Charting.ChartingUtilities.MakeUrlToPieChartLegendTileProvider(16, 1);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                td.Text = "Indexed Words - Grand Total";

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                td.Text = entireIndexTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;


                entireIndexTotal = entireIndexTotal - commonWordsSubTotal;

                imgCommonWordsInPerspectivePieChart.ImageUrl = Charting.ChartingUtilities.MakeUrlToPieChartProvider(170, new int[2] { commonWordsSubTotal, entireIndexTotal });

                base.RenderContents(writer);
            }
        }
    }
}
