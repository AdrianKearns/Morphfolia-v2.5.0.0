// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.Common.Info
{
	/// <summary>
	///  Summary description for CustomPropertyInfo.
	/// </summary>
	public struct CustomPropertyInfo
	{
		public readonly string PropertyKey;
		public readonly string PropertyValue;
		public readonly string PropertyDefaultValue;
		public readonly string PropertyName;
		public readonly string Description;
        public readonly string SuggestedUsage;
        public readonly Various.InputSizes InputSize;

		public CustomPropertyInfo(
			string propertyKey,
			string propertyValue,
			string propertyDefaultValue,
			string propertyName,
			string description,
			string suggestedUsage)
		{
			PropertyKey = propertyKey;
			PropertyValue = propertyValue;
			PropertyDefaultValue = propertyDefaultValue;
			PropertyName = propertyName;
			Description = description;
			SuggestedUsage = suggestedUsage;
            InputSize = Various.InputSizes.SingleLine30x1;
		}

        public CustomPropertyInfo(
            string propertyKey,
            string propertyValue,
            string propertyDefaultValue,
            string propertyName,
            string description,
            string suggestedUsage,
            Various.InputSizes inputSize)
        {
            PropertyKey = propertyKey;
            PropertyValue = propertyValue;
            PropertyDefaultValue = propertyDefaultValue;
            PropertyName = propertyName;
            Description = description;
            SuggestedUsage = suggestedUsage;
            InputSize = inputSize;
        }
	}


	public class CustomPropertyInfoCollection : CollectionBase
	{
		public CustomPropertyInfo this[ int index ]
		{
			get { return( (CustomPropertyInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( CustomPropertyInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( CustomPropertyInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, CustomPropertyInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( CustomPropertyInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( CustomPropertyInfo value )
		{
			// If value is not of type CustomPropertyInfo, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.CustomPropertyInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.CustomPropertyInfo.", "value" );
		}
	}
}