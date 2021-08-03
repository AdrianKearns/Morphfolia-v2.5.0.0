// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Morphfolia.PublishingSystem.WebControls;

public partial class _publishing_userrole_manager : System.Web.UI.Page
{
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }
    #endregion

    RoleManager roleManager;
    private RoleManagerUserList roleManagerUserList;

    private string selectedRole
    {
        get
        {
            return (string)ViewState["SelectedRole"];
        }
        set
        {
            ViewState["SelectedRole"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        roleManager = new RoleManager();
        plhdrRoleList.Controls.Add(roleManager);
        roleManager.ID = "RoleManager";
        roleManager.RoleSelected += new RoleManager.onRoleSelected(roleManager_RoleSelected);
        roleManager.Width = Unit.Percentage(100);

        roleManagerUserList = new RoleManagerUserList();
        plhdrManageMembership.Controls.Add(roleManagerUserList);
        roleManagerUserList.ID = "roleManagerUserList";
        roleManagerUserList.Width = Unit.Percentage(100);
    }

    void roleManager_RoleSelected(string role)
    {
        selectedRole = role;
        roleManagerUserList.TargetRole = selectedRole;
    }
}
