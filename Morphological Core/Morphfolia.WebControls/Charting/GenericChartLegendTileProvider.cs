// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using Morphfolia.WebControls.Logging;
using Morphfolia.Common.Attributes;

namespace Morphfolia.WebControls.Charting
{
    [IsHttpHandler("Dynamically constructs and provides a chart legend as a jpg file.")]
    public class GenericChartLegendTileProvider : IHttpHandler
    {
        [IsHttpHandlerParameter("Size", "An int.", "Used to set the size (in pixels) of the chart (assumes a square).")]
        private static readonly string LegendSize = Constants.QueryStringKeys.GraphSize;

        [IsHttpHandlerParameter("ColourRange", "One of the named values defined in Morphfolia.WebControls.Constants.ColourRanges (which is a partial class).", "Used to identify the colour range to be used to colour the Chart.")]
        private static readonly string ColourRange = Constants.QueryStringKeys.ColourRange;

        [IsHttpHandlerParameter("ColourIndex", "?", "?")]
        private static readonly string ColourIndex = Constants.QueryStringKeys.ColourIndex;

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string colourRange = Utilities.HttpRequestHelper.GetRequestParamValue(ColourRange, Constants.ColourRanges.UrlHistory);

            int size;
            try
            {
                size = int.Parse(Utilities.HttpRequestHelper.GetRequestParamValue(LegendSize));
            }
            catch
            {
                size = 16;
            }

            int colourIndex;
            try
            {
                colourIndex = int.Parse(Utilities.HttpRequestHelper.GetRequestParamValue(ColourIndex));
            }
            catch
            {
                colourIndex = 0;
            }

            Color[] selectedColourRange = ChartingUtilities.GetColourRangeByName(colourRange);

            // Since we are outputting a Jpeg, set the ContentType appropriately
            context.Response.ContentType = "image/jpeg";

            ChartingUtilities.CreatePieChartLegend(context.Response.OutputStream, size, selectedColourRange[colourIndex]);
        }
    }
}
