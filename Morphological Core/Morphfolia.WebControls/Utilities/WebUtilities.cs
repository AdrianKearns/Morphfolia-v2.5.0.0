// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web;

namespace Morphfolia.WebControls.Utilities
{
    public class WebUtilities
    {
        public static readonly string http = "http://";
        public static readonly string https = "https://";


        /// <summary>
        /// A one stop shop for providing the fully qualified root of the 
        /// application regardless of whether it's a virtual 
        /// directory (such as during development) or a full blown website.
        /// </summary>
        /// <returns>the fully qualified URL of the application.</returns>
        /// <remarks>A trailing / is not returned.</remarks>
        public static string FullyQualifiedApplicationRoot()
        {
            string protocol;


           

            if (HttpContext.Current.Request.IsSecureConnection)
            {
                protocol = "https://";
            }
            else
            {
                protocol = "http://";
            }


            if (HttpContext.Current.Request.ApplicationPath.Equals("/"))
            {
                // Application is operating as a site: 

                //ApplicationPath = [/]
                //Url = [http://www.ila.org.nz/_publishing/page_management.aspx]
                //ToString = [System.Web.HttpRequest]
                //Path = [/_publishing/page_management.aspx]
                //server_name = [www.ila.org.nz]

                return string.Format("{0}{1}",
                    protocol,
                    HttpContext.Current.Request.ServerVariables["server_name"].ToString());
            }
            else
            {
                // Application is operating in a virtual root: 

                //ApplicationPath = [/Morphfolia.Web]
                //Url = [http://localhost/Morphfolia.web/_publishing/page_management.aspx]
                //ToString = [System.Web.HttpRequest]
                //Path = [/Morphfolia.web/_publishing/page_management.aspx]
                //server_name = [localhost]

                return string.Format("{0}{1}{2}",
                    protocol,
                    HttpContext.Current.Request.ServerVariables["server_name"].ToString(),
                    HttpContext.Current.Request.ApplicationPath);
            }
        }




        public static string GetDerivedPageUrl()
        {
            HttpContext httpContext = HttpContext.Current;

            string rawUrl = httpContext.Request.RawUrl;
            string fullPageUrl = rawUrl;
            string derivedPageUrl;

            if (!fullPageUrl.StartsWith("http"))
            {
                fullPageUrl = string.Format("http://{0}{1}", httpContext.Request.ServerVariables["SERVER_NAME"].ToString(), rawUrl).ToLower();
            }
            derivedPageUrl = fullPageUrl;

            string fullyQualifiedApplicationRoot = WebUtilities.FullyQualifiedApplicationRoot().ToLower();

            if (derivedPageUrl.IndexOf(fullyQualifiedApplicationRoot) > -1)
            {
                derivedPageUrl = derivedPageUrl.Substring(fullyQualifiedApplicationRoot.Length);
            }

            // Ensure that no leading / are in front of the url (as they aren't stored in the DB): 			
            if (derivedPageUrl.StartsWith("/"))
            {
                derivedPageUrl = derivedPageUrl.Substring(1);
            }

            // Strip off the query string when attempting to page:
            if (derivedPageUrl.IndexOf("?") > -1)
            {
                derivedPageUrl = derivedPageUrl.Substring(0, derivedPageUrl.IndexOf("?"));
            }

            return derivedPageUrl;
        }



        /// <summary>
        /// A one stop shop for providing the virtual root of the 
        /// application regardless of whether it's a virtual 
        /// directory (such as during development) or a full blown website. 
        /// A trailing / is not returned.
        /// </summary>
        /// <returns>Either the virtual root (preceeded by a /) or an empty string.</returns>
        /// <remarks>A trailing / is not returned.</remarks>
        public static string VirtualApplicationRoot()
        {
            if (HttpContext.Current == null)
            {
                return string.Empty;
            }
            else
            {
                if (HttpContext.Current.Request.ApplicationPath.Equals("/"))
                {
                    // Application is operating as a site: 
                    return string.Empty;
                }
                else
                {
                    // Application is operating in a virtual root: 
                    return HttpContext.Current.Request.ApplicationPath;
                }
            }
        }


        /// <summary>
        /// Gets the requested value or returns an empty string.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static string GetRequestParamValue(string paramName)
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

            return string.Empty;
        }




    }
}
