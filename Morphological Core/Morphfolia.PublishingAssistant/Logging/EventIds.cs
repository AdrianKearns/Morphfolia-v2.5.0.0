// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.PublishingSystem.Logging
{
    [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines all known and specific EventIds for the Publishing System assembly.", "3000 - 3499")]
    public class EventIds
    {
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3000)]
        public const int Information = 3000;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3001)]
        public const int Warning = 3001;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3002)]
        public const int Error = 3002;

        /// <summary>
        /// Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(666, "Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.")]
        public const int NotSet = 666;



        /// <summary>
        /// 3100, HttpHandlers, DefaultHandler, ProcessRequest(). Page Request.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3100, "HttpHandlers, DefaultHandler, ProcessRequest(). Page Request.")]
        public const int _3100 = 3100;

        /// <summary>
        /// 3101, HttpHandlers, DefaultHandler, ProcessRequest(). Page Request - Derived Url.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3101, "HttpHandlers, DefaultHandler, ProcessRequest(). Page Request - Derived Url.")]
        public const int _3101 = 3101;

        /// <summary>
        /// 3102, HttpHandlers, DefaultHandler, ProcessRequest(). layoutWebControlType is empty.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3102, "HttpHandlers, DefaultHandler, ProcessRequest(). layoutWebControlType is empty.")]
        public const int _3102 = 3102;

        /// <summary>
        /// 3103, HttpHandlers, DefaultHandler, ProcessRequest(). layoutWebControlType is empty.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3103, "HttpHandlers, DefaultHandler, ProcessRequest(). layoutWebControlType is empty.")]
        public const int _3103 = 3103;



        /// <summary>
        /// 3200, HttpHandlers, ViewBlogByUrl, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3200, "HttpHandlers, ViewBlogByUrl, ProcessRequest().")]
        public const int _3200 = 3200;

        /// <summary>
        /// 3201, HttpHandlers, ViewBlogPostById, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3201, "HttpHandlers, ViewBlogPostById, ProcessRequest().")]
        public const int _3201 = 3201;

        /// <summary>
        /// 3202, HttpHandlers, ViewBlogPostByTitle, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3202, "HttpHandlers, ViewBlogPostByTitle, ProcessRequest().")]
        public const int _3202 = 3202;

        /// <summary>
        /// 3203, HttpHandlers, ViewBlogPostListByTag, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3203, "HttpHandlers, ViewBlogPostListByTag, ProcessRequest().")]
        public const int _3203 = 3203;



        /// <summary>
        /// 3210, HttpHandlers, Atom10Feed, ProcessRequest(). 
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3210, "HttpHandlers, Atom10Feed, ProcessRequest(). Atom 1.0 Feed Request.")]
        public const int _3210 = 3210;

        /// <summary>
        /// 3211, HttpHandlers, RSS20Feed, ProcessRequest(). 
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3211, "HttpHandlers, RSS20Feed, ProcessRequest(). RSS 2.0 Feed Request.")]
        public const int _3211 = 3211;


        /// <summary>
        /// 3310, WebControls, ManageUser, btnSendUserTheirPassword_Command(). 
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3310, "WebControls, ManageUser, btnSendUserTheirPassword_Command().")]
        public const int _3310 = 3310;

        /// <summary>
        /// 3311, WebControls, ManageUser, btnUnlockUser_Command(). 
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3311, "WebControls, ManageUser, btnUnlockUser_Command().")]
        public const int _3311 = 3311;

        /// <summary>
        /// 3312, WebControls, ManageUser, btnApproveUser_Command(). 
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3312, "WebControls, ManageUser, btnApproveUser_Command().")]
        public const int _3312 = 3312;

        /// <summary>
        /// 3313, WebControls, ManageUser, btnSaveEmailAddress_Command(). 
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3313, "WebControls, ManageUser, btnSaveEmailAddress_Command().")]
        public const int _3313 = 3313;
    }






    /// <summary>
    /// Summary description for EventIds
    /// </summary>
    [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Events for the Morphfolia Web Application (site)", "1000 - 1999")]
    public class WebsiteEventIds
    {
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(1000)]
        public const int Information = 1000;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(1001)]
        public const int Warning = 1001;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(1002)]
        public const int Error = 1002;

        /// <summary>
        /// 1003, Global.asax: Application_Error.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(1003, "Global.asax: Application_Error.")]
        public const int _1003 = 1003;

        /// <summary>
        /// 1004, Error caught on custom error page, if one is configured for use.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(1004, "Used to identify errors captured on the custom errors page, if one has been configured for use.")]
        public const int _1004 = 1004;

        /// <summary>
        /// Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(666, "Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.")]
        public const int NotSet = 666;




        /// <summary>
        /// 1202, EditPage UserControl, layoutWebControlType is empty.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(1202, "EditPage UserControl, layoutWebControlType is empty.")]
        public const int _1202 = 1202;
    }






    /// <summary>
    /// Used for uniquely identifying specific tracing actions.
    /// </summary>
    public class TraceGuids
    {
        // A Guid should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx). 

        // dddddddd-dddd-dddd-dddd-dddddddddddd 
        // xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx


        /// <summary>
        /// 3001, HttpHandlers, Diagnostics, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3001, "HttpHandlers, Diagnostics, ProcessRequest().")]
        public static Guid _3001 = new Guid("00000000-0000-0000-0000-000000003001");


        /// <summary>
        /// 3100, HttpHandlers, DefaultHandler, ProcessRequest(). Page Request.
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3100, "HttpHandlers, DefaultHandler, ProcessRequest(). Page Request.")]
        public static Guid _3100 = new Guid("00000000-0000-0000-0000-000000003100");




        /// <summary>
        /// 3200, HttpHandlers, ViewBlogByUrl, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3200, "HttpHandlers, ViewBlogByUrl, ProcessRequest().")]
        public static Guid _3200 = new Guid("00000000-0000-0000-0000-000000003200");

        /// <summary>
        /// 3201, HttpHandlers, ViewBlogPostById, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3201, "HttpHandlers, ViewBlogPostById, ProcessRequest().")]
        public static Guid _3201 = new Guid("00000000-0000-0000-0000-000000003201");

        /// <summary>
        /// 3202, HttpHandlers, ViewBlogPostByTitle, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3202, "HttpHandlers, ViewBlogPostByTitle, ProcessRequest().")]
        public static Guid _3202 = new Guid("00000000-0000-0000-0000-000000003202");

        /// <summary>
        /// 3203, HttpHandlers, ViewBlogPostListByTag, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3203, "HttpHandlers, ViewBlogPostListByTag, ProcessRequest().")]
        public static Guid _3203 = new Guid("00000000-0000-0000-0000-000000003203");



        /// <summary>
        /// 3210, HttpHandlers, Atom10Feed, ProcessRequest(). Atom Feed Request.
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3210, "HttpHandlers, Atom10Feed, ProcessRequest(). Atom Feed Request.")]
        public static Guid _3210 = new Guid("00000000-0000-0000-0000-000000003210");

        /// <summary>
        /// 3211, HttpHandlers, RSS20Feed, ProcessRequest(). RSS Feed Request.
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3211, "HttpHandlers, RSS20Feed, ProcessRequest(). RSS Feed Request.")]
        public static Guid _3211 = new Guid("00000000-0000-0000-0000-000000003211");


        /// <summary>
        /// 3050, WebFormHelper, default constructor().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3050, "WebFormHelper, default constructor().")]
        public static Guid _3050 = new Guid("00000000-0000-0000-0000-000000003050");


        /// <summary>
        /// 3051, WebFormHelper, constructor(string url).
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3051, "WebFormHelper, constructor(string url).")]
        public static Guid _3051 = new Guid("00000000-0000-0000-0000-000000003051");


        /// <summary>
        /// 3060, HttpHandlers, BinaryFileInterceptor, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(3060, "HttpHandlers, BinaryFileInterceptor, ProcessRequest().")]
        public static Guid _3060 = new Guid("00000000-0000-0000-0000-000000003060");
    }
}
