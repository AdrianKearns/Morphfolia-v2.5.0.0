// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Business.Constants;
using Morphfolia.Common.Info;
using Morphfolia.IDataProvider;
using Morphfolia.Common.Constants;

namespace Morphfolia.Business.Logs
{
    /// <summary>
    /// Defines core system object identifiers (objectTypes) for auditing purposes.
    /// </summary>
    public class AuditableObjects
    {
        public const string Page = "Page";
        public const string ContentItem = "Content Item";
        public const string SearchIndex = "SearchIndex";
        public const string UnwantedWords = "UnwantedWords";
        public const string FileOrImage = "FileOrImage";
        public const string User = "User";
        public const string Role = "Role";
        public const string Login = "Login";
    }


    public class Auditor
    {
        /// <summary>
        /// Uses "Morphfolia.Common.Constants.SystemTypeValues.NullInt" under the hood.
        /// </summary>
        public const int ObjectIdUnknown = SystemTypeValues.NullInt;

        private static IAuditorDataProvider iAuditorDateProvider = null;

        internal static IAuditorDataProvider IAuditorDateProvider
        {
            get
            {
                if (iAuditorDateProvider == null)
                {
                    iAuditorDateProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IAuditorDataProvider) as IAuditorDataProvider;
                }
                return iAuditorDateProvider;
            }
        }


        public static void LogAuditEntry(int objectId, string objectType, string auditInformation)
        {
            LogAuditEntry(objectId, objectType, auditInformation, string.Empty);
        }

        public static void LogAuditEntry(int objectId, string objectType, string auditInformation, string userIdentity)
        {
            if (userIdentity.Trim().Equals(string.Empty))
            {
                userIdentity = "[?]";

                if (System.Web.HttpContext.Current != null)
                {
                    userIdentity = System.Web.HttpContext.Current.User.Identity.Name;
                    if (userIdentity.Equals(string.Empty))
                    {
                        userIdentity = "[Anonymous]";
                    }
                }
            }


            try
            {
                IAuditorDateProvider.LogAuditEntry(objectId, 
                    objectType, 
                    auditInformation,
                    userIdentity, 
                    System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                    AppDomain.CurrentDomain.FriendlyName);
            }
            catch (Exception ex)
            {
                Logging.Logger.LogException("LogAuditEntry failed", ex, Logging.EventIds._4300,
                    string.Format("objectId: {1}{0}objectType: {2}{0}User Identity: {3}{0}WindowsIdentity: {4}{0}AppDomain: {5}{0}auditInformation: {6}", 
                    Environment.NewLine, 
                    objectId.ToString(), 
                    objectType, 
                    userIdentity, 
                    System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                    AppDomain.CurrentDomain.FriendlyName,
                    auditInformation));
            }
        }


        /// <summary>
        /// Use to bring back log entries for a specific object (by id and type).
        /// For example Page 24 (24, "Page").
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public static AuditLogInfoCollection ViewAuditLogs(int objectId, string objectType)
        {
            return IAuditorDateProvider.GetAuditLogEntries(objectId, objectType);
        }
    }



    public class AuditLogs
    {
        private static IAuditorDataProvider iAuditorDateProvider = null;

        internal static IAuditorDataProvider IAuditorDateProvider
        {
            get
            {
                if (iAuditorDateProvider == null)
                {
                    iAuditorDateProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IAuditorDataProvider) as IAuditorDataProvider;
                }
                return iAuditorDateProvider;
            }
        }

        public static AuditLogInfoCollection SearchAuditLogs(
            int objectId, 
            string objectType, 
            string auditInformation, 
            string userIdentity, 
            string windowsIdentity, 
            string appDomainName, 
            DateTime WhenLoggedRangeStart, 
            DateTime whenLoggedRangeEnd)
        {
            return IAuditorDateProvider.Search(
                objectId, 
                objectType, 
                auditInformation,
                userIdentity, 
                windowsIdentity, 
                appDomainName,
                WhenLoggedRangeStart, 
                whenLoggedRangeEnd);
        }


        public static AuditLogInfoCollection SearchAuditLogs(AuditLogQuery auditLogQuery)
        {
            return IAuditorDateProvider.Search(
                auditLogQuery.ObjectId,
                auditLogQuery.ObjectType,
                auditLogQuery.AuditInformation,
                auditLogQuery.UserIdentity,
                auditLogQuery.WindowsIdentity,
                auditLogQuery.AppDomainName,
                auditLogQuery.RangeStart,
                auditLogQuery.RangeEnd);
        }




        /// <summary>
        /// Use to bring back log entries for a specific object (by id and type).
        /// For example Page 24 (24, "Page").
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public static AuditLogInfoCollection ViewAuditLogs(int objectId, string objectType)
        {
            return IAuditorDateProvider.GetAuditLogEntries(objectId, objectType);
        }
    }
}
