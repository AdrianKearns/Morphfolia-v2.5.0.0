// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Morphfolia.Common.Info;
using Morphfolia.IDataProvider;
using Morphfolia.SQLDataProvider.Logging;
using Morphfolia.SQLDataProvider.Utilities;
using Morphfolia.Common.Constants;


namespace Morphfolia.SQLDataProvider
{
    public class AuditorDataProvider : IAuditorDataProvider
    {
        public void LogAuditEntry(int objectId, string objectType, string auditInformation, string userIdentity, string windowsIdentity, string appDomainName)
        {
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("AuditLog_INSERT", 
                objectId, 
                objectType, 
                userIdentity, 
                windowsIdentity, 
                appDomainName,
                auditInformation
                );
        }


        public AuditLogInfoCollection GetAuditLogEntries(int objectId, string objectType)
        {
            AuditLogInfo info;
            AuditLogInfoCollection collection = new AuditLogInfoCollection();

            try
            {
                using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                    "AuditLog_SELECT_ByIdAndType", objectId, objectType))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DateTime whenLogged;

                            try
                            {
                                whenLogged = DateTime.Parse(dr["WhenLogged"].ToString());
                            }
                            catch
                            {
                                whenLogged = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                            }

                            //Id, ObjectId, ObjectType, UserIdentity, WindowsIdentity, AppDomainName, WhenLogged, Information

                            info = new Morphfolia.Common.Info.AuditLogInfo(
                                int.Parse(dr["Id"].ToString()),
                                int.Parse(dr["ObjectId"].ToString()),
                                dr["ObjectType"].ToString(),
                                dr["UserIdentity"].ToString(),
                                dr["WindowsIdentity"].ToString(),
                                dr["AppDomainName"].ToString(),
                                whenLogged,
                                dr["Information"].ToString());
                            collection.Add(info);
                        }
                    }
                }

                return collection;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        private string SafeSearchText(string inputValue)
        {
            inputValue = inputValue.Trim();

            if (inputValue.Equals(string.Empty))
            {
                inputValue = "%";
            }
            else
            {
                inputValue = inputValue.Replace("*", "%");
            }

            return inputValue;
        }

        public AuditLogInfoCollection Search(
            int objectId, 
            string objectType, 
            string auditInformation, 
            string userIdentity, 
            string windowsIdentity, 
            string appDomainName, 
            DateTime whenLoggedRangeStart, 
            DateTime whenLoggedRangeEnd)
        {
            AuditLogInfo info;
            AuditLogInfoCollection collection = new AuditLogInfoCollection();

            // No need to do the same with start date as it is 
            // already 'early' enough for a full search.
            if(whenLoggedRangeEnd.Equals(SystemTypeValues.NullDate))
            {
                whenLoggedRangeEnd = DateTime.MaxValue;
            }




            try
            {
                using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                    "AuditLog_SELECT_Search", 
                    objectId,
                    SafeSearchText(objectType),
                    SafeSearchText(auditInformation),
                    SafeSearchText(userIdentity),
                    SafeSearchText(windowsIdentity),
                    SafeSearchText(appDomainName),
                    whenLoggedRangeStart,
                    whenLoggedRangeEnd))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            DateTime tempWhenLogged;

                            try
                            {
                                tempWhenLogged = DateTime.Parse(dr["WhenLogged"].ToString());
                            }
                            catch
                            {
                                tempWhenLogged = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                            }

                            //Id, ObjectId, ObjectType, UserIdentity, WindowsIdentity, AppDomainName, WhenLogged, Information

                            info = new Morphfolia.Common.Info.AuditLogInfo(
                                int.Parse(dr["Id"].ToString()),
                                int.Parse(dr["ObjectId"].ToString()),
                                dr["ObjectType"].ToString(),
                                dr["UserIdentity"].ToString(),
                                dr["WindowsIdentity"].ToString(),
                                dr["AppDomainName"].ToString(),
                                tempWhenLogged,
                                dr["Information"].ToString());
                            collection.Add(info);
                        }
                    }
                }

                return collection;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


    }
}
