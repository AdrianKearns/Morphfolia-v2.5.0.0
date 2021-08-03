// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.ComponentModel;
using System.Configuration;
using System.Web.Configuration;
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
    public class ManageUser : WebControl, INamingContainer
    {        
        private Table tblManageUser;
        private TableRow tr;
        private TableCell td;
        private Label lblLockStatus;
        private TableCell tdUserName;
        private TableCell tdEmail;
        private TextBox txtEmailAddress;
        private Button btnSaveEmailAddress;
        private TableCell tdCreationDate;
        private TableCell tdIsApproved;
        private Label lblApprovalStatus;
        private Button btnApproveUser;
        private TableCell tdIsLockedOut;
        private TableCell tdIsOnline;
        private TableCell tdLastActivityDate;
        private TableCell tdLastLockoutDate;
        private TableCell tdLastLoginDate;
        private TableCell tdLastPasswordChangedDate;
        private TableCell tdPasswordQuestion;
        private TableCell tdSendUserTheirPassword;
        private Button btnSendUserTheirPassword;
        private Button btnUnlockUser;
        private TableCell tdRoles;
        private Literal htmlSnippet;



        public delegate void OnUsersDataChanged();
        public event OnUsersDataChanged UsersDataChanged;



        private string username;
        /// <summary>
        /// Setting this property will populate the underlying User object.
        /// </summary>
        public string UserName
        {
            get { return username; }
            set
            {
                username = value;

                user = Membership.GetUser(username);
            }
        }

        private MembershipUser user;
        public MembershipUser User
        {
            get { return user; }
            set
            {
                user = value;
                UserName = user.UserName;

                PopulateWithUserData();
            }
        }


        /// <summary>
        /// Gets the latest version of the users data, and 
        /// re-populates the form.
        /// </summary>
        private void RefreshUsersData()
        {
            user = Membership.GetUser(username);
            PopulateWithUserData();
        }


        private void PopulateWithUserData()
        {
            EnsureChildControls();

            tdUserName.Text = user.UserName;
            //tdEmail.Text = user.Email;
            txtEmailAddress.Text = user.Email;
            tdCreationDate.Text = user.CreationDate.ToString();

            //tdIsApproved.Text = user.IsApproved.ToString();
            if (user.IsApproved)
            {
                btnApproveUser.CommandName = "DisapproveUser";
                btnApproveUser.Text = "Disallow";
            }
            else
            {
                btnApproveUser.CommandName = "approvedUser";
                btnApproveUser.Text = "Allow";
            }
            btnApproveUser.CommandArgument = user.UserName;
            lblApprovalStatus.Text = string.Format("{0} &nbsp; ", user.IsApproved.ToString());


            lblLockStatus.Text = user.IsLockedOut.ToString();

            if (user.IsLockedOut)
            {
                btnUnlockUser.Visible = true;
                btnUnlockUser.CommandArgument = user.UserName;
            }


            tdIsOnline.Text = user.IsOnline.ToString();
            tdLastActivityDate.Text = user.LastActivityDate.ToString();

            if (user.LastLockoutDate.Year <= 1800)
            {
                tdLastLockoutDate.Text = "&nbsp;";
            }
            else
            {
                tdLastLockoutDate.Text = user.LastLockoutDate.ToString();
            }

            tdLastLoginDate.Text = user.LastLoginDate.ToString();
            tdLastPasswordChangedDate.Text = user.LastPasswordChangedDate.ToString();
            tdPasswordQuestion.Text = user.PasswordQuestion;
           
            btnSendUserTheirPassword.Visible = true;
            btnSendUserTheirPassword.CommandArgument = user.UserName;
            btnSaveEmailAddress.CommandArgument = user.UserName;
            

            System.Text.StringBuilder sbRoles = new System.Text.StringBuilder();

            string[] rolesForUser = Roles.GetRolesForUser(user.UserName);

            if (rolesForUser.Length == 0)
            {
                sbRoles.Append("Not a member of any Roles.");
            }
            else
            {
                for (int i = 0; i < rolesForUser.Length; i++)
                {
                    sbRoles.AppendFormat("{0}<br>", rolesForUser[i]);
                }
            }

            tdRoles.Text = sbRoles.ToString();            
        }



        protected override void CreateChildControls()
        {
            tblManageUser = new Table();
            Controls.Add(tblManageUser);
            tblManageUser.CellPadding = 5;
            tblManageUser.CellSpacing = 0;

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "User Name";

            tdUserName = new TableCell();
            Controls.Add(tdUserName);
            tr.Cells.Add(tdUserName);

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Email";

            tdEmail = new TableCell();
            Controls.Add(tdEmail);
            tr.Cells.Add(tdEmail);

            txtEmailAddress = new TextBox();
            Controls.Add(txtEmailAddress);
            tdEmail.Controls.Add(txtEmailAddress);
            txtEmailAddress.Width = Unit.Pixel(300);

            htmlSnippet = new Literal();
            Controls.Add(htmlSnippet);
            tdEmail.Controls.Add(htmlSnippet);
            htmlSnippet.Text = "<br>";

            btnSaveEmailAddress = new Button();
            Controls.Add(btnSaveEmailAddress);
            tdEmail.Controls.Add(btnSaveEmailAddress);
            btnSaveEmailAddress.Text = "Save Email Address";
            btnSaveEmailAddress.Command += new CommandEventHandler(btnSaveEmailAddress_Command);



            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "User Created";

            tdCreationDate = new TableCell();
            Controls.Add(tdCreationDate);
            tr.Cells.Add(tdCreationDate);

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Is Approved";

            tdIsApproved = new TableCell();
            Controls.Add(tdIsApproved);
            tr.Cells.Add(tdIsApproved);

            lblApprovalStatus = new Label();
            Controls.Add(lblApprovalStatus);
            tdIsApproved.Controls.Add(lblApprovalStatus);

            btnApproveUser = new Button();
            Controls.Add(btnApproveUser);
            tdIsApproved.Controls.Add(btnApproveUser);
            btnApproveUser.Command += new CommandEventHandler(btnApproveUser_Command);
            btnApproveUser.Text = "NotSet";
            btnApproveUser.Visible = true;


            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Is LockedOut";

            tdIsLockedOut = new TableCell();
            Controls.Add(tdIsLockedOut);
            tr.Cells.Add(tdIsLockedOut);


            //btnChangeLockOnUser
            lblLockStatus = new Label();
            Controls.Add(lblLockStatus);
            tdIsLockedOut.Controls.Add(lblLockStatus);

            btnUnlockUser = new Button();
            Controls.Add(btnUnlockUser);
            tdIsLockedOut.Controls.Add(btnUnlockUser);
            btnUnlockUser.Visible = false;
            btnUnlockUser.Text = "Unlock User";
            btnUnlockUser.Command += new CommandEventHandler(btnUnlockUser_Command);
            btnUnlockUser.CommandName = "UnlockUser";

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Is Online?";

            tdIsOnline = new TableCell();
            Controls.Add(tdIsOnline);
            tr.Cells.Add(tdIsOnline);

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Last Activity";

            tdLastActivityDate = new TableCell();
            Controls.Add(tdLastActivityDate);
            tr.Cells.Add(tdLastActivityDate);

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Last Lockout";

            tdLastLockoutDate = new TableCell();
            Controls.Add(tdLastLockoutDate);
            tr.Cells.Add(tdLastLockoutDate);

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Last Login";

            tdLastLoginDate = new TableCell();
            Controls.Add(tdLastLoginDate);
            tr.Cells.Add(tdLastLoginDate);

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Password Last Changed";

            tdLastPasswordChangedDate = new TableCell();
            Controls.Add(tdLastPasswordChangedDate);
            tr.Cells.Add(tdLastPasswordChangedDate);

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Password Question";

            tdPasswordQuestion = new TableCell();
            Controls.Add(tdPasswordQuestion);
            tr.Cells.Add(tdPasswordQuestion);

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "&nbsp;";

            tdSendUserTheirPassword = new TableCell();
            Controls.Add(tdSendUserTheirPassword);
            tr.Cells.Add(tdSendUserTheirPassword);

            btnSendUserTheirPassword = new Button();
            Controls.Add(btnSendUserTheirPassword);
            tdSendUserTheirPassword.Controls.Add(btnSendUserTheirPassword);
            btnSendUserTheirPassword.Visible = false;
            btnSendUserTheirPassword.Text = "Send User Their Password";
            btnSendUserTheirPassword.Command += new CommandEventHandler(btnSendUserTheirPassword_Command);
            btnSendUserTheirPassword.CommandName = "SendUserTheirPasswordUserName";

            tr = new TableRow();
            Controls.Add(tr);
            tblManageUser.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "Membership (<a href='userrole_manager.aspx'>Manage</a>)";
            td.VerticalAlign = VerticalAlign.Top;

            tdRoles = new TableCell();
            Controls.Add(tdRoles);
            tr.Cells.Add(tdRoles);
        }




        void btnSaveEmailAddress_Command(object sender, CommandEventArgs e)
        {
            try
            {
                MembershipUser user = Membership.GetUser(e.CommandArgument.ToString());
                user.Email = txtEmailAddress.Text.Trim();
                Membership.UpdateUser(user);

                RefreshUsersData();

                if (UsersDataChanged != null)
                {
                    UsersDataChanged();
                }
            }
            catch (Exception ex)
            {
                Morphfolia.Common.Logging.Logger.LogException("ManageUser (Web Control); btnSaveEmailAddress_Command(): Error.", ex, Logging.EventIds._3313);
                tdSendUserTheirPassword.Text = "There was an error, could not save the users email address.";
            }
        }


        void btnApproveUser_Command(object sender, CommandEventArgs e)
        {
            try
            {
                MembershipUser user = Membership.GetUser(e.CommandArgument.ToString());

                if (e.CommandName.Equals("DisapproveUser"))
                {
                    user.IsApproved = false;
                    btnApproveUser.Text = "Allow";
                    Auditor.LogAuditEntry(Auditor.ObjectIdUnknown, AuditableObjects.User, string.Format("User '{0}' Disapproved.", user.UserName));
                }
                else
                {
                    user.IsApproved = true;
                    btnApproveUser.Text = "Disallow";
                    Auditor.LogAuditEntry(Auditor.ObjectIdUnknown, AuditableObjects.User, string.Format("User '{0}' Approved.", user.UserName));
                }

                Membership.UpdateUser(user);

                if (UsersDataChanged != null)
                {
                    UsersDataChanged();
                }

                RefreshUsersData();
            }
            catch (Exception ex)
            {
                Morphfolia.Common.Logging.Logger.LogException("ManageUser (Web Control); btnApproveUser_Command(): Error.", ex, Logging.EventIds._3312);
                tdSendUserTheirPassword.Text = "There was an error, could not approve/disapprove the user.";
            }
        }



        void btnUnlockUser_Command(object sender, CommandEventArgs e)
        {
            try
            {
                MembershipUser user = Membership.GetUser(e.CommandArgument.ToString());
                if (user.IsLockedOut)
                {
                    user.UnlockUser();
                    Auditor.LogAuditEntry(Auditor.ObjectIdUnknown, AuditableObjects.User, string.Format("User '{0}' Unlocked.", user.UserName));

                    if (UsersDataChanged != null)
                    {
                        UsersDataChanged();
                    }

                    PopulateWithUserData();
                }                
            }
            catch (Exception ex)
            {
                Logging.Logger.LogException("ManageUser (Web Control); btnUnlockUser_Command(): Error.", ex, Logging.EventIds._3311);
                tdSendUserTheirPassword.Text = "There was an error, could not unlock the user.";
            }
        }



        void btnSendUserTheirPassword_Command(object sender, CommandEventArgs e)
        {            
            string defaultSMTPServer = string.Empty;
            string emailFromAddress = string.Empty;
            string membershipProviderKey;
            string membershipProviderValue;
            bool passwordIsHashed = false;

            try
            {
                emailFromAddress = Morphfolia.Common.Utilities.ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.EmailFromAddress);
                defaultSMTPServer = Morphfolia.Common.Utilities.ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultSMTPServer);

                MembershipUser user = Membership.GetUser(e.CommandArgument.ToString());
                System.Web.Configuration.MembershipSection membSect = System.Web.Configuration.WebConfigurationManager.GetSection("system.web/membership") as MembershipSection;

                //System.Text.StringBuilder temp = new System.Text.StringBuilder();
                //temp.AppendFormat("   ElementInformation.LineNumber = {0}", membSect.ElementInformation.LineNumber.ToString());
                //temp.AppendFormat("   Providers.Count = {0}", membSect.Providers.Count.ToString());

                ProviderSettings settings = membSect.Providers[0];
                //temp.AppendFormat("   Parameters.Count = {0}", settings.Parameters.Count.ToString());
                //temp.AppendFormat("   Type = {0}", settings.Type);
                //temp.AppendFormat("   Name = {0}", settings.Name);

                for (int k = 0; k < settings.Parameters.Count; k++ )
                {
                    membershipProviderKey = settings.Parameters.GetKey(k).ToLower();
                    membershipProviderValue = settings.Parameters.GetValues(k)[0].ToLower();

                    //temp.AppendFormat("{0}Parameter: {1} = {2}", 
                    //    Environment.NewLine, 
                    //    membershipProviderKey,
                    //    membershipProviderValue);

                    if (membershipProviderKey.Equals("passwordformat"))
                    {
                        if (membershipProviderValue.Equals("hashed"))
                        {
                            passwordIsHashed = true;
                        }
                        break;
                    }
                }
                //Logging.Logger.LogVerboseInformation("Debugging Info", temp.ToString(), Logging.EventIds._3310);

                string pword;
                if (passwordIsHashed)
                {
                    // Assumes we don't need to provide the passwordAnswer.
                    pword = user.ResetPassword();
                }
                else
                {
                    // Works for passwordformat = Clear (and in theory, Encrypted).
                    pword = user.GetPassword();
                }
                

                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(emailFromAddress, user.Email);
                mm.Subject = "Reset as Requested.";
                mm.Body = string.Format("{0}", pword);
                System.Net.Mail.SmtpClient s = new System.Net.Mail.SmtpClient(defaultSMTPServer);

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendFormat("SMTP Server: {1}{0}", Environment.NewLine, defaultSMTPServer);
                sb.AppendFormat("To: {1}{0}", Environment.NewLine, user.Email);
                sb.AppendFormat("From: {1}{0}", Environment.NewLine, emailFromAddress);
                sb.AppendFormat("Subject: {1}{0}", Environment.NewLine, mm.Subject);
                sb.AppendFormat("Body: [withheld]{0}", Environment.NewLine, mm.Subject);
                Logging.Logger.LogVerboseInformation("Email about to be sent.", sb.ToString(), Logging.EventIds._3310);
                s.Send(mm);

                tdSendUserTheirPassword.Text = string.Format("The users password has been emailed to them, with the subject '{0}'.", mm.Subject);
            }
            catch (System.NotSupportedException exNotSupportedException)
            {
                Logging.Logger.LogException("ManageUser (Web Control); btnSendUserTheirPassword_Command(): Error.", exNotSupportedException, Logging.EventIds._3310);
                tdSendUserTheirPassword.Text = "Could not send the user their password.  The system is not configured to support sending the existing email - use the reset option instead.";
            }
            catch (System.Configuration.ConfigurationErrorsException exConfigurationErrorsException)
            {
                Logging.Logger.LogException("ManageUser (Web Control); btnSendUserTheirPassword_Command(): Error.", exConfigurationErrorsException, Logging.EventIds._3310);
                tdSendUserTheirPassword.Text = "Could not send the user their password.  There was a configuration error, the config must be changed.";
            }
            catch (System.Net.Mail.SmtpException exSmtpException)
            {
                Logging.Logger.LogException("ManageUser (Web Control); btnSendUserTheirPassword_Command(): Error.", exSmtpException, Logging.EventIds._3310);
                Logging.Logger.LogWarning("Problem sending email", string.Format("The following SMTP Server was used during a failed attempt to send an email.  This value may not be at fault, it is provided here for reference. Default SMTP Server: '{0}'", defaultSMTPServer), Logging.EventIds._3310);
                Logging.Logger.LogWarning("Problem sending email", string.Format("The following 'from' email address was used during a failed attempt to send an email.  This value may not be at fault, it is provided here for reference. 'From' email address: '{0}'", emailFromAddress), Logging.EventIds._3310);
                tdSendUserTheirPassword.Text = "Could not send the user their password.  There was an SMTP related error.";
            }
            catch (Exception ex)
            {
                Logging.Logger.LogException("ManageUser (Web Control); btnSendUserTheirPassword_Command(): Error.", ex, Logging.EventIds._3310);
                tdSendUserTheirPassword.Text = "Could not reset/send the user their password, there was an error.";
            }
        }



        protected override void RenderContents(HtmlTextWriter writer)
        {
            tblManageUser.Width = Width;
           
            base.RenderContents(writer);
        }
    }
}