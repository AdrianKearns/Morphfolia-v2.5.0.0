// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web;

public partial class error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // The exception will have been logged via the Application_Error method in the global.asax.
        try
        {
            Morphfolia.PublishingSystem.WebFormHelper.LogRequest(HttpContext.Current);

            Morphfolia.PublishingSystem.WebFormHelper webFormHelper = new Morphfolia.PublishingSystem.WebFormHelper();

            webFormHelper.AmendHTMLHead(Page);

            PageHeader.Controls.Add(webFormHelper.CreateHeader());
            //PageContent.Controls.Add(webFormHelper.ContentForPage());
            PageFooter.Controls.Add(webFormHelper.CreateFooter());

            lblErrorHeading.Text = "System Error";
            lblErrorMessage.Text = "Unfortunately something has gone wrong, the details of the error have been logged and will be addressed as soon as possible.";
        }
        catch(Exception ex)
        {
            // Production Use:
            lblErrorHeading.Text = "System Error";
            lblErrorMessage.Text = "Unfortunately something has gone wrong, probably a loose wire or a polarized power coupling.";

            // Development / Debugging / Testing Use:
            lblErrorHeading.Text = string.Format("System Error: {0}", ex.Message);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Morphfolia.Common.Logging.ExceptionDetailHelper.PublishInnerException(ex, sb);
            lblErrorMessage.Text = string.Format("<pre>{0}</pre>", sb.ToString());
        }
    }
}
