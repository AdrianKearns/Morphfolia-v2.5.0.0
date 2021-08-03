// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Constants;
using Morphfolia.Common.Logging;
using Morphfolia.Business.Logs;
using Microsoft.Security.Application;

namespace Morphfolia.WebControls
{
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class SystemLogViewer : WebControl, INamingContainer
    {
        public DataGrid logGrid;

        private Label lblHeading;

        public string Message
        {
            get
            {
                EnsureChildControls();
                return lblHeading.Text;
            }
            set
            {
                EnsureChildControls();
                lblHeading.Text = value;
            }
        }

        protected override void CreateChildControls()
        {
            lblHeading = new Label();
            Controls.Add(lblHeading);
            lblHeading.ID = "lblHeading";

            logGrid = new DataGrid();
            Controls.Add(logGrid);
            logGrid.ID = "logGrid";
            logGrid.CellPadding = 5;
            logGrid.CellSpacing = 0;
            logGrid.ItemDataBound += new DataGridItemEventHandler(logGrid_ItemDataBound);
            logGrid.EnableViewState = false;
        }


        DateTime date1;
        string formattedData;
        void logGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            e.Item.Cells[0].VerticalAlign = VerticalAlign.Top;
            e.Item.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[1].VerticalAlign = VerticalAlign.Top;
            e.Item.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[2].VerticalAlign = VerticalAlign.Top;
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[3].VerticalAlign = VerticalAlign.Top;
            e.Item.Cells[4].VerticalAlign = VerticalAlign.Top;
            e.Item.Cells[5].VerticalAlign = VerticalAlign.Top;

            if (
                (e.Item.ItemType == ListItemType.Item)
                |(e.Item.ItemType == ListItemType.AlternatingItem))
            {
                formattedData = e.Item.Cells[5].Text;
                try
                {
                    date1 = DateTime.Parse(formattedData);
                    formattedData = string.Format("<nobr>{0} {1}</nobr>", date1.ToString("yyyy-MM-dd"), date1.ToString("hh:mm:ss.FFF"));
                }
                catch
                {
                    formattedData = string.Format("<nobr>{0}</nobr>", AntiXss.HtmlEncode(formattedData));
                }
                e.Item.Cells[5].Text = formattedData;
            }

            e.Item.Cells[6].VerticalAlign = VerticalAlign.Top;
            e.Item.Cells[7].VerticalAlign = VerticalAlign.Top;
            e.Item.Cells[8].VerticalAlign = VerticalAlign.Top;
            e.Item.Cells[8].Text = string.Format("<pre>{0}</pre>", AntiXss.HtmlEncode( e.Item.Cells[8].Text) );
        }


        private DataTable logEntries;
        public DataTable LogEntries
        {
            get { return logEntries; }
            set { logEntries = value; }
        }


        public void Search(SystemLogQuery systemLogQuery)
        {
            LogEntries = SystemLogs.GetLogEntries(systemLogQuery);
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Visible)
            {
                if (LogEntries == null)
                {
                    logGrid.Visible = false;
                }
                else
                {
                    DataView dv = new DataView(LogEntries);
                    logGrid.DataSource = dv;
                    logGrid.DataBind();

                    logGrid.Attributes.Add("border", "0");
                    logGrid.CssClass = "FunctionalArea";
                    logGrid.AlternatingItemStyle.CssClass = "zebra";
                    logGrid.HeaderStyle.CssClass = "ListHeader";
                }

                base.RenderContents(writer);
            }
        }
    }
}