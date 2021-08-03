// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Info;
using Morphfolia.Business.Constants;
using Morphfolia.Business.Logging;
using Morphfolia.IDataProvider;

namespace Morphfolia.Business
{
	/// <summary>
	/// Handles content (index) searching.
	/// </summary>
	public class SearchEngine
	{
        private static ISearchEngineDataProvider iSearchEngineDataProvider;
        private static ISearchEngineDataProvider ISearchEngineDataProvider
        {
            get
            {
                if (iSearchEngineDataProvider == null)
                {
                    iSearchEngineDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.ISearchEngineDataProvider) as Morphfolia.IDataProvider.ISearchEngineDataProvider;
                }
                return iSearchEngineDataProvider;
            }
        }


		public static WordIndexSearchResultInfoCollection WordIndex_SEARCH( string criteria )
		{
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.BusinessLogic, TraceGuids._4200))
            {
                return ISearchEngineDataProvider.WordIndex_SEARCH(criteria);
            }
		}


        public static SearchResultInfoCollection Search(string criteria)
		{
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.BusinessLogic, TraceGuids._4201))
            {
                return ISearchEngineDataProvider.Content_SEARCH(criteria);
            }
		}
	}
}
