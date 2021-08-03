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
using Morphfolia.Business.Logs;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Summary description for UserList
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class RoleManagerUserList : WebControl, INamingContainer
    {
        private Table tblRoleManagerUserList;
        private TableRow tr;
        private TableCell td;
        //private LinkButton manageUser;
        private TableHeaderRow thr;
        private TableHeaderCell thd;
        CheckBoxList chkbxlst;
        Button btnSave;


        private string targetRole;
        public string TargetRole
        {
            get
            {
                string r = (string)ViewState["SelectedRole"];
                if (r == null)
                {
                    r = string.Empty;
                }
                return r;
            }
            set
            {
                EnsureChildControls();

                targetRole = value;
                ViewState["SelectedRole"] = targetRole;

                if (!targetRole.Equals(string.Empty))
                {
                    chkbxlst.Items.Clear();
                    chkbxlst.DataSource = Users;
                    chkbxlst.DataBind();
                }
            }
        }


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


        void btnSave_Click(object sender, EventArgs e)
        {
            EnsureChildControls();

            if (!TargetRole.Equals(string.Empty))
            {
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //Label lblX = new Label();
                //Controls.Add(lblX);
                //td.Controls.Add(lblX);
                ListItem li;
                string username;

                for (int c = 0; c < chkbxlst.Items.Count; c++)
                {
                    li = chkbxlst.Items[c];
                    username = li.Text;
                    if (li.Selected)
                    {
                        //sb.AppendFormat("<br> + {0}", username);
                        if (!Roles.IsUserInRole(username, TargetRole))
                        {
                            Roles.AddUserToRole(username, TargetRole);
                            Auditor.LogAuditEntry(Auditor.ObjectIdUnknown, AuditableObjects.Role, string.Format("Added User '{0}' to Role '{1}'.", username, TargetRole));
                        }
                    }
                    else
                    {
                        //sb.AppendFormat("<br> - {0}", username);
                        if (Roles.IsUserInRole(username, TargetRole))
                        {
                            Roles.RemoveUserFromRole(username, TargetRole);
                            Auditor.LogAuditEntry(Auditor.ObjectIdUnknown, AuditableObjects.Role, string.Format("Removed User '{0}' from Role '{1}'.", username, TargetRole));
                        }
                    }
                }

                //lblX.Text = sb.ToString();
            }
        }


        //public delegate void onUserSelected(MembershipUser user);
        //public event onUserSelected UserSelected;

        //void manageUser_Click(object sender, EventArgs e)
        //{
        //    LinkButton btn = (LinkButton)sender;

        //    if (UserSelected != null)
        //    {
        //        UserSelected(membershipUserCollection[btn.Text]);
        //    }
        //}


        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            tblRoleManagerUserList = new Table();
            Controls.Add(tblRoleManagerUserList);
            tblRoleManagerUserList.CellPadding = 5;
            tblRoleManagerUserList.CellSpacing = 0;

            thr = new TableHeaderRow();
            Controls.Add(thr);
            tblRoleManagerUserList.Rows.Add(thr);

            thd = new TableHeaderCell();
            Controls.Add(thd);
            thr.Cells.Add(thd);
            thd.Text = string.Format("'{0}' Role Members", TargetRole);

            tr = new TableRow();
            Controls.Add(tr);
            tblRoleManagerUserList.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            chkbxlst = new CheckBoxList();
            Controls.Add(chkbxlst);
            td.Controls.Add(chkbxlst);
            chkbxlst.ID = "chkbxlst";
            //chkbxlst.s
            chkbxlst.DataSource = Users;
            chkbxlst.DataBind();


            tr = new TableRow();
            Controls.Add(tr);
            tblRoleManagerUserList.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            btnSave = new Button();
            Controls.Add(btnSave);
            td.Controls.Add(btnSave);
            btnSave.Text = "Save";
            btnSave.ID = "btnSave";
            btnSave.Click += new EventHandler(btnSave_Click);

            if (TargetRole.Equals(string.Empty))
            {
                btnSave.Enabled = false;
                chkbxlst.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                chkbxlst.Enabled = true;
            }


        }


        private void x()
        {
            EnsureChildControls();

            if (!TargetRole.Equals(string.Empty))
            {
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //Label lblX = new Label();
                //Controls.Add(lblX);
                //td.Controls.Add(lblX);
                ListItem li;
                string username;
                bool z;

                for (int c = 0; c < chkbxlst.Items.Count; c++)
                {
                    li = chkbxlst.Items[c];
                    username = li.Text;
                    z = Roles.IsUserInRole(username, TargetRole);
                    li.Selected = z;
                }
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (TargetRole.Equals(string.Empty))
            {
                btnSave.Enabled = false;
                chkbxlst.Enabled = false;
                thd.Text = "(No Role Selected)";
            }
            else
            {
                btnSave.Enabled = true;
                chkbxlst.Enabled = true;
                thd.Text = string.Format("'{0}' Role Members", TargetRole);
                x();
            }

            base.RenderContents(writer);
        }
    }
}