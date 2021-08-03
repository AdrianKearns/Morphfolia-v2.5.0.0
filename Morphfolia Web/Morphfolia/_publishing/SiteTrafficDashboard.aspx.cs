// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;
using Morphfolia.Business.Logs;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.Common.Info;
using Morphfolia.PublishingSystem.WebControls;

public partial class _publishing_SiteTrafficDashboard : System.Web.UI.Page
{
    private GenericStringIntInfoCollection requestHistory = new GenericStringIntInfoCollection();
    private Table tblHttpSessionFlow;
    private TableHeaderRow thr;
    private TableHeaderCell thc;
    private TableRow tr;
    private TableCell td;
    private HyperLink hyp;

    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime seedDate = DateTime.Now;
        
        // Right now
        tblHttpSessionFlow = BuildDataTable(string.Format("Last 24 Hours (since {0} {1})", seedDate.DayOfWeek, seedDate.AddHours(-24).ToString()), HttpLogs.TopTenUrlsFor24Hours(seedDate.AddHours(-24)));
        pnlRightNow.Controls.Add(tblHttpSessionFlow);

        tblHttpSessionFlow = BuildDataTable(string.Format("{0} {1} - {2}", seedDate.AddHours(-24).DayOfWeek, seedDate.AddHours(-24).ToString(), seedDate.AddHours(-48).ToString()), HttpLogs.TopTenUrlsFor24Hours(seedDate.AddHours(-48)));
        pnlRightNow.Controls.Add(tblHttpSessionFlow);

        tblHttpSessionFlow = BuildDataTable(string.Format("{0} {1} - {2}", seedDate.AddHours(-48).DayOfWeek, seedDate.AddHours(-48).ToString(), seedDate.AddHours(-72).ToString()), HttpLogs.TopTenUrlsFor24Hours(seedDate.AddHours(-72)));
        pnlRightNow.Controls.Add(tblHttpSessionFlow);

        tblHttpSessionFlow = BuildDataTable(string.Format("{0} {1} - {2}", seedDate.AddHours(-72).DayOfWeek, seedDate.AddHours(-72).ToString(), seedDate.AddHours(-96).ToString()), HttpLogs.TopTenUrlsFor24Hours(seedDate.AddHours(-96)));
        pnlRightNow.Controls.Add(tblHttpSessionFlow);


        // Weekly Trend
        tblHttpSessionFlow = BuildDataTable(string.Format("Last 7 days (since {0} {1})", seedDate.AddDays(-7).DayOfWeek, seedDate.AddDays(-7).ToShortDateString()), HttpLogs.TopTenUrlsFor7Days(seedDate.AddDays(-7)));
        pnlWeeklyTrend.Controls.Add(tblHttpSessionFlow);

        tblHttpSessionFlow = BuildDataTable(string.Format("{0} - {1}", seedDate.AddDays(-7).ToShortDateString(), seedDate.AddDays(-14).ToShortDateString()), HttpLogs.TopTenUrlsFor7Days(seedDate.AddDays(-14)));
        pnlWeeklyTrend.Controls.Add(tblHttpSessionFlow);

        tblHttpSessionFlow = BuildDataTable(string.Format("{0} - {1}", seedDate.AddDays(-14).ToShortDateString(), seedDate.AddDays(-21).ToShortDateString()), HttpLogs.TopTenUrlsFor7Days(seedDate.AddDays(-21)));
        pnlWeeklyTrend.Controls.Add(tblHttpSessionFlow);

        tblHttpSessionFlow = BuildDataTable(string.Format("{0} - {1}", seedDate.AddDays(-21).ToShortDateString(), seedDate.AddDays(-28).ToShortDateString()), HttpLogs.TopTenUrlsFor7Days(seedDate.AddDays(-28)));
        pnlWeeklyTrend.Controls.Add(tblHttpSessionFlow);


        // Top Ten Urls of All Time"
        tblHttpSessionFlow = BuildDataTable("Top Ten Urls of All Time", HttpLogs.TopTenUrlsOfAllTime());
        pnlAllTimeGreatestHits.Controls.Add(tblHttpSessionFlow);

    }



    private Table BuildDataTable(string heading, GenericStringIntInfoCollection data)
    {
        tblHttpSessionFlow = new Table();
        //tblHttpSessionFlow.Attributes.Add("border", "1");
        tblHttpSessionFlow.CellPadding = 3;
        tblHttpSessionFlow.CellSpacing = 0;
        tblHttpSessionFlow.CssClass = "FunctionalArea_Light";
        tblHttpSessionFlow.Style.Add("margin-bottom", "5px");
        tblHttpSessionFlow.Width = Unit.Percentage(100);

        thr = new TableHeaderRow();
        tblHttpSessionFlow.Rows.Add(thr);

        thc = new TableHeaderCell();
        thr.Cells.Add(thc);
        thc.Text = heading;
        thc.ColumnSpan = 2;

        if (data.Count == 0)
        {
            tr = new TableRow();
            tblHttpSessionFlow.Rows.Add(tr);
            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "&nbsp;";
            td.ColumnSpan = 2;
        }
        else
        {
            for (int i = 0; i < data.Count; i++)
            {
                tr = new TableRow();
                tblHttpSessionFlow.Rows.Add(tr);

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = data[i].Number.ToString();
                td.Width = Unit.Pixel(40);
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);

                hyp = new HyperLink();
                td.Controls.Add(hyp);
                hyp.Text = data[i].Text;
                hyp.ToolTip = "View current traffic for this URL.";
                hyp.NavigateUrl = string.Format("{0}/{1}?{2}={3}",
                    Morphfolia.WebControls.Utilities.WebUtilities.FullyQualifiedApplicationRoot(),
                    PageURLs.PageTrafficDashboard,
                    RequestKeys.TargetUrl, 
                    Server.UrlEncode(data[i].Text));

                //td = new TableCell();
                //tr.Cells.Add(td);
                //td.Text = data[i].
            }
        }

        return tblHttpSessionFlow;
    }

}
