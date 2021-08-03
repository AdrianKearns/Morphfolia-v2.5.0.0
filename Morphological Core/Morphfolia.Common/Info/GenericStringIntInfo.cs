// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;

namespace Morphfolia.Common.Info
{
    /// <summary>
    ///  Summary description for GenericStringIntInfo.
    /// </summary>
    public struct GenericStringIntInfo
    {
        public readonly string Text;
        public readonly int Number;

        public GenericStringIntInfo(
            string _Text,
            int _Number)
        {
            Text = _Text;
            Number = _Number;
        }
    }


    public class GenericStringIntInfoCollection : CollectionBase
    {
        public GenericStringIntInfo this[int index]
        {
            get { return ((GenericStringIntInfo)List[index]); }
            set { List[index] = value; }
        }

        public int Add(GenericStringIntInfo value)
        {
            return (List.Add(value));
        }

        public int IndexOf(GenericStringIntInfo value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, GenericStringIntInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(GenericStringIntInfo value)
        {
            List.Remove(value);
        }

        public bool Contains(GenericStringIntInfo value)
        {
            // If value is not of type GenericStringIntInfo, this will return false.
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value)
        {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != Type.GetType("Morphfolia.Common.Info.GenericStringIntInfo"))
                throw new ArgumentException("value must be of type Morphfolia.Common.Info.GenericStringIntInfo.", "value");
        }
    }

}