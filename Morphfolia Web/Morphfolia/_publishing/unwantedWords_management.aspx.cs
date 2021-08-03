// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using Morphfolia.Business;

public partial class _publishing_unwantedWords_management : System.Web.UI.Page
{
    //private Morphfolia.Business.UnwantedWordHelper unwantedWordHelper = new Morphfolia.Business.UnwantedWordHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PresentWords();
        }
    }

    private void PresentWords()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //StringCollection unwantedWords = unwantedWordHelper.GetUnwantedWords();
        string tempWord;
        String[] unwantedWords = UnwantedWordHelper.GetUnwantedWords();
        for (int i = 0; i < unwantedWords.Length; i++)
        {
            tempWord = unwantedWords[i];
            tempWord = tempWord.Trim();
            sb.AppendFormat("{0}{1}", tempWord, Environment.NewLine);
        }
        txtUnwantedWords.Text = sb.ToString();        
    }




    protected void btnSaveAndRemove_Click(object sender, EventArgs e)
    {
        Morphfolia.Business.ContentIndexer contentIndexer = new Morphfolia.Business.ContentIndexer();

        //System.Collections.Specialized.StringCollection stringCollection = new System.Collections.Specialized.StringCollection();

        string[] unwantedWords = txtUnwantedWords.Text.Replace(Environment.NewLine, " ").Split(char.Parse(" "));
        //stringCollection.AddRange(unwantedWords.Split(char.Parse(" ")));


        Array.Sort(unwantedWords);


        if (unwantedWords != null)
        {
            UnwantedWordHelper.SaveUnwantedWords(unwantedWords);
            contentIndexer.RemoveUnwantedWordsFromTheContentIndexs(unwantedWords);
        }

        PresentWords();
    }
}
