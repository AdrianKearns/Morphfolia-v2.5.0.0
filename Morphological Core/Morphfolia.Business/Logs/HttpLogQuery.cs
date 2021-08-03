// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.Business.Logs
{
	/// <summary>
	/// Wraps all the arguments that can be used to invoke a search query aganist the Http Logs.
	/// </summary>
    public struct HttpLogQuery : IUberLogQuery
	{
        public readonly string RequestedUrl;
        public readonly string RefererUrl;
        public readonly string SessionId;
        public readonly string UserHostAddress;
        public readonly string MiscInfo;
        public readonly DateTime WhenLoggedRangeStart;
		public readonly DateTime WhenLoggedRangeEnd;

        public DateTime RangeStart
        {
            get { return WhenLoggedRangeStart; }
        }
        public DateTime RangeEnd
        {
            get { return WhenLoggedRangeEnd; }
        }

        public HttpLogQuery(
			DateTime whenLoggedRangeStart,
			DateTime whenLoggedRangeEnd)
		{
            RequestedUrl = string.Empty;
            RefererUrl = string.Empty;
            SessionId = string.Empty;
            UserHostAddress = string.Empty;
            MiscInfo = string.Empty;
			WhenLoggedRangeStart = whenLoggedRangeStart;
			WhenLoggedRangeEnd = whenLoggedRangeEnd;
		}

        public HttpLogQuery(
            string requestedUrl,
            string refererUrl,
            string sessionId,
            string userHostAddress,
            string miscInfo,
            DateTime whenLoggedRangeStart,
            DateTime whenLoggedRangeEnd)
        {
            RequestedUrl = requestedUrl;
            RefererUrl = refererUrl;
            SessionId = sessionId;
            UserHostAddress = userHostAddress;
            MiscInfo = miscInfo;
            WhenLoggedRangeStart = whenLoggedRangeStart;
            WhenLoggedRangeEnd = whenLoggedRangeEnd;
        }
	}
}