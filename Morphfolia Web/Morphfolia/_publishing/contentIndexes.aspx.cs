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

public partial class _publishing_contentIndexes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Morphfolia.WebControls.WordIndexListPresenter wordIndexListPresenter = new Morphfolia.WebControls.WordIndexListPresenter();
        pnlContentIndexes.Controls.Add(wordIndexListPresenter);
    }
}
