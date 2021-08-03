// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.Business.Logs
{
    /// <summary>
    /// Wraps all the arguments that can be used to invoke a search query aganist the System Logs.
    /// </summary>
    public struct SystemLogQuery : IUberLogQuery
    {
        public readonly int MaxNumberOfLogsToReturn;
        public readonly int EventId;
        public readonly int MinimumPriority;
        public readonly string Severity;
        public readonly string MachineName;
        public readonly string TitleFilter;
        public readonly string MessageFilter;
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

        public SystemLogQuery(
            DateTime whenLoggedRangeStart,
            DateTime whenLoggedRangeEnd)
        {
            MaxNumberOfLogsToReturn = int.MaxValue;
            EventId = Common.Constants.SystemTypeValues.NullInt;
            MinimumPriority = 0;
            Severity = string.Empty;
            MachineName = string.Empty;
            TitleFilter = string.Empty;
            MessageFilter = string.Empty;
            WhenLoggedRangeStart = whenLoggedRangeStart;
            WhenLoggedRangeEnd = whenLoggedRangeEnd;
        }

        public SystemLogQuery(
            int maxNumberOfLogsToReturn,
            int eventId,
            int minimumPriority,
            string severity,
            string machineName,
            string titleFilter,
            string messageFilter,
            DateTime whenLoggedRangeStart,
            DateTime whenLoggedRangeEnd)
        {
            MaxNumberOfLogsToReturn = maxNumberOfLogsToReturn;
            EventId = eventId;
            MinimumPriority = minimumPriority;
            Severity = severity;
            MachineName = machineName;
            TitleFilter = titleFilter;
            MessageFilter = messageFilter;
            WhenLoggedRangeStart = whenLoggedRangeStart;
            WhenLoggedRangeEnd = whenLoggedRangeEnd;
        }
    }
}
