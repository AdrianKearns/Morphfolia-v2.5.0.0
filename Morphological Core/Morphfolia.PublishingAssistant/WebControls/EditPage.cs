// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.ComponentModel;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class EditPage : WebControl, INamingContainer
    {
        public const string PageIdQueryStringArgumentKey = "p";

        private int _PageID = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
        private Morphfolia.Business.Page _Page;
        protected HttpContext CurrentContext = HttpContext.Current;
        private Table tblEditPage;
        private TableRow tr;
        private TableCell td;
        private Literal space;
        private Literal br;
        protected TableCell tdPageId;
        protected TextBox txtTitle;
        protected TextBox txtUrl;
        protected HyperLink hypViewPage;
        protected Panel divExistingURLs;
        protected TextBox txtKeywords;
        protected TextBox txtDescription;
        protected CheckBox chxIsLive;
        protected CheckBox chxIsSearchable;
        protected HtmlButton btnIndexPage;
        protected Literal litIndexingWindow;
        protected PageLayoutSelector pageLayoutSelector;
        protected AssignContentToPage assignContentToPage;

        protected Button btnSave;
        protected Button btnSave2;
        protected Button btnSaveAndExit;
        protected Button btnSaveAndExit2;
        protected Button btnSaveAsNew;
        protected Button btnSaveAsNew2;
        protected Button btnDeletePage;
        protected Button btnDeletePage2;
        protected CheckBox chkbxConfirmDelete;
        protected CheckBox chkbxConfirmDelete2;

        protected SkinSelector skinSelector;
        protected Panel pnlCustomPropertiesForLayout;
        protected Panel pnlCustomPropertiesForSkin;

        protected IPrincipal _CurrentUser;
        protected string _CurrentUsersIdentityName = "?";
        bool pageLayoutSelector_LayoutSelected_HasBeenFired = false;

        private string _selectedLayoutWebControlType = string.Empty;
        public string SelectedLayoutWebControlType
        {
            get 
			{
                string v = (String)ViewState["SelectedLayoutWebControlType"];
                if (v == null)
                {
                    v = string.Empty;
                }
                return v;
			}
			set 
			{
				string v = value;
                ViewState["SelectedLayoutWebControlType"] = v;
			}
        }

        private string _selectedSkinProvider = string.Empty;
        public string SelectedSkinProvider
        {
            get
            {
                string v = (String)ViewState["SelectedSkinProvider"];
                if (v == null)
                {
                    v = string.Empty;
                }
                return v;
            }
            set
            {
                string v = value;
                ViewState["SelectedSkinProvider"] = v;
            }
        }



        public EditPage()
        {
            _CurrentUser = HttpContext.Current.User;
            _CurrentUsersIdentityName = _CurrentUser.Identity.Name;
            _CurrentUsersIdentityName = _CurrentUsersIdentityName.Substring(_CurrentUsersIdentityName.IndexOf("|") + 1);

            //----------------------------------------------------------------------
            // Get the Page ID: 
            //----------------------------------------------------------------------
            if (CurrentContext.Request.QueryString[PageIdQueryStringArgumentKey] != null)
            {
                if (CurrentContext.Request.QueryString[PageIdQueryStringArgumentKey].ToString() != "")
                {
                    try
                    {
                        _PageID = int.Parse(CurrentContext.Request.QueryString[PageIdQueryStringArgumentKey].ToString());
                    }
                    catch
                    {
                        _PageID = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
                    }
                }
            }
        }


        private void LoadActions()
        {
            Logging.Logger.LogVerboseInformation("EditPage LoadActions()", "Invoked.");

            btnIndexPage.Visible = false;
            hypViewPage.Visible = false;
            btnSaveAsNew.Visible = false;
            btnSaveAsNew2.Visible = false;
            chkbxConfirmDelete.Visible = false;
            chkbxConfirmDelete2.Visible = false;
            btnDeletePage.Visible = false;
            btnDeletePage2.Visible = false;

            //----------------------------------------------------------------------
			// If it's an existing page - populate the form with the page data:
			//----------------------------------------------------------------------
            if (_PageID > 0)
            {
                string currentLayout = StaticCustomPropertyHelper.GetLayoutWebControlTypeByInstanceID(_PageID);
                pageLayoutSelector.SetSelectedLayout(currentLayout);

                string currentSkinProvider = StaticCustomPropertyHelper.GetSkinProviderTypeByInstanceID(_PageID);
                skinSelector.SetSelectedSkin(currentSkinProvider);

                _Page = Morphfolia.Business.PageFactory.Page(_PageID);
                EditPageHelper.FillCustomPropertiesPanelForSelectedType(pnlCustomPropertiesForLayout, currentLayout, _PageID, true);
                EditPageHelper.FillCustomPropertiesPanelForSelectedType(pnlCustomPropertiesForSkin, currentSkinProvider, _PageID, true);

                hypViewPage.NavigateUrl = string.Format("{0}/{1}", Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot(), this._Page.Url);
                hypViewPage.Visible = true;
                btnIndexPage.Visible = true;
                btnSaveAsNew.Visible = true;
                btnSaveAsNew2.Visible = true;
                chkbxConfirmDelete.Visible = true;
                chkbxConfirmDelete2.Visible = true;
                btnDeletePage.Visible = true;
                btnDeletePage2.Visible = true;

                if (!base.Page.IsPostBack)
                {
                    txtTitle.Text = this._Page.Title;
                    txtUrl.Text = this._Page.Url;
                    txtKeywords.Text = this._Page.Keywords;
                    txtDescription.Text = this._Page.Description;
                    chxIsSearchable.Checked = this._Page.IsSearchable;
                    chxIsLive.Checked = this._Page.IsLive;
                }
            }
            else
            {
                SelectedLayoutWebControlType = pageLayoutSelector.GetSelectedLayout();
                EditPageHelper.FillCustomPropertiesPanelForSelectedType(pnlCustomPropertiesForLayout, SelectedLayoutWebControlType, _PageID, false);

                SelectedSkinProvider = skinSelector.GetSelectedSkin();
                EditPageHelper.FillCustomPropertiesPanelForSelectedType(pnlCustomPropertiesForSkin, SelectedSkinProvider, _PageID, false);
            }

            Logging.Logger.LogVerboseInformation("EditPage LoadActions()", "Complete.");
        }


        protected override void CreateChildControls()
        {
            Logging.Logger.LogVerboseInformation("EditPage CreateChildControls()", "Invoked.");

            tblEditPage = new Table();
            Controls.Add(tblEditPage);
            tblEditPage.ID = "tblEditPage";
            tblEditPage.CellPadding = 5;
            tblEditPage.CellSpacing = 0;
            //tblEditPage.Attributes.Add("border", "1");
            //tblEditPage.Width = Unit.Percentage(100);
            tblEditPage.CssClass = "FunctionalArea";


            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "ID";
            td.Width = Unit.Pixel(120);

            tdPageId = new TableCell();
            tr.Cells.Add(tdPageId);
            tdPageId.ID = "tdPageId";
            if (_PageID > Common.Constants.SystemTypeValues.NullInt)
            {
                tdPageId.Text = _PageID.ToString();
            }



            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Title";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            txtTitle = new TextBox();
            Controls.Add(txtTitle);
            td.Controls.Add(txtTitle);
            txtTitle.Columns = 64;
            txtTitle.MaxLength = 500;
            txtTitle.ID = "txtTitle";





            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "URL";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            txtUrl = new TextBox();
            Controls.Add(txtUrl);
            td.Controls.Add(txtUrl);
            txtUrl.Columns = 64;
            txtUrl.MaxLength = 1000;
            txtUrl.ID = "txtUrl";

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " &nbsp; ";

            hypViewPage = new HyperLink();
            Controls.Add(hypViewPage);
            td.Controls.Add(hypViewPage);
            hypViewPage.Text = "View Page";
            hypViewPage.Visible = false;
            hypViewPage.ID = "hypViewPage";

            br = new Literal();
            Controls.Add(br);
            td.Controls.Add(br);
            br.Text = "<br>";

            divExistingURLs = new Panel();
            Controls.Add(divExistingURLs);
            td.Controls.Add(divExistingURLs);
            divExistingURLs.ID = "divExistingURLs";
            divExistingURLs.Style.Add("border", "solid 1px #cccccc;");
            divExistingURLs.Style.Add("visibility", "hidden");
            divExistingURLs.Style.Add("overflow-y", "scroll");
            divExistingURLs.Style.Add("position", "absolute");
            divExistingURLs.Style.Add("width", "500px");
            divExistingURLs.Style.Add("height", "200px");
            divExistingURLs.Style.Add("background-color", "#fefefe");

            txtUrl.Attributes.Add("onkeyup", string.Format("CheckURLCriteria(this, '{0}')", divExistingURLs.ClientID));



            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Keywords";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            txtKeywords = new TextBox();
            Controls.Add(txtKeywords);
            td.Controls.Add(txtKeywords);
            txtKeywords.TextMode = TextBoxMode.MultiLine;
            txtKeywords.Rows = 3;
            txtKeywords.Columns = 50;
            txtKeywords.MaxLength = 2000;
            txtKeywords.ID = "txtKeywords";






            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Description";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            txtDescription = new TextBox();
            Controls.Add(txtDescription);
            td.Controls.Add(txtDescription);
            txtDescription.TextMode = TextBoxMode.MultiLine;
            txtDescription.Rows = 4;
            txtDescription.Columns = 50;
            txtDescription.MaxLength = 2000;
            txtDescription.ID = "txtDescription";




            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Is Searchable?";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            chxIsSearchable = new CheckBox();
            Controls.Add(chxIsSearchable);
            td.Controls.Add(chxIsSearchable);
            chxIsSearchable.Text = "(Only searchable pages appear in the Site Map)";
            chxIsSearchable.ID = "chxIsSearchable";

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " &nbsp; ";

            btnIndexPage = new HtmlButton();
            Controls.Add(btnIndexPage);
            td.Controls.Add(btnIndexPage);
            btnIndexPage.InnerText = "Index Page";
            btnIndexPage.ID = "btnIndexPage";

            litIndexingWindow = new Literal();
            Controls.Add(litIndexingWindow);
            td.Controls.Add(litIndexingWindow);
            litIndexingWindow.Text = "<div id='indexProgressWindowContainer' style='display: none; padding: 0px; border: solid 1px #000000; width: 543px; height: 200px;'><iframe id='indexProgressWindow' style='width: 100%; height: 100%;' frameborder='0'></iframe></div>";



            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Is Live?";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            chxIsLive = new CheckBox();
            Controls.Add(chxIsLive);
            td.Controls.Add(chxIsLive);
            chxIsLive.Text = "(Only live pages can be viewed)";
            chxIsLive.ID = "chxIsLive";





            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "&nbsp;";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            btnSave = new Button();
            Controls.Add(btnSave);
            td.Controls.Add(btnSave);
            btnSave.Text = "Save";
            btnSave.ID = "btnSave";
            btnSave.Click += new EventHandler(btnSave_Click);

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " ";

            btnSaveAndExit = new Button();
            Controls.Add(btnSaveAndExit);
            td.Controls.Add(btnSaveAndExit);
            btnSaveAndExit.Text = "Save and Exit";
            btnSaveAndExit.ID = "btnSaveAndExit";
            btnSaveAndExit.Click += new EventHandler(btnSaveAndExit_Click);

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " ";

            btnSaveAsNew = new Button();
            Controls.Add(btnSaveAsNew);
            td.Controls.Add(btnSaveAsNew);
            btnSaveAsNew.Text = "Save As New";
            btnSaveAsNew.ID = "btnSaveAsNew";
            btnSaveAsNew.Click += new EventHandler(btnSaveAsNew_Click);

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " &nbsp; &nbsp; ";

            btnDeletePage = new Button();
            Controls.Add(btnDeletePage);
            td.Controls.Add(btnDeletePage);
            btnDeletePage.Text = "Delete";
            btnDeletePage.ID = "btnDeletePage";
            btnDeletePage.Click += new EventHandler(btnDeletePage_Click);

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " ";

            chkbxConfirmDelete = new CheckBox();
            Controls.Add(chkbxConfirmDelete);
            td.Controls.Add(chkbxConfirmDelete);
            chkbxConfirmDelete.Text = "Confirm Delete";
            chkbxConfirmDelete.ID = "chkbxConfirmDelete";




            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Layout";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            pageLayoutSelector = new PageLayoutSelector();
            Controls.Add(pageLayoutSelector);
            td.Controls.Add(pageLayoutSelector);
            pageLayoutSelector.LayoutSelected += new PageLayoutSelector.OnLayoutSelected(pageLayoutSelector_LayoutSelected);
            pageLayoutSelector.ID = "pageLayoutSelector";



            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Content";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            assignContentToPage = new AssignContentToPage();
            Controls.Add(assignContentToPage);
            td.Controls.Add(assignContentToPage);
            assignContentToPage.ID = "assignContentToPage";



            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Layout Properties";
            td.VerticalAlign = VerticalAlign.Top;

            //td = new TableCell();
            //tr.Cells.Add(td);
            //customPropertyList = new CustomPropertyList();
            //Controls.Add(customPropertyList);
            //td.Controls.Add(customPropertyList);
            //customPropertyList.ID = "customPropertyList";

            td = new TableCell();
            tr.Cells.Add(td);
            pnlCustomPropertiesForLayout = new Panel();
            Controls.Add(pnlCustomPropertiesForLayout);
            td.Controls.Add(pnlCustomPropertiesForLayout);
            pnlCustomPropertiesForLayout.ID = "pnlProperties";
            pnlCustomPropertiesForLayout.EnableViewState = true;





            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Skin";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            skinSelector = new SkinSelector();
            Controls.Add(skinSelector);
            td.Controls.Add(skinSelector);
            skinSelector.SkinSelected += new SkinSelector.OnSkinSelected(skinSelector_SkinSelected);
            skinSelector.ID = "skinSelector";



            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Skin Properties";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            pnlCustomPropertiesForSkin = new Panel();
            Controls.Add(pnlCustomPropertiesForSkin);
            td.Controls.Add(pnlCustomPropertiesForSkin);
            pnlCustomPropertiesForSkin.ID = "pnlCustomPropertiesForSkin";
            pnlCustomPropertiesForSkin.EnableViewState = true;







            tr = new TableRow();
            tblEditPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "&nbsp;";
            td.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            tr.Cells.Add(td);
            btnSave2 = new Button();
            Controls.Add(btnSave2);
            td.Controls.Add(btnSave2);
            btnSave2.Text = "Save";
            btnSave2.ID = "btnSave2";
            btnSave2.Click += new EventHandler(btnSave_Click);

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " ";

            btnSaveAndExit2 = new Button();
            Controls.Add(btnSaveAndExit2);
            td.Controls.Add(btnSaveAndExit2);
            btnSaveAndExit2.Text = "Save and Exit";
            btnSaveAndExit2.ID = "btnSaveAndExit2";
            btnSaveAndExit2.Click += new EventHandler(btnSaveAndExit_Click);

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " ";

            btnSaveAsNew2 = new Button();
            Controls.Add(btnSaveAsNew2);
            td.Controls.Add(btnSaveAsNew2);
            btnSaveAsNew2.Text = "Save As New";
            btnSaveAsNew2.ID = "btnSaveAsNew2";
            btnSaveAsNew2.Click += new EventHandler(btnSaveAsNew_Click);

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " &nbsp; &nbsp; ";

            btnDeletePage2 = new Button();
            Controls.Add(btnDeletePage2);
            td.Controls.Add(btnDeletePage2);
            btnDeletePage2.Text = "Delete";
            btnDeletePage2.ID = "btnDeletePage2";
            btnDeletePage2.Click += new EventHandler(btnDeletePage2_Click);

            space = new Literal();
            Controls.Add(space);
            td.Controls.Add(space);
            space.Text = " ";

            chkbxConfirmDelete2 = new CheckBox();
            Controls.Add(chkbxConfirmDelete2);
            td.Controls.Add(chkbxConfirmDelete2);
            chkbxConfirmDelete2.Text = "Confirm Delete";
            chkbxConfirmDelete2.ID = "chkbxConfirmDelete2";


            LoadActions();


            Logging.Logger.LogVerboseInformation("EditPage CreateChildControls()", "Complete.");
        }


        void btnSave_Click(object sender, EventArgs e)
        {
            _PageID = Save();
            if (CurrentContext.Request.Url.AbsoluteUri.Contains("?"))
            {
                CurrentContext.Response.Redirect(CurrentContext.Request.Url.AbsoluteUri);
            }
            else
            {
                CurrentContext.Response.Redirect(string.Format("{0}?{1}={2}", CurrentContext.Request.Url.AbsoluteUri, PageIdQueryStringArgumentKey, _PageID));
            }
        }

        void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            this._PageID = -1;
            _PageID = Save();

            string destinationUrl = CurrentContext.Request.Url.AbsoluteUri;
            destinationUrl = destinationUrl.Remove(destinationUrl.IndexOf("?"));
            CurrentContext.Response.Redirect(string.Format("{0}?{1}={2}", destinationUrl, PageIdQueryStringArgumentKey, _PageID));
        }

        void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            Save();
            CurrentContext.Response.Redirect("../_publishing");
        }

        void btnDeletePage_Click(object sender, EventArgs e)
        {
            if (chkbxConfirmDelete.Checked)
            {
                DeletePage();
                CurrentContext.Response.Redirect("../_publishing");
            }
        }

        void btnDeletePage2_Click(object sender, EventArgs e)
        {
            if (chkbxConfirmDelete2.Checked)
            {
                DeletePage();
                CurrentContext.Response.Redirect("../_publishing");
            }
        }


        private void pageLayoutSelector_LayoutSelected(string selectedLayoutType)
        {
            Logging.Logger.LogVerboseInformation("EditPage pageLayoutSelector_LayoutSelected()", "Invoked.");

            SelectedLayoutWebControlType = selectedLayoutType;

            if (!SelectedLayoutWebControlType.Equals(string.Empty))
            {
                //EditPageHelper.FillContentContainerDropBoxesPanel(pnlContentContainerDropBoxes, SelectedLayoutWebControlType);
                //EditPageHelper.FillContentContainerDropBoxesPanel(pnlContentContainerDropBoxes, SelectedLayoutWebControlType);
                assignContentToPage.PageId = _PageID;
                assignContentToPage.FillContentContainerDropBoxesPanel(SelectedLayoutWebControlType);
                pageLayoutSelector_LayoutSelected_HasBeenFired = true;

                EditPageHelper.FillCustomPropertiesPanelForSelectedType(pnlCustomPropertiesForLayout, SelectedLayoutWebControlType, _PageID, true);
            }

            Logging.Logger.LogVerboseInformation("EditPage pageLayoutSelector_LayoutSelected()", "Complete.");
        }

        private void skinSelector_SkinSelected(string selectedSkinType)
        {
            Logging.Logger.LogVerboseInformation("EditPage skinSelector_SkinSelected()", "Invoked.");

            SelectedSkinProvider = selectedSkinType;

            if (!SelectedSkinProvider.Equals(string.Empty))
            {
                //EditPageHelper.FillContentContainerDropBoxesPanel(pnlContentContainerDropBoxes, SelectedLayoutWebControlType);
                //EditPageHelper.FillContentContainerDropBoxesPanel(pnlContentContainerDropBoxes, SelectedLayoutWebControlType);
                //pageLayoutSelector_LayoutSelected_HasBeenFired = true;
                EditPageHelper.FillCustomPropertiesPanelForSelectedType(pnlCustomPropertiesForSkin, SelectedSkinProvider, _PageID, true);
            }

            Logging.Logger.LogVerboseInformation("EditPage skinSelector_SkinSelected()", "Complete.");
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            Logging.Logger.LogVerboseInformation("EditPage RenderContents()", "Invoked.");

            //Logging.Logger.LogVerboseInformation("EditPage.RenderContents()", string.Format("pageLayoutSelector_LayoutSelected_HasBeenFired = [{0}]", pageLayoutSelector_LayoutSelected_HasBeenFired.ToString()));
            //Logging.Logger.LogVerboseInformation("EditPage.RenderContents()", string.Format("SelectedLayoutWebControlType = [{0}]", SelectedLayoutWebControlType));

            btnIndexPage.Attributes.Add("onClick", string.Format("indexPage( {0} ); return false;", _PageID.ToString()));


            if (!pageLayoutSelector_LayoutSelected_HasBeenFired)
            {
                if (!SelectedLayoutWebControlType.Equals(string.Empty))
                {
                    //Logging.Logger.LogVerboseInformation("EditPage.RenderContents()", "assignContentToPage.FillContentContainerDropBoxesPanel() called in RenderContents()");
                    assignContentToPage.PageId = _PageID;
                    assignContentToPage.FillContentContainerDropBoxesPanel(SelectedLayoutWebControlType);
                }
            }

            EditPageHelper.PopulateCustomPropertiesWithPreviouslySavedData(pnlCustomPropertiesForLayout, _PageID);
            EditPageHelper.PopulateCustomPropertiesWithPreviouslySavedData(pnlCustomPropertiesForSkin, _PageID);

            base.RenderContents(writer);

            Logging.Logger.LogVerboseInformation("EditPage RenderContents()", "Complete.");
        }


        /// <summary>
        /// Physically saves the data.
        /// </summary>
        /// <returns>int - the PageID</returns>
        private int Save()
        {
            Logging.Logger.LogInformation("EditPage Save()", "Invoked.");

            int pageId = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
            Morphfolia.Business.Page page;

            StaticCustomPropertyHelper controlPropertyHelper = new StaticCustomPropertyHelper();

            if (this._PageID == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                page = Morphfolia.Business.PageFactory.SaveNewPage(
                    this._CurrentUsersIdentityName,
                    txtTitle.Text.Trim(),
                    txtUrl.Text.Trim(),
                    txtKeywords.Text.Trim(),
                    txtDescription.Text.Trim(),
                    chxIsLive.Checked,
                    chxIsSearchable.Checked
                    );

                pageId = page.PageID;
                tdPageId.Text = page.PageID.ToString();
            }
            else
            {
                page = Morphfolia.Business.PageFactory.Page(_PageID);
                pageId = _PageID;
                tdPageId.Text = page.PageID.ToString();

                // Update the properties exposed for editing: 
                page.Title = txtTitle.Text.Trim();
                page.Url = txtUrl.Text.Trim();
                page.Keywords = txtKeywords.Text.Trim();
                page.Description = txtDescription.Text.Trim();
                page.IsSearchable = chxIsSearchable.Checked;
                page.IsLive = chxIsLive.Checked;


                StaticCustomPropertyHelper.DeleteControlPropertiesByInstanceAndPropertyType(page.PageID, Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CUST);
                StaticCustomPropertyHelper.DeleteControlPropertiesByInstanceAndPropertyType(page.PageID, Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT);
            }


            assignContentToPage.PageId = page.PageID;
            assignContentToPage.Save();

            EditPageHelper.SaveAllCustomProperties(pnlCustomPropertiesForLayout, page.PageID);
            EditPageHelper.SaveAllCustomProperties(pnlCustomPropertiesForSkin, page.PageID);
       

            StaticCustomPropertyHelper.SaveControlPropertyByInstance(
                new SaveNewCustomPropertyInstanceInfo(
                    page.PageID,
                    Morphfolia.Common.ControlPropertyTypeFactory.CustomPropertyType(),
                    Morphfolia.Common.Constants.Framework.SpecialCustomPropertyKeys.LayoutWebControlType,
                    pageLayoutSelector.GetSelectedLayout())
                );

            StaticCustomPropertyHelper.SaveControlPropertyByInstance(
                new SaveNewCustomPropertyInstanceInfo(
                    page.PageID,
                    Morphfolia.Common.ControlPropertyTypeFactory.CustomPropertyType(),
                    Morphfolia.Common.Constants.Framework.SpecialCustomPropertyKeys.SkinProviderType,
                    skinSelector.GetSelectedSkin())
                );

            // Update any content items added to the page (if any):
            Morphfolia.Common.Info.PageContentUpdateInfoCollection pageContentUpdateInfoCollection = new Morphfolia.Common.Info.PageContentUpdateInfoCollection();

            page.LastModifiedBy = _CurrentUsersIdentityName;
            page.Save(pageContentUpdateInfoCollection);


            hypViewPage.NavigateUrl = string.Format("{0}/{1}",
                Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot(),
                page.Url);

            hypViewPage.Visible = true;


            Logging.Logger.LogInformation("EditPage Save()", "Complete.");

            return pageId;
        }


        private void DeletePage()
        {
            if (this._PageID > Common.Constants.SystemTypeValues.NullInt)
            {
                Morphfolia.Business.Page page = Morphfolia.Business.PageFactory.Page(_PageID);
                page.Delete();
            }
        }
    }
}