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
    public class AppSettingKeyExtractor
    {
        public delegate void OnMiscInformationFound(string key, string val);
        public event OnMiscInformationFound MiscInformationFound;

        public delegate void OnAssemblyMatched(string assemblyName);
        public event OnAssemblyMatched AssemblyMatched;

        public delegate void OnAppSettingKeyDefinitionClassFound(string nameSpace, string className, string description);
        public event OnAppSettingKeyDefinitionClassFound AppSettingKeyDefinitionClassFound;

        public delegate void OnAppSettingKeyDefinitionFound(string fieldName, string key, string description, string usage);
        public event OnAppSettingKeyDefinitionFound AppSettingKeyDefinitionFound;


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
                    if (customAttributes[a] is Morphfolia.Common.Attributes.IsAppSettingKeyClass)
                    {
                        isLoggingEventIdDefinitionClass = true;
                        Morphfolia.Common.Attributes.IsAppSettingKeyClass eventDefClass = (Morphfolia.Common.Attributes.IsAppSettingKeyClass)customAttributes[a];

                        if (AppSettingKeyDefinitionClassFound != null)
                        {
                            AppSettingKeyDefinitionClassFound(currentType.Namespace, currentType.Name, eventDefClass.Description);
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
                    if (customAttributes[a] is Morphfolia.Common.Attributes.IsAppSettingKey)
                    {
                        isLoggingEventIdDefinition = true;
                        Morphfolia.Common.Attributes.IsAppSettingKey eventDef = (Morphfolia.Common.Attributes.IsAppSettingKey)customAttributes[a];

                        if (AppSettingKeyDefinitionFound != null)
                        {
                            AppSettingKeyDefinitionFound(currentField.Name, eventDef.Key, eventDef.Description, eventDef.Usage);
                        }
                        break;
                    }
                }


                // Emit the field as a possible EventId definition if the 
                // parent class IsLoggingEventIdDefinitionClass - even 
                // if the field itself is not marked with the expected attribute.
                if ((isLoggingEventIdDefinitionClass) & (!isLoggingEventIdDefinition))
                {
                    if (MiscInformationFound != null)
                    {
                        MiscInformationFound(" . Possible AppSettingKey Definition", currentField.Name);
                    }
                }

            }
        }

    }
}
