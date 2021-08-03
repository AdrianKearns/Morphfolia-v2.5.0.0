// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using Morphfolia.Common.Info;
using Morphfolia.Common.Constants;
using Morphfolia.Business.Constants;

namespace Morphfolia.Business.Logs
{
    public class HttpLogs
    {
        private static Morphfolia.IDataProvider.IHttpLoggerDataProvider iHttpLoggerDataProvider;
        private static Morphfolia.IDataProvider.IHttpLoggerDataProvider IHttpLoggerDataProvider
        {
            get
            {
                if (iHttpLoggerDataProvider == null)
                {
                    iHttpLoggerDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IHttpLoggerDataProvider) as Morphfolia.IDataProvider.IHttpLoggerDataProvider;
                }
                return iHttpLoggerDataProvider;
            }
        }


        /// <summary>
        /// Gets a list of session active between now and the preceeding amount of hours.
        /// </summary>
        /// <param name="timeWindowInHours">The numbers of hours into the past that you want to search by.</param>
        /// <returns></returns>
        public static HttpSessionListInfoCollection GetListOfActiveSessions(int timeWindowInHours)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_ActiveSessionsByHours(timeWindowInHours);
        }

        public static HttpSessionListInfoCollection GetListOfActiveSessions(DateTime date)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_ActiveSessionsByDate(date);
        }

        public static HttpSessionListInfoCollection GetListOfActiveSessions(DateTime rangeStart, DateTime rangeEnd)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_ActiveSessionsByDateRange(rangeStart, rangeEnd);
        }


        public static HttpLogEntryInfoCollection UrlHistoryForSession(string sessionId)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_UrlHistoryForSession(sessionId);
        }



        public static GenericStringIntInfoCollection ListDestinationUrlsFromVisitedUrl(string visitedUrl, int timeWindowInHours)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours(visitedUrl, timeWindowInHours, string.Empty);
        }

        public static GenericStringIntInfoCollection ListDestinationUrlsFromVisitedUrl(string visitedUrl, int timeWindowInHours, string secondVisitedUrl)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours(visitedUrl, timeWindowInHours, secondVisitedUrl);
        }



        public static GenericStringIntInfoCollection ListDestinationUrlsFromVisitedUrl(string visitedUrl, DateTime date)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDate(visitedUrl, date, string.Empty);
        }

        public static GenericStringIntInfoCollection ListDestinationUrlsFromVisitedUrl(string visitedUrl, DateTime rangeStart, DateTime rangeEnd)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange(visitedUrl, rangeStart, rangeEnd, string.Empty);
        }


        public static GenericStringIntInfoCollection ListDestinationUrlsFromVisitedUrl(string visitedUrl, DateTime date, string secondVisitedUrl)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDate(visitedUrl, date, secondVisitedUrl);
        }

        public static GenericStringIntInfoCollection ListDestinationUrlsFromVisitedUrl(string visitedUrl, DateTime rangeStart, DateTime rangeEnd, string secondVisitedUrl)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange(visitedUrl, rangeStart, rangeEnd, secondVisitedUrl);
        }





        public static GenericStringIntInfoCollection ListReferreringUrlsForVisitedUrl(string visitedUrl, int timeWindowInHours)
        {
            GenericStringIntInfoCollection temp = IHttpLoggerDataProvider.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours(visitedUrl, timeWindowInHours);

            return ModifiedData(temp);
        }

        public static GenericStringIntInfoCollection ListReferreringUrlsForVisitedUrl(string visitedUrl, DateTime date)
        {
            GenericStringIntInfoCollection temp = IHttpLoggerDataProvider.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDate(visitedUrl, date);

            return ModifiedData(temp);
        }

        public static GenericStringIntInfoCollection ListReferreringUrlsForVisitedUrl(string visitedUrl, DateTime rangeStart, DateTime rangeEnd)
        {
            GenericStringIntInfoCollection temp = IHttpLoggerDataProvider.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange(visitedUrl, rangeStart, rangeEnd);

            return ModifiedData(temp);
        }



        /// <summary>
        /// Need to think of a better name for this.
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private static GenericStringIntInfoCollection ModifiedData(GenericStringIntInfoCollection temp)
        {
            // turn this...

//          /                       3 
//          /sitemap.aspx           2 
//          /default.aspx           1 

            // ...into this...

//          /default.aspx           4 
//          /sitemap.aspx           2 

            int tempCount = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Text.EndsWith("/"))
                {
                    tempCount = temp[i].Number;
                    temp.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Text.EndsWith("/default.aspx"))
                {
                    tempCount = (temp[i].Number + tempCount);
                    temp.RemoveAt(i);
                    break;
                }
            }

            if (tempCount > 0)
            {
                temp.Insert(0, new GenericStringIntInfo("/default.aspx", tempCount));
            }

            return temp;
        }



        public static HttpLogEntryInfoCollection GetHistory(DateTime rangeStart, DateTime rangeEnd)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_HistoryByDateRange(rangeStart, rangeEnd);
        }


        public static HttpLogEntryInfoCollection GetHistory(HttpLogQuery httpLogQuery)
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT(
                httpLogQuery.RangeStart,
                httpLogQuery.RangeEnd,
                httpLogQuery.RequestedUrl,
                httpLogQuery.RefererUrl,
                httpLogQuery.UserHostAddress,
                httpLogQuery.SessionId,
                httpLogQuery.MiscInfo);
        }


        public static GenericStringIntInfoCollection TopTenUrlsOfAllTime()
        {
            return IHttpLoggerDataProvider.HttpLog_SELECT_TopTenUrls(SystemTypeValues.NullDate, SystemTypeValues.NullDate);
        }

        public static GenericStringIntInfoCollection TopTenUrlsForDateTimeRange(DateTime rangeStart, DateTime rangeEnd)
        {
            Logging.Logger.LogVerboseInformation("TopTenUrlsForDateTimeRange", string.Format("{0} - {1}", rangeStart.ToString(), rangeStart.ToString()), 666);
            return IHttpLoggerDataProvider.HttpLog_SELECT_TopTenUrls(rangeStart, rangeEnd);
        }

        public static GenericStringIntInfoCollection TopTenUrlsFor24Hours(DateTime rangeStart)
        {
            Logging.Logger.LogVerboseInformation("TopTenUrlsFor24Hours", string.Format("{0} - {1}", rangeStart.ToString(), rangeStart.AddHours(24).ToString()), 666);
            return IHttpLoggerDataProvider.HttpLog_SELECT_TopTenUrls(rangeStart, rangeStart.AddHours(24));
        }

        public static GenericStringIntInfoCollection TopTenUrlsFor7Days(DateTime rangeStart)
        {
            Logging.Logger.LogVerboseInformation("TopTenUrlsFor7Days", string.Format("{0} - {1}", rangeStart.ToString(), rangeStart.AddDays(7).ToString()), 666);
            return IHttpLoggerDataProvider.HttpLog_SELECT_TopTenUrls(rangeStart, rangeStart.AddDays(7));
        }


        //HttpLogUrlReportInfo HttpLog_SELECT_UrlHistory(string targetUrl, DateTime rangeStart, DateTime rangeEnd);
        //HttpLogUrlReportInfoCollection HttpLog_SELECT_UrlHistory7DayReport(string targetUrl, DateTime periodEnding);
        //HttpLogUrlReportInfoCollection HttpLog_SELECT_UrlHistory4WeekReport(string targetUrl, DateTime periodEnding);

        public static HttpLogUrlReportInfo GetUrlHistory(string targetUrl, DateTime rangeStart, DateTime rangeEnd)
        {
            //Logging.Logger.LogVerboseInformation("TopTenUrlsFor7Days", string.Format("{0} - {1}", rangeStart.ToString(), rangeStart.AddDays(7).ToString()), 666);
            return IHttpLoggerDataProvider.HttpLog_SELECT_UrlHistory(targetUrl, rangeStart, rangeEnd);
        }

        public static HttpLogUrlReportInfoCollection GetUrlHistoryFor7Days(string targetUrl, DateTime periodEnding)
        {
            //Logging.Logger.LogVerboseInformation("TopTenUrlsFor7Days", string.Format("{0} - {1}", rangeStart.ToString(), rangeStart.AddDays(7).ToString()), 666);
            return IHttpLoggerDataProvider.HttpLog_SELECT_UrlHistory7DayReport(targetUrl, periodEnding);
        }

        public static HttpLogUrlReportInfoCollection GetUrlHistoryFor4Weeks(string targetUrl, DateTime periodEnding)
        {
            //Logging.Logger.LogVerboseInformation("TopTenUrlsFor7Days", string.Format("{0} - {1}", rangeStart.ToString(), rangeStart.AddDays(7).ToString()), 666);
            return IHttpLoggerDataProvider.HttpLog_SELECT_UrlHistory4WeekReport(targetUrl, periodEnding);
        }
    }
}
