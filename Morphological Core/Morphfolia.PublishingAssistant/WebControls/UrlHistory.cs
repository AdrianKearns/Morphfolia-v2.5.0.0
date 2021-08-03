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
    public class UrlHistory : WebControl, INamingContainer
    {
        private Panel pnlUrlHistory;
        //private Table tblHttpSessionFlow;
        //private TableRow tr;
        //private TableCell td;
        //private HyperLink hyp;
        //private string xxxxxxxx;
        //private string tooooltip;
        Label lblX;
        Label lblText;
        Label lblTotals;

        public HttpLogUrlReportInfo urlHistoryData;

        //public HttpLogUrlReportInfoCollection

        ///// <summary>
        ///// The URL to look for traffic aganist.
        ///// </summary>
        ///// <example>http://www.mysite.geek/default.aspx</example>
        //public string UrlReferrer
        //{
        //    get { return urlReferrer; }
        //    set { urlReferrer = value; }
        //}



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
                return pnlUrlHistory.CssClass;
            }
            set
            {
                EnsureChildControls();
                pnlUrlHistory.CssClass = value;
            }
        }



        protected override void CreateChildControls()
        {
            //base.CreateChildControls();

            //tblHttpSessionFlow = new Table();
            //Controls.Add(tblHttpSessionFlow);
            ////tblHttpSessionFlow.Attributes.Add("border", "1");
            //tblHttpSessionFlow.CellPadding = 5;
            //tblHttpSessionFlow.CellSpacing = 0;

            pnlUrlHistory = new Panel();
            Controls.Add(pnlUrlHistory);

            lblX = new Label();
            Controls.Add(lblX);
            pnlUrlHistory.Controls.Add(lblX);

            lblText = new Label();
            Controls.Add(lblText);
            pnlUrlHistory.Controls.Add(lblText);

            lblTotals = new Label();
            Controls.Add(lblTotals);
            pnlUrlHistory.Controls.Add(lblTotals);
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Visible)
            {
                EnsureChildControls();

                lblText.Text = string.Format(" &nbsp; {0}", Text);

                lblX.Text = string.Format("<br>URL {0}<br>{1} to {2}",
                    urlHistoryData.TargetUrl,
                    urlHistoryData.PeriodStart.ToString(),
                    urlHistoryData.PeriodEnd.ToString());

                if (urlHistoryData.GrandTotal == 0)
                {
                    lblTotals.Text = string.Format("<br>No traffice for Url &nbsp; Total Hits: {0}",
                        urlHistoryData.GrandTotal);
                }
                else
                {
                    lblTotals.Text = string.Format("<br>Url Hits: {0} &nbsp; Referrer: {1} &nbsp; Total Hits: {2}", 
                        urlHistoryData.TotalsHitsByReferrer,
                        urlHistoryData.TotalHitsAsReferrer,
                        urlHistoryData.GrandTotal);
                }

                base.RenderContents(writer);
            }
        }
    }

}