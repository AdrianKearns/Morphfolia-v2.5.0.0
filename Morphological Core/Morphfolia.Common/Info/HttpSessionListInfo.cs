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
    ///  Summary description for HttpSessionListInfo.
    /// </summary>
    public struct HttpSessionListInfo
    {
        public readonly string SessionId;
        public readonly string UserHostName;
        public readonly int TotalPageRequests;
        public readonly DateTime FirstRequest;
        public readonly DateTime MostRecentRequest;
        public readonly string FirstUrlRequested;
        public readonly string MostRecentUrlRequested;

        public HttpSessionListInfo(
            string sessionId,
            string userHostName,
            int totalPageRequests,
            DateTime firstRequest,
            DateTime mostRecentRequest,
            string firstUrlRequested,
            string mostRecentUrlRequested)
        {
            SessionId = sessionId;
            UserHostName = userHostName;
            TotalPageRequests = totalPageRequests;
            FirstRequest = firstRequest;
            MostRecentRequest = mostRecentRequest;
            FirstUrlRequested = firstUrlRequested;
            MostRecentUrlRequested = mostRecentUrlRequested;
        }
    }


    public class HttpSessionListInfoCollection : CollectionBase
    {
        public HttpSessionListInfo this[int index]
        {
            get { return ((HttpSessionListInfo)List[index]); }
            set { List[index] = value; }
        }

        public int Add(HttpSessionListInfo value)
        {
            return (List.Add(value));
        }

        public int IndexOf(HttpSessionListInfo value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, HttpSessionListInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(HttpSessionListInfo value)
        {
            List.Remove(value);
        }

        public bool Contains(HttpSessionListInfo value)
        {
            // If value is not of type HttpSessionListInfo, this will return false.
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
            if (value.GetType() != Type.GetType("Morphfolia.Common.Info.HttpSessionListInfo"))
                throw new ArgumentException("value must be of type Morphfolia.Common.Info.HttpSessionListInfo.", "value");
        }
    }

}