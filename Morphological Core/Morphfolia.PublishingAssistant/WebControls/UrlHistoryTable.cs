// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using System.ComponentModel;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Summary description for HttpSessionList
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class UrlHistoryTable : WebControl, INamingContainer
    {
        private Table tblUrlHistoryTable;
        private TableHeaderRow thr;
        private TableHeaderCell thc;
        private TableRow tr;
        private TableCell td;

        public enum SortOrder { ByDateDescending, ByDateAscending }


        private SortOrder currentSortOrder = SortOrder.ByDateDescending;
        public SortOrder CurrentSortOrder
        {
            get { return currentSortOrder; }
            set { currentSortOrder = value; }
        }

        public HttpLogUrlReportInfoCollection urlHistoryCollectionData = new HttpLogUrlReportInfoCollection();





        private string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }


        public override string CssClass
        {
            get
            {
                EnsureChildControls();
                return tblUrlHistoryTable.CssClass;
            }
            set
            {
                EnsureChildControls();
                tblUrlHistoryTable.CssClass = value;
            }
        }


        public override Unit Width
        {
            get
            {
                EnsureChildControls();
                return tblUrlHistoryTable.Width;
            }
            set
            {
                EnsureChildControls();
                tblUrlHistoryTable.Width = value;
            }
        }




        protected override void CreateChildControls()
        {
            //base.CreateChildControls();

            tblUrlHistoryTable = new Table();
            Controls.Add(tblUrlHistoryTable);
            //tblHttpSessionFlow.Attributes.Add("border", "1");
            tblUrlHistoryTable.CellPadding = 3;
            tblUrlHistoryTable.CellSpacing = 0;

            tblUrlHistoryTable.CssClass = "FunctionalArea";
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Visible)
            {
                EnsureChildControls();

                thr = new TableHeaderRow();
                tblUrlHistoryTable.Rows.Add(thr);

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "&nbsp";
                thc.ColumnSpan = 2;

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "Totals for URL";
                thc.ColumnSpan = 3;
                thc.ToolTip = "These columns show hits relevant to the specified URL page only.";
                thc.HorizontalAlign = HorizontalAlign.Right;

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "Grand Totals";
                thc.ColumnSpan = 3;
                thc.ToolTip = "These columns show hits relevant to the entire site.";
                thc.HorizontalAlign = HorizontalAlign.Right;

                // Data names as stated by Legend:
                //-----------------------------------
                // URL Hits by Referrer
                // URL Hits as Referrer
                // URL Hits by Robots
                // Grand Total
                // Grand Total (Robots)
                // Grand Total (RSS Readers)

                thr = new TableHeaderRow();
                tblUrlHistoryTable.Rows.Add(thr);

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "From";

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "Until";

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "Hits";
                thc.ToolTip = "The total number of hits for the specified page.";
                thc.HorizontalAlign = HorizontalAlign.Right;

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "As Referrer";
                thc.ToolTip = "The number of times this URL was a referrer for another request.";
                thc.HorizontalAlign = HorizontalAlign.Right;

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "Robots";
                thc.ToolTip = "The number of times search engines (search-bots / robots) have indexed the page.";
                thc.HorizontalAlign = HorizontalAlign.Right;

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "All";
                thc.ToolTip = "The grand total of all hits for the period.";
                thc.HorizontalAlign = HorizontalAlign.Right;

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "Robots";
                thc.ToolTip = "The grand total of hits from search engines (search-bots / robots) for the period.";
                thc.HorizontalAlign = HorizontalAlign.Right;

                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = "RSS Readers";
                thc.ToolTip = "The grand total of hits from RSS Readers for the period.";
                thc.HorizontalAlign = HorizontalAlign.Right;

                if (urlHistoryCollectionData.Count == 0)
                {
                    tr = new TableRow();
                    tblUrlHistoryTable.Rows.Add(tr);

                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = "No data.";
                    td.ColumnSpan = 6;
                }
                else
                {
                    if (CurrentSortOrder == SortOrder.ByDateAscending)
                    {
                        PopulateAsAscending();
                    }
                    else
                    {
                        PopulateAsDescending();
                    }
                }

                base.RenderContents(writer);
            }
        }


        private void PopulateAsDescending()
        {
            foreach (HttpLogUrlReportInfo info in urlHistoryCollectionData)
            {
                tr = new TableRow();
                tblUrlHistoryTable.Rows.Add(tr);

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.PeriodStart.ToString();

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.PeriodEnd.ToString();

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.TotalsHitsByReferrer.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.TotalHitsAsReferrer.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.BotTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.GrandTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.BotGrandTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.RSSReaderGrandTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;
            }
        }


        private void PopulateAsAscending()
        {
            HttpLogUrlReportInfo info;
            for (int i = (urlHistoryCollectionData.Count - 1); i >= 0; i--)
            {
                info = urlHistoryCollectionData[i];

                tr = new TableRow();
                tblUrlHistoryTable.Rows.Add(tr);

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.PeriodStart.ToString();

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.PeriodEnd.ToString();

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.TotalsHitsByReferrer.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.TotalHitsAsReferrer.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.BotTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.GrandTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.BotGrandTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.RSSReaderGrandTotal.ToString();
                td.HorizontalAlign = HorizontalAlign.Right;
            }
        }


    }

}