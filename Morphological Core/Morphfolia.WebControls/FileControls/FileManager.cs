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

namespace Morphfolia.WebControls.FileControls
{
	/// <summary>
	/// Ensure that the parent server form has: enctype="multipart/form-data"
	/// </summary>
	public class FileManager : WebControl, INamingContainer
	{
		private Panel pnlFileManager;
		private Label lblMessage;
		private Table tblFileUploader;
		private TableRow tr;
		private TableHeaderCell th;
		private TableCell td;
		private HtmlInputFile txtFile;
		private Button btnUpload;
		private HtmlButton btnDisplayHide;

		private Panel pnlUploadStatus;
		private Label lblUploadStatus;

		private FileListingPanelCollection FileListingPanelCollection;
		private FileListingFactory FileListingFactory;


		public override string CssClass
		{
			get
			{
				if( base.CssClass == null )
				{
					base.CssClass = "FileManager";
				}				
				if( base.CssClass.Equals(string.Empty) )
				{
					base.CssClass = "FileManager";
				}
				return base.CssClass;
			}
			set
			{
				base.CssClass = value;
			}
		}





		public delegate void onFileListingSelected(object sender, FileListingSelectedEventArgs e);

		public event onFileListingSelected FileListingSelected;

		public class FileListingSelectedEventArgs : System.EventArgs
		{
			public FileListingSelectedEventArgs( string FileUrl )
			{
	
				this.FileUrl = FileUrl;
			}

			public string FileUrl;
		}



		private string fileListingFileDirectoryPath;
		/// <summary>
		/// The location to which FileListings are written.
		/// </summary>
		public string FileListingFileDirectoryPath
		{
			get{ return fileListingFileDirectoryPath; }
			set
			{ 
				fileListingFileDirectoryPath = value; 
			}
		}



		private bool useClientSideMode;
		/// <summary>
		/// If true, the control calls a standard JScript function, with the name of the File as the only argument.
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
                if (!this.Page.ClientScript.IsStartupScriptRegistered(ClientScriptRegistrationKeys.FileManager))
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), ClientScriptRegistrationKeys.FileManager, string.Format("<SCRIPT LANGUAGE='JScript' TYPE='text/javascript' SRC='{0}/Morphfolia/JavaScript/FileManager.js'></SCRIPT>", WebUtilities.VirtualApplicationRoot()));
                }
            }

			pnlUploadStatus = new Panel();
			this.Controls.Add( pnlUploadStatus );
			pnlUploadStatus.ID = "FileManagerPnlUploadStatus";
			pnlUploadStatus.Style.Add("position", "relative");
			pnlUploadStatus.CssClass = "pnlUploadStatus_hidden";

			lblUploadStatus = new Label();
			this.Controls.Add( lblUploadStatus );
			pnlUploadStatus.Controls.Add( lblUploadStatus ) ;
			lblUploadStatus.Text = "The selected File is being uploaded, please wait...";



			pnlFileManager = new Panel();
			this.Controls.Add( pnlFileManager );
			pnlFileManager.CssClass = this.CssClass;


			lblMessage = new Label();
			this.Controls.Add( lblMessage );
			pnlFileManager.Controls.Add( lblMessage );


			tblFileUploader = new Table();
			this.Controls.Add( tblFileUploader );
			pnlFileManager.Controls.Add( tblFileUploader );
			tblFileUploader.Width = Unit.Percentage(100);
			tblFileUploader.CellPadding = 5;
			tblFileUploader.CellSpacing = 0;



			
			tr = new TableRow();
			this.Controls.Add( tr );
			tblFileUploader.Rows.Add( tr );

			th = new TableHeaderCell();
			this.Controls.Add( th );
			tr.Cells.Add( th );
			th.ColumnSpan = 3;
			th.Text = "File Manager";





			tr = new TableRow();
			this.Controls.Add( tr );
			tblFileUploader.Rows.Add( tr );

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



			FileListingPanelCollection = new FileListingPanelCollection();
			this.Controls.Add( FileListingPanelCollection );
			pnlFileManager.Controls.Add( FileListingPanelCollection );
			FileListingPanelCollection.ID = "FileListingPanelCollection";
			FileListingPanelCollection.UseClientSideMode = this.UseClientSideMode;
			FileListingPanelCollection.FileListingDirectory = new DirectoryInfo( this.FileListingFileDirectoryPath );
			FileListingPanelCollection.FileListingSelected += new Morphfolia.WebControls.FileControls.FileListingPanelCollection.onFileListingSelected(FileListingPanelCollection_FileListingSelected);
			FileListingPanelCollection.DeleteClick += new Morphfolia.WebControls.FileControls.FileListingPanelCollection.onDeleteClick(FileListingPanelCollection_DeleteClick);

			btnDisplayHide.Attributes.Add("onclick", string.Format("DisplayHideElement('{0}'); return false;", FileListingPanelCollection.ClientID) );
		}
		

		/// <exclude />
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			EnsureChildControls();

			pnlFileManager.Width = Width;
			pnlFileManager.Height = Height;

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
				FileListingFactory = new FileListingFactory( this.FileListingFileDirectoryPath );
				try
				{
					int loop1;
					HttpFileCollection Files;
					string shortFileName;  // Test.txt
					string pathToUploadedFile;

					Files = Context.Request.Files; // Load File collection into HttpFileCollection variable.
					string[] arr1 = Files.AllKeys;  // This will get names of all files into a string array.
					for (loop1 = 0; loop1 < arr1.Length; loop1++) 
					{
						//Context.Response.Write("File- " + Context.Server.HtmlEncode( Files[loop1].FileName ) + "<br>");
						shortFileName = Files[loop1].FileName;
						if( shortFileName != "")
						{
							shortFileName = shortFileName.Substring( shortFileName.LastIndexOf(@"\")+1 );
							pathToUploadedFile = string.Format("{0}/{1}", this.FileListingFileDirectoryPath, shortFileName);
							Files[loop1].SaveAs( pathToUploadedFile );
						}
					}				
				}
				catch (Exception ex) 
				{
                    Morphfolia.Common.Logging.Logger.LogException("File Manager, Upload failed.", ex);
                    lblMessage.Text = "Upload Failed.  Have your administrator check the system logs for the cause.";
				}
			}
			else
			{
				lblMessage.Text = "txtFile.PostedFile == null";
			}
		}



		private void filePanelCollection_FileSelected(object sender, Morphfolia.WebControls.FileControls.FileListingPanelCollection.FileListingSelectedEventArgs e)
		{
			if( FileListingSelected != null )
			{
				FileListingSelected( this, new FileListingSelectedEventArgs( e.fileListingUrl ) );
			}
		}


		private void FileListingPanelCollection_DeleteClick(object sender, Morphfolia.WebControls.FileManagement.DeleteFileListingClickedEventArgs e)
		{
			string FileToDelete = e.FileToDelete;
			string pathToFileToDelete;
			
			try
			{
				pathToFileToDelete = string.Format(@"{0}\{1}", this.FileListingFileDirectoryPath, FileToDelete);
				File.Delete( pathToFileToDelete );
			}
			catch
			{
				throw;
			}

			try
			{
				pathToFileToDelete = string.Format(@"{0}\{1}", this.FileListingFileDirectoryPath, FileToDelete);
				File.Delete( pathToFileToDelete );
			}
			catch
			{
				throw;
			}

			this.FileListingPanelCollection.Reset();
		}

		private void FileListingPanelCollection_FileListingSelected(object sender, Morphfolia.WebControls.FileControls.FileListingPanelCollection.FileListingSelectedEventArgs e)
		{
			if( FileListingSelected != null )
			{
				FileListingSelected( this, new FileListingSelectedEventArgs( e.fileListingUrl ) );
			}
		}
	}
}
