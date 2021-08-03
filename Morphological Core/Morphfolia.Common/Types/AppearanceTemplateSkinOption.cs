// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

//using System;
//using System.Collections;
//using System.Collections.Specialized;

//namespace Morphfolia.Common.Types
//{
//    /// <summary>
//    /// Defines a Appearance-Template Skin-Option.
//    /// </summary>
//    /// <remarks>
//    /// A AppearanceTemplateSkinOption applies to an implementation of a IAppearanceTemplate.
//    /// It describes a template-option available to the user - such as banner image and so on.
//    /// </remarks>
//    public class AppearanceTemplateSkinOption
//    {
//        public AppearanceTemplateSkinOption()
//        {
//        }

//        public AppearanceTemplateSkinOption(
//            string friendlyName,
//            string description,
//            string thumbnailImgUrl,
//            string systemIdentifier)
//        {
//            FriendlyName = friendlyName;
//            Description = description;
//            ThumbnailImgUrl = thumbnailImgUrl;
//            SystemIdentifier = systemIdentifier;
//        }

//        public AppearanceTemplateSkinOption(
//            string friendlyName,
//            string description,
//            string thumbnailImgUrl,
//            string systemIdentifier,
//            NameValueCollection settings)
//        {
//            FriendlyName = friendlyName;
//            Description = description;
//            ThumbnailImgUrl = thumbnailImgUrl;
//            SystemIdentifier = systemIdentifier;
//            Settings = settings;
//        }


//        private string friendlyName = string.Empty;
//        public string FriendlyName
//        {
//            get { return friendlyName; }
//            set { friendlyName = value;  }
//        }

//        private string thumbnailImgUrl = string.Empty;
//        /// <summary>
//        /// The url of an image which visially shows the user what the skin is / looks like.
//        /// </summary>
//        /// <remarks>
//        /// If the only difference in the actual skin implementation is a banner image, 
//        /// and that image is not emornous, you could just show the actual banner, and use this 
//        /// value when constructing the actual skin.
//        /// </remarks>
//        public string ThumbnailImgUrl
//        {
//            get { return thumbnailImgUrl; }
//            set { thumbnailImgUrl = value; }
//        }

//        private string description = string.Empty;
//        public string Description
//        {
//            get { return description; }
//            set { description = value; }
//        }

//        private string systemIdentifier = string.Empty;
//        public string SystemIdentifier
//        {
//            get { return systemIdentifier; }
//            set { systemIdentifier = value; }
//        }

//        private NameValueCollection settings;
//        /// <summary>
//        /// Holds any other WebLayoutTemplateOption options you might 
//        /// want to use internally in your IAppearanceTemplate.
//        /// </summary>
//        public NameValueCollection Settings
//        {
//            get
//            {
//                if (settings == null)
//                {
//                    settings = new NameValueCollection();
//                }
//                return settings;
//            }
//            set { settings = value; }
//        } 
//    }


//    /// <summary>
//    /// Defines a collection of Appearance-Template Skin-Options.
//    /// </summary>
//    /// <remarks>
//    /// A AppearanceTemplateSkinOptionCollection applies to an implementation of a IAppearanceTemplate.
//    /// It describes all the available template-options to the user - such as banner image and so on.
//    /// </remarks>
//    public class AppearanceTemplateSkinOptionCollection : CollectionBase
//    {

//        public AppearanceTemplateSkinOption GetBySystemIndentifer(string systemIndentifer)
//        {
//            AppearanceTemplateSkinOption skinOption;

//            for (int index = 0; index < List.Count; index++)
//            {
//                skinOption = (AppearanceTemplateSkinOption)List[index];
//                if (skinOption.SystemIdentifier.Equals(systemIndentifer))
//                {
//                    return skinOption;
//                }
//            }

//            return null;
//        }

//        public AppearanceTemplateSkinOption this[int index]
//        {
//            get
//            {
//                try
//                {
//                    return ((AppearanceTemplateSkinOption)List[index]);
//                }
//                catch (System.Exception e)
//                {
//                    throw new IndexOutOfRangeException(string.Format("index {0} not found.", index.ToString()), e);
//                }
//            }
//            set { List[index] = value; }
//        }

//        /// <exclude />
//        public int Add(AppearanceTemplateSkinOption value)
//        {
//            return (List.Add(value));
//        }

//        /// <exclude />
//        public int IndexOf(AppearanceTemplateSkinOption value)
//        {
//            return (List.IndexOf(value));
//        }

//        /// <exclude />
//        public void Insert(int index, AppearanceTemplateSkinOption value)
//        {
//            List.Insert(index, value);
//        }

//        /// <exclude />
//        public void Remove(AppearanceTemplateSkinOption value)
//        {
//            List.Remove(value);
//        }

//        /// <exclude />
//        public bool Contains(AppearanceTemplateSkinOption value)
//        {
//            // If value is not of type ContentInfo, this will return false.
//            return (List.Contains(value));
//        }

//        /// <exclude />
//        protected override void OnInsert(int index, Object value)
//        {
//            // Insert additional code to be run only when inserting values.
//        }

//        /// <exclude />
//        protected override void OnRemove(int index, Object value)
//        {
//            // Insert additional code to be run only when removing values.
//        }

//        /// <exclude />
//        protected override void OnSet(int index, Object oldValue, Object newValue)
//        {
//            // Insert additional code to be run only when setting values.
//        }

//        /// <exclude />
//        protected override void OnValidate(Object value)
//        {
//            if (value.GetType() != Type.GetType("Morphfolia.Common.Types.AppearanceTemplateSkinOption"))
//                throw new ArgumentException("value must be of type Morphfolia.Common.Types.AppearanceTemplateSkinOption.", "value");
//        }
//    }
//}
