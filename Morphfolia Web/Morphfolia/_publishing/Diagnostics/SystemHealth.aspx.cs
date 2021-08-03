// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using System.Web;
using Morphfolia.PublishingSystem.Logging;

public partial class Morphfolia__publishing_Diagnostics_SystemHealth : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Logger.LogVerboseInformation("System Health", "LogVerboseInformation Test");
        Logger.LogInformation("System Health", "LogInformation Test");
        Logger.LogAlertInformation("System Health", "LogAlertInformation Test");
        Logger.LogWarning("System Health", "LogWarning Test");

        Exception ex = new Exception("LogException Test; This is a test deliberate exception for system testing purposes.");
        Logger.LogException("System Health", ex);
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        EntryPointNotFoundException p = new EntryPointNotFoundException("Bogus [EntryPoint] exception.");
        FieldAccessException f = new FieldAccessException("Bogus [FieldAccess] exception.", p);
        HttpCompileException h = new HttpCompileException("Bogus [HttpCompile] exception.", f);

        NameValueCollection additionalInfo = new NameValueCollection();
        additionalInfo.Add("DateTime", DateTime.Now.ToString());
        additionalInfo.Add("Caller", "System Health Test");

        //ExceptionManager.Publish(h, EventIds.Error, additionalInfo);

        Logger.LogException("SystemHealth; test exception.", h, EventIds.Error, "Test only, don't panic.");
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        throw new MulticastNotSupportedException("System Health Test Exception");
    }


}
