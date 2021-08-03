// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Reflection;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common;
using Morphfolia.Common.Info;
using Morphfolia.Common.BaseClasses;
using Morphfolia.PageLayoutAndSkinAssistant.Exceptions;
using Morphfolia.PageLayoutAndSkinAssistant.Logging;
using Morphfolia.Common.Utilities;

namespace Morphfolia.PageLayoutAndSkinAssistant
{
	/// <summary>
    /// Summary description for PageLayoutHelper.
    /// Should this be "BasePageLayoutHelper"?
	/// </summary>
	public class PageLayoutHelper
	{
        internal static BasePageLayout Load(string fullTypeName)
		{
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PageLayoutAndSkinAssistant, TraceGuids._3522))
            {
                try
                {
                    Type t = Type.GetType(fullTypeName, true);
                    BasePageLayout basePageLayout = (BasePageLayout)Activator.CreateInstance(t);
                    return basePageLayout;
                }
                catch (Exception ex)
                {
                    //NameValueCollection additionalInfo = new NameValueCollection();
                    //additionalInfo.Add("Error", "Could not build the specified template.");
                    //additionalInfo.Add("typeName", typeName);
                    //ExceptionManager.Publish(ex, EventIds.Temporary.PageLayoutHelper, additionalInfo);

                    Logger.LogException("Could not CreateInstance of the specified BasePageLayout.", ex, EventIds._3522, string.Format("fullTypeName = '{0}'", fullTypeName));


                    // Could not build the specified template, try 
                    // building the default one for the provided template assembly.
                    try
                    {
                        fullTypeName = ConfigHelper.GetAppSetting(AppSettingKeys.DefaultLayout);
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

                        Type t = Type.GetType(fullTypeName, true);
                        BasePageLayout basePageLayout = (BasePageLayout)Activator.CreateInstance(t);
                        return basePageLayout;
                    }
                    catch(Exception ex2)
                    {
                        Logging.Logger.LogException("BasePageLayout.Load() failed.", ex2, 666, string.Format("The fullTypeName passed in was: {0}", fullTypeName));
                        throw;
                    }
                }
            }
		}


        public static BasePageLayout ActivateBasePageLayoutInstance(int controlInstanceId)
        {
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PageLayoutAndSkinAssistant, TraceGuids._3523))
            {
                string fullTypeName = ConfigHelper.GetAppSetting(AppSettingKeys.DefaultLayout);
                //string assemblyName = ConfigHelper.GetAppSetting(AppSettingKeys.LayoutProviderAssembly);
               // string fullTypeName = string.Empty;

                //fullTypeName = string.Format("{0}, {1}", typeName, assemblyName);

                BasePageLayout pageLayout = Load(fullTypeName);
                pageLayout.PageInstanceId = controlInstanceId;
                return pageLayout;
            }
        }


        public static BasePageLayout ActivateBasePageLayoutInstance(string fullTypeName, int controlInstanceId)
		{
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PageLayoutAndSkinAssistant, TraceGuids._3523))
            {
                BasePageLayout pageLayout = Load(fullTypeName);
                pageLayout.PageInstanceId = controlInstanceId;
                return pageLayout;
            }
		}
	}
}