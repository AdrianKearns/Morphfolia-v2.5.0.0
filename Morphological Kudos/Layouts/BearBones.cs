// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Info;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;

namespace Morphological.Kudos.Layouts
{
    [IsLayoutWebControl]
    public class BareBones : BasePageLayout, INamingContainer
    {
        private Literal pageTitle;
        private Panel contentPanel;

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


        //public BareBones()
        //{
        //}


        //public BareBones(WebControl childWebControl)
        //{
        //    ChildControls.Add(childWebControl);
        //}


        private CustomPropertyInstanceInfoCollection CustomProperties = null;

        public override void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            EnsureChildControls();

            CustomProperties = customProperties;
            string propertyKey;
            string propertyValue;

            if (CustomProperties != null)
            {
                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    switch (propertyKey)
                    {
                        case Constants.CommonPropertyKeys.OveralWidth:
                            if (!propertyValue.Equals(string.Empty))
                            {
                                try
                                {
                                    OveralWidth = Unit.Parse(propertyValue);
                                }
                                catch
                                {
                                    OveralWidth = Unit.Pixel(300);
                                }
                            }
                            break;
                    }
                }
            }
        }


        #region ...   Properties   ...

        private Unit overalWidth = Unit.Pixel(650);
        [IsCustomProperty,
        PropertyFriendlyName("Width"),
        PropertyDescription(Descriptions.Width),
        PropertySuggestedUsage(SuggestedUsageNotes.Width)]
        public Unit OveralWidth
        {
            get { return overalWidth; }
            set { overalWidth = value; }
        }


        private string userContent = "&nbsp;";
        [IsContentContainer,
        ContentContainerDescription("Main page content."),
        ContentContainerColour("#ddeeff")]
        public string UserContent
        {
            get { return userContent; }
            set { userContent = value; }
        }

        #endregion


        protected override void CreateChildControls()
        {
            pageTitle = new Literal();
            Controls.Add(pageTitle);

            contentPanel = new Panel();
            Controls.Add(contentPanel);
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                if (ChildControls.Count > 0)
                {
                    for (int c = 0; c < ChildControls.Count; c++)
                    {
                        contentPanel.Controls.AddAt(c, ChildControls[c]);
                    }
                }

                pageTitle.Text = string.Format("<h1>{0}</h1>", base.Page.Title);

                contentPanel.Width = OveralWidth;

                base.RenderContents(writer);
            }
        }


        public override void InitializeContent()
        {
            EnsureChildControls();

            string propertyType;
            int temp;

            if (CustomProperties != null)
            {
                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;

                    if (propertyType.Equals(Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT))
                    {
                        temp = GetContentInfoIndexById(int.Parse(CustomProperties[i].PropertyValue));
                        if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                        {
                            AddContentToContentContainer(contentPanel, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                        }
                    }
                }
            }
        }


        private string formTemplatePresenterType = "Morphological.Kudos.FormTemplatePresenters.LivewireProblem, Morphological.Kudos";
        public override string FormTemplatePresenterType
        {
            get { return formTemplatePresenterType; }
            set { formTemplatePresenterType = value; }
        }

    }
}