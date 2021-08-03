// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using Morphfolia.Common.Interfaces;


namespace Morphfolia.Common.Types
{


    public enum FormTemplateFieldType { Small, Medium, Large, InLineImage, InLineVideo, LinkToFile, LinkToUrl };



    public class FormTemplate : IFormTemplate
    {
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private FormTemplateFieldCollection fields = null;
        public FormTemplateFieldCollection Fields
        {
            get
            {
                if (fields == null)
                {
                    fields = new FormTemplateFieldCollection();
                }
                return fields;
            }
            set { fields = value; }
        }
    }

    public class FormTemplateCollection : CollectionBase
    {
        public FormTemplate this[int index]
        {
            get { return ((FormTemplate)List[index]); }
            set { List[index] = value; }
        }

        public int Add(FormTemplate value)
        {
            return (List.Add(value));
        }

        public int IndexOf(FormTemplate value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, FormTemplate value)
        {
            List.Insert(index, value);
        }

        public void Remove(FormTemplate value)
        {
            List.Remove(value);
        }

        public bool Contains(FormTemplate value)
        {
            // If value is not of type Field, this will return false.
            return (List.Contains(value));
        }
    }





    public class FormTemplateField
    {
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private FormTemplateFieldType type = FormTemplateFieldType.Medium;
        public FormTemplateFieldType Type
        {
            get { return type; }
            set { type = value; }
        }
    }

    public class FormTemplateFieldCollection : CollectionBase
    {
        public FormTemplateField this[int index]
        {
            get { return ((FormTemplateField)List[index]); }
            set { List[index] = value; }
        }

        public int Add(FormTemplateField value)
        {
            return (List.Add(value));
        }

        public int IndexOf(FormTemplateField value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, FormTemplateField value)
        {
            List.Insert(index, value);
        }

        public void Remove(FormTemplateField value)
        {
            List.Remove(value);
        }

        public bool Contains(FormTemplateField value)
        {
            // If value is not of type Field, this will return false.
            return (List.Contains(value));
        }
    }



}