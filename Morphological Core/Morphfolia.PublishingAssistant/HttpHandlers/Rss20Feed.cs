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
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.Common.Info;
using Morphfolia.Common.Utilities;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PublishingSystem.Logging;
using Morphfolia.Common.Attributes;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
    /// <summary>
    /// Summary description for RSS20Feed.
    /// </summary>
    [IsHttpHandler("Provides an RSS 2.0 feed.")]
    public class RSS20Feed : IHttpHandler
    {
        public void ProcessRequest(HttpContext httpContext)
        {
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PublishingSystem, TraceGuids._3211))
            {
                Logger.LogVerboseInformation("RSS Feed Request", httpContext.Request.Url.AbsoluteUri, Morphfolia.PublishingSystem.Logging.EventIds._3211);


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
                    //Common.Info.BlogPostInfoCollection posts = blog.GetPostsForCurrentBlog(DateTime.Now.AddMonths(-1), DateTime.Now);
                    Common.Info.BlogPostInfoCollection posts = blog.GetLatestBlogPostsForRssFeed();

                    httpContext.Response.ContentType = "application/rss+xml";
                    XmlTextWriter xtwFeed = new XmlTextWriter(httpContext.Response.OutputStream, new System.Text.UTF8Encoding());

                    xtwFeed.Formatting = Formatting.Indented;
                    xtwFeed.WriteStartDocument();


                    // The mandatory rss tag

                    xtwFeed.WriteStartElement("rss");

                    xtwFeed.WriteAttributeString("version", "2.0");


                    // Not sure if this is the 'right' way to do this, but it works.
                    // <?xml-stylesheet type="text/xsl" media="screen" href="/~d/styles/rss2full.xsl"?>
                    xtwFeed.WriteProcessingInstruction("xml-stylesheet", string.Format("type=\"text/xsl\" media=\"screen\" href=\"{0}/{1}\"",
                        WebUtilities.FullyQualifiedApplicationRoot(),
                        ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultRSSXsl, "Morphfolia/DefaultRSS.xsl")));

                    // Not sure if this is the 'right' way to do this, but it works.
                    // <?xml-stylesheet type="text/css" media="screen" href="http://feeds.wired.com/~d/styles/itemcontent.css"?>
                    xtwFeed.WriteProcessingInstruction("xml-stylesheet", string.Format("type=\"text/css\" media=\"screen\" href=\"{0}/{1}\"",
                        WebUtilities.FullyQualifiedApplicationRoot(),
                        ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultStyleSheet)));


                    // The channel tag contains RSS feed details

                    xtwFeed.WriteStartElement("channel");

                    xtwFeed.WriteElementString("title", blog.Title);

                    xtwFeed.WriteElementString("link", string.Format("{0}/{1}", WebUtilities.FullyQualifiedApplicationRoot(), blog.Link));

                    xtwFeed.WriteElementString("description", blog.Description);

                    xtwFeed.WriteElementString("generator", "www.morphfolia.geek.nz");

                    //xtwFeed.WriteElementString("copyright", "Copyright 2005 - 2006 blah. All rights reserved.XXX");




                    if (posts.Count == 0)
                    {
                        // XXX
                    }
                    else
                    {
                        string content = string.Empty;
                        foreach (Common.Info.BlogPostInfo post in posts)
                        {
                            content = post.Content.Trim();
                            if (!content.Equals(string.Empty))
                            {
                                xtwFeed.WriteStartElement("item");
                                xtwFeed.WriteElementString("title", post.ContentNote);


                                // <category>Grateful Dead</category>
                                // or
                                // <category domain="http://www.fool.com/cusips">MSFT</category>


                                if (post.Tags.Count == 0)
                                {
                                    Logger.LogVerboseInformation("Blog Post category/tag", "None found.", 666);
                                }
                                else
                                {
                                    //Logger.LogVerboseInformation("Blog Post category/tag", post.Tags.Count.ToString(), 666);

                                    for (int c = 0; c < post.Tags.Count; c++)
                                    {
                                        //Logger.LogVerboseInformation("Blog Post category/tag", post.Tags[c], 666);
                                        xtwFeed.WriteElementString("category", post.Tags[c]);
                                    }
                                }


                                //xtwFeed.WriteElementString("description", post.TextContent); //XXX

                                //xtwFeed.WriteElementString("link", Blogging.BloggingHelpers.CreateUrlToBlogPostByTitle(post));
                                xtwFeed.WriteElementString("link", Blogging.BloggingHelpers.CreatePermalinkUrlToBlogPost(post));



                                // <pubDate>Sun, 19 May 2002 15:21:36 GMT</pubDate>
                                // <pubDate>Mon, 28 Apr 2008 11:20:02 +1200</pubDate> 
                                //new string[] {"NZ", "+1100", "New Zealand "},
                                //new string[] {"NZST", "+1200", "New Zealand Standard"},
                                //new string[] {"NZDT", "+1300", "New Zealand Daylight "},
                                //new string[] {"NZT", "+1200", "New Zealand"},
                                xtwFeed.WriteElementString("pubDate", Morphfolia.Common.Utilities.DateTimeHelper.ToRSS20Format(post.ContentLastModified, "NZST"));
                                //xtwFeed.WriteElementString("pubDate", post.ContentLastModified.ToString("r"));

                                ////content:encoded
                                ////xtwFeed.WriteCData
                                ////xtwFeed.WriteStartElement("content:encoded");
                                //xtwFeed.WriteStartElement("description");
                                ////xtwFeed.WriteCData(httpContext.Server.HtmlEncode(post.Content)); // XXX
                                ////xtwFeed.WriteCData(post.Content); // XXX
                                //xtwFeed.WriteRaw(post.Content); // XXX
                                ////xtwFeed.WriteRaw("<p>Some very <b>basic</b> content</p>"); // XXX
                                //xtwFeed.WriteEndElement();



                                xtwFeed.WriteStartElement("description");
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


                    xtwFeed.WriteEndElement();

                    xtwFeed.WriteEndElement();

                    xtwFeed.WriteEndDocument();

                    xtwFeed.Flush();

                    xtwFeed.Close();



                }
                catch (System.Exception ex)
                {
                    Logger.LogException("RSS20Feed", ex);
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