// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web;
using Morphfolia.Business.Constants;


namespace Morphfolia.Business.Logs
{
    /// <summary>
    /// Summary description for HttpLogger
    /// </summary>
    public class HttpLogger
    {
        /// <summary>
        /// Extracts information from the HttpContext 
        /// and logs it.
        /// </summary>
        /// <param name="httpContext">The current HttpContext</param>
        public static void LogRequest(HttpContext httpContext)
        {
            LogRequest(httpContext, string.Empty);
        }


        /// <summary>
        /// Extracts information from the HttpContext 
        /// and logs it.
        /// </summary>
        /// <param name="httpContext">The current HttpContext</param>
        /// <param name="miscInfo">any additional information you wish to record.</param>
        public static void LogRequest(HttpContext httpContext, string miscInfo)  //, string urlToLog)
        {
            string sessionId = string.Empty;
            System.Web.SessionState.SessionIDManager sessionIDManager = new System.Web.SessionState.SessionIDManager();
            bool supportSessionIDReissue;
            sessionIDManager.InitializeRequest(httpContext, false, out supportSessionIDReissue);
            sessionId = sessionIDManager.GetSessionID(httpContext);
            if (sessionId == null)
            {
                sessionId = sessionIDManager.CreateSessionID(httpContext);
                bool redirected;
                bool cookieAdded;
                sessionIDManager.SaveSessionID(httpContext, sessionId, out redirected, out cookieAdded);

                if (miscInfo.Equals(string.Empty))
                {
                    miscInfo = string.Format("Browser: {0}", httpContext.Request.ServerVariables["HTTP_USER_AGENT"].ToString());
                }
                else
                {
                    miscInfo = string.Format("{0} Browser: {1}", miscInfo, httpContext.Request.ServerVariables["HTTP_USER_AGENT"].ToString());
                }
            }

            string UserHostName = httpContext.Request.UserHostName;

            //string urlToLog = string.Format("{0}://{1}{2}",
            //    httpContext.Request.Url.Scheme,
            //    httpContext.Request.Url.Host,
            //    httpContext.Request.Url.AbsolutePath);

            string UrlReferrer = string.Empty;
            if (httpContext.Request.UrlReferrer != null)
            {
                //UrlReferrer = string.Format("{0}://{1}{2}",
                //    httpContext.Request.UrlReferrer.Scheme,
                //    httpContext.Request.UrlReferrer.Host,
                //    httpContext.Request.UrlReferrer.AbsolutePath);
                UrlReferrer = httpContext.Request.UrlReferrer.AbsoluteUri;
            }


            Morphfolia.IDataProvider.IHttpLoggerDataProvider iHttpLoggerDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IHttpLoggerDataProvider) as Morphfolia.IDataProvider.IHttpLoggerDataProvider;
            iHttpLoggerDataProvider.HttpLog_INSERT(
                sessionId, 
                UserHostName,
                httpContext.Request.Url.AbsoluteUri,
                UrlReferrer,
                miscInfo);
        }
    }

}