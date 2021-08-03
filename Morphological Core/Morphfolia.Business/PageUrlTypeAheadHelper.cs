// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using Morphfolia.Business.Constants;

namespace Morphfolia.Business
{
	/// <summary>
	/// Summary description for UrlTypeAheadHelper.
	/// </summary>
	public class PageUrlTypeAheadHelper
	{
        private static Morphfolia.IDataProvider.IPageDataProvider iPageDataProvider;
        private static Morphfolia.IDataProvider.IPageDataProvider IPageDataProvider
        {
            get
            {
                if (iPageDataProvider == null)
                {
                    iPageDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IPageDataProvider) as Morphfolia.IDataProvider.IPageDataProvider;
                }
                return iPageDataProvider;
            }
        }




		public static StringCollection List( string urlHint )
		{
			try
			{
                return IPageDataProvider.Page_SELECT_UrlSegmentSearch(urlHint);
			}
			catch
			{
				throw;
			}
		}
	}
}
