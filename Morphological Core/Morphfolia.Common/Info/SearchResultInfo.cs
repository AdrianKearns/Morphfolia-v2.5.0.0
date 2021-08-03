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
	/// Summary description for SearchResultInfo.
	/// </summary>
	public struct SearchResultInfo
	{
		public readonly int PageID;
		public readonly string Title;
		public readonly string Url;
		public readonly string Keywords;
		public readonly string Description;
		public readonly DateTime LastModified;
		public readonly string LastModifiedBy;
        public readonly int Matches;
        public readonly int ContentID;
        public readonly Morphfolia.Common.ContentTypes.ContentTypeDefinition ContentTypeDefinition;
        public readonly string ContentNote;


		public SearchResultInfo(
			int pageID,
			string title,
			string url,
			string keywords,
			string description,
			DateTime lastModified,
			string lastModifiedBy,
            int matches,
            int contentId,
            string contentNote,
            string contentTypeMachineValue)
		{
			PageID = pageID;
			Title = title;
			Url = url;
			Keywords = keywords;
			Description = description;
			LastModified = lastModified;
			LastModifiedBy = lastModifiedBy;
            Matches = matches;
            ContentID = contentId;
            ContentNote = contentNote;
            ContentTypeDefinition = Morphfolia.Common.ContentTypes.Factory(contentTypeMachineValue);
		}
	}




	public class SearchResultInfoCollection : CollectionBase
	{
		public SearchResultInfo this[ int index ]
		{
			get { return( (SearchResultInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( SearchResultInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( SearchResultInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, SearchResultInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( SearchResultInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( SearchResultInfo value )
		{
			// If value is not of type SearchResultInfo, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.SearchResultInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.SearchResultInfo.", "value" );
		}
	}





}
