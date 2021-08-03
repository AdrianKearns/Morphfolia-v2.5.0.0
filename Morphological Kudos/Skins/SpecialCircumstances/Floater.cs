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
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;

namespace Morphological.Kudos.Skins.SpecialCircumstances
{
    [IsSkinProvider, SkinProviderDescriptionAttribute("Provides a flexible but simple header and footer.")]
    public class Floater : ISkinProvider
    {
        public System.Web.UI.WebControls.WebControl MakePageHeader(IPage page)
        {
            return Morphological.Kudos.Skins.SpecialCircumstances.HeaderFactory.MakeFloater(page, CustomProperties);
        }

        public System.Web.UI.WebControls.WebControl MakePageFooter(IPage page)
        {
            return Morphological.Kudos.Skins.SpecialCircumstances.FooterFactory.MakeFloater(page, CustomProperties);
        }


        public class Properties
        {
            public const string HeaderPanelWidth = "HeaderPanelWidth";
            public const string HeaderPanelHorizontalAlign = "HeaderPanelHorizontalAlign";
            public const string CssClassHeaderPanel = "CssClassHeaderPanel";
            public const string CssClassPageTitle = "CssClassPageTitle";
            public const string CssClassSearchBox = "CssClassSearchBox";
            public const string CssClassNavigationBox = "CssClassNavigationBox";
            public const string CssClassFooterPanel = "CssClassFooterPanel";
        }


        //private string alertText = string.Empty;
        //[IsCustomProperty,
        //PropertyDefaultValue(""),
        //PropertyFriendlyName("Alert Text"),
        //PropertyDescription(""),
        //PropertySuggestedUsage("")]
        //public string AlertText
        //{
        //    get { return alertText; }
        //    set { alertText = value; }
        //}

        private string cssClassHeaderPanel = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Css Class (Header Panel)"),
        PropertyDescription("Set the CSS class for the page header panel."),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
        public string CssClassHeaderPanel
        {
            get { return cssClassHeaderPanel; }
            set { cssClassHeaderPanel = value; }
        }


        private string cssClassPageTitle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Css Class (Page Title)"),
        PropertyDescription("Set the CSS class for the page title/header."),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
        public string CssClassPageTitle
        {
            get { return cssClassPageTitle; }
            set { cssClassPageTitle = value; }
        }


        private string cssClassSearchBox = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Css Class (Search Box)"),
        PropertyDescription("Set the CSS class for the search input / box."),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
        public string CssClassSearchBox
        {
            get { return cssClassSearchBox; }
            set { cssClassSearchBox = value; }
        }


        private string cssClassNavigationBox = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Css Class (Navigation Box)"),
        PropertyDescription("Set the CSS class for the navigation box."),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
        public string CssClassNavigationBox
        {
            get { return cssClassNavigationBox; }
            set { cssClassNavigationBox = value; }
        }


        private HorizontalAlign headerPanelHorizontalAlign = HorizontalAlign.Center;
        [IsCustomProperty,
        PropertyFriendlyName("HorizontalAlignment (Header)"),
        PropertyDefaultValue(DefaultValues.HorizontalAlignment),
        PropertyDescription(Descriptions.HorizontalAlignment),
        PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
        public HorizontalAlign HeaderPanelHorizontalAlign
        {
            get { return headerPanelHorizontalAlign; }
            set { headerPanelHorizontalAlign = value; }
        }


        private Unit headerPanelWidth = Unit.Pixel(650);
        [IsCustomProperty,
        PropertyFriendlyName("Width (Header)"),
        PropertyDescription(Descriptions.Width),
        PropertySuggestedUsage(SuggestedUsageNotes.Width)]
        public Unit HeaderPanelWidth
        {
            get { return headerPanelWidth; }
            set { headerPanelWidth = value; }
        }


        private string cssClassFooterPanel = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Css Class (Footer Panel)"),
        PropertyDescription("Set the CSS class for the page footer panel."),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
        public string CssClassFooterPanel
        {
            get { return cssClassFooterPanel; }
            set { cssClassFooterPanel = value; }
        }




        //private string backgroundImageTop = string.Empty;
        //[IsCustomProperty,
        //PropertyFriendlyName("Background Image (Top)"),
        //PropertyDescription(""),
        //PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.ImagePath)]
        //public string BackgroundImageTop
        //{
        //    get { return backgroundImageTop; }
        //    set { backgroundImageTop = value; }
        //}

        //private string backgroundColourTop = DefaultColours.DDEEFF;
        //[IsCustomProperty,
        //PropertyDefaultValue(DefaultColours.DDEEFF),
        //PropertyFriendlyName("Background Colour (Top)"),
        //PropertyDescription(""),
        //PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.HexCode)]
        //public string BackgroundColourTop
        //{
        //    get { return backgroundColourTop; }
        //    set { backgroundColourTop = value; }
        //}

        //private string topInlineStyle = string.Empty;
        //[IsCustomProperty,
        //PropertyFriendlyName("Inline Style (Top)"),
        //PropertyDescription("Allows you to inject any inline CSS."),
        //PropertySuggestedUsage("[valid CSS syntax]")]
        //public string TopInlineStyle
        //{
        //    get { return topInlineStyle; }
        //    set { topInlineStyle = value; }
        //}



        //private string cssClassBottom = string.Empty;
        //[IsCustomProperty,
        //PropertyFriendlyName("Css Class (Bottom)"),
        //PropertyDescription(""),
        //PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
        //public string CssClassBottom
        //{
        //    get { return cssClassBottom; }
        //    set { cssClassBottom = value; }
        //}

        //private string backgroundImageBottom = string.Empty;
        //[IsCustomProperty,
        //PropertyFriendlyName("Background Image (Bottom)"),
        //PropertyDescription(""),
        //PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.ImagePath)]
        //public string BackgroundImageBottom
        //{
        //    get { return backgroundImageBottom; }
        //    set { backgroundImageBottom = value; }
        //}

        //private string backgroundColourBottom = DefaultColours.BBEEFF;
        //[IsCustomProperty,
        //PropertyDefaultValue(DefaultColours.BBEEFF),
        //PropertyFriendlyName("Background Colour (Bottom)"),
        //PropertyDescription(""),
        //PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.HexCode)]
        //public string BackgroundColourBottom
        //{
        //    get { return backgroundColourBottom; }
        //    set { backgroundColourBottom = value; }
        //}


        //private string bottomInlineStyle = string.Empty;
        //[IsCustomProperty,
        //PropertyFriendlyName("Inline Style (Bottom)"),
        //PropertyDescription("Allows you to inject any inline CSS."),
        //PropertySuggestedUsage("[valid CSS syntax]")]
        //public string BottomInlineStyle
        //{
        //    get { return bottomInlineStyle; }
        //    set { bottomInlineStyle = value; }
        //}



        private CustomPropertyInstanceInfoCollection CustomProperties = null;


        public void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            CustomProperties = customProperties;


            /*

            if (CustomProperties != null)
            {
                string propertyType;
                string propertyKey;
                string propertyValue;

                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    // Identify content by the name of the container (propertyKey), or as in this case, 
                    // dump all the content into the one-and-only content container - identified 
                    // by property type.
                    switch (propertyKey)
                    {
                        //case "AlertText":
                        //    AlertText = propertyValue;
                        //    break;

                        //case "BackgroundImageTop":
                        //    BackgroundImageTop = propertyValue;
                        //    break;

                        //case "BackgroundImageBottom":
                        //    BackgroundImageBottom = propertyValue;
                        //    break;

                        //case "BackgroundColourTop":
                        //    BackgroundColourTop = propertyValue;
                        //    break;

                        //case "BackgroundColourBottom":
                        //    BackgroundColourBottom = propertyValue;
                        //    break;

                        case "CssClassTop":
                            CssClassTop = propertyValue;
                            break;

                        //case "CssClassBottom":
                        //    CssClassBottom = propertyValue;
                        //    break;

                        //case "TopInlineStyle":
                        //    TopInlineStyle = propertyValue;
                        //    break;

                        //case "BottomInlineStyle":
                        //    BottomInlineStyle = propertyValue;
                        //    break;
                    }
                }
            }
              
             
             * */
        }

    }
}