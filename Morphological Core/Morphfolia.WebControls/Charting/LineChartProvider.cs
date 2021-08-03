// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using Morphfolia.WebControls.Logging;
using Morphfolia.Common.Info;
using Morphfolia.Common.Attributes;

namespace Morphfolia.WebControls.Charting
{
    [IsHttpHandler("Dynamically constructs and provides line charts as jpg files.")]
    public class LineChartProvider : IHttpHandler
    {
        [IsHttpHandlerParameter("ColourRange", "One of the named values defined in Morphfolia.WebControls.Constants.ColourRanges (which is a partial class).", "Used to identify the colour range to be used to colour the Chart.")]
        public static readonly string ColourRange = Constants.QueryStringKeys.ColourRange;

        [IsHttpHandlerParameter("lc", "An int.", "Defines the number of lines being passed in via the LineValues parameter.")]
        public static readonly string LineCount = Constants.QueryStringKeys.LineCount;

        [IsHttpHandlerParameter("lv", "A string of text containing ints seperated by commas.", "Used to identify the colour range to be used to colour the Chart.")]
        public static readonly string LineValues = Constants.QueryStringKeys.LineValues;

        [IsHttpHandlerParameter("lds", "A string of text containing ints seperated by commas, each int represents a dash style. See Charting.ChartingUtilities.GetDashStyleByNumber().", "Used to identify the colour range to be used to colour the Chart.")]
        public static readonly string LineDashStyles = Constants.QueryStringKeys.LineDashStyles;

        [IsHttpHandlerParameter("gw", "An int.", "Used to set the width of the chart (in pixels).")]
        public static readonly string GraphWidth = Constants.QueryStringKeys.GraphWidth;

        [IsHttpHandlerParameter("gh", "An int.", "Used to set the height of the chart (in pixels).")]
        public static readonly string GraphHeight = Constants.QueryStringKeys.GraphHeight;


        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            Color[] selectedColourRange;
            string colourRange = Utilities.HttpRequestHelper.GetRequestParamValue(ColourRange, Constants.ColourRanges.UrlHistory);
            string rawLineCount = Utilities.HttpRequestHelper.GetRequestParamValue(LineCount);
            string rawLineValues = Utilities.HttpRequestHelper.GetRequestParamValue(LineValues);
            string rawLineDashStylesx = Utilities.HttpRequestHelper.GetRequestParamValue(LineDashStyles);

            int graphWidth;
            if (!int.TryParse(Utilities.HttpRequestHelper.GetRequestParamValue(GraphWidth), out graphWidth))
            {
                graphWidth = 400;
            }

            int graphHeight;
            if (!int.TryParse(Utilities.HttpRequestHelper.GetRequestParamValue(GraphHeight), out graphHeight))
            {
                graphHeight = 200;
            }

            selectedColourRange = Morphfolia.WebControls.Charting.ChartingUtilities.GetColourRangeByName(colourRange);

            if (rawLineCount.Equals(string.Empty))
            {
                context.Response.StatusCode = 404;
            }
            else
            {
                // Expected input schema (example): 
                // lc=2&lv=1,2,3,4,5,6,7,8
                // equals two lines:
                // line 1: 1-2-3-4
                // line 2: 5-6-7-8
                int lineCount = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                int.TryParse(rawLineCount, out lineCount);
                string[] rawAmounts = rawLineValues.Split(Char.Parse(","));
                IntCollection[] lines = new IntCollection[lineCount];

                //int dashStyleAssignmentsCount = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                //int.TryParse(rawLineDashStyles, out dashStyleAssignmentsCount);                             
                string[] rawLineDashStyles = rawLineDashStylesx.Split(Char.Parse(","));
                IntCollection dashStyles = new IntCollection();



                // TODO - Check the rawAmounts total divides equally by the numer of lines.

                int[] amounts = new int[rawAmounts.Length];
                //IntCollection lineValues;

                int numberOfValuesPerLine = 0;
                numberOfValuesPerLine = rawAmounts.Length / lineCount;
                //int currentLineIndex = 0;
                int counter = 0;
                lines[0] = new IntCollection();


                for (int a = 0; a < lineCount; a++)
                {
                    lines[a] = new IntCollection();
                    for (int b = 0; b < numberOfValuesPerLine; b++)
                    {
                        lines[a].Add(int.Parse(rawAmounts[(counter + b)]));
                    }
                    counter = counter + numberOfValuesPerLine;

                    dashStyles.Add(Morphfolia.Common.Constants.SystemTypeValues.NullInt);
                }


                // 
                int dashStyleAssignmentValue = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                for (int a = 0; a < rawLineDashStyles.GetLength(0); a++)
                {
                    int.TryParse(rawLineDashStyles[a], out dashStyleAssignmentValue);
                    dashStyles[a] = dashStyleAssignmentValue;
                }


                //// debugging: 
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //for (int z = 0; z < lineCount; z++)
                //{
                //    sb.AppendFormat("{0}{1} =", Environment.NewLine, z.ToString());
                //    foreach(int u in lines[z])
                //    {
                //        sb.AppendFormat(" [{0}]", u.ToString());
                //    }
                //}
                //Logger.LogVerboseInformation("LineGraph input check.", sb.ToString());



                if (lineCount == 0)
                {
                    context.Response.StatusCode = 404;
                }
                else
                {
                    // Since we are outputting a Jpeg, set the ContentType appropriately
                    context.Response.ContentType = "image/jpeg";

                    //int[] segments = PieChartUtilities.PieChartHelper.ConvertRawAmountsToPieChartSegmentRatios(amounts);

                    CreateGraphChartThing(context.Response.OutputStream, graphWidth, graphHeight, selectedColourRange, lines, dashStyles);
                }
            }
        }



        public static void CreateGraphChartThing(System.IO.Stream outputStream, int width, int height, Color[] colourRange, IntCollection[] lineValues, IntCollection dashStyles)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //int paddingX = 10;
            //int paddingY = 10;
            //decimal baseline = height + paddingY;

            //using (Bitmap objBitmap = new Bitmap((width + (paddingX * 2)), (height + (paddingY * 2))))
            using (Bitmap objBitmap = new Bitmap(width+45, height+5))
            {
                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //objGraphics.DpiY
                    //objGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                    objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width+45, height+5);
                    //objGraphics.FillRectangle(new SolidBrush(Color.Silver), 0, 0, width, height);


                    //int horizontalSpacing = 30;
                    int horizontalSpacing = width / (lineValues[0].Count - 1);
                    int currentHorizontalLocation;
                    Pen myPen;                    

                    decimal x1 = 0;
                    decimal y1 = 0;
                    decimal x2 = 0;
                    decimal y2 = 0;


                    // Find the max value from all lines: 
                    int Gross = int.MinValue;
                    for (int z = 0; z < lineValues.GetLength(0); z++)
                    {
                        if (lineValues[z].MaxValue > Gross)
                        {
                            Gross = lineValues[z].MaxValue;
                        }
                    }


                    Decimal theDr;
                    theDr = decimal.Divide(height, Gross);
                    sb.AppendFormat("{0}[theDr] {1} = [height] {2} / [Gross] {3}",
                                Environment.NewLine,
                                theDr, height, Gross);



                    Color guideColour = Color.FromArgb(177, 177, 177);

                    Pen guideLinePen = new Pen(guideColour, 1);
                    guideLinePen.DashStyle = DashStyle.Dot;

                    Pen guideLinePen2 = new Pen(guideColour, 1);
                    guideLinePen2.DashStyle = DashStyle.Dash;



                    InstalledFontCollection installedFontCollection = new InstalledFontCollection();
                    FontFamily[] fontFamilies = installedFontCollection.Families;
                    Font f = new Font(fontFamilies[0], 10);
                    x1 = 0;

                    objGraphics.DrawLine(guideLinePen, 0, 0, 0, (int)Decimal.Ceiling(height));
                    //objGraphics.DrawString("1", f, new System.Drawing.SolidBrush(guideColour), 0, (int)Decimal.Ceiling(height) + 2);

                    for (int q = 0; q < lineValues[0].Count; q++)
                    {
                        x1 = x1 + horizontalSpacing;
                        objGraphics.DrawLine(guideLinePen, (int)Decimal.Ceiling(x1), (int)Decimal.Ceiling(height), (int)Decimal.Ceiling(x1), 0);
                        //objGraphics.DrawString((q+2).ToString(), f, new System.Drawing.SolidBrush(guideColour), (int)Decimal.Ceiling(x1), (int)Decimal.Ceiling(height) + 2);
                    }

                    objGraphics.DrawLine(guideLinePen2, 0, 0, width - 1, 0);
                    objGraphics.DrawString(Gross.ToString(), f, new System.Drawing.SolidBrush(guideColour), width + 2, 0);

                    decimal halfwayValue = Decimal.Divide(Gross, 2);

                    objGraphics.DrawLine(guideLinePen2, 0, (int)Decimal.Ceiling(height) / 2, width - 1, (int)Decimal.Ceiling(height) / 2);
                    objGraphics.DrawString(halfwayValue.ToString(), f, new System.Drawing.SolidBrush(guideColour), width + 2, (int)Decimal.Ceiling(height) / 2);

                    objGraphics.DrawLine(guideLinePen2, 0, (int)Decimal.Ceiling(height) - 1, width - 1, (int)Decimal.Ceiling(height) - 1);




                    

                    for (int z = 0; z < lineValues.GetLength(0); z++)
                    {
                        //sb.AppendFormat("{0}{1} =", Environment.NewLine, lineCount.ToString());
                        
                        myPen = new Pen(colourRange[z], 3);

                        // we'll assume the length of the lineValues array is 
                        // the same as the length og the dashStyles collection: 
                        // But we'll look-out for exceptions just in case.
                        try
                        {
                            myPen.DashStyle = Charting.ChartingUtilities.GetDashStyleByNumber(dashStyles[z]);
                        }
                        catch(Exception ex)
                        {
                            Logger.LogException("Unable to assign specified DashStyle, using 'Solid' instead.", ex);
                            myPen.DashStyle = DashStyle.Solid;
                        }


                        //myPen.DashStyle = DashStyle.DashDot;
                        currentHorizontalLocation = 0;
                        for(int vi = 0; vi < lineValues[z].Count; vi++)
                        {
                            x1 = currentHorizontalLocation;
                            y1 = y2;
                            x2 = currentHorizontalLocation + horizontalSpacing;
                            //y2 = baseline - (lineValues[z][vi] * 15);
                            if (lineValues[z][vi] == 0)
                            {
                                y2 = height;

                                sb.AppendFormat("{1}{0} lineValues[z][vi] == 0",
                                    height.ToString(), Environment.NewLine);
                            }else{
                                //y2 = baseline / (lineValues[z].MaxValue / lineValues[z][vi]);
                                //y2 = baseline - (baseline / (Gross / lineValues[z][vi]));

                                y2 = height - (lineValues[z][vi] * theDr);

                                sb.AppendFormat("{0}{1} = {2} - ({3} * {4})",
                                    Environment.NewLine,
                                    y2,
                                    height,
                                    lineValues[z][vi].ToString(),
                                    theDr);
                            }

                            if (vi > 0)
                            {
                                //objGraphics.DrawLine(myPen, x1, y1, x2, y2);
                                objGraphics.DrawLine(myPen, (int)Decimal.Ceiling(x1), (int)Decimal.Ceiling(y1), (int)Decimal.Ceiling(x2), (int)Decimal.Ceiling(y2));
                                currentHorizontalLocation = currentHorizontalLocation + horizontalSpacing;

                                sb.AppendFormat("{4}{0}, {1}, {2}, {3}",
                                    x1.ToString(), y1.ToString(), x2.ToString(), y2.ToString(), Environment.NewLine);
                            }

                        }
                    }






                    objBitmap.Save(outputStream, ImageFormat.Jpeg);
                    outputStream.Flush();

                    Logger.LogVerboseInformation("CreateGraphChartThing", sb.ToString(), 666);
                }
            }
        }

    }
}
