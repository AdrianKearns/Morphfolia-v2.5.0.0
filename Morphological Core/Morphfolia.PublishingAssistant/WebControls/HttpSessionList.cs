// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.PublishingSystem.WebControls
{


    /// <summary>
    /// Summary description for HttpSessionList
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class HttpSessionList : WebControl, INamingContainer
    {
        private Table tblHttpSessionList;
        private TableHeaderRow th;
        private TableHeaderCell thcMainHeading;
        private TableHeaderCell thc;
        private TableRow tr;
        private TableCell td;
        private HyperLink hypShowSessionsFullHistory;
        private HyperLink hypHostAddress;

        private string sessionId = string.Empty;
        public string SessionId
        {
            get { return sessionId; }
        }

        // need a header row. explain that number of hits is based on hits within certain period 24 hours.


        public delegate void onSessionIdSelected();
        public event onSessionIdSelected SessionIdSelected;



        private HttpSessionListInfoCollection sessions;
        public HttpSessionListInfoCollection Sessions
        {
            get
            {
                if (sessions == null)
                {
                    sessions = new HttpSessionListInfoCollection();
                }
                return sessions;
            }
            set { sessions = value; }
        }



        protected override void CreateChildControls()
        {
            tblHttpSessionList = new Table();
            Controls.Add(tblHttpSessionList);
            tblHttpSessionList.ID = "tblHttpSessionList";
            tblHttpSessionList.CellPadding = 5;
            tblHttpSessionList.CellSpacing = 0;
            //tblHttpSessionList.CssClass = "FunctionalArea";
            //tblHttpSessionList.Attributes.Add("border", "1");
            tblHttpSessionList.Width = Unit.Percentage(100);
            tblHttpSessionList.CssClass = "FunctionalArea";

            th = new TableHeaderRow();
            tblHttpSessionList.Controls.Add(th);

            thcMainHeading = new TableHeaderCell();
            th.Cells.Add(thcMainHeading);
            thcMainHeading.ColumnSpan = 7;



            th = new TableHeaderRow();
            tblHttpSessionList.Controls.Add(th);

            thc = new TableHeaderCell();
            th.Cells.Add(thc);
            thc.Text = "Session Id";

            thc = new TableHeaderCell();
            th.Cells.Add(thc);
            thc.Text = "User Host Name";

            thc = new TableHeaderCell();
            th.Cells.Add(thc);
            thc.Text = "Requests";
            thc.ToolTip = "Number of requests in specified time-frame.";

            thc = new TableHeaderCell();
            th.Cells.Add(thc);
            thc.Text = "First Request";

            thc = new TableHeaderCell();
            th.Cells.Add(thc);
            thc.Text = "First Requested Url";

            thc = new TableHeaderCell();
            th.Cells.Add(thc);
            thc.Text = "Last Request";

            thc = new TableHeaderCell();
            th.Cells.Add(thc);
            thc.Text = "Last Requested Url";
        }



        private void Populate()
        {
            if (Sessions.Count == 0)
            {
                thcMainHeading.Text = "Session List";

                tr = new TableRow();
                tblHttpSessionList.Controls.Add(tr);
                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = "No sessions.";
                td.ColumnSpan = 7;
                tblHttpSessionList.Visible = false;
            }
            else
            {
                string fullyQualifiedApplicationRoot = WebUtilities.FullyQualifiedApplicationRoot();
                tblHttpSessionList.Visible = true;
                thcMainHeading.Text = string.Format("Session List ({0} Sessions active in selected timeframe)", Sessions.Count.ToString());

                for (int i = 0; i < Sessions.Count; i++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblHttpSessionList.Controls.Add(tr);
                    //tr.ID = string.Format("tr{0}", i.ToString());

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);



                    hypShowSessionsFullHistory = new HyperLink();
                    Controls.Add(hypShowSessionsFullHistory);
                    td.Controls.Add(hypShowSessionsFullHistory);
                    hypShowSessionsFullHistory.ID = string.Format("hypShowSessionsFullHistory{0}", i.ToString());
                    hypShowSessionsFullHistory.Text = Sessions[i].SessionId;
                    hypShowSessionsFullHistory.NavigateUrl = string.Format("{0}/{1}?{2}={3}", 
                        fullyQualifiedApplicationRoot,
                        PageURLs.SessionHistoryViewer,
                        RequestKeys.SessionId,
                        Sessions[i].SessionId);
                    hypShowSessionsFullHistory.Target = "_blank";


                    td.ToolTip = "Click to see this sessions full history";


                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    //td.Text = string.Format("<nobr>{0}</nobr>", Sessions[i].UserHostName);
                    td.ToolTip = "UserHostName of the client.";

                    hypHostAddress = new HyperLink();
                    Controls.Add(hypHostAddress);
                    td.Controls.Add(hypHostAddress);
                    //hypHostAddress.ID = string.Format("hypShowSessionsFullHistory{0}", i.ToString());
                    hypHostAddress.Text = Sessions[i].UserHostName;
                    hypHostAddress.NavigateUrl = string.Format("{0}/{1}?{2}={3}",
                        fullyQualifiedApplicationRoot,
                        PageURLs.ViewHttpLogs,
                        RequestKeys.UserHostAddress,
                        Sessions[i].UserHostName);





                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = Sessions[i].TotalPageRequests.ToString();
                    td.ToolTip = "Total Page Requests made by this session.";
                    td.HorizontalAlign = HorizontalAlign.Right;

                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = string.Format("<nobr>{0}</nobr>", Sessions[i].FirstRequest.ToString());
                    td.ToolTip = "The time of the sessions most recent Url request.";
                    td.HorizontalAlign = HorizontalAlign.Right;

                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = string.Format("<nobr>{0}</nobr>", Sessions[i].FirstUrlRequested);
                    td.ToolTip = "The Url most recently requested by this session.";

                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = string.Format("<nobr>{0}</nobr>", Sessions[i].MostRecentRequest.ToString());
                    td.ToolTip = "The time of the sessions most recent Url request.";
                    td.HorizontalAlign = HorizontalAlign.Right;

                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = string.Format("<nobr>{0}</nobr>", Sessions[i].MostRecentUrlRequested);
                    td.ToolTip = "The Url most recently requested by this session.";
                }
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                Populate();

                tblHttpSessionList.RenderControl(writer);
            }
        }


        private void btnShowSessionsFullHistory_Command(object sender, CommandEventArgs e)
        {
            sessionId = e.CommandArgument.ToString();

            if(SessionIdSelected != null)
            {
                SessionIdSelected();
            }
        }    
    }
}