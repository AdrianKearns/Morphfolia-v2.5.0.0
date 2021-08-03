// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using Morphfolia.WebControls.Utilities;

namespace Morphfolia.WebControls
{
    [ToolboxData("<{0}:WordIndexList runat=server></{0}:WordIndexList>")]
    public class WordIndexList : WebControl
    {
        private Table tblWordIndexList;
        private TableRow tr;
        private TableCell tdLetter;
        private TableCell td;
        //private HyperLink pageLink;
        private string virtualApplicationRoot;


        public string letter = string.Empty;
        public string Letter
        {
            get{ return letter; }
            set{ letter = value; }
        }

        public string letterCssStyle = string.Empty;
        public string LetterCssStyle
        {
            get { return letterCssStyle; }
            set { letterCssStyle = value; }
        }

        public string wordCssStyle = string.Empty;
        public string WordCssStyle
        {
            get { return wordCssStyle; }
            set { wordCssStyle = value; }
        }

        public string wordLinkCssStyle = string.Empty;
        public string WordLinkCssStyle
        {
            get { return wordLinkCssStyle; }
            set { wordLinkCssStyle = value; }
        }

        public string wordLinkGroupCssStyle = string.Empty;
        public string WordLinkGroupCssStyle
        {
            get { return wordLinkGroupCssStyle; }
            set { wordLinkGroupCssStyle = value; }
        }

        public WordIndexListInfoCollection wordIndexList = new WordIndexListInfoCollection();
        /// <summary>
        /// Holds all the works (and links) applicable to the letter.
        /// </summary>
        public WordIndexListInfoCollection WordIndexListCollection
        {
            get { return wordIndexList; }
            set { wordIndexList = value; }
        }


        protected override void CreateChildControls()
        {
            //base.CreateChildControls();

            virtualApplicationRoot = WebUtilities.VirtualApplicationRoot();

            tblWordIndexList = new Table();
            Controls.Add(tblWordIndexList);
            //tblWordIndexList.Attributes.Add("border", "1");
            tblWordIndexList.CellPadding = 5;
            tblWordIndexList.CellSpacing = 0;

            tr = new TableRow();
            tblWordIndexList.Rows.Add(tr);

            tdLetter = new TableCell();
            tr.Cells.Add(tdLetter);
            tdLetter.ColumnSpan = 2;
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


        private void AppendPageLink(WordIndexListInfo wordIndexListInfo, TableCell td)
        {
            string blogPostUrl;
            string pageUrl;
            Literal li = new Literal();

            pageUrl = string.Format("{0}/{1}",
                VirtualApplicationRoot,
                wordIndexListInfo.Url);

            if(wordIndexListInfo.ContentTypeDefinition == Morphfolia.Common.ContentTypes.OpenMarkup)
            {
                li.Text = string.Format("<li class='{0}'><a href='{1}'>{2}</a></li>{3}",
                    WordLinkCssStyle,
                    pageUrl,
                    wordIndexListInfo.Title,
                    Environment.NewLine);
            }
            else
            {
                blogPostUrl = string.Format("{0}/blogs/permalink/{1}/{2}/viewpost.aspx", 
                    VirtualApplicationRoot,
                    wordIndexListInfo.PageId.ToString(), 
                    wordIndexListInfo.ContentId.ToString());

                li.Text = string.Format("<li class='{0}'><a href='{1}'>{2}</a> (blogged on <a href='{3}'>{4}</a>)</li>{5}",
                    WordLinkCssStyle,               // 0
                    blogPostUrl,                    // 1
                    wordIndexListInfo.ContentNote,  // 2
                    pageUrl,                        // 3
                    wordIndexListInfo.Title,        // 4
                    Environment.NewLine);           // 5
            }
            td.Controls.Add(li);

        }



        protected override void RenderContents(HtmlTextWriter output)
        {
            EnsureChildControls();
            string tempWord = string.Empty;
            string currentWord = string.Empty;
            //Literal br;
            Literal ul;

            if (Visible)
            {
                tdLetter.Text = Letter.ToUpper();

                tdLetter.CssClass = LetterCssStyle;
                tblWordIndexList.CssClass = CssClass;
                tblWordIndexList.CellPadding = 3;
                tblWordIndexList.CellSpacing = 0;

                if (WordIndexListCollection.Count == 0)
                {
                    tr = new TableRow();
                    tblWordIndexList.Rows.Add(tr);

                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = "No words in this index.";
                }
                else
                {
                    for (int i = 0; i < WordIndexListCollection.Count; i++)
                    {
                        tempWord = WordIndexListCollection[i].Word;

                        if (tempWord.Equals(currentWord))
                        {
                            AppendPageLink(WordIndexListCollection[i], td);
                        }
                        else
                        {
                            if (td != null)
                            {
                                ul = new Literal();
                                ul.Text = "</ul>";
                                td.Controls.Add(ul);
                            }


                            currentWord = tempWord;

                            tr = new TableRow();
                            tblWordIndexList.Rows.Add(tr);

                            td = new TableCell();
                            tr.Cells.Add(td);
                            td.VerticalAlign = VerticalAlign.Top;

                            Label lblWord = new Label();
                            td.Controls.Add(lblWord);
                            lblWord.Text = Context.Server.HtmlEncode(currentWord);
                            lblWord.CssClass = WordCssStyle;

                            ul = new Literal();
                            ul.Text = string.Format("<ul class='{0}'>", WordLinkGroupCssStyle);
                            td.Controls.Add(ul);

                            AppendPageLink(WordIndexListCollection[i], td);
                        }
                    }

                    if (td != null)
                    {
                        ul = new Literal();
                        ul.Text = "</ul>";
                        td.Controls.Add(ul);
                    }
                }

                tblWordIndexList.RenderControl(output);
            }
        }
    }
}
