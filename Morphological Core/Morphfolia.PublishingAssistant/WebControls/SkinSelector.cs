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
    public class SkinSelector : WebControl, INamingContainer
    {
        public delegate void OnSkinSelected(string foo);
        public event OnSkinSelected SkinSelected;


        public string GetSelectedSkin()
        {
            EnsureChildControls();
            if (ddlSkins.SelectedValue == null)
            {
                return string.Empty;
            }
            else
            {
                return ddlSkins.SelectedValue;
            }
        }

        public void SetSelectedSkin(string semiQualifiedName)
        {
            EnsureChildControls();

            foreach (ListItem i in ddlSkins.Items)
            {
                if (i.Value.Equals(semiQualifiedName))
                {
                    i.Selected = true;
                    break;
                }
            }

            ddlSkins_SelectedIndexChanged(null, null);
        }


        private Table tblSkinSelector;
        private TableRow tr;
        private TableCell td;
        private Literal br;

        protected Label lblDDLMsg;
        protected DropDownList ddlSkins;
        protected Image imgSelectedSkinIcon;

        private StringCollection availableSkins = null;
        protected StringCollection AvailablSkins
        {
            get
            {
                if (availableSkins == null)
                {
                    availableSkins = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableSkinProviders();
                }
                return availableSkins;
            }
        }


        private void PopulateDdlSkins()
        {
            string[] parts;
            string tempPart1;
            string humanReadableName;
            string semiQualifiedName;
            string xxx = string.Empty;
            for (int i = 0; i < AvailablSkins.Count; i++)
            {
                parts = AvailablSkins[i].Split(Common.Constants.Framework.Various.SpaceChar);

                if (parts.Length > 0)
                {
                    humanReadableName = parts[0].Remove(parts[0].Length - 1);
                    humanReadableName = humanReadableName.Substring(humanReadableName.LastIndexOf(".") + 1);
                    humanReadableName = string.Format(" * {0}", humanReadableName);

                    tempPart1 = parts[1].Remove(parts[1].Length - 1);

                    if (!xxx.Equals(tempPart1))
                    {
                        xxx = tempPart1;
                        ddlSkins.Items.Add(new ListItem(" ", Morphfolia.Common.Constants.Framework.Various.PleaseSelect));

                        ddlSkins.Items.Add(new ListItem(tempPart1, Morphfolia.Common.Constants.Framework.Various.PleaseSelect));
                    }

                    semiQualifiedName = string.Format("{0} {1}", parts[0], tempPart1);
                    ddlSkins.Items.Add(new ListItem(humanReadableName, semiQualifiedName));
                }
            }

            if (ddlSkins.Items.Count == 0)
            {
                ddlSkins.Items.Insert(0, new ListItem(Morphfolia.Common.Constants.Framework.Various.NoneAvailable));

                Logging.Logger.LogWarning("SkinSelector", "ddlSkins.Items.Count == 0", 666); // XXX WebsiteEventIds._1202);                
            }
            else
            {
                ddlSkins.Items.Insert(0, new ListItem(Morphfolia.Common.Constants.Framework.Various.PleaseSelect));
            }
        }


        protected override void CreateChildControls()
        {
            tblSkinSelector = new Table();
            Controls.Add(tblSkinSelector);
            tblSkinSelector.ID = "tblSkinSelector";
            tblSkinSelector.CellPadding = 5;
            tblSkinSelector.CellSpacing = 0;
            //tblSkinSelector.Attributes.Add("border", "1");
            tblSkinSelector.Width = Unit.Percentage(100);
            tblSkinSelector.CssClass = "FunctionalArea";


            tr = new TableRow();
            tblSkinSelector.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;

            lblDDLMsg = new Label();
            Controls.Add(lblDDLMsg);
            td.Controls.Add(lblDDLMsg);
            lblDDLMsg.Text = "Please select a Skin Provider:";

            br = new Literal();
            Controls.Add(br);
            td.Controls.Add(br);
            br.Text = "<br>";

            ddlSkins = new DropDownList();
            Controls.Add(ddlSkins);
            td.Controls.Add(ddlSkins);
            ddlSkins.ID = "ddlLayouts";
            ddlSkins.SelectedIndexChanged += new EventHandler(ddlSkins_SelectedIndexChanged);
            ddlSkins.AutoPostBack = true;

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;

            imgSelectedSkinIcon = new Image();
            Controls.Add(imgSelectedSkinIcon);
            td.Controls.Add(imgSelectedSkinIcon);
            imgSelectedSkinIcon.ID = "imgSelectedSkinIcon";
            imgSelectedSkinIcon.Width = Unit.Pixel(100);
            imgSelectedSkinIcon.Height = Unit.Pixel(100);
            imgSelectedSkinIcon.Style.Add("background-image", "url('../g/LayoutIconMissing.jpg')");

            if (ddlSkins.Items.Count == 0)
            {
                PopulateDdlSkins();
            }
        }


        void ddlSkins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlSkins.SelectedValue.Equals(string.Empty)) | (ddlSkins.SelectedValue.Equals(Morphfolia.Common.Constants.Framework.Various.PleaseSelect)))
            {
                imgSelectedSkinIcon.ToolTip = string.Empty;
                imgSelectedSkinIcon.ImageUrl = string.Format("{0}/Morphfolia/g/spacer.gif", Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot());

                if (SkinSelected != null)
                {
                    SkinSelected(string.Empty);
                }
            }
            else
            {
                imgSelectedSkinIcon.ToolTip = ddlSkins.SelectedValue;
                imgSelectedSkinIcon.ImageUrl = string.Format("{0}/Morphfolia/g/{1}.jpg", Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot(), ddlSkins.SelectedValue);

                if (SkinSelected != null)
                {
                    SkinSelected(ddlSkins.SelectedValue);
                }
            }       
        }
    }
}
