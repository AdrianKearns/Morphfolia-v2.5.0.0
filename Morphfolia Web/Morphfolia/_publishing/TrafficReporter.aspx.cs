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
using Morphfolia.PublishingSystem;
using Morphfolia.PublishingSystem.WebControls;

public partial class _publishing_TrafficReporter : System.Web.UI.Page
{
    private GenericStringIntInfoCollection requestHistory = new GenericStringIntInfoCollection();
    private int hours = 24;


    protected void Page_Load(object sender, EventArgs e)
    {
        EnsureChildControls();

        if (IsPostBack)
        {
            if (ddlHours.SelectedValue != null)
            {
                hours = int.Parse(ddlHours.SelectedValue);
            }
            else
            {
                hours = 24;
            }
        }


        if (txtUrl.Text.Equals(string.Empty))
        {
            txtUrl.Text = string.Format("{0}/{1}", WebUtilities.FullyQualifiedApplicationRoot(), PageURLs.SearchResults);
        }

        //if (txtAlternativeUrl.Text.Equals(string.Empty))
        //{
        //    txtAlternativeUrl.Text = string.Format("{0}/{1}", Morphfolia.PublishingSystem.WebUtilities.FullyQualifiedApplicationRoot(), Morphfolia.Common.Constants.Framework.PageURLs.SearchResults);
        //}


        Calendar1.SelectionMode = CalendarSelectionMode.Day;
        Calendar2.SelectionMode = CalendarSelectionMode.Day;

        htfToResults.Width = Unit.Percentage(100);
        htfToResults.Text = "Requests to";
        htfToResults.UrlMode = HttpTrafficFlow.Mode.ShowRequestedUrls;

        htfFromResults.Width = Unit.Percentage(100);
        htfFromResults.Text = "Requests from";
        htfFromResults.UrlMode = HttpTrafficFlow.Mode.ShowReferrerUrls;

        pnlTrafficInAndOut.Visible = true;

        if (!IsPostBack)
        {
            Calendar1.SelectedDate = DateTime.Now;
            Calendar1.TodaysDate = DateTime.Now;

            Calendar2.SelectedDate = DateTime.Now;
            Calendar2.TodaysDate = DateTime.Now;

            pnlTrafficInAndOut.Visible = false;

        }
    }


    private void EnsureUrlIsComplete()
    {
        string url = txtUrl.Text.Trim();

        if (!url.StartsWith("http"))
        {
            txtUrl.Text = string.Format("{0}/{1}", WebUtilities.FullyQualifiedApplicationRoot(), url);
            url = txtUrl.Text;
        }

        if (url.EndsWith("/default.aspx"))
        {
            txtAlternativeUrl.Text = url.Replace("/default.aspx", "/");
            pnlAlternativeUrl.Visible = true;
        }
        else
        {
            txtAlternativeUrl.Text = string.Empty;
            pnlAlternativeUrl.Visible = false;
        }
    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        QueryByHours();
    }

    protected void btnViewPredefinedTimeRange_Click(object sender, EventArgs e)
    {
        QueryByHours();
    }

    protected void Calendar1_OnSelectionChanged(object sender, EventArgs e)
    {
        QueryByDate();
    }

    protected void Calendar2_OnSelectionChanged(object sender, EventArgs e)
    {
        QueryByDateRange();
    }

    protected void btnViewThisDateRange_Click(object sender, EventArgs e)
    {
        QueryByDateRange();
    }

    protected void btnViewThisDate_Click(object sender, EventArgs e)
    {
        QueryByDate();
    }





    private void QueryByHours()
    {
        hours = int.Parse(ddlHours.SelectedValue);

        EnsureUrlIsComplete();
        lblTargetTimeRange.Text = string.Format("Traffic for the last {0} hours.", hours);
        //UrlTextBox1.Text = lblTargetTimeRange.Text;

        htfToResults.Hours = hours;
        htfToResults.UrlReferrer = txtUrl.Text;
        htfToResults.UrlReferrer2 = txtAlternativeUrl.Text;
        htfToResults.SessionFlowHistory = HttpLogs.ListReferreringUrlsForVisitedUrl(htfToResults.UrlReferrer, htfToResults.Hours);

        htfFromResults.Hours = hours;
        htfFromResults.UrlReferrer = txtUrl.Text;
        htfFromResults.UrlReferrer2 = txtAlternativeUrl.Text;
        htfFromResults.SessionFlowHistory = HttpLogs.ListDestinationUrlsFromVisitedUrl(htfFromResults.UrlReferrer, htfFromResults.Hours, htfFromResults.UrlReferrer2);
    }





    private void QueryByDate()
    {
        DateTime targetdate = Calendar1.SelectedDate;

        EnsureUrlIsComplete();
        lblTargetTimeRange.Text = string.Format("Traffic for {0} {1}-{2}-{3}", targetdate.DayOfWeek, targetdate.Day, targetdate.Date.Month, targetdate.Year);

        htfToResults.DateRange = targetdate.ToLongDateString();
        htfToResults.UrlReferrer = txtUrl.Text;
        htfToResults.UrlReferrer2 = txtAlternativeUrl.Text;
        htfToResults.SessionFlowHistory = HttpLogs.ListReferreringUrlsForVisitedUrl(htfToResults.UrlReferrer, targetdate);

        htfFromResults.DateRange = targetdate.ToLongDateString();
        htfFromResults.UrlReferrer = txtUrl.Text;
        htfFromResults.UrlReferrer2 = txtAlternativeUrl.Text;
        htfFromResults.SessionFlowHistory = HttpLogs.ListDestinationUrlsFromVisitedUrl(htfFromResults.UrlReferrer, targetdate, htfFromResults.UrlReferrer2);
    }


    private void QueryByDateRange()
    {
        DateTime targetdate1 = Calendar1.SelectedDate;
        DateTime targetdate2 = Calendar2.SelectedDate;

        EnsureUrlIsComplete();
        lblTargetTimeRange.Text = string.Format("Traffic for {0} {1}-{2}-{3} to {4} {5}-{6}-{7} (inclusive)",
            targetdate1.DayOfWeek, targetdate1.Day, targetdate1.Date.Month, targetdate1.Year,
            targetdate2.DayOfWeek, targetdate2.Day, targetdate2.Date.Month, targetdate2.Year);

        htfToResults.UrlReferrer = txtUrl.Text;
        htfToResults.UrlReferrer2 = txtAlternativeUrl.Text;
        htfFromResults.UrlReferrer = txtUrl.Text;
        htfFromResults.UrlReferrer2 = txtAlternativeUrl.Text;

        // returnValue = instance.CompareTo(value)
        //  Less than zero: This instance is earlier than value. 
        //  Zero: This instance is the same as value. 
        //  Greater than zero: This instance is later than value. 
        switch (targetdate1.CompareTo(targetdate2))
        {
            case -1:
                htfToResults.DateRange = string.Format("{0} to {1}", targetdate1.ToShortDateString(), targetdate2.ToShortDateString());
                htfToResults.SessionFlowHistory = HttpLogs.ListReferreringUrlsForVisitedUrl(htfToResults.UrlReferrer, targetdate1, targetdate2);

                htfFromResults.DateRange = string.Format("{0} to {1}", targetdate1.ToShortDateString(), targetdate2.ToShortDateString());
                htfFromResults.SessionFlowHistory = HttpLogs.ListDestinationUrlsFromVisitedUrl(htfFromResults.UrlReferrer, targetdate1, targetdate2, htfFromResults.UrlReferrer2);
                break;

            case 1:
                htfToResults.DateRange = string.Format("{0} to {1}", targetdate2.ToShortDateString(), targetdate1.ToShortDateString());
                htfToResults.SessionFlowHistory = HttpLogs.ListReferreringUrlsForVisitedUrl(htfToResults.UrlReferrer, targetdate2, targetdate1);

                htfFromResults.DateRange = string.Format("{0} to {1}", targetdate2.ToShortDateString(), targetdate1.ToShortDateString());
                htfFromResults.SessionFlowHistory = HttpLogs.ListDestinationUrlsFromVisitedUrl(htfFromResults.UrlReferrer, targetdate2, targetdate1, htfFromResults.UrlReferrer2);
                break;

            default: // dates are the same (and any other cases).
                htfToResults.DateRange = targetdate1.ToLongDateString();
                htfToResults.SessionFlowHistory = HttpLogs.ListReferreringUrlsForVisitedUrl(htfToResults.UrlReferrer, targetdate1);

                htfFromResults.DateRange = targetdate1.ToLongDateString();
                htfFromResults.SessionFlowHistory = HttpLogs.ListDestinationUrlsFromVisitedUrl(htfFromResults.UrlReferrer, targetdate1, htfFromResults.UrlReferrer2);
                break;
        }
    }
}
