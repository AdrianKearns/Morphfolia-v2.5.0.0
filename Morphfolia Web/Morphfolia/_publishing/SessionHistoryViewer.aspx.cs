// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Business.Logs;
using Morphfolia.PublishingSystem.WebControls;
using Morphfolia.Common.Constants.Framework;

public partial class Morphfolia__publishing_SessionHistoryViewer : System.Web.UI.Page
{
    private HttpSessionHistory httpSessionHistory;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Header.Title = "Session History Viewer";

        httpSessionHistory = new HttpSessionHistory();
        pnlSessionHistory.Controls.Add(httpSessionHistory);

        string sessionId = Morphfolia.WebControls.Utilities.HttpRequestHelper.GetRequestParamValue(RequestKeys.SessionId);

        httpSessionHistory.SessionHistory = HttpLogs.UrlHistoryForSession(sessionId);
    }
}
