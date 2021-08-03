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
using Morphfolia.Business;

namespace Morphfolia.WebControls
{
    public class WordIndexListPresenter : WebControl
    {
        private const string letterQueryIdentifier = "letter";

        Table tblWordIndexListPresenter;
        TableRow tr;
        TableCell tdAlphabet;
        TableCell tdWordIndexListContainer;
        WordIndexList wordIndexList;
        HyperLink hypLetter;

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            tblWordIndexListPresenter = new Table();
            Controls.Add(tblWordIndexListPresenter);


            tr = new TableRow();
            tblWordIndexListPresenter.Rows.Add(tr);

            tdAlphabet = new TableCell();
            tr.Cells.Add(tdAlphabet);


            tr = new TableRow();
            tblWordIndexListPresenter.Rows.Add(tr);

            tdWordIndexListContainer = new TableCell();
            tr.Cells.Add(tdWordIndexListContainer);
        }


        protected override void RenderContents(HtmlTextWriter output)
        {
            EnsureChildControls();

            Char[] alphabet = Morphfolia.Common.Constants.Framework.Various.Alphabet;
            string selectedLetter = "A";
            Literal itemSpacer; 
            
            if (Visible)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    hypLetter = new HyperLink();
                    tdAlphabet.Controls.Add(hypLetter);
                    hypLetter.Text = alphabet[i].ToString().ToUpper();
                    hypLetter.NavigateUrl = string.Format("?{0}={1}", letterQueryIdentifier, alphabet[i].ToString());

                    itemSpacer = new Literal();
                    tdAlphabet.Controls.Add(itemSpacer);
                    itemSpacer.Text = " | ";
                }

                hypLetter = new HyperLink();
                tdAlphabet.Controls.Add(hypLetter);
                hypLetter.Text = "#";
                hypLetter.NavigateUrl = string.Format("?{0}={1}", letterQueryIdentifier, ".");



                if (Context.Request.QueryString[letterQueryIdentifier] != null)
                {
                    if (!Context.Request.QueryString[letterQueryIdentifier].Equals(string.Empty))
                    {
                        selectedLetter = Context.Request.QueryString[letterQueryIdentifier].ToUpper();
                        if (selectedLetter.Length > 1)
                        {
                            selectedLetter = selectedLetter.Remove(1);
                        }
                    }
                }


                wordIndexList = new Morphfolia.WebControls.WordIndexList();
                tdWordIndexListContainer.Controls.Add(wordIndexList);

                if (selectedLetter.Equals("."))
                {
                    wordIndexList.letter = "#";
                }
                else
                {
                    wordIndexList.letter = selectedLetter;
                }

                wordIndexList.WordIndexListCollection = WordIndexListHelper.GetWordIndexListForLetter(selectedLetter);
                //wordIndexList.Attributes.Add("border", "1");
                wordIndexList.LetterCssStyle = "WordIndexListLetterStyle";
                wordIndexList.WordCssStyle = "WordIndexListWordStyle";
                wordIndexList.WordLinkCssStyle = "WordIndexListWordLinkStyle";
                wordIndexList.WordLinkGroupCssStyle = "WordIndexListWordLinkGroupStyle";                    
                

                tblWordIndexListPresenter.RenderControl(output);
            }
        }

    }
}
