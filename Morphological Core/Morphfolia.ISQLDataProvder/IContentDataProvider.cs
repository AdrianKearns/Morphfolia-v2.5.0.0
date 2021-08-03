// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Info;

namespace Morphfolia.IDataProvider
{
	/// <summary>
	/// Summary description for IContentDataProvider.
	/// </summary>
	public interface IContentDataProvider
	{
        ContentInfoCollection Content_SELECT_PageByIDForAdminMode(int pageId);
        ContentInfoCollection Content_SELECT_PageByIDForLivePublishing(int pageId);

        /// <summary>
        /// Gets all content items.
        /// </summary>
        /// <returns></returns>
        ContentListInfoCollection Content_SELECT_List();



       /// <summary>
        /// Gets all content items for a specific content type.
       /// </summary>
       /// <param name="contentType"></param>
       /// <returns></returns>
        ContentListInfoCollection Content_SELECT_List(Common.ContentTypes.ContentTypeDefinition contentType);



        ContentListInfoCollection Content_SELECT_List_ById(int contentId);

        ContentListInfoCollection Content_SELECT_List_ById(IntCollection contentIds);

        /// <summary>
        /// Gets all content items which match the notes filter.
        /// </summary>
        /// <param name="notes">Search string</param>
        /// <returns></returns>
        ContentListInfoCollection Content_SELECT_List_Search(string notes);

        /// <summary>
        /// Gets all content items for a specific content type which match the notes filter.
        /// </summary>
        /// <param name="notes">Search string</param>
        /// <param name="contentType">char(4)</param>
        /// <returns></returns>
        ContentListInfoCollection Content_SELECT_List_Search(string notes, Common.ContentTypes.ContentTypeDefinition contentType);



        //ContentInfoCollection Content_SELECT_SearchLiveOnly(string notes, Common.ContentTypes.ContentTypeDefinition contentType);
        ContentInfoCollection Content_SELECT_SearchLiveOnly(string notes);


		ContentInfoCollection Content_SELECT( Common.Info.IntCollection contentIds );


        ContentInfoCollection Content_SELECT(Common.ContentTypes.ContentTypeDefinition contentType);


        // <summary>
        // Gets posts that are not older than this date specified.
        // </summary>
        // <param name="startDate">Gets posts that are equal to or more recent than this date.</param>
        // <returns></returns>
        //ContentListInfoCollection Content_SELECT_List(DateTime startDate);

        // <summary>
        // Gets posts based on a date range.
        // </summary>
        // <param name="startDate">Gets posts that are equal to or more recent than this date.</param>
        // <param name="endDate">Gets posts that are older than this date.</param>
        // <returns></returns>
        //ContentListInfoCollection Content_SELECT_List(DateTime startDate, DateTime endDate);


         ContentListInfoCollection Content_SELECT_List(DateTime startDate, Common.ContentTypes.ContentTypeDefinition contentType);
 

         ContentListInfoCollection Content_SELECT_List(DateTime startDate, Common.ContentTypes.ContentTypeDefinition contentType, int pageId);


         ContentListInfoCollection Content_SELECT_List(DateTime startDate, DateTime endDate, Common.ContentTypes.ContentTypeDefinition contentType);


         ContentListInfoCollection Content_SELECT_List(DateTime startDate, DateTime endDate, Common.ContentTypes.ContentTypeDefinition contentType, int pageId);






         //BlogPostInfoCollection Content_SELECT(DateTime startDate, Common.ContentTypes.ContentTypeDefinition contentType);


         //BlogPostInfoCollection Content_SELECT(DateTime startDate, Common.ContentTypes.ContentTypeDefinition contentType, int pageId);


         //BlogPostInfoCollection Content_SELECT(DateTime startDate, DateTime endDate, Common.ContentTypes.ContentTypeDefinition contentType);


         //BlogPostInfoCollection Content_SELECT(DateTime startDate, DateTime endDate, Common.ContentTypes.ContentTypeDefinition contentType, int pageId);


         BlogPostInfoCollection Content_SELECT_ForBlogRSS(int pageId, Common.ContentTypes.ContentTypeDefinition contentType);




        /// <summary>
        /// Gets a content item, regardless of isLive flag.
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
        ContentInfo Content_SELECT_ByContentID(int contentId);

        /// <summary>
        /// Gets a content item by it's note.
        /// </summary>
        /// <param name="contentNote"></param>
        /// <param name="liveContentOnly">bool - if true the query will only return the item if it is live.</param>
        /// <returns></returns>
        ContentInfo Content_SELECT_ByContentNote(string contentNote, bool liveContentOnly);


        /// <summary>
        /// Gets the latest 'full' content item, by page id.
        /// </summary>
        /// <remarks>Content is only returned where it and it's parent page are live (IsLive).  
        /// This method is intended to be used when the latest blog post(s) or recently modified content 
        /// is wanted, as such implementers may wish to throttle the amount of data returned. 
        /// The default MS SQL provider implementation throttles the results to the last 3 (most recent) items.</remarks>
        /// <param name="pageId">the id of the page to get the latest content for.</param>
        /// <param name="propertyType">The type of content to get (the default is blog posts).</param>
        /// <returns>A collection of content items.</returns>
        ContentInfoCollection Content_SELECT_LatestLiveByPageId(int pageId, Common.ContentTypes.ContentTypeDefinition contentType, int maxNumberOfRecordsToReturn);

        ContentListInfoCollection Content_SELECT_ListLatestLiveByPageId(int pageId, Common.ContentTypes.ContentTypeDefinition contentType, int maxNumberOfRecordsToReturn);




        void Content_UPDATE(ContentUpdateInfo contentUpdateInfo);
		int Content_INSERT( ContentSaveNewInfo contentSaveNewInfo );
        void Content_DELETE(int contentId);
	}
}
