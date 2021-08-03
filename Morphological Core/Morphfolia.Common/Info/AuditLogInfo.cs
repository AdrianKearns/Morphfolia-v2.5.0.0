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
    ///  Summary description for AuditLogInfo.
    /// </summary>
    public struct AuditLogInfo
    {
        public readonly int AuditLogId;
        public readonly int ObjectId;
        public readonly string ObjectType;
        public readonly string UserIdentity;
        public readonly string WindowsIdentity;
        public readonly string AppDomainName;
        public readonly DateTime WhenLogged;
        public readonly string Information;

        public AuditLogInfo(
            int auditLogId,
            int objectId,
            string objectType,
            string userIdentity,
            string windowsIdentity,
            string appDomainName,
            DateTime whenLogged,
            string information)
        {
            AuditLogId = auditLogId;
            ObjectId = objectId;
            ObjectType = objectType;
            UserIdentity = userIdentity;
            WindowsIdentity = windowsIdentity;
            AppDomainName = appDomainName;
            WhenLogged = whenLogged;
            Information = information;
        }
    }


    public class AuditLogInfoCollection : CollectionBase
    {
        public AuditLogInfo this[int index]
        {
            get { return ((AuditLogInfo)List[index]); }
            set { List[index] = value; }
        }

        public int Add(AuditLogInfo value)
        {
            return (List.Add(value));
        }

        public int IndexOf(AuditLogInfo value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, AuditLogInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(AuditLogInfo value)
        {
            List.Remove(value);
        }

        public bool Contains(AuditLogInfo value)
        {
            // If value is not of type AuditLogInfo, this will return false.
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
            if (value.GetType() != Type.GetType("Morphfolia.Common.Info.AuditLogInfo"))
                throw new ArgumentException("value must be of type Morphfolia.Common.Info.AuditLogInfo.", "value");
        }
    }

}