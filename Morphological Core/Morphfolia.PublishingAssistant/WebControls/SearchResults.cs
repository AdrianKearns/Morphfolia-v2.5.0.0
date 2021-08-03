// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using Morphfolia.Business;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Summary description for SearchResults
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class SearchResults : System.Web.UI.WebControls.WebControl, INamingContainer
    {
        private Panel pnlResultsMessage;
        private Label lblResultsMessage;
        private Table tblSearchResults;
        private TableRow tr;
        private TableCell td;
        private HyperLink hypMainLink;
        private HyperLink hypFullUrl;
        private string fullUrl;
        private string smlMatchBlurb;

        private string searchCriteria = string.Empty;
        public string SearchCriteria
        {
            get
            {
                EnsureChildControls();
                return searchCriteria;
            }
        }


        private Morphfolia.Common.Info.SearchResultInfoCollection _SearchResultsItems = new Morphfolia.Common.Info.SearchResultInfoCollection();
        public Morphfolia.Common.Info.SearchResultInfoCollection Items
        {
            get { return this._SearchResultsItems; }
            set { this._SearchResultsItems = value; }
        }



        private string _virtualApplicationRoot = null;
        private string VirtualApplicationRoot
        {
            get
            {
                if (_virtualApplicationRoot == null)
                {
                    _virtualApplicationRoot = WebUtilities.VirtualApplicationRoot();
                }
                return _virtualApplicationRoot;
            }
        }


        protected override void CreateChildControls()
        {
            System.Collections.Specialized.NameValueCollection currentParams;
            string[] keys;

            currentParams = HttpContext.Current.Request.QueryString;
            keys = currentParams.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].ToString().Equals(RequestKeys.SearchCriteriaIndentifier))
                {
                    searchCriteria = currentParams[i].ToString();
                    break;
                }
            }

            if (searchCriteria.Equals(string.Empty))
            {
                currentParams = HttpContext.Current.Request.Form;
                keys = currentParams.AllKeys;
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i].ToString().Equals(RequestKeys.SearchCriteriaIndentifier))
                    {
                        searchCriteria = currentParams[i].ToString();
                        break;
                    }
                }
            }

            pnlResultsMessage = new Panel();
            Controls.Add(pnlResultsMessage);
            //pnlResultsMessage.CssClass = "searchResults_ResultsHeading";

            lblResultsMessage = new Label();
            pnlResultsMessage.Controls.Add(lblResultsMessage);
            lblResultsMessage.Style.Add("align", "center");
            lblResultsMessage.CssClass = "searchResults_ResultsHeading";


            tblSearchResults = new Table();
            Controls.Add(tblSearchResults);
            tblSearchResults.CellPadding = 3;
            tblSearchResults.CellSpacing = 0;
            tblSearchResults.Width = Unit.Percentage(100);
            tblSearchResults.HorizontalAlign = HorizontalAlign.Center;
            //tblSearchResults.Attributes.Add("border", "1");


            if (!SearchCriteria.Equals(string.Empty))
            {
                Morphfolia.Business.SearchEngine searchEngine = new Morphfolia.Business.SearchEngine();
                this._SearchResultsItems = SearchEngine.Search("%" + SearchCriteria + "%");


                // Not yet 100% sure if/how we want to sanitize input into the logs: 
                Morphfolia.Common.Logging.Logger.LogInformation("Search Results", string.Format("{1} matches for '{0}'.", SearchCriteria, _SearchResultsItems.Count.ToString()));


                if (this._SearchResultsItems.Count > 0)
                {
                    lblResultsMessage.Text = string.Format("<b>{0} pages found that contain '{1}'</b>", this._SearchResultsItems.Count.ToString(), AntiXss.HtmlEncode(SearchCriteria));

                    foreach (Morphfolia.Common.Info.SearchResultInfo searchResultInfo in this._SearchResultsItems)
                    {
                        tr = new TableRow();
                        tblSearchResults.Rows.Add(tr);
                        td = new TableCell();
                        tr.Cells.Add(td);

                        if (searchResultInfo.ContentTypeDefinition == Morphfolia.Common.ContentTypes.BlogPost)
                        {
                            fullUrl = Blogging.BloggingHelpers.CreateUrlToBlogPostByTitle(searchResultInfo);

                            //fullUrl = string.Format("{0}/blogs/{1}/{2}.aspx",
                            //    VirtualApplicationRoot,
                            //    searchResultInfo.PageID.ToString(),
                            //    searchResultInfo.ContentID.ToString());

                            if (searchResultInfo.Matches == 1)
                            {
                                smlMatchBlurb = string.Format("1 match.  Blogged in <a href='{0}/{1}'>{2}</a>",
                                    VirtualApplicationRoot,
                                    searchResultInfo.Url,
                                    searchResultInfo.Title);
                            }
                            else
                            {
                                smlMatchBlurb = string.Format("{0} matches.  Blogged in <a href='{1}/{2}'>{3}</a>",
                                    searchResultInfo.Matches.ToString(),
                                    VirtualApplicationRoot,
                                    searchResultInfo.Url,
                                    searchResultInfo.Title);
                            }
                        }
                        else
                        {
                            fullUrl = string.Format("{0}/{1}", VirtualApplicationRoot, searchResultInfo.Url);

                            if (searchResultInfo.Matches == 1)
                            {
                                smlMatchBlurb = "1 match.";
                            }
                            else
                            {
                                smlMatchBlurb = string.Format("{0} matches.", searchResultInfo.Matches.ToString());
                            }
                        }

                        tr = new TableRow();
                        tblSearchResults.Rows.Add(tr);
                        td = new TableCell();
                        tr.Cells.Add(td);

                        hypMainLink = new HyperLink();
                        td.Controls.Add(hypMainLink);
                        hypMainLink.NavigateUrl = fullUrl;
                        hypMainLink.Text = searchResultInfo.Title;
                        hypMainLink.CssClass = "searchResults_MainLink";


                        tr = new TableRow();
                        tblSearchResults.Rows.Add(tr);
                        td = new TableCell();
                        tr.Cells.Add(td);

                        hypFullUrl = new HyperLink();
                        td.Controls.Add(hypFullUrl);
                        hypFullUrl.NavigateUrl = fullUrl;
                        hypFullUrl.Text = fullUrl;
                        hypFullUrl.CssClass = "searchResults_FullUrlLink";




                        tr = new TableRow();
                        tblSearchResults.Rows.Add(tr);
                        td = new TableCell();
                        tr.Cells.Add(td);
                        td.Text = smlMatchBlurb;



                        tr = new TableRow();
                        tblSearchResults.Rows.Add(tr);
                        td = new TableCell();
                        tr.Cells.Add(td);
                        td.CssClass = "searchResults_description";
                        if (searchResultInfo.Description.Length > 1003)
                        {
                            td.Text = string.Format("{0}...", searchResultInfo.Description.Substring(0, 1000));
                        }
                        else
                        {
                            td.Text = searchResultInfo.Description;
                        }

                        tr = new TableRow();
                        tblSearchResults.Rows.Add(tr);
                        td = new TableCell();
                        tr.Cells.Add(td);
                        td.Text = string.Format("Last modified: {0} by {1}<br>&nbsp;", searchResultInfo.LastModified.ToString(), searchResultInfo.LastModifiedBy);
                        td.CssClass = "searchResults_lastUpdated";
                    }
                }
                else
                {
                    lblResultsMessage.Text = string.Format("Sorry, no results found for: {0}", AntiXss.HtmlEncode(SearchCriteria));
                }
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if(Visible)
            {
                base.RenderContents(writer);
            }
        }
    }
}
