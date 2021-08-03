// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.SQLDataProvider.Logging
{
    /// <summary>
    /// Defines all known and specific EventIds for the SQL Data Access assembly.
    /// </summary>
    /// <remarks>6000 - 6999</remarks>
    [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines all known and specific EventIds for the SQL Data Access assembly.", "6000 - 6999")]
    internal class EventIds
    {
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6000)]
        public const int Information = 6000;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6001)]
        public const int Warning = 6001;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6002)]
        public const int Error = 6002;

        /// <summary>
        /// Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(666, "Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.")]
        public const int NotSet = 666;


        /// <summary>
        /// 6040, SearchEngineDataProvider, WordIndex_SEARCH().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6040, "Morphfolia.SQLDataProvider, WordIndex_SEARCH().")]
        public const int _6040 = 6040;



        /// <summary>
        /// 6050, Morphfolia.SQLDataProvider, ContentDataProvider, Content_SELECT_ByContentNote().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6050, "Morphfolia.SQLDataProvider, ContentDataProvider, Content_SELECT_ByContentNote().")]
        public const int _6050 = 6050;

        /// <summary>
        /// 6051, Morphfolia.SQLDataProvider, ContentDataProvider, Content_SELECT_PageByID().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6051, "Morphfolia.SQLDataProvider, ContentDataProvider, Content_SELECT_PageByID().")]
        public const int _6051 = 6051;

        /// <summary>
        /// 6052, Morphfolia.SQLDataProvider, ContentDataProvider, Content_SELECT_ByContentID(): Content item not found.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6052, "Morphfolia.SQLDataProvider, ContentDataProvider, Content_SELECT_ByContentID(). Content item not found.")]
        public const int _6052 = 6052;

        /// <summary>
        /// 6053, Morphfolia.SQLDataProvider, ContentDataProvider, Content_INSERT().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6053, "Morphfolia.SQLDataProvider, Content_INSERT().")]
        public const int _6053 = 6053;

        /// <summary>
        /// 6070, Morphfolia.SQLDataProvider, ContentDataProvider, Page_INSERT().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6070, "Morphfolia.SQLDataProvider, Page_INSERT().")]
        public const int _6070 = 6070;

        /// <summary>
        /// 6072, Morphfolia.SQLDataProvider, Page_SELECT_ByURL().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6072, "Morphfolia.SQLDataProvider, Page_SELECT_ByURL().")]
        public const int _6072 = 6072;

        /// <summary>
        /// 6071, Morphfolia.SQLDataProvider, Page_UPDATE().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6071, "Morphfolia.SQLDataProvider, Page_UPDATE().")]
        public const int _6071 = 6071;



        /// <summary>
        /// 6805, Morphfolia.SQLDataProvider.HttpLoggerDataProvider, HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6805, "Morphfolia.SQLDataProvider.HttpLoggerDataProvider, HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange().")]
        public const int _6805 = 6805;

        /// <summary>
        /// 6806, Morphfolia.SQLDataProvider.HttpLoggerDataProvider, HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6806, "Morphfolia.SQLDataProvider.HttpLoggerDataProvider, HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours().")]
        public const int _6806 = 6806;

        /// <summary>
        /// 6807, Morphfolia.SQLDataProvider.HttpLoggerDataProvider, HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6807, "Morphfolia.SQLDataProvider.HttpLoggerDataProvider, HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange().")]
        public const int _6807 = 6807;

        /// <summary>
        /// 6808, Morphfolia.SQLDataProvider.HttpLoggerDataProvider, HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(6808, "Morphfolia.SQLDataProvider.HttpLoggerDataProvider, HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours().")]
        public const int _6808 = 6808;
    }
}