// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.Business.Logging
{
    internal class Logger
    {
        public static void LogVerboseInformation(string title, string message)
        {
            Morphfolia.Common.Logging.Logger.LogVerboseInformation(
                title,
                message,
                EventIds.Information,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }

        public static void LogVerboseInformation(string title, string message, int eventId)
        {
            Morphfolia.Common.Logging.Logger.LogVerboseInformation(
                title,
                message,
                eventId,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }



        public static void LogInformation(string title, string message)
        {
            Morphfolia.Common.Logging.Logger.LogInformation(
                title,
                message,
                EventIds.Information,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }

        public static void LogInformation(string title, string message, int eventId)
        {
            Morphfolia.Common.Logging.Logger.LogInformation(
                title,
                message,
                eventId,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }





        public static void LogAlertInformation(string title, string message)
        {
            Morphfolia.Common.Logging.Logger.LogAlertInformation(
                title,
                message,
                EventIds.Information,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }

        public static void LogAlertInformation(string title, string message, int eventId)
        {
            Morphfolia.Common.Logging.Logger.LogAlertInformation(
                title,
                message,
                eventId,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }




        public static void LogWarning(string title, string message)
        {
            Morphfolia.Common.Logging.Logger.LogWarning(
                title,
                message,
                EventIds.Warning,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }

        public static void LogWarning(string title, string message, int eventId)
        {
            Morphfolia.Common.Logging.Logger.LogWarning(
                title,
                message,
                eventId,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }



        public static void LogException(string title, Exception ex)
        {
            Morphfolia.Common.Logging.Logger.LogException(
                title,
                ex,
                EventIds.Error,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }

        public static void LogException(string title, Exception ex, int eventId)
        {
            Morphfolia.Common.Logging.Logger.LogException(
                title,
                ex,
                eventId,
                Morphfolia.Common.Logging.Categories.BusinessLogic);
        }

        public static void LogException(string title, Exception ex, int eventId, string additionalExceptionInformation)
        {
            Morphfolia.Common.Logging.Logger.LogException(
                title,
                ex,
                eventId,
                Morphfolia.Common.Logging.Categories.BusinessLogic,
                additionalExceptionInformation);
        }




    }
}
