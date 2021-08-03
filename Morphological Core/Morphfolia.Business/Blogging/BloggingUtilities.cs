// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using Morphfolia.Common.Info;
using Morphfolia.Business.Constants;
using Morphfolia.IDataProvider;
using System.Collections.Specialized;

namespace Morphfolia.Business.Blogging
{
    public class BloggingUtilities
    {
        public static PageInfoCollection GetListOfAvailableBlogs()
        {
            CustomPropertyInstanceInfoCollection blogs = StaticCustomPropertyHelper.GetControlPropertiesByPropertyKey("IsBlog");

            Logging.Logger.LogVerboseInformation("BloggingUtilities, GetListOfAvailableBlogs()", string.Format("Number of blogs found: {0}", blogs.Count.ToString()));

            IntCollection pageIds = new IntCollection();
            foreach (CustomPropertyInstanceInfo blog in blogs)
            {
                pageIds.Add(blog.InstanceID);
            }

            return PageLister.List(pageIds);
        }


        /// <summary>
        /// Provides a nice 'last modified' string that includes the date posted, comparison to now, and the users name.
        /// </summary>
        /// <param name="currentPostLastModified"></param>
        /// <returns></returns>
        public static string BlogFriendlyPostedDateMessage(DateTime lastModified, string lastModifiedBy)
        {
            TimeSpan timeDiff = DateTime.Now.Subtract(lastModified);

            if (timeDiff.Days == 0)
            {
                if (timeDiff.Hours < DateTime.Now.TimeOfDay.Hours)
                {
                    return string.Format("Posted today at {0} by {3} ({1} hours and {2} minutes ago)",
                        lastModified.ToShortTimeString(),
                        timeDiff.Hours.ToString(),
                        timeDiff.Minutes.ToString(),
                        lastModifiedBy);
                }
                else
                {
                    return string.Format("Posted yesterday at {0} by {3} ({1} hours and {2} minutes ago)",
                        lastModified.ToShortTimeString(),
                        timeDiff.Hours.ToString(),
                        timeDiff.Minutes.ToString(),
                        lastModifiedBy);
                }
            }
            else
            {
                return string.Format("Posted at {0} by {4} ({1} days, {2} hours and {3} minutes ago)",
                    lastModified.ToString(),
                    timeDiff.Days.ToString(),
                    timeDiff.Hours.ToString(),
                    timeDiff.Minutes.ToString(),
                    lastModifiedBy);
            }
        }
    }
}
