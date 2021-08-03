// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Morphfolia.IDataProvider;
using Morphfolia.SQLDataProvider.Logging;
using Morphfolia.SQLDataProvider.Utilities;
using Morphfolia.Common.Constants;
using Morphfolia.Common.Info;
using System.Collections.Specialized;

namespace Morphfolia.SQLDataProvider
{
	/// <summary>
	/// Summary description for ContentDataProvider.
	/// </summary>
	public class ContentDataProvider : IContentDataProvider
	{
        /// <summary>
        /// The different modes in which we can ask for a page
        /// </summary>
        private enum ModeOfOperation { NotSet, AdminMode, LivePublishingMode }


        public ContentInfoCollection Content_SELECT_PageByIDForLivePublishing(int pageId)
        {
            return Content_SELECT_PageByID(pageId, ModeOfOperation.LivePublishingMode);
        }


        public ContentInfoCollection Content_SELECT_PageByIDForAdminMode(int pageId)
        {
            return Content_SELECT_PageByID(pageId, ModeOfOperation.AdminMode);
        }


        private ContentInfoCollection Content_SELECT_PageByID(int pageId, ModeOfOperation modeOfOperation)
        {
            string spName = "NotSet";

            switch (modeOfOperation)
            {
                case ModeOfOperation.AdminMode:
                    spName = "Content_SELECT_PageByID";
                    break;

                case ModeOfOperation.LivePublishingMode:
                    spName = "Content_SELECT_PageByID_ForLivePublishing";
                    break;

                default:
                    spName = "Content_SELECT_PageByID_ForLivePublishing";
                    break;
            }


            ContentInfo contentInfo;
            ContentInfoCollection contentInfoCollection = new ContentInfoCollection();

            try
            {
                Logger.LogVerboseInformation("Content_SELECT_PageByID invoked...", string.Format("sp = '{0}', pageid = '{1}'", spName, pageId), EventIds._6051);


                using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                    spName, pageId))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DateTime lastModified;

                            try
                            {
                                lastModified = DateTime.Parse(dr["LastModified"].ToString());
                            }
                            catch
                            {
                                lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                            }

                            contentInfo = new ContentInfo(
                                int.Parse(dr["ContentID"].ToString()),
                                dr["Content"].ToString(),
                                dr["TextContent"].ToString(),
                                dr["Note"].ToString(),
                                Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                                (bool)dr["IsLive"],
                                (bool)dr["IsSearchable"],
                                dr["ContentFilter"].ToString(),
                                lastModified,
                                dr["LastModifiedBy"].ToString());
                            contentInfoCollection.Add(contentInfo);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.LogException("Content_SELECT_PageByID failed", ex, EventIds._6051, string.Format("sp = '{0}', pageid = '{1}'", spName, pageId));
            }

            return contentInfoCollection;
        }


        public ContentInfo Content_SELECT_ByContentNote(string contentNote, bool liveContentOnly)
        {
            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_ByContentNote", contentNote, liveContentOnly))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DateTime lastModified;

                        try
                        {
                            lastModified = DateTime.Parse(dr["LastModified"].ToString());
                        }
                        catch
                        {
                            lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }

                        ContentInfo contentInfo = new ContentInfo(
                            int.Parse(dr["ContentID"].ToString()),
                            dr["Content"].ToString(),
                            dr["TextContent"].ToString(),
                            dr["Note"].ToString(),
                            Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                            (bool)dr["IsLive"],
                            (bool)dr["IsSearchable"],
                            dr["ContentFilter"].ToString(),
                            lastModified,
                            dr["LastModifiedBy"].ToString());

                        return contentInfo;
                    }
                }
                else
                {
                    Logger.LogInformation("Content_SELECT_ByContentNote - item not found.", string.Format("Args: contentNote=[{0}] liveContentOnly=[{1}]", contentNote, liveContentOnly.ToString()), EventIds._6050);
                }
            }

            return ContentInfoFactory.NullContentInfo("Sorry, the requested item was not found.", contentNote);
        }

        /// <summary>
        /// Should only be used in an Admin context as it will return content 
        /// regardless of the value of the 'IsLive' flag.
        /// </summary>
        /// <returns></returns>
        public ContentListInfoCollection Content_SELECT_List()
        {
            return Content_SELECT_List(Common.ContentTypes.All);
        }


        public ContentListInfoCollection Content_SELECT_List(Common.ContentTypes.ContentTypeDefinition contentType)
        {
			ContentListInfo contentListInfo;
			ContentListInfoCollection contentListInfoCollection = new ContentListInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_List", contentType.MachineValue))
			{
				if (dr.HasRows)
				{
					while(dr.Read())
					{
						DateTime lastModified;
					
						try
						{
							lastModified = DateTime.Parse( dr["LastModified"].ToString() );
						}
						catch
						{
							lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
						}

						contentListInfo = new ContentListInfo(
							(int)dr["ContentID"],
							//dr["TextContent"].ToString(),
							dr["Note"].ToString(),
                            Common.ContentTypes.Factory(dr["ContentType"].ToString()),
							(bool)dr["IsLive"],
							(bool)dr["IsSearchable"],
							lastModified,
							dr["LastModifiedBy"].ToString(),
							(int)dr["PageUsageCount"]
							);

						contentListInfoCollection.Add( contentListInfo );
					}
				}
			}

			return contentListInfoCollection;
		}


        public ContentListInfoCollection Content_SELECT_List_Search(string notes)
        {
            return Content_SELECT_List_Search(notes, Common.ContentTypes.All); // XXX
        }


        public ContentListInfoCollection Content_SELECT_List_Search(string notes, Common.ContentTypes.ContentTypeDefinition contentType)
        {
            ContentListInfo contentListInfo;
            ContentListInfoCollection contentListInfoCollection = new ContentListInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_List_Search", notes, contentType.MachineValue))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DateTime lastModified;

                        try
                        {
                            lastModified = DateTime.Parse(dr["LastModified"].ToString());
                        }
                        catch
                        {
                            lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }


                        contentListInfo = new ContentListInfo(
                            (int)dr["ContentID"],
                            dr["Note"].ToString(),
                            Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                            (bool)dr["IsLive"],
                            (bool)dr["IsSearchable"],
                            lastModified,
                            dr["LastModifiedBy"].ToString(),
                            (int)dr["PageUsageCount"]
                            );

                        contentListInfoCollection.Add(contentListInfo);
                    }
                }
            }

            Logging.Logger.LogVerboseInformation("SQLDataProvider, Content_SELECT_List_Search()", string.Format("Content_SELECT_List_Search '{0}', '{1}'    -- {2} items returned.",
                notes,
                contentType.MachineValue,
                contentListInfoCollection.Count.ToString()));

            return contentListInfoCollection;
        }


        public ContentListInfoCollection Content_SELECT_List_ById(int contentId)
        {
            IntCollection ids = new IntCollection();
            ids.Add(contentId);
            return Content_SELECT_List_ById(ids);
        }


        public ContentListInfoCollection Content_SELECT_List_ById(IntCollection contentIds)
        {
            // Preserve the IntCollection of contentIds that was passed in.
            IntCollection workingCollectionOfIds = new IntCollection();
            foreach (int i in contentIds)
            {
                workingCollectionOfIds.Add(i);
            }


            ContentListInfo contentListInfo;
            ContentListInfoCollection contentListInfoCollection = new ContentListInfoCollection();

            // the sp can take upto 5 ids at a time, batch up query into batches of 5 ids, append to out going collection and return.

            int fullBatchCount = workingCollectionOfIds.Count / 5;
            for (int s = 0; s <= fullBatchCount; s++)
            {
                int temp;
                if (workingCollectionOfIds.Count < 5)
                {
                    temp = 5 - workingCollectionOfIds.Count;
                    for (int m = 0; m < temp; m++)
                    {
                        workingCollectionOfIds.Add(Common.Constants.SystemTypeValues.NullInt);                        
                    }
                }

                //Logger.LogVerboseInformation("current 5", string.Format("[{0}|{1}|{2}|{3}|{4}]", workingCollectionOfIds[0], workingCollectionOfIds[1], workingCollectionOfIds[2], workingCollectionOfIds[3], workingCollectionOfIds[4]));

                using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_List_ById",
                    workingCollectionOfIds[0], workingCollectionOfIds[1], workingCollectionOfIds[2], workingCollectionOfIds[3], workingCollectionOfIds[4]))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DateTime lastModified;

                            try
                            {
                                lastModified = DateTime.Parse(dr["LastModified"].ToString());
                            }
                            catch
                            {
                                lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                            }


                            contentListInfo = new ContentListInfo(
                                (int)dr["ContentID"],
                                dr["Note"].ToString(),
                                Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                                (bool)dr["IsLive"],
                                (bool)dr["IsSearchable"],
                                lastModified,
                                dr["LastModifiedBy"].ToString(),
                                (int)dr["PageUsageCount"]
                                );

                            contentListInfoCollection.Add(contentListInfo);
                        }
                    }
                }
                workingCollectionOfIds.RemoveAt(0);
                workingCollectionOfIds.RemoveAt(0);
                workingCollectionOfIds.RemoveAt(0);
                workingCollectionOfIds.RemoveAt(0);
                workingCollectionOfIds.RemoveAt(0);
            }

            return contentListInfoCollection;
        }


        // public ContentInfoCollection Content_SELECT_SearchLiveOnly(string notes, Common.ContentTypes.ContentTypeDefinition contentType)
        public ContentInfoCollection Content_SELECT_SearchLiveOnly(string notes)
        {
            ContentInfo contentInfo;
            ContentInfoCollection contentInfoCollection = new ContentInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_SearchLiveOnly", notes))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DateTime lastModified;

                        try
                        {
                            lastModified = DateTime.Parse(dr["LastModified"].ToString());
                        }
                        catch
                        {
                            lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }


                        contentInfo = new ContentInfo(
                            (int)dr["ContentID"],
                            dr["Content"].ToString(),
                            dr["TextContent"].ToString(),
                            dr["Note"].ToString(),
                            Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                            (bool)dr["IsLive"],
                            (bool)dr["IsSearchable"],
                            dr["ContentFilter"].ToString(),
                            lastModified,
                            dr["LastModifiedBy"].ToString()
                            );

                        contentInfoCollection.Add(contentInfo);
                    }
                }
            }

            Logging.Logger.LogVerboseInformation("SQLDataProvider, Content_SELECT_SearchLiveOnly()", string.Format("Content_SELECT_SearchLiveOnly '{0}'    --> {1} items returned.",
                notes,
                contentInfoCollection.Count.ToString()));

            return contentInfoCollection;
        }


        public ContentInfoCollection Content_SELECT(Common.ContentTypes.ContentTypeDefinition contentType)
        {
            ContentInfo contentInfo;
            ContentInfoCollection contentInfoCollection = new ContentInfoCollection();
            //@txtNotes
            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT", contentType.MachineValue))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DateTime lastModified;

                        try
                        {
                            lastModified = DateTime.Parse(dr["LastModified"].ToString());
                        }
                        catch
                        {
                            lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }


                        contentInfo = new ContentInfo(
                            (int)dr["ContentID"],
                            dr["Content"].ToString(),
                            string.Empty,//dr["TextContent"].ToString(),
                            dr["Note"].ToString(),
                            Common.ContentTypes.Factory( dr["ContentType"].ToString() ),
                            (bool)dr["IsLive"],
                            (bool)dr["IsSearchable"],
                            dr["ContentFilter"].ToString(),
                            lastModified,
                            dr["LastModifiedBy"].ToString()
                            );

                        contentInfoCollection.Add(contentInfo);
                    }
                }
            }

            return contentInfoCollection;
        }


        public ContentListInfoCollection Content_SELECT_List(DateTime startDate, Common.ContentTypes.ContentTypeDefinition contentType)
        {
            return Content_SELECT_List(startDate, DateTime.Now.AddDays(1), contentType, Common.Constants.SystemTypeValues.NullInt);
        }


        public ContentListInfoCollection Content_SELECT_List(DateTime startDate, Common.ContentTypes.ContentTypeDefinition contentType, int pageId)
        {
            return Content_SELECT_List(startDate, DateTime.Now.AddDays(1), contentType, pageId);
        }


        public ContentListInfoCollection Content_SELECT_List(DateTime startDate, DateTime endDate, Common.ContentTypes.ContentTypeDefinition contentType)
        {
            return Content_SELECT_List(startDate, endDate, contentType, Common.Constants.SystemTypeValues.NullInt);
        }

        /// <summary>
        /// Warning - this provider makes a direct call to the CustomPropertiesDataProvider.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public ContentListInfoCollection Content_SELECT_List(DateTime startDate, DateTime endDate, Common.ContentTypes.ContentTypeDefinition contentType, int pageId)
        {
            CustomPropertiesDataProvider cdp = new CustomPropertiesDataProvider();

            ContentListInfo info;
            ContentListInfoCollection collection = new ContentListInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_ListByDateLastModified", 
                startDate, 
                endDate, 
                contentType.MachineValue,
                pageId))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DateTime contentLastModified;

                        try
                        {                            
                            contentLastModified = DateTime.Parse(dr["ContentLastModified"].ToString());
                        }
                        catch
                        {
                            contentLastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }

                        info = new ContentListInfo(
                            (int)dr["ContentID"],
                            dr["ContentNote"].ToString(),
                            //dr["Content"].ToString(),
                            Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                            (bool)dr["ContentIsLive"],
                            (bool)dr["ContentIsSearchable"],
                            //dr["ContentEntryFilter"].ToString(),
                            contentLastModified,
                            dr["ContentLastModifiedBy"].ToString(),
                            Common.Constants.SystemTypeValues.NullInt
                            );

                        collection.Add(info);
                    }
                }
            }

            return collection;
        }





        //public BlogPostInfoCollection Content_SELECT(DateTime startDate, Common.ContentTypes.ContentTypeDefinition contentType)
        //{
        //    return Content_SELECT(startDate, DateTime.Now.AddDays(1), contentType, Common.Constants.SystemTypeValues.NullInt);
        //}


        //public BlogPostInfoCollection Content_SELECT(DateTime startDate, Common.ContentTypes.ContentTypeDefinition contentType, int pageId)
        //{
        //    return Content_SELECT(startDate, DateTime.Now.AddDays(1), contentType, pageId);
        //}


        //public BlogPostInfoCollection Content_SELECT(DateTime startDate, DateTime endDate, Common.ContentTypes.ContentTypeDefinition contentType)
        //{
        //    return Content_SELECT(startDate, endDate, contentType, Common.Constants.SystemTypeValues.NullInt);
        //}


        //public BlogPostInfoCollection Content_SELECT(DateTime startDate, DateTime endDate, Common.ContentTypes.ContentTypeDefinition contentType, int pageId)
        //{
        //    CustomPropertiesDataProvider cdp = new CustomPropertiesDataProvider();
        //    CustomPropertyInstanceInfoCollection contentTags;
        //    StringCollection tags;

        //    BlogPostInfo info;
        //    BlogPostInfoCollection collection = new BlogPostInfoCollection();

        //    using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_ListByDateLastModified",
        //        startDate,
        //        endDate,
        //        contentType.MachineValue,
        //        pageId))
        //    {
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                int contentId;
        //                DateTime contentLastModified;
        //                DateTime pageLastModified;


        //                contentId = (int)dr["ContentID"];


        //                contentTags = cdp.ControlProperties_SELECT_BYInstanceIDPropertyType(contentId, Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CTAG);
        //                tags = new StringCollection();
        //                if (contentTags.Count == 0)
        //                {
        //                    Logging.Logger.LogVerboseInformation("Content_SELECT", "contentTags.count == 0");
        //                }
        //                else
        //                {
        //                    Logging.Logger.LogVerboseInformation("Content_SELECT", string.Format("contentTags.count == {0}", contentTags.Count.ToString()));

        //                    for (int t = 0; t < contentTags.Count; t++)
        //                    {
        //                        tags.Add(contentTags[t].PropertyValue);
        //                    }
        //                }


        //                try
        //                {
        //                    contentLastModified = DateTime.Parse(dr["ContentLastModified"].ToString());
        //                }
        //                catch
        //                {
        //                    contentLastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
        //                }

        //                try
        //                {
        //                    pageLastModified = DateTime.Parse(dr["PageLastModified"].ToString());
        //                }
        //                catch
        //                {
        //                    pageLastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
        //                }


        //                info = new BlogPostInfo(
        //                    contentId,
        //                    dr["ContentNote"].ToString(),
        //                    dr["Content"].ToString(),
        //                    Common.ContentTypes.Factory(dr["ContentType"].ToString()),
        //                    (bool)dr["ContentIsLive"],
        //                    (bool)dr["ContentIsSearchable"],
        //                    dr["ContentEntryFilter"].ToString(),
        //                    contentLastModified,
        //                    dr["ContentLastModifiedBy"].ToString(),
        //                    (int)dr["PageID"],
        //                    dr["PageTitle"].ToString(),
        //                    dr["PageUrl"].ToString(),
        //                    dr["PageKeywords"].ToString(),
        //                    dr["PageDescription"].ToString(),
        //                    pageLastModified,
        //                    dr["PageLastModifiedBy"].ToString(),
        //                    (bool)dr["PageIsSearchable"],
        //                    (bool)dr["PageIsLive"],
        //                    tags
        //                    );

        //                collection.Add(info);
        //            }
        //        }
        //    }

        //    return collection;
        //}
        


        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //public ContentListInfoCollection Content_SELECT(DateTime startDate)
        //{
        //    return Content_SELECT(startDate, DateTime.Now.AddDays(1));
        //}

        /// <summary>
        /// Warning - this provider makes a direct call to the CustomPropertiesDataProvider.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public BlogPostInfoCollection Content_SELECT_ForBlogRSS(int pageId, Common.ContentTypes.ContentTypeDefinition contentType)
        {
            CustomPropertiesDataProvider cdp = new CustomPropertiesDataProvider();
            CustomPropertyInstanceInfoCollection contentTags;
            StringCollection tags = new StringCollection();

            BlogPostInfo blogPostListInfo;
            BlogPostInfoCollection blogPostListInfoCollection = new BlogPostInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_ForBlogRSS", pageId, contentType.MachineValue))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int contentId;
                        DateTime contentLastModified;
                        DateTime pageLastModified;


                        contentId = (int)dr["ContentID"];


                        contentTags = cdp.ControlProperties_SELECT_BYInstanceIDPropertyType(contentId, Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CTAG);
                        tags = new StringCollection();
                        if (contentTags.Count == 0)
                        {
                            Logging.Logger.LogVerboseInformation("Content_SELECT", "contentTags.count == 0");
                        }
                        else
                        {
                            Logging.Logger.LogVerboseInformation("Content_SELECT", string.Format("contentTags.count == {0}", contentTags.Count.ToString()));

                            for (int t = 0; t < contentTags.Count; t++)
                            {
                                tags.Add(contentTags[t].PropertyValue);
                            }
                        }


                        try
                        {
                            contentLastModified = DateTime.Parse(dr["ContentLastModified"].ToString());
                        }
                        catch
                        {
                            contentLastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }

                        try
                        {
                            pageLastModified = DateTime.Parse(dr["PageLastModified"].ToString());
                        }
                        catch
                        {
                            pageLastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }


                        blogPostListInfo = new BlogPostInfo(
                            contentId,
                            dr["ContentNote"].ToString(),
                            dr["Content"].ToString(),
                            Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                            (bool)dr["ContentIsLive"],
                            (bool)dr["ContentIsSearchable"],
                            dr["ContentEntryFilter"].ToString(),
                            contentLastModified,
                            dr["ContentLastModifiedBy"].ToString(),
                            //Common.Constants.SystemTypeValues.NullInt,
                            (int)dr["PageID"],
                            dr["PageTitle"].ToString(),
                            dr["PageUrl"].ToString(),
                            dr["PageKeywords"].ToString(),
                            dr["PageDescription"].ToString(),
                            pageLastModified,
                            dr["PageLastModifiedBy"].ToString(),
                            (bool)dr["PageIsSearchable"],
                            (bool)dr["PageIsLive"],
                            tags
                            );

                        blogPostListInfoCollection.Add(blogPostListInfo);
                    }
                }
            }

            return blogPostListInfoCollection;
        }




        /// <summary>
        /// Should only be used in an Admin context as it will return content 
        /// regardless of the value of the 'IsLive' flag.
        /// </summary>
        /// <param name="contentIds"></param>
        /// <returns></returns>
		public ContentInfoCollection Content_SELECT( IntCollection contentIds )
		{
			ContentInfoCollection contentInfoCollection = new ContentInfoCollection();
			
			for( int i = 0; i < contentIds.Count; i++ )
			{
				contentInfoCollection.Add( Content_SELECT_ByContentID( contentIds[i] ) );
			}

			return contentInfoCollection;
		}

        /// <summary>
        /// Will return a content item (if it exists) regardless of the value of the 'IsLive' flag.
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
		public ContentInfo Content_SELECT_ByContentID( int contentId )
		{
			ContentInfo contentInfo;
            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
					   "Content_SELECT_ByContentID", 
					   contentId))
			{
				if (dr.Read())
				{
					DateTime lastModified;
					
					try
					{
						lastModified = DateTime.Parse( dr["LastModified"].ToString() );
					}
					catch
					{
						lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
					}


					contentInfo = new ContentInfo(
						(int)dr["ContentID"],
						dr["Content"].ToString(),
						dr["TextContent"].ToString(),
						dr["Note"].ToString(),
                        Common.ContentTypes.Factory(dr["ContentType"].ToString()),
						(bool)dr["IsLive"],
						(bool)dr["IsSearchable"],
                        dr["ContentFilter"].ToString(),
						lastModified,
						dr["LastModifiedBy"].ToString()
						);
				}
                else
                {
                    contentInfo = ContentInfoFactory.NullContentInfo(string.Empty, string.Empty);
                    Logger.LogWarning("Content_SELECT_ByContentID(); contentId not found.", string.Format("contentId = {0}", contentId.ToString()), EventIds._6052);

                    // Is this REALLY exceptional?
                    // Would need to return some sort of 'null' value.
                    //throw new Exceptions.SQLDataProviderException(string.Format("Could not find a content item with this ID: {0}", contentId.ToString()));
                }
			}
			return contentInfo;
		}


        public ContentInfoCollection Content_SELECT_LatestLiveByPageId(int pageId, Common.ContentTypes.ContentTypeDefinition contentType, int maxNumberOfPostsToReturn)
        {
            ContentInfo info;
            ContentInfoCollection collection = new ContentInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_LatestLiveByPageId", pageId, contentType.MachineValue))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DateTime contentLastModified;

                        try
                        {
                            contentLastModified = DateTime.Parse(dr["LastModified"].ToString());
                        }
                        catch
                        {
                            contentLastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }

                        info = new ContentInfo(
                            (int)dr["ContentID"],
                            dr["Content"].ToString(),
                            dr["TextContent"].ToString(),
                            dr["Note"].ToString(),
                            Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                            (bool)dr["IsLive"],
                            (bool)dr["IsSearchable"],
                            dr["ContentFilter"].ToString(),
                            contentLastModified,
                            dr["LastModifiedBy"].ToString()
                            );

                        collection.Add(info);
                    }
                }
            }

            return collection;
        }

        /// <summary>
        /// Bit of a bodge - SP will return extra fat columns that we don't 
        /// currently need, and ignores the PageUsageCount member of the ContentListInfo.
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public ContentListInfoCollection Content_SELECT_ListLatestLiveByPageId(int pageId, Common.ContentTypes.ContentTypeDefinition contentType, int maxNumberOfPostsToReturn)
        {
            //throw new NotImplementedException("write a proper SP that can do the PageUsageCount, only gets the columns needed, and gets for a specific page or all.");

            int currentCount = 0;
            ContentListInfo info;
            ContentListInfoCollection collection = new ContentListInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Content_SELECT_ListLatestLiveByPageId",
                pageId, 
                contentType.MachineValue))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (currentCount < maxNumberOfPostsToReturn)
                        {
                            Logger.LogVerboseInformation("Content_SELECT_ListLatestLiveByPageId()", string.Format("maxCount: {0}, currentCount: {1}", maxNumberOfPostsToReturn.ToString(), currentCount.ToString()));

                            DateTime contentLastModified;
                            if (!DateTime.TryParse(dr["LastModified"].ToString(), out contentLastModified))
                            {
                                contentLastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                            }

                            info = new ContentListInfo(
                                (int)dr["ContentID"],
                                //dr["Content"].ToString(),
                                //dr["TextContent"].ToString(),
                                dr["Note"].ToString(),
                                Common.ContentTypes.Factory(dr["ContentType"].ToString()),
                                (bool)dr["IsLive"],
                                (bool)dr["IsSearchable"],
                                //dr["ContentFilter"].ToString(),
                                contentLastModified,
                                dr["LastModifiedBy"].ToString(),
                                (int)dr["PageUsageCount"]
                                );

                            collection.Add(info);

                            currentCount++;
                        }
                        else
                        {
                            break;
                        }


                    }
                }
            }

            return collection;
        }


		public void Content_UPDATE( ContentUpdateInfo contentUpdateInfo )
		{
            try
            {
                SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("Content_UPDATE",    
									   contentUpdateInfo.ContentID,
									   contentUpdateInfo.Content,
									   contentUpdateInfo.TextContent,
									   contentUpdateInfo.Note,
									   contentUpdateInfo.IsLive,
									   contentUpdateInfo.IsSearchable,
									   contentUpdateInfo.LastModifiedBy);
            }
            catch (Exception ex)
            {
                throw new Exceptions.SQLDataProviderException("Content_UPDATE: the execution of SqlHelper.ExecuteNonQuery() failed.", ex);
            }

		}


		public int Content_INSERT( ContentSaveNewInfo contentSaveNewInfo )
		{
			object idAsObject = null;

			try
			{
                Database db = SqlDatabaseHelper.CurrentDatabase;
                DbCommand insertCommand = db.GetStoredProcCommand("Content_INSERT");

                db.AddOutParameter(insertCommand, "@IDENTITY", DbType.Int32, 8);
                db.AddInParameter(insertCommand, "@txtContent", DbType.String, contentSaveNewInfo.Content);
                db.AddInParameter(insertCommand, "@txtTextContent", DbType.String, contentSaveNewInfo.TextContent);
                db.AddInParameter(insertCommand, "@txtNote", DbType.String, contentSaveNewInfo.Note);
                db.AddInParameter(insertCommand, "@txtContentType", DbType.String, contentSaveNewInfo.ContentType.MachineValue);
                db.AddInParameter(insertCommand, "@bitIsLive", DbType.Boolean, contentSaveNewInfo.IsLive);
                db.AddInParameter(insertCommand, "@bitIsSearchable", DbType.Boolean, contentSaveNewInfo.IsSearchable);
                db.AddInParameter(insertCommand, "@txtContentEntryFilter", DbType.String, contentSaveNewInfo.ContentEntryFilter);
                db.AddInParameter(insertCommand, "@txtLastUpdatedBy", DbType.String, contentSaveNewInfo.LastModifiedBy);

                db.ExecuteNonQuery(insertCommand);

                idAsObject = db.GetParameterValue(insertCommand, "@IDENTITY");               
			}
			catch( System.Exception ex )
			{
                Logger.LogException("Content_INSERT Failed.", ex, EventIds._6053);
                throw ex;
			}

			if( idAsObject == System.DBNull.Value )
			{
                throw new Exceptions.SQLDataProviderException("Content_INSERT did not produce an output ID.");
			}
			else
			{
				return (int)idAsObject;
			}
		}


        public void Content_DELETE(int contentId)
        {
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("Content_DELETE_ByContentID", contentId);
        }
	}
}
