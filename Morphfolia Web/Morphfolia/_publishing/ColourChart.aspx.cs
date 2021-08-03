// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;


public partial class _publishing_ColourChart : System.Web.UI.Page
{
    string[] rgbsFC9630 = new String[6] { "F", "C", "9", "6", "3", "0" };
    string[] rgbs0369CF = new String[6] { "0", "3", "6", "9", "C", "F" };
    string[] rgbsFEDCBA9876543210 = new String[16] { "F", "E", "D", "C", "B", "A", "9", "8", "7", "6", "5", "4", "3", "2", "1", "0" };
   

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private string[] ParseRGBInput(TextBox txt)
    {
        try
        {
            string x = txt.Text;
            return x.Trim().Split(char.Parse(" "));
        }
        catch(Exception ex)
        {
            Morphfolia.Common.Logging.Logger.LogException("ParseRGBInput()", ex, 32323);
            return rgbsFC9630;
        }
    }

    private int ParseIntInput(TextBox txt)
    {
        try
        {
            string x = txt.Text.Trim();
            return int.Parse(x);
        }
        catch (Exception ex)
        {
            Morphfolia.Common.Logging.Logger.LogException("ParseIntInput()", ex, 32324);
            return 5;
        }
    }

    private string MakeFullRangeHexCodes()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < rgbsFEDCBA9876543210.Length; i++)
        {
            for (int ii = 0; ii < rgbsFEDCBA9876543210.Length; ii++)
            {
                sb.AppendFormat(" {0}{1}", rgbsFEDCBA9876543210[i], rgbsFEDCBA9876543210[ii]);
            }
        }

        return sb.ToString().Trim();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        DoIt();
    }

    private void DoIt()
    {
        int cellpadding = ParseIntInput(txtCellPadding);
        int cellSpacing = ParseIntInput(txtCellSpacing);
        int cellWidth = ParseIntInput(txtCellWidth);
        int cellHeight = ParseIntInput(txtCellHeight);
        string borderStyle = txtBorderStyle.Text;


        ColourChart1.HexArrayR = ParseRGBInput(txtC1R);
        ColourChart1.HexArrayG = ParseRGBInput(txtC1G);
        ColourChart1.HexArrayB = ParseRGBInput(txtC1B);
        ColourChart1.CellPadding = cellpadding;
        ColourChart1.CellSpacing = cellSpacing;
        ColourChart1.CellWidth = cellWidth;
        ColourChart1.CellHeight = cellHeight;
        ColourChart1.CssBorderStyle = borderStyle;
        ColourChart1.ShowHexCode = chkbxShowHexCode.Checked;
        ColourChart1.RenderRGB();

        ColourChart2.HexArrayR = ParseRGBInput(txtC2R);
        ColourChart2.HexArrayG = ParseRGBInput(txtC2G);
        ColourChart2.HexArrayB = ParseRGBInput(txtC2B);
        ColourChart2.CellPadding = cellpadding;
        ColourChart2.CellSpacing = cellSpacing;
        ColourChart2.CellWidth = cellWidth;
        ColourChart2.CellHeight = cellHeight;
        ColourChart2.CssBorderStyle = borderStyle;
        ColourChart2.ShowHexCode = chkbxShowHexCode.Checked;
        ColourChart2.RenderRGB(); //RenderGRB();
    }

    protected void btnCoarseRange_Click(object sender, EventArgs e)
    {
        txtC1R.Text = "F C 9 6 3 0";
        txtC1G.Text = "F C 9 6 3 0";
        txtC1B.Text = "F C 9 6 3 0";
        DoIt();
    }

    protected void FullRange_Click(object sender, EventArgs e)
    {
        txtC1R.Text = "F C 9 6 3 0";
        txtC1G.Text = "F E D C B A 9 8 7 6 5 4 3 2 1 0";
        txtC1B.Text = "F E D C B A 9 8 7 6 5 4 3 2 1 0";
        DoIt();
    }

    protected void Range_Click(object sender, EventArgs e)
    {
        txtC1R.Text = "FF CC 99 66 33 00";
        txtC1G.Text = MakeFullRangeHexCodes();
        txtC1B.Text = MakeFullRangeHexCodes();
        DoIt();
    }

    protected void btnR_Click(object sender, EventArgs e)
    {
        txtC1R.Text = "F";
        txtC1G.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
        txtC1B.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";

        txtC2R.Text = "0";
        txtC2G.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
        txtC2B.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";

        DoIt();
    }

    protected void btnG_Click(object sender, EventArgs e)
    {
        txtC1R.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
        txtC1G.Text = "F";
        txtC1B.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
        DoIt();
    }

    protected void btnB_Click(object sender, EventArgs e)
    {
        txtC1R.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
        txtC1G.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
        txtC1B.Text = "F";
        DoIt();
    }
}