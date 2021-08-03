// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Reflection;
using System.Security.Policy;
using Morphfolia.Common.Attributes;

namespace Morphfolia.Common.Utilities
{
    public class HttpHandlerExtractor
    {
        public delegate void OnMiscInformationFound(string key, string val);
        public event OnMiscInformationFound MiscInformationFound;

        public delegate void OnAssemblyMatched(string assemblyName);
        public event OnAssemblyMatched AssemblyMatched;

        public delegate void OnHttpHandlerDefinitionClassFound(string nameSpace, string className, string description);
        public event OnHttpHandlerDefinitionClassFound HttpHandlerDefinitionClassFound;

        public delegate void OnHttpHandlerParameterDefinitionFound(string className, string parameterName, string expectedValues, string description);
        public event OnHttpHandlerParameterDefinitionFound HttpHandlerParameterDefinitionFound;


        public void ScanAssemblies()
        {
            ScanAssemblies(string.Empty);
        }


        public void ScanAssemblies(string assemblyNameFilter)
        {
            string currentAssemblyName;
            Assembly currentAssembly;
            AppDomain currentDomain = AppDomain.CurrentDomain;

            if (MiscInformationFound != null)
            {
                MiscInformationFound("Target AppDomain", currentDomain.FriendlyName);
            }

            Evidence asEvidence = currentDomain.Evidence;
            Assembly[] assems = currentDomain.GetAssemblies();

            foreach (Assembly assem in assems)
            {
                currentAssembly = assem;
                currentAssemblyName = currentAssembly.ToString();

                if (assemblyNameFilter.Equals(string.Empty))
                {
                    if (AssemblyMatched != null)
                    {
                        AssemblyMatched(currentAssembly.FullName);
                    }

                    try
                    {
                        ScanAssembly(currentAssembly);
                    }
                    catch (Exception ex)
                    {
                        if (MiscInformationFound != null)
                        {
                            MiscInformationFound("Error", string.Format("<b>{0}</b><br>{1}<br><pre>{2}</pre>", ex.Message, ex.Source, ex.StackTrace));
                        }
                    }
                }
                else
                {
                    if (
                        (currentAssemblyName.StartsWith("App_")) |
                        (currentAssemblyName.StartsWith(assemblyNameFilter))
                        )
                    {
                        if (AssemblyMatched != null)
                        {
                            AssemblyMatched(currentAssembly.FullName);
                        }

                        try
                        {
                            ScanAssembly(currentAssembly);
                        }
                        catch (Exception ex)
                        {
                            if (MiscInformationFound != null)
                            {
                                MiscInformationFound("Error", string.Format("<b>{0}</b><br>{1}<br><pre>{2}</pre>", ex.Message, ex.Source, ex.StackTrace));
                            }
                        }
                    }
                }
            }
        }


        private void ScanAssembly(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            for (int t = 0; t < types.Length; t++)
            {
                ScanType(types[t]);
            }
        }

        private void ScanType(Type typeToParse)
        {
            ScanType(typeToParse, false);
        }

        private void ScanType(Type typeToParse, bool parentIsHttpHandler)
        {
            bool isLoggingEventIdDefinitionClass = parentIsHttpHandler;

            if (parentIsHttpHandler)
            {
                ScanTypeForFields(typeToParse);
            }
            else
            {
                //object currentAttribute;
                object[] customAttributes = typeToParse.GetCustomAttributes(false);

                for (int a = 0; a < customAttributes.Length; a++)
                {
                    if (customAttributes[a] is IsHttpHandler)
                    {
                        isLoggingEventIdDefinitionClass = true;
                        if (HttpHandlerDefinitionClassFound != null)
                        {
                            Morphfolia.Common.Attributes.IsHttpHandler eventDefClass = (Morphfolia.Common.Attributes.IsHttpHandler)customAttributes[a];
                            HttpHandlerDefinitionClassFound(typeToParse.Namespace, typeToParse.Name, eventDefClass.Description);
                        }

                        ScanTypeForFields(typeToParse);
                        //break;
                    }
                }

                //if (isLoggingEventIdDefinitionClass)
                //{
                //    if (HttpHandlerDefinitionClassFound != null)
                //    {
                //        Morphfolia.Common.Attributes.IsHttpHandler eventDefClass = (Morphfolia.Common.Attributes.IsHttpHandler)customAttributes[a];                
                //        HttpHandlerDefinitionClassFound(typeToParse.Namespace, typeToParse.Name, eventDefClass.Description);
                //    }     

                //    ScanTypeForFields(typeToParse);
                //}
            }

            // Now scan child types: 
            Type[] types = typeToParse.GetNestedTypes();
            for (int t = 0; t < types.Length; t++)
            {
                ScanType(types[t], isLoggingEventIdDefinitionClass);
            }
        }



        private void ScanTypeForFields(Type typeToParse)
        {
            FieldInfo currentField;
            FieldInfo[] fields = typeToParse.GetFields();
            for (int f = 0; f < fields.Length; f++)
            {
                currentField = fields[f];
                object[] customFieldAttributes = currentField.GetCustomAttributes(false);

                for (int fa = 0; fa < customFieldAttributes.Length; fa++)
                {
                    if (customFieldAttributes[fa] is Morphfolia.Common.Attributes.IsHttpHandlerParameter)
                    {
                        IsHttpHandlerParameter fld = (IsHttpHandlerParameter)customFieldAttributes[fa];

                        if (HttpHandlerParameterDefinitionFound != null)
                        {
                            HttpHandlerParameterDefinitionFound(typeToParse.Name, fld.ParameterName, fld.ExpectedValues, fld.Description);
                        }
                        //break;
                    }
                }
            }
        }

    }
}
