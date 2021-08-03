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
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class AssignContentToPage : WebControl, INamingContainer
    {
        private TextBox txtHedwig;
        private Table tblAssignContentToPage;
        private TableRow tr;
        private TableCell td;
        private Literal br;
        protected Panel pnlContentContainerDropBoxes;
        protected Label lblText;
        protected HtmlInputText txtContentFilter;
        Literal litClientsideLoadTrigger;
        Literal divAvailableContentItems;


        private int pageId = Common.Constants.SystemTypeValues.NullInt;
        public int PageId
        {
            get { return pageId; }
            set { pageId = value; }
        }

        public AssignContentToPage()
        {
        }

        public AssignContentToPage(int pageId)
        {
            PageId = pageId;
        }



        private string availableContentItemsBackgroundColor = "#ffffcc";
        public string AvailableContentItemsBackgroundColor
        {
            get { return availableContentItemsBackgroundColor; }
            set
            {
                availableContentItemsBackgroundColor = value;
                if (availableContentItemsBackgroundColor.Equals(string.Empty))
                {
                    availableContentItemsBackgroundColor = "#ffffcc";
                }
            }
        }

        private string contentContainerDropBoxesBackgroundColor = "#f9f9dd";
        public string ContentContainerDropBoxesBackgroundColor
        {
            get { return contentContainerDropBoxesBackgroundColor; }
            set
            {
                contentContainerDropBoxesBackgroundColor = value;
                if (contentContainerDropBoxesBackgroundColor.Equals(string.Empty))
                {
                    contentContainerDropBoxesBackgroundColor = "#f9f9dd";
                }
            }
        }



        /// <summary>
        /// The raw JScript recorded hash of the current content-to-page bindings.
        /// </summary>
        public string HedWig
        {
            get
            {
                EnsureChildControls();
                return txtHedwig.Text;
            }
            set
            {
                EnsureChildControls();
                txtHedwig.Text = value;
            }
        }



        /// <summary>
        /// Saves the current content-to-page bindings.
        /// </summary>
        public void Save()
        {
            EnsureChildControls();

            Logging.Logger.LogInformation("AssignContentToPage.Save()", "Invoked");

            
            string PropertyValue = txtHedwig.Text;
            string[] sLines = PropertyValue.Split(char.Parse("@"));
            string[] sValues;
            string ContainerName;
            for (int l = 0; l < sLines.Length; l++)
            {
                if (!sLines[l].Equals(string.Empty))
                {
                    Logging.Logger.LogVerboseInformation("AssignContentToPage.GetValuesToSave() - line", sLines[l].ToString());

                    sValues = sLines[l].Trim().Split(char.Parse(" "));
                    if (sValues.Length > 1)
                    {
                        ContainerName = sValues[0].ToString();
                        for (int v = 1; v < sValues.Length; v++)
                        {
                            if (!sValues[v].Equals(String.Empty))
                            {
                                StaticCustomPropertyHelper.SaveControlPropertyByInstance(
                                    new SaveNewCustomPropertyInstanceInfo(
                                        PageId,
                                        Morphfolia.Common.ControlPropertyTypeFactory.ContentItemContainerPropertyType(),
                                        ContainerName,
                                        sValues[v])
                                    );
                            }
                        }
                    }
                }
            }
        }


        protected override void CreateChildControls()
        {
            this.EnableViewState = false;

            txtHedwig = new TextBox();
            Controls.Add(txtHedwig);
            txtHedwig.TextMode = TextBoxMode.MultiLine;
            txtHedwig.Rows = 5;
            txtHedwig.Columns = 90;
            txtHedwig.Wrap = false;
            txtHedwig.ID = "txtHedwig";
            txtHedwig.Style.Add("display", "none");


            tblAssignContentToPage = new Table();
            Controls.Add(tblAssignContentToPage);
            tblAssignContentToPage.ID = "tblAssignContentToPage";
            tblAssignContentToPage.CellPadding = 5;
            tblAssignContentToPage.CellSpacing = 0;
            //tblAssignContentToPage.Attributes.Add("border", "1");
            tblAssignContentToPage.Width = Unit.Percentage(100);
            tblAssignContentToPage.CssClass = "FunctionalArea";


            tr = new TableRow();
            tblAssignContentToPage.Controls.Add(tr);

            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;

            lblText = new Label();
            Controls.Add(lblText);
            td.Controls.Add(lblText);
            lblText.Text = "Available Content";
            lblText.Style.Add("font-weight", "700");

            br = new Literal();
            Controls.Add(br);
            td.Controls.Add(br);
            br.Text = "<br>";

            lblText = new Label();
            Controls.Add(lblText);
            td.Controls.Add(lblText);
            lblText.Text = "Filter (case sensitive) ";

            txtContentFilter = new HtmlInputText();
            Controls.Add(txtContentFilter);
            td.Controls.Add(txtContentFilter);
            txtContentFilter.ID = "txtContentFilter";
            txtContentFilter.Attributes.Add("onkeyup", "GetContentItems_ByNotesFilter(this.value);");
            
            divAvailableContentItems = new Literal();
            Controls.Add(divAvailableContentItems);
            td.Controls.Add(divAvailableContentItems);
            divAvailableContentItems.EnableViewState = false;


            td = new TableCell();
            tr.Cells.Add(td);
            td.VerticalAlign = VerticalAlign.Top;

            lblText = new Label();
            Controls.Add(lblText);
            td.Controls.Add(lblText);
            lblText.Text = "Content Drop Boxes";
            lblText.Style.Add("font-weight", "700");

            br = new Literal();
            Controls.Add(br);
            td.Controls.Add(br);
            br.Text = "<br>";

            pnlContentContainerDropBoxes = new Panel();
            Controls.Add(pnlContentContainerDropBoxes);
            td.Controls.Add(pnlContentContainerDropBoxes);
            pnlContentContainerDropBoxes.ID = "pnlContentContainerDropBoxes";
            pnlContentContainerDropBoxes.Style.Add("border", "solid 1px #999999");
            pnlContentContainerDropBoxes.Style.Add("padding", "5px");
            pnlContentContainerDropBoxes.Style.Add("width", "300px");
            pnlContentContainerDropBoxes.Style.Add("height", "447px");
            pnlContentContainerDropBoxes.Style.Add("OVERFLOW-Y", "scroll");
            //pnlContentContainerDropBoxes.EnableViewState = false;

            litClientsideLoadTrigger = new Literal();
            Controls.Add(litClientsideLoadTrigger);
        }


        void ddlLayouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        public void FillContentContainerDropBoxesPanel(string selectedLayoutWebControlType)
        {
            Logging.Logger.LogInformation("AssignContentToPage.FillContentContainerDropBoxesPanel", "invoked");
            //Logging.Logger.LogVerboseInformation("FillContentContainerDropBoxesPanel.GetControlPropertiesByInstanceIDAndPropertyKey()", PageId.ToString(), 666);

            EnsureChildControls();

            pnlContentContainerDropBoxes.Controls.Clear();
            System.Text.StringBuilder sb;
            Morphfolia.Common.Info.ContentContainerInfo contentContainer;
            Morphfolia.Common.Info.ContentContainerInfoCollection contentContainers = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableContentContainerProperties(selectedLayoutWebControlType);


            System.Text.StringBuilder sbHedwig = new System.Text.StringBuilder();

            for (int i = 0; i < contentContainers.Count; i++)
            {
                contentContainer = contentContainers[i];

                Morphfolia.PublishingSystem.WebControls.ContentContainerDropBox contentContainerDropBox = new Morphfolia.PublishingSystem.WebControls.ContentContainerDropBox();
                pnlContentContainerDropBoxes.Controls.Add(contentContainerDropBox);
                contentContainerDropBox.ID = string.Format("oTarget{0}", i.ToString());
                contentContainerDropBox.ContainerName = contentContainer.ContainerName;
                contentContainerDropBox.NormalBackgroundColor = contentContainer.Colour;
                contentContainerDropBox.ContainerDescription = contentContainer.Description;
                contentContainerDropBox.Width = Unit.Pixel(260);
                contentContainerDropBox.Height = Unit.Pixel(220);

                if (PageId != Common.Constants.SystemTypeValues.NullInt)
                {
                    int o;

                    CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = StaticCustomPropertyHelper.GetControlPropertiesByInstanceIDAndPropertyKey(PageId, contentContainer.ContainerName);

                    Logging.Logger.LogVerboseInformation("FillContentContainerDropBoxesPanel.GetControlPropertiesByInstanceIDAndPropertyKey()", string.Format("PageId={0}, ContainerName={1}", PageId.ToString(), contentContainer.ContainerName), 666);

                    if (controlPropertyInfoCollection.Count > 0)
                    {
                        sb = new System.Text.StringBuilder();
                        sb.AppendFormat("@ {0} ", contentContainer.ContainerName);

                        for (int c = 0; c < controlPropertyInfoCollection.Count; c++)
                        {
                            sb.AppendFormat("{0}", controlPropertyInfoCollection[c].PropertyValue);

                            if(int.TryParse(controlPropertyInfoCollection[c].PropertyValue, out o))
                            {
                                contentContainerDropBox.CurrentBindings.Add( o );
                            }

                            if (c < controlPropertyInfoCollection.Count - 1)
                            {
                                sb.Append(" ");
                            }
                        }
                        sbHedwig.AppendFormat("{0}{1}", sb.ToString(), Environment.NewLine);
                        contentContainerDropBox.PropertyValue = sb.ToString();
                    }
                }
            }
            txtHedwig.Text = sbHedwig.ToString();
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            litClientsideLoadTrigger.Text = string.Format("<img src='../g/spacer.gif' style='border: solid 0px #ffffff;' onload=\"GetContentItems_ByNotesFilter(document.getElementById('{0}').value); idOfContentAssigner = '{1}'; idOfAvailableContentfilterInputTextBox = '{0}'; PopulateDropBoxesFromHedwig();\">", 
                txtContentFilter.ClientID,
                this.ClientID);

            divAvailableContentItems.Text = string.Format("<div id='divAvailableContentItems' style='margin-top: 3px; border:solid 1px #999999;padding:10px;width:300px;height:415px;OVERFLOW-Y:scroll;background-color: {0};'></div>", AvailableContentItemsBackgroundColor);
            pnlContentContainerDropBoxes.Style.Add("background-color", ContentContainerDropBoxesBackgroundColor);

            base.RenderContents(writer);
        }
    }
}