// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IsLoggingEventIdDefinitionClass : Attribute
    {
        public IsLoggingEventIdDefinitionClass()
        {
        }

        public IsLoggingEventIdDefinitionClass(string description)
        {
            this.description = description;
        }

        public IsLoggingEventIdDefinitionClass(string description, string range)
        {
            this.description = description;
            this.range = range;
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string range = string.Empty;
        public string Range
        {
            get { return range; }
            set { range = value; }
        }
    }
}
