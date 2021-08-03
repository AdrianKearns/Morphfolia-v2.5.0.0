<%@ Application Language="C#" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Perform  LicenseChecker.CheckDomain here for best performance.
        //Morphfolia.Common.Utilities.LicenseChecker.CheckDomain(System.Web.HttpContext.Current);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        Exception ex = Server.GetLastError();

        Morphfolia.PublishingSystem.Logging.WebsiteLogger.LogException("Application_Error", ex, Morphfolia.PublishingSystem.Logging.WebsiteEventIds._1003);                
        
        Response.Write(Morphfolia.Common.Logging.ExceptionDetailHelper.PublishException(ex));
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    
</script>
