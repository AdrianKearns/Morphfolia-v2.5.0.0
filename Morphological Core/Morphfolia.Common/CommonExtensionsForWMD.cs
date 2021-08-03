// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

namespace Morphfolia.Common
{
    public partial class ControlPropertyTypeFactory
    {
        public static ControlPropertyType MarkDownContentPropertyType()
        {
            ControlPropertyType markDownContentPropertyType = new ControlPropertyType();
            markDownContentPropertyType.PropertyTypeIdentifier = ControlPropertyTypeConstants.PropertyTypeIdentifiers.MKDN;
            markDownContentPropertyType.PropertyTypeDescription = ControlPropertyTypeConstants.PropertyTypeDescriptions.MKDN;
            return markDownContentPropertyType;
        }
    }

    public partial class ControlPropertyTypeConstants
    {
        public partial class PropertyTypeIdentifiers
        {
            public const string MKDN = "MKDN";
        }

        public partial class PropertyTypeDescriptions
        {
            public const string MKDN = "MarkDown Content";
        }
    }
}