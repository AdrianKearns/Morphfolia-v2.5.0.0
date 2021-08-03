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
    public class ContentIndexOverview
    {
        private ContentIndexSummaryCollection letterSummaries = new ContentIndexSummaryCollection();
        public ContentIndexSummaryCollection LetterSummaries
        {
            get { return letterSummaries; }
            set { letterSummaries = value; }
        }

        private PopularWordSummaryCollection popularWords = new PopularWordSummaryCollection();
        public PopularWordSummaryCollection PopularWords
        {
            get { return popularWords; }
            set { popularWords = value; }
        }

    }




	public struct ContentIndexSummary
	{
		public readonly int Total;
		public readonly string Letter;

		public ContentIndexSummary(
			int total,
			string letter)
		{
			Total = total;
			Letter = letter;
		}
	}



    public enum LetterArrayIndex { 
        A = 0, 
        B = 1, C = 2, D = 3, E = 4, F = 5, 
        G = 6, H = 7, I = 8, J = 9, K = 10, 
        L = 11, M = 12, N = 13, O = 14, P = 15, 
        Q = 16, R = 17, S = 18, T = 19, U = 20, 
        V = 21, W = 22, X = 23, Y = 24, Z = 25, 
        Default = 26 }

	public class ContentIndexSummaryCollection : CollectionBase
	{
        public ContentIndexSummary GetByLetter(LetterArrayIndex letter)
        {          
            foreach (ContentIndexSummary c in List)
            {
                if (c.Letter == letter.ToString())
                {
                    return c;
                }
            }

            return new ContentIndexSummary(Constants.SystemTypeValues.NullInt, string.Empty);
        }



        public ContentIndexSummary GetByLetter(string letter)
        {
            foreach (ContentIndexSummary c in List)
            {
                if (c.Letter.Equals(letter))
                {
                    return c;
                }
            }

            return new ContentIndexSummary(Constants.SystemTypeValues.NullInt, string.Empty);
        }



		public ContentIndexSummary this[ int index ]
		{
			get { return( (ContentIndexSummary) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( ContentIndexSummary value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( ContentIndexSummary value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, ContentIndexSummary value )
		{
			List.Insert( index, value );
		}

		public void Remove( ContentIndexSummary value )
		{
			List.Remove( value );
		}

		public bool Contains( ContentIndexSummary value )
		{
			// If value is not of type ContentIndexSummary, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.ContentIndexSummary") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.ContentIndexSummary.", "value" );
		}
	}


	public struct PopularWordSummary
	{
		public readonly int Total;
		public readonly string Letter;
		public readonly string Word;

		public PopularWordSummary(
			int _Total,
			string _Letter,
			string _Word)
		{
			Total = _Total;
			Letter = _Letter;
			Word = _Word;
		}
	}


	public class PopularWordSummaryCollection : CollectionBase
	{
		public PopularWordSummary this[ int index ]
		{
			get { return( (PopularWordSummary) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( PopularWordSummary value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( PopularWordSummary value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, PopularWordSummary value )
		{
			List.Insert( index, value );
		}

		public void Remove( PopularWordSummary value )
		{
			List.Remove( value );
		}

		public bool Contains( PopularWordSummary value )
		{
			// If value is not of type PopularWordSummary, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.PopularWordSummary") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.PopularWordSummary.", "value" );
		}
	}

}