// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.IO;
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
using Morphfolia.PublishingSystem.HttpHandlers.Helpers;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// Summary description for ContentPreview.
	/// </summary>
    [IsHttpHandler("Serves a blog post based on the title of the post, as a full HTML page.")]
    public class ViewBlogPostByTitle : IHttpHandler
	{
        /*         
        /blogs/permalink/[blogid]/[postid]/viewpost.aspx
        /blogs/viewpost[blog title]/[blog title].aspx
        */

        /// <summary>
        /// Assumes a specific URI structure.  
        /// This should be enforced by the httpHandlers configuration in web.config.
        /// */blogs/permalink/[postId].aspx
        /// Where [postId] equals the content id of the post to be viewed.
        /// </summary>
        /// <param name="httpContext"></param>
		public void ProcessRequest( HttpContext httpContext )
		{
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PublishingSystem, TraceGuids._3202))
            {
                Logger.LogVerboseInformation("Blog Post Request", httpContext.Request.Url.AbsoluteUri, Morphfolia.PublishingSystem.Logging.EventIds._3202);


                if (ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.LogHttpRequestsInline) == "true")
                {
                    Morphfolia.Business.Logs.HttpLogger.LogRequest(httpContext);
                }


                string[] uriBits;
                string derivedPageUrl;

                try
                {
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter writer = new HtmlTextWriter(sw);

                    //  derivedPageUrl= blogs/viewpost/MilesDavis/m3.aspx
                    //  AbsoluteUri=    http://localhost/Morphfolia.Web/blogs/viewpost/MilesDavis/m3.aspx

                    derivedPageUrl = Morphfolia.PublishingSystem.WebUtilities.GetDerivedPageUrl();
                    uriBits = derivedPageUrl.Split(char.Parse("/"));


                    string blobTitle = uriBits[uriBits.Length-2];
                    Business.Blogging.Blog currentBlog = Business.Blogging.BlogFactory.ByName(blobTitle);

                    Logger.LogVerboseInformation("Blog Post Request",
                        string.Format("Current Blog = {0}", currentBlog.Id.ToString()),
                        Morphfolia.PublishingSystem.Logging.EventIds._3200);



                    string postTitle = uriBits[uriBits.Length-1];
                    postTitle = postTitle.Substring(0, postTitle.LastIndexOf("."));
                    postTitle = httpContext.Server.UrlDecode(postTitle);
                    ContentInfo currentBlogPost = currentBlog.GetBlogPost(postTitle);

                    Logger.LogVerboseInformation("Blog Post Request",
                        string.Format("Current Blog Post = {0}", currentBlogPost.ContentID.ToString()),
                        Morphfolia.PublishingSystem.Logging.EventIds._3200);


                    BasePageLayout pageLayout;
                    Morphfolia.WebControls.HtmlHead htmlHead;

                    // If the user has explicitly defined a page for this post, load teh approprate details 
                    // otherwise get details from the parent blog.
                    Morphfolia.Business.Page page = Morphfolia.Business.PageFactory.PublishThisPage(derivedPageUrl);
                    if (page.PageID == Common.Constants.SystemTypeValues.NullInt)
                    {
                        page = Morphfolia.Business.PageFactory.Page(currentBlog.Id);
                    }
                    htmlHead = new Morphfolia.WebControls.HtmlHead(page);


                    writer.Write("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">{0}<html>{0}{0}", Environment.NewLine);

                    // Support Feed Autodiscovery: 
                    string feedAutodiscovery = string.Format("<link rel=\"alternate\" type=\"application/rss+xml\" title=\"{0}\" href=\"{1}\" />",
                        page.Title,
                        string.Format("{0}/blogs/{1}/rss.ashx", WebUtilities.FullyQualifiedApplicationRoot(), page.Title));
                    htmlHead.MetaTags.Add(feedAutodiscovery);

                    htmlHead.StyleSheet = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultStyleSheet);
                    htmlHead.RenderControl(writer);

                    writer.WriteFullBeginTag("BODY");



                    string layoutWebControlType = string.Empty;
                    CustomPropertyInstanceInfoCollection customPropertyInstanceInfoCollection;
                    Morphfolia.Business.StaticCustomPropertyHelper controlPropertyHelper = new Morphfolia.Business.StaticCustomPropertyHelper();


                    try
                    {
                        layoutWebControlType = StaticCustomPropertyHelper.GetControlPropertiesByInstanceIDAndPropertyKey(page.PageID, SpecialCustomPropertyKeys.LayoutWebControlType)[0].PropertyValue;
                    }
                    catch (System.Exception e)
                    {
                        Logger.LogException("Failed to load layoutWebControlType.", e, EventIds._3100, string.Format("PageID = {0}", page.PageID.ToString()));
                        layoutWebControlType = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultLayout);
                    }


                    try
                    {
                        customPropertyInstanceInfoCollection = StaticCustomPropertyHelper.GetControlPropertiesByInstanceID(page.PageID);

                        if (layoutWebControlType.Equals(string.Empty))
                        {
                            layoutWebControlType = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultLayout);
                            Logger.LogWarning(
                                "DefaultHandler",
                                string.Format("layoutWebControlType is empty, going for DefaultPageLayout '{3}'.{0}PageID: {1}{0}derivedPageUrl: {2}",
                                    Environment.NewLine,
                                    page.PageID.ToString(),
                                    derivedPageUrl,
                                    layoutWebControlType),
                                EventIds._3102);
                        }
                    }
                    catch (System.Exception e)
                    {
                        System.Text.StringBuilder sbErrorInfo = new System.Text.StringBuilder();
                        sbErrorInfo.AppendFormat("AbsoluteUri: {1}{0}derivedPageUrl: {2}", Environment.NewLine, httpContext.Request.Url.AbsoluteUri, derivedPageUrl);

                        Logger.LogException("Something failed.", e, EventIds._3100, sbErrorInfo.ToString());

                        throw;
                    }


                    if (layoutWebControlType.Equals(string.Empty))
                    {
                        layoutWebControlType = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultLayout);
                        Logger.LogWarning(
                            "DefaultHandler",
                            string.Format("layoutWebControlType is empty, going for DefaultPageLayout '{3}'.{0}PageID: {1}{0}derivedPageUrl: {2}",
                                Environment.NewLine,
                                page.PageID.ToString(),
                                derivedPageUrl,
                                layoutWebControlType),
                            EventIds._3103);
                    }
                    pageLayout = PageLayoutHelper.ActivateBasePageLayoutInstance(layoutWebControlType, page.PageID);

                    Layouts.BlogPageLayout bpl;

                    if (pageLayout is Layouts.BlogPageLayout)
                    {
                        bpl = (Layouts.BlogPageLayout)pageLayout;

                        bpl.Page = page;
                        bpl.SetCustomProperties(customPropertyInstanceInfoCollection);

                        bpl.CurrentBlog = currentBlog;
                        bpl.CurrentPost = currentBlogPost;

                        bpl.InitializeContent();
                        bpl.RenderControl(writer);
                    }
                    else
                    {
                        pageLayout.Page = page;
                        pageLayout.SetCustomProperties(customPropertyInstanceInfoCollection);
                        pageLayout.InitializeContent();
                        pageLayout.RenderControl(writer);
                    }


                    // Close BODY
                    writer.WriteEndTag("body");

                    // Close HTML
                    writer.Write("</html>");

                    httpContext.Response.Write(sw.ToString());




                    //-----------------------------------------------------------------------
                    // Tracing
                    //-----------------------------------------------------------------------

                    string enableInlineTracing = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.EnableInlineTracing).ToLower();
                    if (enableInlineTracing.Equals("true"))
                    {
                        httpContext.Response.Write(string.Format("<h4>Inline Tracing Enabled.<br>{0} = true</h4>", Morphfolia.Common.AppSettingKeys.EnableInlineTracing));

                        TracingHelper.WriteAllForms(httpContext);
                        TracingHelper.WriteAllQueryStrings(httpContext);
                        TracingHelper.WriteAllParams(httpContext);
                    }
                }
                catch (System.Exception ex)
                {
                    Logger.LogException("ViewBlogPost.ProcessRequest() Failed.", ex);
                }
            }
		}

		public bool IsReusable
		{
			get{ return true; }
		}
	}
}