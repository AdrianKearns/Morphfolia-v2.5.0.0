// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Morphfolia.WebControls.Utilities;
using System.Collections.Specialized;

namespace Morphfolia.WebControls
{
    /// <summary>
    /// Summary description for HtmlHead.
    /// </summary>
    public class HtmlHead : System.Web.UI.WebControls.WebControl
    {
        private Morphfolia.Business.Page _Page;


        public HtmlHead()
        {
            this._Page = null;
        }

        public HtmlHead(Morphfolia.Business.Page page)
        {
            this._Page = page;

            string temp = this._Page.Keywords;
            if (!temp.Equals(string.Empty))
            {
                MetaTags.Add(string.Format("<meta name='keywords' content='{0}'>", temp));
            }

            temp = this._Page.Description;
            if (!temp.Equals(string.Empty))
            {
                MetaTags.Add(string.Format("<meta name='Description' content='{0}'>", temp));
            }

            MetaTags.Add(string.Format("<meta name='Author' content='{0}'>", this._Page.LastModifiedBy));
            MetaTags.Add(string.Format("<meta name='LastModified' content='{0}'>", this._Page.LastModified));
        }


        public HtmlHead(string title)
        {
            this._Page = new Morphfolia.Business.Page();
            this._Page.Title = title;
            this._Page.Keywords = string.Empty;
            this._Page.Description = string.Empty;
            this._Page.LastModified = DateTime.Now;

            string userIdentity = "[?]";
            if (System.Web.HttpContext.Current != null)
            {
                userIdentity = System.Web.HttpContext.Current.User.Identity.Name;
                if (userIdentity.Equals(string.Empty))
                {
                    userIdentity = "Anonymous";
                }
            }
            this._Page.LastModifiedBy = userIdentity;

            MetaTags.Add(string.Format("<meta name='Author' content='{0}'>", this._Page.LastModifiedBy));
            MetaTags.Add(string.Format("<meta name='LastModified' content='{0}'>", this._Page.LastModified));
        }



        private string styleSheet = "siteStyle.css";
        /// <summary>
        /// The name of the Style Sheet file (path optional).
        /// </summary>
        /// <example>
        /// "siteStyle.css" or 
        /// "myfolder/siteStyle.css"
        /// </example>
        public string StyleSheet
        {
            get
            {
                if (styleSheet == null)
                {
                    styleSheet = "siteStyle.css";
                }

                if (styleSheet.Equals(string.Empty))
                {
                    styleSheet = "siteStyle.css";
                }

                return styleSheet;
            }
            set { styleSheet = value; }
        }


        private bool outputHEADTag = true;
        public bool OutputHEADTag
        {
            get { return outputHEADTag; }
            set { outputHEADTag = value; }
        }

        private bool outputTITLETag = true;
        public bool OutputTITLETag
        {
            get { return outputTITLETag; }
            set { outputTITLETag = value; }
        }



        private StringCollection metaTags = null;
        /// <summary>
        /// Allows you to add <META> tags, such as: <meta name='LastModified' content='6/07/2009 12:44:57 p.m.'>
        /// Add the complete tag as a string to the MetaTags StringCollection.
        /// </summary>
        public StringCollection MetaTags
        {
            get
            {
                if (metaTags == null)
                {
                    metaTags = new StringCollection();
                    metaTags.Add("<meta name='Powered By' content='Morphfolia'>");
                    metaTags.Add("<meta name='Originally Developed By' content='Morphological.geek.nz'>");
                }
                return metaTags;
            }
            set { metaTags = value; }
        }





        /// <summary> 
        /// Render this control to the output parameter specified.
        /// </summary>
        /// <param name="output"> The HTML writer to write out to </param>
        protected override void Render(HtmlTextWriter output)
        {
            if (this._Page != null)
            {
                output.Write("<head>{0}{0}", Environment.NewLine);

                if (OutputTITLETag)
                {
                    output.Write("<title>{0}</title>{1}{1}", this._Page.Title, Environment.NewLine);
                }



                foreach (string metaTag in MetaTags)
                {
                    output.Write("{0}{1}", metaTag, Environment.NewLine);
                }
            }

            output.Write("<LINK href='{0}/{1}' rel='stylesheet' type='text/css'>{2}{2}",
                WebUtilities.VirtualApplicationRoot(),
                StyleSheet,
                Environment.NewLine);

            //			output.WriteLine("ApplicationPath = [{0}]<br>", HttpContext.Current.Request.ApplicationPath );
            //			output.WriteLine("Url = [{0}]<br>", HttpContext.Current.Request.Url );
            //			output.WriteLine("ToString = [{0}]<br>", HttpContext.Current.Request.ToString() );
            //			output.WriteLine("Path = [{0}]<br>", HttpContext.Current.Request.Path );
            //			output.WriteLine("server_name = [{0}]<br>", HttpContext.Current.Request.ServerVariables["server_name"].ToString() );

            if (OutputHEADTag)
            {
                output.Write("</head>");
            }
        }
    }
}
