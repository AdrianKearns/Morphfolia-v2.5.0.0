// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

namespace Morphfolia.Common
{
	/// <summary>
	/// Summary description for VerySimpleMethodsThatShouldBeRefactored.
	/// </summary>
	public class VerySimpleMethodsThatShouldBeRefactored
	{
		public static int SafeStringToInt( string isHopefullyANumber )
		{
			try
			{
				return int.Parse( isHopefullyANumber );
			}
			catch
			{
				return Constants.SystemTypeValues.NullInt;
			}
		}


        public static string prefixNumberWith0(int n, int length)
        {
            string output = n.ToString();
            while (output.Length < length)
            {
                output = string.Format("0{0}", output);
            }
            return output;
        }
	}
}
