// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Reflection;
using System.Security.Policy;

namespace Morphfolia.Common.Utilities
{
    /// <summary>
    /// Uses reflection / attributes to scan for 
    /// logging EventIds.  Useful for providing a self documenting system.
    /// </summary>
    public class EventIdExtractor
    {
        public delegate void OnMiscInformationFound(string key, string val);
        public event OnMiscInformationFound MiscInformationFound;

        public delegate void OnAssemblyMatched(string assemblyName);
        public event OnAssemblyMatched AssemblyMatched;

        public delegate void OnEventIdDefinitionClassFound(string nameSpace, string className, string eventIdRange, string description);
        public event OnEventIdDefinitionClassFound EventIdDefinitionClassFound;

        public delegate void OnEventIdDefinitionFound(string fieldName, int eventId, string description);
        public event OnEventIdDefinitionFound EventIdDefinitionFound;


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

            //List the assemblies in the current application domain.
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
            bool isLoggingEventIdDefinitionClass;
            Type currentType;
            Type[] types = assembly.GetTypes();

            for (int t = 0; t < types.Length; t++)
            {
                currentType = types[t];
                isLoggingEventIdDefinitionClass = false;

                object[] customAttributes = currentType.GetCustomAttributes(false);

                for (int a = 0; a < customAttributes.Length; a++)
                {
                    if (customAttributes[a] is Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass)
                    {
                        isLoggingEventIdDefinitionClass = true;
                        Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass eventDefClass = (Morphfolia.Common.Attributes.IsLoggingEventIdDefinitionClass)customAttributes[a];

                        if (EventIdDefinitionClassFound != null)
                        {
                            EventIdDefinitionClassFound(currentType.Namespace, currentType.Name, eventDefClass.Range, eventDefClass.Description);
                        }
                        break;
                    }
                }

                // Scan all fields regardless of it being 
                // IsLoggingEventIdDefinitionClass or not.
                ExtractAllFields(currentType, isLoggingEventIdDefinitionClass);
            }
        }


        private void ExtractAllFields(Type currentType, bool isLoggingEventIdDefinitionClass)
        {
            FieldInfo currentField;
            FieldInfo[] fields = currentType.GetFields();

            bool isLoggingEventIdDefinition;
            for (int f = 0; f < fields.Length; f++)
            {
                currentField = fields[f];
                isLoggingEventIdDefinition = false;

                object[] customAttributes = currentField.GetCustomAttributes(false);

                for (int a = 0; a < customAttributes.Length; a++)
                {
                    if (customAttributes[a] is Morphfolia.Common.Attributes.IsLoggingEventIdDefinition)
                    {
                        isLoggingEventIdDefinition = true;
                        Morphfolia.Common.Attributes.IsLoggingEventIdDefinition eventDef = (Morphfolia.Common.Attributes.IsLoggingEventIdDefinition)customAttributes[a];

                        if (EventIdDefinitionFound != null)
                        {
                            EventIdDefinitionFound(currentField.Name, eventDef.EventId, eventDef.Description);
                        }
                        break;
                    }                   
                }


                // Emit the field as a possible EventId definition if the 
                // parent class IsLoggingEventIdDefinitionClass - even 
                // if the field itself is not marked with the expected attribute.
                if ((isLoggingEventIdDefinitionClass)&(!isLoggingEventIdDefinition))
                {
                    if (MiscInformationFound != null)
                    {
                        MiscInformationFound(" . Possible EventId Definition", currentField.Name);
                    }
                }

            }
        }

    }
}
