// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.IO;
using Morphfolia.Common.Types;

namespace Morphfolia.Business
{
    public class FormTemplateHelper
    {
        public static FormTemplate GetDefinitionAndDataFromXmlDefinition(string templateDefinition)
        {
            return (FormTemplate)Morphfolia.Common.Utilities.XMLHelper.XMLStringToObject(templateDefinition, typeof(FormTemplate));
        }

        public static FormTemplate GetDefinitionFromXmlDefinitionFile(string templateDefinitionFilePath)
        {
            string templateDefinition = GetFile(templateDefinitionFilePath);
            return GetDefinitionAndDataFromXmlDefinition(templateDefinition);
        }

        public static string GetFile(string fullPath)
        {
            string output;
            using (StreamReader sr = new StreamReader(fullPath))
            {
                output = sr.ReadToEnd();
            }
            return output;
        }
    }
}