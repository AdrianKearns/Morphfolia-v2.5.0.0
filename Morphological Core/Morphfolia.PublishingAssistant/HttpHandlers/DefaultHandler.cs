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
using Morphfolia.Common.Attributes;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.Common.Info;
using Morphfolia.Common.Utilities;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PublishingSystem.Logging;
using Morphfolia.Business;
using Morphfolia.PublishingSystem.HttpHandlers.Helpers;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// This is the default psge handler and should be able to 
	/// handle any basic/normal (.aspx) page request.
	/// </summary>
    [IsHttpHandler("The main HttpHandler for processing end-user requests.")]
	public class DefaultHandler : IHttpHandler
	{
		public void ProcessRequest( HttpContext httpContext )
		{
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PublishingSystem, TraceGuids._3100))
            {
                bool isSearch = false;
                Morphfolia.Business.Page page;
                BasePageLayout pageLayout;
                //NameValueCollection additionalInfo;
                //System.Exception ex;

                //--------------------------------------------------
                // Extract out the part of the raw url that will 
                // map to the URL data we store in the DB:
                //--------------------------------------------------

                //string pageUrl = httpContext.Request.RawUrl;
                string rawUrl = httpContext.Request.RawUrl;
                string fullPageUrl = rawUrl;
                string derivedPageUrl;

                Logger.LogVerboseInformation("Page Request", rawUrl, EventIds._3100);

                if (!rawUrl.StartsWith("http"))
                {
                    fullPageUrl = string.Format("http://{0}{1}", httpContext.Request.ServerVariables["SERVER_NAME"].ToString(), rawUrl).ToLower();
                }
                derivedPageUrl = fullPageUrl;

                string fullyQualifiedApplicationRoot = WebUtilities.FullyQualifiedApplicationRoot().ToLower();

                //if (ConfigHelper.GetAppSetting(Morphfolia.Common.ConfigKeys.LogHttpRequests) == "true")
                //{
                //    Morphfolia.Business.HttpLogger.LogRequest(httpContext);
                //}

                try
                {
                    if (derivedPageUrl.IndexOf(fullyQualifiedApplicationRoot) > -1)
                    {
                        derivedPageUrl = derivedPageUrl.Substring(fullyQualifiedApplicationRoot.Length);
                    }

                    // Ensure that no leading / are in front of the url (as they aren't stored in the DB): 			
                    if (derivedPageUrl.StartsWith("/"))
                    {
                        derivedPageUrl = derivedPageUrl.Substring(1);
                    }

                    // Strip off the query string when attempting to page:
                    if (derivedPageUrl.IndexOf("?") > -1)
                    {
                        derivedPageUrl = derivedPageUrl.Substring(0, derivedPageUrl.IndexOf("?"));
                    }
                }
                catch (System.Exception e)
                {
                    Logger.LogException("Could not parse derivedPageUrl.", e, EventIds._3100, string.Format("fullPageUrl: {0}", fullPageUrl));
                }


                // Get ready: 
                StringWriter sw = new StringWriter();
                HtmlTextWriter writer = new HtmlTextWriter(sw);

                Logger.LogVerboseInformation("Page Request (Derived Url)", derivedPageUrl, EventIds._3101);


                // Last chance to change our minds about which page we want to publish: 
                if (httpContext.Request.Form[RequestKeys.SearchCriteriaIndentifier] != null)
                {
                    if (!httpContext.Request.Form[RequestKeys.SearchCriteriaIndentifier].ToString().Equals(string.Empty))
                    {
                        string surl = derivedPageUrl;

                        if (surl.IndexOf("/") > -1)
                        {
                            surl = surl.Substring(surl.IndexOf("/") + 1);
                        }

                        if (!surl.Equals(Morphfolia.WebControls.SearchInput.SearchResultsPageRawURL))
                        {
                            string url = string.Format("{0}",
                                Morphfolia.WebControls.SearchInput.SearchResultsPageRawURL,
                                httpContext.Request.Form[RequestKeys.SearchCriteriaIndentifier].ToString());

                            isSearch = true;
                            Logger.LogVerboseInformation("Resetting URL", url);
                            derivedPageUrl = url;
                        }
                    }
                }



                if (ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.LogHttpRequestsInline) == "true")
                {
                    string miscInfo = WebUtilities.GetRequestParamValue("searchcriteria");
                    if (!miscInfo.Equals(string.Empty))
                    {
                        miscInfo = string.Format("Users search criteria: {0}", miscInfo);
                    }

                    Morphfolia.Business.Logs.HttpLogger.LogRequest(httpContext, miscInfo);
                }


                // Get the page data, based on the URL.
                // The factory always returns a page object - even if it is a "Page Cannot Be Found" page, 
                // or an exception.

                page = Morphfolia.Business.PageFactory.PublishThisPage(derivedPageUrl);

                writer.Write("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">{0}<html>{0}{0}", Environment.NewLine);

                Morphfolia.WebControls.HtmlHead htmlHead = new Morphfolia.WebControls.HtmlHead(page);
                htmlHead.StyleSheet = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultStyleSheet);
                htmlHead.RenderControl(writer);

                writer.WriteFullBeginTag("BODY");

                if (page.PageID == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                {
                    Label lbl404 = new Label();
                    lbl404.Text = string.Format("Sorry, the page '{0}' does not exist.", derivedPageUrl);

                    pageLayout = PageLayoutHelper.ActivateBasePageLayoutInstance(page.PageID);
                    pageLayout.ChildControls.Add(lbl404);
                    pageLayout.Page = page;
                    pageLayout.SetCustomProperties(new CustomPropertyInstanceInfoCollection());
                    //pageLayout.FormTemplatePresenter = Morphfolia.Business.FormTemplatePresenterProvider.Load(pageLayout.FormTemplatePresenterType);
                    pageLayout.InitializeContent();
                    pageLayout.RenderControl(writer);
                }
                else
                {
                    // Strip off everything after (and including) the .aspx 
                    // to make specific page identification simpler:
                    string pageName = derivedPageUrl.ToLower();
                    int positionOfDotAspx = pageName.IndexOf(".aspx");


                    if (positionOfDotAspx > 0)
                    {
                        pageName = pageName.Substring(0, positionOfDotAspx);

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
                            //layoutWebControlAssembly = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.LayoutProviderAssembly);

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
                            sbErrorInfo.AppendFormat("rawUrl: {1}{0}derivedPageUrl: {2}", Environment.NewLine, rawUrl, derivedPageUrl);

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
                        


                        switch (pageName)
                        {
                            case "searchresults":
                                Morphfolia.PublishingSystem.WebControls.SearchResults searchResults = new Morphfolia.PublishingSystem.WebControls.SearchResults();
                                pageLayout.ChildControls.Add(searchResults);
                                break;

                            case "sitemap":
                                Morphfolia.WebControls.SiteMap siteMap = new Morphfolia.WebControls.SiteMap();
                                siteMap.RootNodeText = httpContext.Request.ServerVariables["SERVER_NAME"].ToString();
                                pageLayout.ChildControls.Add(siteMap);
                                break;

                            case "siteindex":
                                Morphfolia.WebControls.WordIndexListPresenter wordIndexListPresenter = new Morphfolia.WebControls.WordIndexListPresenter();
                                pageLayout.ChildControls.Add(wordIndexListPresenter);
                                break;

                            case "tags":
                                Morphfolia.Business.ContentIndexer contentIndexer = new Morphfolia.Business.ContentIndexer();
                                Morphfolia.WebControls.TagCloud tagCloud = new Morphfolia.WebControls.TagCloud();

                                // Centralize Tag-Cloud control and use the settings here.

                                //tagCloud.NumberOfTagDivisons = TagCloudNumberOfTagDivisons;
                                tagCloud.NumberOfTagDivisons = 15;
                                //tagCloud.MinimumOccurranceThreshold = TagCloudMinimumOccurranceThreshold;
                                tagCloud.MinimumOccurranceThreshold = 20;
                                //tagCloud.Words = contentIndexer.GetWordsForTagCloud(tagCloud.MinimumOccurranceThreshold);
                                tagCloud.Words = contentIndexer.GetWordsForTagCloud(tagCloud.MinimumOccurranceThreshold);
                                tagCloud.NavigateUrl = string.Format("{0}/SearchResults.aspx", WebUtilities.VirtualApplicationRoot());
                                //tagCloud.NavigateUrlQueryStringKey = SearchResultsPage.QueryStringKeys.SearchCriteria;
                                tagCloud.NavigateUrlQueryStringKey = RequestKeys.SearchCriteriaIndentifier;

                                pageLayout.ChildControls.Add(tagCloud);
                                break;
                        }


                        if (isSearch)
                        {
                            Morphfolia.PublishingSystem.WebControls.SearchResults searchResults = new Morphfolia.PublishingSystem.WebControls.SearchResults();
                            pageLayout.ChildControls.Add(searchResults);
                        }


                        pageLayout.Page = page;
                        pageLayout.SetCustomProperties(customPropertyInstanceInfoCollection);
                        pageLayout.FormTemplatePresenter = Morphfolia.Business.FormTemplatePresenterProvider.Load(pageLayout.FormTemplatePresenterType);                        
                        pageLayout.InitializeContent();
                        pageLayout.RenderControl(writer);
                    }
                    else
                    {
                        Logger.LogException("Publishing failed.", "The requested page is not .aspx", EventIds._3100);
                    }
                }

                // Close FORM
                //writer.WriteEndTag("form");

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
		}



        public bool IsReusable
		{
			get{ return false; }
		}

	}
}
