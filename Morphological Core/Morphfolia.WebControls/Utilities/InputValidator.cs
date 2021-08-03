// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.WebControls.Utilities
{
    public class InputValidator
    {

        public static int StringToSearchSafeInt(string stringWeExpectToBeNumeric, int defaultValue)
        {
            int output = -1;

            try
            {
                output = int.Parse(stringWeExpectToBeNumeric);
            }
            catch
            {
                output = defaultValue;
            }

            return output;
        }


        public static DateTime StringToSafeDateTime(string stringWeExpectToBeDateTime)
        {
            DateTime output = Morphfolia.Common.Constants.SystemTypeValues.NullDate;

            try
            {
                output = DateTime.Parse(stringWeExpectToBeDateTime);
            }
            catch
            {
                output = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
            }

            return output;
        }

    }
}
