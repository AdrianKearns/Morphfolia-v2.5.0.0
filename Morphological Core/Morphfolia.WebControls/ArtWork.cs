// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morphfolia.WebControls
{
	/// <summary>
	/// Summary description for ArtWork.
	/// </summary>
	public class ArtWork : WebControl
	{
		private Table tblArtWork;
		private TableRow trArtWork;
		private TableCell tdArtWork;
		private Image imgArtWork;
		private TableRow trTitle;
		private TableCell tdTitle; // + year
		private TableRow trMedia;
		private TableCell tdMedia;
		private TableRow trDimensions;
		private TableCell tdDimensions;

		private TableRow trSignatureDetails;
		private TableCell tdSignatureDetails;

		private TableRow trAcquisition;
		private TableCell tdAcquisition;

		private TableRow trPublications;
		private TableCell tdPublications;

		private TableRow trEditionNumber;
		private TableCell tdEditionNumber;

		private TableRow trNotes;
		private TableCell tdNotes;


		public const string UntitledWork = "Untitled";


		private string imageUrl = string.Empty;
		public string ImageUrl
		{
			get{ return imageUrl; }
			set{ imageUrl = value; }
		}

		private string title = ArtWork.UntitledWork;
		/// <summary>
		/// The name of the work.
		/// </summary>
		public string Title
		{
			get{ return title; }
			set{ title = value; }
		}

		private string year = string.Empty;
		/// <summary>
		/// The date/year the work was finished / worked on.
		/// </summary>
		public string Year
		{
			get{ return year; }
			set{ year = value; }
		}

		private string media = string.Empty;
		/// <summary>
		/// What materials the work is made of / on.
		/// </summary>
		public string Media
		{
			get{ return media; }
			set{ media = value; }
		}

		private string dimensions = string.Empty;
		/// <summary>
		/// The physical size of the work.
		/// </summary>
		public string Dimensions
		{
			get{ return dimensions; }
			set{ dimensions = value; }
		}

		private string signatureDetails = string.Empty;
		/// <summary>
		/// Notes regarding how the work is named/signed (if such details are present / applicable).
		/// </summary>
		public string SignatureDetails
		{
			get{ return signatureDetails; }
			set{ signatureDetails = value; }
		}

		private string acquisition = string.Empty;
		/// <summary>
		/// Notes regarding when the work was acquired and where it is now located.
		/// </summary>
		public string Acquisition
		{
			get{ return acquisition; }
			set{ acquisition = value; }
		}

		private string publications = string.Empty;
		/// <summary>
		/// Notes regarding when the work was published / reproduced (if applicable).
		/// </summary>
		public string Publications
		{
			get{ return publications; }
			set{ publications = value; }
		}

		private string editionNumber = string.Empty;
		/// <summary>
		/// Notes regarding the edition of the work (if applicable).
		/// </summary>
		public string EditionNumber
		{
			get{ return editionNumber; }
			set{ editionNumber = value; }
		}

		private string notes = string.Empty;
		/// <summary>
		/// Any general notes relating to the work.
		/// </summary>
		public string Notes
		{
			get{ return notes; }
			set{ notes = value; }
		}


		private HorizontalAlign horizontalAlignment = HorizontalAlign.NotSet;
		/// <summary>
		/// Specifies the HorizontalAlign of the ArtWork WebControl as a whole.
		/// </summary>
		public HorizontalAlign HorizontalAlignment
		{
			get{ return horizontalAlignment; }
			set{ horizontalAlignment = value; }
		}

		private HorizontalAlign titleHorizontalAlignment = HorizontalAlign.NotSet;
		/// <summary>
		/// Specifies the HorizontalAlign of only the title and year of the work.
		/// </summary>
		public HorizontalAlign TitleHorizontalAlignment
		{
			get{ return titleHorizontalAlignment; }
			set{ titleHorizontalAlignment = value; }
		}

		private HorizontalAlign otherTextHorizontalAlignment = HorizontalAlign.NotSet;
		/// <summary>
		/// Specifies the HorizontalAlign ofall the text (excpet the Title and Year).
		/// </summary>
		public HorizontalAlign OtherTextHorizontalAlignment
		{
			get{ return otherTextHorizontalAlignment; }
			set{ otherTextHorizontalAlignment = value; }
		}

		/// <exclude />
		protected override void CreateChildControls()
		{
			base.CreateChildControls ();

			tblArtWork = new Table();
			Controls.Add( tblArtWork );
			//tblArtWork.Attributes.Add("border", "1");
			tblArtWork.CellPadding = 3;
			tblArtWork.CellSpacing = 0;


			trArtWork = new TableRow();
			Controls.Add( trArtWork );
			tblArtWork.Rows.Add( trArtWork );

			tdArtWork = new TableCell();
			Controls.Add( tdArtWork );
			trArtWork.Cells.Add( tdArtWork );
			
			imgArtWork = new Image();
			Controls.Add( imgArtWork );
			tdArtWork.Controls.Add( imgArtWork );


			// Title + Year -------------------------------------------------------------------
			trTitle = new TableRow();
			Controls.Add( trTitle );
			tblArtWork.Rows.Add( trTitle );

			tdTitle = new TableCell();
			Controls.Add( tdTitle );
			trTitle.Cells.Add( tdTitle );


			// Dimensions -------------------------------------------------------------------
			trDimensions = new TableRow();
			Controls.Add( trDimensions );
			tblArtWork.Rows.Add( trDimensions );
			trDimensions.Visible = false;

			tdDimensions = new TableCell();
			Controls.Add( tdDimensions );
			trDimensions.Cells.Add( tdDimensions );


			// Media -------------------------------------------------------------------
			trMedia = new TableRow();
			Controls.Add( trMedia );
			tblArtWork.Rows.Add( trMedia );
			trMedia.Visible = false;

			tdMedia = new TableCell();
			Controls.Add( tdMedia );
			trMedia.Cells.Add( tdMedia );


			// SignatureDetails -------------------------------------------------------------------
			trSignatureDetails = new TableRow();
			Controls.Add( trSignatureDetails );
			tblArtWork.Rows.Add( trSignatureDetails );
			trSignatureDetails.Visible = false;

			tdSignatureDetails = new TableCell();
			Controls.Add( tdSignatureDetails );
			trSignatureDetails.Cells.Add( tdSignatureDetails );


			// Acquisition -------------------------------------------------------------------
			trAcquisition = new TableRow();
			Controls.Add( trAcquisition );
			tblArtWork.Rows.Add( trAcquisition );
			trAcquisition.Visible = false;

			tdAcquisition = new TableCell();
			Controls.Add( tdAcquisition );
			trAcquisition.Cells.Add( tdAcquisition );


			// Publications -------------------------------------------------------------------
			trPublications = new TableRow();
			Controls.Add( trPublications );
			tblArtWork.Rows.Add( trPublications );
			trPublications.Visible = false;

			tdPublications = new TableCell();
			Controls.Add( tdPublications );
			trPublications.Cells.Add( tdPublications );


			// EditionNumber -------------------------------------------------------------------
			trEditionNumber = new TableRow();
			Controls.Add( trEditionNumber );
			tblArtWork.Rows.Add( trEditionNumber );
			trEditionNumber.Visible = false;

			tdEditionNumber = new TableCell();
			Controls.Add( tdEditionNumber );
			trEditionNumber.Cells.Add( tdEditionNumber );


			// Notes -------------------------------------------------------------------
			trNotes = new TableRow();
			Controls.Add( trNotes );
			tblArtWork.Rows.Add( trNotes );
			trNotes.Visible = false;

			tdNotes = new TableCell();
			Controls.Add( tdNotes );
			trNotes.Cells.Add( tdNotes );
		}


		/// <exclude />
		protected override void RenderContents(HtmlTextWriter writer)
		{
			EnsureChildControls();

			if( Visible )
			{
				if( !ImageUrl.Equals(string.Empty) )
				{
					imgArtWork.ImageUrl = ImageUrl;
					trArtWork.Visible = true;
				}

				if( !Title.Equals(string.Empty) )
				{
					if( !Year.Equals(string.Empty) )
					{
						//tdTitle.Text = string.Format("{0}, {1}", Title, Year);
						tdTitle.Text = string.Format("<b>{0}</b>, {1}", Title, Year);
					}
					else
					{
						//tdTitle.Text = Title;
						tdTitle.Text = string.Format("<b>{0}</b>", Title);
					}
				}
				else
				{
					//tdTitle.Text = ArtWork.UntitledWork;
					tdTitle.Text = string.Format("<b>{0}</b>", ArtWork.UntitledWork);
				}

				if( !Dimensions.Equals(string.Empty) )
				{
					tdDimensions.Text = Dimensions;
					trDimensions.Visible = true;
				}

				if( !Media.Equals(string.Empty) )
				{
					tdMedia.Text = Media;
					trMedia.Visible = true;
				}

				if( !SignatureDetails.Equals(string.Empty) )
				{
					tdSignatureDetails.Text = SignatureDetails;
					trSignatureDetails.Visible = true;
				}

				if( !Acquisition.Equals(string.Empty) )
				{
					tdAcquisition.Text = Acquisition;
					trAcquisition.Visible = true;
				}

				if( !Publications.Equals(string.Empty) )
				{
					tdPublications.Text = Publications;
					trPublications.Visible = true;
				}

				if( !EditionNumber.Equals(string.Empty) )
				{
					tdEditionNumber.Text = EditionNumber;
					trEditionNumber.Visible = true;
				}

				if( !Notes.Equals(string.Empty) )
				{
					tdNotes.Text = Notes;
					trNotes.Visible = true;
				}
			}

			tblArtWork.HorizontalAlign = HorizontalAlignment;

			tdTitle.HorizontalAlign = TitleHorizontalAlignment;
			tdDimensions.HorizontalAlign = OtherTextHorizontalAlignment;
			tdMedia.HorizontalAlign = OtherTextHorizontalAlignment;
			tdSignatureDetails.HorizontalAlign = OtherTextHorizontalAlignment;
			tdAcquisition.HorizontalAlign = OtherTextHorizontalAlignment;
			tdPublications.HorizontalAlign = OtherTextHorizontalAlignment;
			tdEditionNumber.HorizontalAlign = OtherTextHorizontalAlignment;
			tdNotes.HorizontalAlign = OtherTextHorizontalAlignment;

			base.RenderContents( writer );
		}


	}
}
