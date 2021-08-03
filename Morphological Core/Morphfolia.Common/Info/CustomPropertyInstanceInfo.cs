// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using Morphfolia.Common.Interfaces;

namespace Morphfolia.Common.Info
{
 	/// <summary>
	///  Summary description for ControlPropertyInfo.
	/// </summary>
    public struct CustomPropertyInstanceInfo : ICustomPropertyInstance
	{
        private int id;
        public int ID
        {
            get { return id; }
        }

        private int instanceID;
        public int InstanceID
        {
            get { return instanceID; }
        }

        private ControlPropertyType propertyType;
        public ControlPropertyType PropertyType
        {
            get { return propertyType; }
        }

        private string propertyKey;
        public string PropertyKey
        {
            get { return propertyKey; }
        }

        private string propertyValue;
        public string PropertyValue
        {
            get { return propertyValue; }
        }

		public CustomPropertyInstanceInfo(
			int _ID,
			int _InstanceID,
			ControlPropertyType _PropertyType,
			string _PropertyKey,
			string _PropertyValue)
		{
			id = _ID;
			instanceID = _InstanceID;
            propertyType = _PropertyType;
            propertyKey = _PropertyKey;
            propertyValue = _PropertyValue;
		}
	}


    public struct NullCustomPropertyInstanceInfo : ICustomPropertyInstance
    {
        public int ID
        {
            get { return Constants.SystemTypeValues.NullInt; }
        }

        public int InstanceID
        {
            get { return Constants.SystemTypeValues.NullInt; }
        }

        public ControlPropertyType PropertyType
        {
            get { return ControlPropertyTypeFactory.NullCustomPropertyType(); }
        }

        public string PropertyKey
        {
            get { return string.Empty; }
        }

        public string PropertyValue
        {
            get { return string.Empty; }
        }

        public NullCustomPropertyInstanceInfo(
			int _ID )
		{
            // all the property values are hard-coded, so the parameter 
            // in the constructor is just to satisfy the compiler.
		}
    }


	public struct SaveNewCustomPropertyInstanceInfo
	{
		public readonly int InstanceID;
		public readonly ControlPropertyType PropertyType;
		public readonly string PropertyKey;
		public readonly string PropertyValue;

		public SaveNewCustomPropertyInstanceInfo(
			int _InstanceID,
			ControlPropertyType _PropertyType,
			string _PropertyKey,
			string _PropertyValue)
		{
			InstanceID = _InstanceID;
			PropertyType = _PropertyType;
			PropertyKey = _PropertyKey;
			PropertyValue = _PropertyValue;
		}

        public override string ToString()
        {
            return string.Format("InstanceID={0} PropertyTypeIdentifier={1} PropertyKey={2} PropertyValue={3}",
                InstanceID.ToString(),
                PropertyType.PropertyTypeIdentifier,
                PropertyKey,
                PropertyValue);
        }
	}


	public class CustomPropertyInstanceInfoCollection : CollectionBase
	{
		public ICustomPropertyInstance this[ int index ]
		{
			get {
                if (index < List.Count)
                {
                    return ((CustomPropertyInstanceInfo)List[index]);
                }
                else
                {
                    return new NullCustomPropertyInstanceInfo();
                }
            }
			set { List[index] = value; }
		}

		public int Add( CustomPropertyInstanceInfo value )
		{
			return( List.Add( value ) );
		}

        /// <summary>
        /// Only returns the first matching item.
        /// </summary>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
		public CustomPropertyInstanceInfo GetControlPropertyByPropertyKey( string propertyKey )
		{
			CustomPropertyInstanceInfo controlPropertyInfo;
			for(int i = 0; i < List.Count; i++)
			{
				controlPropertyInfo = (CustomPropertyInstanceInfo)List[i];
				if( controlPropertyInfo.PropertyKey.Equals(propertyKey) )
				{
					return controlPropertyInfo;
				}
			}

			return new CustomPropertyInstanceInfo(
				Common.Constants.SystemTypeValues.NullInt, 
				Common.Constants.SystemTypeValues.NullInt,
				Common.ControlPropertyTypeFactory.CustomPropertyType(),
				null,
				null);
		}


        /// <summary>
        /// Returns the current property values as a string, formatted as 'value1, value2, value3'.
        /// </summary>
        /// <returns></returns>
        public string ValuesToString()
        {
            if (List.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                foreach (CustomPropertyInstanceInfo info in List)
                {
                    sb.AppendFormat("{0}, ", info.PropertyValue);
                }
                sb.Remove(sb.Length - 2, 2);

                return sb.ToString();
            }
        }


		public int IndexOf( CustomPropertyInstanceInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, CustomPropertyInstanceInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( CustomPropertyInstanceInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( CustomPropertyInstanceInfo value )
		{
			// If value is not of type ControlPropertyInfo, this will return false.
			return( List.Contains( value ) );
		}

        public CustomPropertyInstanceInfoCollection ByPropertyKey(string propertyKey)
        {
            propertyKey = propertyKey.ToLower();

            CustomPropertyInstanceInfo info;
            CustomPropertyInstanceInfoCollection collection = new CustomPropertyInstanceInfoCollection();
            for (int i = 0; i < List.Count; i++)
            {
                info = (CustomPropertyInstanceInfo)List[i];

                if (info.PropertyKey.ToLower().Equals(propertyKey))
                {
                    collection.Add(info);
                }
            }
            return collection;
        }
    }

}