// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;

namespace Morphfolia.IDataProvider
{
    public interface ILogViewer
    {
        DataTable GetLogEntries(
            int maxNumberOfLogsToReturn,
            int eventId,
            int minimumPriority,
            string severity,
            string machineName,
            string titleFilter, 
            string messageFilter,
            DateTime loggedSince,
            DateTime loggedBefore);
    }
}
