// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Business.Logs;
using Morphfolia.PublishingSystem.WebControls;

public partial class SessionHistory : System.Web.UI.Page
{
    private int hours = 24;
    private HttpSessionList httpSessionList;

    protected void Page_Load(object sender, EventArgs e)
    {
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


        Calendar1.SelectionMode = CalendarSelectionMode.Day;
        Calendar2.SelectionMode = CalendarSelectionMode.Day;

        if (!IsPostBack)
        {
            Calendar1.SelectedDate = DateTime.Now;
            Calendar1.TodaysDate = DateTime.Now;

            Calendar2.SelectedDate = DateTime.Now;
            Calendar2.TodaysDate = DateTime.Now;
        }

        httpSessionList = new Morphfolia.PublishingSystem.WebControls.HttpSessionList();
        plchdrSessionList.Controls.Add(httpSessionList);
        //httpSessionList.Width = Unit.Percentage(100);
        //httpSessionList.Width = Unit.Pixel(500);
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        QueryByHours();
    }


    protected void btnViewPredefinedTimeRange_Click(object sender, EventArgs e)
    {
        QueryByHours();
    }


    protected void btnViewThisDate_Click(object sender, EventArgs e)
    {
        QueryByDate();
    }


    protected void btnViewThisDateRange_Click(object sender, EventArgs e)
    {
        QueryByDateRange();
    }


    protected void Calendar1_OnSelectionChanged(object sender, EventArgs e)
    {
        QueryByDate();
    }


    protected void Calendar2_OnSelectionChanged(object sender, EventArgs e)
    {
        QueryByDateRange();
    }


    private void QueryByHours()
    {
        hours = int.Parse(ddlHours.SelectedValue);

        lblTargetTimeRange.Text = string.Format("Sessions for the last {0} hours.", hours);

        httpSessionList.Sessions = HttpLogs.GetListOfActiveSessions(hours);
    }

    private void QueryByDate()
    {
        DateTime targetdate = Calendar1.SelectedDate;

        lblTargetTimeRange.Text = string.Format("Sessions for {0} {1}-{2}-{3}", targetdate.DayOfWeek, targetdate.Day, targetdate.Date.Month, targetdate.Year);

        httpSessionList.Sessions = HttpLogs.GetListOfActiveSessions(targetdate);
    }

    private void QueryByDateRange()
    {
        DateTime targetdate1 = Calendar1.SelectedDate;
        DateTime targetdate2 = Calendar2.SelectedDate;

        lblTargetTimeRange.Text = string.Format("Sessions for {0} {1}-{2}-{3} to {4} {5}-{6}-{7} (inclusive)",
            targetdate1.DayOfWeek, targetdate1.Day, targetdate1.Date.Month, targetdate1.Year,
            targetdate2.DayOfWeek, targetdate2.Day, targetdate2.Date.Month, targetdate2.Year);

        // returnValue = instance.CompareTo(value)
        //  Less than zero: This instance is earlier than value. 
        //  Zero: This instance is the same as value. 
        //  Greater than zero: This instance is later than value. 
        switch (targetdate1.CompareTo(targetdate2))
        {
            case -1:
                httpSessionList.Sessions = HttpLogs.GetListOfActiveSessions(targetdate1, targetdate2);
                break;

            case 1:
                httpSessionList.Sessions = HttpLogs.GetListOfActiveSessions(targetdate2, targetdate1);
                break;

            default: // dates are the same (and any other cases).
                httpSessionList.Sessions = HttpLogs.GetListOfActiveSessions(targetdate1);
                break;
        }
    }


}