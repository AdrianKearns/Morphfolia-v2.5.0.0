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
using System.Collections.Specialized;
using Morphfolia.SQLDataProvider.Logging;
using Morphfolia.SQLDataProvider.Utilities;
using Morphfolia.IDataProvider;
using Morphfolia.Common.Info;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;


namespace Morphfolia.SQLDataProvider
{
	/// <summary>
	/// Summary description for PageDataProvider.
	/// </summary>
	public class PageDataProvider : IPageDataProvider
	{
        /// <summary>
        /// The different modes in which we can ask for a page
        /// </summary>
        private enum ModeOfOperation { NotSet, AdminMode, LivePublishingMode }


		public Morphfolia.Common.Info.PageInfoCollection Page_SELECT_List()
		{
			Morphfolia.Common.Info.PageInfo pageInfo;
			Morphfolia.Common.Info.PageInfoCollection pageInfoCollection = new Morphfolia.Common.Info.PageInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Page_SELECT_List"))
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


						pageInfo = new Morphfolia.Common.Info.PageInfo(
							(int)dr["PageID"],
							dr["Title"].ToString(),
							dr["Url"].ToString(),
							dr["MetaKeywords"].ToString(),
							dr["MetaDescription"].ToString(),
							lastModified,
							dr["LastModifiedBy"].ToString(),
							(bool)dr["IsSearchable"],
							(bool)dr["IsLive"]
							);

						pageInfoCollection.Add( pageInfo );
					}
				}
			}

			return pageInfoCollection;
		}



		public Morphfolia.Common.Info.PageInfoCollection Page_SELECT_ListSearch( PageListerSearchCriteria pageListerSearchCriteria )
		{
			Morphfolia.Common.Info.PageInfo pageInfo;
			Morphfolia.Common.Info.PageInfoCollection pageInfoCollection = new Morphfolia.Common.Info.PageInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
					   "Page_SELECT_ListSearch",
					   pageListerSearchCriteria.IsSearchable,
					   pageListerSearchCriteria.IsLive))
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


						pageInfo = new Morphfolia.Common.Info.PageInfo(
							(int)dr["PageID"],
							dr["Title"].ToString(),
							dr["Url"].ToString(),
							dr["MetaKeywords"].ToString(),
							dr["MetaDescription"].ToString(),
							lastModified,
							dr["LastModifiedBy"].ToString(),
							(bool)dr["IsSearchable"],
							(bool)dr["IsLive"]
							);

						pageInfoCollection.Add( pageInfo );
					}
				}
			}

			return pageInfoCollection;
		}



        public Morphfolia.Common.Info.PageInfoCollection Page_SELECT_ByChildContentItem(int contentId)
        {
            Morphfolia.Common.Info.PageInfo pageInfo;
            Morphfolia.Common.Info.PageInfoCollection pageInfoCollection = new Morphfolia.Common.Info.PageInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                "Page_SELECT_ByChildContentItem", contentId))
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


                        pageInfo = new Morphfolia.Common.Info.PageInfo(
                            (int)dr["PageID"],
                            dr["Title"].ToString(),
                            dr["Url"].ToString(),
                            dr["MetaKeywords"].ToString(),
                            dr["MetaDescription"].ToString(),
                            lastModified,
                            dr["LastModifiedBy"].ToString(),
                            (bool)dr["IsSearchable"],
                            (bool)dr["IsLive"]
                            );

                        pageInfoCollection.Add(pageInfo);
                    }
                }
            }

            return pageInfoCollection;
        }


        /// <summary>
        /// Selects live pages only.
        /// </summary>
        /// <param name="pageIds"></param>
        /// <returns></returns>
        public PageInfoCollection Page_SELECT_PagesByID(IntCollection pageIds)
        {
            // Preserve the IntCollection of contentIds that was passed in.
            IntCollection workingCollectionOfIds = new IntCollection();
            foreach (int i in pageIds)
            {
                workingCollectionOfIds.Add(i);
            }

            Logging.Logger.LogVerboseInformation("Page_SELECT_PagesByID(), working count", workingCollectionOfIds.Count.ToString());


            PageInfo pageInfo;
            PageInfoCollection pageInfoCollection = new PageInfoCollection();

            // the sp can take upto 5 ids at a time, batch up query into batches of 5 ids, append to out going collection and return.
            int fullBatchCount = workingCollectionOfIds.Count / 5;

            Logging.Logger.LogVerboseInformation("Page_SELECT_PagesByID(), fullBatchCount (wrk/5)", fullBatchCount.ToString());


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




                using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Page_SELECT_PagesByID",
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


                            pageInfo = new Morphfolia.Common.Info.PageInfo(
                                (int)dr["PageID"],
                                dr["Title"].ToString(),
                                dr["Url"].ToString(),
                                dr["MetaKeywords"].ToString(),
                                dr["MetaDescription"].ToString(),
                                lastModified,
                                dr["LastModifiedBy"].ToString(),
                                (bool)dr["IsSearchable"],
                                (bool)dr["IsLive"]
                                );

                            pageInfoCollection.Add(pageInfo);
                        }
                    }
                }
                workingCollectionOfIds.RemoveAt(0);
                workingCollectionOfIds.RemoveAt(0);
                workingCollectionOfIds.RemoveAt(0);
                workingCollectionOfIds.RemoveAt(0);
                workingCollectionOfIds.RemoveAt(0);
            }

            return pageInfoCollection;
        }



		public Morphfolia.Common.Info.PageInfo Page_SELECT_PageByID( int pageId )
		{
			Morphfolia.Common.Info.PageInfo pageInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Page_SELECT_PageByID", pageId))
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


					pageInfo = new Morphfolia.Common.Info.PageInfo(
						(int)dr["PageID"],
						dr["Title"].ToString(),
						dr["Url"].ToString(),
						dr["MetaKeywords"].ToString(),
						dr["MetaDescription"].ToString(),
						lastModified,
						dr["LastModifiedBy"].ToString(),
						(bool)dr["IsSearchable"],
						(bool)dr["IsLive"]
						);
				}
				else
				{
					throw new ApplicationException( string.Format("Could not find a page with this ID: {0}", pageId.ToString()) );
				}
			}
			return pageInfo;
		}


        /// <summary>
        /// Used to locate a page/blog.
        /// </summary>
        /// <param name="pageTitle"></param>
        /// <returns></returns>
        public PageInfo Page_SELECT_PageByTitle(string pageTitle)
        {
            Morphfolia.Common.Info.PageInfo pageInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("Page_SELECT_PageByTitle", pageTitle))
            {
                if (dr.Read())
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


                    pageInfo = new Morphfolia.Common.Info.PageInfo(
                        (int)dr["PageID"],
                        dr["Title"].ToString(),
                        dr["Url"].ToString(),
                        dr["MetaKeywords"].ToString(),
                        dr["MetaDescription"].ToString(),
                        lastModified,
                        dr["LastModifiedBy"].ToString(),
                        (bool)dr["IsSearchable"],
                        (bool)dr["IsLive"]
                        );
                }
                else
                {
                    throw new ApplicationException(string.Format("Could not find a page with this title: {0}", pageTitle));
                }
            }
            return pageInfo;
        }



		public Morphfolia.Common.Info.PageInfo Page_SELECT_ByURLForLivePublishing( string url )
		{
			return Page_SELECT_ByURL( url, ModeOfOperation.LivePublishingMode );
		}


		public Morphfolia.Common.Info.PageInfo Page_SELECT_ByURLForAdminMode( string url )
		{
			return Page_SELECT_ByURL( url, ModeOfOperation.AdminMode );
		}


		private Morphfolia.Common.Info.PageInfo Page_SELECT_ByURL( string url, ModeOfOperation modeOfOperation )
		{
			string spName;

			switch( modeOfOperation )
			{
				case ModeOfOperation.AdminMode:
					spName = "Page_SELECT_ByURL";
					break;

				case ModeOfOperation.LivePublishingMode:
					spName = "Page_SELECT_ByURLForLivePublishing";
					break;

				default:
					spName = "Page_SELECT_ByURLForLivePublishing";
					break;
			}


			Morphfolia.Common.Info.PageInfo pageInfo;
            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(spName, url))
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

					pageInfo = new Morphfolia.Common.Info.PageInfo(
						(int)dr["PageID"],
						dr["Title"].ToString(),
						dr["Url"].ToString(),
						dr["MetaKeywords"].ToString(),
						dr["MetaDescription"].ToString(),
						lastModified,
						dr["LastModifiedBy"].ToString(),
						(bool)dr["IsSearchable"],
						(bool)dr["IsLive"]
						);
				}
				else
				{
                    // Log this if you want to.
                    // You'll get this whenever anyone asks for a blog post (by title), as the blog title is passed as 
                    // the URL; therefore this is not exceptional.
                    //Logger.LogWarning("Page_SELECT_ByURL(); URL Not Found.", string.Format("URL: {0}", url), EventIds._6072);

                    pageInfo = new Morphfolia.Common.Info.PageInfo(
                        Morphfolia.Common.Constants.SystemTypeValues.NullInt,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        Morphfolia.Common.Constants.SystemTypeValues.NullDate,
                        string.Empty,
                        false,
                        false
                        );
				}

                return pageInfo;
			}
		}




		public StringCollection Page_SELECT_UrlSegmentSearch( string urlHint )
		{
			StringCollection matchingUrls = new StringCollection();

			if( urlHint.IndexOf("%") < 0 )
			{
				urlHint = string.Format("{0}%", urlHint);
			}

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
					   "Page_SELECT_UrlSegmentSearch", urlHint))
			{
				if (dr.HasRows)
				{
					while(dr.Read())
					{
                        matchingUrls.Add( dr["Url"].ToString() );
					}
				}
			}

			return matchingUrls;
		}




		public int Page_INSERT( Morphfolia.Common.Info.PageSaveNewInfo pageSaveNewInfo )
		{
			object idAsObject = null;

			try
			{
                Database db = SqlDatabaseHelper.CurrentDatabase;
                DbCommand insertCommand = db.GetStoredProcCommand("Page_INSERT");

                db.AddOutParameter(insertCommand, "@IDENTITY", DbType.Int32, 8);
                db.AddInParameter(insertCommand, "@txtTitle", DbType.String, pageSaveNewInfo.Title);
                db.AddInParameter(insertCommand, "@txtUrl", DbType.String, pageSaveNewInfo.Url);
                db.AddInParameter(insertCommand, "@txtKeywords", DbType.String, pageSaveNewInfo.Keywords);
                db.AddInParameter(insertCommand, "@txtDescription", DbType.String, pageSaveNewInfo.Description);
                db.AddInParameter(insertCommand, "@txtLastModifiedBy", DbType.String, pageSaveNewInfo.LastModifiedBy);
                db.AddInParameter(insertCommand, "@bIsSearchable", DbType.Boolean, pageSaveNewInfo.IsSearchable);
                db.AddInParameter(insertCommand, "@bIsLive", DbType.Boolean, pageSaveNewInfo.IsLive);
                db.ExecuteNonQuery(insertCommand);

                idAsObject = db.GetParameterValue(insertCommand, "@IDENTITY");    
			}
			catch( System.Exception ex )
			{
                Logger.LogException("Page_INSERT Failed.", ex, EventIds._6070);
				throw ex;
			}

			if( idAsObject == System.DBNull.Value )
			{
				throw new ApplicationException("Page_INSERT did not produce an output ID.");
			}
			else
			{
				return (int)idAsObject;
			}
		}



		//		@intPageID int,
		//		@txtTitle varchar(500),
		//		@txtUrl varchar(1000),
		//		@txtKeywords varchar(2000),
		//		@txtDescription varchar(2000),
		//		@dtLastModified DateTime,
		//		@txtLastModifiedBy varchar(101),
		//		@bIsSearchable bit,
		//		@bIsLive bit




		/// <summary>
		/// Updates all available properties of a Page except it's content.
		/// </summary>
		/// <param name="pageUpdateInfo"></param>
		public void Page_UPDATE( Morphfolia.Common.Info.PageUpdateInfo pageUpdateInfo )
		{
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery(
				"Page_UPDATE",
				pageUpdateInfo.PageID,
				pageUpdateInfo.Title, 
				pageUpdateInfo.Url, 
				pageUpdateInfo.Keywords, 
				pageUpdateInfo.Description, 
				pageUpdateInfo.LastModified,
				pageUpdateInfo.LastModifiedBy, 
				pageUpdateInfo.IsSearchable,
				pageUpdateInfo.IsLive);
		}



		/// <summary>
		/// Updates the content of a Page.
		/// </summary>
		/// <param name="pageID"></param>
		/// <param name="pageContentUpdateInfoCollection"></param>
		public void Page_UPDATE_Content( int pageID, Morphfolia.Common.Info.PageContentUpdateInfoCollection pageContentUpdateInfoCollection )
		{
			if( pageID < 1 )
				throw new ArgumentException("pageID < 1");

			if( pageContentUpdateInfoCollection.Count < 1 )
				throw new ArgumentException("pageContentUpdateInfoCollection.Count < 1");


			int i = 0;


            Database db = SqlDatabaseHelper.CurrentDatabase;
            

            DbCommand deleteCommand = db.GetStoredProcCommand("ContentMarshal_DELETE_ContentForPage");
            db.AddInParameter(deleteCommand, "@intPageID", DbType.Int32, pageID);

            DbCommand insertCommand = db.GetStoredProcCommand("ContentMarshal_INSERT_ContentItemForPage");

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    db.ExecuteNonQuery(deleteCommand);

                    if (pageContentUpdateInfoCollection.Count > 0)
                    {
                        foreach (Morphfolia.Common.Info.PageContentUpdateInfo pageContentUpdateInfo in pageContentUpdateInfoCollection)
                        {
                            i++;
                            insertCommand.Parameters.Clear();
                            db.AddInParameter(insertCommand, "@intPageID", DbType.Int32, pageID);
                            db.AddInParameter(insertCommand, "@intContentID", DbType.Int32, pageContentUpdateInfo.ContentID);
                            db.AddInParameter(insertCommand, "@intSortOrder", DbType.Int32, i);
                            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery(insertCommand);
                        }
                    }

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback transaction 
                    transaction.Rollback();

                    Logger.LogException("Page_UPDATE(); Transaction failed, rolling back transaction.", ex, EventIds._6071);
                }
                finally
                {
                    connection.Close();
                }
            }
		}


        public void Page_DELETE_ByPageID(int pageId)
		{
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("Page_DELETE_ByPageID", pageId);
		}
	}
}