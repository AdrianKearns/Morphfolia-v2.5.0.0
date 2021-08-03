// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Morphfolia.Business.Logs;


namespace Morphfolia.Web._publishing
{
	/// <summary>
	/// Summary description for ResetSearchIndex.
	/// </summary>
	public partial class ResetSearchIndex : System.Web.UI.Page
	{
        public class ParameterKeys
        {
            public const string IndexAction = "IndexAction";
            public const string Id = "id";
        }

        public class ParameterValues
        {
            public class IndexAction
            {
                public const string IndexSite = "indexsite";
                public const string IndexPage = "indexpage";
                public const string IndexContent = "indexcontent";
            }
        }

        private Morphfolia.Business.ContentIndexer contentIndexer;
        private Morphfolia.Common.ContentIndexerActivityMonitor contentIndexerActivityMonitor;

        int id;
        string indexAction;
        //string tempRemoveUnwantedWords;
        //bool removeUnwantedWords = false;


        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);

            // Put user code to initialize the page here
            contentIndexerActivityMonitor = new Morphfolia.Common.ContentIndexerActivityMonitor();
            contentIndexer = new Morphfolia.Business.ContentIndexer();
            contentIndexer.ContentIndexerActivityMonitor = contentIndexerActivityMonitor;

            contentIndexerActivityMonitor.GeneralActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.GeneralActivityHandler(f_GeneralActivityEvent);
            contentIndexerActivityMonitor.PageActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.PageActivityHandler(f_PageActivityEvent);
            contentIndexerActivityMonitor.ContentActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.ContentActivityHandler(f_ContentActivityEvent);
            contentIndexerActivityMonitor.DataActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.DataActivityHandler(f_DataActivityEvent);

            Context.Response.Buffer = true;
            Context.Server.ScriptTimeout = 600;  // seconds.
        }


		protected void Page_Load(object sender, System.EventArgs e)
		{
			EmitHtmlHead();

            string tempId = Morphfolia.PublishingSystem.WebUtilities.GetRequestParamValue(ParameterKeys.Id);
            id = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
            try
            {
                id = int.Parse(tempId);
            }
            catch
            {
            }

            indexAction = Morphfolia.PublishingSystem.WebUtilities.GetRequestParamValue(ParameterKeys.IndexAction);

            switch (indexAction.ToLower())
            {
                case ParameterValues.IndexAction.IndexContent:
                    lblIntendedAction.Text = string.Format("Ready to index Content Item {0}.", id.ToString());
                    break;

                case ParameterValues.IndexAction.IndexPage:
                    lblIntendedAction.Text = string.Format("Ready to index Page {0}.", id.ToString());
                    break;

                case ParameterValues.IndexAction.IndexSite:
                    lblIntendedAction.Text = "Ready to index the whole site.";
                    break;
            }
        }


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion



		private void EmitHtmlHead()
		{
            Context.Response.Write("<HTML><HEAD><title>Reset Search Index</title> \n");

            Context.Response.Write("<style> \n");
            Context.Response.Write("body { FONT-SIZE: 11px; FONT-FAMILY: Verdana; TEXT-DECORATION: none; } \n");
            Context.Response.Write(".PageIndexingMsg { color: green; margin-top: 15px; margin-left: 1em; } \n");
            Context.Response.Write(".ContentIndexingMsg { color: red; margin-top: 4px; margin-left: 2em; } \n");
            Context.Response.Write(".DataIndexingMsg { color: #003399; margin-top: 4px; margin-left: 2em; } \n");
            Context.Response.Write(".GeneralIndexingMsg { color: blue; margin-top: 15px; } \n");
            Context.Response.Write("</style> \n");

            Context.Response.Write("</HEAD>\n");

            Context.Response.Write("<script language=javascript src='../JavaScript/ResetSearchIndexHelper.js'></script> \n");

            Context.Response.Write("<body onLoad=\"CancelResetSearchIndexHelperInterval();\"> \n");
            //Context.Response.Write("<body> \n");

			Context.Response.Flush();
		}


        private void IndexContent(int contentId, bool removeUnwantedWords)
        {
            contentIndexer.IndexContentItem(contentId, removeUnwantedWords);
        }


        private void IndexPage(int pageId, bool removeUnwantedWords)
        {
            contentIndexer.IndexPage(pageId, removeUnwantedWords);
        }


        private void IndexSite(bool removeUnwantedWords)
		{
            Literal1.Text = string.Format("<pre>{0}</pre>", base.Context.Server.HtmlEncode(contentIndexer.IndexSiteContent(removeUnwantedWords)));
        }



        void f_DataActivityEvent(object sender, Morphfolia.Common.GeneralContentIndexerEventArgs fe)
        {
            Context.Response.Write(string.Format("<div class='DataIndexingMsg'>{0}</div>\n", Context.Server.HtmlEncode(fe.Message)));
            Context.Response.Flush();
        }

        void f_WordActivityEvent(object sender, Morphfolia.Common.GeneralContentIndexerEventArgs fe)
        {
            Context.Response.Write(string.Format("{0} ", Context.Server.HtmlEncode(fe.Message)));
            Context.Response.Flush();
        }

        void f_ContentActivityEvent(object sender, Morphfolia.Common.GeneralContentIndexerEventArgs fe)
        {
            Context.Response.Write(string.Format("<div class='ContentIndexingMsg'>{0}</div>\n", Context.Server.HtmlEncode(fe.Message)));
            Context.Response.Flush();
        }

        void f_PageActivityEvent(object sender, Morphfolia.Common.GeneralContentIndexerEventArgs fe)
        {
            Context.Response.Write(string.Format("<div class='PageIndexingMsg'>{0}</div>\n", Context.Server.HtmlEncode(fe.Message)));
            Context.Response.Flush();
        }

        void f_GeneralActivityEvent(object sender, Morphfolia.Common.GeneralContentIndexerEventArgs fe)
        {
            Context.Response.Write(string.Format("<div class='GeneralIndexingMsg'>{0}</div>\n", Context.Server.HtmlEncode(fe.Message)));
            Context.Response.Flush();
        }


        protected void btnStartIndexing_Click(object sender, EventArgs e)
        {
            bool removeUnwantedWords = chkbxRemoveUnWantedWords.Checked;

            switch (indexAction.ToLower())
            {
                case ParameterValues.IndexAction.IndexSite:
                    IndexSite(removeUnwantedWords);
                    Auditor.LogAuditEntry(Morphfolia.Common.Constants.SystemTypeValues.NullInt, "Search Indexes", "Indexed site.");
                    break;

                case ParameterValues.IndexAction.IndexPage:
                    IndexPage(id, removeUnwantedWords);
                    Auditor.LogAuditEntry(Morphfolia.Common.Constants.SystemTypeValues.NullInt, "Search Indexes", string.Format("Indexed Page {0}.", id));
                    break;

                case ParameterValues.IndexAction.IndexContent:
                    IndexContent(id, removeUnwantedWords);
                    Auditor.LogAuditEntry(Morphfolia.Common.Constants.SystemTypeValues.NullInt, "Search Indexes", string.Format("Indexed Content {0}.", id));
                    break;

                default:
                    break;
            }
        }
}
}