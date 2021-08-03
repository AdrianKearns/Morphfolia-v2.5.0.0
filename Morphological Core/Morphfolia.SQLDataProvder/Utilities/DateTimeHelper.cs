// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;

namespace Morphfolia.SQLDataProvider.Utilities
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class DateTimeHelper
    {
        /// <summary>
        /// Outputs the time in SQL Format: 2008-07-12 20:38:22.923
        /// </summary>
        /// <returns></returns>
        public static string DateTimeStampInSQLFormat_ToMillisecond(DateTime dateTimeToFormat)
        {
            //Logging.Logger.LogVerboseInformation("DateTimeStampInSQLFormat_ToMillisecond", string.Format("DateTime passed in: {0}", dateTimeToFormat.ToString()), 666);

            return string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}",
                dateTimeToFormat.Year.ToString(),
                dateTimeToFormat.Month.ToString(),
                dateTimeToFormat.Day.ToString(),
                dateTimeToFormat.Hour.ToString(),
                dateTimeToFormat.Minute.ToString(),
                dateTimeToFormat.Second.ToString(),
                dateTimeToFormat.Millisecond.ToString()
            );
        }

        /// <summary>
        /// Outputs the time in SQL Format: 2008-07-12
        /// </summary>
        /// <returns></returns>
        public static string DateInSQLFormat(DateTime dateTimeToFormat)
        {
            return string.Format("{0}-{1}-{2}",
                dateTimeToFormat.Year.ToString(),
                dateTimeToFormat.Month.ToString(),
                dateTimeToFormat.Day.ToString()
            );
        }


        /// <summary>
        /// Attempts to parse the value of the cell to a datetime, on error will return the NullDate constant value.
        /// </summary>
        /// <param name="expectedDateTimeValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromDataRowItem(object expectedDateTimeValue)
        {
            DateTime result = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
            DateTime.TryParse(expectedDateTimeValue.ToString(), out result);
            return result;
        }
    }
}
