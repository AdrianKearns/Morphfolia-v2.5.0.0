// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text;

namespace Morphfolia.WebControls.Designers
{
    public class DefaultDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            return string.Format("<p style='border: 1px solid #000000; padding: 10px;'>[{0}]</p>", this.ID);
        }
    }


}
