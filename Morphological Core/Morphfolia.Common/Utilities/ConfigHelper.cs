// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using Morphfolia.Common.Logging;

namespace Morphfolia.Common.Utilities
{
	/// <summary>
	/// Summary description for ConfigHelper.
	/// </summary>
	public class ConfigHelper
	{
        /// <summary>
        /// Gets an AppSetting via System.Configuration.ConfigurationManager.AppSettings.
        /// </summary>
        /// <remarks>Wraps the call with logging and ensures that a null value is never returned.</remarks>
        /// <param name="ConfigKey"></param>
        /// <returns></returns>
        public static string GetAppSetting(string ConfigKey)
        {
            return GetAppSetting(ConfigKey, string.Empty);
        }

        /// <summary>
        /// Gets an AppSetting via System.Configuration.ConfigurationManager.AppSettings.
        /// </summary>
        /// <remarks>Wraps the call with logging and ensures that a null value is never returned.</remarks>
        /// <param name="ConfigKey"></param>
        /// <param name="ValueIfEmpty"></param>
        /// <returns></returns>
		public static string GetAppSetting( string ConfigKey, string ValueIfEmpty )
		{
            if (ConfigKey.Equals(string.Empty))
            {
                throw new ApplicationException("Error in ConfigHelper.GetMyConfigSetting(); ConfigKey must not be empty.");
            }

            string ConfigValue = string.Empty;
            ConfigValue = System.Configuration.ConfigurationManager.AppSettings[ConfigKey];

            if (ConfigValue == null)
			{
				//throw new ApplicationException("test");
				//ERROR wen config does not have the setting
				//ExceptionManager.Publish(new ApplicationException(string.Format("No value for \"{0}\" in web config file",ConfigKey)), "");
				//ExceptionManager.Publish(new ApplicationException(string.Format("No value for \"{0}\" in web config file", ConfigKey)));

                Logger.LogWarning("AppSetting not found.", string.Format("No value for \"{0}\" in web config file", ConfigKey), Logging.EventIds.ConfigHelper._202);

                ConfigValue = string.Empty; //TODO : This is actually an error : Key does not exist so it will probabally cause further errors down the track, or cause a display not to be configured correctly.
			}

            if (ConfigValue.Equals(string.Empty))
            {
                ConfigValue = ValueIfEmpty;
            }

			return ConfigValue;
		}

        public static string AppSettingsReport()
		{
			string output = "";
            string[] keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;

			foreach(string key in keys)
			{
                output = output + string.Format("{1} ={0}{2}{0}{0}", Environment.NewLine, key, System.Configuration.ConfigurationManager.AppSettings[key].ToString());
			}
			return output;
		}

        public static NameValueCollection AppSettings()
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
            string[] keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
			foreach(string key in keys)
			{
                nameValueCollection.Add(key, System.Configuration.ConfigurationManager.AppSettings[key].ToString());
			}
			return nameValueCollection;
		}

        public static NameValueCollection AppSettings(string keyStartsWithThisText)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
            string[] keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
			foreach(string key in keys)
			{
				if(key.StartsWith(keyStartsWithThisText))
				{
                    nameValueCollection.Add(key, System.Configuration.ConfigurationManager.AppSettings[key].ToString());
				}
			}
			return nameValueCollection;
		}

        public static NameValueCollection AppSettings(string keyStartsWithThisText, string keyEndsWithThisText)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
            string[] keys = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
			foreach(string key in keys)
			{
				if((key.StartsWith(keyStartsWithThisText))&&(key.EndsWith(keyEndsWithThisText)))
				{
					nameValueCollection.Add(key, System.Configuration.ConfigurationManager.AppSettings[key].ToString());
				}
			}
			return nameValueCollection;
		}
	}
}

