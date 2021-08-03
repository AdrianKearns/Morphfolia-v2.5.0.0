// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Info;
using System;

namespace Morphfolia.IDataProvider
{
    public interface IAuditorDataProvider
    {
        void LogAuditEntry(int objectId, string objectType, string auditInformation, string userIdentity, string windowsIdentity, string appDomainName);

        AuditLogInfoCollection GetAuditLogEntries(int objectId, string objectType);

        AuditLogInfoCollection Search(int objectId, string objectType, string auditInformation, string userIdentity, string windowsIdentity, string appDomainName, DateTime whenLoggedRangeStart, DateTime whenLoggedRangeEnd);


    }
}
