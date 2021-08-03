// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Morphfolia.Business.Blogging;
using Morphfolia.Common.Info;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Interfaces;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;
using Morphfolia.PublishingSystem.Skins;

namespace Morphfolia.PublishingSystem.Layouts
{
    /// <summary>
    /// Summary description for SimpleBanner.
    /// </summary>
    [IsLayoutWebControl]
    public class BlogPageLayout : BasePageLayout, INamingContainer
    {
        private ISkinProvider skinProvider;

        private PlaceHolder headerPlaceHolder;
        private PlaceHolder contentPlaceHolder;
        private PlaceHolder footerPlaceHolder;

        private WebControl tblHeader;
        private Table tblContent;
        private WebControl tblFooter;
        private Literal BeginFormTag;
        private Literal EndFormTag;
        protected TableRow tr;

        protected TableCell tdMainContent;
        protected Panel pnlBlogContent;
        protected Panel pnlSupplementaryPageNotes;
        protected TableCell tdBlogSideBar;

        protected WebControls.BlogFeeds blogFeeds;
        protected WebControls.BlogTagCloud blogTagCloud;
        protected WebControls.RecentBlogPosts recentBlogPosts;
        protected WebControls.AvailableBlogs availableBlogs;
        protected Image imgMinimumWidth;

        //private Business.Blogging.Blog CurrentBlog;
        private Morphfolia.Common.WebControlCollection childControls;
        public override Morphfolia.Common.WebControlCollection ChildControls
        {
            get
            {
                EnsureChildControls();
                if (childControls == null)
                {
                    childControls = new Morphfolia.Common.WebControlCollection();
                }
                return childControls;
            }
            set
            {
                childControls = value;
            }
        }


        private Blog currentBlog;
        public Blog CurrentBlog
        {
            get { return currentBlog; }
            set { currentBlog = value; }
        }


        private ContentInfo currentPost;
        public ContentInfo CurrentPost
        {
            get { return currentPost; }
            set { currentPost = value; }
        }



        public BlogPageLayout()
        {
            //skinProviderFactory = new SkinProviderFactory();
        }


        public BlogPageLayout(WebControl childWebControl)
        {
            //skinProviderFactory = new SkinProviderFactory();
            ChildControls.Add(childWebControl);
        }


        private CustomPropertyInstanceInfoCollection CustomProperties = null;

        public override void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            EnsureChildControls();

            Logging.Logger.LogVerboseInformation("BlogPageLayout.SetCustomProperties()", "Invoked.");

            CustomProperties = customProperties;

            System.Text.StringBuilder sbC1 = new System.Text.StringBuilder();
            //string propertyType;
            string propertyKey;
            string propertyValue;
            //int temp;


            if (CustomProperties != null)
            {
                skinProvider = base.LoadSkinProvider(customProperties, new Skins.SimpleSkin());

                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    //propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    switch (propertyKey)
                    {
                        case Morphfolia.PageLayoutAndSkinAssistant.Constants.CommonPropertyKeys.FormTemplatePresenterType:
                            FormTemplatePresenterType = propertyValue;
                            break;

                        case Morphfolia.PageLayoutAndSkinAssistant.Constants.CommonPropertyKeys.OveralWidth:
                            try
                            {
                                OveralWidth = Unit.Parse(propertyValue);
                            }
                            catch
                            {
                            }
                            break;

                        case Morphfolia.PageLayoutAndSkinAssistant.Constants.CommonPropertyKeys.OveralHorizontalAlign:
                            OveralHorizontalAlign = HorizontalAlignFromstring(propertyValue);
                            break;
                    }
                }
            }

            Logging.Logger.LogVerboseInformation("BlogPageLayout.SetCustomProperties()", "Complete.");
        }


        #region ...   Properties   ...


        private HorizontalAlign overalHorizontalAlign = HorizontalAlign.Center;
        [IsCustomProperty,
        PropertyFriendlyName(FriendlyNames.HorizontalAlignment),
        PropertyDefaultValue(DefaultValues.HorizontalAlignment),
        PropertyDescription(Descriptions.HorizontalAlignment),
        PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
        public HorizontalAlign OveralHorizontalAlign
        {
            get { return overalHorizontalAlign; }
            set { overalHorizontalAlign = value; }
        }


        private Unit overalWidth = Unit.Pixel(650);
        [IsCustomProperty,
        PropertyFriendlyName("Width"),
        PropertyDescription(Descriptions.Width),
        PropertySuggestedUsage(SuggestedUsageNotes.Width)]
        public Unit OveralWidth
        {
            get { return overalWidth; }
            set { overalWidth = value; }
        }

        private Unit blogWidth = Unit.Pixel(500);
        [IsCustomProperty,
        PropertyFriendlyName("BlogWidth"),
        PropertyDescription(Descriptions.Width),
        PropertySuggestedUsage(SuggestedUsageNotes.Width)]
        public Unit BlogWidth
        {
            get { return blogWidth; }
            set { blogWidth = value; }
        }

        private Unit blogSideBarWidth = Unit.Pixel(200);
        [IsCustomProperty,
        PropertyFriendlyName("BlogSideBarWidth"),
        PropertyDescription(Descriptions.Width),
        PropertySuggestedUsage(SuggestedUsageNotes.Width)]
        public Unit BlogSideBarWidth
        {
            get { return blogSideBarWidth; }
            set { blogSideBarWidth = value; }
        }


        private string supplementaryPageNotes = "&nbsp;";
        [IsContentContainer]
        public string SupplementaryPageNotes
        {
            get { return supplementaryPageNotes; }
            set { supplementaryPageNotes = value; }
        }



        private string tags = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Tags"),
        PropertyDescription("Define the tags which will be used to tag posts to the blog (a taxonomy), leave empty if you want let posts use any tags (a folksonomy)."),
        PropertySuggestedUsage("One tag per line, spaces permitted."),
        InputSize(Morphfolia.Common.Constants.Framework.Various.InputSizes.MultipleLine40x7)]
        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }



        private string isBlog = string.Empty;
        [IsBlog,
        PropertyFriendlyName("Is a Blog"),
        PropertyDescription("Set to 'Y' if you want this page to be treated as a blog."),
        PropertyDefaultValue("Y"),
        PropertySuggestedUsage("Y otherwise leave empty.")]
        public string IsBlog
        {
            get { return isBlog; }
            set { isBlog = value; }
        }

        private string maxNumberOfPostsToListAsRecent = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Max number of posts to display"),
        PropertyDescription("Use this property to control how many posts are listed on the 'recent-posts' area."),
        PropertyDefaultValue("5"),
        PropertySuggestedUsage("An integer (a positive round number like 1, 5 or 10).")]
        public string MaxNumberOfPostsToListAsRecent
        {
            get
            {
                //Logging.Logger.LogVerboseInformation("BlogPageLayout.NumberOfPostsToDisplay.GET", "Invoked");

                if (maxNumberOfPostsToListAsRecent.Equals(string.Empty))
                {
                    maxNumberOfPostsToListAsRecent = "5";
                }
                return maxNumberOfPostsToListAsRecent;
            }
            set
            {
                //Logging.Logger.LogVerboseInformation("BlogPageLayout.NumberOfPostsToDisplay.SET", "Invoked");

                string temp = value;
                if (temp.Equals(string.Empty))
                {
                    temp = "5";
                }
                else
                {
                    int i;
                    if (int.TryParse(temp.Trim(), out i))
                    {
                        temp = i.ToString();
                    }
                    else
                    {
                        temp = "5";
                    }
                }
                maxNumberOfPostsToListAsRecent = temp;
            }
        }


        private string showPostFromAllBlogs = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Show Posts From All Blogs"),
        PropertyDescription("Use this property to control how which posts are shown on the blogs main page, recent posts from any blog, or just ones from this blog."),
        PropertyDefaultValue("N"),
        PropertySuggestedUsage("Y or N")]
        public string ShowPostFromAllBlogs
        {
            get
            {
                return showPostFromAllBlogs;
            }
            set
            {
                string temp = value;
                if (temp.Equals(string.Empty))
                {
                    temp = "N";
                }
                else
                {
                    temp = temp.Trim().ToUpper();
                    if (temp.Equals("N"))
                    {
                        temp = "N";
                    }
                    else
                    {
                        temp = "Y";
                    }
                }
                showPostFromAllBlogs = temp;
            }
        }



        private const string SortTagCloud_Alpha = "alpha";
        private const string SortTagCloud_Use = "use";

        private string sortTagCloud = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Sort Tag-Cloud"),
        PropertyDescription("Use this property to control how the tag-cloud is sorted: alphabetically or by use (most used to least used)."),
        PropertyDefaultValue(SortTagCloud_Alpha),
        PropertySuggestedUsage("alpha or use")]
        public string SortTagCloud
        {
            get
            {
                return sortTagCloud;
            }
            set
            {
                string temp = value;
                if (temp.Equals(string.Empty))
                {
                    temp = SortTagCloud_Alpha;
                }
                else
                {
                    temp = temp.Trim().ToLower();
                    if (temp.Equals(SortTagCloud_Use))
                    {
                        temp = SortTagCloud_Use;
                    }
                    else
                    {
                        temp = SortTagCloud_Alpha;
                    }
                }
                sortTagCloud = temp;
            }
        }


        #endregion


        protected override void CreateChildControls()
        {
            Logging.Logger.LogVerboseInformation("BlogPageLayout.CreateChildControls()", "Invoked.");


            headerPlaceHolder = new PlaceHolder();
            Controls.Add(headerPlaceHolder);
            headerPlaceHolder.ID = "headerPlaceHolder";

            BeginFormTag = new Literal();
            Controls.Add(BeginFormTag);
            //td.Controls.Add( BeginFormTag );
            BeginFormTag.Text = "<form id=\"Form1\" method=\"post\" runat=\"server\">";

            tblContent = new Table();
            Controls.Add(tblContent);
            //tblContent.Attributes.Add("border", "1");
            tblContent.HorizontalAlign = HorizontalAlign.Center;
            tblContent.CellPadding = 5;
            tblContent.CellSpacing = 0;



            tr = new TableRow();
            Controls.Add(tr);
            tblContent.Rows.Add(tr);


            tdBlogSideBar = new TableCell();
            Controls.Add(tdBlogSideBar);
            tr.Cells.Add(tdBlogSideBar);
            tdBlogSideBar.VerticalAlign = VerticalAlign.Top;
            tdBlogSideBar.ID = "tdBlogSideBar";
            tdBlogSideBar.RowSpan = 2;

            blogFeeds = new Morphfolia.PublishingSystem.WebControls.BlogFeeds();
            Controls.Add(blogFeeds);
            tdBlogSideBar.Controls.Add(blogFeeds);
            blogFeeds.Width = Unit.Percentage(100);

            blogTagCloud = new Morphfolia.PublishingSystem.WebControls.BlogTagCloud();
            Controls.Add(blogTagCloud);
            tdBlogSideBar.Controls.Add(blogTagCloud);

            recentBlogPosts = new Morphfolia.PublishingSystem.WebControls.RecentBlogPosts();
            Controls.Add(recentBlogPosts);
            tdBlogSideBar.Controls.Add(recentBlogPosts);
            recentBlogPosts.Width = Unit.Percentage(100);

            availableBlogs = new Morphfolia.PublishingSystem.WebControls.AvailableBlogs();
            Controls.Add(availableBlogs);
            tdBlogSideBar.Controls.Add(availableBlogs);
            availableBlogs.Width = Unit.Percentage(100);

            imgMinimumWidth = new Image();
            Controls.Add(imgMinimumWidth);
            tdBlogSideBar.Controls.Add(imgMinimumWidth);
            imgMinimumWidth.ImageUrl = string.Format("{0}/{1}", WebUtilities.VirtualApplicationRoot(), Common.Constants.Framework.CommonImages.Spacer);
            imgMinimumWidth.Width = Unit.Pixel(250);
            imgMinimumWidth.Height = Unit.Pixel(1);


            tdMainContent = new TableCell();
            Controls.Add(tdMainContent);
            tr.Cells.Add(tdMainContent);
            tdMainContent.VerticalAlign = VerticalAlign.Top;
            tdMainContent.ID = "tdCurrentBlogPost";


            pnlBlogContent = new Panel();
            Controls.Add(pnlBlogContent);
            tdMainContent.Controls.Add(pnlBlogContent);
            pnlBlogContent.ID = "pnlBlogContent";


            pnlSupplementaryPageNotes = new Panel();
            Controls.Add(pnlSupplementaryPageNotes);
            tdMainContent.Controls.Add(pnlSupplementaryPageNotes);
            pnlSupplementaryPageNotes.ID = "pnlSupplementaryPageNotes";





            EndFormTag = new Literal();
            Controls.Add(EndFormTag);
            EndFormTag.Text = "</form>";

            contentPlaceHolder = new PlaceHolder();
            Controls.Add(contentPlaceHolder);
            contentPlaceHolder.ID = "contentPlaceHolder";

            footerPlaceHolder = new PlaceHolder();
            Controls.Add(footerPlaceHolder);
            footerPlaceHolder.ID = "footerPlaceHolder";

            Logging.Logger.LogVerboseInformation("BlogPageLayout.CreateChildControls()", "Complete.");
        }


        public override void InitializeContent()
        {
            EnsureChildControls();

            Logging.Logger.LogVerboseInformation("BlogPageLayout.InitializeContent()", "Invoked.");

            string propertyType;
            string propertyKey;
            string propertyValue;
            int temp;

            if (CustomProperties != null)
            {
                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    if (propertyType.Equals(Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT))
                    {
                        int id;
                        if (int.TryParse(CustomProperties[i].PropertyValue, out id))
                        {
                            temp = GetContentInfoIndexById(id);
                            if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                AddContentToContentContainer(pnlSupplementaryPageNotes, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            }
                        }
                    }

                    switch (propertyKey)
                    {
                        case Morphfolia.PageLayoutAndSkinAssistant.Constants.CommonPropertyKeys.FormTemplatePresenterType:
                            FormTemplatePresenterType = propertyValue;
                            break;

                        case Morphfolia.PageLayoutAndSkinAssistant.Constants.CommonPropertyKeys.OveralWidth:
                            try
                            {
                                OveralWidth = Unit.Parse(propertyValue);
                            }
                            catch
                            {
                            }
                            break;

                        case "BlogWidth":
                            try
                            {
                                BlogWidth = Unit.Parse(propertyValue);
                            }
                            catch
                            {
                            }
                            break;

                        case "BlogSideBarWidth":
                            try
                            {
                                BlogSideBarWidth = Unit.Parse(propertyValue);
                            }
                            catch
                            {
                            }
                            break;

                        case Morphfolia.PageLayoutAndSkinAssistant.Constants.CommonPropertyKeys.OveralHorizontalAlign:
                            OveralHorizontalAlign = HorizontalAlignFromstring(propertyValue);
                            break;

                        case "IsBlog":
                            IsBlog = propertyValue;
                            break;

                        case "MaxNumberOfPostsToListAsRecent":
                            MaxNumberOfPostsToListAsRecent = propertyValue;
                            break;

                        case "ShowPostFromAllBlogs":
                            ShowPostFromAllBlogs = propertyValue;
                            break;

                        case "SortTagCloud":
                            SortTagCloud = propertyValue;
                            break;
                    }
                }
            }


            if (CurrentBlog != null)
            {             
                blogFeeds.Blog = CurrentBlog;
                recentBlogPosts.SetMaxNumberOfPostsToListAsRecent(MaxNumberOfPostsToListAsRecent);
                recentBlogPosts.Blog = CurrentBlog;

                if (ShowPostFromAllBlogs.Equals("N"))
                {
                    blogTagCloud.BlogId = CurrentBlog.Id;
                }


                if (SortTagCloud == SortTagCloud_Use)
                {
                    blogTagCloud.SortTagsBy = Morphfolia.PublishingSystem.WebControls.BlogTagCloud.SortType.ByUse;
                }
                else
                {
                    blogTagCloud.SortTagsBy = Morphfolia.PublishingSystem.WebControls.BlogTagCloud.SortType.Alphabetically;
                }
            }

            Logging.Logger.LogVerboseInformation("BlogPageLayout.InitializeContent()", "Complete.");
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            Logging.Logger.LogVerboseInformation("BlogPageLayout.RenderContents()", "Invoked.");


            if (Visible)
            {
                tblHeader = skinProvider.MakePageHeader(this.Page);
                Controls.Add(tblHeader);
                headerPlaceHolder.Controls.Add(tblHeader);

                tblContent.Width = OveralWidth;
                tblContent.HorizontalAlign = OveralHorizontalAlign;
                tdBlogSideBar.Width = BlogSideBarWidth;
                imgMinimumWidth.Width = BlogSideBarWidth;
                tdMainContent.Width = BlogWidth;

                bool gotBlog = true;

                if (CurrentBlog == null)
                {
                    gotBlog = false;
                    blogFeeds.Visible = false;
                    recentBlogPosts.Visible = false;
                }


                Table tblPost;
                TableRow tr;
                TableCell tdTitle;
                TableCell tdWhoAndWhen;
                TableCell tdPost;

                tblPost = new Table();
                pnlBlogContent.Controls.Add(tblPost);
                tblPost.CellPadding = 5;
                tblPost.CellSpacing = 0;
                tblPost.CssClass = "BlogPageLayoutPostTable";
                //tblPost.Attributes.Add("border", "1");
                tblPost.Width = Unit.Percentage(100);


                if (gotBlog)
                {
                    tr = new TableRow();
                    tblPost.Rows.Add(tr);

                    tdTitle = new TableCell();
                    tr.Cells.Add(tdTitle);
                    tdTitle.CssClass = "BlogPageLayoutPostTitle";
                    tdTitle.Text = CurrentPost.Note;


                    tr = new TableRow();
                    tblPost.Rows.Add(tr);

                    tdWhoAndWhen = new TableCell();
                    tr.Cells.Add(tdWhoAndWhen);
                    tdWhoAndWhen.CssClass = "BlogPageLayoutPostWhoAndWhen";
                    tdWhoAndWhen.Text = Business.Blogging.BloggingUtilities.BlogFriendlyPostedDateMessage(
                        CurrentPost.LastModified, CurrentPost.LastModifiedBy);


                    tr = new TableRow();
                    tblPost.Rows.Add(tr);

                    tdPost = new TableCell();
                    tr.Cells.Add(tdPost);
                    CustomPropertyInstanceInfoCollection tagsUsed = Business.StaticCustomPropertyHelper.GetControlPropertiesByInstanceIDAndPropertyKey(CurrentPost.ContentID, Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CTAG);
                    tdPost.Text = string.Format("Tagged under: {0}", tagsUsed.ValuesToString());
                    //------------------------------------------------------------------

                    tr = new TableRow();
                    tblPost.Rows.Add(tr);

                    tdPost = new TableCell();
                    tr.Cells.Add(tdPost);
                    tdPost.Text = CurrentPost.Content;
                    tdPost.CssClass = "BlogPageLayoutPostContent";
                }
            }


            if (ChildControls.Count > 0)
            {
                for (int c = 0; c < ChildControls.Count; c++)
                {
                    tdMainContent.Controls.Add(ChildControls[c]);
                }
            }

            tblFooter = skinProvider.MakePageFooter(this.Page);
            Controls.Add(tblFooter);
            footerPlaceHolder.Controls.Add(tblFooter);

            Logging.Logger.LogVerboseInformation("BlogPageLayout.RenderContents()", "Ready, will now invoke base.RenderContents().");

            base.RenderContents(writer);

            Logging.Logger.LogVerboseInformation("BlogPageLayout.RenderContents()", "Complete.");

        }


        private string formTemplatePresenterType = "Morphological.Kudos.FormTemplatePresenters.LivewireProblem, Morphological.Kudos";
        public override string FormTemplatePresenterType
        {
            get
            {
                return formTemplatePresenterType;
            }
            set
            {
                formTemplatePresenterType = value;
            }
        }
    }
}