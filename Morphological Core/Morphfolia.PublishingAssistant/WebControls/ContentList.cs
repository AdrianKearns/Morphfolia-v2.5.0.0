// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{


    /// <summary>
    /// Summary description for ContentList
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class ContentList : WebControl, INamingContainer
    {
        private Table tblContentList;
        private TableRow trHeader;
        private TableRow trFilter;
        private TableRow tr;
        private TableCell td;
        private LinkButton lnkBtnEdit;
        private Button btnFilter;
        private TextBox txtNotesFilter;


        private ContentListInfoCollection contentListInfoCollection;
        public ContentListInfoCollection ContentListInfoCollection
        {
            get
            {
                if (contentListInfoCollection == null)
                {
                    contentListInfoCollection = new ContentListInfoCollection();
                }
                return contentListInfoCollection;
            }
            set { contentListInfoCollection = value; }
        }


        protected override void CreateChildControls()
        {
            Controls.Clear();

            tblContentList = new Table();
            Controls.Add(tblContentList);
            tblContentList.ID = "tblContentList";
            //tblContentList.Attributes.Add("border", "1");
            tblContentList.CellPadding = 5;
            tblContentList.CellSpacing = 0;


            ConstructAndAppendHeaderRow();

            ConstructAndAppendFilterRow();
        }


        private void ConstructAndAppendHeaderRow()
        {
            trHeader = new TableRow();
            tblContentList.Rows.Add(trHeader);
            trHeader.CssClass = "ListHeader";

            td = new TableCell();
            trHeader.Cells.Add(td);
            td.Text = "&nbsp;";

            td = new TableCell();
            trHeader.Cells.Add(td);
            td.Text = "ID";

            td = new TableCell();
            trHeader.Cells.Add(td);
            td.Text = "Note";

            td = new TableCell();
            trHeader.Cells.Add(td);
            td.Text = "Page Usage";

            td = new TableCell();
            trHeader.Cells.Add(td);
            td.Text = "Live?";

            td = new TableCell();
            trHeader.Cells.Add(td);
            td.Text = "Searchable?";

            td = new TableCell();
            trHeader.Cells.Add(td);
            td.Text = "Last Modified";

            td = new TableCell();
            trHeader.Cells.Add(td);
            td.Text = "Last Modified By";

        }


        private void ConstructAndAppendFilterRow()
        {
            trFilter = new TableRow();
            Controls.Add(trFilter);
            tblContentList.Rows.Add(trFilter);
            trFilter.ID = "trFilter";

            td = new TableCell();
            trFilter.Cells.Add(td);
            btnFilter = new Button();
            td.Controls.Add(btnFilter);
            td.ColumnSpan = 2;
            btnFilter.ID = "btnFilter";
            btnFilter.Text = "Filter";
            btnFilter.Click += new EventHandler(btnFilter_Click);

            td = new TableCell();
            trFilter.Cells.Add(td);
            txtNotesFilter = new TextBox();
            td.Controls.Add(txtNotesFilter);
            txtNotesFilter.ID = "txtNotesFilter";
            txtNotesFilter.Columns = 25;
            txtNotesFilter.MaxLength = 25;
            txtNotesFilter.Text = WebUtilities.GetRequestParamValue(txtNotesFilter.UniqueID);

            td = new TableCell();
            trFilter.Cells.Add(td);
            td.Text = "&nbsp;"; // page count

            td = new TableCell();
            trFilter.Cells.Add(td);
            td.Text = "&nbsp;"; //live

            td = new TableCell();
            trFilter.Cells.Add(td);
            td.Text = "&nbsp;"; //"Searchable?";

            td = new TableCell();
            trFilter.Cells.Add(td);
            td.Text = "&nbsp;"; //"Last Modified";

            td = new TableCell();
            trFilter.Cells.Add(td);
            td.Text = "&nbsp;"; //"Last Modified By";

        }


        //public delegate void Search();
        //public event Search OnSearchClicked;

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //string notesFilter = ParseLikeParameter(txtNotesFilter.Text);
            //ContentListInfoCollection = IContentDataProvider.Content_SELECT_List_Search(notesFilter);

            PopulateContentListInfoCollectionBasedOnFilters();

        }


        private void PopulateContentListInfoCollectionBasedOnFilters()
        {
            string notesFilter = ParseLikeParameter(txtNotesFilter.Text);
            ContentListInfoCollection = Morphfolia.Business.ContentItemHelper.Search(notesFilter);
        }


        private string ParseLikeParameter(string text)
        {
            text = text.Replace("*", "%");

            if (text.Equals(string.Empty))
            {
                text = "%";
            }

            if (text.IndexOf("%") == -1)
            {
                text = string.Format("%{0}%", text);
            }

            return text;
        }


        private void ConstructAndAppendContentItemRow(ContentListInfo contentListInfo)
        {
            tr = new TableRow();
            tblContentList.Rows.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);

            lnkBtnEdit = new LinkButton();
            td.Controls.Add(lnkBtnEdit);
            lnkBtnEdit.ID = "btnEdit" + contentListInfo.ContentID.ToString();
            lnkBtnEdit.Text = "Edit";
            lnkBtnEdit.Style.Add("font-weight", "700");

            if (contentListInfo.ContentType.MachineValue.Equals(Common.ContentTypes.MachineValues.BlogPost))
            {
                lnkBtnEdit.PostBackUrl = string.Format("AddBlogPost.aspx?c={0}", contentListInfo.ContentID.ToString());
            }
            else
            {
                lnkBtnEdit.PostBackUrl = string.Format("edit_content.aspx?c={0}", contentListInfo.ContentID.ToString());
            }

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = contentListInfo.ContentID.ToString();
            //td.Text = contentListInfo.ContentType.MachineValue;
            td.HorizontalAlign = HorizontalAlign.Right;

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = contentListInfo.Note;

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = contentListInfo.PageUsageCount.ToString();
            td.HorizontalAlign = HorizontalAlign.Right;


            td = new TableCell();
            tr.Cells.Add(td);
            td.HorizontalAlign = HorizontalAlign.Center;
            if (contentListInfo.IsLive)
            {
                td.Text = "<img src='../g/tickbox_ticked.gif' width='16' height='16' title='Yes' border='0'>";
            }
            else
            {
                td.Text = "<img src='../g/tickbox_empty.gif' width='16' height='16' title='No' border='0'>";
            }

            td = new TableCell();
            tr.Cells.Add(td);
            td.HorizontalAlign = HorizontalAlign.Center;
            if (contentListInfo.IsSearchable)
            {
                td.Text = "<img src='../g/tickbox_ticked.gif' width='16' height='16' title='Yes' border='0'>";
            }
            else
            {
                td.Text = "<img src='../g/tickbox_empty.gif' width='16' height='16' title='No' border='0'>";
            }

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = contentListInfo.LastModified.ToString();
            td.HorizontalAlign = HorizontalAlign.Right;

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = contentListInfo.LastModifiedBy;

        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                tblContentList.Rows.Clear();

                ConstructAndAppendHeaderRow();

                ConstructAndAppendFilterRow();

                if (ContentListInfoCollection.Count == 0)
                {
                    tr = new TableRow();
                    tblContentList.Rows.Add(tr);

                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Text = "No Content Items";
                    td.ColumnSpan = trHeader.Cells.Count;
                }
                else
                {
                    for (int i = 0; i < ContentListInfoCollection.Count; i++)
                    {
                        ConstructAndAppendContentItemRow(ContentListInfoCollection[i]);
                    }
                }

                tblContentList.Width = Width;
                tblContentList.Height = Height;
                tblContentList.RenderControl(writer);
            }
        }
    }
}