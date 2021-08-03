// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Runtime.Serialization;

namespace Morphfolia.IDataProvider.Exceptions
{
	/// <summary>
	/// Summary description for DataNotFoundException.
	/// </summary>
	[Serializable]
	public class DataNotFoundException : ApplicationException
	{
		public DataNotFoundException() : base()
		{
		}

		public DataNotFoundException(string message) : base(message)
		{
		}

		public DataNotFoundException(string message, Exception inner) : base(message, inner)
		{
		}

		public DataNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}


	/// <summary>
	/// Summary description for InsertFailedException.
	/// </summary>
	[Serializable]
	public class InsertFailedException : ApplicationException
	{
		public InsertFailedException() : base()
		{
		}

		public InsertFailedException(string message) : base(message)
		{
		}

		public InsertFailedException(string message, Exception inner) : base(message, inner)
		{
		}

		public InsertFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}

    /// <summary>
    /// StoredProceedureFailedException is used to describe general exceptions raised by/during the 
    /// attempted execution of a SP.
    /// </summary>
    [Serializable]
    public class StoredProceedureFailedException : ApplicationException
    {
        public StoredProceedureFailedException()
            : base()
        {
        }

        public StoredProceedureFailedException(string message)
            : base(message)
        {
        }

        public StoredProceedureFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public StoredProceedureFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
