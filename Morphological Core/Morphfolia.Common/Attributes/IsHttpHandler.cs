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
    public class IsHttpHandler : Attribute
    {
        public IsHttpHandler(string description)
        {
            this.description = description;
        }


        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }




    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class IsHttpHandlerParameter : Attribute
    {
        public IsHttpHandlerParameter(string parameterName, string expectedValues)
        {
            this.description = string.Empty;
            this.expectedValues = expectedValues;
            this.parameterName = parameterName;
        }

        public IsHttpHandlerParameter(string parameterName, string expectedValues, string description)
        {
            this.description = description;
            this.expectedValues = expectedValues;
            this.parameterName = parameterName;
        }


        private string parameterName = string.Empty;
        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        private string expectedValues = string.Empty;
        public string ExpectedValues
        {
            get { return expectedValues; }
            set { expectedValues = value; }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }

}