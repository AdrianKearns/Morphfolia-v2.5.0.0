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
	/// Defines a word, as well as the Url and Title 
    /// of the page from whence it came.
	/// </summary>
	public struct WordIndexListInfo
	{
		public readonly string Word;
        public readonly int PageId;
        public readonly int ContentId;
        public readonly string Url;
        public readonly string Title;
        public readonly string ContentNote;
        public readonly Morphfolia.Common.ContentTypes.ContentTypeDefinition ContentTypeDefinition;

		public WordIndexListInfo(
			string word,
            int pageId,
            int contentId,
			string url,
			string title,
            string contentNote,
            string contentTypeMachineValue)
		{
			Word = word;
            PageId = pageId;
            ContentId = contentId;
            Url = url;
            Title = title;
            ContentNote = contentNote;
            ContentTypeDefinition = Morphfolia.Common.ContentTypes.Factory(contentTypeMachineValue);
		}
	}


	public class WordIndexListInfoCollection : CollectionBase
	{
		public WordIndexListInfo this[ int index ]
		{
			get { return( (WordIndexListInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( WordIndexListInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( WordIndexListInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, WordIndexListInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( WordIndexListInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( WordIndexListInfo value )
		{
			// If value is not of type WordIndexListInfo, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.WordIndexListInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.WordIndexListInfo.", "value" );
		}
	}

}
