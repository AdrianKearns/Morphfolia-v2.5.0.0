// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Text;
using Morphfolia.Business.Constants;
using Morphfolia.Common.Info;
using Morphfolia.Common.Constants;
using Morphfolia.Business.Logs;

namespace Morphfolia.Business
{
    /// <summary>
    /// Looks after the indexing of content / pages.
    /// </summary>
    public class ContentIndexer
    {
        private Morphfolia.Common.ContentIndexerActivityMonitor contentIndexerActivityMonitor;
        public Morphfolia.Common.ContentIndexerActivityMonitor ContentIndexerActivityMonitor
        {
            get { return contentIndexerActivityMonitor; }
            set { 
                contentIndexerActivityMonitor = value;
                IContentIndexerDataProvider.ContentIndexerActivityMonitor = contentIndexerActivityMonitor;
            }
        }
        

        internal Morphfolia.IDataProvider.IPageDataProvider iPageDataProvider = null;
        internal Morphfolia.IDataProvider.IPageDataProvider IPageDataProvider
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


        internal Morphfolia.IDataProvider.IContentDataProvider iContentDataProvider = null;
        internal Morphfolia.IDataProvider.IContentDataProvider IContentDataProvider
        {
            get
            {
                if (iContentDataProvider == null)
                {
                    iContentDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IContentDataProvider) as Morphfolia.IDataProvider.IContentDataProvider;
                }

                return iContentDataProvider;
            }
        }


        private Morphfolia.IDataProvider.IContentIndexerDataProvider iContentIndexerDataProvider = null;
        internal Morphfolia.IDataProvider.IContentIndexerDataProvider IContentIndexerDataProvider
        {
            get
            {
                if (iContentIndexerDataProvider == null)
                {
                    iContentIndexerDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IContentIndexerDataProvider) as Morphfolia.IDataProvider.IContentIndexerDataProvider;
                }

                return iContentIndexerDataProvider;
            }
        }


        private WordIndexAlphabet wordIndex;


        /// <summary>
        /// Looks after the indexing of content / pages.
        /// </summary>
        public ContentIndexer()
        {
            wordIndex = new WordIndexAlphabet();
        }


        /// <summary>
        /// Indexes (and re-indexes) all site content, where the pages and their content items are both live and searchable.
        /// </summary>
        /// <param name="removeUnwantedWords">If true, unwanted words will be automatically purged from 
        /// the indexes immediately after they have been added.</param>
        /// <remarks>Words are added to the indexes and then unwanted words are removed; this is done 
        /// for performance reasons as filtering on insertion would be too slow.</remarks>
        /// <returns>A success message. (are't I optimistic!)</returns>
        public string IndexSiteContent(bool removeUnwantedWords)
        {
            DateTime startTime = DateTime.Now;
            PageInfo tempPageInfo;
            PageInfoCollection pagesToIndex;
            pagesToIndex = IPageDataProvider.Page_SELECT_List();

            if ( ContentIndexerActivityMonitor != null )		// 1
            {
                ContentIndexerActivityMonitor.GeneralActivity(string.Format("Preparing to index site, {0} pages...", pagesToIndex.Count.ToString()));
            }

            for (int i = 0; i < pagesToIndex.Count; i++)
            {
                tempPageInfo = pagesToIndex[i];

                if (ContentIndexerActivityMonitor != null)		// 1
                {
                    ContentIndexerActivityMonitor.PageActivity(string.Format("Indexing page {1} of {2}: {0}", 
                        tempPageInfo.Url, 
                        (i+1).ToString(), 
                        pagesToIndex.Count.ToString()));


    //                ContentIndexerActivityMonitor.PageActivity(string.Format("Indexing page {1} of {2}: {0}",
    //tempPageInfo.,
    //(i + 1).ToString(),
    //pagesToIndex.Count.ToString()));
                }

                IndexPage(tempPageInfo, removeUnwantedWords);
            }


            TimeSpan duration = DateTime.Now.Subtract(startTime);

            return string.Format("\n\nDuration in seconds: {0}.", duration.Seconds.ToString() );
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageId">The id of the page to index.</param>
        /// <param name="removeUnwantedWords">If true, unwanted words will be automatically purged from 
        /// the indexes immediately after they have been added.</param>
        public void IndexPage(int pageId, bool removeUnwantedWords)
        {
            PageInfo pageInfo = Morphfolia.Business.Page.GetPageInfo(pageId);
            IndexPage(pageInfo, removeUnwantedWords);
        }


        /// <summary>
        /// Indexes (and re-indexes) a pages content.
        /// </summary>
        /// <remarks>The page must be live and searchable.</remarks>
        /// <param name="pageInfo">The PageInfo of the page to index.</param>
        /// <param name="removeUnwantedWords">If true, unwanted words will be automatically purged from 
        /// the indexes immediately after they have been added.</param>
        public void IndexPage(PageInfo pageInfo, bool removeUnwantedWords)
        {
            ContentInfoCollection pageContent;
            bool indexPage = true;

            if (!pageInfo.IsLive)
            {
                indexPage = false;
            }

            if (!pageInfo.IsSearchable)
            {
                indexPage = false;
            }

            if (indexPage)
            {
                ContentInfo tempContentInfo;
                pageContent = IContentDataProvider.Content_SELECT_PageByIDForLivePublishing(pageInfo.PageID);

                for (int i = 0; i < pageContent.Count; i++)
                {
                    tempContentInfo = pageContent[i];

                    if (ContentIndexerActivityMonitor != null)		// 1
                    {
                        ContentIndexerActivityMonitor.ContentActivity(string.Format("Indexing content item {1} of {2}, id: {0}",
                            tempContentInfo.ContentID,
                            (i + 1).ToString(),
                            pageContent.Count.ToString()));
                    }

                    IndexContentItem(tempContentInfo, pageInfo.PageID, removeUnwantedWords);
                }
            }
            else
            {
                if (ContentIndexerActivityMonitor != null)		// 1
                {
                    ContentIndexerActivityMonitor.PageActivity(string.Format("Page not for eligible indexing: PageID {0}, {1}", 
                        pageInfo.PageID.ToString(),
                        pageInfo.Url));
                }
            }
        }




        /// <summary>
        /// Indexes (and re-indexes) a content item.
        /// </summary>
        /// <remarks>The content item must be live and searchable.</remarks>
        /// <param name="contentInfo">The ContentInfo of the content to be indexed.</param>
        /// <param name="parentPageId">The id of the page to which the content belongs.</param>
        /// <param name="removeUnwantedWords">If true, unwanted words will be automatically purged from 
        /// the indexes immediately after they have been added.</param>
        public void IndexContentItem(int contentId, bool removeUnwantedWords)
        {
            bool indexContent = true;
            ContentItem contentInfo = Business.ContentItemHelper.GetContentItemById(contentId);
            PageInfoCollection pagesThatUseThisItem = Business.PageLister.PagesUsedByThisContentItem(contentId);
            

            if (!contentInfo.IsLive)
            {
                indexContent = false;
            }

            if (!contentInfo.IsSearchable)
            {
                indexContent = false;
            }

            if (indexContent)
            {
                IndexContent(contentInfo.TextContent, pagesThatUseThisItem, contentInfo.ContentID, removeUnwantedWords);
            }
            else
            {
                // Should never enter here as we should only be getting eligiable content items passed in.
                if (ContentIndexerActivityMonitor != null)		// 1
                {
                    ContentIndexerActivityMonitor.ContentActivity(string.Format("The content item '{0}' is not for eligible indexing.",
                        contentInfo.ContentID.ToString()));
                }
            }
        }



        /// <summary>
        /// Indexes (and re-indexes) a content item.
        /// </summary>
        /// <remarks>The content item must be live and searchable.</remarks>
        /// <param name="contentInfo">The ContentInfo of the content to be indexed.</param>
        /// <param name="parentPageId">The id of the page to which the content belongs.</param>
        /// <param name="removeUnwantedWords">If true, unwanted words will be automatically purged from 
        /// the indexes immediately after they have been added.</param>
        public void IndexContentItem(ContentInfo contentInfo, int parentPageId, bool removeUnwantedWords)
        {
            bool indexContent = true;

            if (!contentInfo.IsLive)
            {
                indexContent = false;
            }

            if (!contentInfo.IsSearchable)
            {
                indexContent = false;
            }

            if (indexContent)
            {
                PageInfo pageInfo = Business.Page.GetPageInfo(parentPageId);
                PageInfoCollection collection = new PageInfoCollection();
                collection.Add(pageInfo);
                IndexContent(contentInfo.TextContent, collection, contentInfo.ContentID, removeUnwantedWords);
            }
            else
            {
                // Should never enter here as we should only be getting eligiable content items passed in.
                if (ContentIndexerActivityMonitor != null)		// 1
                {
                    ContentIndexerActivityMonitor.ContentActivity(string.Format("Content Item not for eligible indexing: ContentID {0}",
                        contentInfo.ContentID.ToString()));
                }
            }
        }


        /// <summary>
        /// Performs the actual indexing of the content.
        /// </summary>
        /// <param name="contentToIndex">The actual text/words to index.</param>
        /// <param name="pageId">The id of the page.</param>
        /// <param name="contentId">The id of the content.</param>
        /// <param name="removeUnwantedWords">If true, unwanted words will be automatically purged from 
        /// the indexes immediately after they have been added.</param>
        private void IndexContent(string contentToIndex, PageInfoCollection pages, int contentId, bool removeUnwantedWords)
        {
            string backslash = "\"";
            backslash = backslash.Normalize(NormalizationForm.FormC);
            backslash = backslash.ToLowerInvariant();
            contentToIndex = contentToIndex.Normalize(NormalizationForm.FormC);
            contentToIndex = contentToIndex.ToLower().Trim();
            contentToIndex = contentToIndex.Replace(backslash, " ");
            contentToIndex = contentToIndex.Replace("   ", " ");
            contentToIndex = contentToIndex.Replace("\t", " ");
            contentToIndex = contentToIndex.Replace(System.Environment.NewLine, " ");
            contentToIndex = contentToIndex.Replace("'", " ");
            contentToIndex = contentToIndex.Replace("`", " ");
            contentToIndex = contentToIndex.Replace(".", " ");
            contentToIndex = contentToIndex.Replace(",", " ");
            contentToIndex = contentToIndex.Replace("(", " ");
            contentToIndex = contentToIndex.Replace(")", " ");
            contentToIndex = contentToIndex.Replace("[", " ");
            contentToIndex = contentToIndex.Replace("]", " ");
            contentToIndex = contentToIndex.Replace("{", " ");
            contentToIndex = contentToIndex.Replace("}", " ");
            contentToIndex = contentToIndex.Replace("/", " "); // keep this?
            contentToIndex = contentToIndex.Replace("\\", " "); // keep this?
            contentToIndex = contentToIndex.Replace(";", " ");
            contentToIndex = contentToIndex.Replace(":", " ");
            contentToIndex = contentToIndex.Replace("!", " ");
            contentToIndex = contentToIndex.Replace("~", " ");
            contentToIndex = contentToIndex.Replace("#", " ");
            contentToIndex = contentToIndex.Replace("*", " ");
            contentToIndex = contentToIndex.Replace("?", " ");
            contentToIndex = contentToIndex.Replace("|", " ");
            //contentToIndex = contentToIndex.Replace("-", " ");  //keep this?
            contentToIndex = contentToIndex.Replace("<", " ");
            contentToIndex = contentToIndex.Replace(">", " ");


            string[] words = contentToIndex.Split( char.Parse(" ") );
            string currentWord;
            string firstLetter;
            int wordsAddedToIndex = 0;




            foreach (PageInfo currentPage in pages)
            {
                if (
                    (!currentPage.IsLive) | (!currentPage.IsSearchable)
                    )
                {
                    if (ContentIndexerActivityMonitor != null)
                    {
                        ContentIndexerActivityMonitor.ContentActivity(string.Format("The page (id {0})  '{1}'<br>{2} is not for eligible indexing.",
                            currentPage.PageID.ToString(),
                            currentPage.Title,
                            currentPage.Url));
                    }
                }
                else
                {
                    wordIndex.ClearAll();
                    wordIndex.PageId = currentPage.PageID;
                    wordIndex.ContentId = contentId;


                    if (ContentIndexerActivityMonitor != null)		// 1
                    {
                        ContentIndexerActivityMonitor.ContentActivity(string.Format("Affects page (id {0}) '{1}', {2}",
                            currentPage.PageID.ToString(),
                            currentPage.Title,
                            currentPage.Url));
                        ContentIndexerActivityMonitor.ContentActivity(string.Format("Words to parse {0}", words.Length.ToString()));
                    }


                    for (int i = 0; i < words.Length; i++)
                    {
                        currentWord = words[i];
                        if (currentWord.Length >= 3)
                        {
                            wordsAddedToIndex++;

                            if (ContentIndexerActivityMonitor != null)		// 1
                            {
                                ContentIndexerActivityMonitor.WordActivity(string.Format("{0} ({1} of {2}) ",
                                    currentWord,
                                    (i + 1).ToString(),
                                    words.Length.ToString()));
                            }

                            firstLetter = currentWord.Substring(0, 1).ToUpper();

                            switch (firstLetter.ToUpper())
                            {
                                case "A":
                                    wordIndex.A.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "B":
                                    wordIndex.B.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "C":
                                    wordIndex.C.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "D":
                                    wordIndex.D.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "E":
                                    wordIndex.E.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "F":
                                    wordIndex.F.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "G":
                                    wordIndex.G.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "H":
                                    wordIndex.H.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "I":
                                    wordIndex.I.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "J":
                                    wordIndex.J.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "K":
                                    wordIndex.K.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "L":
                                    wordIndex.L.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "M":
                                    wordIndex.M.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "N":
                                    wordIndex.N.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "O":
                                    wordIndex.O.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "P":
                                    wordIndex.P.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "Q":
                                    wordIndex.Q.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "R":
                                    wordIndex.R.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "S":
                                    wordIndex.S.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "T":
                                    wordIndex.T.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "U":
                                    wordIndex.U.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "V":
                                    wordIndex.V.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "W":
                                    wordIndex.W.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "X":
                                    wordIndex.X.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "Y":
                                    wordIndex.Y.Add(new WordIndexInfo(currentWord));
                                    break;
                                case "Z":
                                    wordIndex.Z.Add(new WordIndexInfo(currentWord));
                                    break;
                                default:
                                    wordIndex.Other.Add(new WordIndexInfo(currentWord));
                                    break;
                            }
                        }
                    }

                    if (ContentIndexerActivityMonitor != null)
                    {
                        ContentIndexerActivityMonitor.ContentActivity(string.Format("Words to be added to indexes {0}", wordsAddedToIndex.ToString()));
                    }



                    IContentIndexerDataProvider.ContentIndex_INSERT_Word(wordIndex);
                    Auditor.LogAuditEntry(SystemTypeValues.NullInt, AuditableObjects.SearchIndex, string.Format("Inserting entries for PageId: {0}, ContentId: {1}", wordIndex.PageId, wordIndex.ContentId));


                    if (removeUnwantedWords)
                    {
                        this.RemoveUnwantedWordsFromTheContentIndexs();

                        if (ContentIndexerActivityMonitor != null)
                        {
                            ContentIndexerActivityMonitor.ContentActivity("Unwanted words removed from indexes.");
                        }
                    }



                }
            }



            if (ContentIndexerActivityMonitor != null)		// 1
            {
                ContentIndexerActivityMonitor.ContentActivity("Indexing complete.");
            }

            // For debugging only.
            //for (int i = 0; i < wordIndex.WordIndexes.Length; i++)
            //{
            //    if (ContentIndexerActivityMonitor != null)		// 1
            //    {
            //        ContentIndexerActivityMonitor.ContentActivity(string.Format("Word Index {0}, {1}.", 
            //            wordIndex.WordIndexes[i].FirstCharacter.ToString(),
            //            wordIndex.WordIndexes[i].Count.ToString()));
            //    }
            //}
        }



        private string[] unwantedWords = null;
        public string[] UnwantedWords
        {
            get
            {
                if (unwantedWords == null)
                {
                    unwantedWords = UnwantedWordHelper.GetUnwantedWords();
                }
                return unwantedWords;
            }
        }

        public void RemoveUnwantedWordsFromTheContentIndexs()
        {
            IContentIndexerDataProvider.ContentIndex_DELETE_UnwantedWords(UnwantedWords);
            Auditor.LogAuditEntry(SystemTypeValues.NullInt, AuditableObjects.SearchIndex, "Removed unwanted words from Content Indexes.");
        }


        public void RemoveUnwantedWordsFromTheContentIndexs(String[] unwantedWords)
        {
            IContentIndexerDataProvider.ContentIndex_DELETE_UnwantedWords(unwantedWords);
            Auditor.LogAuditEntry(SystemTypeValues.NullInt, AuditableObjects.SearchIndex, "Removed unwanted words from Content Indexes.");
        }


        public WordIndexSearchResultInfoCollection GetWordsForTagCloud()
        {
            return IContentIndexerDataProvider.ContentIndex_SELECT_WordsForTagCloud(100);
        }

        public WordIndexSearchResultInfoCollection GetWordsForTagCloud(int minimumOccurrances)
        {
            return IContentIndexerDataProvider.ContentIndex_SELECT_WordsForTagCloud(minimumOccurrances);
        }


        public void PurgeAllOrphanIndexEntries()
        {
            IContentIndexerDataProvider.ContentIndex_DELETE_OrphanRecords();
            Auditor.LogAuditEntry(SystemTypeValues.NullInt, AuditableObjects.SearchIndex, "Purged all orphan entries from Content Indexes.");
        }


        private ContentIndexOverview indexOverview;
        public ContentIndexOverview IndexOverview
        {
            get
            {
                if (indexOverview == null)
                {
                    indexOverview = IContentIndexerDataProvider.ContentIndex_SELECT_Overview();
                }
                return indexOverview;
            }
        }


        public void RefreshIndexOverview()
        {
            indexOverview = IContentIndexerDataProvider.ContentIndex_SELECT_Overview();
        }



        public int GetCountForLetter(LetterArrayIndex letter)
        {
            return IndexOverview.LetterSummaries.GetByLetter(letter).Total;
        }

        public int GetCountForLetter(string letter)
        {
            return IndexOverview.LetterSummaries.GetByLetter(letter).Total;
        }

        public int GetCountForLetter(int index)
        {
            return IndexOverview.LetterSummaries[index].Total;
        }

        private int totalWordCount = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
        public int GetTotalWordCount()
        {
            if (totalWordCount == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                for (int i = 0; i < 27; i++)
                {
                    totalWordCount = totalWordCount + IndexOverview.LetterSummaries[i].Total;
                }
            }
            return totalWordCount;
        }



        public ContentIndexOverview GetContentIndexOverview()
        {
            return IContentIndexerDataProvider.ContentIndex_SELECT_Overview();
        }
        
    }
}
