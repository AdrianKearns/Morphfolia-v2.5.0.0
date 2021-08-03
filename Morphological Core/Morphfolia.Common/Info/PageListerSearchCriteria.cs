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
	///  Summary description for PageInfo.
	/// </summary>
	public struct PageListerSearchCriteria
	{
		public readonly bool IsLive;
		public readonly bool IsSearchable;

		public PageListerSearchCriteria(
			bool isLive,
			bool isSearchable)
		{
			this.IsLive = isLive;
			this.IsSearchable = isSearchable;
		}
	}

}