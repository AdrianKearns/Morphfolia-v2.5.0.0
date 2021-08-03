// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.Common.Constants
{
    /// <summary>
    /// Defines constants values for common / system types.
    /// </summary>
	public partial class SystemTypeValues
	{
		/// <summary>
		/// Defines a Null Date as the DateTime Type cannot be set to null.
		/// </summary>
		public static readonly DateTime NullDate = DateTime.Parse("1-1-1800");

		/// <summary>
		/// Defines a Null Int as the Int Type cannot be set to null.
		/// </summary>
		public const int NullInt = -1;

		/// <summary>
		/// Defines a Null double as the double Type cannot be set to null.
		/// </summary>
		public static readonly double NullDouble = Double.Parse("-1");
    }
}

namespace Morphfolia.Common.Constants.Framework
{
    /// <summary>
    /// Defines various string and path constants specific to the Morphfolia Framework.
    /// </summary>
    public partial class Various
    {
        public static readonly char[] Alphabet = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
       

		/// <summary>
		/// Defines the char (a "/") which is commonly used for delimiting strings and 
		/// allowing them to be split().
		/// </summary>
		public static char SplitDelimiter = char.Parse("/");

        /// <summary>
        /// Defines a space as a char, which is commonly used for delimiting strings and 
        /// allowing them to be split().
        /// </summary>
        public static char SpaceChar = char.Parse(" ");

		/// <summary>
		/// Defines the location where the main images are uploaded to and retrieved from.
		/// </summary>
		/// <remarks>The value should be root relative, and not begin with a "/".</remarks>
		/// <example>g_publishing/Images</example>
        public static string MasterImageDirectoryPath = @"Morphfolia/g_publishing/Images";

		/// <summary>
		/// Defines the location where Thumbnail images are uploaded to and retrieved from.
		/// </summary>
		/// <remarks>The value should be root relative, and not begin with a "/".</remarks>
		/// <example>g_publishing/Thumbnails</example>
        public static string ThumbnailImageDirectoryPath = "Morphfolia/g_publishing/Thumbnails";


        public static string FileListingDirectoryPath = "Morphfolia/FileListings";


		/// <summary>
		/// Used as the text (and value?) of an Option in a DropDownBox.
		/// It signals to user that they need to select something.
		/// This option is generally not valid for data entry, and is a prompt only.
		/// </summary>
		public static readonly string PleaseSelect = "Please Select...";

		/// <summary>
		/// Used as the text (and value?) of an Option in a DropDownBox.
		/// It signals to user that something went a bit wrong.
		/// This option is generally not valid for data entry.
		/// </summary>
		public static readonly string NoneAvailable = "None Available";

        /// <summary>
        /// Defines a standard set of text input sizes.
        /// </summary>
        public enum InputSizes { SingleLine30x1, MultipleLine30x3, MultipleLine40x7 }
    }

    /// <summary>
    /// Defines so string values for horizontal and vertical alignments.
    /// </summary>
    public partial class Alignments
    {
        public static readonly string NotSet = "NotSet";
        public static readonly string Bottom = "Bottom";
        public static readonly string Middle = "Middle";
        public static readonly string Top = "Top";
        public static readonly string Left = "Left";
        public static readonly string Center = "Center";
        public static readonly string Right = "Right";
	}

    /// <summary>
    /// Defines the names (and path) of some commonly used images.
    /// </summary>
    public partial class CommonImages
    {
        public static readonly string Folder = "Morphfolia/g/folder.gif";
        public static readonly string Page = "Morphfolia/g/page.gif";
        public static readonly string Spacer = "Morphfolia/g/spacer.gif";
    }

    /// <summary>
    /// Defines the names (and path) of some commonly used images - specifically file type icons (as gif files).
    /// </summary>
    public partial class FileTypeIcons
    {
        public static readonly string Gif = "Morphfolia/g/icon_app_gif.gif";
        public static readonly string Jpg = "Morphfolia/g/icon_app_jpg.gif";
        public static readonly string PowerPoint = "Morphfolia/g/icon_app_MS_PowerPoint.gif";
        public static readonly string Access = "Morphfolia/g/icon_app_MSAccess.gif";
        public static readonly string Excel = "Morphfolia/g/icon_app_MSExcel.gif";
        public static readonly string WebPage = "Morphfolia/g/icon_app_MSIE.gif";
        public static readonly string Text = "Morphfolia/g/icon_app_MSNotepad.gif";
        public static readonly string Visio = "Morphfolia/g/icon_app_MSVisio.gif";
        public static readonly string WordDocument = "Morphfolia/g/icon_app_MSWord.gif";
        public static readonly string PDF = "Morphfolia/g/icon_app_pdf.gif";
        public static readonly string Unknown = "Morphfolia/g/icon_app_unknown.gif";
        public static readonly string Zip = "Morphfolia/g/icon_app_Zip.gif";
        public static readonly string Mp3 = "Morphfolia/g/icon_app_mp3.gif";
    }


    /// <summary>
    /// Defines keys used to sensibly register code with the Client Script Manager class.
    /// </summary>
    public partial class ClientScriptRegistrationKeys
    {
        public static readonly string UrlTypeAheadHelper = "UrlTypeAheadHelper";
        public static readonly string ExpandCollapse = "ExpandCollapse";
        public static readonly string FileListingHelper = "FileListingHelper";
        public static readonly string FileManager = "FileManager";
        public static readonly string ABKEditor_CoreScript = "ABKEditor_CoreScript";
        public static readonly string ImageManager = "ImageManager";
        public static readonly string ThumbnailHelper = "ThumbnailHelper";
        public static readonly string ABKSuggests = "ABKSuggests";
    }


    /// <summary>
    /// Pages / URLs expected by the system, or provided out-of-the-box.
    /// </summary>
    public partial class PageURLs
    {
        public static readonly string SiteMap = "SiteMap.aspx";
        public static readonly string SiteIndex = "SiteIndex.aspx";
        public static readonly string SearchResults = "SearchResults.aspx";
        public static readonly string Login = "Login.aspx";
        public static readonly string Register = "Register.aspx";
        public static readonly string ViewHttpLogs = "morphfolia/_publishing/ViewHttpLogs.aspx";
        public static readonly string TrafficReporter = "morphfolia/_publishing/TrafficReporter.aspx";
        public static readonly string SiteTrafficDashboard = "morphfolia/_publishing/SiteTrafficDashboard.aspx";
        public static readonly string PageTrafficDashboard = "morphfolia/_publishing/PageTrafficDashboard.aspx";
        public static readonly string SessionHistory = "morphfolia/_publishing/SessionHistory.aspx";
        public static readonly string SessionHistoryViewer = "morphfolia/_publishing/SessionHistoryViewer.aspx";
        public static readonly string ViewSystemLogs = "morphfolia/_publishing/Diagnostics/viewlogs.aspx";
        public static readonly string ViewAuditLogs = "morphfolia/_publishing/Diagnostics/ViewAuditLogs.aspx";
        public static readonly string ViewEventIds = "morphfolia/_publishing/Diagnostics/EventIds.aspx";
        public static readonly string ViewAppSettingKeys = "morphfolia/_publishing/Diagnostics/AppSettingKeys.aspx";
    }


    /// <summary>
    /// Defines [Request.] Forms and QueryString keys exposed by various controls and pages.
    /// </summary>
    public partial class RequestKeys
    {
        public static readonly string SearchCriteriaIndentifier = "SearchCriteriaIndentifier";

        public static readonly string TargetUrl = "TURL";
        public static readonly string RequestedUrl = "URL";
        public static readonly string RefererUrl = "RURL";
        public static readonly string MiscInfo = "MI";
        public static readonly string SessionId = "SID";
        public static readonly string UserHostAddress = "UHA";
        public static readonly string WhenFrom = "FRM";
        public static readonly string WhenUntil = "TIL";
    }


    public partial class SpecialCustomPropertyKeys
    {
        public static readonly string LayoutWebControlType = "LayoutWebControlType";
        public static readonly string SkinProviderType = "SkinProviderType";
        public static readonly string FormTemplatePresenterType = "FormTemplatePresenterType";
    }

    public partial class SpecialCustomPropertySuggestedUsages
    {
        public const string HexCode = "HexCode";
        public const string ImagePath = "ImagePath";
        public const string CssClass = "CssClass";
        public const string Unit = "Unit";
    }
}