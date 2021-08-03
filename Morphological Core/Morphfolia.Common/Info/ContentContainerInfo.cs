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
    ///  Summary description for ContentContainerInfo.
    /// </summary>
    public struct ContentContainerInfo
    {
        public readonly string ContainerName;
        public readonly string Colour;
        public readonly string Description;

        public ContentContainerInfo(
            string containerName,
            string colour,
            string description)
        {
            ContainerName = containerName;
            Colour = colour;
            Description = description;
        }
    }


    public class ContentContainerInfoCollection : CollectionBase
    {
        public ContentContainerInfo this[int index]
        {
            get { return ((ContentContainerInfo)List[index]); }
            set { List[index] = value; }
        }

        public int Add(ContentContainerInfo value)
        {
            return (List.Add(value));
        }

        public int IndexOf(ContentContainerInfo value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, ContentContainerInfo value)
        {
            List.Insert(index, value);
        }

        public void Remove(ContentContainerInfo value)
        {
            List.Remove(value);
        }

        public bool Contains(ContentContainerInfo value)
        {
            // If value is not of type ContentContainerInfo, this will return false.
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
            if (value.GetType() != Type.GetType("Morphfolia.Common.Info.ContentContainerInfo"))
                throw new ArgumentException("value must be of type Morphfolia.Common.Info.ContentContainerInfo.", "value");
        }
    }

}