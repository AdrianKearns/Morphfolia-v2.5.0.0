// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web.UI.WebControls;
using Morphfolia.Common.Interfaces;

namespace Morphfolia.Common.Interfaces
{
    public interface IFormTemplatePresenterProvider
    {
        WebControl MakePresenter(string formTemplateXml);
        WebControl MakePresenter(IFormTemplate formTemplate);
    }
}
