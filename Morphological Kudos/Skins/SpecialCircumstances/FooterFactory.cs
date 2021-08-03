// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using Morphfolia.Common.Info;
using Morphfolia.Common.Interfaces;

namespace Morphological.Kudos.Skins.SpecialCircumstances
{
    public class FooterFactory
    {
        private static Table tbl;
        private static TableRow tr;
        private static TableCell td;
        private static TableCell tdStuff;

        public static WebControl Make(string alertText, string modifiedBy, DateTime modified, string backgroundColourBottom)
        {
            tbl = new Table();
            //tbl.Attributes.Add("border", "1");
            tbl.Width = Unit.Percentage(100);
            tbl.CellPadding = 3;
            tbl.CellSpacing = 2;

            tr = new TableRow();
            tbl.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);


            string username = modifiedBy;
            MembershipUser user = Membership.GetUser(username);
            if (user != null)
            {
                //td.Text = string.Format("Last Modified {0} by <a href='mailto:{2}'>{1}</a>", modified.ToString(), modifiedBy, user.Email);
                //td.Text = string.Format("Last Modified {0} by {1}", modified.ToString(), modifiedBy);
                td.Text = string.Format("Last Modified {0} by {1} (<span class='fakeLink' title='This email address real, but it is formatted to avoid spam.'>{2}</span>)", modified.ToString(), modifiedBy, SpamSafe.MakeSpamSafe(user.Email));
            }
            else
            {
                td.Text = string.Format("Last Modified {0} by {1}", modified.ToString(), modifiedBy);
            }

            td.Style.Add("background-color", backgroundColourBottom);

            return tbl;
        }


        public static WebControl MakeFloater(IPage page, CustomPropertyInstanceInfoCollection customProperties)
        {
            string propertyKey = string.Empty;
            string propertyValue = string.Empty;

            string cssClassFooterPanel = string.Empty;
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

                            case Floater.Properties.CssClassFooterPanel:
                                cssClassFooterPanel = propertyValue;
                                break;
                        }
                    }
                }
            }




            Table plhdr = new Table();
            plhdr.CssClass = cssClassFooterPanel;
            plhdr.CellPadding = 0;
            plhdr.CellSpacing = 0;
            plhdr.Width = headerPanelWidth;
            plhdr.HorizontalAlign = headerPanelHorizontalAlign;

            tr = new TableRow();
            plhdr.Rows.Add(tr);

            tdStuff = new TableCell();
            tr.Cells.Add(tdStuff);
            tdStuff.VerticalAlign = VerticalAlign.Top;




            tbl = new Table();
            tdStuff.Controls.Add(tbl);
            tbl.CellPadding = 3;
            tbl.CellSpacing = 0;
            //tbl.Width = Unit.Pixel(600);
            //tbl.Style.Add("", "");

            tr = new TableRow();
            tbl.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            string username = page.LastModifiedBy;
            MembershipUser user = Membership.GetUser(username);
            if (user != null)
            {
                //td.Text = string.Format("Last Modified {0} by <a href='mailto:{2}'>{1}</a>", modified.ToString(), modifiedBy, user.Email);
                //td.Text = string.Format("Last Modified {0} by {1}", modified.ToString(), modifiedBy);
                td.Text = string.Format("Last Modified {0} by {1} (<span class='fakeLink' title='This email address real, but it is formatted to avoid spam.'>{2}</span>)", page.LastModified.ToString(), page.LastModifiedBy, SpamSafe.MakeSpamSafe(user.Email));
            }
            else
            {
                td.Text = string.Format("Last Modified {0} by {1}", page.LastModified.ToString(), page.LastModifiedBy);
            }


            return plhdr;
        }

    }
}
