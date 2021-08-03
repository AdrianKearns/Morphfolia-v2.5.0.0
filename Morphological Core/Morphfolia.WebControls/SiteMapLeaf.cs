// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Business;
using Morphfolia.Common.Info;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;

namespace Morphfolia.WebControls
{
	/// <summary>
	/// Summary description for SiteMapLeaf.
	/// </summary>
	public class SiteMapLeaf : WebControl, INamingContainer
	{
		private Table tblSiteMapLeaf;
		private TableRow trLeaf;
		private TableCell tdIcon;
		private HyperLink hypLeafIcon;
		private Image imgIcon;
		private TableCell tdText;
		private HyperLink hypLeafText;



		private string text;
		public string Text
		{
			get{ return this.text; }
			set{ this.text = value; }
		}

		private string url;
		public string Url
		{
			get{ return this.url; }
			set{ 

				this.url = value; 

//				if( !WebUtilities.IsUrlPrefixedWithWebProtocol( this.url ) )
//				{
//					this.url = string.Format("http://{0}", this.url);
//				}
			}
		}

		private string iconImageUrl;
		/// <summary>
		/// The text which is visble to users (the visible value of the node).
		/// </summary>
		public string IconImageUrl
		{
			get
			{ 
				if( this.iconImageUrl == null )
				{
                    this.iconImageUrl = "Morphfolia/g/page.gif";
				}
				
				return this.iconImageUrl; }
			set{ this.iconImageUrl = value; }
		}



		/// <exclude />
		protected override void CreateChildControls()
		{
            this.EnableViewState = false;

			tblSiteMapLeaf = new Table();
			this.Controls.Add( tblSiteMapLeaf );
			tblSiteMapLeaf.CellPadding = 5;
			tblSiteMapLeaf.CellSpacing = 0;

			trLeaf = new TableRow();
			this.Controls.Add( trLeaf );
			tblSiteMapLeaf.Rows.Add( trLeaf );

			tdIcon = new TableCell();
			this.Controls.Add( tdIcon );
			trLeaf.Cells.Add( tdIcon );
			tdIcon.VerticalAlign = VerticalAlign.Top;

			hypLeafIcon = new HyperLink();
			this.Controls.Add( hypLeafIcon );
			tdIcon.Controls.Add( hypLeafIcon );

			imgIcon = new Image();
			this.Controls.Add( imgIcon );
			hypLeafIcon.Controls.Add( imgIcon );
			imgIcon.ImageUrl = this.IconImageUrl;

			tdText = new TableCell();
			this.Controls.Add( tdText );
			trLeaf.Cells.Add( tdText );
			tdText.VerticalAlign = VerticalAlign.Top;

			hypLeafText = new HyperLink();
			this.Controls.Add( hypLeafText );
			tdText.Controls.Add( hypLeafText );
		}



		/// <exclude />
		protected override void Render(HtmlTextWriter writer)
		{
			EnsureChildControls();

			hypLeafIcon.NavigateUrl = this.Url;
			hypLeafText.NavigateUrl = this.Url;
			hypLeafText.Text = this.Text;

			if( Visible )
			{
				tblSiteMapLeaf.RenderControl( writer );
			}
		}
	}


	public class SiteMapLeafCollection : CollectionBase
	{
		public SiteMapLeaf this[ int index ]
		{
			get { return( (SiteMapLeaf) List[index] ); }
			set { List[index] = value; }
		}


		public int Add( SiteMapLeaf value )
		{
			return( List.Add( value ) );
		}
	}

}
