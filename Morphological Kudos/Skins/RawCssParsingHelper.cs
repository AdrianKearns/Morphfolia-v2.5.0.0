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

namespace Morphological.Kudos.Skins
{
    internal class RawCssParsingHelper
    {
        public static void ParseRawCssAndAddToObjectsStyle(WebControl targetWebControl, string rawCss)
        {
            char ruleDelimiter = Char.Parse(";");
            char componentDelimiter = Char.Parse(":");

            string[] cssRules = rawCss.Split(ruleDelimiter);


            string cssRule = string.Empty;
            string cssAttribute = string.Empty;
            string cssAttributeValue = string.Empty;
            int spiltPoint;

            for(int i = 0; i < cssRules.Length; i++)
            {
                cssRule = cssRules[i];
                spiltPoint = cssRule.LastIndexOf(componentDelimiter);

                //Morphfolia.Common.Logging.Logger.LogVerboseInformation(string.Format("a[{0}|{1}]", spiltPoint.ToString(), cssRule), "ABBA");

                if (spiltPoint > -1)
                {
                    cssAttribute = cssRule.Substring(0, spiltPoint).Trim();
                    cssAttributeValue = cssRule.Substring(spiltPoint+1).Trim();

                    //Morphfolia.Common.Logging.Logger.LogVerboseInformation(string.Format("b[{0}|{1}]", cssAttribute, cssAttributeValue), "ABBA");

                    targetWebControl.Style.Add(cssAttribute, cssAttributeValue);
                }
            }




        }
    }
}
