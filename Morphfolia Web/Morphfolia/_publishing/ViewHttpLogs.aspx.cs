// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.IO;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using Morphfolia.Business.Logs;
using Morphfolia.Common.Info;
using Morphfolia.WebControls.Utilities;
using Morphfolia.Common.Constants.Framework;

public partial class Morphfolia__publishing_ViewHttpLogs : System.Web.UI.Page
{
    private HttpLogQuery httpLogQuery;
    private HttpLogEntryInfoCollection collection;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            txtUrl.Text = HttpRequestHelper.GetRequestQueryStringValue(RequestKeys.RequestedUrl);
            txtRefererUrl.Text = HttpRequestHelper.GetRequestQueryStringValue(RequestKeys.RefererUrl);
            txtMiscInfo.Text = HttpRequestHelper.GetRequestQueryStringValue(RequestKeys.MiscInfo);
            txtSessionId.Text = HttpRequestHelper.GetRequestQueryStringValue(RequestKeys.SessionId);
            txtUserHostAddress.Text = HttpRequestHelper.GetRequestQueryStringValue(RequestKeys.UserHostAddress);

            txtDateFrom.Text = HttpRequestHelper.GetRequestQueryStringValue(RequestKeys.WhenFrom);
            if (txtDateFrom.Text.Equals(string.Empty))
            {
                //txtDateFrom.Text = string.Format("{0} 00:00:00", System.DateTime.Now.AddDays(-1).ToShortDateString());
                txtDateFrom.Text = System.DateTime.Now.AddHours(-24).ToString();
                //txtDateFrom.Text = System.DateTime.Now.ToShortDateString();
            }

            txtDateTill.Text = HttpRequestHelper.GetRequestQueryStringValue(RequestKeys.WhenUntil);
            //if (txtDateTill.Text.Equals(string.Empty))
            //{
            //    txtDateTill.Text = string.Format("{0} 23:59:59", System.DateTime.Now.ToShortDateString());
            //}
        }
    }




    private static int StringToSearchSafeInt(string stringWeExpectToBeNumeric)
    {
        int output;

        if(int.TryParse(stringWeExpectToBeNumeric, out output))
        {
            return output;
        }
        else
        {
            return Morphfolia.Common.Constants.SystemTypeValues.NullInt;
        }
    }


    private static DateTime StringToSafeDateTime(string stringWeExpectToBeDateTime, DateTime valueToUseIfError)
    {
        DateTime output;

        if (DateTime.TryParse(stringWeExpectToBeDateTime, out output))
        {
            return output;
        }
        else
        {
            return valueToUseIfError;
        }
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        httpLogQuery = new HttpLogQuery(
            txtUrl.Text,
            txtRefererUrl.Text,
            txtSessionId.Text,
            txtUserHostAddress.Text,
            txtMiscInfo.Text,
            StringToSafeDateTime(txtDateFrom.Text, DateTime.MinValue),
            StringToSafeDateTime(txtDateTill.Text, DateTime.Now.AddHours(1)));
        collection = HttpLogs.GetHistory(httpLogQuery);

        DisplayResults();
    }



    private void DisplayResults()
    {
        pnlResults.Controls.Clear();

        if (collection.Count == 0)
        {
            Label lbl = new Label();
            pnlResults.Controls.Add(lbl);
            lbl.Text = "No log entries returned.";
        }
        else
        {
            Label lbl = new Label();
            pnlResults.Controls.Add(lbl);
            lbl.Text = string.Format("{0} log entries returned.", collection.Count.ToString());


            TableRow tr;
            TableCell td;
            HyperLink hyp;
            Table tbl = new Table();
            tbl.EnableViewState = false;
            pnlResults.Controls.Add(tbl);
            tbl.CellPadding = 5;
            tbl.CellSpacing = 0;
            tbl.CssClass = "FunctionalArea";

            bool zebra = true;


            tr = new TableRow();
            tbl.Rows.Add(tr);
            tr.CssClass = "ListHeader";

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "LogId";
            td.HorizontalAlign = HorizontalAlign.Right;

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Time Logged";

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "UserHostName";

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Session Id";

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Url";

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Url Referrer";

            td = new TableCell();
            tr.Cells.Add(td);
            td.Text = "Misc Info";
            td.Width = Unit.Pixel(220);


            foreach (HttpLogEntryInfo info in collection)
            {
                tr = new TableRow();
                tbl.Rows.Add(tr);

                if (zebra)
                {
                    zebra = false;
                    tr.CssClass = "zebra";
                }
                else
                {
                    zebra = true;
                }

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.LogId.ToString();
                td.VerticalAlign = VerticalAlign.Top;
                td.HorizontalAlign = HorizontalAlign.Right;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = string.Format("<nobr>{0}</nobr>", info.TimeLogged.ToString());
                td.VerticalAlign = VerticalAlign.Top;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = info.UserHostName.ToString();
                td.VerticalAlign = VerticalAlign.Top;

                td = new TableCell();
                tr.Cells.Add(td);
                td.VerticalAlign = VerticalAlign.Top;
                hyp = new HyperLink();
                td.Controls.Add(hyp);
                hyp.Text = info.SessionId.ToString();
                hyp.NavigateUrl = string.Format("SessionHistoryViewer.aspx?{0}={1}", RequestKeys.SessionId, info.SessionId.ToString());
                hyp.ToolTip = "Open this session in the session viewer.";
                hyp.Target = "_blank";

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = AntiXss.HtmlEncode(info.Url.ToString());
                td.VerticalAlign = VerticalAlign.Top;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = AntiXss.HtmlEncode(info.UrlReferrer.ToString());
                td.VerticalAlign = VerticalAlign.Top;

                td = new TableCell();
                tr.Cells.Add(td);
                td.Text = AntiXss.HtmlEncode( info.MiscInfo.ToString() );
                td.VerticalAlign = VerticalAlign.Top;
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {     
        try
        {
            pnlResults.Controls.Clear();


            httpLogQuery = new HttpLogQuery(
                txtUrl.Text,
                txtRefererUrl.Text,
                txtSessionId.Text,
                txtUserHostAddress.Text,
                txtMiscInfo.Text,
                StringToSafeDateTime(txtDateFrom.Text, DateTime.MinValue),
                StringToSafeDateTime(txtDateTill.Text, DateTime.Now.AddHours(1)));
            collection = HttpLogs.GetHistory(httpLogQuery);


            string filename = string.Empty;

            if (collection.Count == 1)
            {
                filename = string.Format("Http Log item {0) Logged {1}.csv",
                    Morphfolia.Common.Utilities.DateTimeHelper.DDMMMYYYY(collection[0].TimeLogged),
                    Morphfolia.Common.Utilities.DateTimeHelper.YYYYMMDDHHMMSS_HumanReadable(DateTime.Now));
            }
            else
            {
                filename = string.Format("Http Logs from {0} to {1} - {2} Items Logged {3}.csv",
                    Morphfolia.Common.Utilities.DateTimeHelper.DDMMMYYYY(collection[collection.Count - 1].TimeLogged),
                    Morphfolia.Common.Utilities.DateTimeHelper.DDMMMYYYY(collection[0].TimeLogged),
                    collection.Count.ToString(),
                    Morphfolia.Common.Utilities.DateTimeHelper.YYYYMMDDHHMMSS_HumanReadable(DateTime.Now));
            }


            string destinationFolderPath = Context.Server.MapPath(string.Format(@"{0}/{1}",
                        Morphfolia.WebControls.Utilities.WebUtilities.VirtualApplicationRoot(),
                        Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath));

            string fullFilename = string.Format(@"{0}/{1}",
                        destinationFolderPath,
                        filename);


            string temp;

            using (StreamWriter sw = new StreamWriter(fullFilename))
            {
                foreach(HttpLogEntryInfo info in collection)
                {
                    temp = info.Url.Replace(",", ".");
                    temp = temp.Replace(Environment.NewLine, " ");

                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
                        info.LogId.ToString(),
                        info.TimeLogged.ToString().Replace(",", "."),
                        info.UserHostName,
                        info.SessionId,
                        info.Url.Replace(",", "."),
                        info.UrlReferrer.Replace(",", "."),
                        info.MiscInfo.Replace(",", "."));
                }
            }

            string downloadUrl = string.Format(@"{0}/{1}/{2}",
                WebUtilities.VirtualApplicationRoot(),
                Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath,
                filename);

            Label lbl = new Label();
            pnlResults.Controls.Add(lbl);
            lbl.Text = string.Format("Logs saved to the File Manager as <a href='{0}' target='_blank'>{1}</a>.", downloadUrl, filename);

        }
        catch (Exception ex)
        {
            Morphfolia.Common.Logging.Logger.LogException("btnSave_Click() failed.", ex);

            Label lbl = new Label();
            pnlResults.Controls.Add(lbl);
            lbl.Text = "Save Log Entries Failed - see system logs.";
        }        
    }
}