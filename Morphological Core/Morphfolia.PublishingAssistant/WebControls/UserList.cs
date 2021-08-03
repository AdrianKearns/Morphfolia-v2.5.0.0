// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.ComponentModel;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Summary description for UserList
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class UserList : WebControl, INamingContainer
    {
        private Table tblUserList;
        private TableRow tr;
        private TableCell td;
        private LinkButton manageUser;
        private TableHeaderRow thr;
        private TableHeaderCell thd;



        private MembershipUserCollection membershipUserCollection;
        public MembershipUserCollection Users
        {
            get
            {
                if (membershipUserCollection == null)
                {
                    membershipUserCollection = Membership.GetAllUsers();
                }
                return membershipUserCollection;
            }
        }

        /// <summary>
        /// Clears the current MembershipUserCollection forcing the control to obtain a fresh copy of the data.
        /// </summary>
        /// <remarks>Call this method if you have made changes to a user and want to refresh the list to reflect those changes.
        /// </remarks>
        public void Reset()
        {
            membershipUserCollection = null;
        }

        public delegate void onUserSelected(MembershipUser user);
        public event onUserSelected UserSelected;

        void manageUser_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            if (UserSelected != null)
            {
                UserSelected(membershipUserCollection[btn.Text]);
            }
        }

        protected override void CreateChildControls()
        {
            //base.CreateChildControls();

            tblUserList = new Table();
            Controls.Add(tblUserList);
            tblUserList.CellPadding = 5;
            tblUserList.CellSpacing = 0;

            thr = new TableHeaderRow();
            Controls.Add(thr);
            tblUserList.Rows.Add(thr);

            thd = new TableHeaderCell();
            Controls.Add(thd);
            thr.Cells.Add(thd);
            thd.Text = "User Name";

            thd = new TableHeaderCell();
            Controls.Add(thd);
            thr.Cells.Add(thd);
            thd.Text = "Email";

            thd = new TableHeaderCell();
            Controls.Add(thd);
            thr.Cells.Add(thd);
            thd.Text = "Last Login";

            thd = new TableHeaderCell();
            Controls.Add(thd);
            thr.Cells.Add(thd);
            thd.Text = "Approved";

            thd = new TableHeaderCell();
            Controls.Add(thd);
            thr.Cells.Add(thd);
            thd.Text = "Locked Out";


            Populate();
        }


        private void Populate()
        {
            EnsureChildControls();

            foreach (MembershipUser user in Users)
            {
                tr = new TableRow();
                Controls.Add(tr);
                tblUserList.Rows.Add(tr);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);

                manageUser = new LinkButton();
                Controls.Add(manageUser);
                td.Controls.Add(manageUser);
                manageUser.Text = user.UserName;
                manageUser.Click += new EventHandler(manageUser_Click);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                td.Text = user.Email;

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                td.Text = user.LastLoginDate.ToString();

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                if (!user.IsApproved)
                {
                    td.Text = "(Unapproved)";
                }
                else
                {
                    td.Text = "&nbsp;";
                }

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                if (user.IsLockedOut)
                {
                    td.Text = "(Locked out)";
                }
                else
                {
                    td.Text = "&nbsp;";
                }
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            tblUserList.Width = Width;

            base.RenderContents(writer);
        }
    }
}