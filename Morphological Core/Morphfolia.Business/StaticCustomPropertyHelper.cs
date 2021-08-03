// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common;
using Morphfolia.Common.Info;
using Morphfolia.Common.Interfaces;
using Morphfolia.IDataProvider;
//using Morphfolia.Common.Logging;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.Business.Constants;
using Morphfolia.Business.Logging;
using Morphfolia.Business.Helpers;

namespace Morphfolia.Business
{
    /// <summary>
    /// Provides access and management of CustomProperties.
    /// </summary>
	public class StaticCustomPropertyHelper
	{
        private static ICustomPropertiesDataProvider iCustomPropertiesDataProvider;
        private static ICustomPropertiesDataProvider ICustomPropertiesDataProvider
        {
            get
            {
                if (iCustomPropertiesDataProvider == null)
                {
                    iCustomPropertiesDataProvider = ProviderLoader.Load(DataProviderAppSettingKeys.ICustomPropertiesDataProvider) as Morphfolia.IDataProvider.ICustomPropertiesDataProvider;
                }
                return iCustomPropertiesDataProvider;
            }
        }



        public static CustomPropertyInstanceInfoCollection GetControlPropertiesByPropertyType(ControlPropertyType controlPropertyType)
        {
            return ICustomPropertiesDataProvider.ControlProperties_SELECT_BYPropertyType(controlPropertyType);
        }

        public static CustomPropertyInstanceInfoCollection GetControlPropertiesByPropertyType(ControlPropertyType controlPropertyType, string propertyValue)
        {
            return ICustomPropertiesDataProvider.ControlProperties_SELECT_BYPropertyType(controlPropertyType, propertyValue);
        }


		/// <summary>
		/// Get all the Control Properties for the LayoutWebControl.
		/// </summary>
		/// <param name="instanceId"></param>
		/// <returns></returns>
		public static CustomPropertyInstanceInfoCollection GetControlPropertiesByInstanceID( int instanceId )
		{
            return GetControlPropertiesByInstanceID(instanceId, string.Empty);
		}

        /// <summary>
        /// Get all the Control Properties for the LayoutWebControl.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static CustomPropertyInstanceInfoCollection GetControlPropertiesByInstanceID(int instanceId, string propertyType)
        {
            if (propertyType.Equals(string.Empty))
            {
                Logger.LogVerboseInformation("CustomPropertyHelper.GetControlPropertiesByInstanceID()", string.Format("invoked, instanceId = {0}", instanceId.ToString()), EventIds._4062);

                return ICustomPropertiesDataProvider.ControlProperties_SELECT_BYInstanceID(instanceId);
            }
            else
            {
                Logger.LogVerboseInformation("CustomPropertyHelper.GetControlPropertiesByInstanceID()", string.Format("invoked, instanceId = {0}, propertyType = {1}", instanceId.ToString(), propertyType), EventIds._4062);

                return ICustomPropertiesDataProvider.ControlProperties_SELECT_BYInstanceIDPropertyType(instanceId, propertyType);
            }
        }

		/// <summary>
		/// Get all the Control Properties for the LayoutWebControl.
		/// </summary>
		/// <param name="layoutWebControl"></param>
		/// <param name="instanceId"></param>
		/// <returns></returns>
		public static IntCollection GetContentItemIdsByInstanceID( int instanceId )
		{
			return ICustomPropertiesDataProvider.ControlProperties_SELECT_ContentItemIdsBYInstanceID( instanceId, Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT );
		}

		/// <summary>
		/// Get all the Control Properties for the LayoutWebControl, by Property Key.
		/// </summary>
		/// <param name="instanceId"></param>
		/// <param name="propertyKey"></param>
		/// <returns></returns>
        public static CustomPropertyInstanceInfoCollection GetControlPropertiesByInstanceIDAndPropertyKey(int instanceId, string propertyKey)
		{
			return ICustomPropertiesDataProvider.ControlProperties_SELECT_BYInstanceIDPropertyKey( instanceId, propertyKey );
		}

        /// <summary>
        /// Get all the Control Properties for the LayoutWebControl, by Property Key.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
        public static CustomPropertyInstanceInfoCollection GetControlPropertiesByPropertyKey(string propertyKey)
        {
            return ICustomPropertiesDataProvider.ControlProperties_SELECT_BYPropertyKey(propertyKey);
        }


        public static string GetCustomPropertyInstanceByInstanceID(int instanceId, string propertyKey)
        {
            try
            {
                CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = ICustomPropertiesDataProvider.ControlProperties_SELECT_BYInstanceIDPropertyKey(instanceId, propertyKey);

                if (controlPropertyInfoCollection.Count > 0)
                {
                    return controlPropertyInfoCollection[0].PropertyValue;
                }           
                else
                {
                    return String.Empty;
                }
            }
            catch(Exception ex)
            {
                Logger.LogException(
                    "GetCustomPropertyInstanceByInstanceID() failed.", 
                    ex, 
                    5451,
                    string.Format("instanceId = {0}, propertyKey = {1}", instanceId.ToString(), propertyKey)
                    );
                return String.Empty;
            }
        }


        public static string GetLayoutWebControlTypeByInstanceID(int instanceId)
		{
            return GetCustomPropertyInstanceByInstanceID(instanceId, SpecialCustomPropertyKeys.LayoutWebControlType);
		}


        public static string GetSkinProviderTypeByInstanceID(int instanceId)
        {
            return GetCustomPropertyInstanceByInstanceID(instanceId, SpecialCustomPropertyKeys.SkinProviderType);
        }


        public static string GetFormTemplatePresenterTypeByInstanceID(int instanceId)
        {
            string formTemplatePresenterType = GetCustomPropertyInstanceByInstanceID(instanceId, SpecialCustomPropertyKeys.FormTemplatePresenterType);

            if (formTemplatePresenterType.Equals(string.Empty))
            {
                Logger.LogWarning(
                    "FormTemplatePresenterType not specified for this instance, using default instead.",
                    string.Format("Instance ID '{0}'", instanceId.ToString()), 
                    EventIds._4063);
            }

            return formTemplatePresenterType;
        }


        public static GenericStringIntInfoCollection GetAllTagsForAllLiveBlogsOrderedAlphabetically()
        {
            return ICustomPropertiesDataProvider.ControlProperties_SELECT_CTagsForLiveBlogs(true);
        }

        public static GenericStringIntInfoCollection GetAllTagsForAllLiveBlogsOrderedByOccurrance()
        {
            return ICustomPropertiesDataProvider.ControlProperties_SELECT_CTagsForLiveBlogs(false);
        }


        public static GenericStringIntInfoCollection GetAllTagsForLiveBlogOrderedAlphabetically(int blogId)
        {
            return ICustomPropertiesDataProvider.ControlProperties_SELECT_CTagsForLiveBlog(blogId, true);
        }

        public static GenericStringIntInfoCollection GetAllTagsForLiveBlogOrderedByOccurrance(int blogId)
        {
            return ICustomPropertiesDataProvider.ControlProperties_SELECT_CTagsForLiveBlog(blogId, false);
        }



        public static SearchResultInfoCollection GetBlogPostsForTag(string tag)
        {
            return ICustomPropertiesDataProvider.ControlProperties_SELECT_BlogPostsByCTag(tag);
        }


		public static void DeleteControlPropertiesByInstance( int instanceId )
		{
            Logger.LogVerboseInformation("DeleteControlPropertiesByInstance()", instanceId.ToString(), EventIds._4061);
			ICustomPropertiesDataProvider.ControlProperties_DELETE_BYInstanceID( instanceId );
		}


        public static void DeleteControlPropertiesByInstanceAndPropertyKey(int instanceId, string propertyKey)
		{
            Logger.LogVerboseInformation("DeleteControlPropertiesByInstanceAndPropertyKey()", string.Format("Instance: {0}, Property Key: {1}", instanceId.ToString(), propertyKey), EventIds._4060);
			ICustomPropertiesDataProvider.ControlProperties_DELETE_BYInstanceIDPropertyKey( instanceId, propertyKey );
		}


        /// <summary>
        /// Delete properties by page id and property type (such as 'CUST' or 'CONT').
        /// </summary>
        /// <param name="instanceId">Id of the page to affect.</param>
        /// <param name="propertyType">use a value from Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers</param>
        public static void DeleteControlPropertiesByInstanceAndPropertyType(int instanceId, string propertyType)
        {
            Logger.LogVerboseInformation("DeleteControlPropertiesByInstanceAndPropertyType()", string.Format("Instance: {0}, (propertyType)property Type: {1}", instanceId.ToString(), propertyType), EventIds._4061);
            ICustomPropertiesDataProvider.ControlProperties_DELETE_BYInstanceIDPropertyType(instanceId, propertyType);
        }


        public static void DeleteControlPropertiesByPropertyKeyAndPropertyValue(string propertyKey, string propertyValue)
        {
            Logger.LogVerboseInformation("DeleteControlPropertiesByPropertyKeyAndPropertyValue()", string.Format("propertyKey: {0}, propertyValue: {1}", propertyKey, propertyValue), EventIds._4058);
            ICustomPropertiesDataProvider.ControlProperties_DELETE_BYPropertyKeyAndPropertyValue(propertyKey, propertyValue);
        }
        
        public static void DeleteControlPropertiesByPropertyTypeAndPropertyValue(string propertyType, string propertyValue)
        {
            Logger.LogVerboseInformation("DeleteControlPropertiesByPropertyTypeAndPropertyValue()", string.Format("propertyType: {0}, (propertyValue: {1}", propertyType, propertyValue), EventIds._4059);
            ICustomPropertiesDataProvider.ControlProperties_DELETE_BYPropertyTypeAndPropertyValue(propertyType, propertyValue);
        }


        /// <summary>
        /// Saves a new property.
        /// </summary>
        /// <param name="controlPropertySaveNewInfo"></param>
        public static void SaveControlPropertyByInstance(SaveNewCustomPropertyInstanceInfo controlPropertySaveNewInfo)
		{
            SaveControlPropertyByInstance(controlPropertySaveNewInfo, false);
        }


        /// <summary>
        /// Saves a new property; If overwriting, this is based on InstanceId and PropertyKey.
        /// </summary>
        /// <param name="controlPropertySaveNewInfo"></param>
        /// <param name="overwriteExistingValues"></param>
        public static void SaveControlPropertyByInstance(SaveNewCustomPropertyInstanceInfo controlPropertySaveNewInfo, bool overwriteExistingValues)
        {
            if (overwriteExistingValues)
            {
                CustomPropertyInstanceInfoCollection existingValues = GetControlPropertiesByInstanceIDAndPropertyKey(controlPropertySaveNewInfo.InstanceID, controlPropertySaveNewInfo.PropertyKey);
                foreach (CustomPropertyInstanceInfo existingValue in existingValues)
                {
                    Logger.LogVerboseInformation("SaveControlPropertyByInstance() - deleting/overwriting this value.",
                        string.Format("{0}, {1}={2}", controlPropertySaveNewInfo.InstanceID.ToString(), controlPropertySaveNewInfo.PropertyKey, controlPropertySaveNewInfo.PropertyValue), 
                        Logging.EventIds._4064);
                    DeleteControlPropertiesByInstanceAndPropertyKey(existingValue.InstanceID, existingValue.PropertyKey);
                }
            }

			ICustomPropertiesDataProvider.ControlProperties_INSERT( controlPropertySaveNewInfo );
		}



        public static void SavePropertyValue(string propertyKey, string newValue)
        {
            SavePropertyValue(propertyKey, newValue, string.Empty);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyKey"></param>
        /// <param name="newValue"></param>
        /// <param name="pattern">not case-sensitive.</param>
        public static void SavePropertyValue(string propertyKey, string newValue, string pattern)
        {
            CustomPropertyInstanceInfo controlProperty;
            CustomPropertyInstanceInfoCollection propertiesAffected = GetControlPropertiesByPropertyKey(propertyKey);

            if (pattern.Equals(string.Empty))
            {
                for (int p = 0; p < propertiesAffected.Count; p++)
                {
                    controlProperty = (CustomPropertyInstanceInfo)propertiesAffected[p];

                    DeleteControlPropertiesByInstanceAndPropertyKey(controlProperty.InstanceID, propertyKey);

                    SaveControlPropertyByInstance(
                        new SaveNewCustomPropertyInstanceInfo(
                            controlProperty.InstanceID,
                            controlProperty.PropertyType,
                            controlProperty.PropertyKey,
                            newValue)
                    );                    
                }
            }
            else
            {
                for (int p = 0; p < propertiesAffected.Count; p++)
                {
                    controlProperty = (CustomPropertyInstanceInfo)propertiesAffected[p];

                    if (controlProperty.PropertyValue.Equals(pattern,StringComparison.CurrentCultureIgnoreCase))
                    {
                        DeleteControlPropertiesByInstanceAndPropertyKey(controlProperty.InstanceID, propertyKey);

                        SaveControlPropertyByInstance(
                            new SaveNewCustomPropertyInstanceInfo(
                                controlProperty.InstanceID,
                                controlProperty.PropertyType,
                                controlProperty.PropertyKey,
                                newValue)
                        );
                    }
                }

            }
        }




        public static void CopySettings(int sourcePageId, string[] targetPageIds)
        {
            for (int i = 0; i < targetPageIds.Length; i++)
            {
                int targetPageId = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                try
                {
                    targetPageId = int.Parse(targetPageIds[i].ToString());
                }
                catch
                {
                    Logging.Logger.LogWarning("CustomPropertyHelper.CopySettings() - could not copy to target id.", 
                        string.Format("Could not parse target id '{0}' to an int.", targetPageIds[i].ToString()),
                        Logging.EventIds._4065);
                }

                if (targetPageId > Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                {
                    CopySettings(sourcePageId, targetPageId);
                }
            }
        }




        public static void CopySettings(int sourcePageId, int targetPageId)
        {
            Logging.Logger.LogVerboseInformation("CustomPropertyHelper.CopySettings() invoked.", string.Format("Source Id: {0}, Target Id: {1}", sourcePageId, targetPageId), Logging.EventIds._4066);

            try
            {
                CustomPropertyInstanceInfo property;
                CustomPropertyInstanceInfoCollection sourceProperties = StaticCustomPropertyHelper.GetControlPropertiesByInstanceID(sourcePageId);
                CustomPropertyInstanceInfoCollection existingTargetProperties = StaticCustomPropertyHelper.GetControlPropertiesByInstanceID(targetPageId);
                SaveNewCustomPropertyInstanceInfo saveInfo;
                Morphfolia.Common.ControlPropertyType customType = Morphfolia.Common.ControlPropertyTypeFactory.CustomPropertyType();


                for (int p = 0; p < existingTargetProperties.Count; p++)
                {
                    property = (CustomPropertyInstanceInfo)existingTargetProperties[p];
                    if (property.PropertyType.PropertyTypeIdentifier.Equals(customType.PropertyTypeIdentifier))
                    {
                        DeleteControlPropertiesByInstanceAndPropertyKey(targetPageId, property.PropertyKey);
                    }
                }


                for (int p = 0; p < sourceProperties.Count; p++)
                {
                    property = (CustomPropertyInstanceInfo)sourceProperties[p];
                    // Only copy custom properties, not content links/bindings.
                    if (property.PropertyType.PropertyTypeIdentifier.Equals(customType.PropertyTypeIdentifier))
                    {
                        saveInfo = new SaveNewCustomPropertyInstanceInfo(
                            targetPageId,
                            property.PropertyType,
                            property.PropertyKey,
                            property.PropertyValue);

                        StaticCustomPropertyHelper.SaveControlPropertyByInstance(saveInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.Logger.LogException("CustomPropertyHelper.CopySettings() failed.", ex, Logging.EventIds._4066);
            }
            
        }
	}
}