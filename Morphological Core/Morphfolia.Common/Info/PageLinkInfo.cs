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
	/// Summary description for PageLink.
	/// </summary>
	public struct PageLinkInfo
	{
		public readonly string UrlDirectoryPath;
		public readonly string UrlFileName;
		public readonly string Text;

		public PageLinkInfo(
			string _UrlDirectoryPath,
			string _UrlFileName,
			string _Text)
		{
			UrlDirectoryPath = _UrlDirectoryPath;
			UrlFileName = _UrlFileName;
			Text = _Text;
		}

		public PageLinkInfo(
			PageInfo pageInfo
			)
		{
			if( pageInfo.Url.LastIndexOf("/") < 0)
			{
				UrlDirectoryPath = pageInfo.Url;
				UrlFileName = "";
			}
			else
			{
				UrlDirectoryPath = pageInfo.Url.Substring( 0, pageInfo.Url.LastIndexOf("/") );
				UrlFileName = pageInfo.Url.Substring( pageInfo.Url.LastIndexOf("/")+1 );
			}
			Text = pageInfo.Title;
		}
	}

	
	public class PageLinkInfoCollection : CollectionBase
	{
		public PageLinkInfo this[ int index ]
		{
			get { return( (PageLinkInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( PageLinkInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( PageLinkInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, PageLinkInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( PageLinkInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( PageLinkInfo value )
		{
			// If value is not of type PageLinkInfo, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.PageLinkInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.PageLinkInfo", "value" );
		}
	}
}
