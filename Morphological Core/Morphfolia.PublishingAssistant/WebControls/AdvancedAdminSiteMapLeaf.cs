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
using Morphfolia.Business;
using Morphfolia.Common;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{
	/// <summary>
	/// Summary description for SiteMapLeaf.
	/// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class AdvancedAdminSiteMapLeaf : Morphfolia.WebControls.SiteMapLeaf, INamingContainer
	{
		private Table tblAdminSiteMapLeaf;

		private TableRow trPageTitle;
		private TableCell tdIcon;
		private HyperLink hypLeafIcon;
		private Image imgIcon;
		private TableCell tdEdit;
        //private LinkButton lnkBtnEdit;
        private HtmlAnchor lnkBtnEdit;
        private TableCell tdLayoutWebControlType;
        private Image imgLayoutWebControlType;
		private TableHeaderCell tdPageTitle;

		private TableRow trPageUrl;
		private TableCell tdPageId;
		private TableCell tdPageUrl;
		private HyperLink hypPageUrl;

		private TableRow trPageData;
		private TableCell tdVoid;
		private TableCell tdDateLastMod;
		private TableCell tdUserLastMod;
		private TableCell tdIsLive;
        private TableCell tdIsSearchable;
        private TableCell tdControlProperties;


        private Table tblPropertySummary;
        private TableRow tr;
        private TableCell td;
        private Image imgToggle;


        public delegate void onCreateChildControlsComplete(AdvancedAdminSiteMapLeaf adminSiteMapLeaf);
		public event onCreateChildControlsComplete CreateChildControlsComplete;


        public AdvancedAdminSiteMapLeaf(AdvancedAdminSiteMap parentSiteMap)
        {
            ParentSiteMap = parentSiteMap;
        }


		private string iconImageUrl;
		/// <summary>
		/// The text which is visble to users (the visible value of the node).
		/// </summary>
		public new string IconImageUrl
		{
			get
			{ 
				if( this.iconImageUrl == null )
				{
					this.iconImageUrl = "../g/page.gif";
				}
				
				return this.iconImageUrl; }
			set{ this.iconImageUrl = value; }
		}

        private StaticCustomPropertyHelper ControlPropertyHelper = new StaticCustomPropertyHelper();
        private Morphfolia.Common.Info.CustomPropertyInstanceInfoCollection CustomPageProperties = new CustomPropertyInstanceInfoCollection();


		private PageInfo pageInfo;
		public PageInfo PageInfo
		{
			get{ return this.pageInfo; }
			set{ 
                this.pageInfo = value;

                CustomPageProperties = StaticCustomPropertyHelper.GetControlPropertiesByInstanceID(pageInfo.PageID, ControlPropertyTypeConstants.PropertyTypeIdentifiers.CUST);
            }
		}


        private AdvancedAdminSiteMap parentSiteMap;
        public AdvancedAdminSiteMap ParentSiteMap
        {
            get { return parentSiteMap;  }
            set { parentSiteMap = value;  }
        }



        /// <summary>
        /// Populates the control with data.
        /// </summary>
        public void SetPageInfo()
        {
            EnsureChildControls();

            hypLeafIcon.NavigateUrl = string.Format("{0}/{1}", WebUtilities.VirtualApplicationRoot(), this.pageInfo.Url);
            hypPageUrl.NavigateUrl = hypLeafIcon.NavigateUrl;
            hypPageUrl.Text = this.pageInfo.Url;

            tdPageTitle.Text = this.pageInfo.Title;
            tdPageId.Text = this.pageInfo.PageID.ToString();
            tdDateLastMod.Text = string.Format("<nobr>{0}</nobr>", this.pageInfo.LastModified.ToString());
            tdUserLastMod.Text = this.pageInfo.LastModifiedBy;

            if (this.pageInfo.IsLive)
            {
                tdIsLive.Text = "<img src='../g/tickbox_ticked.gif' width='16' height='16' title='Page is live' border='0'>";
                tdIsLive.ToolTip = "This page is live and accessible.";
            }
            else
            {
                tdIsLive.Text = "<img src='../g/tickbox_empty.gif' width='16' height='16' title='Page is not live' border='0'>";
                tdIsLive.ToolTip = "This page is NOT live and accessible.";
            }

            if (this.pageInfo.IsSearchable)
            {
                tdIsSearchable.Text = "<img src='../g/tickbox_ticked.gif' width='16' height='16' title='Page is searchable' border='0'>";
                tdIsSearchable.ToolTip = "This page is searchable.";
            }
            else
            {
                tdIsSearchable.Text = "<img src='../g/tickbox_empty.gif' width='16' height='16' title='Page is not searchable' border='0'>";
                tdIsSearchable.ToolTip = "This page is NOT searchable.";
            }

            if (CustomPageProperties.Count == 0)
            {
                tblPropertySummary.Visible = false;
                tdVoid.Text = "&nbsp;";
            }
            else
            {
                tr = new TableRow();
                tblPropertySummary.Rows.Add(tr);
                tr.CssClass = "ListHeader";
                tr.Attributes.Add("onClick", "ExpandCollapseThing(this);");
                tr.ToolTip = "Click to show/hide properties.";

                td = new TableCell();
                tr.Cells.Add(td);
                td.Width = Unit.Percentage(50);
                td.Text = "Property";

                td = new TableCell();
                tr.Cells.Add(td);
                td.Width = Unit.Percentage(50);
                td.Text = "Value";

                td = new TableCell();
                tr.Cells.Add(td);
                td.HorizontalAlign = HorizontalAlign.Right;

                imgToggle = new Image();
                td.Controls.Add(imgToggle);
                imgToggle.ImageUrl = string.Format("{0}/Morphfolia/g/toggle_1.gif", WebUtilities.VirtualApplicationRoot());
                tdUserLastMod.ToolTip = "";



                string selectedProperty = ParentSiteMap.ddlUniqueListOfProperties.SelectedValue;
                string propertyKey;
                string propertyValue;

                for (int i = 0; i < CustomPageProperties.Count; i++)
                {
                    propertyKey = CustomPageProperties[i].PropertyKey;
                    propertyValue = CustomPageProperties[i].PropertyValue;

                    tr = new TableRow();
                    tblPropertySummary.Rows.Add(tr);

                    if (ParentSiteMap != null)
                    {
                        if (selectedProperty.Equals(string.Empty))
                        {
                            tr.Style.Add("display", "inline");
                        }
                        else
                        {
                            if (selectedProperty.Equals(propertyKey))
                            {
                                tr.Style.Add("display", "inline");
                                tr.CssClass = "ListHeader_highlight";
                            }
                            else
                            {
                                tr.Style.Add("display", "none");
                            }
                        }
                    }
                    else
                    {
                        tr.Style.Add("display", "inline");
                    }


                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.Width = Unit.Percentage(50);

                    if (propertyKey.Equals(SpecialCustomPropertyKeys.LayoutWebControlType))
                    {
                        imgLayoutWebControlType.ToolTip = string.Format("Current Layout: {0}", propertyValue);
                        imgLayoutWebControlType.ImageUrl = string.Format("{0}/Morphfolia/g/{1}.jpg",
                            WebUtilities.VirtualApplicationRoot(),
                            propertyValue);

                        td.Text = propertyKey;
                        td.ToolTip = "This can/should only be modified by editing the page directly.";
                    }
                    else
                    {
                        td.Text = propertyKey;
                        td.ToolTip = "Property";
                    }                  
                
                    td = new TableCell();
                    tr.Cells.Add(td);
                    td.ColumnSpan = 2;
                    td.Text = propertyValue;
                    td.ToolTip = "Current property value";
                    td.Width = Unit.Percentage(50);
                }
            }
        }


		protected override void CreateChildControls()
		{
            this.EnableViewState = false;

			tblAdminSiteMapLeaf = new Table();
			this.Controls.Add( tblAdminSiteMapLeaf );
			tblAdminSiteMapLeaf.CellPadding = 5;
			tblAdminSiteMapLeaf.CellSpacing = 0;
			//tblAdminSiteMapLeaf.Attributes.Add("border", "1");

			//----------------------------------------------------
			trPageTitle = new TableRow();
			this.Controls.Add( trPageTitle );
			tblAdminSiteMapLeaf.Rows.Add( trPageTitle );

			tdIcon = new TableCell();
			this.Controls.Add( tdIcon );
			trPageTitle.Cells.Add( tdIcon );
			tdIcon.VerticalAlign = VerticalAlign.Top;
			tdIcon.RowSpan = 4;

			hypLeafIcon = new HyperLink();
			this.Controls.Add( hypLeafIcon );
			tdIcon.Controls.Add( hypLeafIcon );
			hypLeafIcon.Target = "_blank";
			hypLeafIcon.ToolTip = "Click here to open this page in a new window.";

			imgIcon = new Image();
			this.Controls.Add( imgIcon );
			hypLeafIcon.Controls.Add( imgIcon );
			imgIcon.ImageUrl = this.IconImageUrl;

			tdEdit = new TableCell();
			this.Controls.Add( tdEdit );
			trPageTitle.Cells.Add( tdEdit );
			tdEdit.VerticalAlign = VerticalAlign.Top;

            lnkBtnEdit = new HtmlAnchor();
			this.Controls.Add( lnkBtnEdit );
			tdEdit.Controls.Add( lnkBtnEdit );
			lnkBtnEdit.InnerText = "Edit";
            lnkBtnEdit.Style.Add("font-weight", "700");
            lnkBtnEdit.HRef = string.Format("{0}/morphfolia/_publishing/edit_page.aspx?p={1}",
                WebUtilities.VirtualApplicationRoot(),
                pageInfo.PageID.ToString());


            tdLayoutWebControlType = new TableCell();
            this.Controls.Add(tdLayoutWebControlType);
            trPageTitle.Cells.Add(tdLayoutWebControlType);
            tdLayoutWebControlType.VerticalAlign = VerticalAlign.Top;
            tdLayoutWebControlType.RowSpan = 4;

            imgLayoutWebControlType = new Image();
            tdLayoutWebControlType.Controls.Add(imgLayoutWebControlType);
            imgLayoutWebControlType.Width = Unit.Pixel(100);
            imgLayoutWebControlType.Height = Unit.Pixel(100);
            imgLayoutWebControlType.Style.Add("background-image", string.Format("url('{0}/Morphfolia/g/LayoutIconMissing.jpg')", WebUtilities.VirtualApplicationRoot()));


			tdPageTitle = new TableHeaderCell();
			this.Controls.Add( tdPageTitle );
			trPageTitle.Cells.Add( tdPageTitle );
			tdPageTitle.VerticalAlign = VerticalAlign.Top;
			tdPageTitle.ColumnSpan = 5;
            tdPageTitle.ToolTip = "Page Title";


			//----------------------------------------------------
			trPageUrl = new TableRow();
			this.Controls.Add( trPageUrl );
			tblAdminSiteMapLeaf.Rows.Add( trPageUrl );

			tdPageId = new TableCell();
			this.Controls.Add( tdPageId );
			trPageUrl.Cells.Add( tdPageId );
			tdPageId.VerticalAlign = VerticalAlign.Top;
            tdPageId.ToolTip = "Page Id";

			tdPageUrl = new TableCell();
			this.Controls.Add( tdPageUrl );
			trPageUrl.Cells.Add( tdPageUrl );
			tdPageUrl.VerticalAlign = VerticalAlign.Top;
			tdPageUrl.ColumnSpan = 5;

			hypPageUrl = new HyperLink();
			this.Controls.Add( hypPageUrl );
			tdPageUrl.Controls.Add( hypPageUrl );
			hypPageUrl.Target = "_blank";
            hypPageUrl.ToolTip = "Click here to open this page in a new window.";
			hypPageUrl.CssClass = "MajorLink";

			//----------------------------------------------------
			trPageData = new TableRow();
			this.Controls.Add( trPageData );
			tblAdminSiteMapLeaf.Rows.Add( trPageData );

			tdVoid = new TableCell();
			this.Controls.Add( tdVoid );
			trPageData.Cells.Add( tdVoid );

			tdIsLive = new TableCell();
			this.Controls.Add( tdIsLive );
			trPageData.Cells.Add( tdIsLive );
			tdIsLive.VerticalAlign = VerticalAlign.Top;
			tdIsLive.HorizontalAlign = HorizontalAlign.Left;
			tdIsLive.Width = Unit.Pixel(30);

			tdIsSearchable = new TableCell();
			this.Controls.Add( tdIsSearchable );
			trPageData.Cells.Add( tdIsSearchable );
			tdIsSearchable.VerticalAlign = VerticalAlign.Top;
			tdIsSearchable.HorizontalAlign = HorizontalAlign.Left;
			tdIsSearchable.Width = Unit.Pixel(30);

			tdDateLastMod = new TableCell();
			this.Controls.Add( tdDateLastMod );
			trPageData.Cells.Add( tdDateLastMod );
			tdDateLastMod.VerticalAlign = VerticalAlign.Top;
			tdDateLastMod.Width = Unit.Pixel(180);
            tdDateLastMod.ToolTip = "Date last modified";

			tdUserLastMod = new TableCell();
			this.Controls.Add( tdUserLastMod );
			trPageData.Cells.Add( tdUserLastMod );
			tdUserLastMod.VerticalAlign = VerticalAlign.Top;
			tdUserLastMod.Width = Unit.Pixel(180);
            tdDateLastMod.ToolTip = "The last user to modify this page.";

            tdVoid = new TableCell();
            this.Controls.Add(tdVoid);
            trPageData.Cells.Add(tdVoid);
            tdVoid.Text = "&nbsp;";
            tdVoid.Width = Unit.Pixel(310);

            //----------------------------------------------------
            tr = new TableRow();
            this.Controls.Add(tr);
            tblAdminSiteMapLeaf.Rows.Add(tr);
            
            tdVoid = new TableCell();
            this.Controls.Add(tdVoid);
            tr.Cells.Add(tdVoid);
            tdVoid.Text = "&nbsp;";

			tdControlProperties = new TableCell();
            this.Controls.Add(tdControlProperties);
            tr.Cells.Add(tdControlProperties);
            tdControlProperties.Text = "&nbsp;";
            tdControlProperties.ColumnSpan = 5;

            tblPropertySummary = new Table();
            this.Controls.Add(tblPropertySummary);
            tdControlProperties.Controls.Add(tblPropertySummary);
            tblPropertySummary.CssClass = "FunctionalArea_Light";
            tblPropertySummary.CellPadding = 3;
            tblPropertySummary.CellSpacing = 0;
            //tblPropertySummary.Width = Unit.Percentage(100);
            //tblPropertySummary.Attributes.Add("border", "1");


			if( CreateChildControlsComplete != null )
			{
				CreateChildControlsComplete( this );
			}
		}


		protected override void Render(HtmlTextWriter writer)
		{
			EnsureChildControls();

			if( Visible )
			{
				tblAdminSiteMapLeaf.RenderControl( writer );
			}
		}
	}
}