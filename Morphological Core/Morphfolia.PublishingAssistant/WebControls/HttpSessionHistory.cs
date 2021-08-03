// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{


    /// <summary>
    /// Summary description for HttpSessionList
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class HttpSessionHistory : WebControl
    {
        private Table tblHttpSessionHistory;
        private TableHeaderRow thr;
        private TableHeaderCell thc;
        private TableRow tr;
        //private TableCell tdSessionId;
        private TableCell tdUrl;
        private TableCell tdReferer;
        //private TableCell tdWhenRequested;
        private TableCell tdDuration;
        private TableCell tdMiscInfo;

        // need a header row. explain that data reflects complete session history - not just hits within a certain timeframe.
        // highlight hits that match timeframe specified in SessionList?


        private HttpLogEntryInfoCollection sessionHistory;
        public HttpLogEntryInfoCollection SessionHistory
        {
            get
            {
                if (sessionHistory == null)
                {
                    sessionHistory = new HttpLogEntryInfoCollection();
                }
                return sessionHistory;
            }
            set { sessionHistory = value; }
        }

        

        protected override void CreateChildControls()
        {
            tblHttpSessionHistory = new Table();
            Controls.Add(tblHttpSessionHistory);
            tblHttpSessionHistory.CellPadding = 5;
            tblHttpSessionHistory.CellSpacing = 0;
            tblHttpSessionHistory.CssClass = "FunctionalArea_Light";
            //tblHttpSessionHistory.Attributes.Add("border", "1");
            tblHttpSessionHistory.Width = Unit.Percentage(100);
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Visible)
            {
                if (SessionHistory.Count == 0)
                {
                    tblHttpSessionHistory.Visible = false;
                }
                else
                {
                    tblHttpSessionHistory.Visible = true; ;

                    DateTime previousItem = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                    TimeSpan durationBetweenHits = new TimeSpan();
                    string url;
                    //string urlReferrer;



                    thr = new TableHeaderRow();
                    tblHttpSessionHistory.Controls.Add(thr);

                    thc = new TableHeaderCell();
                    thr.Cells.Add(thc);
                    thc.Text = string.Format("Session History for: {0}", SessionHistory[0].SessionId);
                    thc.ColumnSpan = 2;


                    thr = new TableHeaderRow();
                    tblHttpSessionHistory.Controls.Add(thr);

                    thc = new TableHeaderCell();
                    thr.Cells.Add(thc);
                    thc.Text = "Url Requested";

                    thc = new TableHeaderCell();
                    thr.Cells.Add(thc);
                    thc.Text = "Referrer";



                    thr = new TableHeaderRow();
                    tblHttpSessionHistory.Controls.Add(thr);

                    thc = new TableHeaderCell();
                    thr.Cells.Add(thc);
                    thc.Text = "When Requested";

                    thc = new TableHeaderCell();
                    thr.Cells.Add(thc);
                    thc.Text = "Time between requests";



                    thr = new TableHeaderRow();
                    tblHttpSessionHistory.Controls.Add(thr);

                    thc = new TableHeaderCell();
                    thr.Cells.Add(thc);
                    thc.Text = "Misc Info (if any)";
                    thc.ColumnSpan = 2;

                    for (int i = 0; i < SessionHistory.Count; i++)
                    {
                        if (i < (SessionHistory.Count - 1))
                        {
                            durationBetweenHits = SessionHistory[i].TimeLogged.Subtract(SessionHistory[(i + 1)].TimeLogged);
                        }
                        else
                        {
                            durationBetweenHits = TimeSpan.Zero;
                        }
                



                        tr = new TableRow();
                        tblHttpSessionHistory.Controls.Add(tr);
                        tr.CssClass = "FunctionalRow_Light";

                        tdUrl = new TableCell();
                        tr.Cells.Add(tdUrl);
                        url = SessionHistory[i].Url;
                        tdUrl.Text = url;
                        tdUrl.Text = string.Format("<b>{0}</b><br> &nbsp; {1}", url.Replace("?", "?<br>"), SessionHistory[i].TimeLogged.ToString());



                        tdReferer = new TableCell();
                        tr.Cells.Add(tdReferer);
                        if (SessionHistory[i].UrlReferrer.Equals(string.Empty))
                        {
                            tdReferer.Text = "[accessed directly]";
                        }
                        else
                        {
                            if (SessionHistory[i].UrlReferrer.Equals(SessionHistory[i].Url))
                            {
                                tdReferer.Text = "[refreshed]";
                            }
                            else
                            {
                                tdReferer.Text = string.Format("(from: {0})", AntiXss.HtmlEncode(SessionHistory[i].UrlReferrer));
                            }
                        }
                        tdReferer.CssClass = "SessionHistory_UrlReferrer";

                        previousItem = SessionHistory[i].TimeLogged;




                        if (!SessionHistory[i].MiscInfo.Equals(string.Empty))
                        {
                            tr = new TableRow();
                            tblHttpSessionHistory.Controls.Add(tr);

                            tdMiscInfo = new TableCell();
                            tr.Cells.Add(tdMiscInfo);
                            tdMiscInfo.Text = AntiXss.HtmlEncode(SessionHistory[i].MiscInfo);
                            tdMiscInfo.ColumnSpan = 3;
                        }


                        if ((durationBetweenHits != null) & (durationBetweenHits != TimeSpan.Zero))
                        {
                            tr = new TableRow();
                            tblHttpSessionHistory.Controls.Add(tr);
                            tr.CssClass = "FunctionalRow_Light";

                            tdDuration = new TableCell();
                            tr.Cells.Add(tdDuration);
                            tdDuration.HorizontalAlign = HorizontalAlign.Center;
                            tdDuration.ColumnSpan = 3;
                            tdDuration.ToolTip = "Duration (hh:mm:ss) between this request and the previous one (below).";

                            tdDuration.Text = string.Format("({0}:{1}:{2})",
                                Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.prefixNumberWith0(durationBetweenHits.Hours, 2),
                                Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.prefixNumberWith0(durationBetweenHits.Minutes, 2),
                                Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.prefixNumberWith0(durationBetweenHits.Seconds, 2)
                            );
                        }
                    }
                }
                tblHttpSessionHistory.RenderControl(writer);
            }
        }
    }
}