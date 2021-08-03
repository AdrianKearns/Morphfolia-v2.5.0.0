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
    ///  Summary description for HttpLogUrlHitInfo.
    /// </summary>
    public struct HttpLogUrlHitInfo
    {
        public readonly string UrlReferrer;
        public readonly string Url;
        public readonly int HitCount;

        public HttpLogUrlHitInfo(
            string urlReferrer,
            string url,
            int hitCount)
        {
            UrlReferrer = urlReferrer;
            Url = url;
            HitCount = hitCount;
        }
    }


    public class HttpLogUrlHitInfoCollection : CollectionBase
    {
        public HttpLogUrlHitInfo this[int index]
        {
            get { return ((HttpLogUrlHitInfo)List[index]); }
            set { List[index] = value; }
        }

        public int Add(HttpLogUrlHitInfo value)
        {
            return (List.Add(value));
        }

        public int IndexOf(HttpLogUrlHitInfo value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, HttpLogUrlHitInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(HttpLogUrlHitInfo value)
        {
            List.Remove(value);
        }

        public bool Contains(HttpLogUrlHitInfo value)
        {
            // If value is not of type HttpLogUrlHitInfo, this will return false.
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
            if (value.GetType() != Type.GetType("Morphfolia.Common.Info.HttpLogUrlHitInfo"))
                throw new ArgumentException("value must be of type Morphfolia.Common.Info.HttpLogUrlHitInfo.", "value");
        }
    }

}