// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using Morphfolia.Common.Interfaces;

namespace Morphological.Kudos.Skins.SpecialCircumstances
{

    public class HeaderFactory
    {
        private static Table tbl;
        private static TableRow tr;
        private static TableCell td;
        private static TableCell tdStuff;

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
            td.Text = string.Format("<h3>{0}</h3><div>{1}</div>", heading, alertText, Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot());
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



        public static WebControl MakeFloater(IPage page, CustomPropertyInstanceInfoCollection customProperties)
        {
            string propertyKey = string.Empty;
            string propertyValue = string.Empty;

            string cssClassHeaderPanel = string.Empty;
            string cssClassNavigationBox = string.Empty;
            string cssClassPageTitle = string.Empty;
            string cssClassSearchBox = string.Empty;
            HorizontalAlign headerPanelHorizontalAlign = HorizontalAlign.NotSet;
            Unit headerPanelWidth = Unit.Percentage(100);

            if (customProperties != null)
            {
                for (int i = 0; i < customProperties.Count; i++)
                {
                    if (customProperties[i].PropertyType.PropertyTypeIdentifier.Equals(Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CUST))
                    {
                        propertyKey = customProperties[i].PropertyKey;
                        propertyValue = customProperties[i].PropertyValue;

                        switch (propertyKey)
                        {
                            case Floater.Properties.HeaderPanelHorizontalAlign:
                                headerPanelHorizontalAlign = Utilities.WebControlUtilities.HorizontalAlignFromstring(propertyValue);
                                break;

                            case Floater.Properties.HeaderPanelWidth:
                                try
                                {
                                    headerPanelWidth = Unit.Parse(propertyValue);
                                }
                                catch
                                {
                                }
                                break;

                            case Floater.Properties.CssClassHeaderPanel:
                                cssClassHeaderPanel = propertyValue;
                                break;

                            case Floater.Properties.CssClassNavigationBox:
                                cssClassNavigationBox = propertyValue;
                                break;

                            case Floater.Properties.CssClassPageTitle:
                                cssClassPageTitle = propertyValue;
                                break;

                            case Floater.Properties.CssClassSearchBox:
                                cssClassSearchBox = propertyValue;
                                break;
                        }
                    }
                }
            }




            Table plhdr = new Table();
            plhdr.CssClass = cssClassHeaderPanel;
            plhdr.CellPadding = 0;
            plhdr.CellSpacing = 0;
            plhdr.Width = headerPanelWidth;
            plhdr.HorizontalAlign = headerPanelHorizontalAlign;

            tr = new TableRow();
            plhdr.Rows.Add(tr);

            tdStuff = new TableCell();
            tr.Cells.Add(tdStuff);
            tdStuff.VerticalAlign = VerticalAlign.Top;




            Literal h1 = new Literal();
            tdStuff.Controls.Add(h1);
            h1.Text = string.Format("<h1 class=\"{1}\">{0}</h1>",
                page.Title,
                cssClassPageTitle);




            tbl = new Table();
            tdStuff.Controls.Add(tbl);
            tbl.CellPadding = 3;
            tbl.CellSpacing = 0;
            tbl.CssClass = cssClassNavigationBox;

            tr = new TableRow();
            tbl.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;

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

            litHTML = new Literal();
            td.Controls.Add(litHTML);
            litHTML.Text = "</nobr>";



            Morphfolia.WebControls.SearchInput searchInput = new Morphfolia.WebControls.SearchInput();
            tdStuff.Controls.Add(searchInput);
            searchInput.CssClass = cssClassSearchBox;



            return plhdr;
        }


    }

}