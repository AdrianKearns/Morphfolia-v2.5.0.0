// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Reflection;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized; 
using Morphfolia.Common.Logging;


namespace Morphfolia.Business.Helpers
{
	/// <summary>
	/// Summary description for ProviderLoader.
	/// </summary>
	public class ProviderLoader
	{
		public static object Load( string configKey )
		{
			try
			{
                return Morphfolia.Common.Utilities.ProviderLoader.CreateInstanceFromConfig(configKey);
			}
			catch
			{
				throw;
			}
		}


        public static object Load(string typeConfigKey, string assemblyConfigKey)
        {
            try
            {
                object o = Morphfolia.Common.Utilities.ProviderLoader.CreateInstanceFromConfig(typeConfigKey, assemblyConfigKey);
                return o;
            }
            catch
            {
                throw;
            }
        }
	}
}
