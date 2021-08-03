// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for TestSecurity
/// </summary>
public class TestSecurity : WebControl, INamingContainer
{
    Label lbl;

    protected override void CreateChildControls()
    {
        base.CreateChildControls();

        lbl = new Label();
        Controls.Add(lbl);
    }

    private void Append(string[] arry, System.Text.StringBuilder stringBuilder)
    {
        for (int i = 0; i < arry.Length; i++)
        {
            stringBuilder.AppendFormat(" * {0}<br>", arry[i]);
            //Append(System.Web.Security.Roles.GetUsersInRole(arry[i].ToString()), stringBuilder);
        }
    }

    private void RoleCall(System.Text.StringBuilder stringBuilder)
    {
        string[] allRoles = System.Web.Security.Roles.GetAllRoles();
        for (int i = 0; i < allRoles.Length; i++)
        {
            stringBuilder.AppendFormat("{0}<br>", allRoles[i]);
            Append(System.Web.Security.Roles.GetUsersInRole(allRoles[i].ToString()), stringBuilder);
        }
    }

    private string x()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        string[] allRoles = System.Web.Security.Roles.GetAllRoles();
        //string[] rolesForUser = System.Web.Security.Roles.GetRolesForUser("[user]");
        //string[] usersInRole = System.Web.Security.Roles.GetUsersInRole("[role]");

        RoleCall(sb);
        //Append(rolesForUser, sb);
        //Append(System.Web.Security.Roles.GetUsersInRole("[role]"), sb);

        //MembershipUser membershipUser;
        MembershipUserCollection membershipUserCollection = Membership.GetAllUsers();

        //membershipUser.i

        foreach (MembershipUser m in membershipUserCollection)
        {
            sb.AppendFormat(" * {0}, {1}<br>", m.UserName, m.Email);
        }

        for (int i = 0; i < membershipUserCollection.Count; i++)
        {
            
            //membershipUser = membershipUserCollection[i];
        }

        return sb.ToString();
    }

    protected override void RenderContents(HtmlTextWriter writer)
    {
        lbl.Text = x();
        base.RenderContents(writer);
    }
}
