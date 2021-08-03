// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using Morphfolia.Common.Info;

namespace Morphfolia.IDataProvider
{
    public interface IHttpLoggerDataProvider
    {
        void HttpLog_INSERT(string sessionId, string UserHostName, string Url, string UrlReferrer, string miscInfo);

        HttpSessionListInfoCollection HttpLog_SELECT_ActiveSessionsByDate(DateTime date);
        HttpSessionListInfoCollection HttpLog_SELECT_ActiveSessionsByDateRange(DateTime rangeStart, DateTime rangeEnd);
        HttpSessionListInfoCollection HttpLog_SELECT_ActiveSessionsByHours(int numberOfHours);

        GenericStringIntInfoCollection HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDate(string visitedUrl, DateTime date, string visitedUrlOptional);
        GenericStringIntInfoCollection HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange(string visitedUrl, DateTime rangeStart, DateTime rangeEnd, string visitedUrlOptional);
        GenericStringIntInfoCollection HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours(string visitedUrl, int numberOfHours, string visitedUrlOptional);

        GenericStringIntInfoCollection HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDate(string visitedUrl, DateTime date);
        GenericStringIntInfoCollection HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange(string visitedUrl, DateTime rangeStart, DateTime rangeEnd);
        GenericStringIntInfoCollection HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours(string visitedUrl, int numberOfHours);

        HttpLogEntryInfoCollection HttpLog_SELECT_UrlHistoryForSession(string sessionId);

        HttpLogEntryInfoCollection HttpLog_SELECT_HistoryByDateRange(DateTime rangeStart, DateTime rangeEnd);
        HttpLogEntryInfoCollection HttpLog_SELECT(DateTime rangeStart, DateTime rangeEnd, string requestedUrl, string refererUrl, string userHostAddress, string sessionId, string miscInfo);

        GenericStringIntInfoCollection HttpLog_SELECT_TopTenUrls();
        GenericStringIntInfoCollection HttpLog_SELECT_TopTenUrls(DateTime rangeStart, DateTime rangeEnd);

        HttpLogUrlReportInfo HttpLog_SELECT_UrlHistory(string targetUrl, DateTime rangeStart, DateTime rangeEnd);

        /// <summary>
        /// Provides information for a givem URL, for the 7 Day period ending at the date-time specified.
        /// </summary>
        /// <param name="targetUrl"></param>
        /// <param name="periodEnding"></param>
        /// <returns></returns>
        HttpLogUrlReportInfoCollection HttpLog_SELECT_UrlHistory7DayReport(string targetUrl, DateTime periodEnding);

        /// <summary>
        /// Provides information for a givem URL, for the 4 week period ending at the date-time specified.
        /// </summary>        
        /// <param name="targetUrl"></param>
        /// <param name="periodEnding"></param>
        /// <returns></returns>
        HttpLogUrlReportInfoCollection HttpLog_SELECT_UrlHistory4WeekReport(string targetUrl, DateTime periodEnding);
    }
}
