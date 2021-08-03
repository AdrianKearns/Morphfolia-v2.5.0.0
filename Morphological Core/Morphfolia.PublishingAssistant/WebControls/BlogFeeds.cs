// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Displays a pair of links to an RSS 2.0 and Atom 1.0 XML feed.
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class BlogFeeds : WebControl, INamingContainer
    {
        private Table tblBlogFeeds;
        private TableHeaderRow th;
        private TableHeaderCell thcMainHeading;
        private TableRow tr;
        private TableCell td;
        private HyperLink hypAtomFeed;
        private HyperLink hypRSSFeed;
        private Image imgFeed;
        private Label lblText;


        protected override void CreateChildControls()
        {
            tblBlogFeeds = new Table();
            Controls.Add(tblBlogFeeds);
            tblBlogFeeds.ID = "tblBlogFeeds";
            tblBlogFeeds.CellPadding = 5;
            tblBlogFeeds.CellSpacing = 0;
            //tblBlogFeeds.Attributes.Add("border", "1");
            tblBlogFeeds.Width = Unit.Percentage(100);
            tblBlogFeeds.CssClass = "FunctionalArea";

            th = new TableHeaderRow();
            tblBlogFeeds.Controls.Add(th);

            thcMainHeading = new TableHeaderCell();
            th.Cells.Add(thcMainHeading);
            thcMainHeading.Text = "Subscribe To This Blog";


            tr = new TableRow();
            tblBlogFeeds.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            hypAtomFeed = new HyperLink();
            Controls.Add(hypAtomFeed);
            td.Controls.Add(hypAtomFeed);

            imgFeed = new Image();
            Controls.Add(imgFeed);
            hypAtomFeed.Controls.Add(imgFeed);
            imgFeed.ImageUrl = string.Format("{0}/morphfolia/g/16px-Feed-icon.svg.png", WebUtilities.VirtualApplicationRoot());

            lblText = new Label();
            Controls.Add(lblText);
            hypAtomFeed.Controls.Add(lblText);
            lblText.Text = " Atom Feed";



            tr = new TableRow();
            tblBlogFeeds.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            hypRSSFeed = new HyperLink();
            Controls.Add(hypRSSFeed);
            td.Controls.Add(hypRSSFeed);

            imgFeed = new Image();
            Controls.Add(imgFeed);
            hypRSSFeed.Controls.Add(imgFeed);
            imgFeed.ImageUrl = string.Format("{0}/morphfolia/g/16px-Feed-icon.svg.png", WebUtilities.VirtualApplicationRoot());

            lblText = new Label();
            Controls.Add(lblText);
            hypRSSFeed.Controls.Add(lblText);
            lblText.Text = " RSS 2.0 Feed";
        }



        private Business.Blogging.Blog blog;
        public Business.Blogging.Blog Blog
        {
            get { return blog; }
            set { blog = value; }
        }


        private void Populate()
        {
            if (Blog == null)
            {
                Visible = false;
                Logging.Logger.LogWarning("BlogFeeds WebControl", "Feeds not shown - the Blog was not set.");
            }
            else
            {
                hypAtomFeed.NavigateUrl = string.Format("{0}/blogs/{1}/atom.ashx",
                    WebUtilities.VirtualApplicationRoot(),
                    Blog.Title);

                hypRSSFeed.NavigateUrl = string.Format("{0}/blogs/{1}/rss.ashx",
                    WebUtilities.VirtualApplicationRoot(),
                    Blog.Title);
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                Populate();
                tblBlogFeeds.RenderControl(writer);
            }
        }
    }
}