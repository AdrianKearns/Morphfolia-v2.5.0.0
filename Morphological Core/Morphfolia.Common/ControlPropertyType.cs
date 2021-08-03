// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.Common
{
	/// <summary>
	/// Summary description for ControlPropertyType.
	/// </summary>
	public class ControlPropertyType
	{
        private string propertyTypeIdentifier = string.Empty;
        /// <summary>
        /// The char(4) key for the property.  Thsi value is used by the system.
        /// </summary>
		public string PropertyTypeIdentifier
		{
			get{ return propertyTypeIdentifier; }
			set{ propertyTypeIdentifier = value; }
		}

        private string propertyTypeDescription = string.Empty;
        /// <summary>
        /// The human readable description of what the property type is.
        /// </summary>
		public string PropertyTypeDescription
		{
			get{ return propertyTypeDescription; }
			set{ propertyTypeDescription = value; }
		}
	}



	public partial class ControlPropertyTypeConstants
	{       
		public partial class PropertyTypeIdentifiers
		{
            /// <summary>
            /// Not set
            /// </summary>
            public const string NULL = "NULL";

            /// <summary>
            /// A content item binding (to a page)
            /// </summary>
            public const string CONT = "CONT";

            /// <summary>
            /// A custom property (for a page)
            /// </summary>
            public const string CUST = "CUST";

            /// <summary>
            /// A Global setting
            /// </summary>
            public const string GOBL = "GOBL";

            /// <summary>
            /// A Blog
            /// </summary>
            public const string BPST = "BPST";

            /// <summary>
            /// Content Tag
            /// </summary>
            public const string CTAG = "CTAG";
        }

		public partial class PropertyTypeDescriptions
		{
            public const string NULL = "NULL";
            public const string CONT = "Content Item Container";
            public const string CUST = "Custom Property";
            public const string GOBL = "Global, site-wide setting";
            public const string BPST = "A link link between a blog (Page) and a blog-post (Content Item)";
            public const string CTAG = "A tag that describes or adds context to a piece of content";
        }
	}


	public partial class ControlPropertyTypeFactory
	{
		public static ControlPropertyType ControlPropertyType( string propertyTypeIdentifier )
		{
            switch (propertyTypeIdentifier)
            {
                case ControlPropertyTypeConstants.PropertyTypeIdentifiers.BPST:
                    return ControlPropertyTypeFactory.BlogPostLinkPropertyType();

                case ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT:
                    return ControlPropertyTypeFactory.ContentItemContainerPropertyType();

                case ControlPropertyTypeConstants.PropertyTypeIdentifiers.CTAG:
                    return ControlPropertyTypeFactory.ContentTagPropertyType();

                case ControlPropertyTypeConstants.PropertyTypeIdentifiers.CUST:
                    return ControlPropertyTypeFactory.CustomPropertyType();

                case ControlPropertyTypeConstants.PropertyTypeIdentifiers.GOBL:
                    return ControlPropertyTypeFactory.GlobalPropertyType();

                case ControlPropertyTypeConstants.PropertyTypeIdentifiers.NULL:
                    return ControlPropertyTypeFactory.NullCustomPropertyType();
            
            }




			if( propertyTypeIdentifier.Equals( ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT ) )
			{
				return ControlPropertyTypeFactory.ContentItemContainerPropertyType();
			}
			else
			{
				return ControlPropertyTypeFactory.CustomPropertyType();
			}
		}

        /// <summary>
        /// Returns a 'CONT' (Content Item) property type.
        /// </summary>
        /// <returns></returns>
		public static ControlPropertyType ContentItemContainerPropertyType()
		{
			ControlPropertyType controlPropertyType = new ControlPropertyType();
			controlPropertyType.PropertyTypeIdentifier = ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT;
			controlPropertyType.PropertyTypeDescription = ControlPropertyTypeConstants.PropertyTypeDescriptions.CONT;
			return controlPropertyType;
		}

        /// <summary>
        /// Returns a 'GOBL' (global) property type.
        /// </summary>
        /// <returns></returns>
        public static ControlPropertyType GlobalPropertyType()
        {
            ControlPropertyType controlPropertyType = new ControlPropertyType();
            controlPropertyType.PropertyTypeIdentifier = ControlPropertyTypeConstants.PropertyTypeIdentifiers.GOBL;
            controlPropertyType.PropertyTypeDescription = ControlPropertyTypeConstants.PropertyTypeDescriptions.GOBL;
            return controlPropertyType;
        }

        /// <summary>
        /// Returns a 'CUST' (custom property) property type.
        /// </summary>
        /// <returns></returns>
		public static ControlPropertyType CustomPropertyType()
		{
			ControlPropertyType controlPropertyType = new ControlPropertyType();
			controlPropertyType.PropertyTypeIdentifier = ControlPropertyTypeConstants.PropertyTypeIdentifiers.CUST;
			controlPropertyType.PropertyTypeDescription = ControlPropertyTypeConstants.PropertyTypeDescriptions.CUST;
			return controlPropertyType;
		}

        /// <summary>
        /// Returns a 'BLOG' (a blog) property type.
        /// </summary>
        /// <returns></returns>
        public static ControlPropertyType BlogPostLinkPropertyType()
        {
            ControlPropertyType controlPropertyType = new ControlPropertyType();
            controlPropertyType.PropertyTypeIdentifier = ControlPropertyTypeConstants.PropertyTypeIdentifiers.BPST;
            controlPropertyType.PropertyTypeDescription = ControlPropertyTypeConstants.PropertyTypeDescriptions.BPST;
            return controlPropertyType;
        }

        /// <summary>
        /// Returns a 'CTAG' (a content tag) property type.
        /// </summary>
        /// <returns></returns>
        public static ControlPropertyType ContentTagPropertyType()
        {
            ControlPropertyType controlPropertyType = new ControlPropertyType();
            controlPropertyType.PropertyTypeIdentifier = ControlPropertyTypeConstants.PropertyTypeIdentifiers.CTAG;
            controlPropertyType.PropertyTypeDescription = ControlPropertyTypeConstants.PropertyTypeDescriptions.CTAG;
            return controlPropertyType;
        }

        /// <summary>
        /// Returns a 'NULL' property type.
        /// </summary>
        /// <returns></returns>
        public static ControlPropertyType NullCustomPropertyType()
        {
            ControlPropertyType controlPropertyType = new ControlPropertyType();
            controlPropertyType.PropertyTypeIdentifier = ControlPropertyTypeConstants.PropertyTypeIdentifiers.NULL;
            controlPropertyType.PropertyTypeDescription = ControlPropertyTypeConstants.PropertyTypeDescriptions.NULL;
            return controlPropertyType;
        }
	}
}
