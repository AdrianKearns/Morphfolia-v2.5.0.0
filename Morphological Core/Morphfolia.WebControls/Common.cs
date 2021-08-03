// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.WebControls.Common
{
    /// <summary>
    /// Defines the path of the JavaScript used by the Morphfolia.WebControls.SearchInput WebControl.
    /// </summary>
    /// <remarks>Related to Morphfolia.Common.Constants.Framework.ClientScriptRegistrationKeys</remarks>
    public class JavaScriptFileURLs
    {
        /// <summary>
        /// Root relative URL, prefixed with a /, 
        /// e.g: "/JavaScript/ABKSuggests.js"
        /// </summary>
        public static string ABKSuggests
        {
            get { return "/Morphfolia/JavaScript/ABKSuggests.js"; }
        }
    }
}
