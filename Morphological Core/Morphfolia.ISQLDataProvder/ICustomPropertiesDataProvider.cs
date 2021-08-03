// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using System.Data;
using Morphfolia.Common;
using Morphfolia.Common.Info;

namespace Morphfolia.IDataProvider
{
	/// <summary>
	/// Summary description for IImageDataProvider.
	/// </summary>
	public interface ICustomPropertiesDataProvider
	{
		/// <summary>
		/// Insert a single ControlPropertyInfo
		/// </summary>
		/// <param name="controlPropertySaveNewInfo"></param>
		void ControlProperties_INSERT( SaveNewCustomPropertyInstanceInfo controlPropertySaveNewInfo );

		/// <summary>
		/// Delete a single ControlProperty 
		/// </summary>
		/// <param name="id"></param>
		void ControlProperties_DELETE_BYID( int id );

		/// <summary>
		/// Delete ControlProperties by instance identifier
		/// </summary>
		/// <param name="instanceID">int</param>
		void ControlProperties_DELETE_BYInstanceID( int instanceID );

		/// <summary>
		/// Delete ControlProperties by instance identifier and PropertyKey
		/// </summary>
		/// <param name="instanceID">int</param>
		/// <param name="propertyKey">string</param>
		void ControlProperties_DELETE_BYInstanceIDPropertyKey( int instanceID, string propertyKey );

        /// <summary>
        /// Delete ControlProperties by instance identifier and PropertyType
        /// </summary>
        /// <param name="instanceID">int</param>
        /// <param name="propertyType">string</param>
        void ControlProperties_DELETE_BYInstanceIDPropertyType(int instanceID, string propertyType);


        void ControlProperties_DELETE_BYPropertyKeyAndPropertyValue(string propertyKey, string propertyValue);


        void ControlProperties_DELETE_BYPropertyTypeAndPropertyValue(string propertyType, string propertyValue);


		/// <summary>
		/// Get a single ControlPropertyInfo
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		CustomPropertyInstanceInfo ControlProperties_SELECT_BYID( int id );

		/// <summary>
		/// Get multiple ControlPropertyInfos by instance identifier - these should only hold 
		/// content item Ids.
		/// </summary>
		/// <param name="instanceID"></param>
		/// <param name="propertyTypeIdentifier"></param>
		/// <returns></returns>
		IntCollection ControlProperties_SELECT_ContentItemIdsBYInstanceID( int instanceID, string propertyTypeIdentifier );

        /// <summary>
        /// Get multiple ControlPropertyInfos by instance identifier
        /// </summary>
        /// <param name="instanceID"></param>
        /// <returns></returns>
        CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYInstanceID(int instanceID);

        /// <summary>
        /// Gets a collection of Control Properties by their InstanceID and PropertyType.
        /// </summary>
        /// <param name="instanceID"></param>
        /// <param name="propertyType">string (char(4)): CONT CUST</param>
        /// <returns></returns>
        CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYInstanceIDPropertyType(int instanceID, string propertyType);

		/// <summary>
		/// Gets a single ControlPropertyInfo (the first) by matching the instance identifier
		/// and the PropertyKey.
		/// </summary>
		/// <param name="instanceID"></param>
		/// <param name="propertyKey"></param>
		/// <returns></returns>
        CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYInstanceIDPropertyKey(int instanceID, string propertyKey);


        CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey(int instanceID, string propertyValue, string propertyKey);


        CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYPropertyKey(string propertyKey);


        CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYPropertyType(ControlPropertyType propertyType);


        CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYPropertyType(ControlPropertyType propertyType, string propertyValue);


        GenericStringIntInfoCollection ControlProperties_SELECT_CTagsForLiveBlogs(bool orderAlphabetically);

        GenericStringIntInfoCollection ControlProperties_SELECT_CTagsForLiveBlog(int pageId, bool orderAlphabetically);

        SearchResultInfoCollection ControlProperties_SELECT_BlogPostsByCTag(string tag);
    }
}