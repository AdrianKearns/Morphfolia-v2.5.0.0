// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using Morphfolia.Common.Info;
using Morphfolia.IDataProvider;
using Morphfolia.Business.Constants;

namespace Morphfolia.Business.Blogging
{
    public class Blog
    {
        private static IContentDataProvider iContentDataProvider;
        private static IContentDataProvider IContentDataProvider
        {
            get
            {
                if (iContentDataProvider == null)
                {
                    iContentDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IContentDataProvider) as IContentDataProvider;
                }
                return iContentDataProvider;
            }
        }

        private CustomPropertyHelper CustomPropertyHelper;


        internal Blog(PageInfo pageInformation)
        {
            _pageInformation = pageInformation;

            CustomPropertyHelper = new CustomPropertyHelper(_pageInformation.PageID);
        }


        private PageInfo _pageInformation;
        public PageInfo PageInformation
        {
            get
            {
                //if (_pageInformation == null)
                //{
                //    _pageInformation = PageFactory.NullPageInfo();
                //}
                return _pageInformation;
            }
        }


        private string title = string.Empty;
        /// <summary>
        /// The name of the channel. It's how people refer to your service. 
        /// If you have an HTML website that contains the same information 
        /// as your RSS file, the title of your channel should be the same 
        /// as the title of your website.
        /// </summary>
        /// <remarks>This property is part of the RSS 2.0 specification. 
        /// http://cyber.law.harvard.edu/rss/rss.html  
        /// This property is part of the Atom specification. 
        /// http://www.atomenabled.org/developers/syndication
        /// </remarks>
        public string Title
        {
            get { return PageInformation.Title; }
        }


        /// <summary>
        /// Phrase or sentence describing the channel.
        /// </summary>
        /// <remarks>This property is part of the RSS 2.0 specification. 
        /// http://cyber.law.harvard.edu/rss/rss.html
        /// </remarks>
        public string Description
        {
            get { return PageInformation.Description; }
        }


        /// <summary>
        /// RSS Spec: The URL to the HTML website corresponding to the channel. 
        /// In Morpfolia this is the underlying page.Url
        /// </summary>
        /// <remarks>This property is part of the RSS 2.0 specification. 
        /// http://cyber.law.harvard.edu/rss/rss.html  
        /// This property is part of the Atom specification. 
        /// http://www.atomenabled.org/developers/syndication
        /// </remarks>
        public string Link
        {
            get { return PageInformation.Url; }
        }



        /// <summary>
        /// The underlying Page Id (and hence the Blog Id).
        /// </summary>
        /// <remarks>This property is part of the Atom specification. 
        /// http://www.atomenabled.org/developers/syndication
        /// </remarks>
        public int Id
        {
            get { return PageInformation.PageID; }
        }


        /// <summary>
        /// Names the author of the feed.
        /// </summary>
        /// <remarks>
        /// This property is part of the Atom specification. 
        /// http://www.atomenabled.org/developers/syndication
        /// </remarks>
        public string Author
        {
            get { return PageInformation.LastModifiedBy; }
        }


        public ContentListInfoCollection GetListOfPostsForCurrentBlog(DateTime startDate)
        {
            return GetListOfPostsForCurrentBlog(startDate, DateTime.Now.AddDays(1));
        }


        public ContentListInfoCollection GetListOfPostsForCurrentBlog(DateTime startDate, DateTime endDate)
        {
            return IContentDataProvider.Content_SELECT_List(startDate, endDate, Common.ContentTypes.BlogPost, this.Id);
        }


        public ContentListInfoCollection GetListOfPostsForAllBlogs(DateTime startDate)
        {
            return GetListOfPostsForAllBlogs(startDate, DateTime.Now.AddDays(1));
        }


        public ContentListInfoCollection GetListOfPostsForAllBlogs(DateTime startDate, DateTime endDate)
        {
            return IContentDataProvider.Content_SELECT_List(startDate, endDate, Common.ContentTypes.BlogPost, Common.Constants.SystemTypeValues.NullInt);
        }


        public ContentListInfoCollection GetListOfPostsForCurrentBlog(int maxNumberOfPostsToReturn)
        {
            if (maxNumberOfPostsToReturn < 1)
            {
                maxNumberOfPostsToReturn = 5;
            }

            ContentListInfoCollection collection = IContentDataProvider.Content_SELECT_ListLatestLiveByPageId(this.Id, Common.ContentTypes.BlogPost, maxNumberOfPostsToReturn);

            return collection;
        }


        public ContentListInfoCollection GetListOfPostsForAllBlogs(int maxNumberOfPostsToReturn)
        {
            if (maxNumberOfPostsToReturn < 1)
            {
                maxNumberOfPostsToReturn = 5;
            }

            ContentListInfoCollection collection = IContentDataProvider.Content_SELECT_ListLatestLiveByPageId(Common.Constants.SystemTypeValues.NullInt, Common.ContentTypes.BlogPost, maxNumberOfPostsToReturn);

            return collection;
        }


        public BlogPostInfoCollection GetLatestBlogPostsForRssFeed()
        {
            return IContentDataProvider.Content_SELECT_ForBlogRSS(this.Id, Common.ContentTypes.BlogPost);
        }


        /// <summary>
        /// Gets the latest blog post.
        /// </summary>
        /// <returns></returns>
        public ContentInfo GetLatestBlogPost()
        {
            ContentInfoCollection collection = GetLatestBlogPosts(1);
            if (collection.Count > 0)
            {
                return collection[0];
            }
            else
            {
                return Common.Info.ContentInfoFactory.ContentNotFound();
            }
        }


        /// <summary>
        /// Gets the latest blog posts.
        /// </summary>
        /// <returns></returns>
        public ContentInfoCollection GetLatestBlogPosts(int maxNumberOfPostsToReturn)
        {
            if (maxNumberOfPostsToReturn < 1)
            {
                maxNumberOfPostsToReturn = 5;
            }

            ContentInfoCollection collection = IContentDataProvider.Content_SELECT_LatestLiveByPageId(this.Id, Common.ContentTypes.BlogPost, maxNumberOfPostsToReturn);

            return collection;
        }


        /// <summary>
        /// Gets a specific blog post by it's Id.
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
        public ContentInfo GetBlogPost(int contentId)
        {
            // Only get the post if it belongs to the blog.

            CustomPropertyInstanceInfoCollection xxx = CustomPropertyHelper.GetControlPropertiesByInstanceIDAndPropertyKeyAndTypeAndValue("BlogPost", Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.BPST, contentId.ToString());
            if (xxx.Count == 0)
            {
                // bad - post doesn't belong to this blog.
                return ContentInfoFactory.ContentNotFound();
            }
            else
            {
                // should be only one info returned, we'll 
                // turn a blind eye for now if multiple are returned.

                ContentInfo post = IContentDataProvider.Content_SELECT_ByContentID(contentId);

                Logging.Logger.LogVerboseInformation("Blogging.Blog.GetBlogPost()", string.Format("supplied id:{0} returned id:{1}", contentId, post.ContentID));


                if (post.ContentID == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                {
                    return ContentInfoFactory.NullContentInfo("Sorry, the requested blog post was not found.", contentId.ToString());
                }
                else
                {
                    if (post.IsLive)
                    {
                        return post;
                    }
                    else
                    {
                        return ContentInfoFactory.ContentNotFound();
                    }
                }
            }
        }


        /// <summary>
        /// Gets a specific blog post by its title (Content Note).
        /// </summary>
        /// <param name="postTitle"></param>
        /// <returns></returns>
        public ContentInfo GetBlogPost(string postTitle)
        {
            // Only get the post if it belongs to the blog.

            ContentInfo blah = IContentDataProvider.Content_SELECT_ByContentNote(postTitle, true);

            CustomPropertyInstanceInfoCollection xxx = CustomPropertyHelper.GetControlPropertiesByInstanceIDAndPropertyKeyAndTypeAndValue("BlogPost", Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.BPST, blah.ContentID.ToString());
            if (xxx.Count == 0)
            {
                // bad - post doesn't belong to this blog.
                return ContentInfoFactory.ContentNotFound();
            }
            else
            {
                // should be only one info returned, we'll 
                // turn a blind eye for now if multiple are returned.

                ContentInfo post = IContentDataProvider.Content_SELECT_ByContentNote(postTitle, true);

                if (post.ContentID == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                {
                    return ContentInfoFactory.NullContentInfo("Sorry, the requested blog post was not found.", postTitle);
                }
                else
                {
                    if (post.IsLive)
                    {
                        return post;
                    }
                    else
                    {
                        return ContentInfoFactory.ContentNotFound();
                    }
                }
            }
        }
    }
}
