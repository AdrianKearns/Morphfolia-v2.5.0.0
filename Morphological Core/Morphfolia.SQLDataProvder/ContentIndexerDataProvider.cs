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
	/// Summary description for ContentDataProvider.
	/// </summary>
    public class ContentIndexerDataProvider : IContentIndexerDataProvider
	{
        private class TableColumnNames
        {
            public class SearchIndex
            {
                public static readonly string Word = "Word";
                public static readonly string PageId = "PageId";
                public static readonly string ContentId = "ContentId";
            }
        }

        private class ParametersNames
        {
            public class PURGE_ContentIndexDataForContentInstance
            {
                public static readonly string FirstCharacter = "@txtFirstCharacter";
                public static readonly string PageId = "@intPageId";
                public static readonly string ContentId = "@intContentId";
            }
        }



        private Morphfolia.Common.ContentIndexerActivityMonitor contentIndexerActivityMonitor;
        public Morphfolia.Common.ContentIndexerActivityMonitor ContentIndexerActivityMonitor
        {
            get { return contentIndexerActivityMonitor; }
            set { contentIndexerActivityMonitor = value; }
        }


        public void PURGE_ContentIndexDataForContentInstance(char firstCharacter, int pageId, int contentId)
        {
            try
            {
                SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("PURGE_ContentIndexDataForContentInstance", firstCharacter, pageId, contentId);
            }
            catch (System.Exception ex)
            {
                throw new Morphfolia.IDataProvider.Exceptions.StoredProceedureFailedException("PURGE_ContentIndexDataForContentInstance failed.", ex);
            }
        }

        /// <summary>
        /// Takes a WordIndexAlphabet and persists it's data.
        /// </summary>
        /// <remarks>The WordIndexAlphabet should only deal with one Page and one Content Item at a time.</remarks>
        /// <param name="wordIndexAlphabet"></param>
        public void ContentIndex_INSERT_Word(Morphfolia.Common.Info.WordIndexAlphabet wordIndexAlphabet)
        {
            Morphfolia.Common.Info.WordIndexInfo tempWordIndexInfo;
            Morphfolia.Common.Info.WordIndexInfoCollection tempWordIndexInfoCollection;
            //SqlCommand sqlCommand = new SqlCommand();
            int tempPageId;
            int tempContentId;

            try
            {
                tempPageId = wordIndexAlphabet.PageId;
                tempContentId = wordIndexAlphabet.ContentId;

                Database db = SqlDatabaseHelper.CurrentDatabase;
                DbCommand insertCommand = db.GetStoredProcCommand("ContentIndex_INSERT_Word");

                db.AddInParameter(insertCommand, "@txtFirstCharacter", DbType.String, string.Empty);
                db.AddInParameter(insertCommand, "@txtWord", DbType.String, string.Empty);
                db.AddInParameter(insertCommand, "@intPageId", DbType.Int32, tempPageId);
                db.AddInParameter(insertCommand, "@intContentId", DbType.Int32, tempContentId);

                ////SqlConnection sqlConnection = Helpers.ConnectionHelper.GetConnection();
                ////sqlCommand.Connection = sqlConnection;
                //sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //sqlCommand.CommandText = "ContentIndex_INSERT_Word";

                //sqlCommand.Parameters.Add(Morphological.Utilities.SQLParameterHelper.InputChar(ParametersNames.PURGE_ContentIndexDataForContentInstance.FirstCharacter, null, 1));
                //sqlCommand.Parameters.Add(Morphological.Utilities.SQLParameterHelper.InputVarchar("@txtWord", string.Empty, 256));
                //sqlCommand.Parameters.Add(Morphological.Utilities.SQLParameterHelper.InputInt(ParametersNames.PURGE_ContentIndexDataForContentInstance.PageId, tempPageId));
                //sqlCommand.Parameters.Add(Morphological.Utilities.SQLParameterHelper.InputInt(ParametersNames.PURGE_ContentIndexDataForContentInstance.ContentId, tempContentId));

                // for each WordIndexInfoCollection:
                for (int i = 0; i < wordIndexAlphabet.WordIndexes.Length; i++)
                {
                    tempWordIndexInfoCollection = wordIndexAlphabet.WordIndexes[i];
                    //sqlCommand.Parameters[0].Value = tempWordIndexInfoCollection.FirstCharacter;
                    db.SetParameterValue(insertCommand, "@txtFirstCharacter", tempWordIndexInfoCollection.FirstCharacter);

                    if (contentIndexerActivityMonitor != null)	// 1
                    {
                        contentIndexerActivityMonitor.DataActivity(string.Format("Saving {0} words into the '{1}' index...", 
                            tempWordIndexInfoCollection.Count.ToString(),
                            tempWordIndexInfoCollection.FirstCharacter.ToString()));
                    }


                    PURGE_ContentIndexDataForContentInstance(
                        tempWordIndexInfoCollection.FirstCharacter,
                        tempPageId,
                        tempContentId
                    );


                    for (int w = 0; w < tempWordIndexInfoCollection.Count; w++)
                    {
                        tempWordIndexInfo = tempWordIndexInfoCollection[w];
                        //sqlCommand.Parameters[1].Value = tempWordIndexInfo.Word;
                        db.SetParameterValue(insertCommand, "@txtWord", tempWordIndexInfo.Word);
                        //sqlCommand.ExecuteNonQuery();

                        db.ExecuteNonQuery(insertCommand);
                    }

                    //sqlCommand.Dispose();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public void ContentIndex_DELETE_UnwantedWords(String[] unwantedWords)
        {
            string word;
            try
            {
                Database db = SqlDatabaseHelper.CurrentDatabase;
                DbCommand deleteCommand = db.GetStoredProcCommand("ContentIndex_DELETE_UnwantedWords");

                db.AddInParameter(deleteCommand, "@txtFirstCharacter", DbType.String, string.Empty);
                db.AddInParameter(deleteCommand, "@txtWord", DbType.String, string.Empty);

                for (int i = 0; i < unwantedWords.Length; i++)
                {
                    word = unwantedWords[i];
                    if(!word.Equals(string.Empty))
                    {
                        db.SetParameterValue(deleteCommand, "@txtFirstCharacter", word.Substring(0, 1));
                        db.SetParameterValue(deleteCommand, "@txtWord", word);
                        db.ExecuteNonQuery(deleteCommand);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }            
        }


        public void ContentIndex_DELETE_OrphanRecords()
        {
            Morphfolia.SQLDataProvider.Utilities.SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("ContentIndex_DELETE_OrphanRecords");
        }


        public WordIndexSearchResultInfoCollection ContentIndex_SELECT_WordsForTagCloud(int minimumOccurrances)
        {
            WordIndexSearchResultInfo tagInfo;
            WordIndexSearchResultInfoCollection tagInfoCollection = new WordIndexSearchResultInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)Morphfolia.SQLDataProvider.Utilities.SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                "ContentIndex_SELECT_WordsForTagCloud", minimumOccurrances))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tagInfo = new WordIndexSearchResultInfo(
                            dr["WORD"].ToString(),
                            (int)dr["WordCount"],
                            0
                            );
                        tagInfoCollection.Add(tagInfo);
                    }
                }
            }

            return tagInfoCollection;
        }

        /// <summary>
        /// Gets all the words for a word index list, by letter.
        /// </summary>
        /// <param name="letter">The letter to select by</param>
        /// <returns>WordIndexListInfoCollection all the words and the references to 
        /// the pages where the words are displayed.</returns>
        public WordIndexListInfoCollection ContentIndex_SELECT_WordIndexListForLetter(string letter)
        {
            WordIndexListInfo wordIndexListInfo;
            WordIndexListInfoCollection wordIndexListInfoCollection = new WordIndexListInfoCollection();

            if (letter.Length > 1)
            {
                letter = letter.Remove(1);
            }

            using (SqlDataReader dr = (SqlDataReader)Morphfolia.SQLDataProvider.Utilities.SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                "ContentIndex_SELECT_WordIndexList", letter))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        wordIndexListInfo = new WordIndexListInfo(
                            dr["WORD"].ToString(),
                            (int)dr["PageId"],
                            (int)dr["ContentId"],
                            dr["Url"].ToString(),
                            dr["Title"].ToString(),
                            dr["Note"].ToString(),
                            dr["ContentType"].ToString()
                            );
                        wordIndexListInfoCollection.Add(wordIndexListInfo);
                    }
                }
            }

            return wordIndexListInfoCollection;
        }


        public ContentIndexOverview ContentIndex_SELECT_Overview()
        {      
            ContentIndexOverview overview = new ContentIndexOverview();

            DataSet ds = Morphfolia.SQLDataProvider.Utilities.SqlDatabaseHelper.CurrentDatabase.ExecuteDataSet("ContentIndex_SELECT_Overview");

            if (ds.Tables.Count != 2)
            {
                throw new Exceptions.SQLDataProviderException("Error, ContentIndex_SELECT_Overview: wrong number of tables returned by DataSet.");
            }
            else
            {
                overview.LetterSummaries = ExtractIndexSummaries(ds.Tables[0]);
                overview.PopularWords = ExtractPopularwords(ds.Tables[1]);
            }

            return overview;
        }


        private ContentIndexSummaryCollection ExtractIndexSummaries(DataTable dt)
        {
            ContentIndexSummary item;
            ContentIndexSummaryCollection collection = new ContentIndexSummaryCollection();
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                item = new ContentIndexSummary(
                    (int)dt.Rows[r].ItemArray[0],
                    dt.Rows[r].ItemArray[1].ToString()
                    );
                collection.Add(item);
            }
            return collection;
        }

        private PopularWordSummaryCollection ExtractPopularwords(DataTable dt)
        {
            PopularWordSummary item;
            PopularWordSummaryCollection collection = new PopularWordSummaryCollection();
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                item = new PopularWordSummary(
                        (int)dt.Rows[r].ItemArray[1],
                        dt.Rows[r].ItemArray[2].ToString(),
                        dt.Rows[r].ItemArray[0].ToString()
                        );

                collection.Add(item);
            }
            return collection;
        }

	}
}