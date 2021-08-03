// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections.Specialized; 
using Morphfolia.Common.Logging;


namespace Morphfolia.WebControls
{
	/// <summary>
	/// Summary description for ThumbnailPanel.
	/// </summary>
	public class ThumbnailPanelCollection : WebControl, INamingContainer
	{
		private Panel pnlThumbnailPanelCollection;
		private Table tblThumbnailPanelCollection;
		private TableRow tr;
		private TableCell td;



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



		public enum Dimension{ NotSet, Columns, Rows }


		private Dimension activeDimension;
		public Dimension ActiveDimension
		{
			get{ return activeDimension; }
			set{ activeDimension = value; }
		}

		private int rows;
		public int Rows
		{
			get{ return rows; }
			set{ 
				rows = value; 
				activeDimension = Dimension.Rows;
			}
		}

		private int columns;
		public int Columns
		{
			get{ return columns; }
			set{ 
				columns = value; 
				activeDimension = Dimension.Columns;
			}
		}


		private DirectoryInfo thumbnailDirectory;
		/// <summary>
		/// The directory which contains the thumbnail image files.
		/// </summary>
		public DirectoryInfo ThumbnailDirectory
		{
			get{ return thumbnailDirectory; }
			set{ thumbnailDirectory = value; }
		}

		private DirectoryInfo masterImagesDirectory;
		/// <summary>
		/// The directory which contains the original images, from 
		/// which the thumbnail image files were generated.
		/// </summary>
		public DirectoryInfo MasterImagesDirectory
		{
			get{ return masterImagesDirectory; }
			set{ masterImagesDirectory = value; }
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



		public void Reset()
		{
			this.Controls.Clear();
			CreateChildControls();
		}




		/// <exclude />
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();


			ThumbnailPanel thumbnailPanel;


			pnlThumbnailPanelCollection = new Panel();
			this.Controls.Add( pnlThumbnailPanelCollection );
			pnlThumbnailPanelCollection.Style.Add("height", "200px");
			pnlThumbnailPanelCollection.Style.Add("overflow", "scroll");
			pnlThumbnailPanelCollection.CssClass = "FunctionalArea_whiteBg";
			//pnlThumbnailPanelCollection.ID = "ThumbnailPanelCollection";


			tblThumbnailPanelCollection = new Table();
			this.Controls.Add( tblThumbnailPanelCollection );
			pnlThumbnailPanelCollection.Controls.Add( tblThumbnailPanelCollection );
			tblThumbnailPanelCollection.CellPadding = 5;
			tblThumbnailPanelCollection.CellSpacing = 0;
			//tblThumbnailPanelCollection.Attributes.Add("border", "1");

			//bool showFile;
			string tempFudge;

			if( this.ThumbnailDirectory != null )
			{
				foreach( FileInfo fileInfo in this.MasterImagesDirectory.GetFiles() )
				{

					switch( fileInfo.Extension.ToLower() )
					{
						case ".jpg":
							break;

						case ".gif":
							break;

						case ".bmp":
							break;

						case ".png":
							break;

						default:
							continue;
					}


					tr = new TableRow();
					this.Controls.Add( tr );
					tblThumbnailPanelCollection.Rows.Add( tr );

					td = new TableCell();
					this.Controls.Add( td );
					tr.Cells.Add( td );

					thumbnailPanel = new ThumbnailPanel();
					this.Controls.Add( thumbnailPanel );

					tempFudge = fileInfo.FullName;
					tempFudge = tempFudge.Replace(this.MasterImagesDirectory.Name, this.ThumbnailDirectory.Name);
					thumbnailPanel.ImageUrl = tempFudge;
					thumbnailPanel.Width = Unit.Pixel(560);

					thumbnailPanel.UseClientSideMode = this.UseClientSideMode;
					td.Controls.Add( thumbnailPanel );
					thumbnailPanel.ThumbnailSelected += new Morphfolia.WebControls.ThumbnailPanel.onThumbnailSelected(thumbnailPanel_ThumbnailSelected);
					thumbnailPanel.DeleteClick += new Morphfolia.WebControls.ThumbnailPanel.onDeleteClick(thumbnailPanel_DeleteClick);
				}
			}
		}

			
		/// <exclude />
		protected override void Render(HtmlTextWriter writer)
		{
			EnsureChildControls();

			this.pnlThumbnailPanelCollection.Attributes.Add("id", this.ClientID);
			this.pnlThumbnailPanelCollection.Width = Unit.Percentage(100);
			pnlThumbnailPanelCollection.Style.Add("height", "450px");


			if( this.UseClientSideMode == true )
			{
				this.pnlThumbnailPanelCollection.Style.Add("display", "none");
			}

			if( Visible )
			{
				RenderChildren( writer );
			}
		}


		private void thumbnailPanel_ThumbnailSelected(object sender, Morphfolia.WebControls.ThumbnailPanel.ThumbnailSelectedEventArgs e)
		{
			if( ThumbnailSelected != null )
			{
				ThumbnailSelected( this, new ThumbnailSelectedEventArgs( e.ImageUrl ) );
			}
		}



		public delegate void onDeleteClick(object sender, ImageManagement.DeleteImageClickedEventArgs e);
		public event onDeleteClick DeleteClick;

		private void thumbnailPanel_DeleteClick(object sender, Morphfolia.WebControls.ImageManagement.DeleteImageClickedEventArgs e)
		{
			try
			{
				if( DeleteClick != null )
				{
					DeleteClick(sender, e);
				}
			}
			catch( System.Exception ex )
			{
                ExceptionManager.Publish(ex, EventIds.Default.Error);
			}
		}
	}
}