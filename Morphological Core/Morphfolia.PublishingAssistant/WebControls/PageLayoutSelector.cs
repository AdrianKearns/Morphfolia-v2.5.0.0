// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Morphfolia.PublishingSystem.WebControls
{
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class PageLayoutSelector : WebControl, INamingContainer
    {
        public delegate void OnLayoutSelected(string foo);
        public event OnLayoutSelected LayoutSelected;


        public string GetSelectedLayout()
        {
            EnsureChildControls();
            if (ddlLayouts.SelectedValue == null)
            {
                return string.Empty;
            }
            else
            {
                return ddlLayouts.SelectedValue;
            }
        }

        public void SetSelectedLayout(string semiQualifiedName)
        {
            EnsureChildControls();

            foreach (ListItem i in ddlLayouts.Items)
            {
                if (i.Value.Equals(semiQualifiedName))
                {
                    i.Selected = true;
                    break;
                }
            }

            ddlLayouts_SelectedIndexChanged(null, null);
        }


        private Table tblPageLayoutSelector;
        private TableRow tr;
        private TableCell td;
        private Literal br;

        protected Label lblDDLMsg;
        protected DropDownList ddlLayouts;
        protected Image imgSelectedLayoutIcon;

        private StringCollection availableLayoutWebControls = null;
        protected StringCollection AvailableLayoutWebControls
        {
            get
            {
                if (availableLayoutWebControls == null)
                {
                    availableLayoutWebControls = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableLayoutWebControls();
                }
                return availableLayoutWebControls;
            }
        }


        private void PopulateDdlLayouts()
        {
            string[] parts;
            string tempPart1;
            string humanReadableName;
            string semiQualifiedName;
            string xxx = string.Empty;
            for (int i = 0; i < AvailableLayoutWebControls.Count; i++)
            {
                parts = AvailableLayoutWebControls[i].Split(Common.Constants.Framework.Various.SpaceChar);

                if (parts.Length > 0)
                {
                    humanReadableName = parts[0].Remove(parts[0].Length - 1);
                    humanReadableName = humanReadableName.Substring(humanReadableName.LastIndexOf(".") + 1);
                    humanReadableName = string.Format(" * {0}", humanReadableName);

                    tempPart1 = parts[1].Remove(parts[1].Length - 1);

                    if (!xxx.Equals(tempPart1))
                    {
                        xxx = tempPart1;
                        ddlLayouts.Items.Add(new ListItem(" ", Morphfolia.Common.Constants.Framework.Various.PleaseSelect));

                        ddlLayouts.Items.Add(new ListItem(tempPart1, Morphfolia.Common.Constants.Framework.Various.PleaseSelect));
                    }

                    semiQualifiedName = string.Format("{0} {1}", parts[0], tempPart1);
                    ddlLayouts.Items.Add(new ListItem(humanReadableName, semiQualifiedName));
                }
            }

            if (ddlLayouts.Items.Count == 0)
            {
                ddlLayouts.Items.Insert(0, new ListItem(Morphfolia.Common.Constants.Framework.Various.NoneAvailable));

                Logging.Logger.LogWarning("PageLayoutSelector", "ddlLayouts.Items.Count == 0", 666); // XXX WebsiteEventIds._1202);                
            }
            else
            {
                ddlLayouts.Items.Insert(0, new ListItem(Morphfolia.Common.Constants.Framework.Various.PleaseSelect));
            }
        }


        protected override void CreateChildControls()
        {
            tblPageLayoutSelector = new Table();
            Controls.Add(tblPageLayoutSelector);
            tblPageLayoutSelector.ID = "tblPageLayoutSelector";
            tblPageLayoutSelector.CellPadding = 5;
            tblPageLayoutSelector.CellSpacing = 0;
            //tblPageLayoutSelector.Attributes.Add("border", "1");
            tblPageLayoutSelector.Width = Unit.Percentage(100);
            tblPageLayoutSelector.CssClass = "FunctionalArea";


            tr = new TableRow();
            tblPageLayoutSelector.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;

            lblDDLMsg = new Label();
            Controls.Add(lblDDLMsg);
            td.Controls.Add(lblDDLMsg);
            lblDDLMsg.Text = "Please select a Layout:";

            br = new Literal();
            Controls.Add(br);
            td.Controls.Add(br);
            br.Text = "<br>";

            ddlLayouts = new DropDownList();
            Controls.Add(ddlLayouts);
            td.Controls.Add(ddlLayouts);
            ddlLayouts.ID = "ddlLayouts";
            ddlLayouts.SelectedIndexChanged += new EventHandler(ddlLayouts_SelectedIndexChanged);
            ddlLayouts.AutoPostBack = true;

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;

            imgSelectedLayoutIcon = new Image();
            Controls.Add(imgSelectedLayoutIcon);
            td.Controls.Add(imgSelectedLayoutIcon);
            imgSelectedLayoutIcon.ID = "imgSelectedLayoutIcon";
            imgSelectedLayoutIcon.Width = Unit.Pixel(100);
            imgSelectedLayoutIcon.Height = Unit.Pixel(100);
            imgSelectedLayoutIcon.Style.Add("background-image", "url('../g/LayoutIconMissing.jpg')");

            if (ddlLayouts.Items.Count == 0)
            {
                PopulateDdlLayouts();
            }
        }


        void ddlLayouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlLayouts.SelectedValue.Equals(string.Empty)) | (ddlLayouts.SelectedValue.Equals(Morphfolia.Common.Constants.Framework.Various.PleaseSelect)))
            {
                imgSelectedLayoutIcon.ToolTip = string.Empty;
                imgSelectedLayoutIcon.ImageUrl = string.Format("{0}/Morphfolia/g/spacer.gif", Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot());

                if (LayoutSelected != null)
                {
                    LayoutSelected(string.Empty);
                }
            }
            else
            {
                imgSelectedLayoutIcon.ToolTip = ddlLayouts.SelectedValue;
                imgSelectedLayoutIcon.ImageUrl = string.Format("{0}/Morphfolia/g/{1}.jpg", Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot(), ddlLayouts.SelectedValue);

                if (LayoutSelected != null)
                {
                    LayoutSelected(ddlLayouts.SelectedValue);
                }
            }       
        }
    }
}
