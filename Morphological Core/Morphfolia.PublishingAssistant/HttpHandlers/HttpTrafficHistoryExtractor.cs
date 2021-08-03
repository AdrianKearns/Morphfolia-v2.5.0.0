// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Collections.Specialized;
using System.Web;
using System.IO;
using Morphfolia.Business;
using Morphfolia.Business.Logs;
using Morphfolia.Common.Info;
using Morphfolia.PublishingSystem.Logging;
using Morphfolia.Common.Attributes;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// Logs the request of binary files, then serves them.
	/// </summary>
    [IsHttpHandler("Allows clients to get HttpLog data as comma delimited values.  Intended for use by admins.")]
    public class HttpTrafficHistoryExtractor : IHttpHandler
	{
        public class QueryStringKeys
        {
            [IsHttpHandlerParameter("RangeStart", "A date/time.")]
            public const string RangeStart = "RangeStart";

            [IsHttpHandlerParameter("RangeEnd", "A date/time.")]
            public const string RangeEnd = "RangeEnd";
        }


		public void ProcessRequest( HttpContext httpContext )
		{
            httpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            httpContext.Response.Cache.SetNoStore();
            httpContext.Response.Cache.SetExpires(System.DateTime.MinValue);



            //if (httpContext.Request.Url.AbsolutePath.EndsWith("csv"))
            //{
            //    httpContext.Response.ContentType = "application/vnd.ms-excel";
            //}
            //else
            //{
            //httpContext.Response.ContentType = "text/plain";
            //}


            string tempRangeStart = WebUtilities.GetRequestParamValue(QueryStringKeys.RangeStart);
            System.DateTime RangeStart;
            try
            {
                RangeStart = System.DateTime.Parse(tempRangeStart);
            }
            catch
            {
                RangeStart = System.DateTime.MinValue;
            }

            string tempRangeEnd = WebUtilities.GetRequestParamValue(QueryStringKeys.RangeEnd);
            System.DateTime RangeEnd;
            try
            {
                RangeEnd = System.DateTime.Parse(tempRangeEnd);
            }
            catch
            {
                RangeEnd = System.DateTime.MaxValue;
            }
                

            HttpLogEntryInfo item;
            HttpLogEntryInfoCollection collection = HttpLogs.GetHistory(RangeStart, RangeEnd);

            //LogId, SessionId, UserHostName, Url, UrlReferrer, TimeLogged, MiscInfo
            for (int i = 0; i < collection.Count; i++)
            {
                item = collection[i];
                httpContext.Response.Write(string.Format("{0},{1},{2},{3},{4},{5},{6}{7}",
                    item.LogId.ToString(),
                    item.SessionId,
                    item.UserHostName,
                    item.Url,
                    item.UrlReferrer,
                    item.TimeLogged.ToString(),
                    item.MiscInfo,
                    System.Environment.NewLine));

                httpContext.Response.Flush();
            }
		}

        public bool IsReusable
		{
			get{ return false; }
		}
	}
}