// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Info;
using Morphfolia.Common.Logging;
using Morphfolia.Common.Constants;
using Morphfolia.Business.Constants;


namespace Morphfolia.Business
{
    public class PageLister
    {
        private static Morphfolia.IDataProvider.IPageDataProvider iPageDataProvider = null;
        private static Morphfolia.IDataProvider.IPageDataProvider PageDataProvider
        {
            get
            {
                if (iPageDataProvider == null)
                {
                    iPageDataProvider = (Morphfolia.IDataProvider.IPageDataProvider)Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IPageDataProvider);
                }
                return iPageDataProvider;
            }
        }




        public static PageInfoCollection List()
        {
            try
            {
                return PageDataProvider.Page_SELECT_List();
            }
            catch
            {
                throw;
            }
        }



        public static PageInfoCollection List(IntCollection pageIds)
        {
            try
            {
                Logging.Logger.LogVerboseInformation("PageLister, List()", string.Format("Number of pageIds to get: {0}", pageIds.Count.ToString()));
                PageInfoCollection collection = PageDataProvider.Page_SELECT_PagesByID(pageIds);
                Logging.Logger.LogVerboseInformation("PageLister, List()", string.Format("Number of PageInfo items to be returned: {0}", collection.Count.ToString()));
                return collection;
            }
            catch
            {
                throw;
            }
        }



        public static PageInfoCollection PagesUsedByThisContentItem(int contentItemId)
        {
            try
            {
                return PageDataProvider.Page_SELECT_ByChildContentItem(contentItemId);
            }
            catch
            {
                throw;
            }
        }



        public static PageInfoCollection List(PageListerSearchCriteria pageListerSearchCriteria)
        {
            try
            {
                return PageDataProvider.Page_SELECT_ListSearch(pageListerSearchCriteria);
            }
            catch
            {
                throw;
            }
        }



        public static PageInfoCollection ListAllPagesIncludingBlogPosts(bool urlEncode)
        {
            try
            {
                System.Web.HttpContext httpContext = System.Web.HttpContext.Current;
                string urlString;
                Blogging.Blog blog;
                PageInfo temp;
                PageInfoCollection collection = PageDataProvider.Page_SELECT_List();

                ContentListInfoCollection posts = new ContentListInfoCollection();
                PageInfoCollection availableBlogs = Blogging.BloggingUtilities.GetListOfAvailableBlogs();



                if (urlEncode)
                {
                    foreach (PageInfo page in availableBlogs)
                    {
                        collection.Add(page);

                        blog = Blogging.BlogFactory.ById(page.PageID);
                        posts = blog.GetListOfPostsForCurrentBlog(200);

                        // http://localhost/Morphfolia.Web/blogs/The%20Job/rss.ashx
                        urlString = string.Format("blogs/{0}/rss.ashx", httpContext.Server.UrlEncode(page.Title));
                        temp = new PageInfo(page.PageID, page.Title, urlString, page.Keywords, page.Description, page.LastModified, page.LastModifiedBy, page.IsSearchable, page.IsLive);
                        collection.Add(temp);

                        // http://localhost/Morphfolia.Web/blogs/The%20Job/atom.ashx
                        urlString = string.Format("blogs/{0}/atom.ashx", httpContext.Server.UrlEncode(page.Title));
                        temp = new PageInfo(page.PageID, page.Title, urlString, page.Keywords, page.Description, page.LastModified, page.LastModifiedBy, page.IsSearchable, page.IsLive);
                        collection.Add(temp);


                        foreach (ContentListInfo post in posts)
                        {
                            // http://localhost/Morphfolia.Web/blogs/viewpost/Test+Blog+001/Tag+Cloud+Test+(Again).aspx
                            urlString = string.Format("blogs/viewpost/{0}/{1}.aspx", httpContext.Server.UrlEncode(page.Title), httpContext.Server.UrlEncode(post.Note));
                            temp = new PageInfo(page.PageID, page.Title, urlString, page.Keywords, page.Description, post.LastModified, post.LastModifiedBy, post.IsSearchable, post.IsLive);
                            collection.Add(temp);

                            // http://localhost/Morphfolia.Web/blogs/permalink/7/42/viewpost.aspx
                            urlString = string.Format("blogs/permalink/{0}/{1}/viewpost.aspx", page.PageID.ToString(), post.ContentID.ToString());
                            temp = new PageInfo(page.PageID, page.Title, urlString, page.Keywords, page.Description, post.LastModified, post.LastModifiedBy, post.IsSearchable, post.IsLive);
                            collection.Add(temp);
                        }
                    }
                }
                else
                {
                    foreach (PageInfo page in availableBlogs)
                    {
                        collection.Add(page);

                        blog = Blogging.BlogFactory.ById(page.PageID);
                        posts = blog.GetListOfPostsForAllBlogs(200);

                        // http://localhost/Morphfolia.Web/blogs/The%20Job/rss.ashx
                        urlString = string.Format("blogs/{0}/rss.ashx", page.Title);
                        temp = new PageInfo(page.PageID, page.Title, urlString, page.Keywords, page.Description, page.LastModified, page.LastModifiedBy, page.IsSearchable, page.IsLive);
                        collection.Add(temp);

                        // http://localhost/Morphfolia.Web/blogs/The%20Job/atom.ashx
                        urlString = string.Format("blogs/{0}/atom.ashx", page.Title);
                        temp = new PageInfo(page.PageID, page.Title, urlString, page.Keywords, page.Description, page.LastModified, page.LastModifiedBy, page.IsSearchable, page.IsLive);
                        collection.Add(temp);

                        foreach (ContentListInfo post in posts)
                        {
                            // http://localhost/Morphfolia.Web/blogs/viewpost/Test+Blog+001/Tag+Cloud+Test+(Again).aspx
                            urlString = string.Format("blogs/viewpost/{0}/{1}.aspx", page.Title, post.Note);
                            temp = new PageInfo(page.PageID, page.Title, urlString, page.Keywords, page.Description, post.LastModified, post.LastModifiedBy, post.IsSearchable, post.IsLive);
                            collection.Add(temp);

                            // http://localhost/Morphfolia.Web/blogs/permalink/7/42/viewpost.aspx
                            urlString = string.Format("blogs/permalink/{0}/{1}/viewpost.aspx", page.PageID.ToString(), post.ContentID.ToString());
                            temp = new PageInfo(page.PageID, page.Title, urlString, page.Keywords, page.Description, post.LastModified, post.LastModifiedBy, post.IsSearchable, post.IsLive);
                            collection.Add(temp);
                        }
                    }
                }



                return collection;
            }
            catch
            {
                throw;
            }
        }


    }
}
