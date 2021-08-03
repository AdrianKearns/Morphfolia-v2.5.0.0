// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using Morphfolia.WebControls.Logging;



namespace Morphfolia.WebControls.Charting
{

    public class ChartingUtilities
    {
        /// <summary>
        /// builds a valid url for calling the pie chart http-handler.
        /// </summary>
        /// <returns></returns>
        public static string MakeUrlToPieChartProvider(int size, int[] segmentAmounts)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendFormat("{0}?{1}=", Constants.PieChartProviderUrl, Constants.QueryStringKeys.GraphSize);

            // lets enforce a sensible size:
            if ((size < 10) | (size > 2000))
            {
                sb.Append(150);
            }
            else
            {
                sb.Append(size);
            }
            sb.AppendFormat("&{0}=", Constants.QueryStringKeys.Segment);

            if (segmentAmounts.Length < 2)
            {
                // ?
                Logger.LogWarning("PieChartHelper.MakeUrl()", "PieChartHelper.MakeUrl() was called without specifying enough segment amounts.");
            }
            else
            {
                sb.AppendFormat("{0}", segmentAmounts[0]);
                for (int i = 1; i < segmentAmounts.Length; i++)
                {
                    sb.AppendFormat(",{0}", segmentAmounts[i]);
                }
            }

            return sb.ToString();
        }


        public static string MakeUrlToPieChartLegendTileProvider(int size, int colourIndex)
        {
            return MakeUrlToPieChartLegendTileProvider(size, colourIndex, Constants.ColourRanges.Default);
        }

        public static string MakeUrlToPieChartLegendTileProvider(int size, int colourIndex, string colourRange)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendFormat("{0}?{1}=", 
                Constants.GenericChartLegendTileProviderUrl, 
                Constants.QueryStringKeys.GraphSize);

            // ColourRange

            // lets enforce a sensible size:
            if ((size < 1) | (size > 300))
            {
                sb.Append(16);
            }
            else
            {
                sb.Append(size);
            }
            sb.AppendFormat("&{0}={1}", Constants.QueryStringKeys.ColourIndex, colourIndex);

            sb.AppendFormat("&{0}={1}", Constants.QueryStringKeys.ColourRange, colourRange);

            return sb.ToString();
        }


        public static int GetNextIndexForColourRange(Color[] colourRange, int currentIndex)
        {
            // 0, 1, 2 (3)
            // 1, 2, 3

            int nextIndex = currentIndex + 1;

            if (nextIndex >= colourRange.Length)
            {
                nextIndex = 0;
            }

            //return colourRange[nextIndex];
            return nextIndex;
        }

        /// <summary>
        /// converts any array of integers into valid pie-chart segments ratios 
        /// (percentages of 360).
        /// </summary>
        /// <remarks>For example, an array of 1,1,1,1 would become four equal segments of 90 degrees.
        /// An array of 45,75,120 would become three segments of and 67.5, 112.5 and 180 degress, respectively.</remarks>
        /// <param name="incomingRawAmounts"></param>
        /// <returns></returns>
        public static int[] ConvertRawAmountsToPieChartSegmentRatios(int[] rawAmounts)
        {
            int grandTotal = 0;
            float newThing = 1.1F;
            int[] segmentRatios = new int[rawAmounts.Length];

            for (int i = 0; i < rawAmounts.Length; i++)
            {
                grandTotal = grandTotal + rawAmounts[i];
            }

            newThing = (float)360 / grandTotal;

            for (int i = 0; i < rawAmounts.Length; i++)
            {
                segmentRatios[i] = (int)(rawAmounts[i] * newThing);
            }

            return segmentRatios;
        }

        public static void CreatePieChart(System.IO.Stream outputStream, int[] segmentRatios, int size, Color[] colourRange)
        {
            int width = size;
            int height = size;
            int paddingX = 10;
            int paddingY = 10;

            using (Bitmap objBitmap = new Bitmap((width + (paddingX * 2)), (height + (paddingY * 2))))
            {
                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    objGraphics.SmoothingMode = SmoothingMode.HighQuality;
                    //objGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                    objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, (width + (paddingX * 2)), (height + (paddingY * 2)));

                    int currentColourIndex = 0;
                    int startAngle = 0;
                    int sweepAngle = 0;
                    SolidBrush objBrush = new SolidBrush(Color.White);

                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < segmentRatios.Length; i++)
                    {
                        sweepAngle = segmentRatios[i];
                        if (i == (segmentRatios.Length - 1))
                        {
                            sweepAngle = sweepAngle + (360 - (startAngle + sweepAngle));
                            //sb.AppendFormat("<br>{0}, {1}*", startAngle, sweepAngle);
                        }

                        objBrush.Color = colourRange[currentColourIndex];
                        currentColourIndex = GetNextIndexForColourRange(colourRange, currentColourIndex);

                        // startAngle 0 - segments start at 3 O'Clock
                        // startAngle -90 - segments start at 12 O'Clock
                        //sb.AppendFormat("<br>{0}, {1}", startAngle-90, sweepAngle);
                        objGraphics.FillPie(objBrush, paddingX, paddingY, width, height, startAngle - 90, sweepAngle);

                        startAngle = startAngle + sweepAngle;
                    }

                    objBitmap.Save(outputStream, ImageFormat.Jpeg);
                    outputStream.Flush();

                    //Logger.LogVerboseInformation("PieChartMathsHelper", sb.ToString(), 666);
                }
            }
        }

        public static void CreatePieChartLegend(System.IO.Stream outputStream, int size, Color colour)
        {
            int width = size;
            int height = size;
            //int paddingX = 10;
            //int paddingY = 10;

            using (Bitmap objBitmap = new Bitmap(width, height))
            {
                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    objGraphics.SmoothingMode = SmoothingMode.HighQuality;
                    //objGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                    objGraphics.FillRectangle(new SolidBrush(colour), 0, 0, width, height);

                    objBitmap.Save(outputStream, ImageFormat.Jpeg);
                    outputStream.Flush();

                }
            }

        }

        public static Color[] GetColourRangeByName(string namedColourRange)
        {
            if (namedColourRange.Equals(Constants.ColourRanges.SoftBlue))
            {
                return ColourRanges.SoftBlueColourRange;
            }

            if (namedColourRange.Equals(Constants.ColourRanges.Grey))
            {
                return ColourRanges.GreyColourRange;
            }

            if (namedColourRange.Equals(Constants.ColourRanges.Experimental))
            {
                return ColourRanges.ExperimentalColourRange;
            }

            if (namedColourRange.Equals(Constants.ColourRanges.Default))
            {
                return ColourRanges.NamedColourRange;
            }

            if (namedColourRange.Equals(Constants.ColourRanges.UrlHistory))
            {
                return ColourRanges.UrlHistoryColourRange;
            }
  
            return ColourRanges.NamedColourRange;                                
        }

        /// <summary>
        /// Returns a specific DashStyle based on the int passed in.
        /// </summary>
        /// <remarks>
        /// Handles values 0 < and > 4 as 'Solid'.
        /// 0 = Solid 
        /// 1 = Dash 
        /// 2 = Dash Dot 
        /// 3 = Dash Dot Dot 
        /// 4 = Dot 
        /// </remarks>
        /// <param name="n"></param>
        /// <returns></returns>
        public static DashStyle GetDashStyleByNumber(int n)
        {
            if (n <= 0)
            {
                return DashStyle.Solid;
            }

            if (n == 1)
            {
                return DashStyle.Dash;
            }

            if (n == 2)
            {
                return DashStyle.DashDot;
            }

            if (n == 3)
            {
                return DashStyle.DashDotDot;
            }

            if (n == 4)
            {
                return DashStyle.Dot;
            }

            if (n >= 5)
            {
                return DashStyle.Solid;
            }

            return DashStyle.Solid;
        }
    }



    public class ColourRanges
    {
        //15.9375	0
        //31.875	1
        //47.8125	2
        //63.75	    3
        //79.6875	4
        //95.625	5
        //111.5625	6
        //127.5	    7
        //143.4375	8
        //159.375	9
        //175.3125	a
        //191.25	b
        //207.1875	c
        //223.125	d
        //239.0625	e
        //255	    f
        public static Color[] GreyColourRange = new Color[8] {
        Color.FromArgb(15, 15, 15),        // black
        //Color.FromArgb(31, 31, 31),        // black
        Color.FromArgb(47, 47, 47),  // grey
        //Color.FromArgb(63, 63, 63),  // grey
        Color.FromArgb(79, 79, 79),  // grey
        //Color.FromArgb(95, 95, 95),  // white
        Color.FromArgb(111, 111, 111),      //r
        //Color.FromArgb(127, 127, 127),      //g
        Color.FromArgb(143, 143, 143),      //b
        //Color.FromArgb(159, 159, 159),
        Color.FromArgb(175, 175, 175),
        //Color.FromArgb(191, 191, 191),
        Color.FromArgb(207, 207, 207),
        //Color.FromArgb(223, 223, 223),
        Color.FromArgb(239, 239, 239)};

        public static Color[] SoftBlueColourRange = new Color[8] {
        Color.FromArgb(15, 191, 207), 
        //Color.FromArgb(31, 191, 207), 
        Color.FromArgb(47, 191, 207), 
        //Color.FromArgb(63, 191, 207), 
        Color.FromArgb(79, 191, 207), 
        //Color.FromArgb(95, 191, 207), 
        Color.FromArgb(111, 191, 207), 
        //Color.FromArgb(127, 191, 207), 
        Color.FromArgb(143, 191, 207), 
        //Color.FromArgb(159, 191, 207), 
        Color.FromArgb(175, 191, 207), 
        //Color.FromArgb(191, 191, 207), 
        Color.FromArgb(207, 191, 207), 
        //Color.FromArgb(223, 191, 207), 
        Color.FromArgb(239, 191, 207)};

        //public static Color[] SoftBlueColourRange = new Color[15] {
        //Color.FromArgb(15, 191, 207), 
        //Color.FromArgb(31, 191, 207), 
        //Color.FromArgb(47, 191, 207), 
        //Color.FromArgb(63, 191, 207), 
        //Color.FromArgb(79, 191, 207), 
        //Color.FromArgb(95, 191, 207), 
        //Color.FromArgb(111, 191, 207), 
        //Color.FromArgb(127, 191, 207), 
        //Color.FromArgb(143, 191, 207), 
        //Color.FromArgb(159, 191, 207), 
        //Color.FromArgb(175, 191, 207), 
        //Color.FromArgb(191, 191, 207), 
        //Color.FromArgb(207, 191, 207), 
        //Color.FromArgb(223, 191, 207), 
        //Color.FromArgb(239, 191, 207)};

        public static Color[] DefaultColourRange = new Color[8] {
        Color.FromArgb(255, 191, 74),       
        Color.FromArgb(239, 111, 79),  
        Color.FromArgb(255, 111, 63),  
        Color.FromArgb(239, 111, 255),      
        Color.FromArgb(127, 111, 255),      
        Color.FromArgb(111, 175, 255),      
        Color.FromArgb(111, 239, 255),
        Color.FromArgb(111, 255, 111)};


        public static Color[] UrlHistoryColourRange = new Color[7] {
        Color.FromArgb(0, 79, 234),       
        Color.FromArgb(0, 187, 255),  
        Color.FromArgb(184, 103, 241),  
        Color.FromArgb(245, 2, 2),
        Color.FromArgb(255, 138, 0),      
        Color.FromArgb(122, 255, 0),
        Color.FromArgb(255, 234, 0)};


        public static Color[] ExperimentalColourRange = new Color[12] {
        Color.FromArgb(0, 0, 0),        // black
        Color.FromArgb(180, 180, 180),  // grey
        Color.FromArgb(255, 255, 255),  // white
        Color.FromArgb(255, 0, 0),      //r
        Color.FromArgb(0, 255, 0),      //g
        Color.FromArgb(0, 0, 255),      //b
        Color.FromArgb(0, 255, 255),
        Color.FromArgb(255, 0, 255),
        Color.FromArgb(255, 255, 0),
        Color.FromArgb(255, 223, 50),
        Color.FromArgb(50, 223, 207),
        Color.FromArgb(207, 223, 255)};

        public static Color[] NamedColourRange = new Color[12] {
        Color.CornflowerBlue,      //g
        Color.LightBlue,
        Color.YellowGreen,//
        Color.Chartreuse,  // grey
        Color.CadetBlue,  // white
        Color.DarkOrange,      //r
        Color.DeepPink,      //b
        Color.Gold,
        Color.SteelBlue,//
        Color.Moccasin,
        Color.Thistle,
        Color.Teal
        };
    }
            
}
