// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Runtime.Serialization;

namespace Morphfolia.WebControls.Exceptions
{
	/// <summary>
	/// A generic ABK.WebControls tier exception for ImageManagement.
	/// </summary>
	public class ImageManagementException : ApplicationException
	{
		public ImageManagementException() : base()
		{
		}

		public ImageManagementException( string message ) : base(message)
		{
		}

		public ImageManagementException( string message, Exception inner ) : base(message, inner)
		{
		}

		public ImageManagementException( SerializationInfo info, StreamingContext context)
		{
		}
	}


	/// <summary>
	/// A generic ABK.WebControls tier exception for ImageManagement.
	/// </summary>
	public class FileManagementException : ApplicationException
	{
		public FileManagementException() : base()
		{
		}

		public FileManagementException( string message ) : base(message)
		{
		}

		public FileManagementException( string message, Exception inner ) : base(message, inner)
		{
		}

		public FileManagementException( SerializationInfo info, StreamingContext context)
		{
		}
	}
}
