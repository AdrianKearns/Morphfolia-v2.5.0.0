// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{
	/// <summary>
	/// Defines an area that users can use to add content to.
	/// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class ContentContainerDropBox : WebControl, INamingContainer
	{
		private Panel pnlContentContainerDropBox;
        private Label lblContainerName;
        private Label lblContainerDescription;
        private Panel pnlConcreteDropBox;
        private HtmlInputText txtPropertyValue;
		private Image imgOnloadTrigger;
        private ActiveContentNode activeContentNode;


        private string normalBackgroundColor = "#DBFFE4";
        public string NormalBackgroundColor
        {
            get {
                if (normalBackgroundColor.Equals(string.Empty))
                {
                    normalBackgroundColor = "#DBFFE4";
                }
                return normalBackgroundColor; 
            }
            set { normalBackgroundColor = value;  }
        }

        private string onDragEnterBackgroundColor = "#B2F89F";
        public string OnDragEnterBackgroundColor
        {
            get {
                if (onDragEnterBackgroundColor.Equals(string.Empty))
                {
                    onDragEnterBackgroundColor = "#B2F89F";
                }
                return onDragEnterBackgroundColor; 
            }
            set { onDragEnterBackgroundColor = value; }
        }


		public string ContainerName
		{
			get{
				EnsureChildControls();
				return lblContainerName.Text;
			}
			set{
				EnsureChildControls();
				lblContainerName.Text = value;
			}
		}


        public string ContainerDescription
        {
            get
            {
                EnsureChildControls();
                return lblContainerDescription.Text;
            }
            set
            {
                EnsureChildControls();
                lblContainerDescription.Text = value;
            }
        }


        private IntCollection currentBindings = new IntCollection();
        public IntCollection CurrentBindings
        {
            get{
                Logging.Logger.LogVerboseInformation("CurrentBindings.GET", currentBindings.ToString());
                return currentBindings; 
            }
            set{ 
                currentBindings = value;
                Logging.Logger.LogVerboseInformation("CurrentBindings.SET", currentBindings.ToString());
            }
        }


		private Unit width;
		public override Unit Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}


		private Unit height;
		public override Unit Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}


        public string PropertyValue
        {
            //get { return instanceId; }
            set {
                EnsureChildControls();
                txtPropertyValue.Value = value;

                Logging.Logger.LogVerboseInformation("PropertyValue.SET txtPropertyValue.Value", txtPropertyValue.Value);
            }
        }


		protected override void CreateChildControls()
		{
			pnlContentContainerDropBox = new Panel();
			Controls.Add( pnlContentContainerDropBox );

			lblContainerName = new Label();
			Controls.Add( lblContainerName );
			pnlContentContainerDropBox.Controls.Add( lblContainerName );
			lblContainerName.ID = "ContainerName";

            lblContainerDescription = new Label();
            Controls.Add(lblContainerDescription);
            pnlContentContainerDropBox.Controls.Add(lblContainerDescription);
            lblContainerDescription.ID = "ContainerDescription";

			pnlConcreteDropBox = new Panel();
			Controls.Add( pnlConcreteDropBox );
			pnlContentContainerDropBox.Controls.Add( pnlConcreteDropBox );
			pnlConcreteDropBox.ID = "ConcreteDropBox";

            pnlConcreteDropBox.CssClass = "ContentDropBox";

            txtPropertyValue = new HtmlInputText();
            //Controls.Add(txtPropertyValue);
            pnlContentContainerDropBox.Controls.Add(txtPropertyValue);
            txtPropertyValue.ID = "txtPropertyValue";
            //txtPropertyValue.Name = "txtPropertyValue";
            ////txtPropertyValue.Attributes.CssStyle.Add( "visibility", "hidden" );
            ////txtPropertyValue.Attributes.CssStyle.Add( "position", "absolute" );
            txtPropertyValue.Style.Add("display", "none");

			imgOnloadTrigger = new Image();
			Controls.Add( imgOnloadTrigger );
			pnlContentContainerDropBox.Controls.Add( imgOnloadTrigger );
			imgOnloadTrigger.ID = "imgOnloadTrigger";
			imgOnloadTrigger.ImageUrl = "../g/spacer.gif";
		}


		protected override void RenderContents(HtmlTextWriter writer)
		{
			EnsureChildControls();

            if (!lblContainerDescription.Text.Equals(string.Empty))
            {
                lblContainerDescription.Text = string.Format(" &nbsp; ({0})", lblContainerDescription.Text, NormalBackgroundColor);
            }

            pnlConcreteDropBox.Style.Add("background-color", NormalBackgroundColor);
            pnlConcreteDropBox.Attributes.Add("onClick", string.Format("handleDrop(event); this.style.backgroundColor='{0}';", NormalBackgroundColor));
            pnlConcreteDropBox.Attributes.Add("ondrop", string.Format("handleDrop(event); this.style.backgroundColor='{0}';", NormalBackgroundColor));
            pnlConcreteDropBox.Attributes.Add("ondragover", "cancelDefaultAction();");
            pnlConcreteDropBox.Attributes.Add("onDragleave", string.Format("this.style.backgroundColor='{0}';", NormalBackgroundColor));
            pnlConcreteDropBox.Attributes.Add("ondragenter", string.Format("handleDragEnter(); this.style.backgroundColor='{0}';", OnDragEnterBackgroundColor));

			pnlConcreteDropBox.Width = Width;
			pnlConcreteDropBox.Height = Height;
            pnlConcreteDropBox.ToolTip = ContainerName;


            ContentListInfoCollection items = Business.ContentItemHelper.ListById(CurrentBindings);
            //Logging.Logger.LogVerboseInformation("ContentListInfoCollection", items.ToString());

            foreach(ContentListInfo info in items)
            {
                activeContentNode = new ActiveContentNode();
                activeContentNode.Content = info;
                pnlConcreteDropBox.Controls.Add(activeContentNode);

                Logging.Logger.LogVerboseInformation("ContentContainerDropBox, RenderContents()", string.Format("Adding content item to pnlConcreteDropBox, ContentID={0}", info.ContentID), 666);
            }

			if( Visible )
			{
				pnlContentContainerDropBox.RenderControl( writer );
			}
		}
	}
}