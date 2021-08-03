// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.Business.Logging
{
    /// <summary>
    /// Defines all known and specific EventIds for the Business Logic assembly.
    /// </summary>
    /// <remarks>4000 - 5999</remarks>
    [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines all known and specific EventIds for the Business Logic assembly.", "4000 - 5999")]
    internal class EventIds
    {
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4000)]
        public const int Information = 4000;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4001)]
        public const int Warning = 4001;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4002)]
        public const int Error = 4002;

        /// <summary>
        /// Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(666, "Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.")]
        public const int NotSet = 666;


        /// <summary>
        /// 4049, UnwantedWordHelper, GetUnwantedWords().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4049, "UnwantedWordHelper, GetUnwantedWords().")]
        public const int _4049 = 4049;


        /// <summary>
        /// 4050, ControlPropertyHelper, DeleteControlPropertiesByInstanceAndPropertyKey().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4050, "ControlPropertyHelper, DeleteControlPropertiesByInstanceAndPropertyKey().")]
        public const int _4050 = 4050;

        /// <summary>
        /// 4051, ControlPropertyHelper, DeleteControlPropertiesByInstanceAndPropertyType().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4051, "ControlPropertyHelper, DeleteControlPropertiesByInstanceAndPropertyType().")]
        public const int _4051 = 4051;

        /// <summary>
        /// 4052, ControlPropertyHelper, DeleteControlPropertiesByInstance().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4052, "ControlPropertyHelper, DeleteControlPropertiesByInstance().")]
        public const int _4052 = 4052;

        /// <summary>
        /// 4053, ControlPropertyHelper, GetControlPropertiesByInstanceID().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4053, "ControlPropertyHelper, GetControlPropertiesByInstanceID().")]
        public const int _4053 = 4053;

        /// <summary>
        /// 4054, ControlPropertyHelper, GetFormTemplatePresenterTypeByInstanceID().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4054, "ControlPropertyHelper, GetFormTemplatePresenterTypeByInstanceID().")]
        public const int _4054 = 4054;



        /// <summary>
        /// 4058, StaticCustomPropertyHelper, DeleteControlPropertiesByPropertyKeyAndPropertyValue().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4058, "StaticCustomPropertyHelper, DeleteControlPropertiesByPropertyKeyAndPropertyValue().")]
        public const int _4058 = 4058;

        /// <summary>
        /// 4059, StaticCustomPropertyHelper, DeleteControlPropertiesByPropertyTypeAndPropertyValue().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4059, "StaticCustomPropertyHelper, DeleteControlPropertiesByPropertyTypeAndPropertyValue().")]
        public const int _4059 = 4059;

        /// <summary>
        /// 4060, StaticCustomPropertyHelper, DeleteControlPropertiesByInstanceAndPropertyKey().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4060, "StaticCustomPropertyHelper, DeleteControlPropertiesByInstanceAndPropertyKey().")]
        public const int _4060 = 4060;


        /// <summary>
        /// 4061, StaticCustomPropertyHelper, DeleteControlPropertiesByInstanceAndPropertyType().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4061, "StaticCustomPropertyHelper, DeleteControlPropertiesByInstanceAndPropertyType().")]
        public const int _4061 = 4061;

        /// <summary>
        /// 4062, StaticCustomPropertyHelper, DeleteControlPropertiesByInstance().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4062, "StaticCustomPropertyHelper, DeleteControlPropertiesByInstance().")]
        public const int _4062 = 4062;


        /// <summary>
        /// 4063, StaticCustomPropertyHelper, GetFormTemplatePresenterTypeByInstanceID().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4063, "StaticCustomPropertyHelper, GetFormTemplatePresenterTypeByInstanceID().")]
        public const int _4063 = 4063;

        /// <summary>
        /// 4064, StaticCustomPropertyHelper, SaveControlPropertyByInstance().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4064, "StaticCustomPropertyHelper, SaveControlPropertyByInstance().")]
        public const int _4064 = 4064;

        /// <summary>
        /// 4065, StaticCustomPropertyHelper, CopySettings(), string[] targetPageIds.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4065, "StaticCustomPropertyHelper, CopySettings(), string[] targetPageIds.")]
        public const int _4065 = 4065;

        /// <summary>
        /// 4066, StaticCustomPropertyHelper, CopySettings(), int targetPageId.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4066, "StaticCustomPropertyHelper, CopySettings(), int targetPageId.")]
        public const int _4066 = 4066;


        /// <summary>
        /// 4100, PageFactory, Page(int pageId).
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4100, "PageFactory, Page(int pageId).")]
        public const int _4100 = 4100;

        /// <summary>
        /// 4101, PageFactory, PublishThisPage(string url).
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4101, "PageFactory, PublishThisPage(string url).")]
        public const int _4101 = 4101;

        /// <summary>
        /// 4104, PageFactory, ProcessRequest().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4104, "PageFactory, PublishThisPage().")]
        public const int _4104 = 4104;

        /// <summary>
        /// 4200, SearchEngine, WordIndex_SEARCH().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4200, "PageFactory, PublishThisPage().")]
        public const int _4200 = 4200;

        /// <summary>
        /// 4201, SearchEngine, Search().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4201, "PageFactory, PublishThisPage().")]
        public const int _4201 = 4201;



        /// <summary>
        /// 4300, Auditor, LogAuditEntry().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(4300, "Auditor, LogAuditEntry().")]
        public const int _4300 = 4300;
    }

    /// <summary>
    /// Used for uniquely identifying specific tracing actions.
    /// </summary>
    public class TraceGuids
    {
        /// <summary>
        /// 4200, SearchEngine, WordIndex_SEARCH().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(4000, "Default Trace GUID for Business Logic Assembly.")]
        public static Guid _4000 = new Guid("00000000-0000-0000-0000-000000004000");

        /// <summary>
        /// 4200, SearchEngine, WordIndex_SEARCH().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(4200, "SearchEngine, WordIndex_SEARCH().")]
        public static Guid _4200 = new Guid("00000000-0000-0000-0000-000000004200");

        /// <summary>
        /// 4201, SearchEngine, Search().
        /// </summary>
        [Morphfolia.Common.Attributes.IsTracingGuidDefinition(4201, "SearchEngine, Search().")]
        public static Guid _4201 = new Guid("00000000-0000-0000-0000-000000004201");
    }
}
