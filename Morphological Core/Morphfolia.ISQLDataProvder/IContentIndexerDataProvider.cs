// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using Morphfolia.Common.Info;

namespace Morphfolia.IDataProvider
{
	/// <summary>
    /// IContentIndexerDataProvider describes all the different data methods we expect 
    /// when dealing with Content Indexing.
	/// </summary>
    public interface IContentIndexerDataProvider
    {
        Morphfolia.Common.ContentIndexerActivityMonitor ContentIndexerActivityMonitor
        {
            get;
            set;
        }


        void PURGE_ContentIndexDataForContentInstance(char letter, int pageId, int contentId);
        void ContentIndex_INSERT_Word(Morphfolia.Common.Info.WordIndexAlphabet wordIndexAlphabet);
        void ContentIndex_DELETE_UnwantedWords(String[] unwantedWords);

        /// <summary>
        /// Deletes all words that do not belong to a valid page and content item.
        /// </summary>
        void ContentIndex_DELETE_OrphanRecords();

        WordIndexSearchResultInfoCollection ContentIndex_SELECT_WordsForTagCloud(int minimumOccurrances);
 

        /// <summary>
        /// Gets all the words for a word index list, by letter.
        /// </summary>
        /// <param name="letter">The letter to select by</param>
        /// <returns>WordIndexListInfoCollection all the words and the references to 
        /// the pages where the words are displayed.</returns>
        WordIndexListInfoCollection ContentIndex_SELECT_WordIndexListForLetter(string letter);


        ContentIndexOverview ContentIndex_SELECT_Overview();
	}
}
