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
    ///  Summary description for HttpLogEntryInfo.
    /// </summary>
    public struct HttpLogEntryInfo
    {
        public readonly int LogId;
        public readonly string SessionId;
        public readonly string UserHostName;
        public readonly string Url;
        public readonly string UrlReferrer;
        public readonly DateTime TimeLogged;
        public readonly string MiscInfo;

        public HttpLogEntryInfo(
            int logId,
            string sessionId,
            string userHostName,
            string url,
            string urlReferrer,
            DateTime timeLogged,
            string miscInfo)
        {
            LogId = logId;
            SessionId = sessionId;
            UserHostName = userHostName;
            Url = url;
            UrlReferrer = urlReferrer;
            TimeLogged = timeLogged;
            MiscInfo = miscInfo;
        }
    }


    public class HttpLogEntryInfoCollection : CollectionBase
    {
        public HttpLogEntryInfo this[int index]
        {
            get { return ((HttpLogEntryInfo)List[index]); }
            set { List[index] = value; }
        }

        public int Add(HttpLogEntryInfo value)
        {
            return (List.Add(value));
        }

        public int IndexOf(HttpLogEntryInfo value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, HttpLogEntryInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(HttpLogEntryInfo value)
        {
            List.Remove(value);
        }

        public bool Contains(HttpLogEntryInfo value)
        {
            // If value is not of type HttpLogEntryInfo, this will return false.
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
            if (value.GetType() != Type.GetType("Morphfolia.Common.Info.HttpLogEntryInfo"))
                throw new ArgumentException("value must be of type Morphfolia.Common.Info.HttpLogEntryInfo.", "value");
        }
    }

}