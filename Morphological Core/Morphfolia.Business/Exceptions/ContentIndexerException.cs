// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Runtime.Serialization;

namespace Morphfolia.Business.Exceptions
{




    /// <summary>
    /// Exception type for Content Indexing.
    /// </summary>
    public class ContentIndexerException : ApplicationException
    {
        public ContentIndexerException()
            : base()
        {
        }

        public ContentIndexerException(string message)
            : base(message)
        {
        }

        public ContentIndexerException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ContentIndexerException(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
