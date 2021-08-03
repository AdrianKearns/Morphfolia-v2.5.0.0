// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Reflection;
using System.Collections.Specialized;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;
using Morphfolia.PageLayoutAndSkinAssistant.Exceptions;
using Morphfolia.PageLayoutAndSkinAssistant.Logging;
using Morphfolia.Common;
using Morphfolia.Common.Interfaces;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Utilities;

namespace Morphfolia.PageLayoutAndSkinAssistant
{
    /// <summary>
    /// Summary description for Helper.
    /// </summary>
    public class WebLayoutControlHelper
    {
        public static ISkinProvider GetDefaultSkinProvider()
        {
            string fullTypeName = ConfigHelper.GetAppSetting(AppSettingKeys.DefaultISkinProvider);
            //string assemblyName = ConfigHelper.GetAppSetting(AppSettingKeys.LayoutProviderAssembly);
            //string fullTypeName = string.Empty;

            if (fullTypeName == null)
            {
                throw new WebLayoutTemplateHelperException(string.Format("fullTypeName == null.  The value of the configKey '{0}' cannot be located.", AppSettingKeys.DefaultLayout));
            }

            if (fullTypeName.Equals(String.Empty))
            {
                throw new WebLayoutTemplateHelperException(string.Format("fullTypeName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", AppSettingKeys.DefaultLayout));
            }

            //if (assemblyName == null)
            //{
            //    throw new WebLayoutTemplateHelperException(string.Format("assemblyName == null.  The value of the configKey '{0}' cannot be located.", AppSettingKeys.LayoutProviderAssembly));
            //}

            //if (assemblyName.Equals(String.Empty))
            //{
            //    throw new WebLayoutTemplateHelperException(string.Format("assemblyName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", AppSettingKeys.LayoutProviderAssembly));
            //}


            //fullTypeName = string.Format("{0}, {1}", typeName, assemblyName);

            return (ISkinProvider)Morphfolia.Common.Utilities.ProviderLoader.CreateInstance(fullTypeName);
        }
        public static BasePageLayout GetDefaultLayout()
        {
            string fullTypeName = ConfigHelper.GetAppSetting(AppSettingKeys.DefaultLayout);
            //string assemblyName = ConfigHelper.GetAppSetting(AppSettingKeys.LayoutProviderAssembly);
            //string fullTypeName = string.Empty;

            if (fullTypeName == null)
            {
                throw new WebLayoutTemplateHelperException(string.Format("fullTypeName == null.  The value of the configKey '{0}' cannot be located.", AppSettingKeys.DefaultLayout));
            }

            if (fullTypeName.Equals(String.Empty))
            {
                throw new WebLayoutTemplateHelperException(string.Format("fullTypeName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", AppSettingKeys.DefaultLayout));
            }

            //if (assemblyName == null)
            //{
            //    throw new WebLayoutTemplateHelperException(string.Format("assemblyName == null.  The value of the configKey '{0}' cannot be located.", AppSettingKeys.LayoutProviderAssembly));
            //}

            //if (assemblyName.Equals(String.Empty))
            //{
            //    throw new WebLayoutTemplateHelperException(string.Format("assemblyName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", AppSettingKeys.LayoutProviderAssembly));
            //}


            //fullTypeName = string.Format("{0}, {1}", typeName, assemblyName);

            return (BasePageLayout)Morphfolia.Common.Utilities.ProviderLoader.CreateInstance(fullTypeName);
        }
        private static Assembly asm;
        public static Assembly CurrentAssembly
        {
            get
            {
                if (asm == null)
                {
                    string fullTypeName = ConfigHelper.GetAppSetting(AppSettingKeys.DefaultLayout);


                    Logger.LogVerboseInformation("WebLayoutControlHelper: Setting CurrentAssembly.", string.Format("fullTypeName: {0}", fullTypeName), Morphfolia.Common.Logging.EventIds.Default.Information);


                    if (fullTypeName == null)
                    {
                        throw new WebLayoutTemplateHelperException(string.Format("fullTypeName == null.  The value of the configKey '{0}' cannot be located.", AppSettingKeys.DefaultLayout));
                    }

                    if (fullTypeName.Equals(String.Empty))
                    {
                        throw new WebLayoutTemplateHelperException(string.Format("fullTypeName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", AppSettingKeys.DefaultLayout));
                    }

                    Type t = Type.GetType(fullTypeName, true);

                    asm = Assembly.GetAssembly(t);
                }
                return asm;
            }
        }


        private static Type currentType;
        private static string currentTypeAsString = string.Empty;
        public static Type GetCurrentType(string typeToInterogate)
        {
            if (!currentTypeAsString.Equals(typeToInterogate))
            {
                currentType = null;
            }

            if (currentType == null)
            {
                if (typeToInterogate == null)
                {
                    throw new TypeLoadException("GetCurrentType() failed, typeToInterogate was null.");
                }

                if (typeToInterogate.Equals(String.Empty))
                {
                    throw new TypeLoadException("GetCurrentType() failed, typeToInterogate was empty.");
                }

                try
                {
                    currentType = CurrentAssembly.GetType(typeToInterogate, true, true);
                    currentTypeAsString = typeToInterogate;
                }
                catch (TypeLoadException tlex)
                {
                    Logger.LogException("GetCurrentType() failed, TypeLoadException.", tlex, EventIds._3521);
                    currentType = null;
                }
                catch (Exception ex)
                {
                    Logger.LogException("GetCurrentType() failed, general exception.", ex, EventIds._3521);
                    currentType = null;
                }
            }
            return currentType;
        }


        /// <summary>
        /// Gets the assembilies in the current AppDomain, as well as any additional ones via 
        /// the 'Morphfolia.LayoutTemplateAssembilies' appSetting.
        /// </summary>
        /// <returns>A collection of Assembilies.</returns>
        internal static AssemblyCollection GetAssemblies()
        {
            return GetAssemblies(string.Empty);
        }


        /// <summary>
        /// Gets the assembilies in the current AppDomain, as well as any additional ones via 
        /// the 'Morphfolia.LayoutTemplateAssembilies' appSetting.  This overload will allow 
        /// you to filter the assembilies returned via the assemblyNameFilter parameter.
        /// </summary>
        /// <param name="assemblyNameFilter">Filters the assmebilies returned, only assembly names 
        /// begining with the prefix are returned.</param>
        /// <returns>A collection of Assembilies.</returns>
        internal static AssemblyCollection GetAssemblies(string assemblyNameFilter)
        {
            string currentAssemblyName;
            AppDomain currentDomain = AppDomain.CurrentDomain;


            AssemblyCollection outputCollectionOfAssembilies = new AssemblyCollection();
            Assembly[] tempArrayOfAssembilies = currentDomain.GetAssemblies();
            

            if (assemblyNameFilter.Equals(string.Empty))
            {
                foreach (Assembly currentAssembly in tempArrayOfAssembilies)
                {
                    outputCollectionOfAssembilies.Add(currentAssembly);
                }
            }
            else
            {
                foreach (Assembly currentAssembly in tempArrayOfAssembilies)
                {
                    currentAssemblyName = currentAssembly.GetName(false).Name;
                    if (
                        (currentAssemblyName.StartsWith("App_")) |
                        (currentAssemblyName.StartsWith(assemblyNameFilter))
                        )
                    {
                        outputCollectionOfAssembilies.Add(currentAssembly);
                    }
                }
            }

            return outputCollectionOfAssembilies;
        }


        /// <summary>
        /// Supplies a list of the Web Layout Controls available within the assemblies available.
        /// </summary>
        /// <returns>StringCollection of types,each containing the fully qualified name of the Type, 
        /// e.g: Morphological.Kudos.Layouts.SimplePageLayout, Morphological.Kudos, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null</returns>
        public static StringCollection GetAvailableLayoutWebControls()
        {
            return GetAvailableThings(IsLayoutWebControl.AttributeIdentifier);
        }


        /// <summary>
        /// Supplies a list of the Web Layout Controls available within the assemblies available.
        /// </summary>
        /// <returns>StringCollection of types,each containing the fully qualified name of the Type, 
        /// e.g: Morphological.Kudos.Layouts.SimplePageLayout, Morphological.Kudos, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null</returns>
        private static StringCollection GetAvailableThings(string attributeIdentifier)
        {
            Type[] types;
            Type type;
            object[] customAttributes;
            StringCollection availableThings = new StringCollection();
            AssemblyCollection outputCollectionOfAssembilies = GetAssemblies();

            foreach (Assembly currentAssembly in outputCollectionOfAssembilies)
            {
                try
                {
                    //Logger.LogVerboseInformation("GetAvailableThings - currentAssembly", currentAssembly.FullName);
                    types = currentAssembly.GetTypes();

                    for (int i = 0; i < types.Length; i++)
                    {
                        type = types[i];
                        customAttributes = type.GetCustomAttributes(false);

                        for (int a = 0; a < customAttributes.Length; a++)
                        {
                            if (customAttributes[a].ToString().EndsWith(attributeIdentifier))
                            {
                                availableThings.Add(type.AssemblyQualifiedName);
                            }
                        }
                    }
                }
                catch (System.Reflection.ReflectionTypeLoadException rtlex)
                {
                    Logger.LogException("GetAvailableThings() failed, classes in the module cannot be loaded.  Ensure all assembly dependancies share the same version of core DLLs, such as licence keys use of Morphfolia.Common.", rtlex, Logging.EventIds._3520);
                    Logger.LogException("GetAvailableThings() - currentAssembly", currentAssembly.FullName, Logging.EventIds._3520);
                    throw;
                }
                catch (Exception ex)
                {
                    Logger.LogException("GetAvailableThings() failed.", ex, Logging.EventIds._3520);
                    Logger.LogException("GetAvailableThings() - currentAssembly", currentAssembly.FullName, Logging.EventIds._3520);
                    throw;
                }
            }

            return availableThings;
        }


        /// <summary>
        /// Supplies a list of the skin providers available within the assembly.
        /// </summary>
        /// <returns>StringCollection containing the fully qualified name of the System.Type, including the namespace of the System.Type.</returns>
        public static StringCollection GetAvailableSkinProviders()
        {
            return GetAvailableThings(IsSkinProvider.AttributeIdentifier);
        }


        /// <summary>
        /// Gets the public properties of the control that are valid ContentContainer.
        /// </summary>
        /// <param name="typeToInterogate">The System.Type (as a string) of the type to analyze.</param>
        /// <returns>StringCollection of the Properties.</returns>
        public static Morphfolia.Common.Info.ContentContainerInfoCollection GetAvailableContentContainerProperties(string typeToInterogate)
        {
            PropertyInfo[] properties;
            string containerName = string.Empty;
            string containerColour = string.Empty;
            string containerDescription = string.Empty;
            object[] customAttributes;
            Morphfolia.Common.Info.ContentContainerInfo item;
            Morphfolia.Common.Info.ContentContainerInfoCollection collection = new Morphfolia.Common.Info.ContentContainerInfoCollection();


            if (typeToInterogate.Equals(String.Empty))
            {
                return collection;
            }

            if (typeToInterogate.Equals(Morphfolia.Common.Constants.Framework.Various.PleaseSelect))
            {
                return collection;
            }

            if (typeToInterogate.Equals(Morphfolia.Common.Constants.Framework.Various.NoneAvailable))
            {
                return collection;
            }

            Type type;
            try
            {
                type = Type.GetType(typeToInterogate, true);
            }
            catch (Exception ex)
            {
                Logger.LogException("Could not load type.", ex, 666, string.Format("Attempted to load this type: '{0}'", typeToInterogate));
                type = null;
            }


            if (type != null)
            {
                properties = type.GetProperties();

                for (int a = 0; a < properties.Length; a++)
                {
                    containerName = string.Empty;
                    containerColour = string.Empty;
                    containerDescription = string.Empty;

                    customAttributes = properties[a].GetCustomAttributes(false);

                    if (customAttributes.Length > 0)
                    {
                        for (int i = 0; i < customAttributes.Length; i++)
                        {
                            if (customAttributes[i].ToString().EndsWith(IsContentContainer.AttributeIdentifier))
                            {
                                containerName = properties[a].Name;                             
                            }

                            if (customAttributes[i].ToString().EndsWith(ContentContainerColour.AttributeIdentifier))
                            {
                                ContentContainerColour contentContainerColour = (ContentContainerColour)customAttributes[i];
                                containerColour = contentContainerColour.Colour;
                            }

                            if (customAttributes[i].ToString().EndsWith(ContentContainerDescription.AttributeIdentifier))
                            {
                                ContentContainerDescription contentContainerDescription = (ContentContainerDescription)customAttributes[i];
                                containerDescription = contentContainerDescription.Description;
                            }
                        }
                    }

                    if (!containerName.Equals(String.Empty))
                    {
                        item = new Morphfolia.Common.Info.ContentContainerInfo(containerName, containerColour, containerDescription);
                        collection.Add(item);
                    }
                }
            }

            return collection;
        }


        /// <summary>
        /// Gets the public properties of the control that are valid ContentContainer.
        /// </summary>
        /// <param name="typeToInterogate">The System.Type (as a string) of the type to analyze.</param>
        /// <returns>StringCollection of the Properties.</returns>
        public static Morphfolia.Common.Info.CustomPropertyInfoCollection GetAvailableCustomPropertiesForType(string typeToInterogate)
        {
            Morphfolia.Common.Info.CustomPropertyInfoCollection customPropertyInfoCollection = new Morphfolia.Common.Info.CustomPropertyInfoCollection();
            Morphfolia.Common.Info.CustomPropertyInfo customPropertyInfo;


            if (typeToInterogate.Equals(String.Empty))
            {
                return customPropertyInfoCollection;
            }

            if (typeToInterogate.Equals(Morphfolia.Common.Constants.Framework.Various.PleaseSelect))
            {
                return customPropertyInfoCollection;
            }

            if (typeToInterogate.Equals(Morphfolia.Common.Constants.Framework.Various.NoneAvailable))
            {
                return customPropertyInfoCollection;
            }


            PropertyInfo[] properties;
            string property = string.Empty;

            object[] customAttributes;

            //wrap this into a property, which includes adaquate protection, as per above method.
            Type type = null;
            try
            {
                Logger.LogVerboseInformation("WebLayoutControlHelper.GetAvailableCustomPropertiesForType()", string.Format("typeToInterogate: {0}", typeToInterogate));
                type = Type.GetType(typeToInterogate, true);
            }
            catch (Exception ex)
            {
                Logger.LogException("WebLayoutControlHelper.GetAvailableCustomPropertiesForType() - GetType(typeToInterogate, true) failed.", ex, 666, string.Format("typeToInterogate: {0}", typeToInterogate));
            }


            if (type == null)
            {
            }
            else
            {
                StringCollection availableProperties = new StringCollection();

                customAttributes = type.GetCustomAttributes(false);
                properties = type.GetProperties();

                string propertyKey = string.Empty;
                string propertyValue = string.Empty;
                string propertyDefaultValue = string.Empty;
                string propertyName = string.Empty;
                string description = string.Empty;
                string suggestedUsage = string.Empty;
                Various.InputSizes inputSize;
                bool y = false;

                for (int a = 0; a < properties.Length; a++)
                {
                    customAttributes = properties[a].GetCustomAttributes(false);
                    if (customAttributes.Length > 0)
                    {
                        propertyKey = string.Empty;
                        propertyDefaultValue = string.Empty;
                        propertyValue = string.Empty;
                        propertyName = string.Empty;
                        description = string.Empty;
                        suggestedUsage = string.Empty;
                        inputSize = Various.InputSizes.SingleLine30x1;
                        y = false;

                        for (int i = 0; i < customAttributes.Length; i++)
                        {
                            if (customAttributes[i] is PropertyDescriptionAttribute)
                            {
                                PropertyDescriptionAttribute myAttribute = (PropertyDescriptionAttribute)customAttributes[i];
                                description = myAttribute.Description;
                            }

                            if (customAttributes[i] is PropertySuggestedUsageAttribute)
                            {
                                PropertySuggestedUsageAttribute myAttribute = (PropertySuggestedUsageAttribute)customAttributes[i];
                                suggestedUsage = myAttribute.SuggestedUsage;
                            }

                            if (customAttributes[i] is PropertyFriendlyNameAttribute)
                            {
                                PropertyFriendlyNameAttribute myAttribute = (PropertyFriendlyNameAttribute)customAttributes[i];
                                propertyName = myAttribute.FriendlyName;
                            }

                            if (customAttributes[i] is PropertyDefaultValueAttribute)
                            {
                                PropertyDefaultValueAttribute myAttribute = (PropertyDefaultValueAttribute)customAttributes[i];
                                propertyDefaultValue = myAttribute.DefaultValue;
                            }

                            if (customAttributes[i] is InputSizeAttribute)
                            {
                                InputSizeAttribute myAttribute = (InputSizeAttribute)customAttributes[i];
                                inputSize = myAttribute.InputSize;
                            }

                            if (customAttributes[i] is PropertyFriendlyNameAttribute)
                            {
                                y = true;
                            }
                        }

                        if (y)
                        {
                            customPropertyInfo = new Morphfolia.Common.Info.CustomPropertyInfo(
                                properties[a].Name,
                                string.Empty,
                                propertyDefaultValue,
                                propertyName,
                                description,
                                suggestedUsage,
                                inputSize);
                            customPropertyInfoCollection.Add(customPropertyInfo);
                        }
                    }

                    property = String.Empty;
                }
            }

            return customPropertyInfoCollection;
        }


        /// <summary>
        /// Gets the public properties of the control that are valid ContentContainer.
        /// </summary>
        /// <param name="typeToInterogate">The System.Type (as a string) of the type to analyze.</param>
        /// <returns>StringCollection of the Properties.</returns>
        public static StringCollection GetAvailableCustomProperties(string typeToInterogate)
        {
            if (typeToInterogate.Equals(String.Empty))
            {
                return new StringCollection();
            }

            if (typeToInterogate.Equals(Morphfolia.Common.Constants.Framework.Various.PleaseSelect))
            {
                return new StringCollection();
            }

            if (typeToInterogate.Equals(Morphfolia.Common.Constants.Framework.Various.NoneAvailable))
            {
                return new StringCollection();
            }



            PropertyInfo[] properties;
            string property = string.Empty;

            object[] customAttributes;
            StringCollection availableProperties = new StringCollection();

            Type type = Type.GetType(typeToInterogate, true);
            if (type == null)
            {
            }
            else
            {
                customAttributes = type.GetCustomAttributes(false);
                properties = type.GetProperties();


                for (int a = 0; a < properties.Length; a++)
                {
                    customAttributes = properties[a].GetCustomAttributes(false);
                    if (customAttributes.Length > 0)
                    {
                        for (int i = 0; i < customAttributes.Length; i++)
                        {
                            // Replace with a switch statement?
                            // Try and use the webcontrolassembly via an interface (loosely-coupled).
                            string ssss = string.Format("{0}|{1}", customAttributes[i].ToString(), IsCustomProperty.AttributeIdentifier);

                            if (customAttributes[i].ToString().EndsWith(IsCustomProperty.AttributeIdentifier))
                            {
                                property = customAttributes[i].ToString();
                                break;
                            }
                        }
                    }

                    if (!property.Equals(String.Empty))
                    {
                        availableProperties.Add(properties[a].Name);
                    }
                    property = String.Empty;
                }
            }

            return availableProperties;

        }
    }
}