// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Constants;
using Morphfolia.Business;
using Morphfolia.Business.Logs;
using Morphfolia.Common.Info;
using System.ComponentModel;
using Morphfolia.WebControls.Designers;

namespace Morphfolia.WebControls
{
    [DesignerAttribute(typeof(DefaultDesigner))]
    public class AuditLogSearcher : WebControl, INamingContainer
    {
        int ObjectId = SystemTypeValues.NullInt;
        DateTime WhenLoggedRangeFrom = SystemTypeValues.NullDate;
        DateTime WhenLoggedRangeTill = DateTime.MaxValue;


        Table tblAuditLogSearcher;
        TableHeaderRow thr;
        TableHeaderCell thcHeading;
        //TableHeaderCell thc;
        TableRow tr;
        TableCell td;
        TableCell tdResults;
        AuditLogViewer auditLogResults;
        Label lblMsg;

        TextBox txtObjectId;
        Label lblObjectId;
        TextBox txtObjectType;
        TextBox txtAuditInformation;
        TextBox txtUserIdentity;
        TextBox txtWhenLoggedRangeFrom;
        TextBox txtWhenLoggedRangeTill;
        Button btnSearch;
        Label lblWhenLoggedRangeFrom;
        Label lblWhenLoggedRangeTill;

        AuditLogInfoCollection Items = new AuditLogInfoCollection();


        protected override void CreateChildControls()
        {
            tblAuditLogSearcher = new Table();
            Controls.Add(tblAuditLogSearcher);
            tblAuditLogSearcher.CellSpacing = 0;
            tblAuditLogSearcher.CellPadding = 3;
            tblAuditLogSearcher.CssClass = "FunctionalArea";

            thr = new TableHeaderRow();
            Controls.Add(thr);
            tblAuditLogSearcher.Rows.Add(thr);

            thcHeading = new TableHeaderCell();
            Controls.Add(thcHeading);
            thr.Cells.Add(thcHeading);
            thcHeading.Text = "Search Audit Logs";
            thcHeading.ColumnSpan = 2;


            txtObjectId = new TextBox();
            lblObjectId = new Label();
            AppendNewRow("Object ID", txtObjectId, lblObjectId);
            txtObjectId.ID = "txtObjectId";
            txtObjectId.Width = Unit.Pixel(50);

            txtObjectType = new TextBox();
            AppendNewRow("Object Type", txtObjectType);
            txtObjectType.ID = "txtObjectType";
            txtObjectType.Width = Unit.Pixel(200);

            txtAuditInformation = new TextBox();
            AppendNewRow("Audit Information", txtAuditInformation);
            txtAuditInformation.ID = "txtAuditInformation";
            txtAuditInformation.Width = Unit.Pixel(300);

            txtUserIdentity = new TextBox();
            AppendNewRow("User Identity", txtUserIdentity);
            txtUserIdentity.ID = "txtUserIdentity";
            txtUserIdentity.Width = Unit.Pixel(200);

            txtWhenLoggedRangeFrom = new TextBox();
            lblWhenLoggedRangeFrom = new Label();
            AppendNewRow("When Logged - From", txtWhenLoggedRangeFrom, lblWhenLoggedRangeFrom);
            txtWhenLoggedRangeFrom.ID = "txtWhenLoggedRangeFrom";
            txtWhenLoggedRangeFrom.Width = Unit.Pixel(200);

            txtWhenLoggedRangeTill = new TextBox();
            lblWhenLoggedRangeTill = new Label();
            AppendNewRow("When Logged - Until", txtWhenLoggedRangeTill, lblWhenLoggedRangeTill);
            txtWhenLoggedRangeTill.ID = "txtWhenLoggedRangeTill";
            txtWhenLoggedRangeTill.Width = Unit.Pixel(200);

            btnSearch = new Button();
            lblMsg = new Label();
            AppendNewRow("&nbsp;", btnSearch, lblMsg);
            btnSearch.ID = "btnSearch";
            btnSearch.Text = "Search";
            btnSearch.Click += new EventHandler(btnSearch_Click);

           


            tr = new TableRow();
            Controls.Add(tr);
            tblAuditLogSearcher.Rows.Add(tr);

            tdResults = new TableCell();
            Controls.Add(tdResults);
            tr.Cells.Add(tdResults);
            tdResults.ColumnSpan = 2;

            auditLogResults = new AuditLogViewer(AuditLogViewer.Mode.GeekAdmin);
            Controls.Add(auditLogResults);
            tdResults.Controls.Add(auditLogResults);
            auditLogResults.Visible = false;
        }

        /// <summary>
        /// Parses non-string type input and 
        /// notifies the user of input violations.
        /// </summary>
        /// <returns>bool - true for all good, false for input violations.</returns>
        private bool ParseInput()
        {
            string tempInputValue = txtObjectId.Text;
            if (tempInputValue.Equals(string.Empty))
            {
                lblMsg.Text = " Returning only the most recent 200 records.";
            }
            else
            {
                try
                {
                    ObjectId = int.Parse(tempInputValue);
                    lblObjectId.Text = string.Empty;
                    lblMsg.Text = " Returning all records for the Object Id.";
                }
                catch
                {
                    lblObjectId.Text = " The Object Id you supplied wasn't an integer.";
                    return false;
                }
            }

            tempInputValue = txtWhenLoggedRangeFrom.Text;
            if (!tempInputValue.Equals(string.Empty))
            {
                try
                {
                    WhenLoggedRangeFrom = DateTime.Parse(tempInputValue);
                    lblWhenLoggedRangeFrom.Text = string.Empty;                    
                }
                catch
                {
                    lblWhenLoggedRangeFrom.Text = "The date you supplied is not in a vaild date-time format.";
                    return false;
                }
            }

            tempInputValue = txtWhenLoggedRangeTill.Text;
            if (!tempInputValue.Equals(string.Empty))
            {
                try
                {
                    WhenLoggedRangeTill = DateTime.Parse(tempInputValue);
                    lblWhenLoggedRangeTill.Text = string.Empty;                 
                }
                catch
                {
                    lblWhenLoggedRangeTill.Text = "The date you supplied is not in a vaild date-time format.";
                    return false;
                }
            }

            return true;
        }


        void btnSearch_Click(object sender, EventArgs e)
        {
            auditLogResults.Visible = true;

            if (ParseInput())
            {
                auditLogResults.Items = AuditLogs.SearchAuditLogs(
                    ObjectId,
                    txtObjectType.Text,
                    txtAuditInformation.Text,
                    txtUserIdentity.Text,
                    string.Empty,
                    string.Empty,
                    WhenLoggedRangeFrom,
                    WhenLoggedRangeTill);
            }
        }


        private void AppendNewRow(string humanReadableNameOfInput, WebControl inputControl)
        {
            AppendNewRow(humanReadableNameOfInput, inputControl, null);
        }

        private void AppendNewRow(string humanReadableNameOfInput, WebControl inputControl, Label lblFeedBack)
        {
            tr = new TableRow();
            Controls.Add(tr);
            tblAuditLogSearcher.Rows.Add(tr);
            tr.VerticalAlign = VerticalAlign.Top;

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);
            td.Text = humanReadableNameOfInput;
            td.Width = Unit.Pixel(220);

            td = new TableCell();
            Controls.Add(td);
            tr.Cells.Add(td);

            Controls.Add(inputControl);
            td.Controls.Add(inputControl);

            if (lblFeedBack != null)
            {
                Controls.Add(lblFeedBack);
                td.Controls.Add(lblFeedBack);
            }
        }
    }
}
