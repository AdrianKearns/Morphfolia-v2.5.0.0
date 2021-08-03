// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Morphfolia.Common.Utilities
{
    public class DateTimeHelper
    {
        public class MonthNamesAbbrev
        {
            public const string Jan = "Jan";
            public const string Feb = "Feb";
            public const string Mar = "Mar";
            public const string Apr = "Apr";
            public const string May = "May";
            public const string Jun = "Jun";
            public const string Jul = "Jul";
            public const string Aug = "Aug";
            public const string Sep = "Sep";
            public const string Oct = "Oct";
            public const string Nov = "Nov";
            public const string Dec = "Dec";
        }


        public static string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return MonthNamesAbbrev.Jan;
                case 2:
                    return MonthNamesAbbrev.Feb;
                case 3:
                    return MonthNamesAbbrev.Mar;
                case 4:
                    return MonthNamesAbbrev.Apr;
                case 5:
                    return MonthNamesAbbrev.May;
                case 6:
                    return MonthNamesAbbrev.Jun;
                case 7:
                    return MonthNamesAbbrev.Jul;
                case 8:
                    return MonthNamesAbbrev.Aug;
                case 9:
                    return MonthNamesAbbrev.Sep;
                case 10:
                    return MonthNamesAbbrev.Oct;
                case 11:
                    return MonthNamesAbbrev.Nov;
                case 12:
                    return MonthNamesAbbrev.Dec;
                default:
                    return string.Empty;
            }
        }


        /// <summary>
        /// Returns the date in DD-MMM-YYYY format.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DDMMMYYYY(DateTime date)
        {            
            return string.Format("{0}-{1}-{2}",
                date.Day.ToString(),
                GetMonthName(date.Month),
                date.Year.ToString());
        }


        /// <summary>
        /// Output format is YYYYMMDDHHMMSS
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string YYYYMMDDHHMMSS(DateTime date)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}",
                NumberToTwoCharString(date.Year),
                NumberToTwoCharString(date.Month),
                NumberToTwoCharString(date.Day),
                NumberToTwoCharString(date.Hour),
                NumberToTwoCharString(date.Minute),
                NumberToTwoCharString(date.Second));
        }


        /// <summary>
        /// Output format is YYYY-MM-DD HH-MM-SS
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string YYYYMMDDHHMMSS_HumanReadable(DateTime date)
        {
            return string.Format("{0}-{1}-{2} {3}-{4}-{5}",
                NumberToTwoCharString(date.Year),
                NumberToTwoCharString(date.Month),
                NumberToTwoCharString(date.Day),
                NumberToTwoCharString(date.Hour),
                NumberToTwoCharString(date.Minute),
                NumberToTwoCharString(date.Second));
        }




        /// <summary>
        /// Formats a given date in an RSS 2.0 (pubDate) friendly format.
        /// </summary>
        /// <param name="date">The datetime to format.</param>
        /// <param name="timeZoneDifference">The time zone difference, e.g "NZST" for New Zealand Standard Time.</param>
        /// <returns>datetime as a string, e.g: Mon, 28 Apr 2008 11:20:02 NZST</returns>
        public static string ToRSS20Format(DateTime date, string timeZoneDifference)
        {
            return string.Format("{0} {1}",
                date.ToString("ddd, d MMM yyyy hh:mm:ss", CultureInfo.InvariantCulture),
                timeZoneDifference);
        }


        /// <summary>
        /// Formats a given date in an Atom 1.0 (updated) friendly format.
        /// </summary>
        /// <param name="date">The datetime to format.</param>
        /// <param name="timeZoneDifference">The time zone difference, e.g "+1200" for New Zealand Standard Time, 
        /// in RFC3339 format (see www.faqs.org/rfcs/rfc3339.html).</param>
        /// <returns>datetime as a string, e.g: 2002-10-02T10:00:00-05:00</returns>
        public static string ToAtom10Format(DateTime date, string timeZoneDifference)
        {
            return string.Format("{0}{1}",
                date.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                timeZoneDifference);
        }



        /// <summary>
        /// Ensures that numbers less than 10 are returned with a leading 0.
        /// </summary>
        /// <example>0 = "00", 6 = "06", etc</example>
        /// <param name="someNumber"></param>
        /// <returns></returns>
        public static string NumberToTwoCharString(int someNumber)
        {
            if (someNumber > 9)
            {
                return someNumber.ToString();
            }

            if ((someNumber > 0) & (someNumber < 10))
            {
                return string.Format("0{0}", someNumber.ToString());
            }

            if (someNumber == 0)
            {
                return "00";
            }

            // should not get here.
            return someNumber.ToString();
        }
    }
}
