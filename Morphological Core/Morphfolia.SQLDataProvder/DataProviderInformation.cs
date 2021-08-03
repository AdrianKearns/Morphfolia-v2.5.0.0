// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Data.SqlClient;
using Morphfolia.Common.Constants;
using Morphfolia.Common.Info;
using Morphfolia.SQLDataProvider.Utilities;

namespace Morphfolia.SQLDataProvider
{
    public class DataProviderInformation : Morphfolia.IDataProvider.IDataProviderInformation
    {

        public string GetUsageSummary()
        {
            object[] items;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            using (DataSet ds = SqlDatabaseHelper.CurrentDatabase.ExecuteDataSet("GetUsageSummary"))
            {
                if (ds.Tables.Count == 0)
                {
                    sb.Append("No Tables.");
                }
                else
                {
                    for (int t = 0; t < ds.Tables.Count; t++)
                    {
                        if (ds.Tables[t].Rows.Count == 0)
                        {
                            sb.AppendFormat("{0}Table {1}, No rows.", Environment.NewLine, t.ToString());
                        }
                        else
                        {
                            for (int r = 0; r < ds.Tables[t].Rows.Count; r++)
                            {
                                items = ds.Tables[t].Rows[r].ItemArray;
                                if (items.Length == 0)
                                {
                                    sb.AppendFormat("{0}Table {1}, Row {2}, No data.", Environment.NewLine, t.ToString(), r.ToString());
                                }
                                else
                                {
                                    for (int i = 0; i < items.Length; i++)
                                    {
                                        //sb.AppendFormat("{0}Table {1}, Row {2}, value = {3}", Environment.NewLine, t.ToString(), r.ToString(), items[i].ToString());
                                        sb.AppendFormat("{0}{1}: {2}", Environment.NewLine, ds.Tables[t].Columns[i].ColumnName, items[i].ToString());
                                    }
                                }
                            }
                            //sb.Append(Environment.NewLine);
                        }
                        sb.Append(Environment.NewLine);
                    }
                }
            }

            return sb.ToString();
        }

    }
}
