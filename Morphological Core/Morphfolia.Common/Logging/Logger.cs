// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Morphfolia.Common.Logging
{
    public class Logger
    {
        public static void LogVerboseInformation(string title, string message)
        {
            Log(
                title,
                message,
                Common.Logging.EventIds.Default.Information,
                System.Diagnostics.TraceEventType.Verbose,
                Common.Logging.Priorities.VerboseDebugging,
                Common.Logging.Categories.General);
        }

        public static void LogVerboseInformation(string title, string message, int eventId)
        {
            Log(
                title,
                message,
                eventId,
                System.Diagnostics.TraceEventType.Verbose,
                Common.Logging.Priorities.VerboseDebugging,
                Common.Logging.Categories.General);
        }

        public static void LogVerboseInformation(string title, string message, int eventId, string category)
        {
            Log(
                title,
                message,
                eventId,
                System.Diagnostics.TraceEventType.Verbose,
                Common.Logging.Priorities.VerboseDebugging,
                category);
        }


        public static void LogInformation(string title, string message)
        {
            Log(
                title, 
                message, 
                Common.Logging.EventIds.Default.Information, 
                System.Diagnostics.TraceEventType.Information,
                Common.Logging.Priorities.Normal,
                Common.Logging.Categories.General);
        }

        public static void LogInformation(string title, string message, int eventId)
        {
            Log(
                title,
                message,
                eventId,
                System.Diagnostics.TraceEventType.Information,
                Common.Logging.Priorities.Normal,
                Common.Logging.Categories.General);
        }

        public static void LogInformation(string title, string message, int eventId, string category)
        {
            Log(
                title,
                message,
                eventId,
                System.Diagnostics.TraceEventType.Information,
                Common.Logging.Priorities.Normal,
                category);
        }





        public static void LogAlertInformation(string title, string message)
        {
            Log(
                title,
                message,
                Common.Logging.EventIds.Default.Information,
                System.Diagnostics.TraceEventType.Information,
                Common.Logging.Priorities.Alert,
                Common.Logging.Categories.General);
        }

        public static void LogAlertInformation(string title, string message, int eventId)
        {
            Log(
                title,
                message,
                eventId,
                System.Diagnostics.TraceEventType.Information,
                Common.Logging.Priorities.Alert,
                Common.Logging.Categories.General);
        }

        public static void LogAlertInformation(string title, string message, int eventId, string category)
        {
            Log(
                title,
                message,
                eventId,
                System.Diagnostics.TraceEventType.Information,
                Common.Logging.Priorities.Alert,
                category);
        }




        ////?
        //public static void LogInformation(string title, string message, string category)
        //{
        //    Log(
        //        title,
        //        message,
        //        Common.Logging.EventIds.Default.Information,
        //        System.Diagnostics.TraceEventType.Information,
        //        Common.Logging.Priorities.Normal,
        //        category);
        //}


        ////?
        //public static void LogInformation(string title, string message, string category, int eventId)
        //{
        //    Log(
        //        title,
        //        message,
        //        eventId,
        //        System.Diagnostics.TraceEventType.Information,
        //        Common.Logging.Priorities.Normal,
        //        category);
        //}

        public static void LogWarning(string title, string message)
        {
            Log(
                title,
                message,
                Common.Logging.EventIds.Default.Warning,
                System.Diagnostics.TraceEventType.Warning,
                Common.Logging.Priorities.Warnings,
                Common.Logging.Categories.General);
        }

        public static void LogWarning(string title, string message, int eventId)
        {
            Log(
                title,
                message,
                eventId,
                System.Diagnostics.TraceEventType.Warning,
                Common.Logging.Priorities.Warnings,
                Common.Logging.Categories.General);
        }

        public static void LogWarning(string title, string message, int eventId, string category)
        {
            Log(
                title,
                message,
                eventId,
                System.Diagnostics.TraceEventType.Warning,
                Common.Logging.Priorities.Warnings,
                category);
        }



        public static void LogException(string title, string exceptionInformation)
        {
            Logger.Log(
                title, 
                exceptionInformation, 
                Logging.EventIds.Default.Error, 
                System.Diagnostics.TraceEventType.Error, 
                Logging.Priorities.Exceptions, 
                Logging.Categories.General);
        }

        public static void LogException(string title, string exceptionInformation, int eventId)
        {
            Logger.Log(
                title, 
                exceptionInformation, 
                eventId, 
                System.Diagnostics.TraceEventType.Error, 
                Logging.Priorities.Exceptions, 
                Logging.Categories.General);
        }

        public static void LogException(string title, string exceptionInformation, int eventId, string category)
        {
            Logger.Log(
                title, 
                exceptionInformation, 
                eventId, 
                System.Diagnostics.TraceEventType.Error, 
                Logging.Priorities.Exceptions, category);
        }

        public static void LogException(string title, Exception ex)
        {
            Logger.Log(
                title, 
                ExceptionDetailHelper.PublishException(ex), 
                Logging.EventIds.Default.Error, 
                System.Diagnostics.TraceEventType.Error, 
                Logging.Priorities.Exceptions, 
                Logging.Categories.General);
        }

        public static void LogException(string title, Exception ex, int eventId)
        {
            Logger.Log(title, ExceptionDetailHelper.PublishException(ex), eventId, System.Diagnostics.TraceEventType.Error, Logging.Priorities.Exceptions, Logging.Categories.General);
        }

        public static void LogException(string title, Exception ex, int eventId, string category)
        {
            Logger.Log(
                title, 
                ExceptionDetailHelper.PublishException(ex), 
                eventId, 
                System.Diagnostics.TraceEventType.Error, 
                Logging.Priorities.Exceptions,
                category);
        }

        public static void LogException(string title, Exception ex, int eventId, string category, string additionalExceptionInformation)
        {
            Logger.Log(
                title,
                ExceptionDetailHelper.PublishException(ex, additionalExceptionInformation), 
                eventId, 
                System.Diagnostics.TraceEventType.Error, 
                Logging.Priorities.Exceptions,
                category);
        }


        /// <summary>
        /// Performs the actual logging call.
        /// </summary>
        /// <param name="title">string</param>
        /// <param name="message">string</param>
        /// <param name="eventId">int</param>
        /// <param name="severity">System.Diagnostics.TraceEventType</param>
        /// <param name="priority">int</param>
        /// <param name="category">string</param>
        private static void Log(string title, string message, int eventId, System.Diagnostics.TraceEventType severity, int priority, string category)
        {

                LogEntry logEntry = new LogEntry();

                logEntry.Categories.Add(category);
                logEntry.Priority = priority;
                logEntry.Severity = severity;
                logEntry.Message = message;
                logEntry.Title = title;
                logEntry.EventId = eventId;

                Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logEntry);
            
        }
    }


    /// <summary>
    /// A replacement for the functionailty previously provided by version 1 of the App Blocks.
    /// </summary>
    public class ExceptionManager
    {

        public static void PublishAsWarning(Exception exception, int eventId)
        {
            StringBuilder sb = new StringBuilder();
            AppendExceptionDetailToStringBuilder(exception, sb);
            Logger.LogWarning(exception.Message, sb.ToString(), eventId);
        }



        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">Exception</param>
        public static void Publish(Exception exception, int eventId)
        {
            StringBuilder sb = new StringBuilder();
            AppendExceptionDetailToStringBuilder(exception, sb);
            Logger.LogException(exception.Message, sb.ToString(), eventId);
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="additionalInfo">NameValueCollection</param>
        public static void Publish(Exception exception, int eventId, NameValueCollection additionalInfo)
        {
            StringBuilder sb = new StringBuilder();
            AppendExceptionDetailToStringBuilder(exception, sb);
            AppendExceptionDetailToNameValueCollection(additionalInfo, sb);
            Logger.LogException(exception.Message, sb.ToString(), eventId);
        }

        /// <summary>
        /// Unwinds an Exceptions detail into a StringBuilder.
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="sb">StringBuilder</param>
        public static void AppendExceptionDetailToStringBuilder(Exception exception, StringBuilder sb)
        {
            Exception innerException;

            sb.AppendFormat("Exception: {1}{0}Type: {2}{0}Source: {3}", 
                Environment.NewLine, 
                exception.Message, 
                exception.GetType().ToString(), 
                exception.Source);
            sb.AppendFormat("{0}{0}{1}", Environment.NewLine, exception.StackTrace);

            innerException = exception.InnerException;
            while (innerException != null)
            {
                sb.AppendFormat("{0}{0}{0}InnerException: {1}{0}Type: {2}{0}Source: {3}", 
                    Environment.NewLine, 
                    innerException.Message, 
                    innerException.GetType().ToString(), 
                    innerException.Source);
                sb.AppendFormat("{0}{1}", Environment.NewLine, innerException.StackTrace);
                innerException = innerException.InnerException;
            }
        }

        /// <summary>
        /// Unwinds a NameValueCollection into a StringBuilder.
        /// </summary>
        /// <param name="additionalInfo">NameValueCollection</param>
        /// <param name="sb">StringBuilder</param>
        public static void AppendExceptionDetailToNameValueCollection(NameValueCollection additionalInfo, StringBuilder sb)
        {
            string[] keys = additionalInfo.AllKeys;
            if (keys.Length > 0)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    sb.AppendFormat("{0}{1} = {2}", Environment.NewLine, keys[i].ToString(), additionalInfo[i].ToString());
                }
            }
        }
    }

    public class ExceptionDetailHelper
    {
        public static string PublishException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            PublishInnerException(ex, sb);
            return sb.ToString();
        }

        public static string PublishException(Exception ex, string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}{1}", msg, Environment.NewLine);
            PublishInnerException(ex, sb);
            return sb.ToString();
        }

        public static void PublishInnerException(Exception ex, StringBuilder sb)
        {
            Exception innerException;

            sb.AppendFormat("{0}{1}", ex.GetType().ToString(), Environment.NewLine);
            sb.AppendFormat("-----------------------------------------------------------------------------{0}", Environment.NewLine);
            sb.AppendFormat("{0}{1}", ex.Message, Environment.NewLine);
            sb.AppendFormat("{0}{1}", ex.Source, Environment.NewLine);
            sb.AppendFormat("{0}{1}{1}", ex.StackTrace, Environment.NewLine);

            innerException = ex.InnerException;

            while (innerException != null)
            {
                PublishInnerException(innerException, sb);
                innerException = innerException.InnerException;
            }
        }
    }

}
