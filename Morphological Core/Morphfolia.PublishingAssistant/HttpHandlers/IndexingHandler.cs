// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web;
using Morphfolia.Common.Attributes;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
    /// <summary>
    /// Summary description for IndexingHandler
    /// </summary>
    [IsHttpHandler("When called, will start the indexing process.  Intended for admin use only.")]
    public class IndexingHandler : IHttpHandler
    {
        private Morphfolia.Business.ContentIndexer c = null;
        internal Morphfolia.Business.ContentIndexer C
        {
            get
            {
                if (c == null)
                {
                    c = new Morphfolia.Business.ContentIndexer();
                }

                return c;
            }
        }


        public bool IsReusable
        {
            get { return true; }
        }


        private Morphfolia.Business.ContentIndexer contentIndexer;

        private HttpContext Context;

        public void ProcessRequest(HttpContext context)
        {
            Context = context;

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("Morphfolia.Web.HttpHandlers.IndexingHandler", "ProcessRequest() called.");

            Context.Response.Write(string.Format("<div class='DataIndexingMsg'>Started {0}...</div>\n", DateTime.Now.ToString()));
            Context.Response.Flush();



            contentIndexer = new Morphfolia.Business.ContentIndexer();
            Context.Response.Buffer = true;


            Morphfolia.Common.ContentIndexerActivityMonitor f = new Morphfolia.Common.ContentIndexerActivityMonitor();

            f.GeneralActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.GeneralActivityHandler(f_GeneralActivityEvent);
            f.PageActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.PageActivityHandler(f_PageActivityEvent);
            f.ContentActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.ContentActivityHandler(f_ContentActivityEvent);
            //f.WordActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.WordActivityHandler(f_WordActivityEvent);
            f.DataActivityEvent += new Morphfolia.Common.ContentIndexerActivityMonitor.DataActivityHandler(f_DataActivityEvent);
            this.contentIndexer.ContentIndexerActivityMonitor = f;

            //Context.Response.Write(string.Format("<pre>{0}</pre>", Context.Server.HtmlEncode(contentIndexer.IndexPage(3))));
            contentIndexer.IndexPage(3, true);

            Context.Response.Write(string.Format("<div class='DataIndexingMsg'>Complete {0}</div>\n", DateTime.Now.ToString()));
            Context.Response.Flush();
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
    }
}