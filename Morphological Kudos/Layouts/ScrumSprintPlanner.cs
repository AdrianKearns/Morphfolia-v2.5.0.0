// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Morphfolia.Common.Info;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Interfaces;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;
using Morphfolia.Common.Types;

namespace Morphological.Kudos.Layouts
{
    [IsLayoutWebControl]
    public class ScrumSprintPlanner : BasePageLayout, INamingContainer
    {
        private ISkinProvider skinProvider;

        private PlaceHolder headerPlaceHolder;
        private Panel otherContentPanel;
        private PlaceHolder footerPlaceHolder;

        private WebControl tblHeader;
        private Table tblContent;
        private WebControl tblFooter;
        private Literal BeginFormTag;
        private Literal EndFormTag;
        Label lblTemp;

        protected TableRow tr;
        protected TableHeaderCell th;
        protected TableHeaderCell thCurrentSprint;
        protected TableHeaderCell thNextSprint;
        protected TableCell tdProductBacklog;
        protected TableCell tdCurrentSprintBacklog;
        protected TableCell tdNextSprintBacklog;


        private Morphfolia.Common.WebControlCollection childControls;
        public override Morphfolia.Common.WebControlCollection ChildControls
        {
            get
            {
                EnsureChildControls();
                if (childControls == null)
                {
                    childControls = new Morphfolia.Common.WebControlCollection();
                }
                return childControls;
            }
            set
            {
                childControls = value;
            }
        }


        /// <summary>
        /// Define the name of Content Containers 
        /// for easy and consistent reference.
        /// </summary>
        /// <remarks>
        /// The values of these strings should be the same as 
        /// the name of the Property(s) decorated with 
        /// IsContentContainer.
        /// </remarks>
        public new class ContentPlugKeys
        {
            public const string OtherContent = "OtherContent";
            public const string ProductBacklog = "ProductBacklog";
            public const string CurrentSprintBacklog = "CurrentSprintBacklog";
            public const string NextSprintBacklog = "NextSprintBacklog";
        }


        private CustomPropertyInstanceInfoCollection CustomProperties = null;
        public override void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            EnsureChildControls();

            CustomProperties = customProperties;

            System.Text.StringBuilder sbC1 = new System.Text.StringBuilder();
            //string propertyType;
            string propertyKey;
            string propertyValue;
            //int temp;


            if (CustomProperties != null)
            {
                skinProvider = base.LoadSkinProvider(CustomProperties, new Skins.SpecialCircumstances.Anaplian());

                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    //propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    switch (propertyKey)
                    {
                        case Constants.CommonPropertyKeys.FormTemplatePresenterType:
                            FormTemplatePresenterType = propertyValue;
                            break;

                        case "CurrentTargetDate":
                            thCurrentSprint.Text = string.Format("{0}<br>Target: {1}", thCurrentSprint.Text, propertyValue);
                            break;

                        case "NextTargetDate":
                            thNextSprint.Text = string.Format("{0}<br>Target: {1}", thNextSprint.Text, propertyValue);
                            break;
                    }
                }
            }
        }


        public override void InitializeContent()
        {
            EnsureChildControls();

            string propertyKey;
            string propertyValue;
            int temp;

            FormTemplateField f = new FormTemplateField();
            FormTemplateCollection productBacklogItems = new FormTemplateCollection();
            FormTemplateCollection currentSprintBacklogItems = new FormTemplateCollection();
            FormTemplateCollection nextSprintBacklogItems = new FormTemplateCollection();

            if (CustomProperties != null)
            {
                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    switch (propertyKey)
                    {
                        case ContentPlugKeys.OtherContent:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(otherContentPanel, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.ProductBacklog:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AppendFormItemToCollection(Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content, productBacklogItems);
                            break;

                        case ContentPlugKeys.CurrentSprintBacklog:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AppendFormItemToCollection(Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content, currentSprintBacklogItems);
                            break;

                        case ContentPlugKeys.NextSprintBacklog:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AppendFormItemToCollection(Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content, nextSprintBacklogItems);
                            break;
                    }
                }
            }



            Morphological.Kudos.FormTemplatePresenters.UserStoryTemplatePresenter tempUserStoryPresenter;

            if (productBacklogItems.Count == 0)
            {
                lblTemp = new Label();
                tdProductBacklog.Controls.Add(lblTemp);
                lblTemp.Text = "The Product Backlog is empty.";
            }
            else
            {
                foreach (FormTemplate ft in productBacklogItems)
                {
                    tempUserStoryPresenter = new Morphological.Kudos.FormTemplatePresenters.UserStoryTemplatePresenter();
                    tempUserStoryPresenter.FormTemplate = ft;
                    Controls.Add(tempUserStoryPresenter);
                    tdProductBacklog.Controls.Add(tempUserStoryPresenter);
                }
            }

            if (currentSprintBacklogItems.Count == 0)
            {
                lblTemp = new Label();
                tdCurrentSprintBacklog.Controls.Add(lblTemp);
                lblTemp.Text = "The current Sprint Backlog is empty.";
            }
            else
            {
                foreach (FormTemplate ft in currentSprintBacklogItems)
                {
                    tempUserStoryPresenter = new Morphological.Kudos.FormTemplatePresenters.UserStoryTemplatePresenter();
                    tempUserStoryPresenter.FormTemplate = ft;
                    Controls.Add(tempUserStoryPresenter);
                    tdCurrentSprintBacklog.Controls.Add(tempUserStoryPresenter);
                }
            }

            if (nextSprintBacklogItems.Count == 0)
            {
                lblTemp = new Label();
                tdNextSprintBacklog.Controls.Add(lblTemp);
                lblTemp.Text = "The next Sprint Backlog is empty.";
            }
            else
            {
                foreach (FormTemplate ft in nextSprintBacklogItems)
                {
                    tempUserStoryPresenter = new Morphological.Kudos.FormTemplatePresenters.UserStoryTemplatePresenter();
                    tempUserStoryPresenter.FormTemplate = ft;
                    Controls.Add(tempUserStoryPresenter);
                    tdNextSprintBacklog.Controls.Add(tempUserStoryPresenter);
                }
            }
        }


        private string otherContent = string.Empty;
        [IsContentContainer]
        public string OtherContent
        {
            get { return otherContent; }
            set { otherContent = value; }
        }

        private string productBacklog = string.Empty;
        [IsContentContainer]
        public string ProductBacklog
        {
            get { return productBacklog; }
            set { productBacklog = value; }
        }

        private string currentSprintBacklog = string.Empty;
        [IsContentContainer]
        public string CurrentSprintBacklog
        {
            get { return currentSprintBacklog; }
            set { currentSprintBacklog = value; }
        }

        private string nextSprintBacklog = string.Empty;
        [IsContentContainer]
        public string NextSprintBacklog
        {
            get { return nextSprintBacklog; }
            set { nextSprintBacklog = value; }
        }


        private string currentTargetDate = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Current Target Date"),
        PropertyDescription("The target date for completion of the current sprint."),
        PropertySuggestedUsage("A calendar date.")]
        public string CurrentTargetDate
        {
            get { return currentTargetDate; }
            set { currentTargetDate = value; }
        }

        private string nextTargetDate = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Next Target Date"),
        PropertyDescription("The target date for completion of the next sprint."),
        PropertySuggestedUsage("A calendar date.")]
        public string NextTargetDate
        {
            get { return nextTargetDate; }
            set { nextTargetDate = value; }
        }


        protected override void CreateChildControls()
        {
            headerPlaceHolder = new PlaceHolder();
            Controls.Add(headerPlaceHolder);
            headerPlaceHolder.ID = "headerPlaceHolder";

            BeginFormTag = new Literal();
            Controls.Add(BeginFormTag);
            BeginFormTag.Text = "<form id=\"Form1\" method=\"post\" runat=\"server\">";


            otherContentPanel = new Panel();
            Controls.Add(otherContentPanel);
            otherContentPanel.ID = "OtherContentPlaceHolder";
            otherContentPanel.Style.Add("margin", "20px;");
            otherContentPanel.Style.Add("width", "50%");
            


            tblContent = new Table();
            Controls.Add(tblContent);
            tblContent.HorizontalAlign = HorizontalAlign.Center;
            tblContent.CellPadding = 10;
            tblContent.CellSpacing = 0;
            tblContent.CssClass = "ScrumSprintPlanner_table";


            tr = new TableRow();
            Controls.Add(tr);
            tblContent.Rows.Add(tr);

            th = new TableHeaderCell();
            Controls.Add(th);
            tr.Cells.Add(th);
            th.Text = "Product Backlog";
            th.VerticalAlign = VerticalAlign.Top;
            th.Width = Unit.Percentage(33);

            thCurrentSprint = new TableHeaderCell();
            Controls.Add(thCurrentSprint);
            tr.Cells.Add(thCurrentSprint);
            thCurrentSprint.Text = "Current Sprint Backlog";
            thCurrentSprint.VerticalAlign = VerticalAlign.Top;
            th.Width = Unit.Percentage(33);

            thNextSprint = new TableHeaderCell();
            Controls.Add(thNextSprint);
            tr.Cells.Add(thNextSprint);
            thNextSprint.Text = "Next Sprint Backlog";
            thNextSprint.VerticalAlign = VerticalAlign.Top;
            th.Width = Unit.Percentage(33);

 



            tr = new TableRow();
            Controls.Add(tr);
            tblContent.Rows.Add(tr);

            tdProductBacklog = new TableCell();
            Controls.Add(tdProductBacklog);
            tr.Cells.Add(tdProductBacklog);
            tdProductBacklog.VerticalAlign = VerticalAlign.Top;
            tdProductBacklog.ID = "tdProductBacklog";
            tdProductBacklog.CssClass = "ScrumSprintPlanner_ProductBacklog";
            tdProductBacklog.Width = Unit.Percentage(30);

            tdCurrentSprintBacklog = new TableCell();
            Controls.Add(tdCurrentSprintBacklog);
            tr.Cells.Add(tdCurrentSprintBacklog);
            tdCurrentSprintBacklog.VerticalAlign = VerticalAlign.Top;
            tdCurrentSprintBacklog.ID = "tdCurrentSprintBacklog";
            tdCurrentSprintBacklog.CssClass = "ScrumSprintPlanner_CurrentSprintBacklog";
            tdCurrentSprintBacklog.Width = Unit.Percentage(30);

            tdNextSprintBacklog = new TableCell();
            Controls.Add(tdNextSprintBacklog);
            tr.Cells.Add(tdNextSprintBacklog);
            tdNextSprintBacklog.VerticalAlign = VerticalAlign.Top;
            tdNextSprintBacklog.ID = "tdNextSprintBacklog";
            tdNextSprintBacklog.CssClass = "ScrumSprintPlanner_NextSprintBacklog";
            tdNextSprintBacklog.Width = Unit.Percentage(30);

            EndFormTag = new Literal();
            Controls.Add(EndFormTag);
            EndFormTag.Text = "</form>";

            footerPlaceHolder = new PlaceHolder();
            Controls.Add(footerPlaceHolder);
            footerPlaceHolder.ID = "footerPlaceHolder";
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                if (skinProvider == null)
                {
                    skinProvider = base.LoadSkinProvider(null, new Skins.SpecialCircumstances.Anaplian());
                }

                tblHeader = skinProvider.MakePageHeader(this.Page);
                Controls.Add(tblHeader);
                headerPlaceHolder.Controls.Add(tblHeader);

                tblFooter = skinProvider.MakePageFooter(this.Page);
                Controls.Add(tblFooter);
                footerPlaceHolder.Controls.Add(tblFooter);

                base.RenderContents(writer);
            }
        }


        private bool AppendFormItemToCollection(string contentEntryFilter, string content, FormTemplateCollection collection)
        {
            if (
                (contentEntryFilter.Equals(string.Empty)) |
                (contentEntryFilter.Equals("HtmlEditor"))
                )
            {
                // "Normal" content - HTML Mark-up:
                return false;
            }
            else
            {
                if (FormTemplatePresenter == null)
                {
                    return false;
                }
                else
                {                    
                    FormTemplate f = Morphfolia.Business.FormTemplateHelper.GetDefinitionAndDataFromXmlDefinition(content);
                    int newPriority = int.MaxValue;
                    newPriority = ConvertPriorityStringToNumber(f.Fields[1].Text);

                    // change priority to H M L
                    // URL / Page redirects

                    int priority;
                    bool hasBeenAdded = false;
                    //foreach (FormTemplate ft in collection)
                    for(int i = 0; i < collection.Count; i++)
                    {
                        priority = ConvertPriorityStringToNumber(collection[i].Fields[1].Text);
                        if (newPriority < priority)
                        {
                            collection.Insert(i, f);
                            hasBeenAdded = true;
                            break;
                        }
                    }

                    if (!hasBeenAdded)
                    {
                        collection.Add(f);
                    }

                    return true;
                }
            }
        }


        /// <summary>
        /// Takes a text based priority (such as H, M or L) 
        /// and return a number that the algorythum can use 
        /// to order items by priority.
        /// </summary>
        /// <remarks>Case in-sensitive.  Non-matched priorites 
        /// are returned as 100 (not prioritised).</remarks>
        /// <param name="priority">H, M, L, High, Medium, Low.</param>
        /// <returns>10, 20, 30, 100</returns>
        private int ConvertPriorityStringToNumber(string priority)
        {
            string x = priority.Trim().ToUpper();
            switch (x)
            {
                case "H": return 10;
                case "HIGH": return 10;
                case "M": return 20;
                case "MEDIUM": return 20;
                case "L": return 30;
                case "LOW": return 30;
                case "C": return 80;
                case "COMPLETE": return 80;
                default: return 100;
            }
        }


        private string formTemplatePresenterType = "Morphological.Kudos.FormTemplatePresenters.UserStoryTemplatePresenterProvider, Morphological.Kudos";
        public override string FormTemplatePresenterType
        {
            get { return formTemplatePresenterType; }
            set { formTemplatePresenterType = value; }
        }
    }
}
