// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Text;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Business.Logs;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.Common.Info;
using Morphfolia.PublishingSystem.WebControls;

public partial class _publishing_PageTrafficDashboard : System.Web.UI.Page
{
    private UrlHistoryTable uht;
    private UrlHistory requestHistory = new UrlHistory();

    private string UrlToGetDataFor = string.Format("{0}/default.aspx", Morphfolia.WebControls.Utilities.WebUtilities.FullyQualifiedApplicationRoot());


    protected void Page_Load(object sender, EventArgs e)
    {
        string fullyQualifiedApplicationRoot = Morphfolia.WebControls.Utilities.WebUtilities.FullyQualifiedApplicationRoot();

        if (!Page.IsPostBack)
        {
            if (!Morphfolia.WebControls.Utilities.WebUtilities.GetRequestParamValue(Morphfolia.Common.Constants.Framework.RequestKeys.TargetUrl).Equals(string.Empty))
            {
                string temp = Morphfolia.WebControls.Utilities.WebUtilities.GetRequestParamValue(Morphfolia.Common.Constants.Framework.RequestKeys.TargetUrl);
                txtUrl.Text = temp;
                UrlToGetDataFor = temp;
            }

            PageInfoCollection pages = PageLister.ListAllPagesIncludingBlogPosts(true);
            foreach (PageInfo page in pages)
            {
                ddlUrls.Items.Add( string.Format("{0}/{1}", fullyQualifiedApplicationRoot, page.Url));
            }

            PopulatePage();
        }
    }



    private void PopulatePage()
    {
        DateTime seedDate = DateTime.Now;

        litHeading.Text = string.Format("Traffic for: {0}", UrlToGetDataFor);

        //requestHistory = new UrlHistory();
        //requestHistory.CssClass = "FunctionalArea";
        //requestHistory.urlHistoryData = HttpLogs.GetUrlHistory(UrlToGetDataFor, seedDate.AddDays(-28), seedDate);
        //pnlRightNow.Controls.Add(requestHistory);
        //requestHistory.Width = Unit.Pixel(550);



        HttpLogUrlReportInfoCollection history = HttpLogs.GetUrlHistoryFor7Days(UrlToGetDataFor, seedDate);

        AddHistoryGraph(pnlWeeklyTrendChart, history);
        AddChartAxis(pnlWeeklyTrendChart, history[history.Count - 1].PeriodEnd.ToString(), history[0].PeriodStart.ToString(), Unit.Pixel(550));
        AddChartingLegend(pnlWeeklyTrendLegend, false);

        uht = new UrlHistoryTable();
        uht.urlHistoryCollectionData = history;
        uht.CurrentSortOrder = UrlHistoryTable.SortOrder.ByDateAscending;
        pnlWeeklyTrendData.Controls.Add(uht);
        uht.Width = Unit.Pixel(735);



        //history = HttpLogs.GetUrlHistoryFor7Days("http://localhost/Morphfolia.Web/default.aspx", seedDate.AddDays(-7));
        //history = HttpLogs.GetUrlHistoryFor4Weeks("http://localhost/Morphfolia.Web/default.aspx", seedDate.AddDays(-28));
        history = HttpLogs.GetUrlHistoryFor4Weeks(UrlToGetDataFor, seedDate);

        AddHistoryGraphIncludingGrandTotals(pnlAllTimeGreatestHitsChart, history);
        AddChartAxis(pnlAllTimeGreatestHitsChart, history[history.Count - 1].PeriodEnd.ToString(), history[0].PeriodStart.ToString(), Unit.Pixel(550));
        AddChartingLegend(pnlAllTimeGreatestHitsLegend, true);

        uht = new UrlHistoryTable();
        uht.urlHistoryCollectionData = history;
        uht.CurrentSortOrder = UrlHistoryTable.SortOrder.ByDateAscending;
        pnlAllTimeGreatestHitsData.Controls.Add(uht);
        uht.Width = Unit.Pixel(735);
    }


    private void AddChartingLegend(WebControl parentControl, bool includeGrandTotals)
    {
        Morphfolia.WebControls.Charting.Legend l = new Morphfolia.WebControls.Charting.Legend();
        parentControl.Controls.Add(l);
        l.ColourRange = Morphfolia.WebControls.Constants.ColourRanges.UrlHistory;
        l.Words = new System.Collections.Specialized.StringCollection();
        l.Words.Add("URL Hits by Referrer");
        l.Words.Add("URL Hits as Referrer");
        l.Words.Add("URL Hits by Robots");

        if (includeGrandTotals)
        {
            l.Words.Add("Grand Total");
            l.Words.Add("Grand Total (Robots)");
            l.Words.Add("Grand Total (RSS Readers)");
        }
    }


    private void AddHistoryGraph(WebControl parentControl, HttpLogUrlReportInfoCollection history)
    {
        StringBuilder sSrc = new System.Text.StringBuilder();
        StringBuilder sTotalHitsAsReferrer = new System.Text.StringBuilder();
        StringBuilder sTotalsHitsByReferrer = new System.Text.StringBuilder();
        StringBuilder sBotTotals = new System.Text.StringBuilder();

        //foreach (HttpLogUrlReportInfo info in history)
        HttpLogUrlReportInfo info;
        //for (int i = 0; i < history.Count; i++)
        for (int i = (history.Count-1); i >= 0; i--)
        {
            info = history[i];
            sTotalHitsAsReferrer.AppendFormat("{0},", info.TotalHitsAsReferrer.ToString());
            sTotalsHitsByReferrer.AppendFormat("{0},", info.TotalsHitsByReferrer.ToString());
            sBotTotals.AppendFormat("{0},", info.BotTotal.ToString());
        }

        sBotTotals.Remove(sBotTotals.Length - 1, 1);

        // Handles values 0 < and > 4 as 'Solid'.
        // 0 = Solid 
        // 1 = Dash 
        // 2 = Dash Dot 
        // 3 = Dash Dot Dot 
        // 4 = Dot 
        
        sSrc.AppendFormat("{0}?{1}=3&{2}={3}{4}{5}&{6}=550&{7}=0,1,2",
            Morphfolia.WebControls.Constants.LineChartProviderUrl,
            Morphfolia.WebControls.Constants.QueryStringKeys.LineCount,
            Morphfolia.WebControls.Constants.QueryStringKeys.LineValues,
            sTotalsHitsByReferrer.ToString(),
            sTotalHitsAsReferrer.ToString(),
            sBotTotals.ToString(),
            Morphfolia.WebControls.Constants.QueryStringKeys.GraphWidth,
            Morphfolia.WebControls.Constants.QueryStringKeys.LineDashStyles);

        Image img = new Image();
        img.ImageUrl = sSrc.ToString();
        parentControl.Controls.Add(img);
    }


    private void AddHistoryGraphIncludingGrandTotals(WebControl parentControl, HttpLogUrlReportInfoCollection history)
    {
        StringBuilder sSrc = new System.Text.StringBuilder();
        StringBuilder sTotalHitsAsReferrer = new System.Text.StringBuilder();
        StringBuilder sTotalsHitsByReferrer = new System.Text.StringBuilder();
        StringBuilder sBotTotals = new System.Text.StringBuilder();
        StringBuilder sGrandTotals = new System.Text.StringBuilder();
        StringBuilder sGrandTotalBots = new System.Text.StringBuilder();
        StringBuilder sGrandTotalRssReaders = new System.Text.StringBuilder();

        HttpLogUrlReportInfo info;
        for (int i = (history.Count - 1); i >= 0; i--)
        {
            info = history[i];
            sTotalHitsAsReferrer.AppendFormat("{0},", info.TotalHitsAsReferrer.ToString());
            sTotalsHitsByReferrer.AppendFormat("{0},", info.TotalsHitsByReferrer.ToString());
            sBotTotals.AppendFormat("{0},", info.BotTotal.ToString());
            sGrandTotals.AppendFormat("{0},", info.GrandTotal.ToString());
            sGrandTotalBots.AppendFormat("{0},", info.BotGrandTotal.ToString());
            sGrandTotalRssReaders.AppendFormat("{0},", info.RSSReaderGrandTotal.ToString());
        }

        sGrandTotalRssReaders.Remove(sGrandTotalRssReaders.Length - 1, 1);

        // Handles values 0 < and > 4 as 'Solid'.
        // 0 = Solid 
        // 1 = Dash 
        // 2 = Dash Dot 
        // 3 = Dash Dot Dot 
        // 4 = Dot 

        sSrc.AppendFormat("{0}?{1}=6&{2}={3}{4}{5}{6}{7}{8}&{9}=550&{10}=0,1,2,1,2,2",
            Morphfolia.WebControls.Constants.LineChartProviderUrl,
            Morphfolia.WebControls.Constants.QueryStringKeys.LineCount,
            Morphfolia.WebControls.Constants.QueryStringKeys.LineValues,
            sTotalsHitsByReferrer.ToString(),
            sTotalHitsAsReferrer.ToString(),
            sBotTotals.ToString(),
            sGrandTotals.ToString(),
            sGrandTotalBots.ToString(),
            sGrandTotalRssReaders.ToString(),
            Morphfolia.WebControls.Constants.QueryStringKeys.GraphWidth,
            Morphfolia.WebControls.Constants.QueryStringKeys.LineDashStyles);

        Image img = new Image();
        img.ImageUrl = sSrc.ToString();
        parentControl.Controls.Add(img);
    }


    private void AddChartAxis(WebControl parentControl, string leftValue, string rightValue, Unit width)
    {
        TableRow tr;

        Table tblChartAxis = new Table();
        tblChartAxis.CellPadding = 3;
        tblChartAxis.CellSpacing = 0;
        tblChartAxis.Width = width;

        tr = new TableRow();
        tblChartAxis.Rows.Add(tr);

        TableCell td = new TableCell();
        tr.Cells.Add(td);
        td.Text = leftValue;
        td.HorizontalAlign = HorizontalAlign.Left;
        td.Style.Add("color", "#999999");

        td = new TableCell();
        tr.Cells.Add(td);
        td.Text = rightValue;
        td.HorizontalAlign = HorizontalAlign.Right;
        td.Style.Add("color", "#999999");

        parentControl.Controls.Add(tblChartAxis);
    }



    protected void btnShowDataForSelectedUrl_Click(object sender, EventArgs e)
    {
        if (txtUrl.Text == string.Empty)
        {
            UrlToGetDataFor = ddlUrls.SelectedValue;
        }
        else
        {
            UrlToGetDataFor = txtUrl.Text.Trim();
        }
        PopulatePage();
    }
}
