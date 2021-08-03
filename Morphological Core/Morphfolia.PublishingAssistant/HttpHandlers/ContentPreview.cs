// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Collections.Specialized;
using System.Web;
using Morphfolia.Business;
using Morphfolia.Common.Logging;
using Morphfolia.Common.Attributes;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// Summary description for ContentPreview.
	/// </summary>
    [IsHttpHandler("Allows clients to view a content item on its own.  Intended for use by admins.")]
	public class ContentPreview : IHttpHandler
	{
        [IsHttpHandlerParameter("cid", "An int.", "The id of the content item. Intended for admin use only.")]
        public static readonly string ContentIdKey = "cid";

		private Morphfolia.Business.ContentItem _ContentItem;
		private string _ContentItemIDAsString;
		private int _ContentItemID;


		public void ProcessRequest( HttpContext httpContext )
		{
			_ContentItemIDAsString = "NotSet";
			_ContentItemID = -1;

			try
			{
                if (httpContext.Request.QueryString[ContentIdKey] != null)
				{
                    if (httpContext.Request.QueryString[ContentIdKey].ToString() != "")
					{
                        _ContentItemIDAsString = httpContext.Request.QueryString[ContentIdKey].ToString();
						_ContentItemID = int.Parse( _ContentItemIDAsString );
					}
				}

				this._ContentItem = ContentItemHelper.GetContentItemById( _ContentItemID );	

				httpContext.Response.Write( this._ContentItem.Content );
			}
			catch( System.Exception ex )
			{
                Logger.LogException("ContentPreview Failed.", ex);
                //Morphological.Utilities.HttpHandlerHelper.WriteExceptionAsXML( httpContext, ex );
                httpContext.Response.Write("Content not available.");
			}
		}

		public bool IsReusable
		{
			get{ return true; }
		}
	}
}