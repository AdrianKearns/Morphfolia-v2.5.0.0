// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Common.Info;
using Morphfolia.Common.Interfaces;
using Morphfolia.Common.Utilities;
using Morphfolia.PublishingSystem.Logging;

namespace Morphfolia.PublishingSystem
{
    /// <summary>
    /// Provides a one-stop-shop for implementors who want/need to use 
    /// Morphfolia publishing and Templating functionality on standard .aspx WebForms.
    /// </summary>
    public class WebFormHelper
    {
        public virtual IFormTemplatePresenterProvider FormTemplatePresenter
        {
            get
            {
                if (formTemplatePresenter == null)
                {
                    formTemplatePresenter = Morphfolia.Business.FormTemplatePresenterProvider.Load(FormTemplatePresenterType);
                }
                return formTemplatePresenter;                 
            }
        }
        private IFormTemplatePresenterProvider formTemplatePresenter = null;


        public WebFormHelper()
        {
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PublishingSystem, TraceGuids._3050))
            {
                string dervivedUrl = GetDerivedPageUrl();
                Page = Morphfolia.Business.PageFactory.PublishThisPage(dervivedUrl);
            }
        }


        public WebFormHelper(string url)
        {
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PublishingSystem, TraceGuids._3051))
            {
                Page = Morphfolia.Business.PageFactory.PublishThisPage(url);
            }
        }


        private IPage ipage;
        public IPage Page
        {
            get { return ipage; }
            set { ipage = value; }
        }


        private CustomPropertyInstanceInfoCollection customProperties = null;
        public CustomPropertyInstanceInfoCollection CustomProperties
        {
            get
            {
                if (customProperties == null)
                {
                    customProperties = StaticCustomPropertyHelper.GetControlPropertiesByInstanceID(Page.PageID);
                }
                return customProperties;
            }
        }


        private Morphfolia.Business.StaticCustomPropertyHelper customPropertyHelper = null;
        public Morphfolia.Business.StaticCustomPropertyHelper CustomPropertyHelper
        {
            get
            {
                if (customPropertyHelper == null)
                {
                    customPropertyHelper = new Morphfolia.Business.StaticCustomPropertyHelper();
                }
                return customPropertyHelper;
            }
        }


        private ISkinProvider activeSkinProvider;
        public ISkinProvider ActiveSkinProvider
        {
            get
            {
                if (activeSkinProvider == null)
                {
                    string skinProviderType = SkinProviderType;

                    if (!skinProviderType.Equals(string.Empty))
                    {
                        try
                        {
                            //string assemblyName = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.LayoutProviderAssembly);
                            activeSkinProvider = (ISkinProvider)Morphfolia.Common.Utilities.ProviderLoader.CreateInstance(skinProviderType);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogException("Could not create instance of specified ISkinProvider.", ex, 5433, "Will attempt to load default SkinProvider.");

                            Logger.LogWarning("WebFormHelper.ActiveSkinProvider.get", "Returning the Default SkinProvider due to earlier error.", 5433);
                            activeSkinProvider = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetDefaultSkinProvider();
                        }
                    }
                    else
                    {
                        Logger.LogWarning("WebFormHelper.ActiveSkinProvider.get", "Returning the Default SkinProvider as none has been specifically specified.", 5433);
                        activeSkinProvider = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetDefaultSkinProvider();
                    }
                }

                activeSkinProvider.SetCustomProperties(CustomProperties);
                return activeSkinProvider;
            }
        }



        public string SkinProviderType
        {
            get
            {
                if (skinProviderType.Equals(string.Empty))
                {
                    skinProviderType = StaticCustomPropertyHelper.GetSkinProviderTypeByInstanceID(Page.PageID);
                }

                if (skinProviderType.Equals(string.Empty))
                {
                    Logger.LogWarning("WebFormHelper.SkinProviderType.get", string.Format("The appSetting '{0}' must be specified.", Morphfolia.Common.AppSettingKeys.DefaultISkinProvider), 5433);
                }

                return skinProviderType;
            }
        }
        private string skinProviderType = string.Empty;


        public string FormTemplatePresenterType
        {
            get
            {
                if (formTemplatePresenterType.Equals(string.Empty))
                {
                    formTemplatePresenterType = StaticCustomPropertyHelper.GetFormTemplatePresenterTypeByInstanceID(Page.PageID);
                }

                if (formTemplatePresenterType.Equals(string.Empty))
                {
                    Logger.LogWarning("WebFormHelper.FormTemplatePresenterType.get", string.Format("The appSetting '{0}' must be specified.", Morphfolia.Common.AppSettingKeys.DefaultFormTemplatePresenter), 5432);
                }

                return formTemplatePresenterType;
            }
        }
        private string formTemplatePresenterType = string.Empty;


        public string LayoutWebControlType
        {
            get
            {                
                try
                {
                    if (layoutWebControlType.Equals(string.Empty))
                    {
                        layoutWebControlType = StaticCustomPropertyHelper.GetLayoutWebControlTypeByInstanceID(Page.PageID);
                    }

                    if (layoutWebControlType.Equals(string.Empty))
                    {
                        layoutWebControlType = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultLayout);
                        Logger.LogWarning("WebFormLayoutHelper", string.Format("LayoutWebControlType is empty, going for DefaultPageLayout.{0}PageID: {1}{0}PageUrl: {2}", Environment.NewLine, Page.PageID.ToString(), "Login.aspx"), EventIds.NotSet);
                    }

                    return layoutWebControlType;
                }
                catch (System.Exception)
                {
                    // Not logging at this time as the exception is not exceptional.
                    return ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultLayout);
                }
            }
        }
        private string layoutWebControlType = string.Empty;



        /// <summary>
        /// Returns all matching ControlPropertyInfos for the specified key.
        /// </summary>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
        public Morphfolia.Common.Info.CustomPropertyInstanceInfoCollection ControlPropertiesByKey(string propertyKey)
        {
           return CustomProperties.ByPropertyKey(propertyKey);               
        }


        /// <summary>
        /// Returns only the first matching ControlPropertyInfo for the specified key.
        /// </summary>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
        public Morphfolia.Common.Info.CustomPropertyInstanceInfo ControlPropertyByKey(string propertyKey)
        {
            return CustomProperties.GetControlPropertyByPropertyKey(propertyKey);
        }


        /// <summary>
        /// Is this right? are we returning the "Active" skin provider or the default one?
        /// </summary>
        /// <returns></returns>
        private object CreateActiveSkinProvider()
        {
            return Morphfolia.Business.Helpers.ProviderLoader.Load(Morphfolia.Common.AppSettingKeys.DefaultLayout);
        }


        public void AmendHTMLHead(System.Web.UI.Page webForm)
        {
            string temp;
            webForm.Header.Title = Page.Title;

            Literal headerElement = new Literal();
            webForm.Header.Controls.Add(headerElement);
            headerElement.Text = string.Format("{0}{0}{0}<meta name='Powered By' content='Morphfolia'>", Environment.NewLine);

            headerElement = new Literal();
            webForm.Header.Controls.Add(headerElement);
            headerElement.Text = string.Format("{0}<meta name='Originally Developed By' content='Morphological.geek.nz'>", Environment.NewLine);

            temp = Page.Keywords;
            if (!temp.Equals(string.Empty))
            {
                headerElement = new Literal();
                webForm.Header.Controls.Add(headerElement);
                headerElement.Text = string.Format("{0}<meta name='Keywords' content='{1}'>", Environment.NewLine, temp);
            }

            temp = Page.Description;
            if (!temp.Equals(string.Empty))
            {
                headerElement = new Literal();
                webForm.Header.Controls.Add(headerElement);
                headerElement.Text = string.Format("{0}<meta name='Description' content='{1}'>", Environment.NewLine, temp);
            }

            headerElement = new Literal();
            webForm.Header.Controls.Add(headerElement);
            headerElement.Text = string.Format("{0}<meta name='Author' content='{1}'>", Environment.NewLine, Page.LastModifiedBy);

            headerElement = new Literal();
            webForm.Header.Controls.Add(headerElement);
            headerElement.Text = string.Format("{0}<meta name='LastModified' content='{1}'>", Environment.NewLine, Page.LastModified.ToString());

            headerElement = new Literal();
            webForm.Header.Controls.Add(headerElement);
            headerElement.Text = string.Format("{0}<LINK href='{1}/{2}' rel='stylesheet' type='text/css'>{0}{0}{0}",
                Environment.NewLine,
                WebUtilities.VirtualApplicationRoot(),
                ConfigHelper.GetAppSetting("Morphfolia.StyleSheet").ToString());
        }






        public WebControl CreateHeader()
        {
            return ActiveSkinProvider.MakePageHeader(Page);
        }





        public WebControl CreateFooter()
        {
            return ActiveSkinProvider.MakePageFooter(Page);
        }



        /// <summary>
        /// Outouts the content in a Panel as not all the content will be 
        /// plain text/html, some of it may be xml that needs to be converted 
        /// via a IFormTemplatePresenterProvider.
        /// </summary>
        /// <returns></returns>
        public Panel ContentForPage()
        {
            Panel pnlContent = new Panel();
            System.Text.StringBuilder content = new System.Text.StringBuilder();
            Morphfolia.Common.Info.ContentInfo contentInfo;

            for (int i = 0; i < Page.ContentItems.Count; i++)
            {
                contentInfo = Page.ContentItems[i];

                if (
                    (contentInfo.ContentEntryFilter.Equals(string.Empty)) |
                    (contentInfo.ContentEntryFilter.Equals("HtmlEditor"))
                    )
                {
                    // "Normal" content - HTML Mark-up:
                    Literal lblContentHolder = new Literal();
                    lblContentHolder.Text = contentInfo.Content;
                    pnlContent.Controls.Add(lblContentHolder);
                }
                else
                {
                    WebControl wc;
                    if (FormTemplatePresenter == null)
                    {
                        IFormTemplatePresenterProvider presenterProvider = Morphfolia.Business.FormTemplatePresenterProvider.LoadDefaultFormTemplatePresenter();
                        wc = presenterProvider.MakePresenter(contentInfo.Content);
                        pnlContent.Controls.Add(wc);
                    }
                    else
                    {
                        //IFormTemplatePresenterProvider dffp = Morphfolia.Business.FormTemplatePresenterProvider.Load(FormTemplatePresenter);
                        wc = FormTemplatePresenter.MakePresenter(contentInfo.Content);
                        pnlContent.Controls.Add(wc);
                    }
                }

                //contentInfo = Page.ContentItems[i];
                //content.AppendFormat(contentInfo.Content);
            }

            return pnlContent;
        }





        /// <summary>
        /// Use this method to get all the content for a specific part 
        /// of a page, via the content area (property) it was assigned to.
        /// </summary>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
        public string ContentForPageByPropertyKey(string propertyKey)
        {
            Morphfolia.Common.Info.ContentInfo contentInfo;
            //Morphfolia.Common.Info.CustomPropertyInstanceInfo contentProperty;
            Morphfolia.Common.Info.CustomPropertyInstanceInfoCollection contentProperties = ControlPropertiesByKey(propertyKey);

            Morphfolia.Common.Info.IntCollection contentIds = new IntCollection();
            System.Text.StringBuilder content = new System.Text.StringBuilder();

            for (int i = 0; i < contentProperties.Count; i++)
            {
                contentIds.Add(int.Parse(contentProperties[i].PropertyValue));
            }


            for (int i = 0; i < Page.ContentItems.Count; i++)
            {
                contentInfo = Page.ContentItems[i];
                if (contentIds.Contains(contentInfo.ContentID))
                {
                    content.AppendFormat(contentInfo.Content);
                }
            }

            return content.ToString();
        }





        public static string GetDerivedPageUrl()
        {
            return WebUtilities.GetDerivedPageUrl();
        }


        public static void LogRequest(HttpContext httpContext)
        {
            if (ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.LogHttpRequestsInline) == "true")
            {
                Morphfolia.Business.Logs.HttpLogger.LogRequest(httpContext);
            }
        }


        public static void LogRequest(HttpContext httpContext, string miscInfo)
        {
            if (ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.LogHttpRequestsInline) == "true")
            {
                Morphfolia.Business.Logs.HttpLogger.LogRequest(httpContext, miscInfo);
            }
        }

    }
}