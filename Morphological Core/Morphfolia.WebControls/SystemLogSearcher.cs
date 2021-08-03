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
using Morphfolia.Business;
using Morphfolia.Business.Logs;

namespace Morphfolia.WebControls
{
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class SystemLogSearcher : WebControl, INamingContainer
    {
        Table tblSearchCriteria;
        TableHeaderRow thr;
        TableHeaderCell thcHeading;
        TableRow tr;
        TableCell td;
        TextBox txtMaxResults;
        TextBox txtEventId;
        TextBox txtMinimumPriority;
        TextBox txtSeverity;
        TextBox txtTitleFilter;
        TextBox txtMessageFilter;
        TextBox txtLoggedSince;
        TextBox txtLoggedBefore;
        Button btnSearch;
        Button btnSearchAndSave;


        private SystemLogViewer logListViewer;
        public SystemLogViewer LinkedLogListViewer
        {
            get { return logListViewer; }
            set { logListViewer = value; }
        }


        private void tblSearchCriteriaRowAdder(WebControl wc, string text)
        {
            tr = new TableRow();
            Controls.Add(tr);
            tblSearchCriteria.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = text;

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            Controls.Add(wc);
            td.Controls.Add(wc);
            td.ColumnSpan = 4;
        }

        private void tblSearchCriteriaRowAdder(WebControl wc1, string text1, WebControl wc2, string text2)
        {
            tr = new TableRow();
            Controls.Add(tr);
            tblSearchCriteria.Rows.Add(tr);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = text1;

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            Controls.Add(wc1);
            td.Controls.Add(wc1);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = "&nbsp;";

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = text2;

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            Controls.Add(wc2);
            td.Controls.Add(wc2);
        }


        protected override void CreateChildControls()
        {
            tblSearchCriteria = new Table();
            Controls.Add(tblSearchCriteria);
            tblSearchCriteria.ID = "tblSearchCriteria";
            //tblSearchCriteria.Attributes.Add("border", "1");
            tblSearchCriteria.CellPadding = 3;
            tblSearchCriteria.CellSpacing = 0;
            tblSearchCriteria.CssClass = "FunctionalArea";

            thr = new TableHeaderRow();
            Controls.Add(thr);
            tblSearchCriteria.Rows.Add(thr);

            thcHeading = new TableHeaderCell();
            Controls.Add(thcHeading);
            thr.Cells.Add(thcHeading);
            thcHeading.Text = "Search System Logs";
            thcHeading.ColumnSpan = 5;


            txtEventId = new TextBox();
            txtMinimumPriority = new TextBox();
            tblSearchCriteriaRowAdder(txtEventId, "Event Id", txtMinimumPriority, "Minimum Priority");

            txtEventId.ID = "txtEventId";
            txtEventId.Columns = 7;
            txtEventId.ToolTip = "Event Id";

            txtMinimumPriority.ID = "txtMinimumPriority";
            txtMinimumPriority.Columns = 7;
            txtMinimumPriority.ToolTip = "Minimum Priority";

            
            txtSeverity = new TextBox();
            tblSearchCriteriaRowAdder(txtSeverity, "Severity");
            txtSeverity.ID = "txtSeverity";
            txtSeverity.Columns = 30;
            txtSeverity.ToolTip = "Severity";


            txtTitleFilter = new TextBox();
            tblSearchCriteriaRowAdder(txtTitleFilter, "Title Filter");
            txtTitleFilter.ID = "txtTitleFilter";
            txtTitleFilter.Columns = 30;
            txtTitleFilter.ToolTip = "Title Filter";

            txtMessageFilter = new TextBox();
            tblSearchCriteriaRowAdder(txtMessageFilter, "Message Filter");
            txtMessageFilter.ID = "txtMessageFilter";
            txtMessageFilter.Columns = 30;
            txtMessageFilter.ToolTip = "Message Filter";


            txtLoggedSince = new TextBox();
            tblSearchCriteriaRowAdder(txtLoggedSince, "Logged Since");
            txtLoggedSince.ID = "txtLoggedSince";
            txtLoggedSince.Columns = 30;
            txtLoggedSince.ToolTip = "Restrict results to entries that occurred on or after this date/time.";

            txtLoggedBefore = new TextBox();
            tblSearchCriteriaRowAdder(txtLoggedBefore, "Logged Before");
            txtLoggedBefore.ID = "txtLoggedBefore";
            txtLoggedBefore.Columns = 30;
            txtLoggedBefore.ToolTip = "Restrict results to entries that occurred on or before this date/time.";



            txtMaxResults = new TextBox();
            btnSearch = new Button();

            tblSearchCriteriaRowAdder(txtMaxResults, "Max Results", btnSearch, "&nbsp;");

            txtMaxResults.ID = "txtMaxResults";
            txtMaxResults.Columns = 7;
            txtMaxResults.ToolTip = "The maximum number of records you want returned.";

            btnSearch.ID = "btnSearch";
            btnSearch.Text = "Search";
            btnSearch.Click += new EventHandler(btnSearch_Click);


            btnSearchAndSave = new Button();
            tblSearchCriteriaRowAdder(btnSearchAndSave, "Search & Save");
            btnSearchAndSave.ID = "btnSearchAndSave";
            btnSearchAndSave.Text = "Save";
            btnSearchAndSave.Click += new EventHandler(btnSearchAndSave_Click);


            if (Page != null)
            {
                if (!Page.IsPostBack)
                {
                    txtMaxResults.Text = "50";
                    txtMinimumPriority.Text = "0";
                }
            }
        }

        void btnSearchAndSave_Click(object sender, EventArgs e)
        {
            SystemLogQuery systemLogQuery = new SystemLogQuery(
                Utilities.InputValidator.StringToSearchSafeInt(txtMaxResults.Text, 50),
                Utilities.InputValidator.StringToSearchSafeInt(txtEventId.Text, Morphfolia.Common.Constants.SystemTypeValues.NullInt),
                Utilities.InputValidator.StringToSearchSafeInt(txtMinimumPriority.Text, 0),
                txtSeverity.Text,
                string.Empty,
                txtTitleFilter.Text,
                txtMessageFilter.Text,
                Utilities.InputValidator.StringToSafeDateTime(txtLoggedSince.Text),
                Utilities.InputValidator.StringToSafeDateTime(txtLoggedBefore.Text));

            DataTable results = SystemLogs.GetLogEntries(systemLogQuery);

            string destinationFolderPath = string.Format(@"{0}/{1}",
                WebControls.Utilities.WebUtilities.VirtualApplicationRoot(),
                Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath);

            string mappedDestinationFolderPath = Context.Server.MapPath(destinationFolderPath);

            //LinkedLogListViewer.Message = SystemLogs.SaveLogEntriesToDisk(results, destinationFolderPath);
            string filename = SystemLogs.SaveLogEntriesToDisk(results, mappedDestinationFolderPath);

            LinkedLogListViewer.Message = string.Format("Logs saved to the File Manager as <a href='{0}/{1}' target='_blank'>{1}</a>.", destinationFolderPath, filename);
        }






        void btnSearch_Click(object sender, EventArgs e)
        {
            SystemLogQuery systemLogQuery = new SystemLogQuery(
                Utilities.InputValidator.StringToSearchSafeInt(txtMaxResults.Text, 50),
                Utilities.InputValidator.StringToSearchSafeInt(txtEventId.Text, Morphfolia.Common.Constants.SystemTypeValues.NullInt),
                Utilities.InputValidator.StringToSearchSafeInt(txtMinimumPriority.Text, 0),
                txtSeverity.Text, 
                string.Empty, 
                txtTitleFilter.Text, 
                txtMessageFilter.Text,
                Utilities.InputValidator.StringToSafeDateTime(txtLoggedSince.Text),
                Utilities.InputValidator.StringToSafeDateTime(txtLoggedBefore.Text));

            LinkedLogListViewer.Search(systemLogQuery);
        }


    }
}