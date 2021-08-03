// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web;
using System.Xml;
using Morphfolia.Business;
using Morphfolia.Common;
using Morphfolia.Common.Attributes;
using Morphfolia.Common.Info;
using Morphfolia.Common.Logging;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// Summary description for ContentPreview.
	/// </summary>
    [IsHttpHandler("Provides a list of Content items in XML.  Intended for Admin use only, as non-live items can be returned.")]
    public class ContentListProvider : IHttpHandler
	{
        private string notesFilter = string.Empty;
        private string id = string.Empty;


        public class ParameterKeys
        {
            [IsHttpHandlerParameter("nf", "a string of text.", "Allows callers to find Content items by searching for text in the Content items Notes property.")]
            public static readonly string NotesFilterKey = "nf";

            [IsHttpHandlerParameter("contentIds", "A string of one or more integers, seperated by commas.")]
            public static readonly string ContentIdsKey = "contentIds";
        }


		public void ProcessRequest( HttpContext httpContext )
		{
            Logging.Logger.LogVerboseInformation("ContentListProvider.ProcessRequest()", string.Format("invoked, {0}", httpContext.Request.Url.PathAndQuery));

			try
			{
                ContentListInfoCollection items = new ContentListInfoCollection();

                notesFilter = WebUtilities.GetRequestQueryStringValue(ParameterKeys.NotesFilterKey);
                if (!notesFilter.Equals(string.Empty))
                {
                    items = ContentItemHelper.Search(notesFilter, ContentTypes.OpenMarkup);
                    Logging.Logger.LogVerboseInformation("ContentListProvider.ProcessRequest()", string.Format("Items by notes filter: {1} items retrieved for '{0}'.", notesFilter, items.Count.ToString()));
                }

                id = WebUtilities.GetRequestQueryStringValue(ParameterKeys.ContentIdsKey);
                if (!id.Equals(string.Empty))
                {
                    string raw = id.Replace(" ", string.Empty);
                    string[] xxx = raw.Split( char.Parse(","));

                    IntCollection contentIds = new IntCollection();
                    for (int i = 0; i < xxx.Length; i++)
                    {
                        try
                        {
                            contentIds.Add(int.Parse(xxx[i]));
                        }
                        catch { }
                    }

                    items = ContentItemHelper.ListById(contentIds);
                    Logging.Logger.LogVerboseInformation("ContentListProvider.ProcessRequest()", string.Format("Items by contentIds: {0} items retrieved.", items.Count.ToString()));
                }
                
            
                httpContext.Response.ContentType = "application/xml";
                XmlTextWriter xw = new XmlTextWriter(httpContext.Response.OutputStream, new System.Text.UTF8Encoding());

                xw.WriteStartElement("ContentListItems");
                xw.WriteAttributeString("Count", items.Count.ToString());

                foreach(ContentListInfo info in items)
                {
                    xw.WriteStartElement("ContentListItem");
                    xw.WriteAttributeString("ContentID", info.ContentID.ToString());
                    xw.WriteAttributeString("ContentTypeMachineValue", info.ContentType.MachineValue);
                    xw.WriteAttributeString("ContentTypeHumanReadableValue", info.ContentType.HumanReadableValue);
                    xw.WriteAttributeString("Note", info.Note);
                    xw.WriteAttributeString("PageUsageCount", info.PageUsageCount.ToString());
                    xw.WriteAttributeString("IsLive", info.IsLive.ToString());
                    xw.WriteAttributeString("IsSearchable", info.IsSearchable.ToString());
                    xw.WriteAttributeString("LastModified", info.LastModified.ToString());
                    xw.WriteAttributeString("LastModifiedBy", info.LastModifiedBy);

                    xw.WriteEndElement();
                }

                xw.WriteEndElement();
                xw.Close();	
			}
			catch( System.Exception ex )
			{
                Logger.LogException("ContentPreview Failed.", ex);

                //Morphological.Utilities.HttpHandlerHelper.WriteExceptionAsXML( httpContext, ex );

                //NameValueCollection additionalInfo = new NameValueCollection();
                //additionalInfo.Add("Error", "Could not get Content Item ID from httpContext.Request.QueryString[\"cid\"]" );
                //additionalInfo.Add("ContentItemID", _ContentItemIDAsString );
                //ExceptionManager.Publish(ex, EventIds.Default.NotSet, additionalInfo);
			}
		}

		public bool IsReusable
		{
			get{ return true; }
		}
	}
}