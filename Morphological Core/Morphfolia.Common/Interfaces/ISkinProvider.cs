// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Info;
using System.Web.UI.WebControls;

namespace Morphfolia.Common.Interfaces
{
    public interface ISkinProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateInstanceId">Typically the PageID, but can be something else.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        WebControl MakePageFooter(IPage page);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateInstanceId">Typically the PageID, but can be something else.</param>
        /// <param name="page"></param>
        /// <returns></returns>
        WebControl MakePageHeader(IPage page);

        void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties);
    }
}