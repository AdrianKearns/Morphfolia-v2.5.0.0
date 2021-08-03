// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using Morphfolia.PageLayoutAndSkinAssistant.Logging;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.PageLayoutAndSkinAssistant.Attributes
{
    public class FriendlyNames
    {
        public const string CssClass = "Css Class Name";
        public const string Width = "Width";
        public const string Style = "Inline Style";
        public const string HorizontalAlignment = "Horizontal Alignment";
        public const string BackgroundImageUrl = "Background Image Url";
        public const string SkinIdentifier = "Skin Identifier";
        public const string CellPadding = "Cell Padding";
        public const string CellSpacing = "Cell Spacing";
        public const string TagCloud = "Tag-Cloud";
        public const string TagCloudMinimumOccurranceThreshold = "Tag-Cloud: Tag Threshold";
        public const string TagCloudNumberOfTagDivisons = "Tag-Cloud: Number of Tag Divisons";
        public const string TagCloudCssClass = "Tag-Cloud Css Class";
    }

    public class DefaultValues
    {
        public const string HorizontalAlignment = "Center";
    }

    public class SuggestedUsageNotes
    {
        public const string CssClass = "<i>CSS Class Name</i>";
        public const string Width = "Fixed width in pixels (e.g: 220px) or a percentage (e.g: 50%).";
        public const string HorizontalAlignment = "Left, Center or Right.";
        public const string Style = "See: <a href='http://www.w3.org/TR/CSS21' target='_blank'>http://www.w3.org/TR/CSS21</a>";
        public const string BackgroundImageUrl = "See: <a href='http://www.w3.org/TR/CSS21/colors.html#propdef-background-image' target='_blank'>http://www.w3.org/TR/CSS21/colors.html#propdef-background-image</a>";
        public const string SkinIdentifier = "The current page-layout template supports different skins; enter the 'Skin Identifier' from one the <a href=\"AppearanceTemplateInfo.aspx\" target=\"_blank\">skin options listed here</a>.";
        public const string CellPadding = "An integer.";
        public const string CellSpacing = "An integer.";
        public const string TagCloud = "Use the letter Y to display the tag-cloud, or leave empty.";
        public const string TagCloudMinimumOccurranceThreshold = "An integer.";
        public const string TagCloudNumberOfTagDivisons = "An integer; recomended value between 2-5 (no less than 2).";
        public const string TagCloudCssClass = "<i>CSS Class Name</i> for the Tag-Cloud.";
    }

    public class Descriptions
    {
        public const string CssClass = "The name of a CSS Style class.";
        public const string Width = "The desired width on the property.";
        public const string HorizontalAlignment = "The HorizontalAlignment of the content / object.";
        public const string Style = "CSS styles in standard CSS format.";
        public const string BackgroundImageUrl = "The relative or absoulte path to the desired background image.";
        public const string SkinIdentifier = "Specifies which Skin Option will be used for this page.";
        public const string CellPadding = "The distance (in pixels) between the inner border of the table cells and their content.";
        public const string CellSpacing = "The distance (in pixels) between the outer borders of the table cells.";
        public const string TagCloud = "Displays a Tag-Cloud based on content in the site.";
        public const string TagCloudMinimumOccurranceThreshold = "Control the size of the Tag-Cloud by setting the number of times a tag must occur before it appears in the Tag-Cloud.";
        public const string TagCloudNumberOfTagDivisons = "Control the visual level of granularity between tags and how often they occur";
        public const string TagCloudCssClass = "The name of a CSS Style class for the Tag-Cloud.";
    }


    /// <summary>
    /// Identifies Types that are valid LayoutWebControls.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IsLayoutWebControl : Attribute
    {
        public IsLayoutWebControl()
        {
        }

        public static string AttributeIdentifier = ".Attributes.IsLayoutWebControl";
    }

    /// <summary>
    /// Describes to the user what the intent of the layout is.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class LayoutDescriptionAttribute : Attribute
    {
        public LayoutDescriptionAttribute(string description)
        {
            this.description = description;
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }



    /// <summary>
    /// Identifies the class as a blog. // XXX
    /// </summary>
    /// <remarks>Intended for use with Page Layouts.</remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsBlog : Attribute
    {
        public IsBlog()
        {
        }

        public static string AttributeIdentifier = ".Attributes.IsBlog";
    }


    /// <summary>
    /// Identifies Types that are valid IsLayoutSkin.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IsSkinProvider : Attribute
    {
        public IsSkinProvider()
        {
        }

        public static string AttributeIdentifier = ".Attributes.IsSkinProvider";
    }

    /// <summary>
    /// Describes to the user what the intent of the Skin Provider is.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SkinProviderDescriptionAttribute : Attribute
    {
        public SkinProviderDescriptionAttribute(string description)
        {
            this.description = description;
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }





    /// <summary>
    /// Identifies valid Content Container properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsContentContainer : Attribute
    {
        public IsContentContainer()
        {
        }

        public static string AttributeIdentifier = ".Attributes.IsContentContainer";
    }



    /// <summary>
    /// Identifies valid Content Container properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsCustomProperty : Attribute
    {
        public IsCustomProperty()
        {
        }

        public static string AttributeIdentifier = "+Attributes+IsCustomProperty";
    }


    /// <summary>
    /// Defines what the user friendly name of the property is.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PropertyFriendlyNameAttribute : Attribute
    {
        public PropertyFriendlyNameAttribute(string friendlyName)
        {
            this.friendlyName = friendlyName;
        }

        private string friendlyName;
        public string FriendlyName
        {
            get { return friendlyName; }
            set { friendlyName = value; }
        }
    }


    /// <summary>
    /// Defines what the default value of the property is.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PropertyDefaultValueAttribute : Attribute
    {
        public PropertyDefaultValueAttribute(string defaultValue)
        {
            this.defaultValue = defaultValue;
        }

        private string defaultValue = string.Empty;
        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }
    }


    /// <summary>
    /// Describes to the user what the intent of the property is.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PropertyDescriptionAttribute : Attribute
    {
        public PropertyDescriptionAttribute(string description)
        {
            this.description = description;
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }


    /// <summary>
    /// Suggests to the user what values they should enter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PropertySuggestedUsageAttribute : Attribute
    {
        public PropertySuggestedUsageAttribute(string suggestedUsage)
        {
            this.suggestedUsage = suggestedUsage;
        }

        private string suggestedUsage;
        public string SuggestedUsage
        {
            get { return suggestedUsage; }
            set { suggestedUsage = value; }
        }
    }




    /// <summary>
    /// Controls the size of the input field the user will be 
    /// presented with.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class InputSizeAttribute : Attribute
    {
        public InputSizeAttribute(Various.InputSizes inputSizeToUse)
        {
            InputSize = inputSizeToUse;
        }

        private Various.InputSizes inputSize = Various.InputSizes.SingleLine30x1;
        public Various.InputSizes InputSize
        {
            get { return inputSize; }
            set { inputSize = value; }
        }
    }





    ///// <summary>
    ///// Skin option.
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    //public class PropertySkinOption : Attribute
    //{
    //    public static string AttributeIdentifier = ".Attributes.PropertySkinOption";

    //    public PropertySkinOption(string identifier)
    //    {
    //        this.identifier = identifier;
    //    }

    //    private string identifier;
    //    public string Identifier
    //    {
    //        get { return identifier; }
    //        set { identifier = value; }
    //    }
    //}


    /// <summary>
    /// Defines the background colour for a Content Container drop box.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ContentContainerColour : Attribute
    {
        public static string AttributeIdentifier = ".Attributes.ContentContainerColour";

        public ContentContainerColour(string colour)
        {
            this.colour = colour;
        }

        private string colour;
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
    }


    /// <summary>
    /// Defines an optional description for a Content Container drop box.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ContentContainerDescription : Attribute
    {
        public static string AttributeIdentifier = ".Attributes.ContentContainerDescription";

        public ContentContainerDescription(string description)
        {
            this.description = description;
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }





}