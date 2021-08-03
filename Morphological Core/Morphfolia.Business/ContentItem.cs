// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Constants;
using Morphfolia.Business.Constants;

namespace Morphfolia.Business
{
    /// <summary>
    /// Summary description for ContentItem.
    /// </summary>
    public class ContentItem
    {
        private int _ContentID = SystemTypeValues.NullInt;
        public int ContentID
        {
            get { return _ContentID; }
            set { _ContentID = value; }
        }

        private string _Note = string.Empty;
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        private Common.ContentTypes.ContentTypeDefinition contentType = Common.ContentTypes.All;
        public Common.ContentTypes.ContentTypeDefinition ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        private string _Content = string.Empty;
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private string _ContentEntryFilter = string.Empty;
        public string ContentEntryFilter
        {
            get { return _ContentEntryFilter; }
            set { _ContentEntryFilter = value; }
        }

        private string _TextContent = string.Empty;
        public string TextContent
        {
            get { return _TextContent; }
            set { _TextContent = value; }
        }

        private bool _IsLive = false;
        public bool IsLive
        {
            get { return _IsLive; }
            set { _IsLive = value; }
        }

        private bool _IsSearchable = false;
        public bool IsSearchable
        {
            get { return _IsSearchable; }
            set { _IsSearchable = value; }
        }




        private string lastModifiedBy = string.Empty;
        /// <summary>
        /// Returns the name of the user whom modified either the page or one of it's content items - going by the most recently modified.
        /// </summary>
        public string LastModifiedBy
        {
            get { return lastModifiedBy; }
            set { lastModifiedBy = value; }
        }

        private DateTime lastModified = SystemTypeValues.NullDate;
        /// <summary>
        /// Returns the DateTime when the page or one of it's content items was most recently modified.
        /// </summary>
        public DateTime LastModified
        {
            get { return lastModified; }
            set { lastModified = value; }
        }


    }
}
