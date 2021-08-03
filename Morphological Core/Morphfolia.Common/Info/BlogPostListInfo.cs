// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using System.Collections.Specialized;

namespace Morphfolia.Common.Info
{
	/// <summary>
	///  A full blog post, including content.
	/// </summary>
	public struct BlogPostInfo
	{
		public readonly int ContentID;
        public readonly string ContentNote;
        public readonly string Content;
		public readonly Common.ContentTypes.ContentTypeDefinition ContentType;
		public readonly bool ContentIsLive;
		public readonly bool ContentIsSearchable;
		public readonly string ContentEntryFilter;
		public readonly DateTime ContentLastModified;
		public readonly string ContentLastModifiedBy;
		public readonly int PageID;
		public readonly string PageTitle;
		public readonly string PageUrl;
		public readonly string PageKeywords;
		public readonly string PageDescription;
		public readonly DateTime PageLastModified;
		public readonly string PageLastModifiedBy;
		public readonly bool PageIsSearchable;
		public readonly bool PageIsLive;
        public readonly StringCollection Tags;

		public BlogPostInfo(
			int contentID,
			string contentNote,
            string content,
			Common.ContentTypes.ContentTypeDefinition contentType,
			bool contentIsLive,
			bool contentIsSearchable,
			string contentEntryFilter,
			DateTime contentLastModified,
			string contentLastModifiedBy,
			int pageID,
			string pageTitle,
			string pageUrl,
			string pageKeywords,
			string pageDescription,
			DateTime pageLastModified,
			string pageLastModifiedBy,
			bool pageIsSearchable,
			bool pageIsLive,
            StringCollection tags)
		{
			ContentID = contentID;
			ContentNote = contentNote;
            Content = content;
			ContentType = contentType;
			ContentIsLive = contentIsLive;
			ContentIsSearchable = contentIsSearchable;
			ContentEntryFilter = contentEntryFilter;
			ContentLastModified = contentLastModified;
			ContentLastModifiedBy = contentLastModifiedBy;
			PageID = pageID;
			PageTitle = pageTitle;
			PageUrl = pageUrl;
			PageKeywords = pageKeywords;
			PageDescription = pageDescription;
			PageLastModified = pageLastModified;
			PageLastModifiedBy = pageLastModifiedBy;
			PageIsSearchable = pageIsSearchable;
			PageIsLive = pageIsLive;
            Tags = tags;
		}
	}


	public class BlogPostInfoCollection : CollectionBase
	{
		public BlogPostInfo this[ int index ]
		{
			get { return( (BlogPostInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( BlogPostInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( BlogPostInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, BlogPostInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( BlogPostInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( BlogPostInfo value )
		{
			// If value is not of type BlogPostListInfo, this will return false.
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

        //protected override void OnValidate( Object value )
        //{
        //    if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.BlogPostListInfo") )
        //        throw new ArgumentException( "value must be of type Morphfolia.Common.Info.BlogPostListInfo.", "value" );
        //}
	}

}