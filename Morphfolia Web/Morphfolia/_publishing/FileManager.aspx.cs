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
	/// Summary description for FileManager.
	/// </summary>
    public partial class FileManager : System.Web.UI.Page
	{
		private Morphfolia.WebControls.FileControls.FileManager fileManager;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			fileManager = new Morphfolia.WebControls.FileControls.FileManager();
			pnlControls.Controls.Add( fileManager );
			fileManager.Width = Unit.Pixel(600);

			fileManager.FileListingFileDirectoryPath = Context.Server.MapPath( string.Format(@"{0}/{1}",
                Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot(),
                Morphfolia.Common.Constants.Framework.Various.FileListingDirectoryPath) );

			fileManager.FileListingSelected += new Morphfolia.WebControls.FileControls.FileManager.onFileListingSelected(fileManager_FileListingSelected);
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

		private void fileManager_FileListingSelected(object sender, Morphfolia.WebControls.FileControls.FileManager.FileListingSelectedEventArgs e)
		{
			Literal selectedFileUrl = new Literal();
			selectedFileUrl.Text = e.FileUrl;
			this.pnlControls.Controls.Add( selectedFileUrl );
		}
	}
}
