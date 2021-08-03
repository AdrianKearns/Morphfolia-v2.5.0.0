// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Collections.Specialized;
using System.Web;
using System.IO;
using Morphfolia.Common.Attributes;
using Morphfolia.Business;
using Morphfolia.Business.Logs;
using Morphfolia.PublishingSystem.Logging;
using Microsoft.Security.Application;


namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// Logs the request of files (typically those not handled by the asp.net pipeline) then serves them.
	/// </summary>
    /// <remarks>
    /// Uses the Microsoft AntiXSS library to sanitize data. 
    /// Only the file name is returned, the BinaryFileInterceptor HttpHandler 
    /// must be called within the correct directory.
    /// </remarks>
    /// <example>
    /// The BinaryFileInterceptor HttpHandler must be called within the correct directory, e.g: 
    /// if the target file is: "/downloads/setup.zip"
    /// the URL users are supplied should be: "/downloads/BinaryFileInterceptor.ashx?FileName=setup.zip" 
    /// and not: "BinaryFileInterceptor.ashx?FileName=/downloads/setup.zip"
    /// </example>
    [IsHttpHandler("Allows clients to access files within the specified directory, and records the HttpRequest on the HttpLogs.")]
    public class BinaryFileInterceptor : IHttpHandler
	{
        [IsHttpHandlerParameter("FileName", "A file name.")]
        public static readonly string FileNameKey = "FileName";

		public void ProcessRequest( HttpContext httpContext )
		{
            httpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            httpContext.Response.Cache.SetNoStore();
            httpContext.Response.Cache.SetExpires(System.DateTime.MinValue);
      
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PublishingSystem, TraceGuids._3060))
            {
                try
                {
                    string requestedFileName = WebUtilities.GetRequestParamValue(FileNameKey);
                    string parsedFileName = AntiXss.UrlEncode(requestedFileName).ToUpperInvariant();
                    parsedFileName = parsedFileName.Replace("%2F", " ");
                    parsedFileName = parsedFileName.Replace("%5C", " ");
                    
                    string[] fileNameBits = parsedFileName.Split(char.Parse(" "));
                    parsedFileName = fileNameBits[fileNameBits.Length-1];

                    if (!parsedFileName.Equals(string.Empty))
                    {
                        Logger.LogInformation("BinaryFileInterceptor", string.Format("Requested File: {0}  Parsed File name: {1}", requestedFileName, parsedFileName), 555);
                        HttpLogger.LogRequest(httpContext, string.Format("Requested File: {0}  Parsed File name: {1}", requestedFileName, parsedFileName));
                        httpContext.Response.Redirect(parsedFileName, false);
                    }                    
                }
                catch (System.Exception ex)
                {
                    httpContext.Response.StatusCode = 500;
                    Logger.LogException("BinaryFileInterceptor Failed.", ex, 555);
                }
            }
		}

		public bool IsReusable
		{
			get{ return false; }
		}
	}
}