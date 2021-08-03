// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

//using System;
//using Morphfolia.Common.Info;
//using Morphfolia.Common.Interfaces;
//using Morphfolia.Common.Logging;
//using Morphfolia.PageLayoutAndSkinAssistant.Attributes;

//namespace Morphological.Kudos.Skins.SpecialCircumstances
//{
//    [IsSkinProvider, SkinProviderDescriptionAttribute("Provides a flexible but simple header and footer that allows for random background images.")]
//    public class Hippinse : ISkinProvider
//    {
//        private class DefaultColours
//        {
//            internal const string DDEEFF = "#ddeeff";
//            internal const string BBEEFF = "#bbeeff";
//        }



//        public System.Web.UI.WebControls.WebControl HeaderFactory(string templateInstanceId, IPage page)
//        {
//            return Morphological.Kudos.Skins.SpecialCircumstances.HeaderFactory.Make(AlertText, page.Title, RandomPathAlways(), string.Empty, BackgroundColourTop, BackgroundColourBottom, CssClassTop, CssClassBottom, TopInlineStyle, BottomInlineStyle);
//        }

//        public System.Web.UI.WebControls.WebControl FooterFactory(string templateInstanceId, IPage page)
//        {
//            return Morphological.Kudos.Skins.SpecialCircumstances.FooterFactory.Make(AlertText, page.ContentLastModifiedBy, page.ContentLastModified, BackgroundColourBottom);
//        }



//        private string alertText = string.Empty;
//        [IsCustomProperty,
//        PropertyDefaultValue(""),
//        PropertyFriendlyName("Alert Text"),
//        PropertyDescription(""),
//        PropertySuggestedUsage("")]
//        public string AlertText
//        {
//            get { return alertText; }
//            set { alertText = value; }
//        }

//        private string cssClassTop = string.Empty;
//        [IsCustomProperty,
//        PropertyFriendlyName("Css Class (Top)"),
//        PropertyDescription(""),
//        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
//        public string CssClassTop
//        {
//            get { return cssClassTop; }
//            set { cssClassTop = value; }
//        }

//        private string randomBackgroundImagePaths = string.Empty;
//        [IsCustomProperty,
//        PropertyFriendlyName("Random Background Image Paths"),
//        PropertyDescription("Shows a random image.  To set images, specify one image path per-line."),
//        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.ImagePath),
//        InputSizeAttribute(Morphfolia.Common.Constants.Framework.Various.InputSizes.MultipleLine40x7)]
//        public string RandomBackgroundImagePaths
//        {
//            get { return randomBackgroundImagePaths; }
//            set { randomBackgroundImagePaths = value; }
//        }

//        private string randomImageFrequency = string.Empty;
//        [IsCustomProperty,
//        PropertyFriendlyName("Random Image Frequency"),        
//        PropertyDescription("Specifies the frequency a new random image will appear."),
//        PropertySuggestedUsage("'E' every request, 'D' daily.")]
//        public string RandomImageFrequency
//        {
//            get { return randomImageFrequency; }
//            set { randomImageFrequency = value; }
//        }

//        private string backgroundColourTop = DefaultColours.DDEEFF;
//        [IsCustomProperty,
//        PropertyDefaultValue(DefaultColours.DDEEFF),
//        PropertyFriendlyName("Background Colour (Top)"),
//        PropertyDescription(""),
//        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.HexCode)]
//        public string BackgroundColourTop
//        {
//            get { return backgroundColourTop; }
//            set { backgroundColourTop = value; }
//        }

//        private string topInlineStyle = string.Empty;
//        [IsCustomProperty,
//        PropertyFriendlyName("Inline Style (Top)"),
//        PropertyDescription("Allows you to inject any inline CSS."),
//        PropertySuggestedUsage("[valid CSS syntax]")]
//        public string TopInlineStyle
//        {
//            get { return topInlineStyle; }
//            set { topInlineStyle = value; }
//        }



//        private string cssClassBottom = string.Empty;
//        [IsCustomProperty,
//        PropertyFriendlyName("Css Class (Bottom)"),
//        PropertyDescription(""),
//        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.CssClass)]
//        public string CssClassBottom
//        {
//            get { return cssClassBottom; }
//            set { cssClassBottom = value; }
//        }



//        private string backgroundColourBottom = DefaultColours.BBEEFF;
//        [IsCustomProperty,
//        PropertyDefaultValue(DefaultColours.BBEEFF),
//        PropertyFriendlyName("Background Colour (Bottom)"),
//        PropertyDescription(""),
//        PropertySuggestedUsage(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.HexCode)]
//        public string BackgroundColourBottom
//        {
//            get { return backgroundColourBottom; }
//            set { backgroundColourBottom = value; }
//        }


//        private string bottomInlineStyle = string.Empty;
//        [IsCustomProperty,
//        PropertyFriendlyName("Inline Style (Bottom)"),
//        PropertyDescription("Allows you to inject any inline CSS."),
//        PropertySuggestedUsage("[valid CSS syntax]")]
//        public string BottomInlineStyle
//        {
//            get { return bottomInlineStyle; }
//            set { bottomInlineStyle = value; }
//        }



//        private System.Collections.Specialized.StringCollection paths = new System.Collections.Specialized.StringCollection();
//        private void InitRandomness()
//        {
//            string[] temp = RandomBackgroundImagePaths.Split(Char.Parse(Environment.NewLine));
//            paths.AddRange(temp);

//            for (int i = 0; i < temp.Length; i++)
//            {
//                Logger.LogVerboseInformation("RandomBackgroundImagePaths", temp[i].ToString());
//            }


//        }

//        private string RandomPathAlways()
//        {
//            InitRandomness();
//            Random r = new Random(DateTime.Now.Millisecond);
//            int theChoosenOne = r.Next(0, paths.Count - 1);
//            Logger.LogVerboseInformation("theChoosenOne", paths[theChoosenOne]);
//            Logger.LogWarning("theChoosenOne", paths[theChoosenOne]);

//            throw new ApplicationException(string.Format("theChoosenOne = {0}", paths[theChoosenOne]));

//            return paths[theChoosenOne];
//        }


//        private CustomPropertyInstanceInfoCollection CustomProperties = null;


//        public void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
//        {
//            CustomProperties = customProperties;
//            if (CustomProperties != null)
//            {
//                string propertyType;
//                string propertyKey;
//                string propertyValue;

//                for (int i = 0; i < CustomProperties.Count; i++)
//                {
//                    propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;
//                    propertyKey = CustomProperties[i].PropertyKey;
//                    propertyValue = CustomProperties[i].PropertyValue;

//                    // Identify content by the name of the container (propertyKey), or as in this case, 
//                    // dump all the content into the one-and-only content container - identified 
//                    // by property type.
//                    switch (propertyKey)
//                    {
//                        case "AlertText":
//                            AlertText = propertyValue;
//                            break;

//                        case "RandomImageFrequency":
//                            RandomImageFrequency = propertyValue;
//                            break;

//                        case "RandomBackgroundImagePaths":
//                            RandomBackgroundImagePaths = propertyValue;
//                            break;

//                        //case "BackgroundImageBottom":
//                        //    BackgroundImageBottom = propertyValue;
//                        //    break;

//                        case "BackgroundColourTop":
//                            BackgroundColourTop = propertyValue;
//                            break;

//                        case "BackgroundColourBottom":
//                            BackgroundColourBottom = propertyValue;
//                            break;

//                        case "CssClassTop":
//                            CssClassTop = propertyValue;
//                            break;

//                        case "CssClassBottom":
//                            CssClassBottom = propertyValue;
//                            break;

//                        case "TopInlineStyle":
//                            TopInlineStyle = propertyValue;
//                            break;

//                        case "BottomInlineStyle":
//                            BottomInlineStyle = propertyValue;
//                            break;
//                    }
//                }
//            }
//        }

//    }
//}