// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Business.Constants;
using Morphfolia.IDataProvider;

namespace Morphfolia.Business.Diagnostics
{
    public class DataProviderInformation
    {
        private static IDataProviderInformation iDataProviderInformation = null;

        internal static IDataProviderInformation IDataProviderInformation
        {
            get
            {
                if (iDataProviderInformation == null)
                {
                    iDataProviderInformation = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IDataProviderInformation) as IDataProviderInformation;
                }
                return iDataProviderInformation;
            }
        }



        public static string GetUsageSummary()
        {
            return IDataProviderInformation.GetUsageSummary();
        }
    }
}
