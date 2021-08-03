// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.Common.Logging
{
    [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines a generic set of EventIds.", "0 - 999")]
    public class EventIds
    {
        /// <summary>
        /// Defines a small set of generic EventIds.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("??Defines a generic set of EventIds.", "0 - 49 (+666)")]
        public class Default
        {
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(0)]
            public const int Information = 0;

            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(1)]
            public const int Warning = 1;

            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(2)]
            public const int Error = 2;

            /// <summary>
            /// Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(666, "Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.")]
            public const int NotSet = 666;
        }

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines a set of licensing related EventIds.", "50 - 59")]
        public class Licensing
        {
            /// <summary>
            /// 50, Licensing Url Check.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(50, "Licensing Url Check.")]
            public const int _50 = 50;
        }

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines a set of EventIds for the BasePageLayout.", "100 - 120")]
        public class BasePageLayout
        {
            /// <summary>
            /// 100, BasePageLayout - Information.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(100, "BasePageLayout - Information.")]
            public const int _100 = 100;

            /// <summary>
            /// 101, BasePageLayout - Warning.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(101, "BasePageLayout - Warning.")]
            public const int _101 = 101;

            /// <summary>
            /// 102, BasePageLayout - Error.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(102, "BasePageLayout - Error.")]
            public const int _102 = 102;
        }



        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines a set of EventIds for the ConfigHelper.", "200 - 250")]
        public class ConfigHelper
        {
            /// <summary>
            /// 200, ConfigHelper - Information.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(200, "ConfigHelper - Information.")]
            public const int _200 = 200;

            /// <summary>
            /// 201, ConfigHelper - Warning.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(201, "ConfigHelper - Warning.")]
            public const int _201 = 201;

            /// <summary>
            /// 202, ConfigHelper - Error.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(202, "ConfigHelper - Error.")]
            public const int _202 = 202;
        }


        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines a set of EventIds for common utilities.", "900 - 999")]
        public class Utilities
        {
            /// <summary>
            /// 900, ProviderLoader.
            /// </summary>
            [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(900, "ProviderLoader.")]
            public const int _900 = 900;
        }


        //[Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("TEMPORARY.", "666001 - 666005")]
        //public class Temporary
        //{
        //    //public const int ContentAuthorFactory = 666001;
        //    //public const int PageFactory = 666002;
        //    //public const int PageLayoutHelper = 666003;
        //    //public const int ABKWebControls = 666004;
        //    //public const int PageDataProvider = 666005;
        //}




        ///// <summary>
        ///// Event Id range assigned to this area.
        ///// </summary>
        ///// <remarks>1000 - 1999</remarks>
        //[Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("?? WebInterface EventIds.", "1000 - 1999")]
        //public class WebInterface
        //{
        //    /// <summary>
        //    /// 1002, Global.asax: Application_Error.
        //    /// </summary>
        //    public const int _1002 = 1002;

        //    /// <summary>
        //    /// 1200, HttpHandlers, DefaultHandler, ProcessRequest().
        //    /// </summary>
        //    public const int _1200 = 1200;

        //    /// <summary>
        //    /// 1201, Page Request.
        //    /// </summary>
        //    public const int _1201 = 1201;

        //    /// <summary>
        //    /// 1202, EditPage UserControl, layoutWebControlType is empty.
        //    /// </summary>
        //    public const int _1202 = 1202;


        //}


        ///// <summary>
        ///// Event Id range assigned to this area.
        ///// </summary>
        ///// <remarks>2000 - 2500</remarks>
        //public class PageLayoutAndSkinAssistant
        //{
        //    /// <summary>
        //    /// 2001, WebLayoutControlHelper, GetCurrentType().
        //    /// </summary>
        //    public const int _2001 = 2001;
        //}
    }
}