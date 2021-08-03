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
    public class HttpTrafficFlow : WebControl
    {

        public enum Mode { ShowRequestedUrls, ShowReferrerUrls }

        public Mode UrlMode = Mode.ShowRequestedUrls;
        private Table tblHttpSessionFlow;
        private TableRow tr;
        private TableCell td;
        private HyperLink hyp;
        private string xxxxxxxx;
        private string tooooltip;


        private string urlReferrer = string.Empty;
        /// <summary>
        /// The URL to look for traffic aganist.
        /// </summary>
        /// <example>http://www.mysite.geek/default.aspx</example>
        public string UrlReferrer
        {
            get { return urlReferrer; }
            set { urlReferrer = value;  }
        }

        private string urlReferrer2 = string.Empty;
        /// <summary>
        /// An alternate URL to look for traffic aganist.  
        /// Designed to be used for root requests where requests to a default page 
        /// may or may not have explicitly included the default file name (usually 
        /// default.aspx, but also possibly index.aspx, and so on).
        /// </summary>
        /// <example>http://www.mysite.geek/</example>
        public string UrlReferrer2
        {
            get { return urlReferrer2; }
            set { urlReferrer2 = value; }
        }


        private string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }


        private int hours = 24;
        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        private string dateRange = string.Empty;
        public string DateRange
        {
            get { return dateRange; }
            set { dateRange = value; }
        }

        public override Unit Width
        {
            get
            {
                EnsureChildControls();
                return tblHttpSessionFlow.Width;
            }
            set
            {
                EnsureChildControls();
                tblHttpSessionFlow.Width = value;
            }
        }


        private GenericStringIntInfoCollection sessionFlowHistory;
        public GenericStringIntInfoCollection SessionFlowHistory
        {
            get
            {
                if (sessionFlowHistory == null)
                {
                    sessionFlowHistory = new GenericStringIntInfoCollection();
                }
                return sessionFlowHistory;
            }
            set { sessionFlowHistory = value; }
        }



        protected override void CreateChildControls()
        {
            //base.CreateChildControls();

            tblHttpSessionFlow = new Table();
            Controls.Add(tblHttpSessionFlow);
            //tblHttpSessionFlow.Attributes.Add("border", "1");
            tblHttpSessionFlow.CellPadding = 5;
            tblHttpSessionFlow.CellSpacing = 0;
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Visible)
            {
                if (SessionFlowHistory.Count == 0)
                {
                    tr = new TableRow();
                    tblHttpSessionFlow.Controls.Add(tr);

                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.ColumnSpan = 2;
                    td.CssClass = "SessionFlowHistory_Heading";
                    td.Text = string.Format("No traffic flow to <b>{0}</b> in the last {1} hours",
                        UrlReferrer,
                        Hours.ToString());
                }
                else
                {
                    if(!Text.Equals(string.Empty))
                    {
                        tr = new TableRow();
                        tblHttpSessionFlow.Controls.Add(tr);


                        if (DateRange.Equals(string.Empty))
                        {
                            td = new TableCell();
                            tr.Cells.Add(td);
                            td.ColumnSpan = 2;
                            td.CssClass = "SessionFlowHistory_Heading";
                            td.Text = string.Format("{2} <b>{0}</b> in the last {1} hours", 
                                UrlReferrer,
                                Hours.ToString(),
                                Text);
                        }
                        else
                        {
                            td = new TableCell();
                            tr.Cells.Add(td);
                            td.ColumnSpan = 2;
                            td.CssClass = "SessionFlowHistory_Heading";
                            td.Text = string.Format("{2} <b>{0}</b> {1}",
                                UrlReferrer,
                                DateRange,
                                Text);
                        }
                    }


                    if (UrlMode == Mode.ShowRequestedUrls)
                    {
                        xxxxxxxx = RequestKeys.RequestedUrl;
                        tooooltip = "View recent HTTP logs for this URL";
                    }
                    else
                    {
                        xxxxxxxx = RequestKeys.RefererUrl;
                        tooooltip = "View recent HTTP logs for this Referrer";
                    }


                    string url;
                    for (int i = 0; i < SessionFlowHistory.Count; i++)
                    {
                        //url = SessionFlowHistory[i].Text.Replace(WebUtilities.FullyQualifiedApplicationRoot(), "");
                        url = SessionFlowHistory[i].Text;


                        tr = new TableRow();
                        tblHttpSessionFlow.Controls.Add(tr);
                        tr.Attributes.Add("onMouseOver", "this.className='simpleMouseOverState';");
                        tr.Attributes.Add("onMouseOut", "this.className='';");

                        td = new TableCell();
                        tr.Cells.Add(td);


                        if (url.Equals(string.Empty))
                        {
                            td.Text = "[accessed directly]";
                        }
                        else
                        {
                            hyp = new HyperLink();
                            hyp.ToolTip = tooooltip;
                            hyp.Text = url;
                            hyp.NavigateUrl = string.Format("{0}/{1}?{2}={3}",
                                WebUtilities.FullyQualifiedApplicationRoot(),
                                PageURLs.ViewHttpLogs,
                                xxxxxxxx,
                                url);
                            //http://localhost/Morphfolia.Web/morphfolia/_publishing/ViewHttpLogs.aspx

                            td.Controls.Add(hyp);
                        }


                        td.CssClass = "SessionFlowHistory_Url";

                        td = new TableCell();
                        tr.Cells.Add(td);
                        td.Text =  SessionFlowHistory[i].Number.ToString();
                        td.CssClass = "SessionFlowHistory_NumberOfHitsOnDestination";
                        td.HorizontalAlign = HorizontalAlign.Right;
                    }
                }

                tblHttpSessionFlow.RenderControl(writer);
            }
        }
    }

}