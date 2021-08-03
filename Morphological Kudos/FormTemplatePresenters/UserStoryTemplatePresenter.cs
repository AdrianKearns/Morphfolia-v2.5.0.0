// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Interfaces;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Types;

namespace Morphological.Kudos.FormTemplatePresenters
{
    public class UserStoryTemplatePresenterProvider : IFormTemplatePresenterProvider
    {
        public System.Web.UI.WebControls.WebControl MakePresenter(IFormTemplate formTemplate)
        {
            throw new System.NotImplementedException();
        }

        public System.Web.UI.WebControls.WebControl MakePresenter(string formTemplateXml)
        {
            Morphfolia.Common.Logging.Logger.LogVerboseInformation("UserStoryTemplatePresenter", formTemplateXml, 1234);

            Morphological.Kudos.FormTemplatePresenters.UserStoryTemplatePresenter x = new UserStoryTemplatePresenter();
            x.FormTemplate = Morphfolia.Business.FormTemplateHelper.GetDefinitionAndDataFromXmlDefinition(formTemplateXml);
            return x;
        }
    }



    public class UserStoryTemplatePresenter : WebControl, INamingContainer
    {
        protected Table tblDefaultFormTemplatePresenter;
        protected TableHeaderRow thr;
        protected TableHeaderCell thc;
        protected TableRow tr;
        protected TableCell td;

        private FormTemplate formTemplate = null;
        public FormTemplate FormTemplate
        {
            get { return formTemplate; }
            set { formTemplate = value; }
        }

        protected override void CreateChildControls()
        {
            tblDefaultFormTemplatePresenter = new Table();
            Controls.Add(tblDefaultFormTemplatePresenter);
            tblDefaultFormTemplatePresenter.CellPadding = 3;
            tblDefaultFormTemplatePresenter.CellSpacing = 0;
            //tblDefaultFormTemplatePresenter.Style.Add("border", "dashed 1px #dd66dd");
            tblDefaultFormTemplatePresenter.Style.Add("margin", "3px");
            tblDefaultFormTemplatePresenter.Width = Unit.Percentage(100);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("Kudos", "UserStoryTemplatePresenter, RenderContents() called.");

            if (FormTemplate == null)
            {
                tr = new TableRow();
                tblDefaultFormTemplatePresenter.Rows.Add(tr);
                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = "FormTemplate == null";
            }
            else
            {
                thr = new TableHeaderRow();
                tblDefaultFormTemplatePresenter.Rows.Add(thr);
                thc = new TableHeaderCell();
                thr.Cells.Add(thc);
                thc.Text = FormTemplate.Fields[0].Text;
                thc.ColumnSpan = 2;

                tr = new TableRow();
                tblDefaultFormTemplatePresenter.Rows.Add(tr);
                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = string.Format("Priority: {0}", FormTemplate.Fields[1].Text);


                string priorityMatcher = FormTemplate.Fields[1].Text.Trim().ToUpper();
                bool done = false;

                if (priorityMatcher.Equals("H") | priorityMatcher.Equals("HIGH"))
                {
                    tblDefaultFormTemplatePresenter.CssClass = "ScrumSprintPlanner_UserStory_HighPriority";
                    td.Text = "Priority: High";
                    done = true;
                }

                if (priorityMatcher.Equals("M") | priorityMatcher.Equals("MEDIUM"))
                {
                    tblDefaultFormTemplatePresenter.CssClass = "ScrumSprintPlanner_UserStory_MediumPriority";
                    td.Text = "Priority: Medium";
                    done = true;
                }

                if (priorityMatcher.Equals("L") | priorityMatcher.Equals("LOW"))
                {
                    tblDefaultFormTemplatePresenter.CssClass = "ScrumSprintPlanner_UserStory_LowPriority";
                    td.Text = "Priority: Low";
                    done = true;
                }

                if (priorityMatcher.Equals("C") | priorityMatcher.Equals("COMPLETE"))
                {
                    tblDefaultFormTemplatePresenter.CssClass = "ScrumSprintPlanner_UserStory_Complete";
                    td.Text = "Priority: Complete";
                    done = true;
                }

                if (!done)
                {
                    tblDefaultFormTemplatePresenter.CssClass = "ScrumSprintPlanner_UserStory_NoPriority";
                    td.Text = string.Format("Priority: {0}", FormTemplate.Fields[1].Text);
                }


                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = string.Format("Story Points: {0}", FormTemplate.Fields[2].Text);


                tr = new TableRow();
                tblDefaultFormTemplatePresenter.Rows.Add(tr);
                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = FormTemplate.Fields[3].Text;
                td.ColumnSpan = 2;
            }

            if (Visible)
            {
                tblDefaultFormTemplatePresenter.RenderControl(writer);
            }
        }
    }
}