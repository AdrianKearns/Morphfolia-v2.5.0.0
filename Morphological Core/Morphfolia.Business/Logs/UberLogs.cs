// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Morphfolia.Business.Logs
//{
//    public class UberLogs
//    {
//        public void GetSomeLogs(UberLogQuery uberLogQuery)
//        {
//            GetSomeLogs(uberLogQuery.RangeStart, uberLogQuery.RangeEnd);
//        }

//        public void GetSomeLogs(DateTime rangeStart, DateTime rangeEnd)
//        {

//            Get all records and munge them together by datetime


//            SystemLogs.GetLogEntries(new SystemLogQuery(rangeStart, rangeEnd));
//            AuditLogs.SearchAuditLogs(new AuditLogQuery(rangeStart, rangeEnd));
//            HttpLogs.GetHistory(rangeStart, rangeEnd);


//        }


//    }
//}
