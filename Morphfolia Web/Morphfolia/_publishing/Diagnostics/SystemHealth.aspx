<%@ Page Language="C#" MasterPageFile="~/Morphfolia/_publishing/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SystemHealth.aspx.cs" Inherits="Morphfolia__publishing_Diagnostics_SystemHealth" Title="Untitled Page" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" Runat="Server">


                
        <table width=80% cellpadding=5 cellspacing=0>
            <tr>
                <td valign=top><asp:Button ID="btnExerciseLogging" runat="server" OnClick="Button1_Click" Text="Exercise Logging" />
                </td>
                <td>Should add four log entries to the currently configured sink (depending onyour logging config), a vebose, info, warning and error; example log entries as follows:
                <pre>1098 1002 1000 Error System Health 2008-11-20 11:36:14 FASSIN
/LM/w3svc/1/ROOT/Morphfolia.Web-23-128716977679843750 System.Exception
-----------------------------------------------------------------------------
LogException Test; This is a test deliberate exception for system testing purposes.
 
1097 1001 500 Warning System Health 2008-11-20 11:36:14 FASSIN
/LM/w3svc/1/ROOT/Morphfolia.Web-23-128716977679843750 LogWarning Test
 
1096 1000 100 Information System Health 2008-11-20 11:36:14 FASSIN
/LM/w3svc/1/ROOT/Morphfolia.Web-23-128716977679843750 LogInformation Test
 
1095 1000 0 Verbose System Health 2008-11-20 11:36:14 FASSIN
/LM/w3svc/1/ROOT/Morphfolia.Web-23-128716977679843750 LogVerboseInformation Test
 
</pre>
                </td>
            </tr>
            <tr>
                <td valign=top><asp:Button ID="btnExerciseExceptionHandling" runat="server" OnClick="Button2_Click" Text="Exercise Exception Handling" />
                </td>
                <td>Should add log entry to the currently configured sink, example log entry text as follows:
                <pre>Title:Bogus [HttpCompile] exception.

Timestamp: 27/11/2007 12:06:27 a.m.
Category: General
Severity: Error
EventId: 2
Priority: 1000

Message: Exception: Bogus [HttpCompile] exception.
Type: System.Web.HttpCompileException
Source: 

InnerException: Bogus [FieldAccess] exception.
Type: System.FieldAccessException
Source: 

InnerException: Bogus [EntryPoint] exception.
Type: System.EntryPointNotFoundException
Source: 

DateTime = 27/11/2007 1:06:27 p.m.
Caller = System Health Test</pre>
                </td>
            </tr>
            <tr>
                <td valign=top>
                    <asp:Button ID="btnThrowUnhandledError" runat="server" OnClick="Button3_Click" Text="Throw Unhandled Error" /></td>
                <td>
                    Should show the user a user-friendly (non-technical) error message, and add log
                    entry to the currently configured sink, example log entry text as follows:
                    <pre>Title:Application_Error

Timestamp: 27/11/2007 12:21:25 a.m.
Category: General
Severity: Error
EventId: 1002
Priority: 1000

Message: System.Web.HttpUnhandledException
-----------------------------------------------------------------------------
Exception of type 'System.Web.HttpUnhandledException' was thrown.
System.Web
   at System.Web.UI.Page.HandleError(Exception e)
   at System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)
   at System.Web.UI.Page.ProcessRequest(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)
   at System.Web.UI.Page.ProcessRequest()
   at System.Web.UI.Page.ProcessRequestWithNoAssert(HttpContext context)
   at System.Web.UI.Page.ProcessRequest(HttpContext context)
   at ASP._publishing_systemhealth_aspx.ProcessRequest(HttpContext context) in c:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Temporary ASP.NET Files\Morphfolia.web\b4df58f8\6f5fea6f\App_Web_xvkgprfz.28.cs:line 0
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)

System.MulticastNotSupportedException
-----------------------------------------------------------------------------
System Health Test Exception
App_Web_xvkgprfz
   at _publishing_SystemHealth.Button3_Click(Object sender, EventArgs e) in c:\DevData\ABK\ABK.CMS\Morphfolia.Web\_publishing\SystemHealth.aspx.cs:line 41
   at System.Web.UI.WebControls.Button.OnClick(EventArgs e)
   at System.Web.UI.WebControls.Button.RaisePostBackEvent(String eventArgument)
   at System.Web.UI.WebControls.Button.System.Web.UI.IPostBackEventHandler.RaisePostBackEvent(String eventArgument)
   at System.Web.UI.Page.RaisePostBackEvent(IPostBackEventHandler sourceControl, String eventArgument)
   at System.Web.UI.Page.RaisePostBackEvent(NameValueCollection postData)
   at System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)</pre></td>
            </tr>
        </table>
        
</asp:Content>

