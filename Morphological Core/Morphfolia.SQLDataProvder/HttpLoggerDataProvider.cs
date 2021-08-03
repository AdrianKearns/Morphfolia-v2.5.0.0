// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data.SqlClient;
using Morphfolia.Common.Constants;
using Morphfolia.Common.Info;
using Morphfolia.SQLDataProvider.Utilities;

namespace Morphfolia.SQLDataProvider
{
    public class HttpLoggerDataProvider : Morphfolia.IDataProvider.IHttpLoggerDataProvider
    {
        public void HttpLog_INSERT(string sessionId, string userHostName, string url, string urlReferrer, string miscInfo)
        {
            if (miscInfo == null)
            {
                miscInfo = string.Empty;
            }

            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("HttpLog_INSERT", sessionId, userHostName, url, urlReferrer, miscInfo);
        }


        public HttpSessionListInfoCollection HttpLog_SELECT_ActiveSessionsByDate(DateTime date)
        {
            return HttpLog_SELECT_ActiveSessionsByDateRange(date, SystemTypeValues.NullDate);
        }

        public HttpSessionListInfoCollection HttpLog_SELECT_ActiveSessionsByDateRange(DateTime rangeStart, DateTime rangeEnd)
        {
            HttpSessionListInfo httpSessionListInfo;
            HttpSessionListInfoCollection sessions = new HttpSessionListInfoCollection();

            // Modify Dates as required:
            if (rangeEnd.Equals(SystemTypeValues.NullDate))
            {
                rangeEnd = rangeStart;
            }
            rangeEnd = rangeEnd.AddDays(1);


            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "HttpLog_SELECT_ActiveSessionsByDateRange", 
                       Utilities.DateTimeHelper.DateInSQLFormat(rangeStart),
                       Utilities.DateTimeHelper.DateInSQLFormat(rangeEnd)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        httpSessionListInfo = new HttpSessionListInfo(
                            dr["SessionId"].ToString(),
                            dr["UserHostName"].ToString(),
                            (int)dr["TotalPageRequests"],
                            Utilities.DateTimeHelper.GetDateTimeFromDataRowItem(dr["FirstUrlRequest"]),
                            Utilities.DateTimeHelper.GetDateTimeFromDataRowItem(dr["LastUrlRequest"]),
                            dr["FirstUrlRequested"].ToString(),
                            dr["LastUrlRequested"].ToString()
                            );

                        sessions.Add(httpSessionListInfo);
                    }
                }
            }

            return sessions;
        }

        public HttpSessionListInfoCollection HttpLog_SELECT_ActiveSessionsByHours(int numberOfHours)
        {
            HttpSessionListInfo httpSessionListInfo;
            HttpSessionListInfoCollection sessions = new HttpSessionListInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "HttpLog_SELECT_ActiveSessionsByHours", numberOfHours))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        httpSessionListInfo = new HttpSessionListInfo(
                            dr["SessionId"].ToString(),
                            dr["UserHostName"].ToString(),
                            (int)dr["TotalPageRequests"],
                            Utilities.DateTimeHelper.GetDateTimeFromDataRowItem(dr["FirstUrlRequest"]),
                            Utilities.DateTimeHelper.GetDateTimeFromDataRowItem(dr["LastUrlRequest"]),
                            dr["FirstUrlRequested"].ToString(),
                            dr["LastUrlRequested"].ToString()
                        );

                        sessions.Add(httpSessionListInfo);
                    }
                }
            }

            return sessions;
        }



        public GenericStringIntInfoCollection HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDate(string visitedUrl, DateTime date, string visitedUrlOptional)
        {
            return HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange(visitedUrl, date, SystemTypeValues.NullDate, visitedUrlOptional);
        }

        public GenericStringIntInfoCollection HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange(string visitedUrl, DateTime rangeStart, DateTime rangeEnd, string visitedUrlOptional)
        {
            Logging.Logger.LogVerboseInformation("HTTP Log - Traffic inquiry", string.Format("visitedUrl: [{0}]{2}visitedUrlOptional: [{1}]", visitedUrl, visitedUrlOptional, Environment.NewLine), Logging.EventIds._6805);


            GenericStringIntInfo genericStringIntInfo;
            GenericStringIntInfoCollection genericStringIntInfoCollection = new GenericStringIntInfoCollection();


            // Modify Dates as required:
            if (rangeEnd.Equals(SystemTypeValues.NullDate))
            {
                rangeEnd = rangeStart;
            }
            rangeEnd = rangeEnd.AddDays(1);



            if (visitedUrlOptional == null)
            {
                visitedUrlOptional = string.Empty;
            }


            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange", 
                       visitedUrl, 
                       visitedUrlOptional, 
                       Utilities.DateTimeHelper.DateInSQLFormat(rangeStart), 
                       Utilities.DateTimeHelper.DateInSQLFormat(rangeEnd)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        genericStringIntInfo = new GenericStringIntInfo(
                            dr["Url"].ToString(),
                            (int)dr["NumberOfHitsOnDestination"]
                            );

                        genericStringIntInfoCollection.Add(genericStringIntInfo);
                    }
                }
            }

            return genericStringIntInfoCollection;
        }

        public GenericStringIntInfoCollection HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours(string visitedUrl, int numberOfHours, string visitedUrlOptional)
        {
            Logging.Logger.LogVerboseInformation("HTTP Log - Traffic inquiry", string.Format("visitedUrl: [{0}]{2}visitedUrlOptional: [{1}]", visitedUrl, visitedUrlOptional, Environment.NewLine), Logging.EventIds._6806);


            GenericStringIntInfo genericStringIntInfo;
            GenericStringIntInfoCollection genericStringIntInfoCollection = new GenericStringIntInfoCollection();


            if (visitedUrlOptional == null)
            {
                visitedUrlOptional = string.Empty;
            }


            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours", visitedUrl, visitedUrlOptional, numberOfHours))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        genericStringIntInfo = new GenericStringIntInfo(
                            dr["Url"].ToString(),
                            (int)dr["NumberOfHitsOnDestination"]
                            );

                        genericStringIntInfoCollection.Add(genericStringIntInfo);
                    }
                }
            }

            return genericStringIntInfoCollection;
        }



        public GenericStringIntInfoCollection HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDate(string visitedUrl, DateTime date)
        {
            return HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange(visitedUrl, date, SystemTypeValues.NullDate);
        }

        public GenericStringIntInfoCollection HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange(string visitedUrl, DateTime rangeStart, DateTime rangeEnd)
        {
            Logging.Logger.LogVerboseInformation("HTTP Log - Traffic inquiry", string.Format("visitedUrl: [{0}]", visitedUrl), Logging.EventIds._6807);


            GenericStringIntInfo genericStringIntInfo;
            GenericStringIntInfoCollection genericStringIntInfoCollection = new GenericStringIntInfoCollection();


            // Modify Dates as required:
            if (rangeEnd.Equals(SystemTypeValues.NullDate))
            {
                rangeEnd = rangeStart;
            }
            rangeEnd = rangeEnd.AddDays(1);



            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange", 
                       visitedUrl, 
                       Utilities.DateTimeHelper.DateInSQLFormat(rangeStart), 
                       Utilities.DateTimeHelper.DateInSQLFormat(rangeEnd)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        genericStringIntInfo = new GenericStringIntInfo(
                            dr["UrlReferrer"].ToString(),
                            (int)dr["NumberOfHitsOnDestination"]
                            );

                        genericStringIntInfoCollection.Add(genericStringIntInfo);
                    }
                }
            }

            return genericStringIntInfoCollection;
        }

        public GenericStringIntInfoCollection HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours(string visitedUrl, int numberOfHours)
        {
            Logging.Logger.LogVerboseInformation("HTTP Log - Traffic inquiry", string.Format("visitedUrl: [{0}]", visitedUrl), Logging.EventIds._6808);


            GenericStringIntInfo genericStringIntInfo;
            GenericStringIntInfoCollection genericStringIntInfoCollection = new GenericStringIntInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours", visitedUrl, numberOfHours))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        genericStringIntInfo = new GenericStringIntInfo(
                            dr["UrlReferrer"].ToString(),
                            (int)dr["NumberOfHitsOnDestination"]
                            );

                        genericStringIntInfoCollection.Add(genericStringIntInfo);
                    }
                }
            }

            return genericStringIntInfoCollection;
        }



        public HttpLogEntryInfoCollection HttpLog_SELECT_UrlHistoryForSession(string sessionId)
        {
            DateTime timeLogged;
            HttpLogEntryInfo httpLogEntryInfo;
            HttpLogEntryInfoCollection httpLogEntryInfoCollection = new HttpLogEntryInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("HttpLog_SELECT_UrlHistoryForSession", sessionId))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        try
                        {
                            timeLogged = DateTime.Parse(dr["TimeLogged"].ToString());
                        }
                        catch
                        {
                            timeLogged = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }


                        httpLogEntryInfo = new HttpLogEntryInfo(
                            (int)dr["LogId"],
                            dr["SessionId"].ToString(),
                            dr["UserHostName"].ToString(),
                            dr["Url"].ToString(),
                            dr["UrlReferrer"].ToString(),
                            timeLogged,
                            dr["MiscInfo"].ToString()
                            );

                        httpLogEntryInfoCollection.Add(httpLogEntryInfo);
                    }
                }
            }

            return httpLogEntryInfoCollection;
        }


        public HttpLogEntryInfoCollection HttpLog_SELECT_HistoryByDateRange(DateTime rangeStart, DateTime rangeEnd)
        {
            HttpLogEntryInfo item;
            HttpLogEntryInfoCollection collection = new HttpLogEntryInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "HttpLog_SELECT_HistoryByDateRange",
                       Utilities.DateTimeHelper.DateInSQLFormat(rangeStart),
                       Utilities.DateTimeHelper.DateInSQLFormat(rangeEnd)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        item = new HttpLogEntryInfo(
                            (int)dr["LogId"],
                            dr["SessionId"].ToString(),
                            dr["UserHostName"].ToString(),
                            dr["Url"].ToString(),
                            dr["UrlReferrer"].ToString(),
                            (DateTime)dr["TimeLogged"],
                            dr["MiscInfo"].ToString()
                            );

                        collection.Add(item);
                    }
                }
            }

            return collection;
        }


        public HttpLogEntryInfoCollection HttpLog_SELECT(
            DateTime rangeStart, 
            DateTime rangeEnd, 
            string requestedUrl,
            string refererUrl,
            string userHostAddress, 
            string sessionId,
            string miscInfo)
        {
            HttpLogEntryInfo item;
            HttpLogEntryInfoCollection collection = new HttpLogEntryInfoCollection();

            //Logging.Logger.LogVerboseInformation("HttpLog_SELECT", string.Format("rangeStart: [{0}] rangeEnd: [{1}]", rangeStart.ToString(), rangeEnd.ToString()), 666);

            string parsedRequestedUrl = Utilities.Like.SafeLikeExpression(requestedUrl);
            string parsedRefererUrl = Utilities.Like.SafeLikeExpression(refererUrl);
            string parsedUserHostAddress = Utilities.Like.SafeLikeExpression(userHostAddress);
            string parsedSessionId = Utilities.Like.SafeLikeExpression(sessionId);
            string parsedMiscInfo = Utilities.Like.SafeLikeExpression(miscInfo);

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "HttpLog_SELECT",
                       Utilities.DateTimeHelper.DateTimeStampInSQLFormat_ToMillisecond(rangeStart),
                       Utilities.DateTimeHelper.DateTimeStampInSQLFormat_ToMillisecond(rangeEnd),
                       parsedRequestedUrl, parsedRefererUrl, parsedUserHostAddress, parsedSessionId, parsedMiscInfo))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        item = new HttpLogEntryInfo(
                            (int)dr["LogId"],
                            dr["SessionId"].ToString(),
                            dr["UserHostName"].ToString(),
                            dr["Url"].ToString(),
                            dr["UrlReferrer"].ToString(),
                            (DateTime)dr["TimeLogged"],
                            dr["MiscInfo"].ToString()
                            );

                        collection.Add(item);
                    }
                }
            }

            return collection;
        }


        public GenericStringIntInfoCollection HttpLog_SELECT_TopTenUrls()
        {
            GenericStringIntInfo genericStringIntInfo;
            GenericStringIntInfoCollection genericStringIntInfoCollection = new GenericStringIntInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("HttpLog_SELECT_TopTenUrls"))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        genericStringIntInfo = new GenericStringIntInfo(
                            dr["Url"].ToString(),
                            (int)dr["HitCount"]
                            );

                        genericStringIntInfoCollection.Add(genericStringIntInfo);
                    }
                }
            }

            return genericStringIntInfoCollection;
        }


        public GenericStringIntInfoCollection HttpLog_SELECT_TopTenUrls(DateTime rangeStart, DateTime rangeEnd)
        {
            GenericStringIntInfo genericStringIntInfo;
            GenericStringIntInfoCollection genericStringIntInfoCollection = new GenericStringIntInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("HttpLog_SELECT_TopTenUrls",
                       rangeStart, rangeEnd))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        genericStringIntInfo = new GenericStringIntInfo(
                            dr["Url"].ToString(),
                            (int)dr["HitCount"]
                            );

                        genericStringIntInfoCollection.Add(genericStringIntInfo);
                    }
                }
            }

            return genericStringIntInfoCollection;
        }


        public HttpLogUrlReportInfo HttpLog_SELECT_UrlHistory(string targetUrl, DateTime rangeStart, DateTime rangeEnd)
        {
            Logging.Logger.LogVerboseInformation("HttpLog_SELECT_UrlHistory", string.Format("rangeStart: {0}<br>rangeEnd: {1}", rangeStart.ToString(), rangeEnd.ToString()), 666);
            //return IHttpLoggerDataProvider.HttpLog_SELECT_UrlHistory(targetUrl, rangeStart, rangeEnd);

            HttpLogUrlReportInfo httpLogUrlReportInfo;
            HttpLogUrlHitInfoCollection hitsByReferrer = new HttpLogUrlHitInfoCollection();
            GenericStringIntInfoCollection hitsAsReferrer = new GenericStringIntInfoCollection();
            GenericStringIntInfoCollection sessions = new GenericStringIntInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("HttpLog_SELECT_UrlHistory",
                       targetUrl, rangeStart, rangeEnd))
            {
                if (dr.HasRows)
                {
                    httpLogUrlReportInfo = UrlHistoryDataBatchSkimmer(dr);
                }
                else
                {


                    //TargetURL                                                         RangeStart              RangeEnd
                    //----------------------------------------------------------------- ----------------------- -----------------------
                    //http://localhost/Morphfolia.Web/default.aspx                      2010-04-08 00:00:00.000 2010-04-14 00:00:00.000

                    //UrlReferrer                                                                                            Url                                                            HitCount
                    //------------------------------------------------------------------------------------------------------ -------------------------------------------------------------- -----------
                    //                                                                                                       http://localhost/Morphfolia.Web/default.aspx                   7
                    //http://localhost/Morphfolia.Web/blogs/viewpost/Test+Blog+001/BlogContentTest+3+-+Political.aspx        http://localhost/Morphfolia.Web/default.aspx                   4
                    //http://localhost/Morphfolia.Web/SiteMap.aspx                                                           http://localhost/Morphfolia.Web/default.aspx                   3
                    //http://localhost/Morphfolia.Web/test/Sven.aspx                                                         http://localhost/Morphfolia.Web/default.aspx                   2
                    //http://localhost/Morphfolia.Web/SearchResults.aspx?searchcriteria=blogpostcontent                      http://localhost/Morphfolia.Web/default.aspx                   2
                    //http://localhost/Morphfolia.Web/PageLayout%20Tutorial.aspx                                             http://localhost/Morphfolia.Web/default.aspx                   1
                    //                                                                                                       http://localhost/Morphfolia.Web/default.aspx?search=foo        1
                    //http://localhost/Morphfolia.Web/backlog.aspx                                                           http://localhost/Morphfolia.Web/default.aspx                   1

                    //Url                                                                                                    ReferrerHits
                    //------------------------------------------------------------------------------------------------------ ------------
                    //http://localhost/Morphfolia.Web/SearchResults.aspx?searchcriteria=test+001&btnSearch=Search            1

                    //SessionId                                          Hits
                    //-------------------------------------------------- -----------
                    //np4i2f5533r0dbi03lyxxzqg                           21
                    //ssfc1345tcijo3bpk1vlvavq                           2

                    //HitsTotal
                    //-----------
                    //23

                    //ReferrerHitsTotal
                    //-----------------
                    //1

                    //BotTotal
                    //-----------
                    //0

                    //GrandTotal
                    //-----------
                    //115

                    //BotGrandTotal
                    //-------------
                    //0

                    //RSSReaderGrandTotal
                    //-------------------
                    //16



                    Logging.Logger.LogVerboseInformation("HttpLog_SELECT_UrlHistory", "no rows");
                    httpLogUrlReportInfo = new HttpLogUrlReportInfo(targetUrl, rangeStart, rangeEnd, 
                        hitsByReferrer, hitsAsReferrer, sessions,
                        Common.Constants.SystemTypeValues.NullInt,
                        Common.Constants.SystemTypeValues.NullInt,
                        Common.Constants.SystemTypeValues.NullInt,
                        Common.Constants.SystemTypeValues.NullInt,
                        Common.Constants.SystemTypeValues.NullInt,
                        Common.Constants.SystemTypeValues.NullInt);
                }
            }
          
            return httpLogUrlReportInfo;
        }



        public HttpLogUrlReportInfoCollection HttpLog_SELECT_UrlHistory7DayReport(string targetUrl, DateTime periodEnding)
        {
            HttpLogUrlReportInfo httpLogUrlReportInfo;
            HttpLogUrlReportInfoCollection httpLogUrlReportInfoCollection = new HttpLogUrlReportInfoCollection();

            Logging.Logger.LogVerboseInformation("HttpLog_SELECT_UrlHistory7DayReport", string.Format("periodEnding: {0}", periodEnding.ToString()), 666);

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("HttpLog_SELECT_UrlHistory7DayReport",
                       targetUrl, periodEnding))
            {
                if (dr.HasRows)
                {
                    httpLogUrlReportInfo = UrlHistoryDataBatchSkimmer(dr);
                    httpLogUrlReportInfoCollection.Add(httpLogUrlReportInfo);

                    while (dr.NextResult())
                    {
                        httpLogUrlReportInfo = UrlHistoryDataBatchSkimmer(dr);
                        httpLogUrlReportInfoCollection.Add(httpLogUrlReportInfo);
                    }
                }
                else
                {
                    Logging.Logger.LogVerboseInformation("HttpLog_SELECT_UrlHistory7DayReport", "no rows");
                }
            }

            return httpLogUrlReportInfoCollection;
        }

        public HttpLogUrlReportInfoCollection HttpLog_SELECT_UrlHistory4WeekReport(string targetUrl, DateTime periodEnding)
        {
            HttpLogUrlReportInfo httpLogUrlReportInfo;
            HttpLogUrlReportInfoCollection httpLogUrlReportInfoCollection = new HttpLogUrlReportInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("HttpLog_SELECT_UrlHistory4WeekReport",
                       targetUrl, periodEnding))
            {
                if (dr.HasRows)
                {
                    httpLogUrlReportInfo = UrlHistoryDataBatchSkimmer(dr);
                    httpLogUrlReportInfoCollection.Add(httpLogUrlReportInfo);

                    while (dr.NextResult())
                    {
                        httpLogUrlReportInfo = UrlHistoryDataBatchSkimmer(dr);
                        httpLogUrlReportInfoCollection.Add(httpLogUrlReportInfo);
                    }
                }
                else
                {
                    Logging.Logger.LogVerboseInformation("HttpLog_SELECT_UrlHistory4WeekReport", "no rows");
                }
            }

            return httpLogUrlReportInfoCollection;
        }


        /// <summary>
        /// Reads through all the data for a "batch" of UrlHistoryData - 10 lots of data in all.
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private HttpLogUrlReportInfo UrlHistoryDataBatchSkimmer(SqlDataReader dr)
        {
            //Logging.Logger.LogVerboseInformation("TopTenUrlsFor7Days", string.Format("{0} - {1}", rangeStart.ToString(), rangeStart.AddDays(7).ToString()), 666);
            //return IHttpLoggerDataProvider.HttpLog_SELECT_UrlHistory(targetUrl, rangeStart, rangeEnd);

            string targetUrl = string.Empty;
            DateTime periodStart = Common.Constants.SystemTypeValues.NullDate;
            DateTime periodEnd = Common.Constants.SystemTypeValues.NullDate;
            HttpLogUrlReportInfo httpLogUrlReportInfo;
            HttpLogUrlHitInfo httpLogUrlHitInfo;
            HttpLogUrlHitInfoCollection hitsByReferrer = new HttpLogUrlHitInfoCollection();
            GenericStringIntInfoCollection hitsAsReferrer = new GenericStringIntInfoCollection();
            GenericStringIntInfoCollection sessions = new GenericStringIntInfoCollection();
            int totalsHitsByReferrer = Common.Constants.SystemTypeValues.NullInt;
            int totalHitsAsReferrer = Common.Constants.SystemTypeValues.NullInt;
            int botTotal = Common.Constants.SystemTypeValues.NullInt;
            int grandTotal = Common.Constants.SystemTypeValues.NullInt;
            int botGrandTotal = Common.Constants.SystemTypeValues.NullInt;
            int rssGrandTotal = Common.Constants.SystemTypeValues.NullInt;
            GenericStringIntInfo sharedStringIntInfo;

            if(dr != null)
            {
                // HttpLog_SELECT_UrlHistory returns back the calling arguments: 
                if (dr.HasRows)
                {
                    try
                    {
                        dr.Read();
                        targetUrl = dr["TargetURL"].ToString();
                        bool x = DateTime.TryParse(dr["RangeStart"].ToString(), out periodStart);
                        bool y = DateTime.TryParse(dr["RangeEnd"].ToString(), out periodEnd);

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer", string.Format("RangeStart {0}<br>RangeEnd {1} - {2} {3}", 
                            dr["RangeStart"].ToString(), dr["RangeEnd"].ToString(),
                            x.ToString(), y.ToString()));

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (1 - get basic info).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (1 - get basic info) failed.", ex);
                    }
                }

                dr.NextResult();
                // hitsByReferrer.
                if (dr.HasRows)
                {
                    try
                    {
                        while (dr.Read())
                        {
                            httpLogUrlHitInfo = new HttpLogUrlHitInfo(
                                dr["UrlReferrer"].ToString(),
                                dr["Url"].ToString(),
                                (int)dr["HitCount"]
                                );

                            hitsByReferrer.Add(httpLogUrlHitInfo);
                        }

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (2 - hitsByReferrer).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (2 - hitsByReferrer) failed.", ex);
                    }
                }





                dr.NextResult();
                // hitsAsReferrer
                if (dr.HasRows)
                {
                    try
                    {
                        while (dr.Read())
                        {
                            sharedStringIntInfo = new GenericStringIntInfo(
                                dr["Url"].ToString(),
                                (int)dr["ReferrerHits"]
                                );

                            hitsAsReferrer.Add(sharedStringIntInfo);
                        }

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (3 - hitsAsReferrer).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (3 - hitsAsReferrer) failed.", ex);
                    }
                }




                dr.NextResult();
                // sessions
                if (dr.HasRows)
                {
                    try
                    {
                        while (dr.Read())
                        {
                            sharedStringIntInfo = new GenericStringIntInfo(
                                dr["SessionId"].ToString(),
                                (int)dr["Hits"]
                                );

                            sessions.Add(sharedStringIntInfo);
                        }

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (4 - sessions).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (4 - sessions) failed.", ex);
                    }
                }


                dr.NextResult();
                // totalsHitsByReferrer
                if (dr.HasRows)
                {
                    try
                    {
                        dr.Read();
                        totalsHitsByReferrer = (int)dr["HitsTotal"];
                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (5 - totalsHitsByReferrer).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (5 - totalsHitsByReferrer) failed.", ex);
                    }
                }


                dr.NextResult();
                // totalHitsAsReferrer
                if (dr.HasRows)
                {
                    try
                    {
                        dr.Read();
                        totalHitsAsReferrer = (int)dr["ReferrerHitsTotal"];

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (6 - totalHitsAsReferrer).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (6 - totalHitsAsReferrer) failed.", ex);
                    }
                }


                dr.NextResult();
                // BotTotal
                if (dr.HasRows)
                {
                    try
                    {
                        dr.Read();
                        botTotal = (int)dr["BotTotal"];

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (7 - botTotal).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (7 - botTotal) failed.", ex);
                    }
                }


                dr.NextResult();
                // grandTotal
                if (dr.HasRows)
                {
                    try
                    {                      
                        dr.Read();
                        grandTotal = (int)dr["GrandTotal"];                        

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (8 - grandTotal).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (8 - grandTotal) failed.", ex);
                    }
                }


                dr.NextResult();
                // BotGrandTotal
                if (dr.HasRows)
                {
                    try
                    {
                        dr.Read();
                        botGrandTotal = (int)dr["BotGrandTotal"];

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (9 - BotGrandTotal).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (9 - BotGrandTotal) failed.", ex);
                    }
                }

                dr.NextResult();
                // RSSGrandTotal
                if (dr.HasRows)
                {
                    try
                    {
                        dr.Read();
                        rssGrandTotal = (int)dr["RSSReaderGrandTotal"];

                        Logging.Logger.LogVerboseInformation("UrlHistoryDataBatchSkimmer (10 - RSSReaderGrandTotal).", "Complete");
                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.LogException("UrlHistoryDataBatchSkimmer (10 - RSSReaderGrandTotal) failed.", ex);
                    }
                }
            }

            httpLogUrlReportInfo = new HttpLogUrlReportInfo(targetUrl, periodStart, periodEnd, 
                hitsByReferrer,
                hitsAsReferrer,
                sessions, 
                totalsHitsByReferrer, 
                totalHitsAsReferrer, 
                botTotal,
                grandTotal, 
                botGrandTotal, 
                rssGrandTotal);

            return httpLogUrlReportInfo;
        }

    }
}
