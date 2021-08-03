// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;

namespace Morphfolia.PublishingSystem.Skins
{
    public class HeaderFactory
    {
        private static Table tbl;
        private static TableRow tr;
        private static TableCell td;

        public static WebControl Make(
            string alertText,
            string heading,
            string backgroundImageTop,
            string backgroundImageBottom,
            string backgroundColourTop,
            string backgroundColourBottom,
            string cssClassTop,
            string cssClassBottom,
            string topInlineStyle,
            string bottomInlineStyle)
        {
            tbl = new Table();
            //tbl.Attributes.Add("border", "1");
            tbl.Width = Unit.Percentage(100);
            tbl.CellPadding = 3;
            tbl.CellSpacing = 0;

            tr = new TableRow();
            tbl.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.ColumnSpan = 2;
            //td.Text = string.Format("<h3>{0}</h3><div><a href='{2}/'>Home</a> | <a href='{2}/sitemap.aspx'>Site Map</a> | <a href='{2}/siteindex.aspx'>Site Index</a> {1}</div>", heading, alertText, Morphological.Utilities.WebHelper.VirtualApplicationRoot());
            td.Text = string.Format("<h3>{0}</h3><div>{1}</div>", heading, alertText);//, Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot());
            //td.Text = string.Format("<h3>{0}</h3><div>{1}</div>", heading, alertText, Morphological.Utilities.WebHelper.VirtualApplicationRoot());
            if (!backgroundColourTop.Equals(string.Empty))
            {
                td.Style.Add("background-color", backgroundColourTop);
            }
            if (!backgroundImageTop.Equals(string.Empty))
            {
                //td.Style.Add("background-image", string.Format("url ({0})", backgroundImageTop));
                td.Style.Add("background-image", backgroundImageTop);
            }
            if (!cssClassTop.Equals(string.Empty))
            {
                td.CssClass = cssClassTop;
            }
            if (!topInlineStyle.Equals(string.Empty))
            {
                //td.Style.Clear();
                //td.Attributes.Add("style", topInlineStyle);

                RawCssParsingHelper.ParseRawCssAndAddToObjectsStyle(td, topInlineStyle);
            }



            tr = new TableRow();
            tbl.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            if (!backgroundColourBottom.Equals(string.Empty))
            {
                td.Style.Add("background-color", backgroundColourBottom);
            }
            if (!backgroundImageBottom.Equals(string.Empty))
            {
                //td.Style.Add("background-image", string.Format("url ({0})", backgroundImageBottom));
                td.Style.Add("background-image", backgroundImageBottom);
            }
            if (!cssClassBottom.Equals(string.Empty))
            {
                td.CssClass = cssClassBottom;
            }
            if (!bottomInlineStyle.Equals(string.Empty))
            {
                //td.Style.Clear();
                //td.Attributes.Add("style", bottomInlineStyle);

                RawCssParsingHelper.ParseRawCssAndAddToObjectsStyle(td, bottomInlineStyle);
            }


            //Literal litHTML = new Literal();
            //td.Controls.Add(litHTML);
            //litHTML.Text = "<nobr>";


            Morphfolia.WebControls.SearchInput searchInput = new Morphfolia.WebControls.SearchInput();
            td.Controls.Add(searchInput);


            td = new TableCell();
            tr.Cells.Add(td);
            td.Width = Unit.Percentage(100);
            if (!backgroundColourBottom.Equals(string.Empty))
            {
                td.Style.Add("background-color", backgroundColourBottom);
            }
            if (!backgroundImageBottom.Equals(string.Empty))
            {
                //td.Style.Add("background-image", string.Format("url ({0})", backgroundImageBottom));
                td.Style.Add("background-image", backgroundImageBottom);
            }
            if (!cssClassBottom.Equals(string.Empty))
            {
                td.CssClass = cssClassBottom;
            }
            if (!bottomInlineStyle.Equals(string.Empty))
            {
                // parse CSS values and add to collection instead of 
                // just blowing it away.

                //td.Style.Clear();
                //td.Attributes.Add("style", bottomInlineStyle);

                RawCssParsingHelper.ParseRawCssAndAddToObjectsStyle(td, bottomInlineStyle);
            }



            Literal litHTML = new Literal();
            td.Controls.Add(litHTML);
            litHTML.Text = "<nobr>";

            string vRoot = Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot();

            HyperLink link = new HyperLink();
            td.Controls.Add(link);
            link.Text = "Home";
            link.NavigateUrl = string.Format("{0}/", vRoot);

            litHTML = new Literal();
            td.Controls.Add(litHTML);
            litHTML.Text = " | ";

            link = new HyperLink();
            td.Controls.Add(link);
            link.Text = "Site Map";
            link.NavigateUrl = string.Format("{0}/{1}", vRoot, Morphfolia.Common.Constants.Framework.PageURLs.SiteMap);

            litHTML = new Literal();
            td.Controls.Add(litHTML);
            litHTML.Text = " | ";

            link = new HyperLink();
            td.Controls.Add(link);
            link.Text = "Site Index";
            link.NavigateUrl = string.Format("{0}/{1}", vRoot, Morphfolia.Common.Constants.Framework.PageURLs.SiteIndex);

            //td.Text = string.Format("<h3>{0}</h3><div><a href='{2}/'>Home</a> | <a href='{2}/sitemap.aspx'>Site Map</a> | <a href='{2}/siteindex.aspx'>Site Index</a> {1}</div>", heading, alertText, Morphological.Utilities.WebHelper.VirtualApplicationRoot());

            litHTML = new Literal();
            td.Controls.Add(litHTML);
            litHTML.Text = "</nobr>";

            return tbl;
        }
    }



}