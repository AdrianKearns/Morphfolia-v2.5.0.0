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
    ///  Summary description for WordIndexSearchResultInfo.
    /// </summary>
    public struct WordIndexSearchResultInfo
    {
	    public readonly string Word;
        public readonly int TotalOccurances;
        public readonly int DistinctPageCount;

	    public WordIndexSearchResultInfo(
		    string word,
            int totalOccurances,
            int distinctPageCount)
	    {
            Word = word;
            TotalOccurances = totalOccurances;
            DistinctPageCount = distinctPageCount;
	    }
    }


    public class WordIndexSearchResultInfoCollection : CollectionBase
    {
	    public WordIndexSearchResultInfo this[ int index ]
	    {
		    get { return( (WordIndexSearchResultInfo) List[index] ); }
		    set { List[index] = value; }
	    }

	    public int Add( WordIndexSearchResultInfo value )
	    {
		    return( List.Add( value ) );
	    }

	    public int IndexOf( WordIndexSearchResultInfo value )
	    {
		    return( List.IndexOf( value ) );
	    }

	    public void Insert( int index, WordIndexSearchResultInfo value )
	    {
		    List.Insert( index, value );
	    }

	    public void Remove( WordIndexSearchResultInfo value )
	    {
		    List.Remove( value );
	    }

	    public bool Contains( WordIndexSearchResultInfo value )
	    {
		    // If value is not of type WordIndexSearchResultInfo, this will return false.
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
		    if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.WordIndexSearchResultInfo") )
			    throw new ArgumentException( "value must be of type Morphfolia.Common.Info.WordIndexSearchResultInfo.", "value" );
	    }
    }

}