// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using Morphfolia.IDataProvider;
using Morphfolia.Business.Constants;
using System.IO;

namespace Morphfolia.Business.Logs
{
    public class SystemLogs
    {
        private static ILogViewer iLogViewer;

        public static DataTable GetLogEntries(SystemLogQuery systemLogQuery)
        {
            iLogViewer = (ILogViewer)Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.ILogViewer);
            return iLogViewer.GetLogEntries(
                systemLogQuery.MaxNumberOfLogsToReturn,
                systemLogQuery.EventId,
                systemLogQuery.MinimumPriority,
                systemLogQuery.Severity,
                systemLogQuery.MachineName,
                systemLogQuery.TitleFilter,
                systemLogQuery.MessageFilter,
                systemLogQuery.RangeStart,
                systemLogQuery.RangeEnd);
        }


        public static string SaveLogEntriesToDisk(DataTable logEntries, string destinationFolderPath)
        {
            try
            {
                if (logEntries.Rows.Count == 0)
                {
                    throw new NotImplementedException("No log records found to save - not sure what to do now.");
                }
                else
                {
                    string filename = string.Empty;
                    object[] itemArray1;
                    object[] itemArray2;
                    DateTime dt1;
                    DateTime dt2;

                    if (logEntries.Rows.Count == 1)
                    {
                        itemArray1 = logEntries.Rows[0].ItemArray;

                        dt1 = (DateTime)itemArray1.GetValue(5);

                        filename = string.Format("System Log item {0) Logged {1}.csv",
                            Common.Utilities.DateTimeHelper.DDMMMYYYY(dt1),
                            Common.Utilities.DateTimeHelper.YYYYMMDDHHMMSS_HumanReadable(DateTime.Now));
                    }
                    else
                    {
                        itemArray1 = logEntries.Rows[0].ItemArray;
                        itemArray2 = logEntries.Rows[logEntries.Rows.Count - 1].ItemArray;
                        
                        dt1 = (DateTime)itemArray1.GetValue(5);
                        dt2 = (DateTime)itemArray2.GetValue(5);

                        filename = string.Format("System Logs from {0} to {1} - {2} Items Logged {3}.csv",
                            Common.Utilities.DateTimeHelper.DDMMMYYYY(dt2),
                            Common.Utilities.DateTimeHelper.DDMMMYYYY(dt1),
                            logEntries.Rows.Count.ToString(),
                            Common.Utilities.DateTimeHelper.YYYYMMDDHHMMSS_HumanReadable(DateTime.Now));
                    }

                    string fullFilename = string.Format(@"{0}/{1}",
                        destinationFolderPath,
                        filename);                    

                    string temp;

                    using (StreamWriter sw = new StreamWriter(fullFilename))
                    {
                        for (int r = 0; r < logEntries.Rows.Count; r++)
                        {
                            itemArray1 = logEntries.Rows[r].ItemArray;

                            temp = itemArray1[8].ToString().Replace(",", ".");
                            temp = temp.Replace(Environment.NewLine, " ");

                            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                itemArray1[0].ToString(),
                                itemArray1[1].ToString(),
                                itemArray1[2].ToString(),
                                itemArray1[3].ToString(),
                                itemArray1[4].ToString().Replace(",", "."),
                                itemArray1[5].ToString(),
                                itemArray1[6].ToString(),
                                itemArray1[7].ToString(),
                                temp);
                        }
                    }

                    return filename;

                    //string downloadUrl = string.Format(@"{0}/{1}/{2}",
                    //    WebUtilities.VirtualApplicationRoot(),
                    //    Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath,
                    //    filename);

                    //return string.Format("Logs saved to the File Manager as {0}.", filename);
                }
            }
            catch (Exception ex)
            {
                Logging.Logger.LogException("SaveLogEntriesToDisk() failed.", ex);
                return "Save Log Entries Failed - see system logs.";
            }
        }


    }
}
