// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Info;
using System;
using System.Data;
using System.Collections.Specialized;

namespace Morphfolia.IDataProvider
{
	/// <summary>
	/// Summary description for ISQLDataProvider.
	/// </summary>
	public interface IPageDataProvider
	{
        PageInfo Page_SELECT_PageByID(int pageId);
        PageInfo Page_SELECT_PageByTitle(string pageTitle);

        PageInfoCollection Page_SELECT_List();
		PageInfoCollection Page_SELECT_ListSearch( PageListerSearchCriteria pageListerSearchCriteria );
        PageInfoCollection Page_SELECT_ByChildContentItem(int contentId);
        PageInfoCollection Page_SELECT_PagesByID(IntCollection pageIds);

		PageInfo Page_SELECT_ByURLForAdminMode( string url );
		PageInfo Page_SELECT_ByURLForLivePublishing( string url );

		StringCollection Page_SELECT_UrlSegmentSearch( string urlHint );

        //ContentInfoCollection Content_SELECT_PageByIDForAdminMode( int pageId );
        //ContentInfoCollection Content_SELECT_PageByIDForLivePublishing(int pageId);

		int Page_INSERT( PageSaveNewInfo pageSaveNewInfo );

		void Page_UPDATE( PageUpdateInfo pageUpdateInfo );
		void Page_UPDATE_Content( int pageId, PageContentUpdateInfoCollection pageContentUpdateInfoCollection );

        void Page_DELETE_ByPageID(int pageId);


	}
}
