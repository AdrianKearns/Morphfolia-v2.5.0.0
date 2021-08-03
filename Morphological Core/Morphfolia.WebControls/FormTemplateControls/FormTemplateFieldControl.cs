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
using Morphfolia.Common.Logging;
using Morphfolia.WebControls.Utilities;

namespace Morphfolia.WebControls.FormTemplateControls
{
    public class FormTemplateFieldControl : TableRow, INamingContainer
    {
        TableCell tdName;
        TableCell tdText;
        TextBox txtDataEntry;
        Label lblDescription;


        public const string txtDataEntryID = "FieldText";


        private string name = string.Empty;
        public string Name
        {
            get{ return name; }
            set{ name = value; }
        }


        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        private string text = string.Empty;
        public String Text
        {
            get{ return text; }
            set
            {
                string v = value;
                EnsureChildControls();
                text = HttpRequestHelper.GetRequestParamValue(txtDataEntry.UniqueID);
                if (text.Equals(string.Empty))
                {
                    text = v;
                }
                txtDataEntry.Text = text;                
            }
        }


        private bool showDataEntryFields = true;
        public bool ShowDataEntryFields
        {
            get { return showDataEntryFields; }
            set { showDataEntryFields = value; }
        }


        private FormTemplateFieldType formTemplateFieldType = FormTemplateFieldType.Medium;
        public FormTemplateFieldType FormTemplateFieldType
        {
            get
            {
                return formTemplateFieldType;
            }
            set
            {
                formTemplateFieldType = value;
            }
        }


        protected override void CreateChildControls()
        {
            tdName = new TableCell();
            Cells.Add(tdName);
            tdName.ID = "FieldName";
            tdName.VerticalAlign = VerticalAlign.Top;
            tdName.Width = Unit.Pixel(125);

            tdText = new TableCell();
            Controls.Add(tdText);
            Cells.Add(tdText);
            txtDataEntry = new TextBox();
            tdText.Controls.Add(txtDataEntry);
            txtDataEntry.ID = txtDataEntryID; // "FieldText";

            lblDescription = new Label();
            //Controls.Add(lblDescription);
            tdText.Controls.Add(lblDescription);
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            tdName.Text = Name;
            lblDescription.Text = "<br>" + Description;

            if (showDataEntryFields == false)
            {
                txtDataEntry.Visible = false;

                switch (FormTemplateFieldType)
                {
                    case FormTemplateFieldType.Small:
                        tdText.Text = Text;
                        break;

                    case FormTemplateFieldType.Medium:
                        tdText.Text = Text;
                        break;

                    case FormTemplateFieldType.Large:
                        tdText.Text = Text;
                        break;

                    case FormTemplateFieldType.InLineImage:
                        Image inLineImage = new Image();
                        tdText.Controls.Add(inLineImage);
                        inLineImage.ImageUrl = Text;
                        inLineImage.ToolTip = Text;
                        break;

                    case FormTemplateFieldType.InLineVideo:
                        Image inLineVideo = new Image();
                        tdText.Controls.Add(inLineVideo);
                        //inLineImage.ImageUrl = Text; - must use "dynsrc" not "src" property to specifiy location of the video file.
                        inLineVideo.ToolTip = Text;
                        inLineVideo.Attributes.Add("dynsrc", Text);
                        break;

                    case FormTemplateFieldType.LinkToFile:
                        HyperLink linkToFile = new HyperLink();
                        tdText.Controls.Add(linkToFile);
                        linkToFile.NavigateUrl = Text;
                        linkToFile.ToolTip = Text;
                        linkToFile.Text = Text;
                        linkToFile.Target = "_blank";
                        break;

                    case FormTemplateFieldType.LinkToUrl:
                        HyperLink linkToUrl = new HyperLink();
                        tdText.Controls.Add(linkToUrl);
                        linkToUrl.NavigateUrl = Text;
                        linkToUrl.ToolTip = Text;
                        linkToUrl.Text = Text;
                        linkToUrl.Target = "_blank";
                        break;

                    default:    // Includes FormTemplateFieldType.Medium
                        tdText.Text = Text;
                        break;
                }
            }
            else
            {
                txtDataEntry.Visible = true;
                txtDataEntry.Text = Text;
                txtDataEntry.TabIndex = TabIndex;

                switch (FormTemplateFieldType)
                {
                    case FormTemplateFieldType.Small:
                        txtDataEntry.MaxLength = 20;
                        txtDataEntry.Columns = 20;
                        txtDataEntry.TextMode = TextBoxMode.SingleLine;
                        break;

                    case FormTemplateFieldType.Medium:
                        txtDataEntry.MaxLength = 200;
                        txtDataEntry.Columns = 50;
                        txtDataEntry.TextMode = TextBoxMode.SingleLine;
                        break;

                    case FormTemplateFieldType.Large:
                        txtDataEntry.MaxLength = 2000;
                        txtDataEntry.Columns = 50;
                        txtDataEntry.Rows = 7;
                        txtDataEntry.TextMode = TextBoxMode.MultiLine;
                        break;

                    case FormTemplateFieldType.InLineImage:
                        txtDataEntry.MaxLength = 500;
                        txtDataEntry.Columns = 50;
                        txtDataEntry.TextMode = TextBoxMode.SingleLine;
                        txtDataEntry.ToolTip = "Please specifiy the location of the image.";
                        break;

                    case FormTemplateFieldType.InLineVideo:
                        txtDataEntry.MaxLength = 500;
                        txtDataEntry.Columns = 50;
                        txtDataEntry.TextMode = TextBoxMode.SingleLine;
                        txtDataEntry.ToolTip = "Please specifiy the location of the video.";
                        break;

                    case FormTemplateFieldType.LinkToFile:
                        txtDataEntry.MaxLength = 500;
                        txtDataEntry.Columns = 50;
                        txtDataEntry.TextMode = TextBoxMode.SingleLine;
                        txtDataEntry.ToolTip = "Please specifiy the location of the file.";
                        break;

                    case FormTemplateFieldType.LinkToUrl:
                        txtDataEntry.MaxLength = 500;
                        txtDataEntry.Columns = 50;
                        txtDataEntry.TextMode = TextBoxMode.SingleLine;
                        txtDataEntry.ToolTip = "Please specifiy the URL.";
                        break;

                    default:    // Includes FormTemplateFieldType.Medium
                        txtDataEntry.MaxLength = 200;
                        txtDataEntry.Columns = 50;
                        txtDataEntry.TextMode = TextBoxMode.SingleLine;
                        break;
                }
            }

            //Logger.LogVerboseInformation("FormTemplateFieldControl: RenderContents() about to complete by calling: base.RenderContents(writer);", "", Logging.EventIds.FormTemplateControls._1100);

            base.RenderContents(writer);
        }
    }
}