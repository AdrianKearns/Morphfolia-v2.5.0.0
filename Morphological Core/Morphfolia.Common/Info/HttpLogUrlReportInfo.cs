// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;

namespace Morphfolia.Common.Info
{
    /// <summary>
    ///  Summary description for HttpLogUrlReportInfo.
    /// </summary>
    public struct HttpLogUrlReportInfo
    {
        /// <summary>
        /// The URL this information is about.
        /// </summary>
        public readonly string TargetUrl;

        /// <summary>
        /// The date/time this history starts from.
        /// </summary>
        public readonly DateTime PeriodStart;

        /// <summary>
        /// The date/time this history stops at.
        /// </summary>
        public readonly DateTime PeriodEnd;

        /// <summary>
        /// The number of hits aganist the target URL, by Referrer.
        /// </summary>
        public readonly HttpLogUrlHitInfoCollection HitsByReferrer;

        /// <summary>
        /// The number of times the target URL has been a Referrer.
        /// </summary>
        public readonly GenericStringIntInfoCollection HitsAsReferrer;

        /// <summary>
        /// List of sessions that have hit the target URL, plus the number of hits that session has had.
        /// </summary>
        public readonly GenericStringIntInfoCollection Sessions;

        /// <summary>
        /// The total number of hits for the target URL.
        /// </summary>
        public readonly int TotalsHitsByReferrer;

        /// <summary>
        /// The total number of times the target URL has been a referrer.
        /// </summary>
        public readonly int TotalHitsAsReferrer;

        /// <summary>
        /// The total of hits aganist the URL for the same period - for search robots.
        /// </summary>
        public readonly int BotTotal;

        /// <summary>
        /// The grand total of hits for the same period.
        /// </summary>
        public readonly int GrandTotal;

        /// <summary>
        /// The grand total of hits for the same period - for search robots.
        /// </summary>
        public readonly int BotGrandTotal;

        /// <summary>
        /// The grand total of hits for the same period - for RSS Readers.
        /// </summary>
        public readonly int RSSReaderGrandTotal;


        /// <summary>
        /// A bunch of information about the HTTP Traffic (and related info) for a specific URL.
        /// </summary>
        /// <param name="urlReferrer"></param>
        /// <param name="url"></param>
        /// <param name="hitCount"></param>
        public HttpLogUrlReportInfo(
            string targetUrl,
            DateTime periodStart,
            DateTime periodEnd,
            HttpLogUrlHitInfoCollection hitsByReferrer,
            GenericStringIntInfoCollection hitsAsReferrer,
            GenericStringIntInfoCollection sessions,
            int totalsHitsByReferrer,
            int totalHitsAsReferrer,
            int botTotal,
            int grandTotal,
            int botGrandTotal,
            int rssReaderGrandTotal)
        {
            TargetUrl = targetUrl;
            PeriodStart = periodStart;
            PeriodEnd = periodEnd;
            HitsByReferrer = hitsByReferrer;
            HitsAsReferrer = hitsAsReferrer;
            Sessions = sessions;
            TotalsHitsByReferrer = totalsHitsByReferrer;
            TotalHitsAsReferrer = totalHitsAsReferrer;
            BotTotal = botTotal;
            GrandTotal = grandTotal;
            BotGrandTotal = botGrandTotal;
            RSSReaderGrandTotal = rssReaderGrandTotal;
        }
    }


    public class HttpLogUrlReportInfoCollection : CollectionBase
    {
        public HttpLogUrlReportInfo this[int index]
        {
            get { return ((HttpLogUrlReportInfo)List[index]); }
            set { List[index] = value; }
        }

        public int Add(HttpLogUrlReportInfo value)
        {
            return (List.Add(value));
        }

        public int IndexOf(HttpLogUrlReportInfo value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, HttpLogUrlReportInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(HttpLogUrlReportInfo value)
        {
            List.Remove(value);
        }

        public bool Contains(HttpLogUrlReportInfo value)
        {
            // If value is not of type HttpLogUrlReportInfo, this will return false.
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value)
        {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != Type.GetType("Morphfolia.Common.Info.HttpLogUrlReportInfo"))
                throw new ArgumentException("value must be of type Morphfolia.Common.Info.HttpLogUrlReportInfo.", "value");
        }
    }

}