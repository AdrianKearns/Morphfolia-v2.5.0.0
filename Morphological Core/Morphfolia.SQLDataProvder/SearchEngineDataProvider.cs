// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
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
	/// Summary description for ISearchEngineDataProvider.
	/// </summary>
	public class SearchEngineDataProvider : Morphfolia.IDataProvider.ISearchEngineDataProvider
	{              
        /// <summary>
        /// Performs searching of the WordIndexes.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
		public Morphfolia.Common.Info.WordIndexSearchResultInfoCollection WordIndex_SEARCH( string criteria )
		{
			Morphfolia.Common.Info.WordIndexSearchResultInfo wordIndexSearchResultInfo;
			Morphfolia.Common.Info.WordIndexSearchResultInfoCollection wordIndexSearchResultInfoCollection = new Morphfolia.Common.Info.WordIndexSearchResultInfoCollection();
            try
            {

                using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                           "WordIndex_SEARCH", criteria))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            wordIndexSearchResultInfo = new Morphfolia.Common.Info.WordIndexSearchResultInfo(
                                dr["Word"].ToString(),
                                (int)dr["TotalOccurances"],
                                (int)dr["DistinctPageCount"]
                                );
                            wordIndexSearchResultInfoCollection.Add(wordIndexSearchResultInfo);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("WordIndex_SEARCH failed.", ex, EventIds._6040);
            }
			return wordIndexSearchResultInfoCollection;
		}


        /// <summary>
        /// Performs the actual searching, to satisfy users searches.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
		public Morphfolia.Common.Info.SearchResultInfoCollection Content_SEARCH( string criteria )
		{
            criteria = criteria.Trim();
            criteria = criteria.Replace("*", "%");

			Morphfolia.Common.Info.SearchResultInfo searchResultInfo;
			Morphfolia.Common.Info.SearchResultInfoCollection searchResultInfoCollection = new Morphfolia.Common.Info.SearchResultInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
					   "Content_SEARCH", criteria))
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


						searchResultInfo = new Morphfolia.Common.Info.SearchResultInfo(
							(int)dr["PageID"],
							dr["Title"].ToString(),
							dr["Url"].ToString(),
							dr["MetaKeywords"].ToString(),
							dr["MetaDescription"].ToString(),
							lastModified,
							dr["LastModifiedBy"].ToString(),
                            (int)dr["Matches"],
                            (int)dr["ContentId"],
                            dr["Note"].ToString(),
							dr["ContentType"].ToString()					
							);

						searchResultInfoCollection.Add( searchResultInfo );
					}
				}
			}

            Logging.Logger.LogInformation("SQLDataProvider.SearchEngineDataProvider.Content_SEARCH()", string.Format("Search criteria='{0}', Records returned={1}", criteria, searchResultInfoCollection.Count.ToString()), 666);

			return searchResultInfoCollection;
		}
	}
}