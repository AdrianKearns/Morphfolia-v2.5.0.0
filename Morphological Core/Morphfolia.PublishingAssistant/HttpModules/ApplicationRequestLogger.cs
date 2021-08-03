// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web;
using Morphfolia.Common.Utilities;

namespace Morphfolia.PublishingSystem.HttpModules
{
    /// <summary>
    /// Summary description for ApplicationRequestLogger
    /// </summary>
    public class ApplicationRequestLogger : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(LogCurrentRequest);            
        }

        private void LogCurrentRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext httpContext = application.Context;

            if (ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.LogHttpRequestsUniversally) == "true")
            {
                Morphfolia.Business.Logs.HttpLogger.LogRequest(httpContext);
            }
        }
    }
}