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

namespace Morphfolia.PublishingSystem.WebControls
{
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class BlogPostsByTag : WebControl, INamingContainer
    {
        public BlogPostsByTag(string tag)
        {
            Tag = tag;
            Links = Business.StaticCustomPropertyHelper.GetBlogPostsForTag(Tag);

            Logging.Logger.LogVerboseInformation("BlogPostsByTag - number of matching posts", Links.Count.ToString());
        }


        private Table tblBlogPostsByTag;
        private TableHeaderRow th;
        private TableHeaderCell thcMainHeading;
        private TableRow tr;
        private TableCell td;


        public string Heading
        {
            get
            {
                EnsureChildControls();
                return thcMainHeading.Text;
            }
            set
            {
                EnsureChildControls();
                thcMainHeading.Text = value;
            }
        }

        private string tag = string.Empty;
        /// <summary>
        /// The Tag that we want to see posts for.
        /// </summary>
        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }


        private SearchResultInfoCollection links = new SearchResultInfoCollection();
        /// <summary>
        /// A collection of posts that have been tagged with the specified Tag.
        /// </summary>
        public SearchResultInfoCollection Links
        {
            get { return links; }
            set { links = value; }
        }


        protected override void CreateChildControls()
        {
            tblBlogPostsByTag = new Table();
            Controls.Add(tblBlogPostsByTag);
            tblBlogPostsByTag.ID = "tblBlogPostsByTag";
            tblBlogPostsByTag.CellPadding = 5;
            tblBlogPostsByTag.CellSpacing = 0;
            //tblBlogFeeds.Attributes.Add("border", "1");
            tblBlogPostsByTag.Width = Unit.Percentage(100);
            //tblBlogPostsByTag.CssClass = "FunctionalArea";

            th = new TableHeaderRow();
            tblBlogPostsByTag.Controls.Add(th);

            thcMainHeading = new TableHeaderCell();
            th.Cells.Add(thcMainHeading);
            thcMainHeading.Text = "Recent Posts";
        }



        private HyperLink hypMainLink;
        private HyperLink hypFullUrl;



        private string _virtualApplicationRoot = null;
        private string VirtualApplicationRoot
        {
            get
            {
                if (_virtualApplicationRoot == null)
                {
                    _virtualApplicationRoot = WebUtilities.VirtualApplicationRoot();
                }
                return _virtualApplicationRoot;
            }
        }


        private void PopulateControl()
        {
            Logging.Logger.LogVerboseInformation("BlogPostsByTag.PopulateControl", "Invoked");

            thcMainHeading.Text = string.Format("Blog Posts tagged with '{0}'", Tag);

            if (Links.Count == 0)
            {
                tr = new TableRow();
                tblBlogPostsByTag.Rows.Add(tr);

                td = new TableCell();
                tr.Cells.Add(td);

                td.Text = string.Format("Sorry, no blog posts were found that are tagged with '{0}'.", Tag);
            }
            else
            {
                tr = new TableRow();
                tblBlogPostsByTag.Rows.Add(tr);

                td = new TableCell();
                tr.Cells.Add(td);

                if (Links.Count == 1)
                {
                    td.Text = string.Format("1 blog post about '{0}'.", Tag);
                }
                else
                {
                    td.Text = string.Format("{0} blog posts about '{1}'.", Links.Count.ToString(), Tag);
                }


                foreach (SearchResultInfo searchResultInfo in Links)
                {
                    tr = new TableRow();
                    tblBlogPostsByTag.Rows.Add(tr);
                    td = new TableCell();
                    tr.Cells.Add(td);

                    hypMainLink = new HyperLink();
                    td.Controls.Add(hypMainLink);
                    hypMainLink.Text = searchResultInfo.ContentNote;
                    hypMainLink.CssClass = "searchResults_MainLink";
                    hypMainLink.NavigateUrl = Blogging.BloggingHelpers.CreateUrlToBlogPostByTitle(searchResultInfo);



                    tr = new TableRow();
                    tblBlogPostsByTag.Rows.Add(tr);
                    td = new TableCell();
                    tr.Cells.Add(td);

                    hypFullUrl = new HyperLink();
                    td.Controls.Add(hypFullUrl);
                    hypFullUrl.NavigateUrl = hypMainLink.NavigateUrl;
                    hypFullUrl.Text = hypMainLink.NavigateUrl;
                    hypFullUrl.CssClass = "searchResults_FullUrlLink";

                    tr = new TableRow();
                    tblBlogPostsByTag.Rows.Add(tr);
                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = string.Format("Last modified: {0} by {1}", searchResultInfo.LastModified.ToString(), searchResultInfo.LastModifiedBy);
                    td.CssClass = "searchResults_lastUpdated";


                    tr = new TableRow();
                    tblBlogPostsByTag.Rows.Add(tr);
                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = string.Format("Blogged in <a href='{0}/{1}'>{2}</a>",
                        VirtualApplicationRoot,
                        searchResultInfo.Url,
                        searchResultInfo.Title); ;



                    tr = new TableRow();
                    tblBlogPostsByTag.Rows.Add(tr);
                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.CssClass = "searchResults_description";
                    if (searchResultInfo.Description.Length > 1003)
                    {
                        td.Text = string.Format("{0}...<br>&nbsp;", searchResultInfo.Description.Substring(0, 1000));
                    }
                    else
                    {
                        td.Text = string.Format("{0}<br>&nbsp;", searchResultInfo.Description);
                    }
                }               
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            Logging.Logger.LogVerboseInformation("BlogPostsByTag.RenderContents", "Invoked");

            if (Visible)
            {
                PopulateControl();
                base.RenderContents(writer);
            }
        }
    }
}