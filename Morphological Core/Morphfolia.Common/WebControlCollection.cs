// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using System.Web.UI.WebControls;

namespace Morphfolia.Common
{
	/// <summary>
	/// Summary description for WebControlCollection.
	/// </summary>
	public class WebControlCollection : CollectionBase
	{
		/// <summary>
		/// Get an item by its index.
		/// </summary>
		public WebControl this[ int index ]
		{
			get { return( (WebControl) List[index] ); }
			set { List[index] = value; }
		}


		/// <summary>
		/// Add an item to the collection.
		/// </summary>
		/// <param name="value">The item to add.</param>
		/// <returns>Its index.</returns>
		public int Add( WebControl value )
		{
			return( List.Add( value ) );
		}
	}
}
