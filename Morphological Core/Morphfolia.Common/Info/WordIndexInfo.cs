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
    ///  The WordIndexInfo holds information about a word that is being indexed.
	/// </summary>
	public struct WordIndexInfo
	{
        public readonly string Word;

        public WordIndexInfo(string word)
        {
            Word = word;
        }
	}


    public class WordIndexInfoCollection : CollectionBase
	{
        private char firstCharacter;
        public char FirstCharacter
        {
            get { return firstCharacter; }
            set { firstCharacter = value; }
        }

        public WordIndexInfo this[int index]
		{
            get { return ((WordIndexInfo)List[index]); }
			set { List[index] = value; }
		}

        public int Add(WordIndexInfo value)
		{
			return( List.Add( value ) );
		}

        public int IndexOf(WordIndexInfo value)
		{
			return( List.IndexOf( value ) );
		}

        public void Insert(int index, WordIndexInfo value)
		{
			List.Insert( index, value );
		}

		public void Remove( string value )
		{
			List.Remove( value );
		}

        public bool Contains(WordIndexInfo value)
		{
			// If value is not of type string, this will return false.
			return( List.Contains( value ) );
		}


	}


}