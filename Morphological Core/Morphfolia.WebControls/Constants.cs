// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Attributes;

namespace Morphfolia.WebControls
{
    public class Constants
    {
        public static readonly string LineChartProviderUrl = "LineChart.ashx";
        public static readonly string PieChartProviderUrl = "PieChart.ashx";
        public static readonly string GenericChartLegendTileProviderUrl = "LegendTile.ashx";

        public class QueryStringKeys
        {
            /// <summary>
            /// Used to identify the number of lines in a line graph.
            /// </summary>
            public static readonly string LineCount = "lc";

            /// <summary>
            /// Used to identify the number of lines in a line graph.
            /// </summary>
            public static readonly string LineValues = "lv";

            /// <summary>
            /// Used to assign DashStyles to lines.          
            /// </summary>
            public static readonly string LineDashStyles = "lds";

            /// <summary>
            /// Used to identify the segment values for a Pie Chart.
            /// </summary>
            public static readonly string Segment = "Segment";


            public static readonly string ColourRange = "ColourRange";

             
            public static readonly string ColourIndex = "ColourIndex";

            /// <summary>
            /// Used to set the size of the chart (assumes a square).
            /// </summary>
            [IsHttpHandlerParameter("Size", "An int.", "Used to set the size of the chart (assumes a square).")]
            public static readonly string GraphSize = "Size";

            /// <summary>
            /// Used to set the height of the chart.
            /// </summary>
            [IsHttpHandlerParameter("gh", "An int.", "Used to set the height of the chart.")]
            public static readonly string GraphHeight = "gh";

            /// <summary>
            /// Used to set the width of the chart.
            /// </summary>
            [IsHttpHandlerParameter("gw", "An int.", "Used to set the width of the chart.")]
            public static readonly string GraphWidth = "gw";
        }

        public partial class ColourRanges
        {
            public static readonly string SoftBlue = "SoftBlue";
            public static readonly string Grey = "Grey";
            public static readonly string Experimental = "Experimental";
            public static readonly string Default = "Default";
            public static readonly string UrlHistory = "UrlHistory";
        }
    }
}

namespace Morphfolia.WebControls.ImageManagement
{
	public class DeleteImageClickedEventArgs : System.EventArgs
	{
		public readonly string ImageToDelete;

		public DeleteImageClickedEventArgs( string imageToDelete )
		{
			ImageToDelete = imageToDelete;
		}
	}
}

namespace Morphfolia.WebControls.FileManagement
{
	public class DeleteFileListingClickedEventArgs : System.EventArgs
	{
		public readonly string FileToDelete;

		public DeleteFileListingClickedEventArgs( string fileToDelete )
		{
			FileToDelete = fileToDelete;
		}
	}
}
