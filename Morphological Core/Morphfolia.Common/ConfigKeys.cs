// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Attributes;

namespace Morphfolia.Common
{
    [IsAppSettingKeyClass()]
    public static class AppSettingKeys
    {        
        ////<add key="      Morphfolia.LayoutTemplate.Assembly" value="Morphological.Kudos" />
        //[IsAppSettingKey("Morphfolia.LayoutTemplate.Assembly", "", "Morphological.Kudos")]
        //public const string LayoutProviderAssembly = "Morphfolia.LayoutTemplate.Assembly";

        //[IsAppSettingKey("Morphfolia.LayoutTemplateAssembilies", "A list of assembilies that contain LayoutTemplates. Can be blank.  Seperate multiple entries with a space.", "Morphological.Kudos OurNamespace.StandardLayouts")]
        //public const string LayoutTemplateAssembilies = "Morphfolia.LayoutTemplateAssembilies";


        [IsAppSettingKey("Morphfolia.LayoutTemplate.DefaultPageLayout", "", "Morphological.Kudos.Layouts.SimplePageLayout, Morphological.Kudos")]
        public const string DefaultLayout = "Morphfolia.LayoutTemplate.DefaultPageLayout";

        [IsAppSettingKey("Morphfolia.LayoutTemplate.DefaultWebFormLayoutHelper", "", "Morphological.Kudos.Skins.SpecialCircumstances.Anaplian, Morphological.Kudos")]
        public const string DefaultWebFormLayoutHelper = "Morphfolia.LayoutTemplate.DefaultWebFormLayoutHelper";

        [IsAppSettingKey("Morphfolia.LayoutTemplate.DefaultISkinProvider", "", "Morphological.Kudos.Skins.SpecialCircumstances.Anaplian, Morphological.Kudos")]
        public const string DefaultISkinProvider = "Morphfolia.LayoutTemplate.DefaultISkinProvider";

        [IsAppSettingKey("Morphfolia.DefaultFormTemplatePresenter", "", " Morphfolia.WebControls.FormTemplateControls.DefaultFormTemplatePresenterProvider, Morphfolia.WebControls")]
        public const string DefaultFormTemplatePresenter = "Morphfolia.DefaultFormTemplatePresenter";


        /// <summary>
        /// If used, requests will be logged 'inline' by the default Http Handler and the Morphfolia.PublishingAssistant.WebFormHelper
        /// Valid values: true, [false].
        /// </summary>        
        [IsAppSettingKey("Morphfolia.LogHttpRequests.Inline", "If used, requests will be logged 'inline' by the default Http Handler and the Morphfolia.PublishingAssistant.WebFormHelper", "Valid values: true, [false]")]
        public const string LogHttpRequestsInline = "Morphfolia.LogHttpRequests.Inline";

        /// <summary>
        /// If used, all requests will be logged by an HttpModule: Morphfolia.Web.HttpModules.ApplicationRequestLogger
        /// Valid values: true, [false].
        /// </summary>
        [IsAppSettingKey("Morphfolia.LogHttpRequests.Universally", "If used, all requests will be logged by an HttpModule: Morphfolia.Web.HttpModules.ApplicationRequestLogger", "Valid values: true, [false]")]
        public const string LogHttpRequestsUniversally = "Morphfolia.LogHttpRequests.Universally";

        //[IsAppSettingKey("Morphfolia.HttpSessionFlow.HomepageUrl")]
        //public const string HttpSessionFlowHomePageUrl = "Morphfolia.HttpSessionFlow.HomepageUrl";

        //[IsAppSettingKey("Morphfolia.HttpSessionFlow.OptionalUrl")]
        //public const string HttpSessionFlowOptionalUrl = "Morphfolia.HttpSessionFlow.OptionalUrl";

        //<add key="      Morphfolia.StyleSheet" value="Morphfolia/siteStyle.css" />
        [IsAppSettingKey("Morphfolia.StyleSheet", "", "Morphfolia/siteStyle.css")]
        public const string DefaultStyleSheet = "Morphfolia.StyleSheet";


        //<add key="      Morphfolia.DefaultRSSXsl" value="Morphfolia/DefaultRSS.xsl" />
        [IsAppSettingKey("Morphfolia.DefaultRSSXsl", "The location of the xsl to use in generic situations.", "Morphfolia/DefaultRSS.xsl")]
        public const string DefaultRSSXsl = "Morphfolia.DefaultRSSXsl";

                
        /// <summary>
        /// Valid values: true, [false].
        /// </summary>
        //<add key="Morphfolia.Web.InlineTracing.Enabled" value="false" />
        [IsAppSettingKey("Morphfolia.Web.InlineTracing.Enabled")]
        public const string EnableInlineTracing = "Morphfolia.Web.InlineTracing.Enabled";


        /// <summary>
        /// The config key that identifies the appSetting which specifies the URL users 
        /// are sent to when they successfully complete Registration via the provided 
        /// registration page.
        /// </summary>
        [IsAppSettingKey("Morphfolia.RegistrationPage.ContinueDestinationPageUrl")]
        public const string ContinueDestinationPageUrl = "Morphfolia.RegistrationPage.ContinueDestinationPageUrl";

        /// <summary>
        /// The config key that identifies the appSetting which specifies the Role 
        /// that newly registered users are automatically added to when they register
        /// via the provided registration page.
        /// </summary>
        [IsAppSettingKey("Morphfolia.RegistrationPage.AutomaticRoleNewUsersJoin")]
        public const string AutomaticRoleNewUsersJoin = "Morphfolia.RegistrationPage.AutomaticRoleNewUsersJoin";



        [IsAppSettingKey("Morphfolia.DefaultSMTPServer", "The address of the SMTP server to use when sending email, used to initialize instances of the SmtpClient (System.Net.Mail.SmtpClient).")]
        public const string DefaultSMTPServer = "Morphfolia.DefaultSMTPServer";

        [IsAppSettingKey("Morphfolia.Email.FromAddress", "The 'from' email address used to send email when the actual sender is not known, such as by the system.")]
        public const string EmailFromAddress = "Morphfolia.Email.FromAddress";

        [IsAppSettingKey("Morphfolia.Email.DefaultAlertAddress", "The address that 'alert' emails can be sent to.")]
        public const string DefaultAlertAddress = "Morphfolia.Email.DefaultAlertAddress";

        
    }
}
