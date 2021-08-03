// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Morphfolia.WebControls.Utilities;
using Microsoft.Security.Application;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.WebControls
{
    public class SearchInput : WebControl//, INamingContainer
    {
        private Panel pnlSearchInput;
        //private TextBox txtSearchCriteria;
        private HtmlInputText txtSearchCriteria;
        //private Button btnSearch;
        private HtmlInputSubmit btnSearch;
        private Panel divSuggestResults;
        //private Table tblSearchResults;
        private Literal nobr;

        private static string searchResultsPageRawURL = null;
        public static string SearchResultsPageRawURL
        {
            get
            {
                if (searchResultsPageRawURL == null)
                {
                    //searchResultsPageRawURL = string.Format("{0}/SearchResults.aspx", WebUtilities.VirtualApplicationRoot());
                    searchResultsPageRawURL = "SearchResults.aspx";
                }
                return searchResultsPageRawURL;
            }
            set { searchResultsPageRawURL = value; }
        }


        private static string searchResultsPageURL = null;
        /// <summary>
        /// The URL with the querystring (and includes the search key, but not the search value).
        /// </summary>
        public static string SearchResultsPageURL
        {
            get
            {
                if (searchResultsPageURL == null)
                {
                    searchResultsPageURL = string.Format("{0}?{1}=",
                        SearchResultsPageRawURL,
                        Morphfolia.Common.Constants.Framework.RequestKeys.SearchCriteriaIndentifier);
                }
                return searchResultsPageURL;
            }
            set { searchResultsPageURL = value; }
        }

        private Unit suggestionBoxWidth = Unit.Pixel(375);
        public Unit SuggestionBoxWidth
        {
            get { return suggestionBoxWidth; }
            set { suggestionBoxWidth = value; }
        }

        private Unit suggestionBoxHeight = Unit.Pixel(200);
        public Unit SuggestionBoxHeight
        {
            get { return suggestionBoxHeight; }
            set { suggestionBoxHeight = value; }
        }

        private string suggestionBoxBackgroundColor = "#fefefe";
        public string SuggestionBoxBackgroundColor
        {
            get { return suggestionBoxBackgroundColor; }
            set { suggestionBoxBackgroundColor = value; }
        }

        private string suggestionBoxBorderStyle = "#000000 1px solid";
        public string SuggestionBoxBorderStyle
        {
            get { return suggestionBoxBorderStyle; }
            set { suggestionBoxBorderStyle = value; }
        }


        public enum SubmitTypes
        {
            NotSet = 0,
            OwnForm,
            UseParentForm
        }

        private SubmitTypes submitType = SubmitTypes.OwnForm;
        public SubmitTypes SubmitType
        {
            get { return submitType; }
            set { submitType = value; }
        }


        public delegate void onSearch(object sender, EventArgs e);
        /// <summary>
        /// Fires when the Search button has been clicked, and immeadiately before 
        /// Redirecting the user to the Search Results Page (see the SearchResultsPageURL property).
        /// </summary>
        public event onSearch Search;


        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            pnlSearchInput = new Panel();
            Controls.Add(pnlSearchInput);

            nobr = new Literal();
            Controls.Add(nobr);
            pnlSearchInput.Controls.Add(nobr);
            nobr.Text = "<nobr>";



            //txtSearchCriteria = new TextBox();
            //Controls.Add(txtSearchCriteria);
            //pnlSearchInput.Controls.Add(txtSearchCriteria);
            //txtSearchCriteria.ID = Morphfolia.Common.Constants.Framework.Various.SearchCriteriaIndentifier;
            //txtSearchCriteria.EnableViewState = true;
            //txtSearchCriteria.Width = Unit.Pixel(272);
            //txtSearchCriteria.MaxLength = 100;
            //txtSearchCriteria.Attributes.Add("onkeyup", "checkSearchCriteria(this);");
            //txtSearchCriteria.Style.Add("position", "relative");

            txtSearchCriteria = new HtmlInputText();
            Controls.Add(txtSearchCriteria);
            pnlSearchInput.Controls.Add(txtSearchCriteria);
            txtSearchCriteria.ID = Morphfolia.Common.Constants.Framework.RequestKeys.SearchCriteriaIndentifier;
            //txtSearchCriteria.EnableViewState = true;
            txtSearchCriteria.Style.Add("width", "272px");
            txtSearchCriteria.MaxLength = 100;
            txtSearchCriteria.Attributes.Add("onkeyup", "checkSearchCriteria(this);");
            txtSearchCriteria.Style.Add("position", "relative");

            //btnSearch = new Button();
            //Controls.Add(btnSearch);
            //pnlSearchInput.Controls.Add(btnSearch);
            //btnSearch.ID = "btnSearch";
            //btnSearch.Text = "Search";
            //btnSearch.Click += new EventHandler(btnSearch_Click);

            btnSearch = new HtmlInputSubmit();
            Controls.Add(btnSearch);
            pnlSearchInput.Controls.Add(btnSearch);
            btnSearch.ID = "btnSearch";
            btnSearch.Value = "Search";
            //btnSearch.Click += new EventHandler(btnSearch_Click);


            nobr = new Literal();
            Controls.Add(nobr);
            pnlSearchInput.Controls.Add(nobr);
            nobr.Text = "</nobr>";



            // if ie: we want a <br> in here before the div: 
            if (HttpContext.Current.Request.Browser.Type.StartsWith("IE"))
            {
                Literal br = new Literal();
                Controls.Add(br);
                pnlSearchInput.Controls.Add(br);
                br.Text = "<br>";
            }

            divSuggestResults = new Panel();
            Controls.Add(divSuggestResults);
            pnlSearchInput.Controls.Add(divSuggestResults);
            divSuggestResults.Attributes.Add("align", "left");
            divSuggestResults.Attributes.Add("id", "divSuggestResults");
            divSuggestResults.Style.Add("OVERFLOW-Y", "scroll");
            divSuggestResults.Style.Add("VISIBILITY", "hidden");
            divSuggestResults.Style.Add("POSITION", "absolute");

            //tblSearchResults = new Table();
            //Controls.Add(tblSearchResults);
            //pnlSearchInput.Controls.Add(tblSearchResults);
            //tblSearchResults.CellPadding = 3;
            //tblSearchResults.CellSpacing = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                Search(sender, e);
            }

            ExecuteSearch();
        }


        private void ExecuteSearch()
        {
            Morphfolia.Common.Logging.Logger.LogInformation("Search", txtSearchCriteria.Value);
            //HttpContext.Current.Response.Redirect(string.Format("{0}{1}", SearchResultsPageURL, txtSearchCriteria.Value));
            HttpContext.Current.Response.Redirect(string.Format("{0}{1}", SearchResultsPageURL, AntiXss.UrlEncode(txtSearchCriteria.Value)));
        }


        private bool JavaScriptsRegistered = false;

        protected override void OnPreRender(EventArgs e)
        {
            EnsureChildControls();

            if (Page != null)
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered(ClientScriptRegistrationKeys.ABKSuggests))
                {
                    Page.ClientScript.RegisterClientScriptInclude(this.GetType(), ClientScriptRegistrationKeys.ABKSuggests, string.Format("{0}{1}",
                        WebUtilities.FullyQualifiedApplicationRoot(),
                        Morphfolia.WebControls.Common.JavaScriptFileURLs.ABKSuggests));

                    JavaScriptsRegistered = true;
                }
                else
                {
                    JavaScriptsRegistered = true;
                }
            }

            base.OnPreRender(e);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            divSuggestResults.Style.Add("width", SuggestionBoxWidth.ToString());
            divSuggestResults.Style.Add("height", SuggestionBoxHeight.ToString());
            divSuggestResults.Style.Add("BACKGROUND-COLOR", SuggestionBoxBackgroundColor);
            divSuggestResults.Style.Add("BORDER", SuggestionBoxBorderStyle);

            if (Visible)
            {
                if (!JavaScriptsRegistered)
                {
                    //writer.Write("<script language=javascript>var sHttpContextCurrentRequestApplicationPath = '{0}';</script>{1}",
                    //    WebUtilities.FullyQualifiedApplicationRoot(),
                    //    Environment.NewLine);
                    writer.Write("<script language=javascript src='{0}{1}'></script>{2}",
                        WebUtilities.FullyQualifiedApplicationRoot(),
                        Morphfolia.WebControls.Common.JavaScriptFileURLs.ABKSuggests,
                        Environment.NewLine);
                }


                // Do this regardless: 
                writer.Write("<script language=javascript>var txtSearchCriteriaId = '{0}'; var btnSearchId = '{1}';</script>{2}",
                    txtSearchCriteria.ClientID,
                    btnSearch.ClientID,
                    Environment.NewLine);


                switch (SubmitType)
                {
                    case SubmitTypes.OwnForm:
                        writer.Write("<form name='frmABKSuggests' action='{0}/SearchResults.aspx' method='GET'>{1}",
                            WebUtilities.FullyQualifiedApplicationRoot(),
                            Environment.NewLine);
                        break;

                    case SubmitTypes.UseParentForm:
                        break;

                    default:
                        break;
                }


                base.RenderContents(writer);


                switch (SubmitType)
                {
                    case SubmitTypes.OwnForm:
                        writer.Write("</form>");
                        break;

                    case SubmitTypes.UseParentForm:
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
