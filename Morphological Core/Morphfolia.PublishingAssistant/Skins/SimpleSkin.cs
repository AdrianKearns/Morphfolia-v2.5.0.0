// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using Morphfolia.Common.Interfaces;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;

namespace Morphfolia.PublishingSystem.Skins
{
    [IsSkinProvider]
    public class SimpleSkin : ISkinProvider
    {
        private class DefaultColours
        {
            internal const string DDEEFF = "#ddeeff";
            internal const string BBEEFF = "#bbeeff";
        }




        public WebControl MakePageHeader(IPage page)
        {
            return Skins.HeaderFactory.Make(AlertText, page.Title, BackgroundImageTop, BackgroundImageBottom, BackgroundColourTop, BackgroundColourBottom, CssClassTop, CssClassBottom, TopInlineStyle, BottomInlineStyle);
        }

        public WebControl MakePageFooter(IPage page)
        {
            return Skins.FooterFactory.Make(AlertText, page.ContentLastModifiedBy, page.ContentLastModified, BackgroundColourBottom);
        }



        private string alertText = string.Empty;
        [IsCustomProperty,
        PropertyDefaultValue(""),
        PropertyFriendlyName("Alert Text"),
        PropertyDescription(""),
        PropertySuggestedUsage("")]
        public string AlertText
        {
            get { return alertText; }
            set { alertText = value; }
        }

        private string cssClassTop = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Css Class (Top)"),
        PropertyDescription(""),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
        public string CssClassTop
        {
            get { return cssClassTop; }
            set { cssClassTop = value; }
        }

        private string backgroundImageTop = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Background Image (Top)"),
        PropertyDescription(""),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.ImagePath)]
        public string BackgroundImageTop
        {
            get { return backgroundImageTop; }
            set { backgroundImageTop = value; }
        }

        private string backgroundColourTop = DefaultColours.DDEEFF;
        [IsCustomProperty,
        PropertyDefaultValue(DefaultColours.DDEEFF),
        PropertyFriendlyName("Background Colour (Top)"),
        PropertyDescription(""),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.HexCode)]
        public string BackgroundColourTop
        {
            get { return backgroundColourTop; }
            set { backgroundColourTop = value; }
        }

        private string topInlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Inline Style (Top)"),
        PropertyDescription("Allows you to inject any inline CSS."),
        PropertySuggestedUsage("[valid CSS syntax]")]
        public string TopInlineStyle
        {
            get { return topInlineStyle; }
            set { topInlineStyle = value; }
        }



        private string cssClassBottom = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Css Class (Bottom)"),
        PropertyDescription(""),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
        public string CssClassBottom
        {
            get { return cssClassBottom; }
            set { cssClassBottom = value; }
        }

        private string backgroundImageBottom = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Background Image (Bottom)"),
        PropertyDescription(""),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.ImagePath)]
        public string BackgroundImageBottom
        {
            get { return backgroundImageBottom; }
            set { backgroundImageBottom = value; }
        }

        private string backgroundColourBottom = DefaultColours.BBEEFF;
        [IsCustomProperty,
        PropertyDefaultValue(DefaultColours.BBEEFF),
        PropertyFriendlyName("Background Colour (Bottom)"),
        PropertyDescription(""),
        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.HexCode)]
        public string BackgroundColourBottom
        {
            get { return backgroundColourBottom; }
            set { backgroundColourBottom = value; }
        }


        private string bottomInlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Inline Style (Bottom)"),
        PropertyDescription("Allows you to inject any inline CSS."),
        PropertySuggestedUsage("[valid CSS syntax]")]
        public string BottomInlineStyle
        {
            get { return bottomInlineStyle; }
            set { bottomInlineStyle = value; }
        }



        private CustomPropertyInstanceInfoCollection CustomProperties = null;


        public void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            CustomProperties = customProperties;
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
                        case "AlertText":
                            AlertText = propertyValue;
                            break;

                        case "BackgroundImageTop":
                            BackgroundImageTop = propertyValue;
                            break;

                        case "BackgroundImageBottom":
                            BackgroundImageBottom = propertyValue;
                            break;

                        case "BackgroundColourTop":
                            BackgroundColourTop = propertyValue;
                            break;

                        case "BackgroundColourBottom":
                            BackgroundColourBottom = propertyValue;
                            break;

                        case "CssClassTop":
                            CssClassTop = propertyValue;
                            break;

                        case "CssClassBottom":
                            CssClassBottom = propertyValue;
                            break;

                        case "TopInlineStyle":
                            TopInlineStyle = propertyValue;
                            break;

                        case "BottomInlineStyle":
                            BottomInlineStyle = propertyValue;
                            break;
                    }
                }
            }
        }

    }
}