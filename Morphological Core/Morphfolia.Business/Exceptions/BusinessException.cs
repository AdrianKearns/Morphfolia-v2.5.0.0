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
	/// A generic Morphfolia.Business tier exception.
	/// </summary>
	public class BusinessException : ApplicationException
	{
		public BusinessException() : base()
		{
		}

		public BusinessException( string message ) : base(message)
		{
		}

		public BusinessException( string message, Exception inner ) : base(message, inner)
		{
		}

		public BusinessException( SerializationInfo info, StreamingContext context)
		{
		}
	}

}
