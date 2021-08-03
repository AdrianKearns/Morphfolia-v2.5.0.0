// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class IsAppSettingKey : Attribute
    {
        public IsAppSettingKey(string key)
        {
            Key = key;
        }

        public IsAppSettingKey(string key, string description)
        {
            Key = key;
            Description = description;
        }

        public IsAppSettingKey(string key, string description, string usage)
        {
            Key = key;
            Description = description;
            Usage = usage;
        }

        private string key = string.Empty;
        /// <summary>
        /// The appSettingKey as it appears in config.
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string description = string.Empty;
        /// <summary>
        /// What the key specifies.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string usage = string.Empty;
        /// <summary>
        /// Typical usage or expected value(s).
        /// </summary>
        public string Usage
        {
            get { return usage; }
            set { usage = value; }
        }
    }
}
