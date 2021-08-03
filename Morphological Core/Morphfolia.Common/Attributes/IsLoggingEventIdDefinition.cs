// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class IsLoggingEventIdDefinition : Attribute
    {
        public IsLoggingEventIdDefinition(int eventId)
        {
            EventId = eventId;
        }

        public IsLoggingEventIdDefinition(int eventId, string description)
        {
            EventId = eventId;
            Description = description;
        }

        private int eventId = 0;
        public int EventId
        {
            get { return eventId; }
            set { eventId = value; }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
