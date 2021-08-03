// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Business.Logs;
using System.ComponentModel;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Summary description for RoleManager
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class RoleManager : WebControl, INamingContainer
    {
        Table tblRoleManager;
        Table tblListOfRoles;
        private TableRow tr;
        private TableCell td;
        private TableHeaderRow thr;
        private TableHeaderCell thd;
        private TextBox txtAddNewRole;
        private Button btnAddNewRole;
        private LinkButton manageRole;
        private TableCell tdListOfRolesContainer;
        private Button btnDeleteRole;
        private Label lblMessage;

        private string[] _allRoles = null;
        private string[] AllRoles
        {
            get
            {
                if (_allRoles == null)
                {
                    _allRoles = Roles.GetAllRoles();
                }
                return _allRoles;
            }
            set
            {
                _allRoles = value;
            }
        }


        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            tblRoleManager = new Table();
            Controls.Add(tblRoleManager);
            tblRoleManager.CellPadding = 5;
            tblRoleManager.CellSpacing = 0;

            tr = new TableRow();
            Controls.Add(tr);
            tblRoleManager.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            txtAddNewRole = new TextBox();
            Controls.Add(txtAddNewRole);
            td.Controls.Add(txtAddNewRole);
            txtAddNewRole.ID = "txtAddNewRole";

            btnAddNewRole = new Button();
            Controls.Add(btnAddNewRole);
            td.Controls.Add(btnAddNewRole);
            btnAddNewRole.ID = "btnAddNewRole";
            btnAddNewRole.Text = "Add New Role";
            btnAddNewRole.Click += new EventHandler(btnAddNewRole_Click);



            thr = new TableHeaderRow();
            Controls.Add(thr);
            tblRoleManager.Rows.Add(thr);

            thd = new TableHeaderCell();
            Controls.Add(thd);
            thr.Cells.Add(thd);
            thd.Text = "Role Name";

            tr = new TableRow();
            Controls.Add(tr);
            tblRoleManager.Rows.Add(tr);

            tdListOfRolesContainer = new TableCell();
            Controls.Add(tdListOfRolesContainer);
            tr.Cells.Add(tdListOfRolesContainer);

            lblMessage = new Label();
            Controls.Add(lblMessage);
            tdListOfRolesContainer.Controls.Add(lblMessage);
            lblMessage.Visible = false;

            PopulateListOfRoles();
        }


        private void PopulateListOfRoles()
        {
            if (tblListOfRoles != null)
            {
                tblListOfRoles.Rows.Clear();
                tblListOfRoles.Controls.Clear();
            }

            if (AllRoles.Length == 0)
            {
                tdListOfRolesContainer.Text = "There aren't any roles, please add some.";
            }
            else
            {
                tblListOfRoles = new Table();
                Controls.Add(tblListOfRoles);
                tdListOfRolesContainer.Controls.Add(tblListOfRoles);

                for (int r = 0; r < AllRoles.Length; r++)
                {
                    tr = new TableRow();
                    Controls.Add(tr);
                    tblListOfRoles.Rows.Add(tr);

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Width = Unit.Pixel(150);

                    manageRole = new LinkButton();
                    Controls.Add(manageRole);
                    td.Controls.Add(manageRole);
                    manageRole.Text = AllRoles[r].ToString();
                    manageRole.Click += new EventHandler(manageRole_Click);
                    manageRole.ToolTip = "Click to add / remove users from this role.";

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);

                    btnDeleteRole = new Button();
                    Controls.Add(btnDeleteRole);
                    td.Controls.Add(btnDeleteRole);
                    btnDeleteRole.Text = "Delete";
                    btnDeleteRole.Click += new EventHandler(btnDeleteRole_Click);
                    btnDeleteRole.CommandArgument = AllRoles[r].ToString();

                }
            }
        }


        void btnDeleteRole_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string roleName = btn.CommandArgument;
            if (Roles.RoleExists(roleName))
            {
                try
                {
                    Roles.DeleteRole(roleName);
                    AllRoles = null;
                    PopulateListOfRoles();

                    if (RoleSelected != null)
                    {
                        RoleSelected(string.Empty);
                    }
                }
                catch (System.Configuration.Provider.ProviderException)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Can't delete role, it has users attached to it.  Remove the users from the role first.";

                    if (RoleSelected != null)
                    {
                        RoleSelected(roleName);
                    }
                }
                catch (Exception ex)
                {
                    Logging.Logger.LogException("RoleManager, btnDeleteRole_Click() failed.", ex);
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error - consult the system logs.";
                }
            }
        }


        private void btnAddNewRole_Click(object sender, EventArgs e)
        {
            string newRoleName = txtAddNewRole.Text;
            if (newRoleName.Trim().Equals(string.Empty))
            {
                // Ignore ?
            }
            else
            {
                try
                {
                    if (!Roles.RoleExists(newRoleName))
                    {
                        Roles.CreateRole(newRoleName);
                        AllRoles = null;
                        Auditor.LogAuditEntry(Auditor.ObjectIdUnknown, AuditableObjects.Role, string.Format("Role '{0}' Created.", newRoleName));
                        txtAddNewRole.Text = string.Empty;
                        PopulateListOfRoles();


                        if (RoleSelected != null)
                        {
                            RoleSelected(string.Empty);
                        }
                    }
                }
                catch (Exception ex)
                {
                    tdListOfRolesContainer.Text = "Could not add role - see system logs.";

                    Logging.Logger.LogException("Morphfolia.PublishingSystem.WebControls.RoleManager.btnAddNewRole_Click()", ex, 666, string.Format("Couldn't add this role '{0}'.", newRoleName));
                }
            }
        }


        public delegate void onRoleSelected(string role);
        public event onRoleSelected RoleSelected;

        void manageRole_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            if (RoleSelected != null)
            {
                RoleSelected(btn.Text);
            }
        }


        //protected override void RenderContents(HtmlTextWriter writer)
        //{
        //    EnsureChildControls();

        //    if (Visible)
        //    {
        //        base.RenderContents(writer);
        //    }
        //}
    }
}