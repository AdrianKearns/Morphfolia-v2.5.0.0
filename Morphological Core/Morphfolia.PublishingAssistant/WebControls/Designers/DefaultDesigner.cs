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

namespace Morphfolia.PublishingSystem.WebControls.Designers
{
    public class DefaultDesigner : ControlDesigner
    {
        public override bool AllowResize
        {
            get
            {
                //return base.AllowResize;
                return true;
            }
        }


        public override string GetDesignTimeHtml()
        {
            return string.Format("<div style='border: 1px dashed #666666; padding: 2px; width:{1}; height:{2};'>[{0}]</div>",
                this.ID,
                ((WebControl)this.Component).Width.ToString(),
                ((WebControl)this.Component).Height.ToString());
        }
    }
}
