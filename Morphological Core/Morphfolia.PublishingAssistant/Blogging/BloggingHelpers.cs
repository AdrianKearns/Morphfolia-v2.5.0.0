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
using System.Web;

namespace Morphfolia.PublishingSystem.Blogging
{
    public class BloggingHelpers
    {
        private static string fullyQualifiedApplicationRoot = string.Empty;
        internal static string FullyQualifiedApplicationRoot
        {
            get
            {
                if (fullyQualifiedApplicationRoot.Equals(String.Empty))
                {
                    fullyQualifiedApplicationRoot = WebUtilities.FullyQualifiedApplicationRoot();
                }
                return fullyQualifiedApplicationRoot;
            }
        }


        // this is evil, but we need something...

        public static string CreateUrlToPostByTitle(string blogTitle, ContentListInfo post)
        {
            //Business.Blogging.Blog currentBlog = Business.Blogging.BlogFactory.ByPostId(post.ContentID);
            //return string.Format("{0}/blogs/viewpost/{1}/{2}.aspx", VirtualApplicationRoot, currentBlog.Title, post.Note);
            return string.Format("{0}/blogs/viewpost/{1}/{2}.aspx", 
                FullyQualifiedApplicationRoot, 
                HttpContext.Current.Server.UrlEncode(blogTitle), 
                HttpContext.Current.Server.UrlEncode(post.Note));
        }


        public static string CreatePermalinkUrlToBlogPost(BlogPostInfo post)
        {
            return string.Format("{0}/blogs/permalink/{1}/{2}/viewpost.aspx", 
                FullyQualifiedApplicationRoot, 
                post.PageID.ToString(), 
                post.ContentID.ToString());
        }

        public static string CreateUrlToBlogPostByTitle(BlogPostInfo post)
        {
            return string.Format("{0}/blogs/viewpost/{1}/{2}.aspx", 
                FullyQualifiedApplicationRoot, 
                HttpContext.Current.Server.UrlEncode(post.PageTitle), 
                HttpContext.Current.Server.UrlEncode(post.ContentNote));
        }

        public static string CreateUrlToBlogPostByTitle(SearchResultInfo post)
        {
            return string.Format("{0}/blogs/viewpost/{1}/{2}.aspx", 
                FullyQualifiedApplicationRoot, 
                HttpContext.Current.Server.UrlEncode(post.Title), 
                HttpContext.Current.Server.UrlEncode(post.ContentNote));
        }

        public static string CreateUrlToBlogByTitle(SearchResultInfo post)
        {
            return string.Format("{0}/blogs/viewpost/{1}/{2}.aspx", 
                FullyQualifiedApplicationRoot, 
                HttpContext.Current.Server.UrlEncode(post.Title), 
                HttpContext.Current.Server.UrlEncode(post.ContentNote));
        }
    }
}
