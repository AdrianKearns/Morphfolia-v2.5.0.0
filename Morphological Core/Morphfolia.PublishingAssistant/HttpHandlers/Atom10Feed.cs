// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Common.Attributes;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.Common.Info;
using Morphfolia.Common.Utilities;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PublishingSystem.Logging;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
    /// <summary>
    /// Summary description for Atom10Feed.
    /// </summary>
    [IsHttpHandler("Provides an Atom 1.0 feed.")]
    public class Atom10Feed : IHttpHandler
    {
        public void ProcessRequest(HttpContext httpContext)
        {
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PublishingSystem, TraceGuids._3210))
            {
                Logger.LogVerboseInformation("Atom Feed Request", httpContext.Request.Url.AbsoluteUri, Morphfolia.PublishingSystem.Logging.EventIds._3210);


                if (ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.LogHttpRequestsInline) == "true")
                {
                    Morphfolia.Business.Logs.HttpLogger.LogRequest(httpContext);
                }


                string[] uriBits;
                int uriBitsLength;
                string derivedPageUrl;
                //Label litBlog;
                string BlogName = string.Empty;
                //ContentInfo BlogPost;

                try
                {
                    derivedPageUrl = Morphfolia.PublishingSystem.WebUtilities.GetDerivedPageUrl();

                    uriBits = httpContext.Request.Url.AbsoluteUri.Split(char.Parse("/"));
                    uriBitsLength = uriBits.Length;

                    BlogName = uriBits[uriBitsLength - 2];
                    BlogName = httpContext.Server.UrlDecode(BlogName);

                    Morphfolia.Business.Blogging.Blog blog = Morphfolia.Business.Blogging.BlogFactory.ByName(BlogName);
                    //Common.Info.BlogPostInfoCollection posts = blog.GetListOfPosts(DateTime.Now.AddMonths(-1), true);
                    Common.Info.BlogPostInfoCollection posts = blog.GetLatestBlogPostsForRssFeed();              



                    httpContext.Response.ContentType = "application/atom+xml";
                    XmlTextWriter xtwFeed = new XmlTextWriter(httpContext.Response.OutputStream, new System.Text.UTF8Encoding());

                    xtwFeed.Formatting = Formatting.Indented;
                    xtwFeed.WriteStartDocument();


                    // The mandatory rss tag

                    xtwFeed.WriteStartElement("feed");

                    xtwFeed.WriteAttributeString("xmlns", "http://www.w3.org/2005/Atom");


                    //// Not sure if this is the 'right' way to do this, but it works.
                    //// <?xml-stylesheet type="text/xsl" media="screen" href="/~d/styles/rss2full.xsl"?>
                    //xtwFeed.WriteProcessingInstruction("xml-stylesheet", string.Format("type=\"text/xsl\" media=\"screen\" href=\"{0}/{1}\"",
                    //    WebUtilities.FullyQualifiedApplicationRoot(),
                    //    ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultRSSXsl, "Morphfolia/DefaultRSS.xsl")));

                    //// Not sure if this is the 'right' way to do this, but it works.
                    //// <?xml-stylesheet type="text/css" media="screen" href="http://feeds.wired.com/~d/styles/itemcontent.css"?>
                    //xtwFeed.WriteProcessingInstruction("xml-stylesheet", string.Format("type=\"text/css\" media=\"screen\" href=\"{0}/{1}\"", 
                    //    WebUtilities.FullyQualifiedApplicationRoot(),
                    //    ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultStyleSheet)));


                    // The channel tag contains RSS feed details

                    //xtwFeed.WriteStartElement("feed");

                    xtwFeed.WriteElementString("title", blog.Title);

                    xtwFeed.WriteElementString("id", httpContext.Server.UrlEncode(blog.Title));

                    xtwFeed.WriteElementString("updated", DateTime.Now.ToString("r"));  // XXX not sure what format to use here.


                    xtwFeed.WriteElementString("subtitle", blog.Description);

                    xtwFeed.WriteElementString("generator", "www.morphfolia.geek.nz");

                    //xtwFeed.WriteElementString("rights", "Copyright 2005 - 2006 blah. All rights reserved.XXX");




                    xtwFeed.WriteStartElement("author");
                    xtwFeed.WriteElementString("name", blog.Author);
                    //xtwFeed.WriteElementString("email", blog.Link);
                    //xtwFeed.WriteElementString("uri", blog.Link);
                    xtwFeed.WriteEndElement();



                    if (posts.Count == 0)
                    {
                        // XXX
                        Logger.LogVerboseInformation("Atom10Feed.ProcessRequest()", "No posts returned.");
                    }
                    else
                    {
                        Logger.LogVerboseInformation("Atom10Feed.ProcessRequest()", string.Format("{0} post(s) returned.", posts.Count));

                        string content = string.Empty;
                        foreach (Common.Info.BlogPostInfo post in posts)
                        {
                            content = post.Content.Trim();
                            if (!content.Equals(string.Empty))
                            {
                                xtwFeed.WriteStartElement("entry");
                                xtwFeed.WriteElementString("title", post.ContentNote);

                                xtwFeed.WriteElementString("id", Blogging.BloggingHelpers.CreatePermalinkUrlToBlogPost(post)); //XXX

                                xtwFeed.WriteStartElement("link");
                                xtwFeed.WriteAttributeString("href", Blogging.BloggingHelpers.CreatePermalinkUrlToBlogPost(post));
                                xtwFeed.WriteEndElement();


                                // <category>Grateful Dead</category>
                                // or
                                // <category domain="http://www.fool.com/cusips">MSFT</category>

                                if (post.Tags.Count == 0)
                                {
                                    Logger.LogVerboseInformation("Blog Post category/tag", "None found.", 666);
                                }
                                else
                                {
                                    for (int c = 0; c < post.Tags.Count; c++)
                                    {
                                        xtwFeed.WriteElementString("category", post.Tags[c]);
                                    }
                                }

                                //xtwFeed.WriteElementString("description", post.TextContent); //XXX

                                // 2002-10-02T10:00:00-05:00

                                //xtwFeed.WriteElementString("updated", post.ContentLastModified.ToString("r"));  // XXX not sure what format to use here.
                                xtwFeed.WriteElementString("updated", Morphfolia.Common.Utilities.DateTimeHelper.ToAtom10Format(post.ContentLastModified, "+1200"));

                                xtwFeed.WriteStartElement("content");
                                //xtwFeed.WriteCData(post.Content);
                                //xtwFeed.WriteRaw(post.Content);
                                //type="html"
                                xtwFeed.WriteAttributeString("type", "html");
                                xtwFeed.WriteRaw(httpContext.Server.HtmlEncode(post.Content));
                                xtwFeed.WriteEndElement();

                                xtwFeed.WriteEndElement();

                            }
                        }
                    }


                    //xtwFeed.WriteEndElement();

                    xtwFeed.WriteEndElement();

                    xtwFeed.WriteEndDocument();

                    xtwFeed.Flush();

                    xtwFeed.Close();



                }
                catch (System.Exception ex)
                {
                    Logger.LogException("Atom10Feed", ex);
                    //Morphological.Utilities.HttpHandlerHelper.WriteExceptionAsXML( httpContext, ex );
                }
            }
        }


        public bool IsReusable
        {
            get { return true; }
        }
    }
}