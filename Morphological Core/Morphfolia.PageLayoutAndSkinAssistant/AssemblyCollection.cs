// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using System.Reflection;

namespace Morphfolia.PageLayoutAndSkinAssistant
{
    internal class AssemblyCollection : CollectionBase
    {
        public Assembly this[int index]
        {
            get { return ((Assembly)List[index]); }
            set { List[index] = value; }
        }

        public int Add(Assembly value)
        {
            return (List.Add(value));
        }

        public int IndexOf(Assembly value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, Assembly value)
        {
            List.Insert(index, value);
        }

        public void Remove(Assembly value)
        {
            List.Remove(value);
        }

        public bool Contains(Assembly value)
        {
            // If value is not of type Assembly, this will return false.
            return (List.Contains(value));
        }

        //protected override void OnInsert(int index, Object value)
        //{
        //    // Insert additional code to be run only when inserting values.
        //}

        //protected override void OnRemove(int index, Object value)
        //{
        //    // Insert additional code to be run only when removing values.
        //}

        //protected override void OnSet(int index, Object oldValue, Object newValue)
        //{
        //    // Insert additional code to be run only when setting values.
        //}

        //protected override void OnValidate(Object value)
        //{
        //    if (value.GetType() != Type.GetType("Morphfolia.Common.Info.Assembly"))
        //        throw new ArgumentException("value must be of type Morphfolia.Common.Info.Assembly.", "value");
        //}
    }    
}
