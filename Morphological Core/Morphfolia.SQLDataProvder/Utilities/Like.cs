// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.SQLDataProvider.Utilities
{
    public class Like
    {
        /// <summary>
        /// Ensures a string will be useful in a LIKE search. 
        /// Replaces empty strings with %.
        /// Replaces * with %.
        /// Wraps terms with % (%[expression]%) when % is not detected.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string SafeLikeExpression(string expression)
        {
            if(expression.Equals(string.Empty))
            {
                return "%";
            }

            string output = expression.Replace("*", "%");

            if (!output.Contains("%"))
            {
                output = string.Format("%{0}%", output);
            }

            return output;
        }
    }
}
