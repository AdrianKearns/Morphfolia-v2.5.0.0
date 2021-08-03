// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using Morphfolia.Common.Interfaces;
using Morphfolia.Common.Types;

namespace Morphfolia.Common.BaseClasses
{
    public abstract class BasePageLayout : WebControl, INamingContainer
    {
        /// <summary>
        /// Used to identify the current page instance. Used when requesting / storing control properties and content.
        /// </summary>
        public int PageInstanceId
        {
            get { return pageInstanceId; }
            set { pageInstanceId = value; }
        }
        private int pageInstanceId;

        /// <summary>
        /// Defines the keys that identify areas where content can be assigned to the Page-Layout.
        /// </summary>
        public abstract class ContentPlugKeys { }

        /// <summary>
        /// The underlying System.Web.UI.Page.
        /// </summary>
        /// <returns></returns>
        public System.Web.UI.Page GetPage()
        {
            return base.Page;
        }

        private IPage page;

        /// <summary>
        /// Used to assign page information/data to the current instance of the Page-Layout.
        /// </summary>
        public virtual new IPage Page
        {
            set { page = value; }
            get { return page; }
        }

        /// <summary>
        /// Perform any necessary actions to populate content containers and control properties in 
        /// your Page-Layout implementation.
        /// This is called immeadiately before calling [BasePageLayout].RenderControl(writer);
        /// </summary>
        /// <remarks>
        /// Use the private Properties: Page and ControlProperties, to 
        /// populate the control with content and properties.
        /// </remarks>
        public abstract void SetCustomProperties(CustomPropertyInstanceInfoCollection CustomProperties);

        /// <summary>
        /// Identifies (and returns) the desired ISkinProvider implementation (from the customProperties) 
        /// and loads it with the customProperties.
        /// A back-up/default ISkinProvider implementation is returned if there is an issue loading desired implementation.
        /// </summary>
        /// <param name="customProperties">The properties assigned to the current page, by the user.</param>
        /// <param name="backupSkinProvider">The ISkinProvider implementation to use in the event of an error.</param>
        /// <returns></returns>
        public ISkinProvider LoadSkinProvider(CustomPropertyInstanceInfoCollection customProperties, ISkinProvider backupSkinProvider)
        {
            ISkinProvider skinProvider;
            string propertyKey = string.Empty;
            string propertyValue = string.Empty;

            try
            {
                for (int i = 0; i < customProperties.Count; i++)
                {
                    propertyKey = customProperties[i].PropertyKey;

                    if (propertyKey.Equals(Morphfolia.Common.Constants.Framework.SpecialCustomPropertyKeys.SkinProviderType))
                    {
                        propertyValue = customProperties[i].PropertyValue;
                        break;                
                    }
                }

                if (propertyValue.Equals(string.Empty))
                {
                    Morphfolia.Common.Logging.Logger.LogException("LoadSkinProvider() failed, using hard-coded default.", "The specified Property Value is empty.");
                    skinProvider = backupSkinProvider;
                }
                else
                {
                    skinProvider = (ISkinProvider)Morphfolia.Common.Utilities.ProviderLoader.CreateInstance(propertyValue);
                }
            }
            catch (Exception ex)
            {
                Morphfolia.Common.Logging.Logger.LogException("LoadSkinProvider() failed, using hard-coded default.", ex);
                skinProvider = backupSkinProvider;
            }


            skinProvider.SetCustomProperties(customProperties);
            return skinProvider;
        }

        public abstract void InitializeContent();

        /// <summary>
        /// Can be used to add child controls to the current instance of the Page-Layout.
        /// </summary>
        public abstract Common.WebControlCollection ChildControls { get; set; }

        /// <summary>
        /// do we need this (and do we need it here)?
        /// </summary>
        public virtual IFormTemplatePresenterProvider FormTemplatePresenter
        {
            get{ return formTemplatePresenter; }
            set{ formTemplatePresenter = value; }
        }
        private IFormTemplatePresenterProvider formTemplatePresenter = null;

        /// <summary>
        /// Allows implementors to specify (either in code or by exposing a configurable 
        /// property) which IFormTemplatePresenterProvider to instansiate, and 
        /// provide presentation for FormTemplate items.
        /// </summary>
        public virtual string FormTemplatePresenterType
        { 
            get { return formTemplatePresenterType; }
            set { formTemplatePresenterType = value; }
        }
        private string formTemplatePresenterType = string.Empty;

        /// <summary>
        /// AddContentToContentContainer
        /// </summary>
        /// <param name="contentContainer">The System.Web.UI.Control that we will append the content to.</param>
        /// <param name="contentEntryFilter">Helps decide how we will add / present the content.</param>
        /// <param name="content">The content we are adding / appending to the container.</param>
        public virtual void AddContentToContentContainer(System.Web.UI.Control contentContainer, string contentEntryFilter, string content)
        {
            EnsureChildControls();

            if (contentContainer == null)
            {
                Logging.Logger.LogException("BasePageLayout.AddContentToContentContainer()", "The 'contentContainer' argument must not be null.", Logging.EventIds.BasePageLayout._102);
                throw new Exceptions.BasePageLayoutException("The 'contentContainer' argument must not be null.");
            }


            if (
                (contentEntryFilter.Equals(string.Empty)) |
                (contentEntryFilter.Equals("HtmlEditor"))
                )
            {
                // "Normal" content - HTML Mark-up:
                Literal lblContentHolder = new Literal();
                lblContentHolder.Text = content;
                Controls.Add(lblContentHolder);
                contentContainer.Controls.Add(lblContentHolder);
            }
            else
            {
                if (FormTemplatePresenter == null)
                {
                    Literal lblContentHolder = new Literal();
                    Controls.Add(lblContentHolder);
                    contentContainer.Controls.Add(lblContentHolder);
                    lblContentHolder.Text = string.Format("Need to refactor this. 106 {0}", content);
                }
                else
                {
                    WebControl wc = FormTemplatePresenter.MakePresenter(content);
                    Controls.Add(wc);
                    contentContainer.Controls.Add(wc);
                }
            }
        }

        public int GetContentInfoIndexById(int targetContentItemId)
        {
            for (int i = 0; i < Page.ContentItems.Count; i++)
            {
                if (Page.ContentItems[i].ContentID == targetContentItemId)
                {
                    return i;
                }
            }

            return Common.Constants.SystemTypeValues.NullInt;
        }

        /// <summary>
        /// Takes a string and returns a HorizontalAlign.
        /// </summary>
        /// <remarks>Not sure why this is here, will look to refactor, eventually.</remarks>
        /// <param name="horizontalAlign">string</param>
        /// <returns>HorizontalAlign</returns>
        public HorizontalAlign HorizontalAlignFromstring(string horizontalAlign)
        {
            switch (horizontalAlign.ToLower())
            {
                case "left":
                    return HorizontalAlign.Left;

                case "center":
                    return HorizontalAlign.Center;

                case "right":
                    return HorizontalAlign.Right;

                default:
                    return HorizontalAlign.NotSet;
            }
        }
    }
}