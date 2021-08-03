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
    /// Provides access and management of CustomProperties, on an instance specific basis.
    /// </summary>
    public class CustomPropertyHelper
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

        private int instanceId;
        public int InstanceId
        {
            get { return instanceId; }
        }

        /// <summary>
        /// Used by method calls, not expected to hold values between method calls.
        /// </summary>
        private CustomPropertyInstanceInfoCollection tempCustomProperties = null;

        /// <summary>
        /// The currently available Custom Properties for the instance, but only available internally to the CustomPropertyHelper.
        /// </summary>
        private CustomPropertyInstanceInfoCollection customPropertiesWTF = null;

        /// <summary>
        /// All the currently available Custom Properties for the instance.
        /// </summary>
        public CustomPropertyInstanceInfoCollection CustomProperties
        {
            get
            {
                if (customPropertiesWTF == null)                
                {
                    Logger.LogVerboseInformation("CustomPropertyHelper.CustomProperties", string.Format("Getting properties afresh from storage., instanceId = {0}", InstanceId.ToString()), EventIds._4052);

                    customPropertiesWTF = ICustomPropertiesDataProvider.ControlProperties_SELECT_BYInstanceID(InstanceId);
                    return customPropertiesWTF;
                }
                else
                {
                    Logger.LogVerboseInformation("CustomPropertyHelper.CustomProperties", string.Format("Using in-memory copy of properties, instanceId = {0}", InstanceId.ToString()), EventIds._4052);

                    return customPropertiesWTF;
                }
            }
        }


        /// <summary>
        /// Removes all custom properties, leaving the CustomProperties null.
        /// </summary>
        public void ClearCustomProperties()
        {
            customPropertiesWTF = null;
        }

        public int CurrentCount
        {
            get
            {
                if (customPropertiesWTF == null)
                {
                    return Common.Constants.SystemTypeValues.NullInt;
                }
                else
                {
                    return customPropertiesWTF.Count;
                }
            }
        }

        public CustomPropertyHelper(int instanceId)
        {
            this.instanceId = instanceId;
        }



        /// <summary>
        /// Get all the Control Properties for the LayoutWebControl.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public CustomPropertyInstanceInfoCollection GetControlPropertiesByInstanceID(string propertyTypeIdentifier)
        {
            tempCustomProperties = new CustomPropertyInstanceInfoCollection();

            foreach (CustomPropertyInstanceInfo info in CustomProperties)
            {
                if (info.PropertyType.PropertyTypeIdentifier.Equals(propertyTypeIdentifier))
                {
                    tempCustomProperties.Add(info);
                }
            }

            return tempCustomProperties;
        }

        /// <summary>
        /// Get all the Control Properties for the LayoutWebControl.
        /// </summary>
        /// <param name="layoutWebControl"></param>
        /// <returns></returns>
        public IntCollection GetContentItemIdsByInstanceID()
        {
            //             return GetControlPropertiesByInstanceID(Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT);

            int contentId;
            IntCollection ids = new IntCollection();

            foreach (CustomPropertyInstanceInfo info in CustomProperties)
            {
                if (info.PropertyType.PropertyTypeIdentifier.Equals(Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT))
                {                   
                    if(int.TryParse(info.PropertyValue, out contentId))
                    {
                        ids.Add(contentId);
                    }
                }
            }

            return ids;
        }

        /// <summary>
        /// Get all the Control Properties for the LayoutWebControl, by Property Key.
        /// </summary>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
        public CustomPropertyInstanceInfoCollection GetControlPropertiesByInstanceIDAndPropertyKey(string propertyKey)
        {
            tempCustomProperties = new CustomPropertyInstanceInfoCollection();

            foreach (CustomPropertyInstanceInfo info in CustomProperties)
            {
                if (info.PropertyKey.Equals(propertyKey))
                {
                    tempCustomProperties.Add(info);
                }
            }

            return tempCustomProperties;
        }


        /// <summary>
        /// Get all the Control Properties for the LayoutWebControl, by Property Key.
        /// </summary>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
        public CustomPropertyInstanceInfoCollection GetControlPropertiesByInstanceIDAndPropertyKeyAndType(string propertyKey, string propertyTypeIdentifier)
        {
            tempCustomProperties = new CustomPropertyInstanceInfoCollection();

            foreach (CustomPropertyInstanceInfo info in CustomProperties)
            {
                if (info.PropertyType.PropertyTypeIdentifier.Equals(propertyTypeIdentifier))
                {
                    if (info.PropertyKey.Equals(propertyKey))
                    {
                        tempCustomProperties.Add(info);
                    }
                }
            }

            return tempCustomProperties;
        }



        /// <summary>
        /// Get all the Control Properties for the LayoutWebControl, by Property Key.
        /// </summary>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
        public CustomPropertyInstanceInfoCollection GetControlPropertiesByInstanceIDAndPropertyKeyAndTypeAndValue(string propertyKey, string propertyTypeIdentifier, string propertyValue)
        {
            tempCustomProperties = new CustomPropertyInstanceInfoCollection();

            foreach (CustomPropertyInstanceInfo info in CustomProperties)
            {
                if (info.PropertyType.PropertyTypeIdentifier.Equals(propertyTypeIdentifier))
                {
                    if (info.PropertyKey.Equals(propertyKey))
                    {
                        if (info.PropertyValue.Equals(propertyValue))
                        {
                            tempCustomProperties.Add(info);
                        }
                    }
                }
            }

            return tempCustomProperties;
        }



        /// <summary>
        /// This will return only the value of the last item found - it is expecting only one.
        /// </summary>
        /// <remarks>If more than one matching value is found only the last will be returned.  
        /// Which item is last will depend on the order in which they were retrieved.</remarks>
        /// <param name="propertyKey"></param>
        /// <returns></returns>
        public string GetCustomPropertyInstanceByInstanceID(string propertyKey)
        {
            try
            {
                tempCustomProperties = GetControlPropertiesByInstanceIDAndPropertyKey(propertyKey);

                if (tempCustomProperties.Count > 0)
                {
                    return tempCustomProperties[tempCustomProperties.Count - 1].PropertyValue;
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(
                    "GetCustomPropertyInstanceByInstanceID() failed.",
                    ex,
                    5451,
                    string.Format("instanceId = {0}, propertyKey = {1}", InstanceId.ToString(), propertyKey)
                    );
                return String.Empty;
            }
        }


        public string GetLayoutWebControlTypeByInstanceID()
        {
            return GetCustomPropertyInstanceByInstanceID(SpecialCustomPropertyKeys.LayoutWebControlType);
        }


        public string GetSkinProviderTypeByInstanceID()
        {
            return GetCustomPropertyInstanceByInstanceID(SpecialCustomPropertyKeys.SkinProviderType);
        }


        public string GetFormTemplatePresenterTypeByInstanceID()
        {
            string formTemplatePresenterType = GetCustomPropertyInstanceByInstanceID(SpecialCustomPropertyKeys.FormTemplatePresenterType);

            if (formTemplatePresenterType.Equals(string.Empty))
            {
                Logger.LogWarning(
                    "The specified FormTemplatePresenterType could not be found for this instance, use default instead.",
                    string.Format("Instance ID '{0}'", InstanceId.ToString()),
                    EventIds._4053);
            }

            return formTemplatePresenterType;
        }



        public void DeleteControlPropertiesByInstance()
        {
            Logger.LogVerboseInformation("DeleteControlPropertiesByInstance()", InstanceId.ToString(), EventIds._4050);

            ClearCustomProperties();

            //Auditor.LogAuditEntry(instanceId, AuditableObjects.CustomProperty, "DELETE - ByInstance");
            ICustomPropertiesDataProvider.ControlProperties_DELETE_BYInstanceID(InstanceId);
        }


        public void DeleteControlPropertiesByInstanceAndPropertyKey(string propertyKey)
        {
            Logger.LogVerboseInformation("DeleteControlPropertiesByInstanceAndPropertyKey()", string.Format("Instance: {0}, Property Key: {1}", InstanceId.ToString(), propertyKey), EventIds._4051);

            ClearCustomProperties();

            ICustomPropertiesDataProvider.ControlProperties_DELETE_BYInstanceIDPropertyKey(InstanceId, propertyKey);
        }


        /// <summary>
        /// Delete properties by page id and property type (such as 'CUST' or 'CONT').
        /// </summary>
        /// <param name="instanceId">Id of the page to affect.</param>
        /// <param name="propertyType">use a value from Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers</param>
        public void DeleteControlPropertiesByInstanceAndPropertyType(string propertyType)
        {
            Logger.LogVerboseInformation("DeleteControlPropertiesByInstanceAndPropertyType()", string.Format("Instance: {0}, (propertyType)property Type: {1}", InstanceId.ToString(), propertyType), EventIds._4052);

            ClearCustomProperties();

            ICustomPropertiesDataProvider.ControlProperties_DELETE_BYInstanceIDPropertyType(InstanceId, propertyType);
        }

    }
}