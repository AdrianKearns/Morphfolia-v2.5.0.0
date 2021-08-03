// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.IDataProvider
{
	/// <summary>
    /// Summary description for ISearchEngineDataProvider.
	/// </summary>
    public interface ISearchEngineDataProvider
	{
		Morphfolia.Common.Info.WordIndexSearchResultInfoCollection WordIndex_SEARCH( string criteria );
		Morphfolia.Common.Info.SearchResultInfoCollection Content_SEARCH( string criteria );
	}
}
