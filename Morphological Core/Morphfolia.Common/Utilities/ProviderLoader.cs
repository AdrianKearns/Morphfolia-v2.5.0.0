// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Reflection;
using Morphfolia.Common.Exceptions;
using Morphfolia.Common.Logging;

namespace Morphfolia.Common.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class ProviderLoader
    {
        public static object CreateInstanceFromConfig(string fullTypeNameConfigKey)
        {
            string fullTypeName = ConfigHelper.GetAppSetting(fullTypeNameConfigKey);

            if (fullTypeName == null)
            {
                throw new ProviderLoaderException(string.Format("fullTypeName == null.  The value of the configKey '{0}' cannot be located.", fullTypeNameConfigKey));
            }

            if (fullTypeName.Equals(String.Empty))
            {
                throw new ProviderLoaderException(string.Format("fullTypeName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", fullTypeNameConfigKey));
            }

            return CreateInstance(fullTypeName);
        }


        public static object CreateInstanceFromConfig(string typeConfigKey, string assemblyConfigKey)
        {
            string typeName = ConfigHelper.GetAppSetting(typeConfigKey);
            string assemblyName = ConfigHelper.GetAppSetting(assemblyConfigKey);

            if (typeName == null)
            {
                throw new ProviderLoaderException(string.Format("typeName == null.  The value of the configKey '{0}' cannot be located.", typeConfigKey));
            }

            if (typeName.Equals(String.Empty))
            {
                throw new ProviderLoaderException(string.Format("typeName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", typeConfigKey));
            }

            if (assemblyName == null)
            {
                throw new ProviderLoaderException(string.Format("assemblyName == null.  The value of the configKey '{0}' cannot be located.", assemblyConfigKey));
            }

            if (assemblyName.Equals(String.Empty))
            {
                throw new ProviderLoaderException(string.Format("assemblyName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", assemblyConfigKey));
            }

            return CreateInstance(typeName, assemblyName);
        }


        /// <summary>
        /// Returns an object of the passed in type.
        /// </summary>
        /// <param name="typeName">The type to create an instance of.</param>
        /// <param name="assemblyName">The assembly in which the type exists.</param>
        /// <returns>object</returns>
        public static object CreateInstance(string typeName, string assemblyName)
        {
            return CreateInstance(string.Format("{0},{1}", typeName, assemblyName));
        }


        /// <summary>
        /// Returns an object of the passed in type.
        /// </summary>
        /// <param name="fullTypeName">The type to create an instance of, and the assembly in which the type exists.  
        /// The correct calling format is: "FullTypeName, AssemblyName</param>
        /// <returns>object</returns>
        public static object CreateInstance(string fullTypeName)
        {
            Type t;
            try
            {
                t = Type.GetType(fullTypeName, true);
            }
            catch (System.Exception ex)
            {
                throw new ProviderLoaderException(string.Format("t = Type.GetType(fullTypeName, true) failed.  fullTypeName = {0}", fullTypeName), ex);
            }

            try
            {
                return Activator.CreateInstance(t);
            }
            catch (System.Exception ex)
            {
                throw new ProviderLoaderException(string.Format("Activator.CreateInstance(t) failed.  fullTypeName = {0}", fullTypeName), ex);
            }
        }


        public static Assembly GetAssemblyFromConfig(string typeConfigKey, string assemblyConfigKey)
        {
            string typeName = ConfigHelper.GetAppSetting(typeConfigKey);
            string assemblyName = ConfigHelper.GetAppSetting(assemblyConfigKey);
            string fullTypeName = string.Empty;


            if (typeName == null)
            {
                throw new ProviderLoaderException(string.Format("typeName == null.  The value of the configKey '{0}' cannot be located.", typeConfigKey));
            }

            if (typeName.Equals(String.Empty))
            {
                throw new ProviderLoaderException(string.Format("typeName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", typeConfigKey));
            }



            if (assemblyName == null)
            {
                throw new ProviderLoaderException(string.Format("assemblyName == null.  The value of the configKey '{0}' cannot be located.", assemblyConfigKey));
            }

            if (assemblyName.Equals(String.Empty))
            {
                throw new ProviderLoaderException(string.Format("assemblyName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", assemblyConfigKey));
            }


            fullTypeName = string.Format("{0}, {1}", typeName, assemblyName);



            Type t;
            try
            {
                t = Type.GetType(fullTypeName, true);
            }
            catch (System.Exception ex)
            {
                Logger.LogException("GetType() failed.", ex, EventIds.Utilities._900);

                throw new ProviderLoaderException(string.Format("t = Type.GetType(fullTypeName, true) failed.  fullTypeName = {0}", fullTypeName), ex);
            }


            try
            {
                Assembly assebly = Assembly.GetAssembly(t);
                return assebly;
            }
            catch
            {
                throw;
            }
        }


        public static Assembly GetAssemblyFromConfig(string fullTypeNameConfigKey)
        {
            string typeName = ConfigHelper.GetAppSetting(fullTypeNameConfigKey);

            if (typeName == null)
            {
                throw new ProviderLoaderException(string.Format("typeName == null.  The value of the configKey '{0}' cannot be located.", fullTypeNameConfigKey));
            }

            if (typeName.Equals(String.Empty))
            {
                throw new ProviderLoaderException(string.Format("typeName.Equals(String.Empty).  The value of the configKey '{0}' is empty.", fullTypeNameConfigKey));
            }


            Type t;
            try
            {
                t = Type.GetType(typeName, true);
            }
            catch (System.Exception ex)
            {
                throw new ProviderLoaderException(string.Format("t = Type.GetType(typeName, true) failed.  typeName = {0}", typeName), ex);
            }


            try
            {
                Assembly assebly = Assembly.GetAssembly(t);
                return assebly;
            }
            catch
            {
                throw;
            }
        }
    }
}