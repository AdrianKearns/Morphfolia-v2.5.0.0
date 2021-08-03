// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web;
using System.Xml;
using Morphfolia.Business;
using Morphfolia.Common.Info;
using Morphfolia.Common.Attributes;

namespace Morphfolia.PublishingSystem.HttpHandlers
{
	/// <summary>
	/// Summary description for SearchResultPreview.
	/// </summary>
    [IsHttpHandler("Provides an XML response of likely search results, based on the search criteria.")]
    public class SearchResultPreview : IHttpHandler
	{
		private WordIndexSearchResultInfoCollection _WordIndexSearchResultInfoCollection;
		private string criteria = string.Empty;

        [IsHttpHandlerParameter("searchCriteria", "Any string of text")]
        public static readonly string searchCriteriaKey = "searchCriteria";


		public void ProcessRequest( HttpContext httpContext )
		{
            if (httpContext.Request.QueryString[searchCriteriaKey] != null)
			{
                if (httpContext.Request.QueryString[searchCriteriaKey].ToString() != string.Empty)
				{
                    criteria = httpContext.Request.QueryString[searchCriteriaKey].ToString();
				}
			}

            _WordIndexSearchResultInfoCollection = SearchEngine.WordIndex_SEARCH(criteria);


			XmlTextWriter xw = new XmlTextWriter(httpContext.Response.OutputStream, new System.Text.UTF8Encoding());

			xw.WriteStartElement("SearchPreview");
			xw.WriteAttributeString("ResultCount", _WordIndexSearchResultInfoCollection.Count.ToString());
			xw.WriteAttributeString("Query", criteria);

			foreach( Morphfolia.Common.Info.WordIndexSearchResultInfo wordIndexSearchResultInfo in _WordIndexSearchResultInfoCollection)
			{
				xw.WriteStartElement("MyWord");
                xw.WriteAttributeString("TotalOccurances", wordIndexSearchResultInfo.TotalOccurances.ToString());
                xw.WriteAttributeString("DistinctPageCount", wordIndexSearchResultInfo.DistinctPageCount.ToString());
                xw.WriteString(wordIndexSearchResultInfo.Word);
				xw.WriteEndElement(); // Word
			}
			xw.WriteEndElement(); // SearchPreview
			xw.Close();

            httpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            httpContext.Response.ContentType = "application/xml";
		}

		public bool IsReusable
		{
			get
			{
				return true;
			}
		}
	}
}