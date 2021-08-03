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
	///  Summary description for PageContentUpdateInfo.
	/// </summary>
	public struct PageContentUpdateInfo
	{
		public readonly int PageID;
		public readonly int ContentID;

		public PageContentUpdateInfo(
			int _PageID,
			int _ContentID)
		{
			PageID = _PageID;
			ContentID = _ContentID;
		}
	}


	public class PageContentUpdateInfoCollection : CollectionBase
	{
		public PageContentUpdateInfo this[ int index ]
		{
			get { return( (PageContentUpdateInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( PageContentUpdateInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( PageContentUpdateInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, PageContentUpdateInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( PageContentUpdateInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( PageContentUpdateInfo value )
		{
			// If value is not of type PageContentUpdateInfo, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.PageContentUpdateInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.PageContentUpdateInfo", "value" );
		}
	}

}