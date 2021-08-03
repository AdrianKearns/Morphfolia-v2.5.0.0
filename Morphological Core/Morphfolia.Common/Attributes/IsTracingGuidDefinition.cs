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
    public class IsTracingGuidDefinition : Attribute
    {
        public IsTracingGuidDefinition(int guidEventIdSeed)
        {
            GuidEventIdSeed = guidEventIdSeed;
        }

        public IsTracingGuidDefinition(int guidEventIdSeed, string description)
        {
            GuidEventIdSeed = guidEventIdSeed;
            Description = description;
        }

        private int guidEventIdSeed = 0;
        /// <summary>
        /// This part of the GUID should match the EventId defined 
        /// for an event that occurs at the same place 
        /// as the where the tracing takes place.
        /// </summary>
        /// <remarks>00000000-0000-0000-0000-00000000####, 
        /// where #### is the EventId, can be as many characters long as necessary, 
        /// as long as the validity of the GUID is not violated.</remarks>
        public int GuidEventIdSeed
        {
            get { return guidEventIdSeed; }
            set { guidEventIdSeed = value; }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
