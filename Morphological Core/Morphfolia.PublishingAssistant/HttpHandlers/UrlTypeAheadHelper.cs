// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using System.Web;
using System.Xml;
using Morphfolia.Common.Logging;
using Morphfolia.Common.Attributes;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// Summary description for UrlTypeAheadHelper.
	/// </summary>
    [IsHttpHandler("Provides a list of page URLs (in XML) where the start of the URL matches the 'urlHint' passed in.  You can use it to find similarly names pages/URLs.  Intended for admin use only.")]
	public class UrlTypeAheadHelper : IHttpHandler
	{
        [IsHttpHandlerParameter("urlHint", "A string, representing a URL possibly known to the system.")]
		public readonly string urlHintKey = "urlHint";

		public readonly string urlSegmentKey = "urlSegment";
		private string urlHint = string.Empty;


		public void ProcessRequest( HttpContext httpContext )
		{
			try
			{
                if (httpContext.Request.QueryString[urlHintKey] != null)
				{
                    if (httpContext.Request.QueryString[urlHintKey].ToString() != "")
					{
                        urlHint = httpContext.Request.QueryString[urlHintKey].ToString();
					}
				}

				StringCollection matchingUrls = Morphfolia.Business.PageUrlTypeAheadHelper.List( urlHint );


				httpContext.Response.ContentType = "application/xml";
				XmlTextWriter xw = new XmlTextWriter(httpContext.Response.OutputStream, new System.Text.UTF8Encoding());

				xw.WriteStartElement("UrlSegments");
				xw.WriteAttributeString("ResultCount", matchingUrls.Count.ToString());

				if( matchingUrls.Count == 0 )
				{
					xw.WriteStartElement(urlSegmentKey);
					xw.WriteString( "None Found" );
					xw.WriteEndElement();
				}
				else
				{
					foreach( String s in matchingUrls )
					{
						xw.WriteStartElement(urlSegmentKey);
						xw.WriteString( s );
						xw.WriteEndElement();
					}
				}
				xw.WriteEndElement();
				xw.Close();	
			}
			catch( System.Exception ex )
			{
                Logger.LogException("UrlTypeAheadHelper", ex);
                //Morphological.Utilities.HttpHandlerHelper.WriteExceptionAsXML( httpContext, ex );

                //NameValueCollection additionalInfo = new NameValueCollection();
                //additionalInfo.Add("Error", "Could process UrlTypeAheadHelper httpContext.Request.QueryString[\"urlHint\"]" );
                //additionalInfo.Add("urlHint", urlHint );
                //ExceptionManager.Publish(ex, EventIds.Default.NotSet, additionalInfo);
			}
		}


		public bool IsReusable
		{
			get{ return true; }
		}
	}
}