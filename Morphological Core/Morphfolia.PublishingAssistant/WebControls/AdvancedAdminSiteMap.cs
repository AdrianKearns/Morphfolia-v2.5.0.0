// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Common.Info;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.PublishingSystem.WebControls
{
	/// <summary>
	/// Summary description for SiteMap.
	/// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class AdvancedAdminSiteMap : Morphfolia.WebControls.SiteMap, INamingContainer
	{
		//private PageLister _PageLister = new Morphfolia.Business.PageLister();
        private AdvancedAdminSiteMapNode RootNode;
		private Panel pnlUserInput;
        private Panel pnlResults;
        private Table tblSetNewPropertyValue;
        private TableRow tr;
        private TableCell td;
        private Button btnApplyNewPropertyValue;
        private TextBox txtFilter;
        private TextBox txtNewValue;
        public DropDownList ddlUniqueListOfProperties;

        private Table tblCopyPropertiesToOtherPage;
        private TextBox txtSourcePageId;
        private TextBox txtTargetPageIds;
        private Button btnCopyProperties;
        private TableCell tdCopyPropertiesMessage;
        private Label lbl;

        private TableHeaderRow thr;
        private TableHeaderCell thc;

        private PageInfoCollection pageInfoCollection;
        public PageInfoCollection PageInfoCollection
        {
            get
            {
                if (pageInfoCollection == null)
                {
                    pageInfoCollection = Morphfolia.Business.PageLister.List();
                }
                else
                {
                    if (pageInfoCollection.Count == 0)
                    {
                        pageInfoCollection = Morphfolia.Business.PageLister.List();
                    }
                }
                return pageInfoCollection;
            }
            set
            {                
                pageInfoCollection = value;
            }
        }

        public AdvancedAdminSiteMap()
        {
        }

        public AdvancedAdminSiteMap(PageInfoCollection pageInfoCollection )
        {
            this.PageInfoCollection = pageInfoCollection;
        }

        private string rootNodeText = "Site Root";
        public new string RootNodeText
        {
            get { return rootNodeText; }
            set { rootNodeText = value; }
        }


        /// <summary>
        /// Helps to construct the UI (table) that provides functionality to 
        /// modfiy properties across many pages.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private TableCell AppendRowToTblSetNewPropertyValue(string text)
        {
            tr = new TableRow();
            this.Controls.Add(tr);
            tblSetNewPropertyValue.Rows.Add(tr);

            td = new TableCell();
            this.Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = text;

            td = new TableCell();
            this.Controls.Add(td);
            tr.Cells.Add(td);

            return td;
        }


        protected override void CreateChildControls()
		{
            this.EnableViewState = false;

            if (!Page.ClientScript.IsClientScriptIncludeRegistered(ClientScriptRegistrationKeys.ExpandCollapse))
            {
                Page.ClientScript.RegisterClientScriptInclude(ClientScriptRegistrationKeys.ExpandCollapse, string.Format("{0}/Morphfolia/JavaScript/ExpandCollapse.js", WebUtilities.VirtualApplicationRoot()));
            }


			pnlUserInput = new Panel();
			Controls.Add( pnlUserInput );

            Literal br = new Literal();
            Controls.Add(br);
            br.Text = "<br>";

            pnlResults = new Panel();
            Controls.Add(pnlResults);



            tblSetNewPropertyValue = new Table();
            Controls.Add(tblSetNewPropertyValue);
            pnlUserInput.Controls.Add(tblSetNewPropertyValue);
            tblSetNewPropertyValue.CellPadding = 5;
            tblSetNewPropertyValue.CellSpacing = 0;
            tblSetNewPropertyValue.CssClass = "FunctionalArea";
            tblSetNewPropertyValue.Width = Unit.Pixel(600);


            thr = new TableHeaderRow();
            Controls.Add(thr);
            tblSetNewPropertyValue.Rows.Add(thr);

            thc = new TableHeaderCell();
            Controls.Add(thc);
            thr.Cells.Add(thc);
            thc.ColumnSpan = 2;
            thc.Text = "Change Existing Settings";





            td = AppendRowToTblSetNewPropertyValue("Property To Set");

            ddlUniqueListOfProperties = new DropDownList();
            this.Controls.Add(ddlUniqueListOfProperties);
            td.Controls.Add(ddlUniqueListOfProperties);
            ddlUniqueListOfProperties.ToolTip = "Select the property you wish to modify.";
            ddlUniqueListOfProperties.Items.Clear();
            ddlUniqueListOfProperties.Items.Add(new ListItem("Please Select / Show All", string.Empty));
            ddlUniqueListOfProperties.AutoPostBack = true;

            NameValueCollection listOfProperties = GetListOfUniqueProperties();
            if (listOfProperties.Count == 0)
            {
                // Error?
                td.Text = "None available.";
            }
            else
            {
                foreach (string key in listOfProperties.AllKeys)
                {
                    ddlUniqueListOfProperties.Items.Add(new ListItem(string.Format("{0} ({1})", listOfProperties[key].ToString(), key), key));
                }
            }


            td = AppendRowToTblSetNewPropertyValue("Filter");

            txtFilter = new TextBox();
            this.Controls.Add(txtFilter);
            td.Controls.Add(txtFilter);
            txtFilter.ToolTip = "The value to match/replace.";
            txtFilter.Columns = 45;



            td = AppendRowToTblSetNewPropertyValue("New Value");

            txtNewValue = new TextBox();
            this.Controls.Add(txtNewValue);
            td.Controls.Add(txtNewValue);
            txtNewValue.ToolTip = "The new value to apply to the specified property.";
            txtNewValue.Columns = 45;
            txtNewValue.MaxLength = 2000;


            btnApplyNewPropertyValue = new Button();
            this.Controls.Add(btnApplyNewPropertyValue);
            td.Controls.Add(btnApplyNewPropertyValue);
            btnApplyNewPropertyValue.ID = "btnApplyNewPropertyValue";
            btnApplyNewPropertyValue.Text = "Set";
            btnApplyNewPropertyValue.Click += new EventHandler(btnApplyNewPropertyValue_Click);


            br = new Literal();
            pnlUserInput.Controls.Add(br);
            br.Text = "<br>";


            tblCopyPropertiesToOtherPage = new Table();
            Controls.Add(tblCopyPropertiesToOtherPage);
            pnlUserInput.Controls.Add(tblCopyPropertiesToOtherPage);
            tblCopyPropertiesToOtherPage.CellPadding = 5;
            tblCopyPropertiesToOtherPage.CellSpacing = 0;
            tblCopyPropertiesToOtherPage.CssClass = "FunctionalArea";
            tblCopyPropertiesToOtherPage.Width = Unit.Pixel(600);

            thr = new TableHeaderRow();
            Controls.Add(thr);
            tblCopyPropertiesToOtherPage.Rows.Add(thr);

            thc = new TableHeaderCell();
            Controls.Add(thc);
            thr.Cells.Add(thc);
            thc.ColumnSpan = 3;
            thc.Text = "Copy Settings";

            tr = new TableRow();
            Controls.Add(tr);
            tblCopyPropertiesToOtherPage.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            lbl = new Label();
            Controls.Add(lbl);
            td.Controls.Add(lbl);
            lbl.Text = "Source Page Id ";

            txtSourcePageId = new TextBox();
            Controls.Add(txtSourcePageId);
            td.Controls.Add(txtSourcePageId);
            txtSourcePageId.ToolTip = "The Id of the page to copy properties from.";
            txtSourcePageId.Columns = 6;
            txtSourcePageId.ID = "txtSourcePageId";

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            lbl = new Label();
            Controls.Add(lbl);
            td.Controls.Add(lbl);
            lbl.Text = "Target Page Id(s) ";

            txtTargetPageIds = new TextBox();
            Controls.Add(txtTargetPageIds);
            td.Controls.Add(txtTargetPageIds);
            txtTargetPageIds.ToolTip = "The Id of the page(s) to copy properties to.  Seperate Ids with a space or a comma.";
            txtTargetPageIds.Columns = 20;
            txtTargetPageIds.ID = "txtTargetPageIds";

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            btnCopyProperties = new Button();
            Controls.Add(btnCopyProperties);
            td.Controls.Add(btnCopyProperties);
            btnCopyProperties.ID = "btnCopyProperties";
            btnCopyProperties.Text = "Copy";
            btnCopyProperties.Click += new EventHandler(btnCopyProperties_Click);


            tr = new TableRow();
            Controls.Add(tr);
            tblCopyPropertiesToOtherPage.Rows.Add(tr);

            tdCopyPropertiesMessage = new TableCell();
            Controls.Add(tdCopyPropertiesMessage);
            tr.Cells.Add(tdCopyPropertiesMessage);
            tdCopyPropertiesMessage.ColumnSpan = 3;
            //tdCopyPropertiesMessage.Text = "";


            RootNode = new AdvancedAdminSiteMapNode(this);
            Controls.Add(RootNode);
            pnlResults.Controls.Add(RootNode);
            RootNode.Url = string.Empty;
            //RootNode.ParentSiteMap = this;
            //RootNode.ParentSiteMapNode = null;
            


            RePopulateTree();
		}


        void btnCopyProperties_Click(object sender, EventArgs e)
        {
            string temp;
            int sourcePageId = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
            string[] targetPageIds;

            try
            {
                sourcePageId = int.Parse(txtSourcePageId.Text.Trim());                
            }
            catch
            {
            }

            if (sourcePageId == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                tdCopyPropertiesMessage.Text = "The source Page Id was not specified correctly.";
            }
            else
            {
                temp = txtTargetPageIds.Text.Trim();
                temp = temp.Replace(",", " ");
                targetPageIds = temp.Split(char.Parse(" "));

                if (targetPageIds.Length == 0)
                {
                    tdCopyPropertiesMessage.Text = "The target Page Id(s) was not specified correctly.";
                }
                else
                {
                    StaticCustomPropertyHelper.CopySettings(sourcePageId, targetPageIds);

                    tdCopyPropertiesMessage.Text = "Copying successful.";
                }
            }
        }


        protected void btnApplyNewPropertyValue_Click(object sender, EventArgs e)
        {
            string propertyToSave = ddlUniqueListOfProperties.SelectedValue;

            if (!propertyToSave.Equals(String.Empty))
            {
                if (txtFilter.Text.Equals(string.Empty))
                {
                    StaticCustomPropertyHelper.SavePropertyValue (propertyToSave, txtNewValue.Text);
                }
                else
                {
                    StaticCustomPropertyHelper.SavePropertyValue(propertyToSave, txtNewValue.Text, txtFilter.Text);                    
                }
            }
        }


        private void RePopulateTree()
        {
            EnsureChildControls();

            RootNode.Leafs.Clear();
            RootNode.Nodes.Clear();
            PageInfoCollection.Clear();
            PageInfoCollection = Morphfolia.Business.PageLister.List();

            foreach (PageInfo p in PageInfoCollection)
            {
                RootNode.AddNode(new Morphfolia.WebControls.SiteMapNode.WorkingInfo(p.Title, p.Url), p, RootNode);
            }
        }



        protected NameValueCollection GetListOfUniqueProperties()
        {
            string temp;
            NameValueCollection uniqueListOfProperties = new NameValueCollection();
            StringCollection availableLayoutTemplates = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableLayoutWebControls();

            uniqueListOfProperties.Add("LayoutWebControlType", "Layout");
            uniqueListOfProperties.Add("SkinProviderType", "Skin");

            if (availableLayoutTemplates.Count > 0)
            {
                for (int t = 0; t < availableLayoutTemplates.Count; t++)
                {
                    foreach (Morphfolia.Common.Info.CustomPropertyInfo customPropertyInfo in Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableCustomPropertiesForType(availableLayoutTemplates[t]))
                    {
                        temp = customPropertyInfo.PropertyKey;
                        if (uniqueListOfProperties.Get(temp) == null)
                        {
                            uniqueListOfProperties.Add(customPropertyInfo.PropertyKey, customPropertyInfo.PropertyName);
                        }
                    }
                }
            }


            StringCollection availableSkinProviders = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableSkinProviders();
            if (availableSkinProviders.Count > 0)
            {
                for (int t = 0; t < availableSkinProviders.Count; t++)
                {
                    foreach (Morphfolia.Common.Info.CustomPropertyInfo customPropertyInfo in Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableCustomPropertiesForType(availableSkinProviders[t]))
                    {
                        temp = customPropertyInfo.PropertyKey;
                        if (uniqueListOfProperties.Get(temp) == null)
                        {
                            uniqueListOfProperties.Add(customPropertyInfo.PropertyKey, customPropertyInfo.PropertyName);
                        }
                    }
                }
            }



            return uniqueListOfProperties;
        }



        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                RootNode.Text = RootNodeText;

                RePopulateTree();

                base.RenderContents(writer);
            }
        }

        //protected override void Render(HtmlTextWriter output)
        //{
        //    EnsureChildControls();

        //    if( Visible )
        //    {
        //        RootNode.Text = RootNodeText;

        //        RePopulateTree();

        //        base.Render(output);
        //    }
        //}
	}
}