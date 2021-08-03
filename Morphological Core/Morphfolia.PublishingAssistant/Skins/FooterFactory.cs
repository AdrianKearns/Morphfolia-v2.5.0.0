// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Morphfolia.PublishingSystem.Skins
{
    public class FooterFactory
    {
        private static Table tbl;
        private static TableRow tr;
        private static TableCell td;

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
                td.Text = string.Format("Last Modified {0} by {1} (<span class='fakeLink' title='This email address real, but it is formatted to avoid spam.'>{2}</span>)", modified.ToString(), modifiedBy, Morphfolia.PageLayoutAndSkinAssistant.SpamSafe.MakeSpamSafe(user.Email));
            }
            else
            {
                td.Text = string.Format("Last Modified {0} by {1}", modified.ToString(), modifiedBy);
            }

            td.Style.Add("background-color", backgroundColourBottom);

            return tbl;
        }
    }
}
