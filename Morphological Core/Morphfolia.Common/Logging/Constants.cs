// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 


namespace Morphfolia.Common.Logging
{
    /// <summary>
    /// The categories here (the actual values) should 
    /// all have corresponding entries in the config 
    /// for EntLib Logging.
    /// </summary>
    public class Categories
    {
        public const string General = "Morphfolia General";

        public const string Website = "Morphfolia Website";

        public const string BusinessLogic = "Morphfolia Business Logic";

        public const string DataAccess = "Morphfolia Data Access";

        public const string PageLayoutAndSkinAssistant = "Morphfolia Page-Layout and Skin Assistant";

        public const string PublishingSystem = "Morphfolia Publishing System";

        public const string WebControls = "Morphfolia WebControls";

    }

    public class Severity
    {
        public const string Information = "Information";
        public const string Verbose = "Verbose";
        public const string Warnings = "Warning";
        public const string Exceptions = "Error";
    }

    public class Priorities
    {
        /// <summary>
        /// 0, Used primarily for debugging and development.
        /// </summary>
        public const int VerboseDebugging = 0;

        /// <summary>
        /// 20, Used primarily for debugging and development.
        /// </summary>
        public const int VerboseIAppearanceTemplateDebugging = 20;

        /// <summary>
        /// 100, Normal.
        /// </summary>
        public const int Normal = 100;

        /// <summary>
        /// 200, Alert.
        /// </summary>
        /// <remarks>Typically used where you want to be notified of something - such
        /// as when a user creates a new account, or a support ticket;  Would typically 
        /// result in additional logging or notification via email.</remarks>
        public const int Alert = 200;

        /// <summary>
        /// 100, Normal.
        /// </summary>
        public const int Warnings = 500;

        /// <summary>
        /// 1000, Exceptions.
        /// </summary>
        public const int Exceptions = 1000;
    }
}