// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using System.ComponentModel;
using Morphfolia.WebControls.Designers;

namespace Morphfolia.WebControls
{
    [DesignerAttribute(typeof(DefaultDesigner))]
    public class AuditLogViewer : WebControl, INamingContainer
    {
        Table tblAuditLogViewer;
        TableHeaderRow thr;
        TableHeaderCell thcHeading;
        TableHeaderCell thc;
        TableRow tr;
        TableCell td;

        /// <summary>
        /// Defines the modes in which the control can operate.
        /// </summary>
        public enum Mode { 
            /// <summary>
            /// Shows only info useful to average user.
            /// </summary>
            NonGeek, 
            /// <summary>
            /// Full log including AppDomain.
            /// </summary>
            GeekAdmin }


        private Mode CurrentModusOperandi;


        public AuditLogViewer(Mode mode)
        {
            CurrentModusOperandi = mode;
        }


        public string Heading
        {
            get
            {
                EnsureChildControls();
                return thcHeading.Text;
            }
            set
            {
                EnsureChildControls();
                thcHeading.Text = value;
            }
        }





        protected override void OnInit(System.EventArgs e)
        {
            base.CssClass = "AuditLogBox";
            base.OnInit(e);
        }


        protected override void CreateChildControls()
        {
            tblAuditLogViewer = new Table();
            Controls.Add(tblAuditLogViewer);
            tblAuditLogViewer.CellSpacing = 0;
            tblAuditLogViewer.CellPadding = 3;

            thr = new TableHeaderRow();
            Controls.Add(thr);
            tblAuditLogViewer.Rows.Add(thr);

            thcHeading = new TableHeaderCell();
            Controls.Add(thcHeading);
            thr.Cells.Add(thcHeading);
        }



        private AuditLogInfoCollection items = new AuditLogInfoCollection();
        public AuditLogInfoCollection Items
        {
            get { return items; }
            set { items = value; }
        }


        private void PopulateForNonGeeks()
        {
            if (Items.Count == 0)
            {
                tr = new TableRow();
                Controls.Add(tr);
                tblAuditLogViewer.Rows.Add(tr);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                td.Text = "No audit log entries found.";
            }
            else
            {
                AuditLogInfo info;

                thcHeading.ColumnSpan = 3;

                thr = new TableHeaderRow();
                Controls.Add(thr);
                tblAuditLogViewer.Rows.Add(thr);
                thr.VerticalAlign = VerticalAlign.Top;

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "What";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "When";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "Who";

                for (int i = 0; i < Items.Count; i++)
                {
                    info = Items[i];

                    tr = new TableRow();
                    Controls.Add(tr);
                    tblAuditLogViewer.Rows.Add(tr);
                    tr.VerticalAlign = VerticalAlign.Top;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = info.Information;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = string.Format("<nobr>{0}</nobr>", info.WhenLogged.ToString());

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = info.UserIdentity;
                }
            }
        }


        private void PopulateForGeekyAdmins()
        {
            if (Items.Count == 0)
            {
                tr = new TableRow();
                Controls.Add(tr);
                tblAuditLogViewer.Rows.Add(tr);

                td = new TableCell();
                Controls.Add(td);
                tr.Cells.Add(td);
                td.Text = "No audit log entries found.";
            }
            else
            {
                AuditLogInfo info;

                thcHeading.ColumnSpan = 8;

                thr = new TableHeaderRow();
                Controls.Add(thr);
                tblAuditLogViewer.Rows.Add(thr);
                thr.VerticalAlign = VerticalAlign.Top;

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "<nobr>Audit Id</nobr>";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "<nobr>Object Id</nobr>";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "<nobr>Object Type</nobr>";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "<nobr>Audit Info</nobr>";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "<nobr>When Logged</nobr>";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "<nobr>User Identity</nobr>";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "<nobr>Windows Identity</nobr>";

                thc = new TableHeaderCell();
                Controls.Add(thc);
                thr.Cells.Add(thc);
                thc.Text = "AppDomain";

                for (int i = 0; i < Items.Count; i++)
                {
                    info = Items[i];

                    tr = new TableRow();
                    Controls.Add(tr);
                    tblAuditLogViewer.Rows.Add(tr);
                    tr.VerticalAlign = VerticalAlign.Top;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = info.AuditLogId.ToString();
                    td.HorizontalAlign = HorizontalAlign.Right;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = info.ObjectId.ToString();
                    td.HorizontalAlign = HorizontalAlign.Right;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = string.Format("<nobr>{0}</nobr>", info.ObjectType);

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = info.Information;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = string.Format("<nobr>{0}</nobr>", info.WhenLogged.ToString());

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = info.UserIdentity;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = info.WindowsIdentity;

                    td = new TableCell();
                    Controls.Add(td);
                    tr.Cells.Add(td);
                    td.Text = info.AppDomainName;
                }
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                switch (CurrentModusOperandi)
                {
                    case Mode.GeekAdmin:
                        PopulateForGeekyAdmins();
                        break;

                    case Mode.NonGeek:
                        PopulateForNonGeeks();
                        break;

                    default:
                        PopulateForNonGeeks();
                        break;
                }

                base.RenderContents(writer);
            }
        }
    }
}
