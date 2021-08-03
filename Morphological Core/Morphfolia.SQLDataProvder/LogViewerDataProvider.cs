// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using Morphfolia.SQLDataProvider.Logging;
using Morphfolia.SQLDataProvider.Utilities;
using Morphfolia.IDataProvider;
using Morphfolia.Common.Info;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Morphfolia.SQLDataProvider
{
    public class LogViewerDataProvider : ILogViewer
    {
        public DataTable GetLogEntries(
            int maxNumberOfLogsToReturn,
            int eventId,
            int minimumPriority,
            string severity,
            string machineName,
            string titleFilter, 
            string messageFilter,
            DateTime loggedSince,
            DateTime loggedBefore)
        {

            if (maxNumberOfLogsToReturn < 1)
            {
                maxNumberOfLogsToReturn = 10;
            }

            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            //sql.AppendFormat("SELECT TOP {0} LogID, EventID, Priority, Severity, Title, [Timestamp], MachineName, AppDomainName, Message FROM [Log] ", maxNumberOfLogsToReturn.ToString());
            sql.AppendFormat("SELECT TOP {0} LogID, EventID, Priority, Severity, Title, [Timestamp], MachineName, AppDomainName, FormattedMessage AS Message FROM [Log] ", maxNumberOfLogsToReturn.ToString());

            sql.AppendFormat("WHERE Priority >= {0} ", minimumPriority.ToString());

            if (eventId > Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                sql.AppendFormat("AND EventID = {0} ", eventId.ToString());
            }

            if (!severity.Equals(string.Empty))
            {
                sql.AppendFormat("AND Severity = '{0}' ", severity);
            }

            if (!machineName.Equals(string.Empty))
            {
                sql.AppendFormat("AND MachineName = '{0}' ", machineName);
            }

            if (!titleFilter.Equals(string.Empty))
            {
                titleFilter = Utilities.Like.SafeLikeExpression(titleFilter);
                sql.AppendFormat("AND Title LIKE '{0}' ", titleFilter);
            }

            if (!messageFilter.Equals(string.Empty))
            {
                messageFilter = Utilities.Like.SafeLikeExpression(messageFilter);
                sql.AppendFormat("AND FormattedMessage LIKE '{0}' ", messageFilter);
            }

            if (!loggedSince.Equals(Morphfolia.Common.Constants.SystemTypeValues.NullDate))
            {
                sql.AppendFormat("AND [Timestamp] >= '{0}' ", DateTimeHelper.DateTimeStampInSQLFormat_ToMillisecond(loggedSince));
            }

            if (!loggedBefore.Equals(Morphfolia.Common.Constants.SystemTypeValues.NullDate))
            {
                sql.AppendFormat("AND [Timestamp] <= '{0}' ", DateTimeHelper.DateTimeStampInSQLFormat_ToMillisecond(loggedBefore));
            }

            sql.Append("ORDER BY [Timestamp] DESC, LogID DESC");


            DataColumn dc;
            DataRow dr;
            DataTable dt = new DataTable();

            dc = new DataColumn();
            dc.ColumnName = "LogID";
            dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "EventID";
            dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Priority";
            dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Severity";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Title";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Timestamp";
            dc.DataType = Type.GetType("System.DateTime");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "MachineName";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "AppDomainName";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "Message";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);


            //Logger.LogVerboseInformation("The SQL", sql.ToString());


            using (IDataReader dataReader = SqlDatabaseHelper.CurrentDatabase.ExecuteReader(CommandType.Text, sql.ToString()))
            {
                while (dataReader.Read())
                {
                    dr = dt.NewRow();
                    dr["LogID"] = dataReader["LogID"];
                    dr["EventID"] = dataReader["EventID"];
                    dr["Priority"] = dataReader["Priority"];
                    dr["Severity"] = dataReader["Severity"];
                    dr["Title"] = dataReader["Title"];
                    dr["Timestamp"] = dataReader["Timestamp"];
                    dr["MachineName"] = dataReader["MachineName"];
                    dr["AppDomainName"] = dataReader["AppDomainName"];
                    dr["Message"] = dataReader["Message"];     
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
    }
}