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
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.WebControls
{
    /// <summary>
    /// Provides a TagCloud.  
    /// It's source is a list of words, which are presented as hyperlinks.
    /// The NavigateUrl of these links is taken from the TagClouds NavigateUrl 
    /// property.
    /// </summary>
    public class TagCloud : WebControl
    {
        private Table tblTagCloud;
        private TableRow tr;
        private TableCell td;

        //private Label lbl;
        private HyperLink hypTag;
        private Literal litItemSpacer;

        /// <summary>
        /// This array holds the values which mark the boundary 
        /// between the different Tag Division.
        /// </summary>
        /// <remarks>DivisionBoundaryPoints = NumberOfTagDivisons, however, the 
        /// first values is always assigned the value of (MinimumOccurrances - 1); 
        /// This is to ensure that all Tags are dealt with when iterating through the 
        /// Divisions (as specified by the DivisionBoundaryPoints).
        /// 
        /// A TagDivision is used to visually show the user the 
        /// relative importance of the tags, based on the number 
        /// of occurrances.</remarks>
        private int[] DivisionBoundaryPoints;

        private int numberOfTagDivisons = 3;
        public int NumberOfTagDivisons
        {
            get { return numberOfTagDivisons; }
            set { 
                numberOfTagDivisons = value;

                // This number should not be less than three 
                // as that is impractical.
                if (numberOfTagDivisons < 3)
                {
                    numberOfTagDivisons = 3;
                }
            }
        }

        private string navigateUrl = string.Empty;
        public string NavigateUrl
        {
            get { return navigateUrl; }
            set { navigateUrl = value; }
        }

        private string navigateUrlQueryStringKey = RequestKeys.SearchCriteriaIndentifier;
        public string NavigateUrlQueryStringKey
        {
            get { return navigateUrlQueryStringKey; }
            set { navigateUrlQueryStringKey = value; }
        }

        private int minimumOccurrances = 1;
        /// <summary>
        /// Specifies the minimum number of times a word must occur for 
        /// it to be included in the tag cloud.
        /// </summary>
        public int MinimumOccurranceThreshold
        {
            get { return minimumOccurrances; }
            set { minimumOccurrances = value; }
        }

        private bool showOccurranceCount = false;
        /// <summary>
        /// If true the link will also show the total occurances count.
        /// This information is accessible via the ToolTip regardless of this setting.
        /// </summary>
        public bool ShowOccurranceCount
        {
            get { return showOccurranceCount; }
            set { showOccurranceCount = value; }
        }

        private int smallestTagFontSize = 100;
        /// <summary>
        /// The font-size of the least occurring tags.
        /// </summary>
        public int SmallestTagFontSize
        {
            get { return smallestTagFontSize; }
            set { smallestTagFontSize = value; }
        }

        private int fontSizeIncrementValue = 15;
        /// <summary>
        /// The amount by which tags increase in size   
        /// from one division to the next.
        /// </summary>
        public int FontSizeIncrementValue
        {
            get { return fontSizeIncrementValue; }
            set { fontSizeIncrementValue = value; }
        }

        private WordIndexSearchResultInfoCollection words;
        /// <summary>
        /// Holds a collection of words (and the number of occurrances) 
        /// which will be used to fill the TagCloud.
        /// </summary>
        /// <remarks>Are currently 'borrowing' the WordIndexSearchResultInfoCollection type, 
        /// rather than create a specific type.</remarks>
        public WordIndexSearchResultInfoCollection Words
        {
            get {
                if (words == null)
                {
                    words = new WordIndexSearchResultInfoCollection();
                }
                return words; 
            }
            set { words = value; }
        }


        public override string CssClass
        {
            get
            {
                EnsureChildControls();
                return tblTagCloud.CssClass;
            }
            set
            {
                EnsureChildControls();
                tblTagCloud.CssClass = value;
            }
        }



        /// <summary>
        /// example:
        /// TotalOccurances range (min - max): 100 - 400
        ///  lowerBound: 100
        ///  upperBound: 400
        ///  difference: 300
        ///  divisionAmount (difference / NumberOfTagDivisons (3)): 100
        /// </summary>
        private void WorkOutBounds()
        {
            int lowerBound = MinimumOccurranceThreshold;
            int upperBound = 0;
            int difference = 0;
            int divisionAmount = 0;

            if (Words.Count == 0)
            {
                // ?
            }
            else
            {
                //-------------------------------------------------
                // Work out the "division amount":
                //-------------------------------------------------
                for (int i = 0; i < Words.Count; i++)
                {
                    if (Words[i].TotalOccurances > upperBound)
                    {
                        upperBound = Words[i].TotalOccurances;
                    }
                }

                difference = upperBound - lowerBound;
                divisionAmount = difference / NumberOfTagDivisons;

                // example:
                // TotalOccurances range (min - max): 100 - 400
                //  lowerBound: 100
                //  upperBound: 400
                //  difference: 300
                //  divisionAmount (difference / NumberOfTagDivisons (3)): 100


                int temp = lowerBound;
                DivisionBoundaryPoints = new int[NumberOfTagDivisons];
                DivisionBoundaryPoints[0] = (MinimumOccurranceThreshold - 1);
                for (int i = 1; i < DivisionBoundaryPoints.Length; i++)
                {
                    temp = temp + divisionAmount;
                    DivisionBoundaryPoints[i] = temp;
                }
            }
        }


        private void PopulateCloud()
        {
            if(Words.Count == 0)
            {
                litItemSpacer = new Literal();
                Controls.Add(litItemSpacer);
                litItemSpacer.Text = "(Empty)";
            }
            else
            {
                for (int i = 0; i < Words.Count; i++)
                {
                    hypTag = new HyperLink();
                    Controls.Add(hypTag);
                    td.Controls.Add(hypTag);
                    //hypTag.ToolTip = string.Format("{0} occurances over {1} pages.", Words[i].TotalOccurances.ToString(), Words[i].DistinctPageCount.ToString());
                    hypTag.ToolTip = string.Format("{0} occurances.", Words[i].TotalOccurances.ToString());
                    hypTag.NavigateUrl = string.Format("{0}?{1}={2}", 
                        NavigateUrl, 
                        NavigateUrlQueryStringKey,
                        Context.Server.UrlEncode( Words[i].Word ));

                    if (ShowOccurranceCount)
                    {
                        hypTag.Text = string.Format("{0} ({1})", Words[i].Word, Words[i].TotalOccurances.ToString());
                    }
                    else
                    {
                        hypTag.Text = Words[i].Word;
                    }

                    for (int b = DivisionBoundaryPoints.Length-1; b >= 0; b--)
                    {
                        if (Words[i].TotalOccurances > DivisionBoundaryPoints[b])
                        {
                            hypTag.Style.Add("font-size", string.Format("{0}%", smallestTagFontSize + (fontSizeIncrementValue * b)));
                            break;
                        }
                    }

                    
                    if (i < (Words.Count-1))
                    {
                        litItemSpacer = new Literal();
                        Controls.Add(litItemSpacer);
                        td.Controls.Add(litItemSpacer);
                        litItemSpacer.Text = string.Format(" {0}", Environment.NewLine);
                    }
                }
            }
        }


        protected override void CreateChildControls()
        {
            //base.CreateChildControls();

            tblTagCloud = new Table();
            Controls.Add(tblTagCloud);
            tblTagCloud.CellPadding = 3;
            tblTagCloud.CellSpacing = 0;

            tr = new TableRow();
            Controls.Add(tr);
            tblTagCloud.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            WorkOutBounds();
            PopulateCloud();

            tblTagCloud.RenderControl(writer);
        }
    }
}
