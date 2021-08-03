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
    public class SimplePageLayout : BasePageLayout, INamingContainer
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
        protected TableCell tdContentContainer;


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


        public SimplePageLayout()
        {
        }


        public SimplePageLayout(WebControl childWebControl)
        {
            ChildControls.Add(childWebControl);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// the values of these strings should be the same as 
        /// the att...?
        /// </remarks>
        public new class ContentPlugKeys
        {
            public static readonly string GeneralContent = "GeneralContent";
        }


        private CustomPropertyInstanceInfoCollection CustomProperties = null;

        public override void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            EnsureChildControls();

            CustomProperties = customProperties;

            System.Text.StringBuilder sbC1 = new System.Text.StringBuilder();
            string propertyKey;
            string propertyValue;


            if (CustomProperties == null)
            {
                Logging.Logger.LogWarning("SimplePageLayout SetCustomProperties()", "Warning, CustomProperties == null");
            }
            else
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
        }


        #region ...   Properties   ...


        //private string formTemplatePresenterType = string.Empty;
        //[IsCustomProperty,
        //PropertyFriendlyName("FormTemplatePresenterType"),
        //PropertyDescription("FormTemplatePresenterType"),
        //PropertySuggestedUsage("FormTemplatePresenterType")]
        //public override string FormTemplatePresenterType
        //{
        //    get { return formTemplatePresenterType; }
        //    set { formTemplatePresenterType = value; }
        //}



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


        private string generalContent = "&nbsp;";
        [IsContentContainer]
        public string GeneralContent
        {
            get { return generalContent; }
            set { generalContent = value; }
        }

        //private string skinIdentifier = string.Empty;
        //[IsCustomProperty,
        //PropertyFriendlyName(FriendlyNames.SkinIdentifier),
        //PropertyDescription(Descriptions.SkinIdentifier),
        //PropertySuggestedUsage(SuggestedUsageNotes.SkinIdentifier)]
        //public string SkinIdentifier
        //{
        //    get { return skinIdentifier; }
        //    set { skinIdentifier = value; }
        //}


        #endregion


        protected override void CreateChildControls()
        {
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

            tr = new TableRow();
            Controls.Add(tr);
            tblContent.Rows.Add(tr);

            tdContentContainer = new TableCell();
            Controls.Add(tdContentContainer);
            tr.Cells.Add(tdContentContainer);
            tdContentContainer.VerticalAlign = VerticalAlign.Top;
            tdContentContainer.ID = "tdContentContainer";

            EndFormTag = new Literal();
            Controls.Add(EndFormTag);
            EndFormTag.Text = "</form>";

            contentPlaceHolder = new PlaceHolder();
            Controls.Add(contentPlaceHolder);
            contentPlaceHolder.ID = "contentPlaceHolder";

            footerPlaceHolder = new PlaceHolder();
            Controls.Add(footerPlaceHolder);
            footerPlaceHolder.ID = "footerPlaceHolder";
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                Logging.Logger.LogVerboseInformation("SimplePageLayout RenderContents()", string.Format("skinProvider = '{0}'", skinProvider.GetType().ToString()), 666);

                tblHeader = skinProvider.MakePageHeader(this.Page);
                Controls.Add(tblHeader);
                headerPlaceHolder.Controls.Add(tblHeader);

                tblContent.Width = OveralWidth;
                tblContent.HorizontalAlign = OveralHorizontalAlign;

                if (ChildControls.Count > 0)
                {
                    for (int c = 0; c < ChildControls.Count; c++)
                    {
                        tdContentContainer.Controls.AddAt(c, ChildControls[c]);
                    }
                }

                tblFooter = skinProvider.MakePageFooter(this.Page);
                Controls.Add(tblFooter);
                footerPlaceHolder.Controls.Add(tblFooter);

                base.RenderContents(writer);
            }
        }


        public override void InitializeContent()
        {
            EnsureChildControls();

            string propertyType;
            string propertyValue;
            int temp;

            if (CustomProperties != null)
            {
                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;
                    //propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    if (propertyType.Equals(Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT))
                    {
                        int id;

                        if (int.TryParse(propertyValue, out id))
                        {
                            temp = GetContentInfoIndexById(id);

                            if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                AddContentToContentContainer(tdContentContainer, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            }
                        }
                        else
                        {
                            Logging.Logger.LogWarning("SimplePageLayout, InitializeContent()",
                                string.Format("Non-fatal parsing error, the Custom Property Value '{0}' is not an int. The offending Custom Propertys Id is {1}.",
                                propertyValue,
                                CustomProperties[i].ID.ToString()));
                        }
                    }
                }
            }
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
