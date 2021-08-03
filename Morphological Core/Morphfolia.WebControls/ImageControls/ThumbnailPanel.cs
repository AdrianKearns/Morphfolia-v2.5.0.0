// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Business;
using Morphfolia.Common.Info;
using Morphfolia.WebControls;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Specialized; 
using Morphfolia.Common.Logging;
using Morphfolia.WebControls.Utilities;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.WebControls
{
	/// <summary>
	/// Summary description for ThumbnailPanel.
	/// </summary>
	public class ThumbnailPanel : WebControl, INamingContainer, IPostBackEventHandler
	{
		private Table tblThumbnailPanel;
		private TableRow tr;
		private TableCell tdThumbNail;
		private TableCell tdImageName;
		private TableCell tdDimensions;
		private TableCell tdDelete;
		private TableCell tdInsertThumbnailImage;
		private TableCell tdInsertOriginalImage;

		private HtmlButton hbtnInsertThumbnailImage;
		private HtmlButton hbtnInsertOriginalImage;
		private HtmlButton hbtnDelete;



		public delegate void onThumbnailSelected(object sender, ThumbnailSelectedEventArgs e);

		public event onThumbnailSelected ThumbnailSelected;

		public class ThumbnailSelectedEventArgs : System.EventArgs
		{
			public ThumbnailSelectedEventArgs( string imageUrl )
			{
	
				this.ImageUrl = imageUrl;
			}

			public string ImageUrl;
		}





		private string imageUrl;
		public string ImageUrl
		{
			get{ return imageUrl; }
			set{ 
				imageUrl = value; 
				if( imageUrl != null )
				{
					name = imageUrl.Replace("/", @"\");
					name = name.Substring( name.LastIndexOf(@"\")+1 );
					imageUrl = string.Format("{0}/Morphfolia/g_publishing/Thumbnails/{1}", WebUtilities.VirtualApplicationRoot(), this.name );
				}
			}
		}


		private bool useClientSideMode;
		/// <summary>
		/// If true, the control calls a standard JScript function, with the name of the image as the only argument.
		/// This is intended to work with the HTMLEditor.
		/// </summary>
		public bool UseClientSideMode
		{
			get{ return useClientSideMode; }
			set{ useClientSideMode = value; }
		}



		private HyperLink hypThumbNailImageLink;
		private Image thumbNailImage;
		private string name;



		/// <exclude />
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(ClientScriptRegistrationKeys.ThumbnailHelper))
			{
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), ClientScriptRegistrationKeys.ThumbnailHelper, string.Format("<script language=javascript src='{0}/Morphfolia/JavaScript/ThumbnailHelper.js'></script>", WebUtilities.VirtualApplicationRoot()));
			}

			tblThumbnailPanel = new Table();
			this.Controls.Add( tblThumbnailPanel );
			//tblThumbnailPanel.Attributes.Add("border", "1");
			tblThumbnailPanel.CellPadding = 5;
			tblThumbnailPanel.CellSpacing = 0;


			tr = new TableRow();
			this.Controls.Add( tr );
			tblThumbnailPanel.Rows.Add( tr );

			tdThumbNail = new TableCell();
			this.Controls.Add( tdThumbNail );
			tr.Cells.Add( tdThumbNail );
			tdThumbNail.RowSpan = 4;

			tdImageName = new TableCell();
			this.Controls.Add( tdImageName );
			tr.Cells.Add( tdImageName );
			tdImageName.ColumnSpan = 2;
            tdImageName.Width = Unit.Percentage(100);


			tr = new TableRow();
			this.Controls.Add( tr );
			tblThumbnailPanel.Rows.Add( tr );

			tdDimensions = new TableCell();
			this.Controls.Add( tdDimensions );
			tr.Cells.Add( tdDimensions );

			tdDelete = new TableCell();
			this.Controls.Add( tdDelete );
			tr.Cells.Add( tdDelete );

			hbtnDelete = new HtmlButton();
			this.Controls.Add( hbtnDelete );
			tdDelete.Controls.Add( hbtnDelete );
			hbtnDelete.ID = "hbtnDelete";
			hbtnDelete.InnerText = "Delete";
			//hbtnDelete.Attributes.Add("class", "btn");
			
			


			tr = new TableRow();
			this.Controls.Add( tr );
			tblThumbnailPanel.Rows.Add( tr );

			tdInsertThumbnailImage = new TableCell();
			this.Controls.Add( tdInsertThumbnailImage );
			tr.Cells.Add( tdInsertThumbnailImage );
			tdInsertThumbnailImage.ColumnSpan = 2;


			tr = new TableRow();
			this.Controls.Add( tr );
			tblThumbnailPanel.Rows.Add( tr );

			tdInsertOriginalImage = new TableCell();
			this.Controls.Add( tdInsertOriginalImage );
			tr.Cells.Add( tdInsertOriginalImage );
			tdInsertOriginalImage.ColumnSpan = 2;


			if( this.UseClientSideMode )
			{
				hbtnInsertThumbnailImage = new HtmlButton();
				this.Controls.Add( hbtnInsertThumbnailImage );
				tdInsertThumbnailImage.Controls.Add( hbtnInsertThumbnailImage );
				hbtnInsertThumbnailImage.ID = "hbtnInsertThumbnailImage";
				hbtnInsertThumbnailImage.InnerText = "Insert Thumbnail";
                //hbtnInsertThumbnailImage.Attributes.Add("onclick", string.Format("ThumbnailImageClicked('{0}/Morphfolia/g_publishing/Thumbnails/{1}', 'thumbnailAsLinkToOriginalImage'); return false;", WebUtilities.VirtualApplicationRoot(), this.name));
                hbtnInsertThumbnailImage.Attributes.Add("onclick", string.Format("FormatActionMapper('insertThumbnailAsLinkToOriginalImage', '{0}/Morphfolia/g_publishing/Thumbnails/{1}'); return false;", WebUtilities.VirtualApplicationRoot(), this.name));
                //hbtnInsertThumbnailImage.Attributes.Add("class", "btn");

				hbtnInsertOriginalImage = new HtmlButton();
				this.Controls.Add( hbtnInsertOriginalImage );
				tdInsertOriginalImage.Controls.Add( hbtnInsertOriginalImage );
				hbtnInsertOriginalImage.ID = "hbtnInsertOriginalImage";
				hbtnInsertOriginalImage.InnerText = "Insert Original";
                //hbtnInsertOriginalImage.Attributes.Add("onclick", string.Format("ThumbnailImageClicked('{0}/Morphfolia/g_publishing/Images/{1}', ''); return false;", WebUtilities.VirtualApplicationRoot(), this.name));
                hbtnInsertOriginalImage.Attributes.Add("onclick", string.Format("FormatActionMapper('insertOriginalImage', '{0}/Morphfolia/g_publishing/Images/{1}'); return false;", WebUtilities.VirtualApplicationRoot(), this.name));
                //hbtnInsertOriginalImage.Attributes.Add("class", "btn");
			}
			else
			{
				tdInsertThumbnailImage.Text = "&nbsp;";
				tdInsertOriginalImage.Text = "&nbsp;";
			}

		}

			

		/// <exclude />
		protected override void Render(HtmlTextWriter writer)
		{
			EnsureChildControls();

			if( this.thumbNailImage != null )
			{
				this.thumbNailImage.Dispose();
			}


			tblThumbnailPanel.Width = Width;

            if(CssClass.Equals(string.Empty))
            {
                CssClass = "VerticalDividerBottom";
            }
            tblThumbnailPanel.CssClass = CssClass;


			hypThumbNailImageLink = new HyperLink();
			this.thumbNailImage = new Image();

			hypThumbNailImageLink.Controls.Add( thumbNailImage );
            hypThumbNailImageLink.NavigateUrl = string.Format("{0}/Morphfolia/g_publishing/Images/{1}", WebUtilities.VirtualApplicationRoot(), this.name);
			hypThumbNailImageLink.Target = "_blank";
			this.thumbNailImage.ImageUrl = this.ImageUrl;

			tdThumbNail.Controls.Clear();
			tdThumbNail.Controls.Add( hypThumbNailImageLink );
			//tdThumbNail.Controls.Add( this.thumbNailImage );
			tdImageName.Text = this.name;
			tdImageName.Style.Add("font-weight", "700");

			ImageInfo imageInfo = ImageFactory.ByImageName( this.name );
			if( imageInfo.ID < 0 )
			{
				tdDimensions.Text = "Dimesions not found";
			}
			else
			{
				tdDimensions.Text = string.Format("Dimesions: {0} x {1}", imageInfo.Width.ToString(), imageInfo.Height.ToString() );
			}


            hbtnDelete.Attributes.Add("onclick", string.Format("if(confirm('Are you sure you want to delete?')){0};", Page.ClientScript.GetPostBackEventReference(this, this.name)));



			if( Visible )
			{
				RenderChildren( writer );
			}
		}



		private void btnInsertThumbnailImage_Click(object sender, EventArgs e)
		{
			if( ThumbnailSelected != null )
			{
				ThumbnailSelected( this, new ThumbnailSelectedEventArgs( this.name ) );
			}
		}



		private void btnInsertOriginalImage_Click(object sender, EventArgs e)
		{
			if( ThumbnailSelected != null )
			{
				ThumbnailSelected( this, new ThumbnailSelectedEventArgs( this.name ) );
			}
		}





		public delegate void onDeleteClick(object sender, ImageManagement.DeleteImageClickedEventArgs e);
		public event onDeleteClick DeleteClick;

		// Invokes delegates registered with the Click event.
		protected virtual void OnDeleteClicked(ImageManagement.DeleteImageClickedEventArgs e) 
		{                  
			try
			{
				if (DeleteClick != null) 
				{
					DeleteClick(this, e);
				} 
			}
			catch( System.Exception ex )
			{
                ExceptionManager.Publish(ex, EventIds.Default.Error);
			}
    
		}


		#region ...   IPostBackEventHandler Members   ...

		public void RaisePostBackEvent(string eventArgument)
		{
			// TODO:  Add ThumbnailPanel.RaisePostBackEvent implementation
			OnDeleteClicked(new ImageManagement.DeleteImageClickedEventArgs( eventArgument ));
		}


		#endregion
	}
}
