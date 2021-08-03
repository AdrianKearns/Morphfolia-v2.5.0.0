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
    /// Wraps all the arguments that can be used to invoke a search query aganist the Audit Logs.
	/// </summary>
    public struct AuditLogQuery : IUberLogQuery
	{
		public readonly int ObjectId;
		public readonly string ObjectType;
		public readonly string AuditInformation;
		public readonly string UserIdentity;
		public readonly string WindowsIdentity;
		public readonly string AppDomainName;
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

        public AuditLogQuery(
            DateTime whenLoggedRangeStart,
            DateTime whenLoggedRangeEnd)
        {
            ObjectId = Common.Constants.SystemTypeValues.NullInt;
            ObjectType = string.Empty;
            AuditInformation = string.Empty;
            UserIdentity = string.Empty;
            WindowsIdentity = string.Empty;
            AppDomainName = string.Empty;
            WhenLoggedRangeStart = whenLoggedRangeStart;
            WhenLoggedRangeEnd = whenLoggedRangeEnd;
        }

		public AuditLogQuery(
			int objectId,
			string objectType,
			string auditInformation,
			string userIdentity,
			string windowsIdentity,
			string appDomainName,
			DateTime whenLoggedRangeStart,
			DateTime whenLoggedRangeEnd)
		{
			ObjectId = objectId;
			ObjectType = objectType;
			AuditInformation = auditInformation;
			UserIdentity = userIdentity;
			WindowsIdentity = windowsIdentity;
			AppDomainName = appDomainName;
			WhenLoggedRangeStart = whenLoggedRangeStart;
			WhenLoggedRangeEnd = whenLoggedRangeEnd;
		}
	}
}