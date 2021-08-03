// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

namespace Morphfolia.Web.UserControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Security.Principal;
    using Morphfolia.Business;
    using System.Collections.Specialized;
    using Morphfolia.Common.Logging;
    using Morphfolia.Common.Types;
    using Morphfolia.WebControls.FormTemplateControls;


	/// <summary>
	///		Summary description for EditContent.
	/// </summary>
	public partial class EditContent : System.Web.UI.UserControl
	{
        public const string ContentIdQueryStringArgumentKey = "c";

		protected HttpContext CurrentContext = HttpContext.Current;
		protected IPrincipal _CurrentUser;
		protected string _CurrentUsersIdentityName = "?";
        private int _ContentID = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
		private Morphfolia.Business.ContentItem _ContentItem;
        private string s = string.Empty;


        private string contentEntryFilterHtmlEditorOptionValue = "HtmlEditor";
        public string ContentEntryFilterHtmlEditorOptionValue
        {
            get { return contentEntryFilterHtmlEditorOptionValue; }
        }


		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(CurrentContext.Request.QueryString["c"] != null)
			{
                if (CurrentContext.Request.QueryString["c"].ToString() != string.Empty)
                {
                    try
                    {
                        this._ContentID = int.Parse(CurrentContext.Request.QueryString["c"].ToString());
                        chkbxCreateOwnPage.Visible = false;
                        btnSaveAsNew1.Visible = true;
                        btnSaveAsNew2.Visible = true;
                        btnIndexContent.Visible = true;
                        btnDelete1.Visible = true;
                        btnDelete2.Visible = true;
                        chkbxConfirmDelete1.Visible = true;
                        chkbxConfirmDelete2.Visible = true;
                    }
                    catch
                    {
                        this._ContentID = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                    }
                }
			}

            if (this._ContentID == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                chkbxCreateOwnPage.Visible = true;
                btnSaveAsNew1.Visible = false;
                btnSaveAsNew2.Visible = false;
                btnIndexContent.Visible = false;
                btnDelete1.Visible = false;
                btnDelete2.Visible = false;                
                chkbxConfirmDelete1.Visible = false;
                chkbxConfirmDelete2.Visible = false;
            }

            _CurrentUser = HttpContext.Current.User;
            _CurrentUsersIdentityName = _CurrentUser.Identity.Name;
            _CurrentUsersIdentityName = _CurrentUsersIdentityName.Substring(_CurrentUsersIdentityName.IndexOf("|") + 1);


            if (!IsPostBack)
            {             
                chkbxIsLive.Checked = true;
                chkbxIsSearchable.Checked = true;

                PopulateContentEntryFilterDropDownList();

                PopulateUIWithExistingValues(_ContentID);
            }        
		}


        private void PopulateUIWithExistingValues(int contentId)
        {
            if (contentId > Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                _ContentItem = ContentItemHelper.GetContentItemById(contentId);

                litContentID.Text = _ContentItem.ContentID.ToString();
                txtNote.Text = _ContentItem.Note;

                if ((_ContentItem.ContentEntryFilter == string.Empty) | (_ContentItem.ContentEntryFilter.Equals(ContentEntryFilterHtmlEditorOptionValue)))
                {
                    HTMLEditor1.Html = _ContentItem.Content;
                    ToggleContentEntryFilterUI(false);
                    ddlContentEntryFilter.SelectedIndex = 0;
                }
                else
                {
                    LoadUpFormTemplate(_ContentItem.Content);
                    ToggleContentEntryFilterUI(true);

                    for (int i = 0; i < ddlContentEntryFilter.Items.Count; i++)
                    {
                        if (_ContentItem.ContentEntryFilter.EndsWith(ddlContentEntryFilter.Items[i].Value))
                        {
                            ddlContentEntryFilter.SelectedIndex = i;
                            break;
                        }
                    }
                }


                chkbxIsSearchable.Checked = _ContentItem.IsSearchable;
                chkbxIsLive.Checked = _ContentItem.IsLive;

                //Morphfolia.Common.Info.PageInfo tempPage;
                Morphfolia.Common.Info.PageInfoCollection pages = PageLister.PagesUsedByThisContentItem(_ContentID);

                if (pages.Count == 0)
                {
                    lblPagesThatUseThisItem.Text = "This content item is not used by any pages.";
                }
                else
                {
                    Morphfolia.PublishingSystem.WebControls.AdminSiteMap mapOfParentPages = new Morphfolia.PublishingSystem.WebControls.AdminSiteMap(pages);
                    lblPagesThatUseThisItem.Controls.Add(mapOfParentPages);
                    mapOfParentPages.RootNodeText = "Pages The Use This Content Item";
                    lblPagesThatUseThisItem.CssClass = "FunctionalArea";
                }
            }
            else
            {
                if (ddlContentEntryFilter.SelectedValue.Equals(ContentEntryFilterHtmlEditorOptionValue))
                {
                    HTMLEditor1.Html = string.Empty;
                    ToggleContentEntryFilterUI(false);
                    ddlContentEntryFilter.SelectedIndex = 0;
                }
                else
                {
                    LoadUpFormTemplate(null);
                    ToggleContentEntryFilterUI(true);
                }
            }
        }


        /// <summary>
        /// Need to wrap / protect this as it is only used some of the time.
        /// </summary>
        private void LoadUpFormTemplate(string content)
        {
            pnlFormTemplateContainer.Controls.Clear();
            string xmlDefPath = "[NotSet]";
            string rawXml = "[NotSet]";
            try
            {
                Morphfolia.WebControls.FormTemplateControls.DefaultFormTemplatePresenter formTemplateControl;

                if (content == null)
                {
                    xmlDefPath = string.Format("{0}Morphfolia\\_publishing\\FormTemplates\\{1}", 
                        AppDomain.CurrentDomain.BaseDirectory,
                        ddlContentEntryFilter.SelectedItem.Value);
                    //xmlDefPath = ddlContentEntryFilter.SelectedItem.Value;
                    if (!IsPostBack)
                    {
                        formTemplateControl = FormTemplateHelperThingy.CreateCleanForm(xmlDefPath, true);
                    }
                    else
                    {
                        formTemplateControl = FormTemplateHelperThingy.CreateCleanForm(xmlDefPath, true);
                    }
                    pnlFormTemplateContainer.Controls.Add(formTemplateControl);
                    formTemplateControl.ID = "FormTemplate";
                    formTemplateControl.ShowDataEntryForm = true;
                    ToggleContentEntryFilterUI(true);
                }
                else
                {                
                    // This will only work if it's xml content - not html.
                    rawXml = content;
                    formTemplateControl = FormTemplateHelperThingy.CreateUpdateForm(rawXml);
                    pnlFormTemplateContainer.Controls.Add(formTemplateControl);
                    formTemplateControl.ID = "FormTemplate";
                    formTemplateControl.ShowDataEntryForm = true;
                    //chkbxContentFilterType.Checked = true;
                    //pnlFormTemplateContainer.Style.Add("display", "inline");
                    ToggleContentEntryFilterUI(true);
                }
            }
            catch(Exception ex)
            {
                NameValueCollection AdditionalInfo = new NameValueCollection();
                AdditionalInfo.Add("Error", "Could not extract (de-serialize) FormTemplate.");
                AdditionalInfo.Add("xmlDefPath", xmlDefPath);
                AdditionalInfo.Add("rawXml", Server.HtmlEncode(rawXml));
                ExceptionManager.Publish(ex, EventIds.Default.NotSet, AdditionalInfo);

                Label lblErrorMessage = new Label();
                pnlFormTemplateContainer.Controls.Add(lblErrorMessage);
                lblErrorMessage.Text = "Sorry, could not open that Form Template.";
            }
        }


        private void PopulateContentEntryFilterDropDownList()
        {
            string xmlDefPath = string.Format("{0}Morphfolia\\_publishing\\FormTemplates", AppDomain.CurrentDomain.BaseDirectory);

            String[] availableFilters = System.IO.Directory.GetFiles(xmlDefPath);
            string filterName;

            ddlContentEntryFilter.Items.Clear();
            ddlContentEntryFilter.Items.Add(new ListItem("Normal", ContentEntryFilterHtmlEditorOptionValue));
            for (int i = 0; i < availableFilters.Length; i++)
            {
                filterName = availableFilters[i];
                filterName = filterName.Substring(filterName.LastIndexOf("\\") + 1);
                //ddlContentEntryFilter.Items.Add(new ListItem(filterName, availableFilters[i]));
                ddlContentEntryFilter.Items.Add(new ListItem(filterName, filterName));
            }
        }


        protected void ToggleContentEntryFilterUI(bool showFormTemplate)
        {
            if (showFormTemplate)
            {
                pnlFormTemplateContainer.Style.Add("display", "block");
                HTMLEditor1.Style.Add("display", "none");
            }
            else
            {
                pnlFormTemplateContainer.Style.Add("display", "none");
                HTMLEditor1.Style.Add("display", "block");
            }           
        }


        protected void ddlContentEntryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateUIWithExistingValues(_ContentID);
        }


		protected void btnSave_Click(object sender, System.EventArgs e)
		{
            int contentId = Save();
            if (Request.Url.AbsoluteUri.Contains("?"))
            {
                CurrentContext.Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                //CurrentContext.Response.Redirect(string.Format("edit_content.aspx?c={0}", contentId.ToString()));
                CurrentContext.Response.Redirect(string.Format("{0}?{1}={2}", Request.Url.AbsoluteUri, ContentIdQueryStringArgumentKey, contentId));
            }
        }

        protected void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            this._ContentID = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
            int contentId = Save();
            CurrentContext.Response.Redirect(string.Format("edit_content.aspx?c={0}", contentId.ToString()));
        }

		protected void btnSaveNExit_Click(object sender, System.EventArgs e)
		{
			Save();
			CurrentContext.Response.Redirect("../_publishing/content_management.aspx");
		}



		private int Save()
		{
			// if this._ContentID = -1, save a new instance.
			//string tempTitle;
            int outputContentId;

			if( this._ContentID == Morphfolia.Common.Constants.SystemTypeValues.NullInt )
			{
				Morphfolia.Business.ContentItem contentItem = new Morphfolia.Business.ContentItem();
				contentItem.Note = txtNote.Text.Trim();

                if ( !ddlContentEntryFilter.SelectedItem.Value.Equals("HtmlEditor") )
                {
                    contentItem.Content = ComposeXml();
                    contentItem.TextContent = ComposeXml();
                }
                else
                {
                    contentItem.Content = HTMLEditor1.Html;
                    contentItem.TextContent = HTMLEditor1.Text.Trim();
                }

                contentItem.ContentType = Common.ContentTypes.OpenMarkup;
				contentItem.IsLive = chkbxIsLive.Checked;
				contentItem.IsSearchable = chkbxIsSearchable.Checked;
                contentItem.ContentEntryFilter = ddlContentEntryFilter.SelectedValue;
                contentItem.LastModifiedBy = _CurrentUsersIdentityName;
                outputContentId = ContentItemHelper.Save(contentItem);
				




                //// Create a dedicated page to hold this content. 
                //// At the moment you can only do this for a "new" page: 
                //if( this.chkbxCreateOwnPage.Checked )
                //{
                //    //-------------------------------------------------------------------
                //    // Maybe this code should probably be put into the PageFactory?
                //    //-------------------------------------------------------------------
                //    int lengthOfContentToUseForTitle = 500;
                //    if( contentItem.TextContent.Length < lengthOfContentToUseForTitle )
                //    {
                //        lengthOfContentToUseForTitle = contentItem.TextContent.Length;
                //    }
                //    tempTitle = contentItem.TextContent.Substring(0, lengthOfContentToUseForTitle);
                //    if( tempTitle.Length == 0 )
                //    {
                //        tempTitle = "Untitled";
                //    }

                //    int lengthOfContentToUseForDescription = 1000;
                //    if( contentItem.TextContent.Length < lengthOfContentToUseForDescription )
                //    {
                //        lengthOfContentToUseForDescription = contentItem.TextContent.Length;
                //    }
                //    //-------------------------------------------------------------------

                //    Morphfolia.Business.Page page = Morphfolia.Business.PageFactory.Page( 
                //        _CurrentUsersIdentityName, 
                //        tempTitle, 
                //        contentItem.TextContent.Substring(0, lengthOfContentToUseForDescription), 
                //        chkbxIsLive.Checked, 
                //        chkbxIsSearchable.Checked,
                //        newContentItemID );
					
                //    int pageId = page.SaveAsNew( _CurrentUsersIdentityName );
                //    CurrentContext.Response.Redirect( string.Format("../_publishing/edit_page.aspx?p={0}", pageId.ToString()));
                //}
            }
			else
			{
				EnsureChildControls();

                ContentItem contentItem = ContentItemHelper.GetContentItemById(_ContentID);
				contentItem.Note = txtNote.Text;

                if (!ddlContentEntryFilter.SelectedItem.Value.Equals("HtmlEditor"))
                {
                    contentItem.Content = ComposeXml();
                    contentItem.TextContent = ComposeText();
                }
                else
                {
                    contentItem.Content = HTMLEditor1.Html;
                    contentItem.TextContent = HTMLEditor1.Text;
                }

                //contentItem.ContentType = Common.ContentTypes.OpenMarkup;
				contentItem.IsLive = chkbxIsLive.Checked;
				contentItem.IsSearchable = chkbxIsSearchable.Checked;
                contentItem.LastModifiedBy = _CurrentUsersIdentityName;

                outputContentId = ContentItemHelper.Save(contentItem);
			}

            return outputContentId;
		}


        private string ComposeXml()
        {
            string xmlDefPath = string.Format("{0}Morphfolia\\_publishing\\FormTemplates\\{1}", 
                AppDomain.CurrentDomain.BaseDirectory,
                ddlContentEntryFilter.SelectedValue);

            ////FormTemplateField field;
            //FormTemplate formTemplate = FormTemplateHelperThingy.GetDefinitionFromXmlDefinitionFile(xmlDefPath);
            FormTemplate formTemplate = Morphfolia.Business.FormTemplateHelper.GetDefinitionFromXmlDefinitionFile(xmlDefPath);
            //formTemplate.Name = "NotSureWhereToGetThis";

            for (int i = 0; i < formTemplate.Fields.Count; i++)
            {
                // if its a post back - get the previous values: 
                formTemplate.Fields[i].Text = Morphfolia.PublishingSystem.WebUtilities.GetRequestParamValue(string.Format("{0}{1}${2}",
                    Morphfolia.WebControls.FormTemplateControls.DefaultFormTemplatePresenter.FormTemplateFieldID,
                    i.ToString(),
                    Morphfolia.WebControls.FormTemplateControls.FormTemplateFieldControl.txtDataEntryID));
            }

            string xml = Morphfolia.Common.Utilities.XMLHelper.ObjectToXMLString(formTemplate);
            return xml;
        }


        private string ComposeText()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string xmlDefPath = string.Format("{0}Morphfolia\\_publishing\\FormTemplates\\{1}",
                AppDomain.CurrentDomain.BaseDirectory,
                ddlContentEntryFilter.SelectedValue);

            ////FormTemplateField field;
            FormTemplate formTemplate = Morphfolia.Business.FormTemplateHelper.GetDefinitionFromXmlDefinitionFile(xmlDefPath);
            //formTemplate.Name = "NotSureWhereToGetThis";

            for (int i = 0; i < formTemplate.Fields.Count; i++)
            {
                // if its a post back - get the previous values: 
                //FormTemplateField3:FieldText
                //formTemplate.Fields[i].Text = Morphological.Utilities.HttpRequestHelper.GetRequestParamValue(string.Format("FormTemplateField{0}:FieldText", i.ToString()));
                sb.AppendFormat("{0} ", Morphfolia.PublishingSystem.WebUtilities.GetRequestParamValue(string.Format("{0}{1}${2}",
                    Morphfolia.WebControls.FormTemplateControls.DefaultFormTemplatePresenter.FormTemplateFieldID,
                    i.ToString(),
                    Morphfolia.WebControls.FormTemplateControls.FormTemplateFieldControl.txtDataEntryID)) );
            }

            return sb.ToString();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if ((chkbxConfirmDelete1.Checked) | (chkbxConfirmDelete2.Checked))
            {
                ContentItemHelper.DeleteContentItemById(_ContentID);
                CurrentContext.Response.Redirect("../_publishing/content_management.aspx");
            }
        }




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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

}


    internal class FormTemplateHelperThingy
    {
        public static DefaultFormTemplatePresenter CreateDisplayOnlyForm(string templateDefinition)
        {
            //StringBuilder sb = new StringBuilder();
            DefaultFormTemplatePresenter formTemplateControl = new DefaultFormTemplatePresenter();
            formTemplateControl.FormTemplate = Morphfolia.Business.FormTemplateHelper.GetDefinitionAndDataFromXmlDefinition(templateDefinition);
            //formTemplateControl.ShowDataEntryForm = false;

            //for (int i = 0; i < formTemplateControl.FormTemplate.Fields.Count; i++)
            //{
            //    sb.AppendFormat("<p>{0} = {1}</p>",
            //        formTemplateControl.FormTemplate.Fields[i].Name,
            //        formTemplateControl.FormTemplate.Fields[i].Text
            //    );
            //}

            //return sb.ToString();
            return formTemplateControl;
        }

        public static DefaultFormTemplatePresenter CreateUpdateForm(string templateDefinition)
        {
            DefaultFormTemplatePresenter formTemplateControl = new DefaultFormTemplatePresenter();
            formTemplateControl.FormTemplate = Morphfolia.Business.FormTemplateHelper.GetDefinitionAndDataFromXmlDefinition(templateDefinition);
            return formTemplateControl;
        }

        public static DefaultFormTemplatePresenter CreateCleanForm(string templateDefinitionFilePath, bool showFormTemplatesDefaultValues)
        {
            DefaultFormTemplatePresenter formTemplateControl = new DefaultFormTemplatePresenter();
            formTemplateControl.FormTemplate = Morphfolia.Business.FormTemplateHelper.GetDefinitionFromXmlDefinitionFile(templateDefinitionFilePath);
            // wanted to show default values specified in the form - but too hard to 
            // distinguish from entered content.
            //formTemplateControl.ShowValues = showFormTemplatesDefaultValues;
            return formTemplateControl;
        }
    }
}