// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Displays a pair of links to an RSS 2.0 and Atom 1.0 XML feed.
    /// </summary>
    /// <remarks>This control gets its own data automatically.</remarks>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class BlogTagCloud : WebControl, INamingContainer
    {
        private Table tblBlogTagCloud;
        private TableHeaderRow th;
        private TableHeaderCell thcMainHeading;
        private TableRow tr;
        private TableCell td;


        public enum SortType { Alphabetically, ByUse };

        private SortType sortTagsBy = SortType.Alphabetically;
        public SortType SortTagsBy
        {
            get { return sortTagsBy; }
            set { sortTagsBy = value; }
        }


        private int blogId = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
        /// <summary>
        /// Set this property to restrict the tag-cloud to a specific blog, 
        /// otherwise tags for all live blogs are shown.
        /// </summary>
        public int BlogId
        {
            get { return blogId; }
            set { blogId = value; }
        }


        //public enum DisplayOptions { 
        //    /// <summary>
        //    /// Displays all tags the same size.
        //    /// </summary>
        //    UniformSize, 
        //    /// <summary>
        //    /// Displays tags in different sizes: most common are largest, least common are smallest.
        //    /// </summary>
        //    DifferentSizes }


        //private DisplayOptions displayOption = DisplayOptions.UniformSize;
        //public DisplayOptions DisplayOption
        //{
        //    get { return displayOption; }
        //    set { displayOption = value; }
        //}


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


        private void AppendNewTagWithUniformSize(GenericStringIntInfo tagInfo, StringBuilder output)
        {
            int tagCount = tagInfo.Number;

            if (tagCount == 1)
            {
                output.AppendFormat("<span style='white-space:nowrap;'><a href='{1}/blogs/postsByTag.aspx?{3}={2}'>{2}</a> (1)&nbsp;</span> {0}", 
                    System.Environment.NewLine,
                    VirtualApplicationRoot,
                    tagInfo.Text,
                    Morphfolia.PublishingSystem.HttpHandlers.ViewBlogPostListByTag.QueryStringKeys.QueriedTag);
            }
            else
            {
                output.AppendFormat("<span style='white-space:nowrap;'><a href='{1}/blogs/postsByTag.aspx?{4}={2}'>{2}</a> ({3})&nbsp;</span> {0}",
                    System.Environment.NewLine,
                    VirtualApplicationRoot,
                    tagInfo.Text,
                    tagCount.ToString(),
                    Morphfolia.PublishingSystem.HttpHandlers.ViewBlogPostListByTag.QueryStringKeys.QueriedTag);
            }
        }


        protected override void CreateChildControls()
        {
            tblBlogTagCloud = new Table();
            Controls.Add(tblBlogTagCloud);
            tblBlogTagCloud.ID = "tblBlogTagCloud";
            tblBlogTagCloud.CellPadding = 5;
            tblBlogTagCloud.CellSpacing = 0;
            //tblBlogFeeds.Attributes.Add("border", "1");
            tblBlogTagCloud.Width = Unit.Percentage(100);
            tblBlogTagCloud.CssClass = "FunctionalArea";

            th = new TableHeaderRow();
            tblBlogTagCloud.Controls.Add(th);

            thcMainHeading = new TableHeaderCell();
            th.Cells.Add(thcMainHeading);
            thcMainHeading.Text = "Tags";


            tr = new TableRow();
            tblBlogTagCloud.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
        }


        private void PopulateForUniformSize()
        {
            GenericStringIntInfoCollection tags;
            if (BlogId == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                if (SortTagsBy == SortType.Alphabetically)
                {
                    tags = Business.StaticCustomPropertyHelper.GetAllTagsForAllLiveBlogsOrderedAlphabetically();
                }
                else
                {
                    tags = Business.StaticCustomPropertyHelper.GetAllTagsForAllLiveBlogsOrderedByOccurrance();
                }
            }
            else
            {
                if (SortTagsBy == SortType.Alphabetically)
                {
                    tags = Business.StaticCustomPropertyHelper.GetAllTagsForLiveBlogOrderedAlphabetically(BlogId);
                }
                else
                {
                    tags = Business.StaticCustomPropertyHelper.GetAllTagsForLiveBlogOrderedByOccurrance(BlogId);
                }
            }

            if (tags.Count == 0)
            {
                Visible = false;
                Logging.Logger.LogInformation("BlogTagCloud WebControl", "No Tags Found.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (GenericStringIntInfo tag in tags)
                {
                    AppendNewTagWithUniformSize(tag, sb);
                }
                td.Text = sb.ToString();
            }
        }




        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                //if (DisplayOption == DisplayOptions.UniformSize)
                //{
                PopulateForUniformSize();
                //}
                //else
                //{
                //    PopulateForDifferentSizes();
                //}
                base.RenderContents(writer);
            }
        }
    }
}