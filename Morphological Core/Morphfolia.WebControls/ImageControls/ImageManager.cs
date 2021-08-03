// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Morphfolia.WebControls.Utilities;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.WebControls
{
	/// <summary>
	/// Ensure that the parent server form has: enctype="multipart/form-data"
	/// </summary>
	public class ImageManager : WebControl, INamingContainer
	{
		private Panel pnlImageManager;
		private Label lblMessage;
		private Table tblImageUploader;	
		private TableRow tr;
		private TableHeaderCell th;
		private TableCell td;
		private HtmlInputFile txtFile;
		private Button btnUpload;
		private HtmlButton btnDisplayHide;

		private Panel pnlUploadStatus;
		private Label lblUploadStatus;

		private ThumbnailPanelCollection thumbnailPanelCollection;
		private ThumbnailFactory thumbnailFactory;



		public override string CssClass
		{
			get
			{
				if( base.CssClass == null )
				{
					base.CssClass = "ImageManager";
				}				
				if( base.CssClass.Equals(string.Empty) )
				{
					base.CssClass = "ImageManager";
				}
				return base.CssClass;
			}
			set
			{
				base.CssClass = value;
			}
		}





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





		private string masterImageDirectoryPath;
		/// <summary>
		/// The location to which the images are uploaded.
		/// </summary>
		public string MasterImageDirectoryPath
		{
			get{ return masterImageDirectoryPath; }
			set
			{ 
				masterImageDirectoryPath = value; 
			}
		}


		private string thumbnailImageDirectoryPath;
		/// <summary>
		/// The location to which Thumbnails are written.
		/// </summary>
		public string ThumbnailImageDirectoryPath
		{
			get{ return thumbnailImageDirectoryPath; }
			set
			{ 
				thumbnailImageDirectoryPath = value; 
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



		/// <exclude />
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();


            if (this.Page != null)
            {
                if (!this.Page.ClientScript.IsStartupScriptRegistered(ClientScriptRegistrationKeys.ImageManager))
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), ClientScriptRegistrationKeys.ImageManager, string.Format("<SCRIPT LANGUAGE='JScript' TYPE='text/javascript' SRC='{0}/Morphfolia/JavaScript/ImageManager.js'></SCRIPT>", WebUtilities.VirtualApplicationRoot()));
                }
            }

			pnlUploadStatus = new Panel();
			this.Controls.Add( pnlUploadStatus );
			pnlUploadStatus.ID = "ImageManagerPnlUploadStatus";
			pnlUploadStatus.Style.Add("position", "relative");
			pnlUploadStatus.CssClass = "pnlUploadStatus_hidden";

			lblUploadStatus = new Label();
			this.Controls.Add( lblUploadStatus );
			pnlUploadStatus.Controls.Add( lblUploadStatus ) ;
			lblUploadStatus.Text = "The selected image is being uploaded, please wait...";



			pnlImageManager = new Panel();
			this.Controls.Add( pnlImageManager );
			pnlImageManager.CssClass = this.CssClass;


			lblMessage = new Label();
			this.Controls.Add( lblMessage );
			pnlImageManager.Controls.Add( lblMessage );


			tblImageUploader = new Table();
			this.Controls.Add( tblImageUploader );
			pnlImageManager.Controls.Add( tblImageUploader );
			tblImageUploader.Width = Unit.Percentage(100);
			tblImageUploader.CellPadding = 5;
			tblImageUploader.CellSpacing = 0;



			
			tr = new TableRow();
			this.Controls.Add( tr );
			tblImageUploader.Rows.Add( tr );

			th = new TableHeaderCell();
			this.Controls.Add( th );
			tr.Cells.Add( th );
			th.ColumnSpan = 3;
			th.Text = "Image Manager";





			tr = new TableRow();
			this.Controls.Add( tr );
			tblImageUploader.Rows.Add( tr );

			td = new TableCell();
			this.Controls.Add( td );
			tr.Cells.Add( td );

			txtFile = new HtmlInputFile();
			this.Controls.Add( txtFile );
			td.Controls.Add( txtFile );
			txtFile.ID = "txtFile";
			txtFile.Size = 40;

			btnUpload = new Button();
			this.Controls.Add( btnUpload );
			td.Controls.Add( btnUpload );
			btnUpload.ID = "btnUpload";
			btnUpload.Text = "Upload";
			btnUpload.Click += new EventHandler(btnUpload_Click);
			btnUpload.Attributes.Add("onclick", "document.getElementById('" + pnlUploadStatus.ClientID + "').className='pnlUploadStatus';");


			td = new TableCell();
			this.Controls.Add( td );
			tr.Cells.Add( td );
			td.Text = "&nbsp;";


			td = new TableCell();
			this.Controls.Add( td );
			tr.Cells.Add( td );
			td.HorizontalAlign = HorizontalAlign.Right;

			btnDisplayHide = new HtmlButton();
			this.Controls.Add( btnDisplayHide );
			td.Controls.Add( btnDisplayHide );
			btnDisplayHide.ID = "btnDisplayHide";
			btnDisplayHide.InnerText = "...";



			thumbnailPanelCollection = new ThumbnailPanelCollection();
			this.Controls.Add( thumbnailPanelCollection );
			pnlImageManager.Controls.Add( thumbnailPanelCollection );
			thumbnailPanelCollection.ID = "thumbnailPanelCollection";
			thumbnailPanelCollection.UseClientSideMode = this.UseClientSideMode;
			thumbnailPanelCollection.MasterImagesDirectory = new DirectoryInfo( this.MasterImageDirectoryPath );
			thumbnailPanelCollection.ThumbnailDirectory = new DirectoryInfo( this.ThumbnailImageDirectoryPath );
			thumbnailPanelCollection.ThumbnailSelected += new Morphfolia.WebControls.ThumbnailPanelCollection.onThumbnailSelected(thumbnailPanelCollection_ThumbnailSelected);
			thumbnailPanelCollection.DeleteClick += new Morphfolia.WebControls.ThumbnailPanelCollection.onDeleteClick(thumbnailPanelCollection_DeleteClick);

			btnDisplayHide.Attributes.Add("onclick", string.Format("DisplayHideElement('{0}'); return false;", thumbnailPanelCollection.ClientID) );
		}
		


		/// <exclude />
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			EnsureChildControls();

			pnlImageManager.Width = Width;
			pnlImageManager.Height = Height;

			if( Visible )
			{
				this.RenderChildren( writer );
			}
		}



		private void btnUpload_Click(object sender, EventArgs e)
		{
			//lblMessage.Text = "btnUpload_Click";

			if (txtFile.PostedFile != null) 
			{
				thumbnailFactory = new ThumbnailFactory( this.ThumbnailImageDirectoryPath );
				try
				{
					int loop1;
					HttpFileCollection Files;
					string shortFileName;  // Test.txt
					string pathToUploadedImage;

					Files = Context.Request.Files; // Load File collection into HttpFileCollection variable.
					string[] arr1 = Files.AllKeys;  // This will get names of all files into a string array.
					for (loop1 = 0; loop1 < arr1.Length; loop1++) 
					{
						//Context.Response.Write("File- " + Context.Server.HtmlEncode( Files[loop1].FileName ) + "<br>");
						shortFileName = Files[loop1].FileName;
						if( shortFileName != "")
						{
							shortFileName = shortFileName.Substring( shortFileName.LastIndexOf(@"\")+1 );
							pathToUploadedImage = string.Format("{0}/{1}", this.MasterImageDirectoryPath, shortFileName);
							Files[loop1].SaveAs( pathToUploadedImage );


							Bitmap sourceBitmap = new Bitmap( pathToUploadedImage );						
							Morphfolia.Business.ImageFactory.SaveImageDetails( shortFileName, sourceBitmap.Width, sourceBitmap.Height);


							thumbnailFactory.MakeThumbnail( pathToUploadedImage, ThumbnailFactory.ScaleToDimension.Width, 150 );
						}
					}				
				}
				catch (Exception ex) 
				{
                    Morphfolia.Common.Logging.Logger.LogException("Image Manager, Upload failed.", ex);
                    lblMessage.Text = "Upload Failed.  Have your administrator check the system logs for the cause.";
				}
			}
			else
			{
				lblMessage.Text = "txtFile.PostedFile == null";
			}
		}



		private void thumbnailPanelCollection_ThumbnailSelected(object sender, Morphfolia.WebControls.ThumbnailPanelCollection.ThumbnailSelectedEventArgs e)
		{
			if( ThumbnailSelected != null )
			{
				ThumbnailSelected( this, new ThumbnailSelectedEventArgs( e.ImageUrl ) );
			}
		}


		private void thumbnailPanelCollection_DeleteClick(object sender, Morphfolia.WebControls.ImageManagement.DeleteImageClickedEventArgs e)
		{
			string imageToDelete = e.ImageToDelete;
			string pathToImageToDelete;
			
			try
			{
				pathToImageToDelete = string.Format(@"{0}\{1}", this.MasterImageDirectoryPath, imageToDelete);
				File.Delete( pathToImageToDelete );
			}
			catch
			{
				throw;
			}

			try
			{
				pathToImageToDelete = string.Format(@"{0}\{1}", this.ThumbnailImageDirectoryPath, imageToDelete);
				File.Delete( pathToImageToDelete );
			}
			catch
			{
				throw;
			}

			this.thumbnailPanelCollection.Reset();
		}
	}
}
