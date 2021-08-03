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
using Morphfolia.WebControls.Utilities;


namespace Morphfolia.WebControls.FileControls
{
	/// <summary>
	/// Summary description for FileListingPanel.
	/// </summary>
	public class FileListingPanelCollection : WebControl, INamingContainer
	{
		private Panel pnlFileListingPanelCollection;
		private Table tblFileListingPanelCollection;
		private TableRow tr;
		private TableCell td;



		public delegate void onFileListingSelected(object sender, FileListingSelectedEventArgs e);

		public event onFileListingSelected FileListingSelected;

		public class FileListingSelectedEventArgs : System.EventArgs
		{
			public FileListingSelectedEventArgs( string fileListingUrl )
			{
	
				this.fileListingUrl = fileListingUrl;
			}

			public string fileListingUrl;
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


		private DirectoryInfo fileListingDirectory;
		/// <summary>
		/// The directory which contains the FileListing fileListing files.
		/// </summary>
		public DirectoryInfo FileListingDirectory
		{
			get{ return fileListingDirectory; }
			set{ fileListingDirectory = value; }
		}

		private DirectoryInfo masterfileListingsDirectory;
		/// <summary>
		/// The directory which contains the original fileListings, from 
		/// which the FileListing fileListing files were generated.
		/// </summary>
		public DirectoryInfo MasterfileListingsDirectory
		{
			get{ return masterfileListingsDirectory; }
			set{ masterfileListingsDirectory = value; }
		}




		private bool useClientSideMode;
		/// <summary>
		/// If true, the control calls a standard JScript function, with the name of the fileListing as the only argument.
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


			FileListingPanel fileListingPanel;


			pnlFileListingPanelCollection = new Panel();
			this.Controls.Add( pnlFileListingPanelCollection );
			pnlFileListingPanelCollection.Style.Add("height", "200px");
			pnlFileListingPanelCollection.Style.Add("overflow", "scroll");
			pnlFileListingPanelCollection.CssClass = "FunctionalArea_whiteBg";
			//pnlFileListingPanelCollection.ID = "FileListingPanelCollection";


			tblFileListingPanelCollection = new Table();
			this.Controls.Add( tblFileListingPanelCollection );
			pnlFileListingPanelCollection.Controls.Add( tblFileListingPanelCollection );
			tblFileListingPanelCollection.CellPadding = 5;
			tblFileListingPanelCollection.CellSpacing = 0;
			//tblFileListingPanelCollection.Attributes.Add("border", "1");

			//bool showFile;
			//string tempFudge;

			if( this.FileListingDirectory != null )
			{
				if( !FileListingDirectory.Exists )
				{
					FileListingDirectory.Create();
				}

				foreach( FileInfo fileInfo in this.FileListingDirectory.GetFiles() )
				{
					tr = new TableRow();
					this.Controls.Add( tr );
					tblFileListingPanelCollection.Rows.Add( tr );

					td = new TableCell();
					this.Controls.Add( td );
					tr.Cells.Add( td );

					fileListingPanel = new FileListingPanel();
					this.Controls.Add( fileListingPanel );
					fileListingPanel.File = fileInfo;
					fileListingPanel.Width = Unit.Pixel(560);

					fileListingPanel.LocationOfFileTypeIconsFolder = WebUtilities.VirtualApplicationRoot();
					fileListingPanel.UseClientSideMode = this.UseClientSideMode;
					td.Controls.Add( fileListingPanel );

					fileListingPanel.FileListingSelected += new Morphfolia.WebControls.FileControls.FileListingPanel.onFileListingSelected(fileListingPanel_FileListingSelected);
					fileListingPanel.DeleteClick += new Morphfolia.WebControls.FileControls.FileListingPanel.onDeleteClick(fileListingPanel_DeleteClick);
				}
			}
		}

			

		/// <exclude />
		protected override void Render(HtmlTextWriter writer)
		{
			EnsureChildControls();

			pnlFileListingPanelCollection.Attributes.Add("id", this.ClientID);
			pnlFileListingPanelCollection.Width = Unit.Percentage(100);
			pnlFileListingPanelCollection.Style.Add("height", "450px");


			if( this.UseClientSideMode == true )
			{
				pnlFileListingPanelCollection.Style.Add("display", "none");
			}

			if( Visible )
			{
				RenderChildren( writer );
			}
		}





		public delegate void onDeleteClick(object sender, FileManagement.DeleteFileListingClickedEventArgs e);
		public event onDeleteClick DeleteClick;



		private void fileListingPanel_FileListingSelected(object sender, Morphfolia.WebControls.FileControls.FileListingPanel.FileListingSelectedEventArgs e)
		{
			if( FileListingSelected != null )
			{
				FileListingSelected( this, new FileListingSelectedEventArgs( e.FileListingUrl ) );
			}
		}

		private void fileListingPanel_DeleteClick(object sender, Morphfolia.WebControls.FileManagement.DeleteFileListingClickedEventArgs e)
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