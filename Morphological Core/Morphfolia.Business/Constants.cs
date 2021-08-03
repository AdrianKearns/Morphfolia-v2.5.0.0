// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Attributes;

namespace Morphfolia.Business.Constants
{
    [IsAppSettingKeyClass("Defines the AppSettings used to identify DataProviders.")]
    public class DataProviderAppSettingKeys
    {
        [IsAppSettingKey("Morphfolia.IAuditorDataProvider", "Identifies the DataProvider to use for Audit Logging.", "Expected value is 'type, assembly'.")]
        public const string IAuditorDataProvider = "Morphfolia.IAuditorDataProvider";

        [IsAppSettingKey("Morphfolia.IContentDataProvider", "Identifies the DataProvider to use for Content.", "Expected value is 'type, assembly'.")]
        public const string IContentDataProvider = "Morphfolia.IContentDataProvider";

        [IsAppSettingKey("Morphfolia.IContentIndexerDataProvider", "Identifies the DataProvider to use for Content Indexing.", "Expected value is 'type, assembly'.")]
        public const string IContentIndexerDataProvider = "Morphfolia.IContentIndexerDataProvider";

        [IsAppSettingKey("Morphfolia.ICustomPropertiesDataProvider", "Identifies the DataProvider to use for Custom Properties.", "Expected value is 'type, assembly'.")]
        public const string ICustomPropertiesDataProvider = "Morphfolia.ICustomPropertiesDataProvider";

        [IsAppSettingKey("Morphfolia.IHttpLoggerDataProvider", "Identifies the DataProvider to use for Http-Logging.", "Expected value is 'type, assembly'.")]
        public const string IHttpLoggerDataProvider = "Morphfolia.IHttpLoggerDataProvider";

        [IsAppSettingKey("Morphfolia.IImageDataProvider", "Identifies the DataProvider to use for Image information.", "Expected value is 'type, assembly'.")]
        public const string IImageDataProvider = "Morphfolia.IImageDataProvider";

        [IsAppSettingKey("Morphfolia.IPageDataProvider", "Identifies the DataProvider to use for Page information.", "Morphfolia.SQLDataProvider.PageDataProvider,Morphfolia.SQLDataProvider")]
        public const string IPageDataProvider = "Morphfolia.IPageDataProvider";

        [IsAppSettingKey("Morphfolia.ISearchEngineDataProvider", "Identifies the DataProvider to use for Search Engine functionality.", "Expected value is 'type, assembly'.")]
        public const string ISearchEngineDataProvider = "Morphfolia.ISearchEngineDataProvider";

        [IsAppSettingKey("Morphfolia.IDataProviderInformation", "Identifies the DataProvider to use for providing information on the current data provider.", "Expected value is 'type, assembly'.")]
        public const string IDataProviderInformation = "Morphfolia.IDataProviderInformation";

        [IsAppSettingKey("Morphfolia.ILogViewer", "Identifies the DataProvider to use for Log Reporting.", "Expected value is 'type, assembly'.")]
        public const string ILogViewer = "Morphfolia.ILogViewer";


    }
}
