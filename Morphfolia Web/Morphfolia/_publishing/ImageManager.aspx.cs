// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Morphfolia.Common;

namespace Morphfolia.Web._publishing
{
	/// <summary>
	/// Summary description for ImageManager.
	/// </summary>
    public partial class ImageManagerPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Label Label1;
		protected Morphfolia.WebControls.ImageManager imageManager;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			imageManager = new Morphfolia.WebControls.ImageManager();
			this.pnlControls.Controls.Add( imageManager );
			imageManager.Width = Unit.Pixel(600);
			//imageManager.Height = Unit.Pixel(600);
			imageManager.ThumbnailImageDirectoryPath = Server.MapPath( Morphfolia.Common.Constants.Framework.Various.ThumbnailImageDirectoryPath );
            imageManager.MasterImageDirectoryPath = Server.MapPath(Morphfolia.Common.Constants.Framework.Various.MasterImageDirectoryPath);

			imageManager.ThumbnailImageDirectoryPath = Context.Server.MapPath( string.Format(@"{0}/{1}",
                Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot(),
                Morphfolia.Common.Constants.Framework.Various.ThumbnailImageDirectoryPath));
			imageManager.MasterImageDirectoryPath = Context.Server.MapPath( string.Format(@"{0}/{1}",
                Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot(),
                Morphfolia.Common.Constants.Framework.Various.MasterImageDirectoryPath));

			imageManager.ThumbnailSelected += new Morphfolia.WebControls.ImageManager.onThumbnailSelected(imageManager_ThumbnailSelected);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private void imageManager_ThumbnailSelected(object sender, Morphfolia.WebControls.ImageManager.ThumbnailSelectedEventArgs e)
		{
			Literal selectedImageUrl = new Literal();
			selectedImageUrl.Text = e.ImageUrl;
			this.pnlControls.Controls.Add( selectedImageUrl );
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
		
			if ( File1.PostedFile != null) 
			{
				try
				{
					int loop1;
					HttpFileCollection Files;
					string shortFileName;  // Test.txt
                    string uploadedDocsRootDirectoryPath = Server.MapPath(Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath);
					string pathToUploadedDocsRoot;

					Files = Context.Request.Files; // Load File collection into HttpFileCollection variable.
					string[] arr1 = Files.AllKeys;  // This will get names of all files into a string array.
					for (loop1 = 0; loop1 < arr1.Length; loop1++) 
					{

						shortFileName = Files[loop1].FileName;
						if( shortFileName != "")
						{
							shortFileName = shortFileName.Substring( shortFileName.LastIndexOf(@"\")+1 );
                            pathToUploadedDocsRoot = string.Format("{0}/{1}", Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath, shortFileName);
							Files[loop1].SaveAs( pathToUploadedDocsRoot );
						}
					}

				}
				catch(System.Exception ex)
				{
					Label1.Text = string.Format("<b>{0}</b><br>{1}<br><pre>{2}</pre>", ex.Message, ex.Source, ex.StackTrace);
				}
			}
		}
	}
}