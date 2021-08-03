// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.PageLayoutAndSkinAssistant.Logging
{
    /// <summary>
    /// Defines all known and specific EventIds for the PageLayoutAndSkinAssistant assembly.
    /// </summary>
    /// <remarks>2000 - 2499</remarks>
    [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Defines all known and specific EventIds for the Page-Layout and Skin Assistant assembly.", "3500 - 3999")]
    internal class EventIds
    {
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3500)]
        public const int Information = 3500;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3501)]
        public const int Warning = 3501;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3502)]
        public const int Error = 3502;

        /// <summary>
        /// Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(666, "Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.")]
        public const int NotSet = 666;



        /// <summary>
        /// 3520, WebLayoutControlHelper, GetAvailableThings().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3520, "WebLayoutControlHelper, GetAvailableThings().")]
        public const int _3520 = 3520;

        /// <summary>
        /// 3521, WebLayoutControlHelper, GetCurrentType().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3521, "WebLayoutControlHelper, GetCurrentType().")]
        public const int _3521 = 3521;

        /// <summary>
        /// 3522, PageLayoutHelper, Load(). 
        /// Loads a BasePageLayout from the specified typename.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3522, "PageLayoutHelper, Load(). Loads a BasePageLayout from the specified typename.")]
        public const int _3522 = 3522;

        /// <summary>
        /// 3523, PageLayoutHelper, Load(). 
        /// Loads a BasePageLayout from the specified typename.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3523, "PageLayoutHelper, ActivateBasePageLayoutInstance(int controlInstanceId).")]
        public const int _3523 = 3523;

        /// <summary>
        /// 3524, PageLayoutHelper, Load(). 
        /// Loads a BasePageLayout from the specified typename.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3524, "PageLayoutHelper, ActivateBasePageLayoutInstance(string typeName, int controlInstanceId).")]
        public const int _3524 = 3524;
    }


    public class TraceGuids
    {
        /// <summary>
        /// 3522, PageLayoutAndSkinAssistant, BasePageLayout, Load().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3522, "PageLayoutAndSkinAssistant, BasePageLayout, Load().")]
        public static Guid _3522 = new Guid("00000000-0000-0000-0000-000000003522");

        /// <summary>
        /// 3523, PageLayoutAndSkinAssistant, BasePageLayout, ActivateBasePageLayoutInstance().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(3523, "PageLayoutAndSkinAssistant, BasePageLayout, ActivateBasePageLayoutInstance().")]
        public static Guid _3523 = new Guid("00000000-0000-0000-0000-000000003523");
    }
}
