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


namespace Morphfolia.WebControls.FileControls
{
	/// <summary>
	/// Summary description for FileListingPanel.
	/// </summary>
	public class FileListingPanel : WebControl, INamingContainer, IPostBackEventHandler
	{
		private Table tblFileListingPanel;
		private TableRow tr;
		private TableRow trInsertFileListing;
		private TableCell tdFileListing;
		private TableCell tdFileListingName;
		private TableCell tdDimensions;
		private TableCell tdDelete;
		private TableCell tdInsertFileListingFileListing;
		//private TableCell tdInsertOriginalFileListing;

		private HtmlButton hbtnConvertSelectedTextIntoLinkToFile;
		private HtmlButton hbtnInsertLinkToFile;
		private HtmlButton hbtnDelete;

		private Image imgFileTypeIcon;
		private HyperLink hypOpenFileFromIcon;
		private HyperLink hypOpenFileFromName;



		public FileListingPanel()
		{
		}


		public delegate void onFileListingSelected(object sender, FileListingSelectedEventArgs e);

		public event onFileListingSelected FileListingSelected;

		public class FileListingSelectedEventArgs : System.EventArgs
		{
			public FileListingSelectedEventArgs( string fileListingUrl )
			{
	
				this.FileListingUrl = fileListingUrl;
			}

			public string FileListingUrl;
		}




		private FileInfo fileInfo;
		public FileInfo File
		{
			get{ return fileInfo; }
			set
			{ 
				fileInfo = value; 
				fileName = fileInfo.Name;
				extension = fileInfo.Extension;
				fileListingUrl = string.Format("{0}/{1}/{2}", 
					WebUtilities.VirtualApplicationRoot(),
                    Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath,
                    fileName );
				sizeInBytes = fileInfo.Length;
			}
		}


		private string fileName = string.Empty;
		public string FileName
		{
			get{ return fileName; }
		}


		private string extension = string.Empty;
		public string Extension
		{
			get{ return extension; }
		}


		private string fileListingUrl;
		public string FileListingUrl
		{
			get{ return fileListingUrl; }
		}


		private string locationOfFileTypeIconsFolder = string.Empty;
		public string LocationOfFileTypeIconsFolder
		{
			get{ return locationOfFileTypeIconsFolder; }
			set{ locationOfFileTypeIconsFolder = value; }
		}


		private long sizeInBytes;
		public long FileSizeInBytes
		{
			get{ return sizeInBytes; }
		}

		public string FileSize
		{
			get
			{
				decimal decTemp;

				// 1,024 = 1 Kb
				if( sizeInBytes < 1024 )
				{
					return string.Format("{0} Bytes", sizeInBytes.ToString() );
				}

				// 1,048,576 = 1 Mb
				if( sizeInBytes < 1048576 )
				{
					//decTemp = decimal.Truncate( (decimal)sizeInBytes * (decimal)0.001 );
					decTemp = (decimal)sizeInBytes * (decimal)0.001;
					return string.Format("{0} Kb", decimal.Round( decTemp, 2 ).ToString() );
				}

				// 1,073,741,824 = 1 Gb
				if( sizeInBytes < 1073741824 )
				{
					//decTemp = decimal.Truncate( (decimal)sizeInBytes * (decimal)0.000001 );
					decTemp = (decimal)sizeInBytes * (decimal)0.000001;
					return string.Format("{0} Mb", decimal.Round( decTemp, 2 ).ToString() );
				}
				
				// 1,099,511,627,776 = 1 Tb
				if( sizeInBytes < 1099511627776 )
				{
					//decTemp = decimal.Truncate( (decimal)sizeInBytes * (decimal)0.000000001 );
					decTemp = (decimal)sizeInBytes * (decimal)0.000000001;
					return string.Format("{0} Gb", decimal.Round( decTemp, 2 ).ToString() );
				}			

				// a REALY big file.
				return string.Format("{0} Bytes", sizeInBytes.ToString() );
			}
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



		/// <exclude/>
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();
            
			if( !this.Page.ClientScript.IsClientScriptBlockRegistered(ClientScriptRegistrationKeys.FileListingHelper) )
			{
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), ClientScriptRegistrationKeys.FileListingHelper, string.Format("<script language=javascript src='{0}/Morphfolia/JavaScript/FileListingHelper.js'></script>", WebUtilities.VirtualApplicationRoot()));
			}

			tblFileListingPanel = new Table();
			this.Controls.Add( tblFileListingPanel );
			//tblFileListingPanel.Attributes.Add("border", "1");
			tblFileListingPanel.CellPadding = 5;
			tblFileListingPanel.CellSpacing = 0;


			tr = new TableRow();
			this.Controls.Add( tr );
			tblFileListingPanel.Rows.Add( tr );

			tdFileListing = new TableCell();
			this.Controls.Add( tdFileListing );
			tr.Cells.Add( tdFileListing );
			tdFileListing.RowSpan = 4;
			tdFileListing.VerticalAlign = VerticalAlign.Top;
			tdFileListing.Width = Unit.Pixel(20);

			hypOpenFileFromIcon = new HyperLink();
			this.Controls.Add( hypOpenFileFromIcon );
			tdFileListing.Controls.Add( hypOpenFileFromIcon );

			imgFileTypeIcon = new Image();
			this.Controls.Add( imgFileTypeIcon );
			hypOpenFileFromIcon.Controls.Add( imgFileTypeIcon );


			tdFileListingName = new TableCell();
			this.Controls.Add( tdFileListingName );
			tr.Cells.Add( tdFileListingName );
			tdFileListingName.ColumnSpan = 2;

			hypOpenFileFromName = new HyperLink();
			this.Controls.Add( hypOpenFileFromName );
			tdFileListingName.Controls.Add( hypOpenFileFromName );


			tr = new TableRow();
			this.Controls.Add( tr );
			tblFileListingPanel.Rows.Add( tr );

			tdDimensions = new TableCell();
			this.Controls.Add( tdDimensions );
			tr.Cells.Add( tdDimensions );

			tdDelete = new TableCell();
			this.Controls.Add( tdDelete );
			tr.Cells.Add( tdDelete );
			tdDelete.HorizontalAlign = HorizontalAlign.Right;

			hbtnDelete = new HtmlButton();
			this.Controls.Add( hbtnDelete );
			tdDelete.Controls.Add( hbtnDelete );
			hbtnDelete.ID = "hbtnDelete";
			hbtnDelete.InnerText = "Delete";
			//hbtnDelete.Attributes.Add("class", "btn");
			
			


			trInsertFileListing = new TableRow();
			this.Controls.Add( trInsertFileListing );
			tblFileListingPanel.Rows.Add( trInsertFileListing );

			tdInsertFileListingFileListing = new TableCell();
			this.Controls.Add( tdInsertFileListingFileListing );
			trInsertFileListing.Cells.Add( tdInsertFileListingFileListing );
			tdInsertFileListingFileListing.ColumnSpan = 2;




			if( this.UseClientSideMode )
			{
				trInsertFileListing.Visible = true;

				hbtnConvertSelectedTextIntoLinkToFile = new HtmlButton();
				this.Controls.Add( hbtnConvertSelectedTextIntoLinkToFile );
				tdInsertFileListingFileListing.Controls.Add( hbtnConvertSelectedTextIntoLinkToFile );
				hbtnConvertSelectedTextIntoLinkToFile.ID = "hbtnConvertSelectedTextIntoLinkToFile";
				hbtnConvertSelectedTextIntoLinkToFile.InnerText = "Convert To Link To File";
				hbtnConvertSelectedTextIntoLinkToFile.Attributes.Add( "onclick", string.Format("FileListingClicked('{0}', 'CreateLink'); return false;", this.FileListingUrl ) );
				//hbtnConvertSelectedTextIntoLinkToFile.Attributes.Add("class", "btn");

				hbtnInsertLinkToFile = new HtmlButton();
				this.Controls.Add( hbtnInsertLinkToFile );
				tdInsertFileListingFileListing.Controls.Add( hbtnInsertLinkToFile );
				hbtnInsertLinkToFile.ID = "hbtnInsertLinkToFile";
				hbtnInsertLinkToFile.InnerText = "Insert Link To File";
                hbtnInsertLinkToFile.Attributes.Add("onclick", string.Format("FileListingClicked('{0}', 'insertLinkToFile'); return false;", this.FileListingUrl));
				//hbtnInsertLinkToFile.Attributes.Add("class", "btn");
			}
			else
			{
				trInsertFileListing.Visible = false;
			}
		}
			

		/// <exclude />
		protected override void Render(HtmlTextWriter writer)
		{
			EnsureChildControls();

			tblFileListingPanel.Width = Width;

            if (CssClass.Equals(string.Empty))
            {
                CssClass = "VerticalDividerBottom";
            }
			tblFileListingPanel.CssClass = CssClass;

			hypOpenFileFromIcon.NavigateUrl = string.Format("{0}", this.FileListingUrl );
			hypOpenFileFromIcon.Target = "_blank";

			hypOpenFileFromName.NavigateUrl = string.Format("{0}", this.FileListingUrl );
			hypOpenFileFromName.Target = "_blank";
			hypOpenFileFromName.Text = this.fileName;
			hypOpenFileFromName.Style.Add("font-weight", "700");

			tdDimensions.Text = FileSize;

            hbtnDelete.Attributes.Add("onclick", string.Format("if(confirm('Are you sure you want to delete?')){0};", Page.ClientScript.GetPostBackEventReference(this, this.fileName)));


			switch( extension.ToLower() )
			{
				case ".mdb":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Access);
					break;

				case ".xls":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Excel);
					break;

				case ".gif":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Gif);
					break;

				case ".jpg":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Jpg);
					break;

				case ".pdf":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.PDF);
					break;

				case ".ppt":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.PowerPoint);
					break;
				case ".ppp":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.PowerPoint);
					break;

				case ".txt":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Text);
					break;

				case ".vsd":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Visio);
					break;

				case ".htm":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.WebPage);
					break;
				case ".html":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.WebPage);
					break;

				case ".doc":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.WordDocument);
					break;
				case ".rtf":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.WordDocument);
					break;

				case ".zip":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Zip);
					break;

				case ".mp3":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Mp3);
					break;
				case ".wav":
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Mp3);
					break;

				default:
					imgFileTypeIcon.ImageUrl = string.Format("{0}/{1}", locationOfFileTypeIconsFolder, Morphfolia.Common.Constants.Framework.FileTypeIcons.Unknown);
					break;
			}


			if( Visible )
			{
				RenderChildren( writer );
			}
		}



		private void btnInsertFileListingFileListing_Click(object sender, EventArgs e)
		{
			if( FileListingSelected != null )
			{
				FileListingSelected( this, new FileListingSelectedEventArgs( this.fileName ) );
			}
		}



		private void btnInsertOriginalFileListing_Click(object sender, EventArgs e)
		{
			if( FileListingSelected != null )
			{
				FileListingSelected( this, new FileListingSelectedEventArgs( this.fileName ) );
			}
		}





		public delegate void onDeleteClick(object sender, FileManagement.DeleteFileListingClickedEventArgs e);
		public event onDeleteClick DeleteClick;

		// Invokes delegates registered with the Click event.
		protected virtual void OnDeleteClicked(FileManagement.DeleteFileListingClickedEventArgs e) 
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
			OnDeleteClicked(new FileManagement.DeleteFileListingClickedEventArgs( eventArgument ));
		}


		#endregion
	}
}
