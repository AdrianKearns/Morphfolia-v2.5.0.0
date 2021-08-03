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
    /// <summary>
    /// Displays a list of the available blogs.
    /// </summary>
    /// <remarks>This control gets its own data automatically.</remarks>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class AvailableBlogs : WebControl, INamingContainer
    {
        private Table tblAvailableBlogs;
        private TableHeaderRow th;
        private TableHeaderCell thcMainHeading;
        private TableRow tr;
        private TableCell td;
        private HyperLink hypBlog;

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

        protected override void CreateChildControls()
        {
            tblAvailableBlogs = new Table();
            Controls.Add(tblAvailableBlogs);
            tblAvailableBlogs.ID = "tblAvailableBlogs";
            tblAvailableBlogs.CellPadding = 5;
            tblAvailableBlogs.CellSpacing = 0;
            //tblBlogFeeds.Attributes.Add("border", "1");
            tblAvailableBlogs.Width = Unit.Percentage(100);
            tblAvailableBlogs.CssClass = "FunctionalArea";

            th = new TableHeaderRow();
            tblAvailableBlogs.Controls.Add(th);

            thcMainHeading = new TableHeaderCell();
            th.Cells.Add(thcMainHeading);
            thcMainHeading.Text = "Available Blogs";
        }


        private void Populate()
        {
            EnsureChildControls();

            PageInfo blog;
            PageInfoCollection blogs = Business.Blogging.BloggingUtilities.GetListOfAvailableBlogs();

            if (blogs.Count == 0)
            {
                tr = new TableRow();
                tblAvailableBlogs.Controls.Add(tr);

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = "No Blogs Found.";
            }
            else
            {
                for (int i = 0; i < blogs.Count; i++)
                {
                    blog = blogs[i];

                    tr = new TableRow();
                    tblAvailableBlogs.Controls.Add(tr);

                    td = new TableCell();
                    tr.Cells.Add(td);

                    hypBlog = new HyperLink();
                    Controls.Add(hypBlog);
                    td.Controls.Add(hypBlog);
                    hypBlog.Text = blog.Title;
                    hypBlog.NavigateUrl = string.Format("{0}/{1}",
                       WebUtilities.VirtualApplicationRoot(),
                       blog.Url);
                }
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                Populate();

                tblAvailableBlogs.RenderControl(writer);
            }
        }
    }
}