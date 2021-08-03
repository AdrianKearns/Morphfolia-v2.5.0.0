// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Morphfolia.PublishingSystem.WebControls;

namespace Morphfolia.Web._publishing
{
	/// <summary>
	/// Summary description for user_management.
	/// </summary>
    public partial class User_Management : System.Web.UI.Page
	{

        private int subControlsWidth = 750;


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

        private UserList userList;
        private ManageUser manageUser;

        private string selectedUser
        {
            get
            {
                return (string)ViewState["SelectedUser"];
            }
            set
            {
                ViewState["SelectedUser"] = value;

                if (selectedUser != null)
                {
                    manageUser.User = userList.Users[selectedUser];
                    pnlManageUser.Visible = true;
                    pnlUserList.Height = Unit.Pixel(170);
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUserList.Style.Add("overflow-y", "scroll");
            pnlUserList.Height = Unit.Pixel(400);

            userList = new UserList();
            pnlUserList.Controls.Add(userList);
            userList.UserSelected += new UserList.onUserSelected(userList_UserSelected);
            userList.Width = Unit.Pixel(subControlsWidth);

            manageUser = new ManageUser();
            pnlManageUser.Controls.Add(manageUser);
            pnlManageUser.Visible = false;
            manageUser.Width = Unit.Pixel(subControlsWidth);
            manageUser.UsersDataChanged += new ManageUser.OnUsersDataChanged(manageUser_UsersDataChanged);


            if (selectedUser != null)
            {
                manageUser.User = userList.Users[selectedUser];
                pnlManageUser.Visible = true;
                pnlUserList.Height = Unit.Pixel(170);
            }
        }

        void manageUser_UsersDataChanged()
        {
            userList.Reset();
        }


        void userList_UserSelected(MembershipUser user)
        {
            selectedUser = user.UserName;
        }
	}
}