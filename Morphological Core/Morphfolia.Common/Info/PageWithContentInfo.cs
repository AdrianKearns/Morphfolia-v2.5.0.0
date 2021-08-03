// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;

namespace Morphfolia.Common.Info
{
	/// <summary>
	///  Summary description for PageWithContentInfo.
	/// </summary>
	public struct PageWithContentInfo
	{
		public readonly int PageID;
		public readonly string Title;
		public readonly string Url;
		public readonly string Keywords;
		public readonly string Description;
		public readonly DateTime LastModified;
		public readonly string LastModifiedBy;
		public readonly bool IsSearchable;
		public readonly bool IsLive;
		public readonly Morphfolia.Common.Info.ContentInfoCollection ContentCollection;

		public PageWithContentInfo(
			int pageID,
			string title,
			string url,
			string keywords,
			string description,
			DateTime lastModified,
			string lastModifiedBy,
			bool isSearchable,
			bool isLive,
			Morphfolia.Common.Info.ContentInfoCollection contentCollection)
		{
			PageID = pageID;
			Title = title;
			Url = url;
			Keywords = keywords;
			Description = description;
			LastModified = lastModified;
			LastModifiedBy = lastModifiedBy;
			IsSearchable = isSearchable;
			IsLive = isLive;
			ContentCollection = contentCollection;
		}
	}


	public class PageWithContentInfoCollection : CollectionBase
	{
		public Morphfolia.Common.Info.PageWithContentInfo this[ int index ]
		{
			get { return( (Morphfolia.Common.Info.PageWithContentInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( Morphfolia.Common.Info.PageWithContentInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( Morphfolia.Common.Info.PageWithContentInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, Morphfolia.Common.Info.PageWithContentInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( Morphfolia.Common.Info.PageWithContentInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( Morphfolia.Common.Info.PageWithContentInfo value )
		{
			// If value is not of type Morphfolia.Common.Info.PageWithContentInfo, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )
		{
			// Insert additional code to be run only when inserting values.
		}

		protected override void OnRemove( int index, Object value )
		{
			// Insert additional code to be run only when removing values.
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )
		{
			// Insert additional code to be run only when setting values.
		}

		protected override void OnValidate( Object value )
		{
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.PageWithContentInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.PageWithContentInfo.", "value" );
		}
	}

}