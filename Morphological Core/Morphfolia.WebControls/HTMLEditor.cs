// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.WebControls.Utilities;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class HTMLEditor : System.Web.UI.WebControls.WebControl, INamingContainer
    {
        private Table tblHTMLEditor;
        private TableRow trHtmlViewToolbar;
        private TableRow trHtmlView;
        private TableRow trWysiwygToolbar;
        private TableRow trWysiwygView;
        private TableRow trImageManager;
        private TableCell tdImageManager;
        private TableRow trFileManager;
        private TableCell tdFileManager;
        private TableCell td;
        private TextBox txtHtml;
        private TextBox txtText;
        private Panel divWysiwygCanvas;
        private Image img;
        private ImageManager imageManager;
        private FileControls.FileManager fileManager;

        private string text;
        public string Text
        {
            get
            {
                if (this.txtText != null)
                {
                    text = this.txtText.Text;
                }
                return text;
            }
        }

        private string html;
        public string Html
        {
            get
            {
                EnsureChildControls();
                if (this.txtHtml != null)
                {
                    html = this.txtHtml.Text;
                }
                return html;
            }
            set
            {
                EnsureChildControls();
                html = value;
                if (this.txtHtml != null)
                {
                    this.txtHtml.Text = html;
                }
            }
        }


        public HTMLEditor()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(ClientScriptRegistrationKeys.ABKEditor_CoreScript))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), ClientScriptRegistrationKeys.ABKEditor_CoreScript, string.Format("<SCRIPT LANGUAGE='JScript' TYPE='text/javascript' SRC='{0}/Morphfolia/ABKEditor/js/Editor.js'></SCRIPT>", WebUtilities.VirtualApplicationRoot()));
            }

            PopulateProperties();
        }


        private CssStyleCollection style;
        public new CssStyleCollection Style
        {
            get {
                EnsureChildControls();
                return tblHTMLEditor.Style; }
            set { style = value;  }
        }

        private Image CreateChildControl_EditorButtonSeperator()
        {
            img = new Image();
            this.Controls.Add(img);
            img.Width = Unit.Pixel(5);
            img.Height = Unit.Pixel(22);
            img.ImageUrl = string.Format("{0}/Morphfolia/ABKEditor/g/iconEditorButtons_buttonSeperator.gif", WebUtilities.VirtualApplicationRoot());
            return img;
        }

        private Image CreateChildControl_EditorButton(string action, string javaScript)
        {
            img = new Image();
            this.Controls.Add(img);
            ApplyEditorButtonStyle(img);
            //img.ImageUrl = string.Format("{0}/Morphfolia/ABKEditor/g/iconEditorButtons_{1}.gif", WebUtilities.VirtualApplicationRoot(), action);
            img.ImageUrl = string.Format("{0}/Morphfolia/ABKEditor/g/iconEditorButtons_{1}.gif", WebUtilities.FullyQualifiedApplicationRoot(), action);
            img.ToolTip = action;
            img.AlternateText = action;
            //img.Attributes.Add("onclick", string.Format("PerformAction('{0}'); return false;", javaScript));
            img.Attributes.Add("onclick", javaScript);
            return img;
        }

        private Image CreateChildControl_EditorButton(string action)
        {
            img = new Image();
            this.Controls.Add(img);
            ApplyEditorButtonStyle(img);
            img.ImageUrl = string.Format("{0}/Morphfolia/ABKEditor/g/iconEditorButtons_{1}.gif", WebUtilities.VirtualApplicationRoot(), action);
            img.ToolTip = action;
            img.AlternateText = action;
            img.Attributes.Add("onclick", string.Format("FormatActionMapper('{0}'); return false;", action));
            return img;
        }

        private void ApplyEditorButtonStyle(Image img)
        {
            img.Width = Unit.Pixel(23);
            img.Height = Unit.Pixel(22);
            img.CssClass = "ABKEditorButton";
            img.Attributes.Add("onMouseover", "this.className='ABKEditorButton_mo';");// = "ABKEditorButton";
            img.Attributes.Add("onMouseout", "this.className='ABKEditorButton';");// = "ABKEditorButton";
        }

        /// <exclude />
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            if (this.Page != null)
            {
                if (!this.Page.ClientScript.IsStartupScriptRegistered(string.Format("InitializeABKHtmlEditor_{0}", this.ID)))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), string.Format("InitializeABKHtmlEditor_{0}", this.ID), string.Format("<script> InitializeABKHtmlEditor('{0}'); </script>", this.ID));
                }
            }


            tblHTMLEditor = new Table();
            this.Controls.Add(tblHTMLEditor);            
            tblHTMLEditor.CssClass = "ABKEditor";
            tblHTMLEditor.CellPadding = 2;
            tblHTMLEditor.CellSpacing = 0;
            tblHTMLEditor.Style.Clear();

            // ----------------------------------------------------------------

            trHtmlViewToolbar = new TableRow();
            this.Controls.Add(trHtmlViewToolbar);
            tblHTMLEditor.Rows.Add(trHtmlViewToolbar);
            //trHtmlViewToolbar.ID = string.Format("abkEditor_{0}_trHtmlViewToolbar", this.ID);
            trHtmlViewToolbar.Attributes.Add("ID", string.Format("abkEditor_{0}_trHtmlViewToolbar", this.ID));

            td = new TableCell();
            this.Controls.Add(td);
            trHtmlViewToolbar.Cells.Add(td);
            td.Width = Unit.Pixel(710);

            img = new Image();
            this.Controls.Add(img);
            td.Controls.Add(img);
            ApplyEditorButtonStyle(img);
            img.ImageUrl = string.Format("{0}/Morphfolia/ABKEditor/g/iconEditorButtons_normalview.gif", WebUtilities.VirtualApplicationRoot());
            img.ToolTip = "Normal View";
            img.AlternateText = "Normal View";
            img.Attributes.Add("onclick", "SwitchToView('wysiwyg');");

            // ----------------------------------------------------------------

            trHtmlView = new TableRow();
            this.Controls.Add(trHtmlView);
            tblHTMLEditor.Rows.Add(trHtmlView);
            //trHtmlView.ID = string.Format("abkEditor_{0}_trHtmlView", this.ID);
            trHtmlView.Attributes.Add("ID", string.Format("abkEditor_{0}_trHtmlView", this.ID));

            td = new TableCell();
            this.Controls.Add(td);
            trHtmlView.Cells.Add(td);

            txtHtml = new TextBox();
            this.Controls.Add(txtHtml);
            td.Controls.Add(txtHtml);
            //txtHtml.ID = "txtHtml";

            //txtHtml.ID = string.Format("abkEditor_{0}_HtmlData", this.ID);
            txtHtml.Attributes.Add("ID", string.Format("abkEditor_{0}_HtmlData", this.ID));
            txtHtml.TextMode = TextBoxMode.MultiLine;
            txtHtml.Width = Unit.Percentage(100);
            txtHtml.Height = Unit.Pixel(300);
            //txtHtml.Width = Unit.Pixel(700);
            //txtHtml.Height = Unit.Pixel(300);
            txtHtml.Style.Add("width", "700px");


            txtText = new TextBox();
            this.Controls.Add(txtText);
            td.Controls.Add(txtText);
            //txtText.ID = "txtText";            

            //txtText.ID = string.Format("abkEditor_{0}_TextData", this.ID);
            txtText.Attributes.Add("ID", string.Format("abkEditor_{0}_TextData", this.ID));
            //txtText.TextMode = TextBoxMode.MultiLine;
            txtText.Style.Add("display", "none");
            //txtText.Width = Unit.Pixel( 400 );
            //txtText.Height = Unit.Pixel( 200 );

            // ----------------------------------------------------------------
            // Wysiwyg Toolbar
            // ----------------------------------------------------------------

            trWysiwygToolbar = new TableRow();
            this.Controls.Add(trWysiwygToolbar);
            tblHTMLEditor.Rows.Add(trWysiwygToolbar);
            //trWysiwygToolbar.ID = string.Format("abkEditor_{0}_trWysiwygToolbar", this.ID);
            trWysiwygToolbar.Attributes.Add("ID", string.Format("abkEditor_{0}_trWysiwygToolbar", this.ID));

            td = new TableCell();
            this.Controls.Add(td);
            trWysiwygToolbar.Cells.Add(td);
            td.Width = Unit.Pixel(710);

            img = new Image();
            this.Controls.Add(img);
            td.Controls.Add(img);
            ApplyEditorButtonStyle(img);
            img.ImageUrl = string.Format("{0}/Morphfolia/ABKEditor/g/iconEditorButtons_htmlview.gif", WebUtilities.VirtualApplicationRoot());
            img.ToolTip = "HTML View";
            img.AlternateText = "HTML View";
            img.Attributes.Add("onclick", "SwitchToView('html');");

            td.Controls.Add(CreateChildControl_EditorButtonSeperator());
            td.Controls.Add(CreateChildControl_EditorButton("Bold"));//, "FormatBlockElement('font-weight: 700;'); return false;"));
            td.Controls.Add(CreateChildControl_EditorButton("Underline"));//, "FormatBlockElement('text'); return false;"));
            td.Controls.Add(CreateChildControl_EditorButton("Italic"));//, "FormatBlockElement('font-style: italic;'); return false;"));
            td.Controls.Add(CreateChildControl_EditorButtonSeperator());
            td.Controls.Add(CreateChildControl_EditorButton("Indent"));
            td.Controls.Add(CreateChildControl_EditorButton("Outdent"));
            td.Controls.Add(CreateChildControl_EditorButtonSeperator());
            td.Controls.Add(CreateChildControl_EditorButton("JustifyLeft"));
            td.Controls.Add(CreateChildControl_EditorButton("JustifyCenter"));
            td.Controls.Add(CreateChildControl_EditorButton("JustifyRight"));
            td.Controls.Add(CreateChildControl_EditorButtonSeperator());
            td.Controls.Add(CreateChildControl_EditorButton("InsertOrderedList"));
            td.Controls.Add(CreateChildControl_EditorButton("InsertUnorderedList"));
            td.Controls.Add(CreateChildControl_EditorButtonSeperator());
            td.Controls.Add(CreateChildControl_EditorButton("CreateLink", "FormatActionMapper('CreateLink', '', true)"));
            td.Controls.Add(CreateChildControl_EditorButton("Unlink"));
            td.Controls.Add(CreateChildControl_EditorButtonSeperator());
            td.Controls.Add(CreateChildControl_EditorButton("InsertHorizontalRule"));
            td.Controls.Add(CreateChildControl_EditorButton("RemoveFormat"));


            trWysiwygView = new TableRow();
            this.Controls.Add(trWysiwygView);
            tblHTMLEditor.Rows.Add(trWysiwygView);
            //trWysiwygView.ID = string.Format("abkEditor_{0}_trWysiwygView", this.ID);
            trWysiwygView.Attributes.Add("ID", string.Format("abkEditor_{0}_trWysiwygView", this.ID));

            td = new TableCell();
            this.Controls.Add(td);
            trWysiwygView.Cells.Add(td);

            divWysiwygCanvas = new Panel();
            this.Controls.Add(divWysiwygCanvas);
            td.Controls.Add(divWysiwygCanvas);
            //divWysiwygCanvas.ID = string.Format("abkEditor_{0}_divWysiwygCanvas", this.ID);
            divWysiwygCanvas.Attributes.Add("ID", string.Format("abkEditor_{0}_divWysiwygCanvas", this.ID));

            divWysiwygCanvas.Attributes.Add("CONTENTEDITABLE", "true");
            //divWysiwygCanvas.Style.Add("width", "100%");
            divWysiwygCanvas.Style.Add("width", "700px");
            divWysiwygCanvas.Style.Add("height", "300px");
            divWysiwygCanvas.Style.Add("overflow", "scroll");
            divWysiwygCanvas.Style.Add("border", "1px solid #000000");
            divWysiwygCanvas.Style.Add("background-color", "white");
            divWysiwygCanvas.Attributes.Add("onMouseout", "PopulateHtmlView();");


            //---------------------------------------------------------------------------
            // ImageManager
            //---------------------------------------------------------------------------

            trImageManager = new TableRow();
            this.Controls.Add(trImageManager);
            tblHTMLEditor.Rows.Add(trImageManager);
            //trWysiwygView.Attributes.Add("ID", string.Format("abkEditor_{0}_trImageManager", this.ID));
            trImageManager.ID = "trImageManager";

            tdImageManager = new TableCell();
            this.Controls.Add(tdImageManager);
            trImageManager.Cells.Add(tdImageManager);

            imageManager = new Morphfolia.WebControls.ImageManager();
            this.Controls.Add(imageManager); // causes error in designer
            tdImageManager.Controls.Add(imageManager);
            imageManager.UseClientSideMode = true;
            imageManager.Width = Unit.Pixel(700);

            imageManager.ThumbnailImageDirectoryPath = Context.Server.MapPath(string.Format(@"{0}/{1}",
                WebUtilities.VirtualApplicationRoot(),
                Morphfolia.Common.Constants.Framework.Various.ThumbnailImageDirectoryPath));

            imageManager.MasterImageDirectoryPath = Context.Server.MapPath(string.Format(@"{0}/{1}",
                WebUtilities.VirtualApplicationRoot(),
                Morphfolia.Common.Constants.Framework.Various.MasterImageDirectoryPath));


            //---------------------------------------------------------------------------
            // FileManager
            //---------------------------------------------------------------------------

            trFileManager = new TableRow();
            this.Controls.Add(trFileManager);
            tblHTMLEditor.Rows.Add(trFileManager);
            trFileManager.ID = "trFileManager";

            tdFileManager = new TableCell();
            this.Controls.Add(tdFileManager);
            trFileManager.Cells.Add(tdFileManager);

            fileManager = new Morphfolia.WebControls.FileControls.FileManager();
            this.Controls.Add(fileManager);
            tdFileManager.Controls.Add(fileManager);
            fileManager.UseClientSideMode = true;
            fileManager.Width = Unit.Pixel(700);
            fileManager.FileListingFileDirectoryPath = Context.Server.MapPath(string.Format(@"{0}/{1}",
                WebUtilities.VirtualApplicationRoot(),
                Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath));
        }


        private void PopulateProperties()
        {
            if (this.txtHtml != null)
            {
                html = this.txtHtml.Text;
            }
        }


        /// <exclude />
        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                if (txtHtml.Text.Equals(string.Empty))
                {
                    txtHtml.Text = this.html;
                }

                tblHTMLEditor.Width = base.Width;
                this.txtHtml.Width = Width;
                this.divWysiwygCanvas.Width = Width;

                RenderChildren(writer);
            }
        }
    }
}