// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 


namespace Morphfolia.WebControls.Utilities
{
    public class HttpRequestHelper
    {
        public static string GetRequestQueryStringValue(string keyName)
        {
            System.Web.HttpContext currentHttpContext = System.Web.HttpContext.Current;
            string[] keys = currentHttpContext.Request.QueryString.AllKeys;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].Equals(keyName))
                {
                    return currentHttpContext.Request.QueryString[i].ToString();
                }
            }

            return string.Empty;
        }


        public static string GetRequestParamValue(string paramName)
        {
            return GetRequestParamValue(paramName, string.Empty);
        }

        public static string GetRequestParamValue(string paramName, string valueToUseIfNotFound)
        {
            System.Web.HttpContext currentHttpContext = System.Web.HttpContext.Current;
            string[] keys = currentHttpContext.Request.Params.AllKeys;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].Equals(paramName))
                {
                    return currentHttpContext.Request.Params[i].ToString();
                }
            }

            return valueToUseIfNotFound;
        }
    }
}
