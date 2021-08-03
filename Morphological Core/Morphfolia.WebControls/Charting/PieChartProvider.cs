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
    [IsHttpHandler("Dynamically constructs and provides pie charts as jpg files.")]
    public class PieChartProvider : IHttpHandler
    {
        [IsHttpHandlerParameter("ColourRange", "One of the named values defined in Morphfolia.WebControls.Constants.ColourRanges (which is a partial class).", "Used to identify the colour range to be used to colour the Chart.")]
        public static readonly string ColourRange = Constants.QueryStringKeys.ColourRange;

        [IsHttpHandlerParameter("Segment", "A string of values seperated by commas, e.g.: 12,6,34,100,5", "Used to identify the segment values for a Pie Chart.")]
        public static readonly string Segment = Constants.QueryStringKeys.Segment;

        [IsHttpHandlerParameter("Size", "An int", "Used to set the size (in pixels) of the chart (assumes a square).")]
        public static readonly string GraphSize = Constants.QueryStringKeys.GraphSize;



        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            Color[] selectedColourRange;
            string colourRange = Utilities.HttpRequestHelper.GetRequestParamValue(ColourRange);
            string raw = Utilities.HttpRequestHelper.GetRequestParamValue(Segment);

            int size;
            try
            {
                size = int.Parse(Utilities.HttpRequestHelper.GetRequestParamValue(GraphSize));
            }
            catch
            {
                size = 300;
            }


            selectedColourRange = ChartingUtilities.GetColourRangeByName(colourRange);



            if (raw.Equals(string.Empty))
            {
                context.Response.StatusCode = 404;
            }
            else
            {
                string[] rawAmounts = raw.Split(Char.Parse(","));

                int[] amounts = new int[rawAmounts.Length];
                for (int i = 0; i < rawAmounts.Length; i++)
                {
                    amounts[i] = int.Parse(rawAmounts[i]);
                }

                if (amounts.Length == 0)
                {
                    context.Response.StatusCode = 404;
                }
                else
                {
                    // Since we are outputting a Jpeg, set the ContentType appropriately
                    context.Response.ContentType = "image/jpeg";

                    int[] segments = ChartingUtilities.ConvertRawAmountsToPieChartSegmentRatios(amounts);

                    ChartingUtilities.CreatePieChart(context.Response.OutputStream, segments, size, selectedColourRange);
                }
            }
        }
    }
}