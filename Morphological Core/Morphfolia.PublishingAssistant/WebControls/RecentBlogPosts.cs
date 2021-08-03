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
    /// Displays a list of recent posts, belonging to the current blog.
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class RecentBlogPosts : WebControl, INamingContainer
    {
        private Table tblRecentBlogPosts;
        private TableHeaderRow th;
        private TableHeaderCell thcMainHeading;
        private TableRow tr;
        private TableCell td;
        private HyperLink hypLinkToPost;

        protected override void CreateChildControls()
        {
            tblRecentBlogPosts = new Table();
            Controls.Add(tblRecentBlogPosts);
            tblRecentBlogPosts.ID = "tblRecentBlogPosts";
            tblRecentBlogPosts.CellPadding = 5;
            tblRecentBlogPosts.CellSpacing = 0;
            //tblRecentBlogPosts.Attributes.Add("border", "1");
            tblRecentBlogPosts.Width = Unit.Percentage(100);
            tblRecentBlogPosts.CssClass = "FunctionalArea";

            th = new TableHeaderRow();
            tblRecentBlogPosts.Controls.Add(th);

            thcMainHeading = new TableHeaderCell();
            th.Cells.Add(thcMainHeading);
            thcMainHeading.Text = "Recent Posts";
        }



        public RecentBlogPosts()
        {
        }

        public RecentBlogPosts(int maxNumberOfPostsToListAsRecent)
        {
            MaxNumberOfPostsToListAsRecent = maxNumberOfPostsToListAsRecent;
        }

        private int maxNumberOfPostsToListAsRecent = 5;
        public int MaxNumberOfPostsToListAsRecent
        {
            get { return maxNumberOfPostsToListAsRecent; }
            set { 
                maxNumberOfPostsToListAsRecent = value;

                if (maxNumberOfPostsToListAsRecent < 1)
                {
                    maxNumberOfPostsToListAsRecent = 5;
                }
            }
        }

        public void SetMaxNumberOfPostsToListAsRecent(string numberAsString)
        {
            if (numberAsString.Equals(string.Empty))
            {
                MaxNumberOfPostsToListAsRecent = 5;
            }
            else
            {
                int i;
                if (int.TryParse(numberAsString, out i))
                {
                    MaxNumberOfPostsToListAsRecent = i;
                }
                else
                {
                    MaxNumberOfPostsToListAsRecent = 5;
                }
            }
        }



        private Business.Blogging.Blog blog;
        public Business.Blogging.Blog Blog
        {
            get { return blog; }
            set { blog = value; }
        }


        //private ContentListInfoCollection posts = new ContentListInfoCollection();
        //public ContentListInfoCollection Posts
        //{
        //    get { return posts; }
        //    set { posts = value; }
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


        //private bool showPostFromAllBlogs = true;
        //public bool ShowPostFromAllBlogs
        //{
        //    get{ return showPostFromAllBlogs; }
        //    set{ showPostFromAllBlogs = value; }
        //}

        private ContentListInfoCollection _posts = null;
        private ContentListInfoCollection Posts
        {
            get
            {
                if (_posts == null)
                {
                    _posts = this.Blog.GetListOfPostsForCurrentBlog(MaxNumberOfPostsToListAsRecent);
                }
                return _posts;
            }
        }


        private void Populate()
        {
            if (Posts.Count == 0)
            {
                tr = new TableRow();
                tblRecentBlogPosts.Controls.Add(tr);

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = "No recent posts.";
            }
            else
            {
                //if (ShowPostFromAllBlogs)
                //{
                foreach (ContentListInfo post in Posts)
                {
                    tr = new TableRow();
                    tblRecentBlogPosts.Controls.Add(tr);

                    td = new TableCell();
                    tr.Cells.Add(td);

                    hypLinkToPost = new HyperLink();
                    td.Controls.Add(hypLinkToPost);
                    hypLinkToPost.Text = post.Note;
                    hypLinkToPost.NavigateUrl = Blogging.BloggingHelpers.CreateUrlToPostByTitle(this.Blog.Title, post);

                    //http://localhost/Morphfolia.Web/blogs/blogtest001/aaa.aspx
                    //hypLinkToPost.NavigateUrl = string.Format("{0}/blogs/{1}/{2}.aspx",
                    //    WebUtilities.VirtualApplicationRoot(),
                    //    post.PageID,
                    //    post.ContentID);

                    hypLinkToPost.ToolTip = Business.Blogging.BloggingUtilities.BlogFriendlyPostedDateMessage(post.LastModified, post.LastModifiedBy);
                }
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                Populate();
                tblRecentBlogPosts.RenderControl(writer);
            }
        }
    }
}