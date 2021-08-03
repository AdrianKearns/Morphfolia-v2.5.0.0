// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem
{
    /// <summary>
    /// Provides access to live content items without going via a specific page or URL.
    /// </summary>
    public class ContentPublishingHelper
    {
        /// <summary>
        /// Gets a collection of live content items, where the Notes property matches the 
        /// specified notesFilter argument.
        /// </summary>
        /// <param name="notesFilter"></param>
        /// <returns></returns>
        public static ContentInfoCollection GetContentByNotesFilter(string notesFilter)
        {
            return Morphfolia.Business.ContentItemHelper.GetLiveContentByNotesFilter(notesFilter);
        }

        public static string GetRawContentById(int contentId)
        {
            return Morphfolia.Business.ContentItemHelper.GetContentItemById(contentId).Content;
        }

        public static Morphfolia.Business.ContentItem GetContentById(int contentId)
        {
            return Morphfolia.Business.ContentItemHelper.GetContentItemById(contentId);
        }
    }
}
