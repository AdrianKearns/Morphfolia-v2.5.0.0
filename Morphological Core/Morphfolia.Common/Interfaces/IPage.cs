// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using Morphfolia.Common.Info;

namespace Morphfolia.Common.Interfaces
{
    /// <summary>
    /// For publishing / presentation only?
    /// </summary>
    public interface IPage
    {
        ContentInfoCollection ContentItems
        {
            get;
            set;
        }

        string Title
        {
            get;
            set;
        }

        int PageID
        {
            get;
            set;
        }

        /// <summary>
        /// Returns the DateTime when the page was last modified.
        /// </summary>
        DateTime LastModified
        {
            get;
            set;
        }

        /// <summary>
        /// Returns the DateTime when the page or one of it's content items was most recently modified.
        /// </summary>
        DateTime ContentLastModified
        {
            get;
        }

        /// <summary>
        /// Returns the name of the user who modified the page.
        /// </summary>
        string LastModifiedBy
        {
            get;
            set;
        }

        /// <summary>
        /// Returns the name of the user whom modified either the page or one of it's content items - going by the most recently modified.
        /// </summary>
        string ContentLastModifiedBy
        {
            get;
        }

        string Keywords
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }
    }
}
