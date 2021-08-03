// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;

using System.Web.Security;
using System.Web.UI.WebControls;
using Morphfolia.Common.Utilities;


public partial class Register : System.Web.UI.Page
{
    private Morphfolia.PublishingSystem.WebFormHelper WebFormHelper;


    protected void Page_Load(object sender, EventArgs e)
    {
        WebFormHelper = new Morphfolia.PublishingSystem.WebFormHelper();
        string sssss = WebFormHelper.ContentForPageByPropertyKey("PrivacyPolicyNotice");

        CreateUserWizard1.CancelDestinationPageUrl = "default.aspx";

        //CreateUserWizard1.ContinueDestinationPageUrl = "sitemap.aspx";
        //string continueDestinationPageUrl = System.Configuration.ConfigurationManager.AppSettings[Morphfolia.Common.ConfigKeys.ContinueDestinationPageUrl];
        string continueDestinationPageUrl = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.ContinueDestinationPageUrl);

        if (continueDestinationPageUrl == null)
        {
            continueDestinationPageUrl = "default.aspx";
        }

        if (continueDestinationPageUrl.Equals(string.Empty))
        {
            continueDestinationPageUrl = "default.aspx";
        }
        CreateUserWizard1.ContinueDestinationPageUrl = continueDestinationPageUrl;

        CreateUserWizard1.ContinueButtonClick += new EventHandler(CreateUserWizard1_ContinueButtonClick);
        CreateUserWizard1.NextButtonClick += new WizardNavigationEventHandler(CreateUserWizard1_NextButtonClick);
        CreateUserWizard1.FinishButtonClick += new WizardNavigationEventHandler(CreateUserWizard1_FinishButtonClick);
        CreateUserWizard1.CreatedUser += new EventHandler(CreateUserWizard1_CreatedUser1);


        WebFormHelper.AmendHTMLHead(this);
        pnlPageHeader.Controls.Add(WebFormHelper.CreateHeader());
        pnlContent.Controls.Add(WebFormHelper.ContentForPage());
        pnlPageFooter.Controls.Add(WebFormHelper.CreateFooter());
    }


    void CreateUserWizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //sb.Append("<b>CreateUserWizard1_FinishButtonClick</b><br>");
        //sb.AppendFormat("ContinueDestinationPageUrl: {0}<br>", CreateUserWizard1.ContinueDestinationPageUrl);
        //sb.AppendFormat("ActiveStep.Name: {0}<br>", CreateUserWizard1.ActiveStep.Name);
        //sb.AppendFormat("ActiveStep.ID: {0}<br>", CreateUserWizard1.ActiveStep.ID);
        //sb.AppendFormat("ActiveStepIndex: {0}<br>", CreateUserWizard1.ActiveStepIndex.ToString());

        //lblRegistrationFeedback.Text = sb.ToString();
    }

    void CreateUserWizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //sb.Append("<b>CreateUserWizard1_NextButtonClick</b><br>");
        //sb.AppendFormat("ContinueDestinationPageUrl: {0}<br>", CreateUserWizard1.ContinueDestinationPageUrl);
        //sb.AppendFormat("ActiveStep.Name: {0}<br>", CreateUserWizard1.ActiveStep.Name);
        //sb.AppendFormat("ActiveStep.ID: {0}<br>", CreateUserWizard1.ActiveStep.ID);
        //sb.AppendFormat("ActiveStepIndex: {0}<br>", CreateUserWizard1.ActiveStepIndex.ToString());

        //lblRegistrationFeedback.Text = sb.ToString();
    }

    void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
    {
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //sb.Append("<b>CreateUserWizard1_ContinueButtonClick</b><br>");
        //sb.AppendFormat("ContinueDestinationPageUrl: {0}<br>", CreateUserWizard1.ContinueDestinationPageUrl);
        //sb.AppendFormat("ActiveStep.Name: {0}<br>", CreateUserWizard1.ActiveStep.Name);
        //sb.AppendFormat("ActiveStep.ID: {0}<br>", CreateUserWizard1.ActiveStep.ID);
        //sb.AppendFormat("ActiveStepIndex: {0}<br>", CreateUserWizard1.ActiveStepIndex.ToString());
        
        //lblRegistrationFeedback.Text = sb.ToString();
    }


    protected void CreateUserWizard1_CreatedUser1(object sender, EventArgs e)
    {
        Morphfolia.Common.Logging.Logger.LogInformation("New User Registered.", sender.GetType().ToString(), 5990);


        string defaultSMTPServer = string.Empty;
        string emailFromAddress = string.Empty;
        string defaultAlertAddress = string.Empty;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        try
        {
            emailFromAddress = Morphfolia.Common.Utilities.ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.EmailFromAddress);
            defaultAlertAddress = Morphfolia.Common.Utilities.ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultAlertAddress);
            defaultSMTPServer = Morphfolia.Common.Utilities.ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultSMTPServer);

            sb.AppendFormat("Username: {0}", CreateUserWizard1.UserName);
            sb.AppendFormat("{0}Email: {1}", Environment.NewLine, CreateUserWizard1.Email);

            System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(emailFromAddress, defaultAlertAddress);
            mm.Subject = string.Format("A new user {0} has registered.", CreateUserWizard1.UserName);
            mm.Body = sb.ToString();
            System.Net.Mail.SmtpClient s = new System.Net.Mail.SmtpClient(defaultSMTPServer);
            s.Send(mm);
        }
        catch (Exception ex)
        {
            Morphfolia.Common.Logging.Logger.LogException("Register.aspx, CreateUserWizard1_CreatedUser1(): Error.", ex, 666);
            Morphfolia.Common.Logging.Logger.LogWarning("Problem sending email", string.Format("The following SMTP Server was used during a failed attempt to send an email.  This value may not be at fault, it is provided here for reference. Default SMTP Server: '{0}'", defaultSMTPServer), 9897);
            Morphfolia.Common.Logging.Logger.LogWarning("Problem sending email", string.Format("The following 'to' email address was used during a failed attempt to send an email.  This value may not be at fault, it is provided here for reference. 'to' email address (defaultAlertAddress): '{0}'", defaultAlertAddress), 9897);
            Morphfolia.Common.Logging.Logger.LogWarning("Problem sending email", string.Format("The following 'from' email address was used during a failed attempt to send an email.  This value may not be at fault, it is provided here for reference. 'From' email address: '{0}'", emailFromAddress), 9897);
        }


        try
        {
            string automaticRoleNewUsersJoin = ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.AutomaticRoleNewUsersJoin);
            if (automaticRoleNewUsersJoin != null)
            {
                if (!automaticRoleNewUsersJoin.Equals(string.Empty))
                {
                    if (!Roles.RoleExists(automaticRoleNewUsersJoin))
                    {
                        Roles.CreateRole(automaticRoleNewUsersJoin);
                    }

                    Roles.AddUserToRole(CreateUserWizard1.UserName, automaticRoleNewUsersJoin);
                }
            }
        }
        catch (Exception ex)
        {
            Morphfolia.Common.Logging.Logger.LogException("New User Registered, but not added to any default Role.", ex, 5990);
        }

    }
}
