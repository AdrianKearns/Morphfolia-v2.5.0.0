// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.Common
{
    public class ContentTypes
    {
        public class MachineValues
        {
            public const string All = "____";
            public const string OpenMarkup = "CONT";
            public const string BlogPost = "BPST";
        }

        public class HumanReadableValues
        {
            public const string All = "All";
            public const string OpenMarkup = "Open Mark-up";
            public const string BlogPost = "Blog Post";
        }


        public static ContentTypeDefinition All = new ContentTypeDefinition(HumanReadableValues.All, MachineValues.All);
        public static ContentTypeDefinition OpenMarkup = new ContentTypeDefinition(HumanReadableValues.OpenMarkup, MachineValues.OpenMarkup);
        public static ContentTypeDefinition BlogPost = new ContentTypeDefinition(HumanReadableValues.BlogPost, MachineValues.BlogPost);


        public static ContentTypeDefinition Factory(string contentTypeMachineValue)
        {
            switch (contentTypeMachineValue.ToUpper())
            {
                case MachineValues.All:
                    return All;

                case MachineValues.OpenMarkup:
                    return OpenMarkup;

                case MachineValues.BlogPost:
                    return BlogPost;

                default:
                    return All;
            }
        }
        
        


        /// <summary>
        /// Used to define the different types of Content that the system knows of.
        /// </summary>
        public class ContentTypeDefinition
        {
            public readonly string HumanReadableValue;
            public readonly string MachineValue;


            /// <summary>
            /// Defines a ContentTypeDefinition.
            /// </summary>
            /// <param name="humanReadableValue">The ContentType as a human would understand it.</param>
            /// <param name="machineValue">The ContentType as the system will understand it. Length of 4 characters only</param>
            protected internal ContentTypeDefinition(string humanReadableValue, string machineValue)
            {
                HumanReadableValue = humanReadableValue;
                MachineValue = machineValue;
            }
        }

    }
}
