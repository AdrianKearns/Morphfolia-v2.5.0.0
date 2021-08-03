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
	public class IntCollection : CollectionBase
	{
        public override string ToString()
        {
            //return base.ToString();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(base.ToString());
            foreach (int i in base.List)
            {
                sb.AppendFormat(" {0}", i);
            }

            return sb.ToString();
        }

		public int this[ int index ]
		{
			get { return( (int) List[index] ); }
			set { List[index] = value; }
		}

        public int Add(int value)
		{
			return( List.Add( value ) );
		}

        public int IndexOf(int value)
		{
			return( List.IndexOf( value ) );
		}

        public void Insert(int index, int value)
		{
			List.Insert( index, value );
		}

        public void Remove(int value)
		{
			List.Remove( value );
		}

        public bool Contains(int value)
		{
			// If value is not of type IntInfo, this will return false.
			return( List.Contains( value ) );
		}

        /// <summary>
        /// Returns the highest value in the collection.
        /// </summary>
        public int MaxValue
        {
            get
            {
                int max = int.MinValue;
                foreach (int i in base.List)
                {
                    if (i > max)
                    {
                        max = i;
                    }
                }

                return max;
            }
        }

        /// <summary>
        /// Returns the lowest value in the collection.
        /// </summary>
        public int MinValue
        {
            get
            {
                int min = int.MaxValue;
                foreach (int i in base.List)
                {
                    if (i < min)
                    {
                        min = i;
                    }
                }

                return min;
            }
        }

        //protected override void OnInsert( int index, Object value )
        //{
        //    // Insert additional code to be run only when inserting values.
        //}

        //protected override void OnRemove( int index, Object value )
        //{
        //    // Insert additional code to be run only when removing values.
        //}

        //protected override void OnSet( int index, Object oldValue, Object newValue )
        //{
        //    // Insert additional code to be run only when setting values.
        //}

        //protected override void OnValidate( Object value )
        //{
        //    if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.IntInfo") )
        //        throw new ArgumentException( "value must be of type Morphfolia.Common.Info.IntInfo.", "value" );
        //}
	}
}