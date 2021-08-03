// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;



public partial class Morphfolia__publishing_ContentIndexOverview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ContentIndexSummary1.Letter = "D";
        ContentIndexSummary1.NumberOfPopularWordsToShow = 10;
        Header.Title = "Index Overview";

    }
}
