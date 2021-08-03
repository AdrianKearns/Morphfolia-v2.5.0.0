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

namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// Provides read-only access to various diagnostic information.
	/// </summary>
    /// <remarks>Access to this resource should be controlled via config. 
    /// It could be restricted to admin access only by referencing as being
    /// in the _Publishing folder, however, it will require login to access - 
    /// which may not be available if something has gone really wrong). 
    /// Make publicly accessible to be run anywhere.</remarks>
    [IsHttpHandler("Provides read-only access to various diagnostic information")]
    public class Diagnostics : IHttpHandler
	{
        private enum Queries { DataProviderUsage }

        [IsHttpHandlerParameter("query", "DataProviderUsage", "More options may be provided overtime.")]
        public static readonly string DiagnosticQuery = "query";

		public void ProcessRequest( HttpContext httpContext )
		{
            httpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            httpContext.Response.Cache.SetNoStore();
            httpContext.Response.Cache.SetExpires(System.DateTime.MinValue);
                 
            using (Microsoft.Practices.EnterpriseLibrary.Logging.Tracer traceDefaultHandlerProcessRequest = new Microsoft.Practices.EnterpriseLibrary.Logging.Tracer(Morphfolia.Common.Logging.Categories.PublishingSystem, TraceGuids._3060))
            {
                try
                {
                    Queries currentQuery;
                    string query = WebUtilities.GetRequestParamValue(DiagnosticQuery);

                    if (!query.Equals(string.Empty))
                    {
                        //Logger.LogVerboseInformation("BinaryFileInterceptor [31]", string.Format("physicalPath={0}", physicalPath), 555);
                        HttpLogger.LogRequest(httpContext, string.Format("Requested query: {0}", query));

                        currentQuery = (Queries)System.Enum.Parse(typeof(Queries), query, true);

                        switch (currentQuery)
                        {
                            case Queries.DataProviderUsage:
                                httpContext.Response.Write(Morphfolia.Business.Diagnostics.DataProviderInformation.GetUsageSummary());
                                break;
                                    
                            default:
                                httpContext.Response.Write(string.Format("Please supply a 'query', permitted queries are: {0}", Queries.DataProviderUsage));
                                break;
                        }
                    }
                    else
                    {
                        HttpLogger.LogRequest(httpContext, "No query specified");
                        httpContext.Response.Write( string.Format("Please supply a 'query', permitted queries are: {0}", Queries.DataProviderUsage) );
                    }
                }
                catch (System.Exception ex)
                {
                    httpContext.Response.StatusCode = 500;
                    Logger.LogException("Diagnostics HttpHandler Failed.", ex, 555);
                }
            }
		}

		public bool IsReusable
		{
			get{ return false; }
		}
	}
}