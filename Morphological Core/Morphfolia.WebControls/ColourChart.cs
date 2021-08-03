// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;

namespace Morphfolia.WebControls
{
    public class ColourChart : WebControl
    {
        private Table tblColourChart;
        private TableRow tr;
        private TableCell td;


        public string[] HexArrayR
        {
            get
            {
                if (hexArrayR == null)
                {
                    hexArrayR = BaseHexArray;
                }
                return hexArrayR;
            }
            set{ hexArrayR = value; }
        }
        private string[] hexArrayR = null;

        public string[] HexArrayG
        {
            get
            {
                if (hexArrayG == null)
                {
                    hexArrayG = BaseHexArray;
                }
                return hexArrayG;
            }
            set { hexArrayG = value; }
        }
        private string[] hexArrayG = null;

        public string[] HexArrayB
        {
            get
            {
                if (hexArrayB == null)
                {
                    hexArrayB = BaseHexArray;
                }
                return hexArrayB;
            }
            set { hexArrayB = value; }
        }
        private string[] hexArrayB = null;


        private string[] BaseHexArray = new String[16] { "F", "E", "D", "C", "B", "A", "9", "8", "7", "6", "5", "4", "3", "2", "1", "0" };



        public void RenderRGB()
        {
            string rgb = string.Empty;

            for (int r = 0; r < HexArrayR.Length; r++)
            {
                MakeTable();

                for (int g = 0; g < HexArrayG.Length; g++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblColourChart.Rows.Add(tr);

                    for (int b = 0; b < HexArrayB.Length; b++)
                    {
                        rgb = string.Format("#{0}{1}{2}", HexArrayR[r].ToUpper(), HexArrayG[g].ToUpper(), HexArrayB[b].ToUpper());
                        AppendColourCell(tr, rgb);
                    }
                }
            }
        }


        public void RenderRBG()
        {
            string rgb = string.Empty;

            for (int r = 0; r < HexArrayR.Length; r++)
            {
                MakeTable();

                for (int g = 0; g < HexArrayG.Length; g++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblColourChart.Rows.Add(tr);

                    for (int b = 0; b < HexArrayB.Length; b++)
                    {
                        rgb = string.Format("#{0}{2}{1}", HexArrayR[r].ToUpper(), HexArrayG[g].ToUpper(), HexArrayB[b].ToUpper());
                        AppendColourCell(tr, rgb);
                    }
                }
            }
        }


        public void RenderGRB()
        {
            string rgb = string.Empty;

            for (int r = 0; r < HexArrayR.Length; r++)
            {
                MakeTable();

                for (int g = 0; g < HexArrayG.Length; g++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblColourChart.Rows.Add(tr);

                    for (int b = 0; b < HexArrayB.Length; b++)
                    {
                        rgb = string.Format("#{1}{0}{2}", HexArrayR[r].ToUpper(), HexArrayG[g].ToUpper(), HexArrayB[b].ToUpper());
                        AppendColourCell(tr, rgb);
                    }
                }
            }
        }


        public void RenderGBR()
        {
            string rgb = string.Empty;

            for (int r = 0; r < HexArrayR.Length; r++)
            {
                MakeTable();

                for (int g = 0; g < HexArrayG.Length; g++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblColourChart.Rows.Add(tr);

                    for (int b = 0; b < HexArrayB.Length; b++)
                    {
                        rgb = string.Format("#{1}{2}{0}", HexArrayR[r].ToUpper(), HexArrayG[g].ToUpper(), HexArrayB[b].ToUpper());
                        AppendColourCell(tr, rgb);
                    }
                }
            }
        }


        public void RenderBRG()
        {
            string rgb = string.Empty;

            for (int r = 0; r < HexArrayR.Length; r++)
            {
                MakeTable();

                for (int g = 0; g < HexArrayG.Length; g++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblColourChart.Rows.Add(tr);

                    for (int b = 0; b < HexArrayB.Length; b++)
                    {
                        rgb = string.Format("#{2}{0}{1}", HexArrayR[r].ToUpper(), HexArrayG[g].ToUpper(), HexArrayB[b].ToUpper());
                        AppendColourCell(tr, rgb);
                    }
                }
            }
        }


        public void RenderBGR()
        {
            string rgb = string.Empty;

            for (int r = 0; r < HexArrayR.Length; r++)
            {
                MakeTable();

                for (int g = 0; g < HexArrayG.Length; g++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblColourChart.Rows.Add(tr);

                    for (int b = 0; b < HexArrayB.Length; b++)
                    {
                        rgb = string.Format("#{2}{1}{0}", HexArrayR[r].ToUpper(), HexArrayG[g].ToUpper(), HexArrayB[b].ToUpper());
                        AppendColourCell(tr, rgb);
                    }
                }
            }
        }


        public int CellWidth
        {
            get { return cellWidth; }
            set { cellWidth = value;  }
        }
        private int cellWidth = 15;

        public int CellHeight
        {
            get { return cellHeight; }
            set { cellHeight = value; }
        }
        private int cellHeight = 15;


        public int CellSpacing
        {
            get { return cellSpacing; }
            set { cellSpacing = value; }
        }
        private int cellSpacing = 1;


        public int CellPadding
        {
            get { return cellPadding; }
            set { cellPadding = value; }
        }
        private int cellPadding = 0;


        public string CssBorderStyle
        {
            get { return borderStyle; }
            set { borderStyle = value; }
        }
        private string borderStyle = "1px solid #666666;";



        public bool ShowHexCode
        {
            get { return showHexCode; }
            set { showHexCode = value; }
        }
        private bool showHexCode = false;



        private void MakeTable()
        {
            tblColourChart = new Table();
            Controls.Add(tblColourChart);
            tblColourChart.Style.Add("border", CssBorderStyle);
            tblColourChart.Style.Add("margin", "2px;");
            tblColourChart.CellPadding = CellPadding;
            tblColourChart.CellSpacing = CellSpacing;
            tblColourChart.EnableViewState = false;
        }

        private void AppendColourCell(TableRow tr, string rgb)
        {
            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            if (ShowHexCode)
            {
                td.Text = rgb;
            }
            else
            {
                td.Text = string.Empty;// "&nbsp;";
            }
            td.ToolTip = rgb;
            td.Style.Add("background-color", rgb);
            td.Style.Add("font-size", "9px");
            td.Width = Unit.Pixel(CellWidth);
            td.Height = Unit.Pixel(CellHeight);
        }

    }
}