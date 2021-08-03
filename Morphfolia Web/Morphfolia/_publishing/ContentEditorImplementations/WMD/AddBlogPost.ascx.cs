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
    using Morphfolia.Common;
    using Morphfolia.Common.Logging;
    using Morphfolia.Common.Info;
    using Morphfolia.Common.Types;
    using Morphfolia.WebControls.FormTemplateControls;


	/// <summary>
	///		Summary description for EditContent.
	/// </summary>
	public partial class EditContent : System.Web.UI.UserControl
	{
        public const string ContentIdQueryStringArgumentKey = "c";


        private int TheContentId
        {
            get
            {
                object temp = ViewState["ContentId"];
                if (temp == null)
                {
                    temp = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                }
                return (int)temp;
            }
            set
            {
                ViewState["ContentId"] = value;
            }
        }

        private int theRealSelectedBlogId
        {
            get
            {
                object temp = ViewState["theRealSelectedBlogId"];
                if (temp == null)
                {
                    temp = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                }
                return (int)temp;
            }
            set
            {
                ViewState["theRealSelectedBlogId"] = value;
            }
        }

        private int savedBlogId
        {
            get
            {
                object temp = ViewState["savedBlogId"];
                if (temp == null)
                {
                    temp = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                }
                return (int)temp;
            }
            set
            {
                ViewState["savedBlogId"] = value;
            }
        }

        //private int intTryParse;  // used for int.TryParse() attempts - never used afterwards.
		protected HttpContext CurrentContext = HttpContext.Current;
		protected IPrincipal _CurrentUser;
		protected string _CurrentUsersIdentityName = "?";
		private Morphfolia.Business.ContentItem _ContentItem;
        private string s = string.Empty;

        private string contentEntryFilterHtmlEditorOptionValue = "HtmlEditor";
        public string ContentEntryFilterHtmlEditorOptionValue
        {
            get { return contentEntryFilterHtmlEditorOptionValue; }
        }


		protected void Page_Load(object sender, System.EventArgs e)
		{
            Logger.LogVerboseInformation("EditContent.Page_Load()", string.Format("IsPostBack:{0} IsCallback:{1}", Page.IsPostBack.ToString(), Page.IsCallback.ToString()));

            btnSave1.Attributes.Add("onMouseOver", "PopulateTextContent();");
            btnSave2.Attributes.Add("onMouseOver", "PopulateTextContent();");
            //btnSaveAsNew1.Attributes.Add("onMouseOver", "PopulateTextContent();");
            //btnSaveAsNew2.Attributes.Add("onMouseOver", "PopulateTextContent();");
            btnSaveNExit1.Attributes.Add("onMouseOver", "PopulateTextContent();");
            btnSaveNExit2.Attributes.Add("onMouseOver", "PopulateTextContent();");
            txtTextContent.Style.Add("display", "none");
            txtEditor_MarkDown.Attributes.Add("onChange", "PopulateTextContent();");
            txtTextContentID.Text = txtTextContent.ClientID;

            _CurrentUser = HttpContext.Current.User;
            _CurrentUsersIdentityName = _CurrentUser.Identity.Name;
            _CurrentUsersIdentityName = _CurrentUsersIdentityName.Substring(_CurrentUsersIdentityName.IndexOf("|") + 1);
            
            if (!IsPostBack)
            {
                if (TheContentId == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                {
                    if (Request[ContentIdQueryStringArgumentKey] != null)
                    {
                        int tryParseOutput;
                        if (int.TryParse(Request[ContentIdQueryStringArgumentKey].ToString(), out tryParseOutput))
                        {
                            TheContentId = tryParseOutput;
                        }
                    }
                }

                if (TheContentId != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                {
                    PopulateUIWithExistingValues(TheContentId);
                }

                chkbxIsLive.Checked = true;
                chkbxIsSearchable.Checked = true;

                PopulateListOfAvailableBlogs();

                if (theRealSelectedBlogId != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                {
                    ddlBlog.SelectedValue = theRealSelectedBlogId.ToString();                    
                    Logger.LogVerboseInformation("EditContent.ddlBlog.SelectedValue() [95]SET ", ddlBlog.Items[0].Value);
                }               
            }
		}



        /// <summary>
        /// Populates the dropdownlist of available blogs (pages 
        /// that use an IsBlog decorated BasePageLayout).
        /// </summary>
        private void PopulateListOfAvailableBlogs()
        {
            Logger.LogVerboseInformation("EditContent.PopulateListOfAvailableBlogs()", "Invoked");

            PageInfoCollection blogs = Business.Blogging.BloggingUtilities.GetListOfAvailableBlogs();
            if (blogs.Count == 0)
            {
                btnSave1.Enabled = false;
                btnSave2.Enabled = false;
                btnSaveNExit1.Enabled = false;
                btnSaveNExit2.Enabled = false;
                lblBlogListMsg.Text = "No blogs are currently set-up.  To create a new blog: add a new page but use the BlogPageLayout and set the layout properties as required.";
                lblBlogListMsg.Visible = true;
            }
            else
            {
                btnSave1.Enabled = true;
                btnSave2.Enabled = true;
                btnSaveNExit1.Enabled = true;
                btnSaveNExit2.Enabled = true;
                lblBlogListMsg.Visible = false;

                if (ddlBlog.Items.Count == 0)
                {
                    if (!Page.IsPostBack)
                    {
                        ddlBlog.Items.Add(new ListItem("Please Select a Blog", Common.Constants.SystemTypeValues.NullInt.ToString()));
                    }

                    foreach (PageInfo blog in blogs)
                    {
                        ddlBlog.Items.Add(new ListItem(blog.Title, blog.PageID.ToString()));
                    }
                }
            }

            Logger.LogVerboseInformation("EditContent.PopulateListOfAvailableBlogs()", "Invoked");
        }


        private void PopulateUIWithExistingValues(int contentId)
        {
            Logger.LogVerboseInformation("EditContent.PopulateUIWithExistingValues()", "Invoked");

            if (contentId > Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                _ContentItem = ContentItemHelper.GetContentItemById(contentId);

                litContentID.Text = _ContentItem.ContentID.ToString();
                txtNote.Text = _ContentItem.Note;
                //HTMLEditor1.Html = _ContentItem.Content;
                txtEditor_MarkDown.Text = StaticCustomPropertyHelper.GetCustomPropertyInstanceByInstanceID(contentId, "MarkDownContent");

                chkbxIsSearchable.Checked = _ContentItem.IsSearchable;
                chkbxIsLive.Checked = _ContentItem.IsLive;
                chkbxCreateOwnPage.Visible = false;

                CustomPropertyInstanceInfoCollection poss = StaticCustomPropertyHelper.GetControlPropertiesByPropertyType(ControlPropertyTypeFactory.BlogPostLinkPropertyType(), contentId.ToString());
                if (poss.Count > 0)
                {
                    // In theory there should only be one item returned, we'll be defensive and 
                    // use the 'last' item just in case there are more (assuming the last is
                    // the most recent).
                    theRealSelectedBlogId = poss[poss.Count-1].InstanceID;
                }
                else
                {
                    // Wooops - should never get in here.
                    Logger.LogInformation("Could not get the Blog Id", string.Format("Content (post) Id: {0}", contentId.ToString()));
                    theRealSelectedBlogId = Common.Constants.SystemTypeValues.NullInt;
                    Logger.LogVerboseInformation("EditContent.theRealSelectedBlogId() [196]SET ", "null int");
                }


                PopulateTagUI();


                CustomPropertyInstanceInfoCollection currentlySavedTags = StaticCustomPropertyHelper.GetControlPropertiesByInstanceIDAndPropertyKey(contentId, Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CTAG);

                foreach (ListItem i in lstTagsTaxonomyInput.Items)
                {
                    i.Selected = false;
                }
                    
                for(int t = 0; t < currentlySavedTags.Count; t++)
                {
                    foreach (ListItem i in lstTagsTaxonomyInput.Items)
                    {
                        //if (t < (currentlySavedTags.Count - 1))
                        //{
                        //    Logger.LogWarning("t is too low.", string.Format("t={0}, i={1}", t.ToString(), i.Text));
                        //}
                        //else
                        //{
                        if (i.Text.Equals(currentlySavedTags[t].PropertyValue, StringComparison.InvariantCultureIgnoreCase))
                        {
                            i.Selected = true;
                            currentlySavedTags.RemoveAt(t);
                            t--;
                            break;
                        }
                        //}
                    }
                }
                
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int t = 0; t < currentlySavedTags.Count; t++)
                {
                    sb.AppendFormat("{0}{1}", currentlySavedTags[t].PropertyValue, Environment.NewLine);
                }
                txtTagsFolksonomyInput.Text = sb.ToString();
            }
            else
            {
                ToggleContentEntryFilterUI(false);
                chkbxCreateOwnPage.Visible = true;
            }

            Logger.LogVerboseInformation("EditContent.PopulateUIWithExistingValues()", "Complete");
        }





        /// <summary>
        /// Shows the appropriate UI for Tag entry, based on the parent blog/page.
        /// </summary>
        /// <remarks>If the parent does not have any tags defined a free-text input will be 
        /// displayed, otherwise a checkbox list.</remarks>
        private void PopulateTagUI()
        {
            Logger.LogVerboseInformation("EditContent.PopulateTagUI()", "Invoked.");

            if (RawPredefinedTaxonomyTags.Equals(string.Empty))
            {
                lstTagsTaxonomyInput.Visible = false;
            }
            else
            {
                lstTagsTaxonomyInput.Visible = true;
                if (lstTagsTaxonomyInput.Items.Count == 0)
                {
                    StringCollection tags = ParseFreeText(RawPredefinedTaxonomyTags);
                    for (int i = 0; i < tags.Count; i++)
                    {
                        lstTagsTaxonomyInput.Items.Add(new ListItem(tags[i], tags[i]));
                    }
                }
            }

            Logger.LogVerboseInformation("EditContent.PopulateTagUI()", "Completed.");
        }


        protected void ToggleContentEntryFilterUI(bool showFormTemplate)
        {
            //if (showFormTemplate)
            //{
            //    pnlFormTemplateContainer.Style.Add("display", "inline");
            //    HTMLEditor1.Style.Add("display", "none");
            //}
            //else
            //{
            //    pnlFormTemplateContainer.Style.Add("display", "none");
            //    HTMLEditor1.Style.Add("display", "inline");
            //}
        }


        protected void ddlContentEntryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateUIWithExistingValues(TheContentId);
        }


        private string rawPredefinedTaxonomyTags = null;
        /// <summary>
        /// Returns a simple taxonomy of tags defined at the parent page 
        /// level - if they exist/have been defined.
        /// </summary>
        protected string RawPredefinedTaxonomyTags
        {
            get
            {
                if (rawPredefinedTaxonomyTags == null)
                {
                    rawPredefinedTaxonomyTags = StaticCustomPropertyHelper.GetCustomPropertyInstanceByInstanceID(theRealSelectedBlogId, "Tags");
                }
                return rawPredefinedTaxonomyTags;
            }
        }


        /// <summary>
        /// Triggers reconstruction of the Tag input UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBlog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBlog.SelectedValue != null)
            {
                int r2;
                if (int.TryParse(ddlBlog.SelectedValue, out r2))
                {
                    theRealSelectedBlogId = r2;
                    Logger.LogVerboseInformation("EditContent.theRealSelectedBlogId() [331]SET ", r2.ToString());
                }
            }
            
            rawPredefinedTaxonomyTags = null;
            lstTagsTaxonomyInput.Items.Clear();
            PopulateTagUI();
        }

        /// <summary>
        /// Parses a string of raw text as Tags, and returns the tags in a structured format.
        /// </summary>
        /// <param name="rawText"></param>
        /// <returns></returns>
        private StringCollection ParseFreeText(string rawText)
        {
            string[] possibleSplitChars = new string[5] { ";", ":", "~", ">", "^" };
            string tagSplitter = ";";
            string temp = rawText.Trim();
            StringCollection output = new StringCollection();

            foreach (string psc in possibleSplitChars)
            {
                if (temp.IndexOf(psc) == -1)
                {
                    tagSplitter = psc;
                    break;
                }
            }
            temp = temp.Replace(Environment.NewLine, tagSplitter);
            string[] tags = temp.Split(char.Parse(tagSplitter));
            for (int i = 0; i < tags.Length; i++)
            {
                output.Add(tags[i]);
            }

            return output;
        }


		protected void btnSave_Click(object sender, System.EventArgs e)
		{
            TheContentId = Save();
        }

        protected void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            this.TheContentId = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
            int contentId = Save();
            //CurrentContext.Response.Redirect(string.Format("edit_content.aspx?c={0}", contentId.ToString()));
        }

		protected void btnSaveNExit_Click(object sender, System.EventArgs e)
		{
            TheContentId = Save();
			CurrentContext.Response.Redirect("../_publishing/content_management.aspx");
		}

		private int Save()
		{
            EnsureChildControls();

            Logger.LogVerboseInformation("EditContent.Save()", "Invoked");

			// if this._ContentID = -1, save a new instance.
            int outputContentId;

            if (TheContentId == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
			{				
                Morphfolia.Business.ContentItem contentItem = new Morphfolia.Business.ContentItem();

                contentItem.ContentType = Common.ContentTypes.BlogPost;

				contentItem.Note = txtNote.Text.Trim();
                //contentItem.Content = HTMLEditor1.Html;
                //contentItem.TextContent = HTMLEditor1.Text.Trim();
                contentItem.Content = txtEditor_HTML.Text;
                contentItem.TextContent = txtTextContent.Text;
				contentItem.IsLive = chkbxIsLive.Checked;
				contentItem.IsSearchable = chkbxIsSearchable.Checked;
                contentItem.LastModifiedBy = _CurrentUsersIdentityName;
                outputContentId = ContentItemHelper.Save(contentItem);

                savedBlogId = int.Parse(ddlBlog.SelectedValue);

                SaveNewCustomPropertyInstanceInfo markAsBlogPost = new SaveNewCustomPropertyInstanceInfo(
                    int.Parse(ddlBlog.SelectedValue),
                    Morphfolia.Common.ControlPropertyTypeFactory.BlogPostLinkPropertyType(),
                    "BlogPost",
                    outputContentId.ToString());
                StaticCustomPropertyHelper.SaveControlPropertyByInstance(markAsBlogPost);

                SaveTags(outputContentId);


                // Save Markdown seperately via the custom properties.
                SaveNewCustomPropertyInstanceInfo info = new SaveNewCustomPropertyInstanceInfo(
                    savedBlogId, Common.ControlPropertyTypeFactory.MarkDownContentPropertyType(), "MarkDownContent", txtEditor_MarkDown.Text);
                StaticCustomPropertyHelper.SaveControlPropertyByInstance(info);

//                Morphfolia.Common.ControlPropertyTypeFactory.


            }
			else
			{
                ContentItem contentItem = ContentItemHelper.GetContentItemById(TheContentId);
				contentItem.Note = txtNote.Text;
                //contentItem.Content = HTMLEditor1.Html;
                //contentItem.TextContent = HTMLEditor1.Text;
                contentItem.Content = txtEditor_HTML.Text;
                contentItem.TextContent = txtTextContent.Text;
				contentItem.IsLive = chkbxIsLive.Checked;
				contentItem.IsSearchable = chkbxIsSearchable.Checked;
                contentItem.LastModifiedBy = _CurrentUsersIdentityName;
                outputContentId = ContentItemHelper.Save(contentItem);

                StaticCustomPropertyHelper.DeleteControlPropertiesByInstanceAndPropertyType(TheContentId, Morphfolia.Common.ControlPropertyTypeFactory.ContentTagPropertyType().PropertyTypeIdentifier);

                StaticCustomPropertyHelper.DeleteControlPropertiesByPropertyTypeAndPropertyValue(Morphfolia.Common.ControlPropertyTypeFactory.BlogPostLinkPropertyType().PropertyTypeIdentifier, TheContentId.ToString());

                savedBlogId = int.Parse(ddlBlog.SelectedValue);

                SaveNewCustomPropertyInstanceInfo markAsBlogPost = new SaveNewCustomPropertyInstanceInfo(
                    int.Parse(ddlBlog.SelectedValue),
                    Morphfolia.Common.ControlPropertyTypeFactory.BlogPostLinkPropertyType(),
                    "BlogPost",
                    outputContentId.ToString());
                StaticCustomPropertyHelper.SaveControlPropertyByInstance(markAsBlogPost);

                SaveTags(TheContentId);


                // Save Markdown seperately via the custom properties.
                StaticCustomPropertyHelper.DeleteControlPropertiesByInstanceAndPropertyType(outputContentId, Common.ControlPropertyTypeFactory.MarkDownContentPropertyType().PropertyTypeIdentifier);

                SaveNewCustomPropertyInstanceInfo info = new SaveNewCustomPropertyInstanceInfo(
                    savedBlogId, Common.ControlPropertyTypeFactory.MarkDownContentPropertyType(), "MarkDownContent", txtEditor_MarkDown.Text);
                StaticCustomPropertyHelper.SaveControlPropertyByInstance(info);
			}

            Logger.LogVerboseInformation("EditContent.Save()", "Complete");

            return outputContentId;
		}


        /// <summary>
        /// Works for both new and existing pages.
        /// </summary>
        /// <remarks>Covers basic saving operations only - not 
        /// deleting old values when 'updateding' existing).</remarks>
        private void SaveTags(int contentId)
        {
            // Save selected pre-defined tags - if any: 
            foreach (ListItem o in lstTagsTaxonomyInput.Items)
            {
                if (o.Selected)
                {
                    SaveNewCustomPropertyInstanceInfo cTag = new SaveNewCustomPropertyInstanceInfo(
                        contentId,
                        Morphfolia.Common.ControlPropertyTypeFactory.ContentTagPropertyType(),
                        "CTAG",
                        o.Text);

                    StaticCustomPropertyHelper.SaveControlPropertyByInstance(cTag);
                }
            }

            // Save any ad-hoc defined tags - if any;
            string currentTag = string.Empty;
            StringCollection tags = ParseFreeText(txtTagsFolksonomyInput.Text);
            for (int i = 0; i < tags.Count; i++)
            {
                currentTag = tags[i].ToString().Trim();

                if (!currentTag.Equals(string.Empty))
                {
                    SaveNewCustomPropertyInstanceInfo cTag = new SaveNewCustomPropertyInstanceInfo(
                        contentId,
                        Morphfolia.Common.ControlPropertyTypeFactory.ContentTagPropertyType(),
                        "CTAG",
                        currentTag);

                    StaticCustomPropertyHelper.SaveControlPropertyByInstance(cTag);
                }
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
}