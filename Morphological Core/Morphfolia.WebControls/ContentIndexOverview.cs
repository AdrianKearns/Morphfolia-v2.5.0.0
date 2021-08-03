// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;

namespace Morphfolia.WebControls
{
    public class ContentIndexOverviewPanel : WebControl, INamingContainer
    {
        Label lbl;
        Morphfolia.Business.ContentIndexer contentIndexer = new Morphfolia.Business.ContentIndexer();

        protected override void CreateChildControls()
        {
            lbl = new Label();
            Controls.Add(lbl);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<h5>Letter Counts</h5>");
            foreach (string letter in Enum.GetNames(typeof(LetterArrayIndex)))
            {
                sb.AppendFormat("<br>letter: {0} {1}", letter, contentIndexer.GetCountForLetter(letter).ToString());
            }

            sb.AppendFormat("<h6>Total Count: {0}</h6>", contentIndexer.GetTotalWordCount().ToString());


            sb.Append("<h5>Popular Words</h5>");

            foreach (PopularWordSummary p in contentIndexer.IndexOverview.PopularWords)
            {
                sb.AppendFormat("<br>Word: {0} {1}", p.Word, p.Total.ToString());
            }



            lbl.Text = sb.ToString();

            base.RenderContents(writer);
        }


    }
}
