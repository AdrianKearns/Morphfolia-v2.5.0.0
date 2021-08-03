// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Morphological.Kudos.Utilities
{
    class WebControlUtilities
    {

        /// <summary>
        /// Takes a string and returns a HorizontalAlign.
        /// </summary>
        /// <remarks>Not sure why this is here, will look to refactor, eventually.</remarks>
        /// <param name="horizontalAlign">string</param>
        /// <returns>HorizontalAlign</returns>
        public static HorizontalAlign HorizontalAlignFromstring(string horizontalAlign)
        {
            switch (horizontalAlign.ToLower())
            {
                case "left":
                    return HorizontalAlign.Left;

                case "center":
                    return HorizontalAlign.Center;

                case "right":
                    return HorizontalAlign.Right;

                default:
                    return HorizontalAlign.NotSet;
            }
        }

    }
}
