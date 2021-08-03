// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web;
using Morphfolia.Common.Attributes;

namespace Morphfolia.PublishingSystem.HttpHandlers.Helpers
{
    /// <summary>
    /// Summary description for TracingHelper
    /// </summary>
    public class TracingHelper
    {
        public static void WriteAllParams(HttpContext httpContext)
        {
            System.Collections.Specialized.NameValueCollection currentParams = httpContext.Request.Params;
            string[] keys = currentParams.AllKeys;
            httpContext.Response.Write("<h5>All Params:</h5><pre>");
            for (int i = 0; i < keys.Length; i++)
            {
                httpContext.Response.Write(string.Format("{1} =\t\t{2}{0}", Environment.NewLine, keys[i].ToString(), currentParams[i].ToString()));
            }
            httpContext.Response.Write("</pre>");
        }

        public static void WriteAllQueryStrings(HttpContext httpContext)
        {
            System.Collections.Specialized.NameValueCollection currentParams = httpContext.Request.QueryString;
            string[] keys = currentParams.AllKeys;
            httpContext.Response.Write("<h5>All QueryStrings:</h5><pre>");
            for (int i = 0; i < keys.Length; i++)
            {
                httpContext.Response.Write(string.Format("{1} =\t\t{2}{0}", Environment.NewLine, keys[i].ToString(), currentParams[i].ToString()));
            }
            httpContext.Response.Write("</pre>");
        }

        public static void WriteAllForms(HttpContext httpContext)
        {
            System.Collections.Specialized.NameValueCollection currentParams = httpContext.Request.Form;
            string[] keys = currentParams.AllKeys;
            httpContext.Response.Write("<h5>All Forms:</h5><pre>");
            for (int i = 0; i < keys.Length; i++)
            {
                httpContext.Response.Write(string.Format("{1} =\t\t{2}{0}", Environment.NewLine, keys[i].ToString(), currentParams[i].ToString()));
            }
            httpContext.Response.Write("</pre>");
        }
    }
}