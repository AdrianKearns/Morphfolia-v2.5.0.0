// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Morphfolia.Business;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Represents a content item that has been assigned to a page via a specific ContentContainerDropBox.
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class ActiveContentNode : WebControl
    {
        private Table tblActiveContentNode;
        private TableRow tr;
        private TableCell tdContentId;
        private TableCell td;
        private TableCell tdNote;
        //private HtmlAnchor hypPreview;
        private HtmlAnchor hypEdit;
        private Image imgIsLive;
        private Image imgIsSearchable;
        private Image imgUp;
        private Image imgDown;
        private Image imgRemove;


        private ContentListInfo content = new ContentListInfo();
        public ContentListInfo Content
        {
            get { return content; }
            set { content = value; }
        }


        protected override void CreateChildControls()
        {
            this.EnableViewState = false;

            tblActiveContentNode = new Table();
            Controls.Add(tblActiveContentNode);
            tblActiveContentNode.CellPadding = 3;
            tblActiveContentNode.CellSpacing = 0;
            tblActiveContentNode.CssClass = "ActiveContentNode";
            tblActiveContentNode.Width = Unit.Percentage(100);


            tr = new TableRow();
            tblActiveContentNode.Controls.Add(tr);
            tr.CssClass = "ActiveContentNodeToolbar";

            tdContentId = new TableCell();
            tr.Cells.Add(tdContentId);
            tdContentId.VerticalAlign = VerticalAlign.Top;
            tdContentId.HorizontalAlign = HorizontalAlign.Right;
            tdContentId.Width = Unit.Pixel(30);

            //td = new TableCell();
            //tr.Cells.Add(td);
            //td.VerticalAlign = VerticalAlign.Top;
            //hypPreview = new HtmlAnchor();
            //td.Controls.Add(hypPreview);
            //hypPreview.InnerText = "Preview";
            //hypPreview.HRef = "#";

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;
            td.HorizontalAlign = HorizontalAlign.Center;
            td.Width = Unit.Pixel(16);
            imgIsLive = new Image();
            td.Controls.Add(imgIsLive);
            imgIsLive.Style.Add("background-color", "#ffffff");            


            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;
            td.HorizontalAlign = HorizontalAlign.Center;
            td.Width = Unit.Pixel(16);
            imgIsSearchable = new Image();
            td.Controls.Add(imgIsSearchable);
            imgIsSearchable.Style.Add("background-color", "#ffffff");



            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;
            td.HorizontalAlign = HorizontalAlign.Center;
            td.Width = Unit.Pixel(16);
            imgUp = new Image();
            td.Controls.Add(imgUp);
            imgUp.ImageUrl = "../g/icon_moveUp.jpg";
            imgUp.Attributes.Add("title", "Click to re-order the content within the content drop box.");
            imgUp.Style.Add("cursor", "hand");
            imgUp.Attributes.Add("onclick", "MoveActiveContentNodeUpOrDown( this, 'up' );");

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;
            td.HorizontalAlign = HorizontalAlign.Center;
            td.Width = Unit.Pixel(16);
            imgDown = new Image();
            td.Controls.Add(imgDown);
            imgDown.ImageUrl = "../g/icon_moveDown.jpg";
            imgDown.ToolTip = "Click to re-order the content within the content drop box.";
            imgDown.Style.Add("cursor", "hand");
            imgDown.Attributes.Add("onclick", "MoveActiveContentNodeUpOrDown( this, 'down' );");

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;
            td.HorizontalAlign = HorizontalAlign.Center;
            td.Width = Unit.Pixel(16);
            imgRemove = new Image();
            td.Controls.Add(imgRemove);
            imgRemove.ImageUrl = "../g/icon_Remove.jpg";
            imgRemove.ToolTip = "Click to remove from the content drop box.";
            imgRemove.Style.Add("cursor", "hand");
            imgRemove.Attributes.Add("onclick", "RemoveActiveContentNodeFromCanvas( this );");

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;
            td.HorizontalAlign = HorizontalAlign.Left;
            td.Width = Unit.Percentage(100);
            hypEdit = new HtmlAnchor();
            td.Controls.Add(hypEdit);
            hypEdit.InnerText = "Edit";
            hypEdit.Target = "_blank";


            tr = new TableRow();
            tblActiveContentNode.Controls.Add(tr);

            tdNote = new TableCell();
            tr.Cells.Add(tdNote);
            tdNote.ColumnSpan = 7;
            tdNote.Width = Unit.Percentage(100);
        }



        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Content.ContentID != Common.Constants.SystemTypeValues.NullInt)
            {
                tblActiveContentNode.Attributes.Add("title", string.Format("Item {0}", Content.ContentID.ToString()));
                tblActiveContentNode.Attributes.Add("id", string.Format("tbl_{0}", Content.ContentID.ToString()));
                tdContentId.Text = Content.ContentID.ToString();
                //hypPreview.Attributes.Add("onclick", string.Format("PreviewContentItem({0}); return false;", Content.ContentID.ToString()));
                hypEdit.HRef = string.Format("edit_content.aspx?c={0}", Content.ContentID.ToString());
                imgUp.Attributes.Add("name", string.Format("img_{0}", Content.ContentID.ToString()));
                imgDown.Attributes.Add("name", string.Format("img_{0}", Content.ContentID.ToString()));
                imgRemove.Attributes.Add("name", string.Format("img_{0}", Content.ContentID.ToString()));
                tdNote.Text = Content.Note;

                if (Content.IsLive)
                {
                    imgIsLive.ImageUrl = "../g/tickbox_ticked.gif";
                    imgIsLive.ToolTip = "Is live";
                }
                else
                {
                    imgIsLive.ImageUrl = "../g/tickbox_empty.gif";
                    imgIsLive.ToolTip = "Is not live";
                }

                if (Content.IsSearchable)
                {
                    imgIsSearchable.ImageUrl = "../g/tickbox_ticked.gif";
                    imgIsSearchable.ToolTip = "Is searchable";
                }
                else
                {
                    imgIsSearchable.ImageUrl = "../g/tickbox_empty.gif";
                    imgIsSearchable.ToolTip = "Is not searchable";
                }
            }

            base.RenderContents(writer);
        }
    }
}