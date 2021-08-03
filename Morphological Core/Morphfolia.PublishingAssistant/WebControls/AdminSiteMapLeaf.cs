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
	/// Summary description for SiteMapLeaf.
	/// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
	public class AdminSiteMapLeaf : Morphfolia.WebControls.SiteMapLeaf, INamingContainer
	{
		private Table tblAdminSiteMapLeaf;

		private TableRow trPageTitle;
		private TableCell tdIcon;
		private HyperLink hypLeafIcon;
		private Image imgIcon;
		private TableCell tdEdit;
        private HtmlAnchor lnkBtnEdit;
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



		public delegate void onCreateChildControlsComplete( AdminSiteMapLeaf adminSiteMapLeaf );
		public event onCreateChildControlsComplete CreateChildControlsComplete;


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
                    this.iconImageUrl = string.Format("{0}/Morphfolia/g/page.gif", WebUtilities.VirtualApplicationRoot());
				}
				
				return this.iconImageUrl; }
			set{ this.iconImageUrl = value; }
		}



		private PageInfo pageInfo;
		public PageInfo PageInfo
		{
			get{ return this.pageInfo; }
			set{ this.pageInfo = value; }
		}



        /// <summary>
        /// Populates the control with data.
        /// </summary>
        public void SetPageInfo()
        {
            hypLeafIcon.NavigateUrl = string.Format("{0}/{1}", WebUtilities.VirtualApplicationRoot(), this.pageInfo.Url);
            hypPageUrl.NavigateUrl = hypLeafIcon.NavigateUrl;
            hypPageUrl.Text = this.pageInfo.Url;

            tdPageTitle.Text = this.pageInfo.Title;
            tdPageId.Text = this.pageInfo.PageID.ToString();
            tdDateLastMod.Text = this.pageInfo.LastModified.ToString();
            tdUserLastMod.Text = this.pageInfo.LastModifiedBy;

            if (this.pageInfo.IsLive)
            {
                tdIsLive.Text = "<img src='../g/tickbox_ticked.gif' width='16' height='16' title='Page is live' border='0'>";
            }
            else
            {
                tdIsLive.Text = "<img src='../g/tickbox_empty.gif' width='16' height='16' title='Page is not live' border='0'>";
            }

            if (this.pageInfo.IsSearchable)
            {
                tdIsSearchable.Text = "<img src='../g/tickbox_ticked.gif' width='16' height='16' title='Page is searchable' border='0'>";
            }
            else
            {
                tdIsSearchable.Text = "<img src='../g/tickbox_empty.gif' width='16' height='16' title='Page is not searchable' border='0'>";
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
            tblAdminSiteMapLeaf.ID = "tblAdminSiteMapLeaf";

			//----------------------------------------------------
			trPageTitle = new TableRow();
			this.Controls.Add( trPageTitle );
			tblAdminSiteMapLeaf.Rows.Add( trPageTitle );

			tdIcon = new TableCell();
			this.Controls.Add( tdIcon );
			trPageTitle.Cells.Add( tdIcon );
			tdIcon.VerticalAlign = VerticalAlign.Top;
			tdIcon.RowSpan = 3;

			hypLeafIcon = new HyperLink();
			this.Controls.Add( hypLeafIcon );
			tdIcon.Controls.Add( hypLeafIcon );
			hypLeafIcon.Target = "_blank";
			hypLeafIcon.ToolTip = "Opens in a new window.";

			imgIcon = new Image();
			this.Controls.Add( imgIcon );
			hypLeafIcon.Controls.Add( imgIcon );
			imgIcon.ImageUrl = this.IconImageUrl;

			tdEdit = new TableCell();
			this.Controls.Add( tdEdit );
			trPageTitle.Cells.Add( tdEdit );
			tdEdit.VerticalAlign = VerticalAlign.Top;

            lnkBtnEdit = new HtmlAnchor();
            this.Controls.Add(lnkBtnEdit);
            tdEdit.Controls.Add(lnkBtnEdit);
            lnkBtnEdit.InnerText = "Edit";
            lnkBtnEdit.Style.Add("font-weight", "700");
            lnkBtnEdit.HRef = string.Format("{0}/morphfolia/_publishing/edit_page.aspx?p={1}",
                WebUtilities.VirtualApplicationRoot(),
                pageInfo.PageID.ToString());

			tdPageTitle = new TableHeaderCell();
			this.Controls.Add( tdPageTitle );
			trPageTitle.Cells.Add( tdPageTitle );
			tdPageTitle.VerticalAlign = VerticalAlign.Top;
			tdPageTitle.ColumnSpan = 5;


			//----------------------------------------------------
			trPageUrl = new TableRow();
			this.Controls.Add( trPageUrl );
			tblAdminSiteMapLeaf.Rows.Add( trPageUrl );

			tdPageId = new TableCell();
			this.Controls.Add( tdPageId );
			trPageUrl.Cells.Add( tdPageId );
			tdPageId.VerticalAlign = VerticalAlign.Top;

			tdPageUrl = new TableCell();
			this.Controls.Add( tdPageUrl );
			trPageUrl.Cells.Add( tdPageUrl );
			tdPageUrl.VerticalAlign = VerticalAlign.Top;
			tdPageUrl.ColumnSpan = 5;

			hypPageUrl = new HyperLink();
			this.Controls.Add( hypPageUrl );
			tdPageUrl.Controls.Add( hypPageUrl );
			hypPageUrl.Target = "_blank";
			hypPageUrl.ToolTip = "Opens in a new window.";
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
			tdIsLive.HorizontalAlign = HorizontalAlign.Center;
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

			tdUserLastMod = new TableCell();
			this.Controls.Add( tdUserLastMod );
			trPageData.Cells.Add( tdUserLastMod );
			tdUserLastMod.VerticalAlign = VerticalAlign.Top;
			tdUserLastMod.Width = Unit.Pixel(180);

			tdVoid = new TableCell();
			this.Controls.Add( tdVoid );
			trPageData.Cells.Add( tdVoid );
			tdVoid.Text = "&nbsp;";
			tdVoid.Width = Unit.Pixel(310);




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

