// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Types;
using Morphfolia.PageLayoutAndSkinAssistant.Logging;

namespace Morphfolia.PageLayoutAndSkinAssistant
{
    public class DefaultFormTemplatePresenter : WebControl, INamingContainer
    {
        protected Table tblDefaultFormTemplatePresenter;
        protected TableRow tr;
        protected TableCell td;

        private FormTemplate formTemplate = null;
        public FormTemplate FormTemplate
        {
            get { return formTemplate; }
            set { formTemplate = value; }
        }


        public DefaultFormTemplatePresenter()
        {
        }

        public DefaultFormTemplatePresenter(FormTemplate formTemplate)
        {
            FormTemplate = formTemplate;
        }

        public DefaultFormTemplatePresenter(string formTemplateXML)
        {
            FormTemplate newFormTemplate = new FormTemplate();
            newFormTemplate = (FormTemplate)Morphfolia.Common.Utilities.XMLHelper.XMLStringToObject(formTemplateXML, newFormTemplate.GetType());
            FormTemplate = newFormTemplate;
        }

        protected override void CreateChildControls()
        {
            tblDefaultFormTemplatePresenter = new Table();
            Controls.Add(tblDefaultFormTemplatePresenter);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

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
                string Text;
                FormTemplateFieldType formTemplateFieldType;

                tr = new TableRow();
                tblDefaultFormTemplatePresenter.Rows.Add(tr);
                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = FormTemplate.Name;

                for (int i = 0; i < FormTemplate.Fields.Count; i++)
                {
                    tr = new TableRow();
                    tblDefaultFormTemplatePresenter.Rows.Add(tr);
                    td = new TableCell();
                    tr.Cells.Add(td);

                    Text = FormTemplate.Fields[i].Text;
                    formTemplateFieldType = FormTemplate.Fields[i].Type;

                    switch (formTemplateFieldType)
                    {
                        case FormTemplateFieldType.Small:
                            td.Text = Text;
                            break;

                        case FormTemplateFieldType.Medium:
                            td.Text = Text;
                            break;

                        case FormTemplateFieldType.Large:
                            td.Text = Text;
                            break;

                        case FormTemplateFieldType.InLineImage:
                            Image inLineImage = new Image();
                            td.Controls.Add(inLineImage);
                            inLineImage.ImageUrl = Text;
                            inLineImage.ToolTip = Text;
                            break;

                        case FormTemplateFieldType.InLineVideo:
                            Image inLineVideo = new Image();
                            td.Controls.Add(inLineVideo);
                            //inLineImage.ImageUrl = Text; - must use "dynsrc" not "src" property to specifiy location of the video file.
                            inLineVideo.ToolTip = Text;
                            inLineVideo.Attributes.Add("dynsrc", Text);
                            break;

                        case FormTemplateFieldType.LinkToFile:
                            HyperLink linkToFile = new HyperLink();
                            td.Controls.Add(linkToFile);
                            linkToFile.Text = Text;
                            linkToFile.NavigateUrl = Text;
                            linkToFile.ToolTip = Text;
                            linkToFile.Target = "_blank";
                            break;

                        case FormTemplateFieldType.LinkToUrl:
                            HyperLink linkToUrl = new HyperLink();
                            td.Controls.Add(linkToUrl);
                            linkToUrl.Text = Text;
                            linkToUrl.NavigateUrl = Text;
                            linkToUrl.ToolTip = Text;
                            linkToUrl.Target = "_blank";
                            break;

                        default:    // Includes FormTemplateFieldType.Medium
                            td.Text = string.Format("{0}: {1}", FormTemplate.Fields[i].Name, FormTemplate.Fields[i].Text);
                            break;
                    }
                }
            }

            if (Visible)
            {
                tblDefaultFormTemplatePresenter.RenderControl(writer);
            }
        }
    }
}