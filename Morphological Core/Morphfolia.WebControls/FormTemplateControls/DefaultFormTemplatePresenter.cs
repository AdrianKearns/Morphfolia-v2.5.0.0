// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Types;
using Morphfolia.Common.Interfaces;

namespace Morphfolia.WebControls.FormTemplateControls
{
    public class DefaultFormTemplatePresenterProvider : IFormTemplatePresenterProvider
    {
        public System.Web.UI.WebControls.WebControl MakePresenter(IFormTemplate formTemplate)
        {
            DefaultFormTemplatePresenter presenter = new DefaultFormTemplatePresenter();
            presenter.FormTemplate = formTemplate;
            return presenter;
        }

        public System.Web.UI.WebControls.WebControl MakePresenter(string formTemplateXml)
        {
            DefaultFormTemplatePresenter presenter = new DefaultFormTemplatePresenter();
            presenter.FormTemplate = Morphfolia.Business.FormTemplateHelper.GetDefinitionAndDataFromXmlDefinition(formTemplateXml);
            return presenter;
        }
    }


    public class DefaultFormTemplatePresenter : WebControl, INamingContainer
    {
        Table tblDefaultFormTemplatePresenter;
        TableRow tr;
        TableHeaderCell th;
        FormTemplateFieldControl formTemplateField;


        public const string FormTemplateFieldID = "FormTemplateField";
         
        private IFormTemplate innerFormTemplate;
        public IFormTemplate FormTemplate
        {
            get { return innerFormTemplate; }
            set { innerFormTemplate = value; }
        }
         
        private bool showDataEntryForm = false;
        public bool ShowDataEntryForm
        {
            get { return showDataEntryForm; }
            set { showDataEntryForm = value; }
        }
         
        private void Construct()
        {
            tblDefaultFormTemplatePresenter.Rows.Clear();

            tr = new TableRow();
            tblDefaultFormTemplatePresenter.Rows.Add(tr);

            th = new TableHeaderCell();
            tr.Cells.Add(th);
            th.Text = innerFormTemplate.Name;
            //DefaultFormTemplatePresenterProvider
            //tdName.CssClass = "formTemplateControlPresenterHeading";
            th.CssClass = "DefaultFormTemplatePresenterProviderHeading";
            th.ColumnSpan = 2;

            for (int i = 0; i < innerFormTemplate.Fields.Count; i++)
            {
                formTemplateField = new FormTemplateFieldControl();                
                tblDefaultFormTemplatePresenter.Rows.Add(formTemplateField);
                // can't figure out how to cast to a short (duh).
                //formTemplateField.TabIndex = (short.Parse(i.ToString()) + 1);

                formTemplateField.ID = string.Format("{0}{1}", FormTemplateFieldID, i.ToString());
                formTemplateField.Name = innerFormTemplate.Fields[i].Name;
                formTemplateField.FormTemplateFieldType = innerFormTemplate.Fields[i].Type;
                formTemplateField.ShowDataEntryFields = ShowDataEntryForm;
                formTemplateField.Text = innerFormTemplate.Fields[i].Text;
                formTemplateField.Description = innerFormTemplate.Fields[i].Description;
            }
        }
         
        protected override void CreateChildControls()
        {
            tblDefaultFormTemplatePresenter = new Table();
            //tblDefaultFormTemplatePresenter.Attributes.Add("border", "1");
            tblDefaultFormTemplatePresenter.CssClass = "DefaultFormTemplatePresenterProviderItem";
            tblDefaultFormTemplatePresenter.CellPadding = 5;
            tblDefaultFormTemplatePresenter.CellSpacing = 0;
            tblDefaultFormTemplatePresenter.Width = Unit.Percentage(100);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();
            Construct();

            if (Visible)
            {
                tblDefaultFormTemplatePresenter.RenderControl(writer);
            }
        }
    }
}