// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Morphfolia.PublishingSystem.HttpHandlers.Helpers
{
    internal class ErrorHandling
    {
        public static void HandleErrorNicelyForPublic(HttpContext httpContext)
        {

            httpContext.Response.Write("Sorry, there was an error.");


        }
    }
}
