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
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Logging;
using Morphfolia.Common.Info;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;
using Morphfolia.PageLayoutAndSkinAssistant.Interfaces;

public partial class login : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        Morphfolia.PublishingSystem.WebFormHelper webFormHelper = new Morphfolia.PublishingSystem.WebFormHelper();

 
        webFormHelper.AmendHTMLHead(Page);


        PageHeader.Controls.Add(webFormHelper.CreateHeader());

        tdAdditionalContent.Controls.Add( webFormHelper.ContentForPage() );

        PageFooter.Controls.Add(webFormHelper.CreateFooter());

        LoginControl.LoggedIn += new EventHandler(LoginControl_LoggedIn);
    }

    bool userHasLoggedIn = false;

    void LoginControl_LoggedIn(object sender, EventArgs e)
    {
        Morphfolia.Business.Logs.HttpLogger.LogRequest(HttpContext.Current, string.Format("User successfully logged in: {0}", LoginControl.UserName));
        Logger.LogInformation("Successful Login", string.Format("User successfully logged in: {0}", LoginControl.UserName), 110);
        userHasLoggedIn = true;
    }

    protected override void Render(HtmlTextWriter writer)
    {
        if (!userHasLoggedIn)
        {
            Morphfolia.Business.Logs.HttpLogger.LogRequest(HttpContext.Current);
        }
        base.Render(writer);
    }
}