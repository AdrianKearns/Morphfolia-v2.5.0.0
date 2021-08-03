// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.WebControls.Logging
{
    /// <summary>
    /// Event Id range assigned to this area ?
    /// </summary>
    /// <remarks>2000 - 2999</remarks>
    [Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass("Events for Morphfolia.WebControls", "1000 - 1999")]
    public class EventIds
    {
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(2000)]
        public const int Information = 2000;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(2001)]
        public const int Warning = 2001;

        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(2002)]
        public const int Error = 2002;

        /// <summary>
        /// Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(666, "Anywhere that this is used should be re-evaluated and a 'proper' event id assigned.")]
        public const int NotSet = 666;


        /// <summary>
        /// 1100, FormTemplateFieldControl, RenderContents().
        /// </summary>
        [Morphfolia.Common.Attributes.IsLoggingEventIdDefinition(1100, "FormTemplateFieldControl, RenderContents().")]
        public const int _1100 = 1100;
    }
}
